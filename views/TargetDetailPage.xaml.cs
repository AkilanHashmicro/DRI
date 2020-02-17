using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    public partial class TargetDetailPage : PopupPage
    {
        List<target_line> saleresult = new List<target_line>();
        public TargetDetailPage(SalesTarget item)
        {
            InitializeComponent();
            // saleresult = Controller.InstanceCreation().salesTargetData();
            targetListview.ItemsSource = item.target_line;
            name_val.Text = item.name;
            com_val.Text = item.commission_type;

            var backRecognizer = new TapGestureRecognizer();
            backRecognizer.Tapped += (s, e) => {

                PopupNavigation.PopAsync();
                //    Navigation.PopAllPopupAsync();
                //   Navigation.PushAsync(new CalendarPage());
                //  App.Current.MainPage = new MasterPage(new CalendarPage());


            };
            backImg.GestureRecognizers.Add(backRecognizer);
        }


        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            obj.View.BackgroundColor = Color.FromHex("#FFFFFF");
        }



        protected override bool OnBackButtonPressed()
        {

            PopupNavigation.PopAsync();
            return true;
        }
    }
}
