using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentOrders.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentOrders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarPage : ContentPage
    {
        OrderList ol;
        public CarPage(OrderList olist)
        {
            InitializeComponent();
            ol = olist;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var car = (Car)BindingContext;
            await App.Database.SaveCarAsync(car);
            listView.ItemsSource = await App.Database.GetCarsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var car = (Car)BindingContext;
            await App.Database.DeleteCarAsync(car);
            listView.ItemsSource = await App.Database.GetCarsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetCarsAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Car c;
            if (e.SelectedItem != null)
            {
                c = e.SelectedItem as Car;
                var lc = new ListCar()
                {
                    OrderListID = ol.ID,
                    CarID = c.ID
                };
                await App.Database.SaveListCarAsync(lc);
                c.ListCars = new List<ListCar> { lc };

                await Navigation.PopAsync();
            }
        }
    }
}