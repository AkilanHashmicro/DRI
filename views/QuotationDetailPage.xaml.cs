using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using SalesApp.models;
using SalesApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalesApp.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuotationDetailPage : ContentPage
	{
        //public QuotationDetailPage (SalesModel item)
        public QuotationDetailPage()
        {
            InitializeComponent();
            PricePicker.SelectedIndex = 0;
           
		}

        private void PricePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PricePicker.SelectedItem == "Create")
            {
                Navigation.PushPopupAsync(new PriceListPopupPage());
            }
        }
    }
}