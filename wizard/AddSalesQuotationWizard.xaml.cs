using System;
using System.Collections.Generic;
using System.Linq;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using SalesApp.models;
using SalesApp.views;
using Xamarin.Forms;

namespace SalesApp.wizard
{
    public partial class AddSalesQuotationWizard : PopupPage
    {
        public AddSalesQuotationWizard()
        {
            InitializeComponent();

            Dictionary<string, dynamic> vals = new Dictionary<string, dynamic>();


            pd.ItemsSource = App.productList.Select(x => x.Name).ToList();
            pd.SelectedIndex = 0;

            //vals["type_of_aircon"] = pd.SelectedItem.ToString();

            //vals["units_to_service"] = des.Date;
            //vals["units_to_service"] = oqty.Date;
            //vals["units_to_service"] = up.Text.ToString(); 
            //vals["units_to_service"] = NoOfServiced.Text.ToString();
            //vals["units_to_service"] = stot.Text.ToString();

           // vals["units_serviced"] = Convert.ToInt32(NoOfServiced.Text);

            //bool updated = Controller.InstanceCreation().UpdatecrmOppMeeting("update_pcf_aircon_app", vals);
            //if (updated)
            //{
            //    // Navigation.PushAsync(new PcfNotesPage(workId));
            //}
            //else
            //{
            //    //  Navigation.PushPopupAsync(new CommonAlertWizard("Your request sending failed. Try Again"));
            //}

            var backRecognizer = new TapGestureRecognizer();
            backRecognizer.Tapped += (s, e) => {

                Navigation.PushPopupAsync(new SalesQuotationCreationPage());

            };
            backImg.GestureRecognizers.Add(backRecognizer); 
        }

        private void Button_Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Button_Add_Clicked(object sender, EventArgs e)
        {
            Dictionary<string, dynamic> vals = new Dictionary<string, dynamic>();

            if (pd.SelectedIndex == -1 || des.Text == "0" || oqty.Text == "0")
            {
                // Navigation.PushPopupAsync(new CommonAlertWizard("Value should be greater than 0. Try Again"));
                DisplayAlert("Alert", "Please select atleast one", "Ok");
            }

                else
                {

                vals["product"] = pd.SelectedItem.ToString();

                vals["description"] = des.Text;
                vals["ordered_qty"] = Convert.ToDouble(oqty.Text);

                string updated = Controller.InstanceCreation().UpdateCRMOpporData("sale.crm", "create_sale_quotation", vals);

                if (updated == "true")
                {
                   // App.Current.MainPage = new MasterPage(new CrmTabbedPage());
                }

                else
                {

                }

            }
        }
    }
}
