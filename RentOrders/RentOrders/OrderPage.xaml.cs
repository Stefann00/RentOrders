using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentOrders.Models;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentOrders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
        }
        int count = 0;

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var phnumber = PhEntry.Text;
            var phpattern = ("[0-9]");
            if(Regex.IsMatch(phnumber,phpattern))
            {
                ErrorLabel.Text = "Error! Invalid number!!";
            }
            else
            {
                var olist = (OrderList)BindingContext;
                olist.Date = DateTime.UtcNow;
                olist.Title = "Order " + int.Parse(olist.ID.ToString());
                await App.Database.SaveOrderListAsync(olist);
                await Navigation.PopAsync();
            }
           

        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var olist = (OrderList)BindingContext;
            await App.Database.DeleteOrderListAsync(olist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            count++;
            if(count < 1) {
                await Navigation.PushAsync(new CarPage((OrderList)
               this.BindingContext)
                {
                    BindingContext = new Car()
                });
            }
            else
            {
                ButtonClick.IsEnabled = false; 
                CarError.Text="Only 1 vehicle per order is allowed!";

            }

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var orderl = (OrderList)BindingContext;

            listView.ItemsSource = await App.Database.GetListCarsAsync(orderl.ID);
        }

    }

}