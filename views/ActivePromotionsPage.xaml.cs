using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using SalesApp.DBModel;
using SalesApp.models;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    public partial class ActivePromotionsPage : ContentPage
    {
        List<ActivePromotions> promotionresult = new List<ActivePromotions>();
        public ActivePromotionsPage()
        {
            InitializeComponent();


            // promotionresult = Controller.InstanceCreation().getPromotionData();
            List<CRMLead> crmLeadData = Controller.InstanceCreation().crmLeadData();

            salesOrderListView.ItemsSource = App.promotionsList;

            if (App.NetAvailable == false)
            {
                // promotionresult = Controller.InstanceCreation().getPromotionData();
                salesOrderListView.ItemsSource = App.promotionsListDB;
            }

            salesOrderListView.Refreshing += this.RefreshRequested;

            //catch
            //{
            //    promotionresult = Controller.InstanceCreation().getPromotionData();
            //    salesOrderListView.ItemsSource = App.promotionsListDB;
            //}


        }

        async void Loadingalertcall()
        {
            await PopupNavigation.PopAllAsync();
        }

        private void OnMenuItemTapped(object sender, ItemTappedEventArgs ea)
        {

            //    App.Current.MainPage = new MasterPage(new SalesOrderListviewDetail(ea.Item as SalesOrder));
            // App.Current.MainPage = new MasterPage(new SalesOrderDetailPage(ea.Item as SalesModel));

            //   Navigation.PushAsync(new TargetDetailPage(ea.Item as SalesTarget));

            try
            {

                Navigation.PushPopupAsync(new ActivePromotionDetailPage(ea.Item as ActivePromotions));
            }

            catch
            {
                if (App.NetAvailable == false)
                {
                    Navigation.PushPopupAsync(new ActivePromotionDetailPage(ea.Item as ActivePromotionsDB));
                }
            }
        }

        private void RefreshRequested(object sender, object e)
        {
            salesOrderListView.IsRefreshing = true;
            //   await Task.Delay(200);

            //  await RefreshData();

            if (App.NetAvailable == true)
            {

                List<CRMLead> crmLeadData = Controller.InstanceCreation().crmLeadData();
                salesOrderListView.ItemsSource = App.promotionsList;
                // salesQuotationListView.EndRefresh(); 

                salesOrderListView.IsRefreshing = false;
            }

            else if (App.NetAvailable == false)
            {
                // await Task.Delay(500);
                salesOrderListView.ItemsSource = App.promotionsListDB;
                salesOrderListView.EndRefresh();
            }
            salesOrderListView.EndRefresh();
        }


        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            // obj.View.BackgroundColor = Color.FromHex("#414141");  
            obj.View.BackgroundColor = Color.White;
        }
    }
}