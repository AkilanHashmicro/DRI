using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using Xamarin.Forms;

namespace SalesApp.Pages
{
    public partial class PasswordChangePopupPage : PopupPage
    {
        Dictionary<string, dynamic> vals = new Dictionary<string, dynamic>();
        public PasswordChangePopupPage()
        {
            InitializeComponent();

        }


        void cancel_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAllPopupAsync();
        }

        async void save_ClickedAsync(object sender, System.EventArgs e)
        {
            if( pass1_entry.Text == pass2_entry.Text)
            {
                var currentpage = new LoadingAlert();
                await PopupNavigation.PushAsync(currentpage);
                vals["password"] = pass1_entry.Text;

                bool updated = Controller.InstanceCreation().UpdatePassword("res.users", "app_change_password", App.userid, pass1_entry.Text);

                Settings.UserPassword = pass1_entry.Text;

                await DisplayAlert("Alert", "Password updated successfully", "Ok");
                await PopupNavigation.PopAllAsync();
            }

            else
            {
                await  DisplayAlert("Alert", "Password doesn't match", "Ok");
                await PopupNavigation.PopAllAsync();
            }
        }

    }
}
