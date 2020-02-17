using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;



namespace SalesApp.views
{
    public partial class MeetingsListviewPage : PopupPage
    {
        List<all_events> meetingresult = new List<all_events>();

        public MeetingsListviewPage(int cus_id)
        {
            InitializeComponent();


           // byte[] data = File.ReadAllBytes(filePath);

            meetingresult = Controller.InstanceCreation().GetMeetingsData(cus_id);
            meetingsListView.ItemsSource = meetingresult;

            var backImgRecognizer = new TapGestureRecognizer();
            backImgRecognizer.Tapped += (s, e) => {
                // handle the tap    

                // Navigation.PopAllPopupAsync();
                PopupNavigation.PopAsync();

            };
            backImg.GestureRecognizers.Add(backImgRecognizer);

        }

        private void ViewCellPending_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            obj.View.BackgroundColor = Color.White;
        }

        private void meetingListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            all_events modelObj = e.Item as all_events;
          //  Navigation.PushAsync(new CalendarDetailPage(modelObj));
            Navigation.PushPopupAsync(new CalendarDetailPage(modelObj));
        }

        protected override bool OnBackButtonPressed()
        {
            PopupNavigation.PopAsync();
            return true;
        }

    }
}
