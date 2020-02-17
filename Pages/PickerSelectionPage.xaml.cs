using System;
using System.Collections.Generic;
using System.Linq;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SalesApp.models.CRMModel;

namespace SalesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerSelectionPage : PopupPage
    {
        List<ProductsList> proesult = new List<ProductsList>();
        public PickerSelectionPage()
        {
            InitializeComponent();
            if (App.NetAvailable == true)
            {
                proesult = App.productList;
                pickerListView.ItemsSource = proesult;
            }

            if (App.NetAvailable == false)
            {
                
                proesult = App.ProductListDb;
                pickerListView.ItemsSource = proesult;
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                pickerListView.ItemsSource = App.productList;
            }

            //else if(e.NewTextValue =="")
            //{
            //    pickerListView.ItemsSource = App.productList.Select(x => x.Name).ToList();
            //}

            else
            {
                pickerListView.ItemsSource = App.productList.Where(x => x.Name.ToLower().Contains(e.NewTextValue.ToLower()));
               // pickerListView.ItemsSource = App.productList.Where(x => x.customer.ToLower().Contains(e.NewTextValue.ToLower()) || x.name.ToLower().Contains(e.NewTextValue.ToLower()));
            }

        }

        private void pickerListView_ItemTapped(object sender, ItemTappedEventArgs ea)
        {
            ProductsList masterItemObj = (ProductsList)ea.Item;

            MessagingCenter.Send<string, int>("MyApp", "PickerMsg", masterItemObj.Id);

            Navigation.PopPopupAsync();
           // Navigation.PushPopupAsync(new CrmLeadDetailWizard(masterItemObj, "Lead"));
        }


        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            obj.View.BackgroundColor = Color.FromHex("#f0eaea");
            //  m_title.TextColor = Color.Red;
        }

    }
}
