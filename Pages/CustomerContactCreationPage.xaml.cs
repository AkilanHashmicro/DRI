using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.views;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.Pages
{
    public partial class CustomerContactCreationPage : PopupPage
    {
        string selectedImage = "";

        public CustomerContactCreationPage()
        {
            InitializeComponent();

            var closeRecognizer = new TapGestureRecognizer();
            closeRecognizer.Tapped += (s, e) => {
                // handle the tap              

                // Navigation.PushAsync(new KimHuatServicePage(workId));
                //  Navigation.PopAllPopupAsync();
                PopupNavigation.PopAsync();

            };
            closeImg.GestureRecognizers.Add(closeRecognizer);

        }

        private void btnDiscardClicked(object sender, EventArgs ea)
        {
           // Navigation.PopAllPopupAsync();
            PopupNavigation.PopAsync();
        }

        private void btnsaveClicked(object sender, EventArgs ea)
        {
            name_alert.IsVisible = false;

            if (name_text.Text == "")
            {
                name_alert.IsVisible = true;
            }

            else
            {
                App.concreationList.Add(new ContactsCreationList(name_text.Text, mobile_text.Text, mail_text.Text, selectedImage, ""));
                MessagingCenter.Send<string, string>("MyApp", "NotifyMsg", "From BlePairingViewModel");
                // Navigation.PopAllPopupAsync();
                PopupNavigation.PopAsync();
            }

        }
           
        private async void btnaddphotoclicked(object sender, EventArgs ea)
        {
            FileData fileData = new FileData();
            FileData filedata = null;
            try
            {
                filedata = await CrossFilePicker.Current.PickFile();
                if (!string.IsNullOrEmpty(filedata.FileName)) //Just the file name, it doesn't has the path
                {

                    byte[] bydata = filedata.DataArray;
                    String UploadData = Convert.ToBase64String(bydata);
                    selectedImage = UploadData;
                    var stream = new MemoryStream(bydata);
                    imgCreation.Source = ImageSource.FromStream(() => stream);

                }
            }

            catch (Exception ex)
            {
                filedata = null;
                System.Diagnostics.Debug.WriteLine("Warning Exception :  " + ex.Message);
            }
        }

    }
}