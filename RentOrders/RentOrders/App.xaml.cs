using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RentOrders.Data;
using System.IO;

namespace RentOrders
{
    public partial class App : Application
    {
        static OrderDatabase database;
        public static OrderDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   OrderDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "OrdersDatabase.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new OrderEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
