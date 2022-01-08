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
    public partial class OrderEntryPage : ContentPage
    {
        public OrderEntryPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetOrderListsAsync();
        }
        async void OnOrderListAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderPage
            {
                BindingContext = new OrderList()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new OrderPage
                {
                    BindingContext = e.SelectedItem as OrderList
                });
            }
        }
    }
}