using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    public partial class NewSalesTargetPage : ContentPage
    {
        List<SalesTarget> saleresult = new List<SalesTarget>();
        public NewSalesTargetPage()
        {
            InitializeComponent();

            saleresult = Controller.InstanceCreation().salesTargetData();
            salesOrderListView.ItemsSource = saleresult; ;


        }

        async void Loadingalertcall()
        {
            await PopupNavigation.PopAllAsync();
        }

        private void OnMenuItemTapped(object sender, ItemTappedEventArgs ea)
        {

            //    App.Current.MainPage = new MasterPage(new SalesOrderListviewDetail(ea.Item as SalesOrder));
            // App.Current.MainPage = new MasterPage(new SalesOrderDetailPage(ea.Item as SalesModel));

            Navigation.PushAsync(new NewSalesTargetDetailPage(ea.Item as SalesTarget));
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            // obj.View.BackgroundColor = Color.FromHex("#414141");  
            obj.View.BackgroundColor = Color.White;
        }
    }
}
