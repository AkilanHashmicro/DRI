using System;
using System.Collections.Generic;
using System.Linq;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using SalesApp.views;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.Pages
{
    public partial class MarkLostPopupPage : PopupPage
    {
        List<ReasonsList> reasonsList = new List<ReasonsList>();

        List<int> reasonsIdList = new List<int>();

        int modelId = 0;
        int reasonId = 0;

        public MarkLostPopupPage(int id)
        {
            InitializeComponent();

            resons_picker.ItemsSource = App.reasondict.Select(x => x.Value).ToList();
            resons_picker.SelectedIndex = 0;

            modelId = id;

           // resons_picker.ItemsSource = App.cusdict.Select(x => x.Value).ToList();
        }

        public void reasonPickerSelectedIndexChanged(object sender, EventArgs e)
        {

            reasonId = App.reasondict.FirstOrDefault(x => x.Value == resons_picker.SelectedItem.ToString()).Key;
           // reasonsIdList.Add(cusid);

         //   reasonsList.Add(new ReasonsList(resons_picker.SelectedItem.ToString()));

            //reasonsIdList = reasonsIdList.GroupBy(i => i).Select(g => g.First()).ToList();
            //reasonsList = reasonsList.GroupBy(i => i.name).Select(g => g.First()).ToList();
              
        }

        void cancel_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAllPopupAsync();
        }


        private async void update_Clicked(object sender, EventArgs e)
        {
            var currentpage = new LoadingAlert();
            await PopupNavigation.PushAsync(currentpage);

            bool updated = Controller.InstanceCreation().UpdateLost(modelId, reasonId);

            if (updated)
            {
                await DisplayAlert("Alert", "Sucessfuly submitted", "Ok");

            //    Navigation.PopAllPopupAsync();

               // App.Current.MainPage = new MasterPage(new CrmTabbedPage());
                Loadingalertcall();
            }

            else
            {
                await DisplayAlert("Alert", "Please try again", "Ok");
                Loadingalertcall();
            }

        }


        async void Loadingalertcall()
        {
            await PopupNavigation.PopAllAsync();
        }

       //private void update_Clicked(object sender, System.EventArgs e)
        //{
        //    var currentpage = new LoadingAlert();
        //    await PopupNavigation.PushAsync(currentpage);

        //    bool updated = Controller.InstanceCreation().UpdateLost(modelId,reasonId);

        //    if (updated)
        //    {
        //        await DisplayAlert("Alert", "State successfully moved", "Ok");

        //        App.Current.MainPage = new MasterPage(new CrmTabbedPage());
        //        Loadingalertcall();
        //    }

        //    else
        //    {
        //        await DisplayAlert("Alert", "Please try again", "Ok");
        //    }

        //  //  Navigation.PopAllPopupAsync();
        //}
    }
}
