using System;
using System.Collections.Generic;
using SalesApp.models;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    public partial class LoggedCallsPage : ContentPage
    {
        public LoggedCallsPage()
        {
            InitializeComponent();

            List<LoggedCalls> logData = Controller.InstanceCreation().GetlogData();

            logListView.ItemsSource = logData;

            if(logData.Count == 0)
            {
                overstack.IsVisible = false;
            }

        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            obj.View.BackgroundColor = Color.FromHex("#F0EEEF");
            //  m_title.TextColor = Color.Red;
        }
    }
}
