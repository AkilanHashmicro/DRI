using System;
using System.Collections.Generic;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SalesApp.models.CRMModel;

namespace SalesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttachmentPopupPage : PopupPage
    {

        int so_id = 0;

        List<Attachments> attachres = new List<Attachments>();

        IDownloader downloader = DependencyService.Get<IDownloader>();

        public AttachmentPopupPage(List<Attachments> res, int id)
        {
            InitializeComponent();

          //  downloader.OnFileDownloaded += OnFileDownloaded;



            attachres = res;

            so_id = id;
            // attachListView.ItemsSource = App.nextActivityList;

            //next_activity nxt = new next_activity();
            //nxt.name = "akil.pdf";

            //App.nextActivityList.Add(nxt);

          //  attachres = Controller.InstanceCreation().getfileAtachment(so_id, "crm.lead");

            attachListView.ItemsSource = attachres;

            listviewlayout.HeightRequest = attachres.Count * 45;

            mainlayout.HeightRequest = listviewlayout.HeightRequest + 35;

            if (attachres.Count == 0)
            {
                listviewlayout.IsVisible = false;
                mainlayout.WidthRequest = 100;
                mainlayout.HeightRequest = 25;
            }

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                    // handle the tap
                    FileData fileData = new FileData();
                FileData filedata = null;
                try
                {
                    filedata = await CrossFilePicker.Current.PickFile();

                    if (filedata.FileName.Contains(".pdf") || filedata.FileName.Contains(".doc") ||
                        filedata.FileName.Contains(".docx") || filedata.FileName.Contains(".txt") || filedata.FileName.Contains(".jpeg") || filedata.FileName.Contains(".xls") ||
                         filedata.FileName.Contains(".jpg") || filedata.FileName.Contains(".wav") || filedata.FileName.Contains(".mp3") || filedata.FileName.Contains(".png")
                        || filedata.FileName.Contains(".mp4") || filedata.FileName.Contains(".3gp") || filedata.FileName.Contains(".avi") || filedata.FileName.Contains(".xlsx"))
                    {
                        if (!string.IsNullOrEmpty(filedata.FileName)) //Just the file name, it doesn't has the path
                            {
                            byte[] bydata = filedata.DataArray;
                                //  String UploadData = Convert.ToBase64String(bydata);
                                string file_uploadstring = Convert.ToBase64String(bydata);
                            string file_uploadname = filedata.FileName;

                            Dictionary<string, dynamic> vals = new Dictionary<string, dynamic>();

                            var currentpage = new LoadingAlert();
                            await PopupNavigation.PushAsync(currentpage);


                            vals["res_model"] = "crm.lead";
                            vals["res_id"] = so_id;
                            vals["name"] = file_uploadname;
                            vals["datas"] = file_uploadstring;
                            vals["datas_fname"] = file_uploadname;
                            vals["public"] = true;

                            var res1 = Controller.InstanceCreation().UpdateLeadCreationData("ir.attachment", "create", vals);

                            await DisplayAlert("Alert", "Record updated successfully", "Ok");

                            attachres = Controller.InstanceCreation().getfileAtachment(so_id,"crm.lead");

                            attachListView.ItemsSource = attachres;

                            listviewlayout.HeightRequest = attachres.Count * 45;

                            mainlayout.HeightRequest = listviewlayout.HeightRequest + 35;

                            if (attachres.Count == 0)
                            {
                                listviewlayout.IsVisible = false;
                                mainlayout.WidthRequest = 100;
                                mainlayout.HeightRequest = 20;
                            }

                            MessagingCenter.Send<string, List<Attachments>>("MyApp", "attachUpdated", attachres);

                                // MessagingCenter.Send<List<Attachments>,>("attachUpdated", attachres);

                                await PopupNavigation.PopAsync();

                            await PopupNavigation.PopAsync();

                                //  topimg = UploadData;
                                // var stream = new MemoryStream(bydata);
                                // user_img.Source = ImageSource.FromStream(() => stream);
                            }

                    }

                    else
                    {
                        await DisplayAlert("Alert", "Please upload valid file name", "Ok");
                        await PopupNavigation.PopAsync();
                    }
                }
                catch (Exception ex)
                {
                    filedata = null;
                    System.Diagnostics.Debug.WriteLine("Warning Exception :  " + ex.Message);
                }

            };
            add_attach.GestureRecognizers.Add(tapGestureRecognizer);

        }


        private void attachListviewTaped(object sender, ItemTappedEventArgs ea)
        {

            Attachments t2 = ea.Item as Attachments;

            byte[] bytes = Convert.FromBase64String(t2.file);

            string download_string = "http://laborindo.equip-sapphire.com/web/content/" + t2.id + "?download=true";

            Device.OpenUri(new Uri(download_string));

            PopupNavigation.PopAsync();


        }


        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
                DisplayAlert("XF Downloader", "File Saved Successfully", "Close");
            }
            else
            {
                DisplayAlert("XF Downloader", "Error while saving the file", "Close");
            }
        }


        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            obj.View.BackgroundColor = Color.White;
        }


        async void filedeleteClickedAsync(object sender, EventArgs e1)
        {

            //Attachments t2 = args.Parameter as Attachments;

            //var currentpage = new LoadingAlert();
            //await PopupNavigation.PushAsync(currentpage);

            //string res = Controller.InstanceCreation().SaleOrderConfirm("sale.order", "remove_attachment", t2.id);

            //if (res == "true")
            //{
            //    attachListView.ItemsSource = null;

            //    attachres = Controller.InstanceCreation().getfileAtachment(so_id);

            //    attachListView.ItemsSource = attachres;

            //    listviewlayout.HeightRequest = attachres.Count * 45;

            //    mainlayout.HeightRequest = listviewlayout.HeightRequest + 35;

            //    if (attachres.Count == 0)
            //    {
            //        listviewlayout.IsVisible = false;
            //        mainlayout.WidthRequest = 100;
            //        mainlayout.HeightRequest = 20;
            //    }

            //    MessagingCenter.Send<string, List<Attachments>>("MyApp", "attachUpdated", attachres);

            //    await PopupNavigation.PopAsync();

            //}

            //else
            //{
            //    await DisplayAlert("Alert", "Please Try Again", "Cancel");
            //    await PopupNavigation.PopAsync();
            //}

            //await PopupNavigation.PopAsync();
        }


    }

}