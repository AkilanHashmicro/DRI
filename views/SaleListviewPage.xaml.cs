using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using SalesApp.Pages;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    
    public partial class SaleListviewPage : PopupPage
    {
        List<SalesOrder> saleresult = new List<SalesOrder>();
        public SaleListviewPage(int cus_id)
        {
            InitializeComponent();

          //  NavigationPage.SetHasNavigationBar(
            saleresult = Controller.InstanceCreation().GetSalesData(cus_id);
            salesOrderListView.ItemsSource = saleresult;

            var backImgRecognizer = new TapGestureRecognizer();
            backImgRecognizer.Tapped += (s, e) => {
                // handle the tap    

                //  Navigation.PopAllPopupAsync();
                PopupNavigation.PopAsync();

            };
            backImg.GestureRecognizers.Add(backImgRecognizer);

        }

        async void Loadingalertcall()
        {
            await PopupNavigation.PopAllAsync();
        }

        private void OnMenuItemTapped(object sender, ItemTappedEventArgs ea)
        {
            
            Navigation.PushPopupAsync(new SalesOrderListviewDetail(ea.Item as SalesOrder));
        
       // App.Current.MainPage = new MasterPage(new SalesOrderListviewDetail(ea.Item as SalesOrder));
            // App.Current.MainPage = new MasterPage(new SalesOrderDetailPage(ea.Item as SalesModel));
        }

        protected override bool OnBackButtonPressed()
        {
            PopupNavigation.PopAsync();
            return true;
        }

    }
}
