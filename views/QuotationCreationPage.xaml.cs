using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalesApp.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotationCreationPage : ContentPage
    {
        public QuotationCreationPage()
        {
            InitializeComponent();
                      
        }

        private void check1_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if(check1.Checked == true)
            {
                check2.Checked = false;
            }

            else
            {
                check2.Checked = true;
            }
           
            cust.IsVisible = true;
            ivAddr.IsVisible = true;
            delAddr.IsVisible = true;
            retTemplate.IsVisible = true;

            oDate.IsVisible = false;
            exDate.IsVisible = false;
            priceList.IsVisible = false;
            paymentTerms.IsVisible = false;
        }

        private void check2_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if (check2.Checked == true)
            {
                check1.Checked = false;
            }

            else
            {
                check1.Checked = true;
            }

            cust.IsVisible = false;
            ivAddr.IsVisible = false;
            delAddr.IsVisible = false;
            retTemplate.IsVisible = false;

            oDate.IsVisible = true;
            exDate.IsVisible = true;
            priceList.IsVisible = true;
            paymentTerms.IsVisible = true;
        }
    }
}