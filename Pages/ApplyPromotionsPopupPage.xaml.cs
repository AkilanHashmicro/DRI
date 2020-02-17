using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using SalesApp.views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplyPromotionsPopupPage : PopupPage
    {
        int so_id = 0;

        int type_id = 2;

        public ApplyPromotionsPopupPage(int sale_id)
        {
            InitializeComponent();

            so_id = sale_id;

            var mannualfillimgRecognizer = new TapGestureRecognizer();
            mannualfillimgRecognizer.Tapped += (s, e) => {

                autofillimg.IsVisible = false;
                manualfillimg.IsVisible = true;
                type_id = 1;

            };
            manualempimg.GestureRecognizers.Add(mannualfillimgRecognizer);

            var autofillimgRecognizer = new TapGestureRecognizer();
            autofillimgRecognizer.Tapped += (s, e) => {

                autofillimg.IsVisible = true;
                manualfillimg.IsVisible = false;
                type_id = 2;

            };
            autoempimg.GestureRecognizers.Add(autofillimgRecognizer);

        }

        void cancel_Clicked(object sender, System.EventArgs e)
        {
            PopupNavigation.PopAsync();
        }

        async void save_ClickedAsync(object sender, System.EventArgs e)
        {

            if (type_id == 1)
            {
                await PopupNavigation.PopAsync();
                await Navigation.PushPopupAsync(new ApplyProManPopupPage(so_id));
            }

            else if (type_id == 2)
            {
                try
                {
                    var currentpage = new LoadingAlert();
                    await PopupNavigation.PushAsync(currentpage);

                    bool res = Controller.InstanceCreation().UpdatePromotionsAuto(so_id);

                    if (res == true)
                    {

                        Application.Current.MainPage = new MasterPage(new CrmTabbedPage("tab3"));

                        await DisplayAlert("Alert", "Promotions Applied Successfully", "Ok");

                        await PopupNavigation.PopAllAsync();
                    }

                    else if (res == false)
                    {
                        await DisplayAlert("Alert", "There are multiple promotions applicable, please select manually.", "Ok");
                        await PopupNavigation.PopAsync();
                    }

                    // await PopupNavigation.PopAsync();
                }

                catch (Exception ex)
                {
                    await DisplayAlert("Alert", "Please try again", "Ok");
                    await PopupNavigation.PopAsync();
                }
            }


        }
    }
}
