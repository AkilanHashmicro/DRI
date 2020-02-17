using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using SalesApp.views;
using Xamarin.Forms;

namespace SalesApp.Pages
{
    public partial class ApplyProManPopupPage : PopupPage
    {
        int so_id = 0;
        int promo_key_id = 0;
        public ApplyProManPopupPage(int sale_id)
        {
            InitializeComponent();

            so_id = sale_id;

            JObject res = Controller.InstanceCreation().GetPromoData(so_id);

            Dictionary<int, string> prodict = res.ToObject<Dictionary<int, string>>();

            var values = prodict.Values.ToList();

            promo_key_id = prodict.FirstOrDefault(x => x.Value == values[0]).Key;

            manpicker.ItemsSource = values;

            manpicker.SelectedIndex = 0;

            if (values.Count() == 0)
            {
                manpicker.Title = "No Discounts";

            }

        }

        void cancel_Clicked(object sender, System.EventArgs e)
        {
            PopupNavigation.PopAsync();
        }

        async void apply_clickedAsync(object sender, System.EventArgs e)
        {

            var currentpage = new LoadingAlert();
            await PopupNavigation.PushAsync(currentpage);

            bool res = Controller.InstanceCreation().UpdatePromotions(so_id, promo_key_id);

            if (res == true)
            {

                Application.Current.MainPage = new MasterPage(new CrmTabbedPage("tab3"));

                await DisplayAlert("Alert", "Promotions Applied Successfully", "Ok");
                await PopupNavigation.PopAllAsync();
            }

            else
            {
                await DisplayAlert("Alert", "Try Again", "Ok");
                await PopupNavigation.PopAllAsync();

            }

            // PopupNavigation.PopAsync();
            // Navigation.PushPopupAsync(new ApplyProManPopupPage());
        }

        //void save_ClickedAsync(object sender, System.EventArgs e)
        //{

        //    // PopupNavigation.PopAsync();
        //    // Navigation.PushPopupAsync(new ApplyProManPopupPage());
        //}
    }
}
