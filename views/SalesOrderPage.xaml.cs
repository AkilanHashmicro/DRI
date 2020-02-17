using Rg.Plugins.Popup.Extensions;
using SalesApp.DBModel;
using SalesApp.models;
using SalesApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalesOrderPage : ContentPage
    {
        //public List<SalesModel> getSalesOrderDetails()
        //{
        //    //List<SalesModel> quotationData = Controller.InstanceCreation().salesOrderData("sales");
        //    //return quotationData;

        //    List<SalesModel> quotationData1 = Controller.InstanceCreation().salesOrderData1();
        //    return quotationData1;

        //}


        private async void RefreshDataconstructor()
        {
            await RefreshData();
        }

        public SalesOrderPage()
        {
            Title = "Sales Order";

            BackgroundColor = Color.White;
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                //Fixes an android bug where the search bar would be hidden
                searchBar.HeightRequest = 40.0;
            }

            try
            {
                if (App.filterstring == "Month" && App.load_rpc == true)
                {
                    List<CRMLead> crmLeadData = Controller.InstanceCreation().crmLeadData();
                }

                salesOrderListView.ItemsSource = App.salesOrderList;
            }

            catch (Exception ea)
            {
                if (ea.Message.Contains("(Network is unreachable)") || ea.Message.Contains("NameResolutionFailure"))
                {
                    App.NetAvailable = false;
                }

                else if (ea.Message.Contains("(503) Service Unavailable"))
                {
                    App.responseState = false;
                }
            }

            if (App.NetAvailable == false)
            {
                salesOrderListView.ItemsSource = App.SalesOrderListDb;
            }


            // salesOrderListView.ItemsSource = getSalesOrderDetails();
          //  salesOrderListView.ItemsSource = App.salesOrderList;
            salesOrderListView.Refreshing += this.RefreshRequested;
        }


        private void OnMenuItemTapped(object sender, ItemTappedEventArgs ea)
        {

            if (App.NetAvailable == true)
            {
              //  App.Current.MainPage = new MasterPage(new SalesOrderListviewDetail(ea.Item as SalesOrder));

                Navigation.PushPopupAsync(new SalesOrderListviewDetail(ea.Item as SalesOrder));
            }

            if (App.NetAvailable == false)
            {
               // App.Current.MainPage = new MasterPage(new SalesOrderListviewDetail(ea.Item as SalesOrderDB));
                Navigation.PushPopupAsync(new SalesOrderListviewDetail(ea.Item as SalesOrderDB));
            }
          // App.Current.MainPage = new MasterPage(new SalesOrderDetailPage(ea.Item as SalesModel));
        }

        async Task RefreshData()
        {
            List<CRMLead> crmLeadData = Controller.InstanceCreation().crmLeadData();
        }

        private async void RefreshRequested(object sender, object e)
        {
           // await Task.Delay(2000);
           // List<CRMLead> crmLeadData = Controller.InstanceCreation().crmLeadData();
            salesOrderListView.IsRefreshing = true;

            await RefreshData();

            if (App.filterstring == "Month" && App.load_rpc == true)
            {
                RefreshDataconstructor();
            }

            if (App.NetAvailable == true)
            {
                
                //   List<CRMLead> crmLeadData = Controller.InstanceCreation().crmLeadData();
                salesOrderListView.ItemsSource = App.salesOrderList;
                // salesQuotationListView.EndRefresh(); 

                salesOrderListView.IsRefreshing = false;
            }


            else if (App.NetAvailable == false)
            {
                // await Task.Delay(500);
                salesOrderListView.ItemsSource = App.SalesOrderListDb;
              //  salesQuotationListView.EndRefresh();
            }
            salesOrderListView.EndRefresh();

            //salesOrderListView.ItemsSource = App.salesOrderList;
            //salesOrderListView.EndRefresh();
        }

        private void Toolbar_Search_Activated(object sender, EventArgs e)
        {
            if (searchBar.IsVisible)
            {
                searchBar.IsVisible = false;
            }
            else { searchBar.IsVisible = true; }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                salesOrderListView.ItemsSource = App.salesOrderList; ;
            }

            else
            {
                salesOrderListView.ItemsSource = App.salesOrderList.Where(x => x.customer.ToLower().Contains(e.NewTextValue.ToLower()) || x.name.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }


        private void Toolbar_Filter_Activated(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new FilterPopupPage("tab4"));
            //Navigation.PushPopupAsync(new CrmFilterWizard());
        }

        private void Handle_FabClicked(object sender, EventArgs e)
        {

        }
    }
}