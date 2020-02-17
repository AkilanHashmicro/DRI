using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace SalesApp.Pages
{
    public partial class CommonAlertWizard : PopupPage
    {
        public CommonAlertWizard(string text)
        {
            InitializeComponent();
            body.Text = text;
        }

        public CommonAlertWizard(string Message, string text1)
        {
            InitializeComponent();
            Title.Text = "Alert";
            body.Text = text1;
        }

        private void yesbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}