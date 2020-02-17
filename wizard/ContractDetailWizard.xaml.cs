using Plugin.Messaging;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SalesApp.models.CRMModel;
using Plugin.FilePicker.Abstractions;
using Plugin.FilePicker;
using Rg.Plugins.Popup.Services;
using SalesApp.Pages;
using SalesApp.models;

namespace SalesApp.wizard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContractDetailWizard : PopupPage
    {
        ContactsList myobj = null;
        string selectedimg = "";
        List<ContactsList> listview_update = new List<ContactsList>();
        int contact_id = 0;

        int CustParent_Id = 0;

        ImageSource photo = null;
        public ContractDetailWizard(ContactsList obj)
        {
            InitializeComponent();

            myobj = obj;
            contactImage.Source = obj.CustomerImg;
            name.Text = obj.name;
            email.Text = obj.email;
            mobile.Text = obj.mobile;
            phone.Text = obj.phone;
            position.Text = obj.position;

            contact_id = obj.id;
            photo = obj.CustomerImg;

            //if(phone.Text == "")
            //{
            //    phoneimg.IsVisible = false;
            //}
            //if (mobile.Text == "")
            //{
            //    mobileimg.IsVisible = false;
            //}

            var imageRecognizer = new TapGestureRecognizer();
            imageRecognizer.Tapped += async (s, e) =>
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
                        selectedimg = UploadData;
                        var stream = new MemoryStream(bydata);
                        contactImage.Source = ImageSource.FromStream(() => stream);
                    }

                }
                catch (Exception ex)
                {
                    filedata = null;
                    System.Diagnostics.Debug.WriteLine("Warning Exception :  " + ex.Message);
                }

            };
            contactImage.GestureRecognizers.Add(imageRecognizer);

        }

        public ContractDetailWizard(int id)
        {
            InitializeComponent();

            CustParent_Id = id;
            contactImage.Source = "unknown.png";
            photo = contactImage.Source;
            var imageRecognizer = new TapGestureRecognizer();
            imageRecognizer.Tapped += async (s, e) =>
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
                        selectedimg = UploadData;
                        var stream = new MemoryStream(bydata);
                        contactImage.Source = ImageSource.FromStream(() => stream);
                    }

                }
                catch (Exception ex)
                {
                    filedata = null;
                    System.Diagnostics.Debug.WriteLine("Warning Exception :  " + ex.Message);
                }

            };
            contactImage.GestureRecognizers.Add(imageRecognizer);

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (contact_id == 0)
            {
                // Contact Create function

                Dictionary<string, dynamic> vals = new Dictionary<string, dynamic>();

                vals["mobile"] = mobile.Text;
                vals["name"] = name.Text;
                vals["email"] = email.Text;
                vals["phone"] = phone.Text;
                vals["function"] = position.Text;
                vals["parent_id"] = CustParent_Id;

                if (selectedimg != "")
                {
                    vals["image"] = selectedimg;
                }
                else
                {
                    vals["image"] = "";
                }

                var currentpage = new LoadingAlert();
                await PopupNavigation.PushAsync(currentpage);

                var updated = Controller.InstanceCreation().CreateContactlist("res.partner", "create", vals);

                if (updated)
                {
                    ContactsList createCont = new ContactsList();

                    createCont.id = App.createContact_Id;
                    createCont.name = name.Text;
                    createCont.mobile = mobile.Text;
                    createCont.email = email.Text;
                    createCont.phone = phone.Text;
                    createCont.position = position.Text;

                    if (selectedimg != "")
                    {
                        createCont.image_small = selectedimg;
                    }
                    else
                    {
                        createCont.image_small = "";
                    }
                    MessagingCenter.Send<string, ContactsList>("MyApp", "CreateMsg", createCont);

                    await DisplayAlert("Alert", "Contact created successfully", "ok");
                    await PopupNavigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alert", "Please try again", "Ok");
                }

            }
            else
            {
                // Contact Update function

                ContactsList newcont = new ContactsList();

                newcont.id = contact_id;
                newcont.name = name.Text;
                newcont.mobile = mobile.Text;
                newcont.email = email.Text;
                newcont.phone = phone.Text;
                newcont.position = position.Text;


                if (selectedimg != "")
                {
                    newcont.image_small = selectedimg;
                }
                else
                {
                    try
                    {
                        StreamImageSource streamImageSource = (StreamImageSource)photo;
                        System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
                        Task<Stream> task = streamImageSource.Stream(cancellationToken);
                        Stream stream = task.Result;

                        var memoryStream = new MemoryStream();
                        stream.CopyTo(memoryStream);

                        var base64String = Convert.ToBase64String(memoryStream.ToArray());

                        newcont.image_small = base64String;

                    }
                    catch (Exception ex)
                    {

                        newcont.image_small = "";

                    }

                }

                MessagingCenter.Send<string, ContactsList>("MyApp", "ContactMsg", newcont);


                Dictionary<string, dynamic> vals = new Dictionary<string, dynamic>();

                vals["mobile"] = mobile.Text;
                vals["name"] = name.Text;
                vals["email"] = email.Text;

                if (selectedimg != "")
                {
                    vals["image"] = selectedimg;
                }
                else
                {
                    try
                    {
                        StreamImageSource streamImageSource = (StreamImageSource)photo;
                        System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
                        Task<Stream> task = streamImageSource.Stream(cancellationToken);
                        Stream stream = task.Result;

                        var memoryStream = new MemoryStream();
                        stream.CopyTo(memoryStream);

                        var base64String = Convert.ToBase64String(memoryStream.ToArray());

                        vals["image"] = base64String;
                    }
                    catch (Exception ex)
                    {
                        vals["image"] = "";
                    }

                }

                var currentpage = new LoadingAlert();
                await PopupNavigation.PushAsync(currentpage);

                var updated = Controller.InstanceCreation().UpdateContactlist("res.partner", "write", contact_id, vals);

                if (updated)
                {
                    await DisplayAlert("Alert", "Contact updated successfully", "ok");
                    await PopupNavigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alert", "Please try again", "Ok");
                }

            }

            await PopupNavigation.PopAsync();

        }

    }
}



//async void phoneClicked(object sender, EventArgs e1)
//{
//    //var args = (TappedEventArgs)e1;

//    //ContactsList myobj = args.Parameter as ContactsList;
//    var phoneDialer = CrossMessaging.Current.PhoneDialer;
//    if (phoneDialer.CanMakePhoneCall && myobj.phone != "")
//    {
//        phoneDialer.MakePhoneCall(myobj.phone);
//    }
//    else
//    {

//        await Navigation.PushPopupAsync(new PhoneCallWizard());
//    }
//}

//async void mobileClicked(object sender, EventArgs e1)
//{
//    //var args = (TappedEventArgs)e1;
//    //ContactsList myobj = args.Parameter as ContactsList;
//    var phoneDialer = CrossMessaging.Current.PhoneDialer;
//    if (phoneDialer.CanMakePhoneCall && myobj.mobile != "")
//    {
//        phoneDialer.MakePhoneCall(myobj.mobile);
//    }
//    else
//    {

//        await Navigation.PushPopupAsync(new PhoneCallWizard());
//    }
//}