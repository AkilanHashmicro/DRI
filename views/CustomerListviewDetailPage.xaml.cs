using System.Collections;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using SalesApp.Pages;
using SalesApp.wizard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;
//using Java.Util;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SalesApp.views
{
    public partial class CustomerListviewDetailPage : PopupPage
    {
        CustomersModel cusobj = new CustomersModel();
        string selectedimage = "";
        string image = "";
      //  List<ContactsList> cusnewList = new List<ContactsList>();

        List<ContactsList> final_listview = new List<ContactsList>();

      //  List<CustomersModel> customerdata = new List<CustomersModel>();

        //save previous contactlist
        //ContactsListPrevious data;
        //List<ContactsListPrevious> cusnewListPrev = new List<ContactsListPrevious>();

        int customer_id = 0;

        public CustomerListviewDetailPage(int cus_id)
        {
            InitializeComponent();

            customer_id = cus_id;

            JObject obj = Controller.InstanceCreation().GetCustomerDetailData(customer_id);

           // cusobj = obj;

            List<ContactsList> cusnewList = new List<ContactsList>();

            string cus_name = obj["name"].ToObject<string>();
            string cus_email = obj["email"].ToObject<string>();
            string cus_mobile = obj["mobile"].ToObject<string>();
            string cus_street = obj["street"].ToObject<string>();
            string cus_city = obj["city"].ToObject<string>();
            string cus_zip = obj["zip"].ToObject<string>();
            string cus_website = obj["website"].ToObject<string>();
            int crm_count = obj["crm_count"].ToObject<int>();
            int sales_count = obj["sales_count"].ToObject<int>();
            int meeting_count = obj["meeting_count"].ToObject<int>();
            string image_small = obj["image_small"].ToObject<string>();
            cusnewList = obj["contacts"].ToObject<List<ContactsList>>();

            Dictionary<int, string> tags = obj["tags"].ToObject<Dictionary<int, string>>();

            CusListView.IsEnabled = false;
            cus_image.IsEnabled = false;

            List<string> tagsList = new List<string>();

            List<TagsList> custagsList = new List<TagsList>();

          

            byte[] imageAsBytes = Encoding.UTF8.GetBytes(image_small);

            byte[] decodedByteArray = System.Convert.FromBase64String(Encoding.UTF8.GetString(imageAsBytes, 0, imageAsBytes.Length));
            var stream = new MemoryStream(decodedByteArray);
            cus_image.Source = ImageSource.FromStream(() => stream);

            name.Text = cus_name;
            email.Text = cus_email;
            mobile_No.Text = cus_mobile;
            street.Text = cus_street;
            city.Text = cus_city;
            zip.Text = cus_zip;
            web_text.Text = cus_website;
            oppo_text.Text = crm_count.ToString();
            sales_text.Text = sales_count.ToString();
            meeting_text.Text = meeting_count.ToString();

            image = image_small;

           // cusnewList = obj.contacts;
            CusListView.HeightRequest = 80 * cusnewList.Count;
            CusListView.ItemsSource = cusnewList;

            final_listview = cusnewList;


          //   saving prev contactlist
            //foreach (var res in obj.contacts)
            //{
            //    data = new ContactsListPrevious();
            //    data.email = res.email;
            //    data.id = res.id;
            //    data.image_small = res.image_small;
            //    data.mobile = res.mobile;
            //    data.name = res.name;
            //    data.phone = res.phone;
            //    data.PhoneNo = res.PhoneNo;
            //    data.position = res.position;
            //    cusnewListPrev.Add(data);
            //}

              //CusListView.ItemsSource = cusmodel;
            foreach (var cusname in tags)
            {
                tagsList.Add(cusname.Value);
                custagsList.Add(new TagsList(cusname.Value));
            }

            //tags strted 

            try
            {
                

                var backImgRecognizer = new TapGestureRecognizer();
                backImgRecognizer.Tapped += (s, e) => {
                    // handle the tap    

                    Navigation.PopAllPopupAsync();

                };
                backImg.GestureRecognizers.Add(backImgRecognizer);

            }
            catch (Exception ea)
            { System.Diagnostics.Debug.WriteLine("Warning Message : " + ea.Message); }



            var editbutton = new TapGestureRecognizer();
            editbutton.Tapped += (s, e) => {

                sq_editbtn.IsVisible = false;

                updatebtn.IsVisible = true;

                CusListView.IsEnabled = true;

                cus_image.IsEnabled = true;

                name.IsVisible = false;
                name_entry.Text = name.Text;
                name_label.IsVisible = true;
                name_entry.IsVisible = true;

                email.IsVisible = false;
                email_entry.Text = email.Text;
                email_label.IsVisible = true;
                email_entry.IsVisible = true;

                mobile_No.IsVisible = false;
                mobile_No_entry.Text = mobile_No.Text;
                mobile_No_label.IsVisible = true;
                mobile_No_entry.IsVisible = true;


                street.IsVisible = false;
                street_entry.Text = street.Text;
                street_label.IsVisible = true;
                street_entry.IsVisible = true;

                city.IsVisible = false;
                city_entry.Text = city.Text;
                city_label.IsVisible = true;
                city_entry.IsVisible = true;

                zip.IsVisible = false;
                zip_entry.Text = zip.Text;
                zip_label.IsVisible = true;
                zip_entry.IsVisible = true;

                web_text.IsVisible = false;
                web_text_entry.Text = web_text.Text;
                web_text_entry.IsVisible = true;

                AddContact_line.IsVisible = true;

            };
            sq_editbtn.GestureRecognizers.Add(editbutton);


            var imageRecognizer = new TapGestureRecognizer();
            imageRecognizer.Tapped += async (s, e) => {

                FileData fileData = new FileData();
                FileData filedata = null;
                try
                {
                    filedata = await CrossFilePicker.Current.PickFile();
                    if (!string.IsNullOrEmpty(filedata.FileName)) //Just the file name, it doesn't has the path
                    {
                        byte[] bydata = filedata.DataArray;
                        String UploadData = Convert.ToBase64String(bydata);
                        selectedimage = UploadData;
                        var str = new MemoryStream(bydata);
                        cus_image.Source = ImageSource.FromStream(() => str);
                    }
                }

                catch (Exception ex)
                {
                    filedata = null;
                    System.Diagnostics.Debug.WriteLine("Warning Exception :  " + ex.Message);
                }

            };
            cus_image.GestureRecognizers.Add(imageRecognizer);

            var contRecognizer = new TapGestureRecognizer();
            contRecognizer.Tapped += (s, e) => {

              //  Navigation.PushPopupAsync(new ContractDetailWizard(obj.id));
                Navigation.PushPopupAsync(new ContractDetailWizard(customer_id));
            };
            AddContact_line.GestureRecognizers.Add(contRecognizer);


        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            // obj.View.BackgroundColor = Color.FromHex("#414141");
            obj.View.BackgroundColor = Color.White;
        }

        private void meetingStackClicked(object sender, EventArgs e)
        {
           // Navigation.PushPopupAsync(new MeetingsListviewPage(cusobj.id));
            Navigation.PushPopupAsync(new MeetingsListviewPage(customer_id));
        }

        private void oppoClicked(object sender, EventArgs e)
        {
          //  Navigation.PushPopupAsync(new OppurtunityListviewPage(cusobj.id));
            Navigation.PushPopupAsync(new OppurtunityListviewPage(customer_id));
        }

        private void saleClicked(object sender, EventArgs e)
        {
          //  Navigation.PushPopupAsync(new SaleListviewPage(cusobj.id));
            Navigation.PushPopupAsync(new SaleListviewPage(customer_id));
        }

        private void CusListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ContactsList obj = e.Item as ContactsList;
            Navigation.PushPopupAsync(new ContractDetailWizard(obj));
        }


        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAllPopupAsync();
            return true;
        }

       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ContactsList cont_list = null;

            MessagingCenter.Subscribe<string, ContactsList>("MyApp", "ContactMsg", (sender, arg) =>
            {
                int contact_id = arg.id;

                foreach (var data in cusobj.contacts)
                {
                    if (contact_id == data.id && data.id != 0)
                    {
                        cont_list = new ContactsList();

                        cont_list.name = arg.name;
                        cont_list.id = contact_id;
                        cont_list.mobile = arg.mobile;
                        cont_list.phone = arg.phone;
                        cont_list.position = arg.position;
                        cont_list.email = arg.email;
                        cont_list.image_small = arg.image_small;
 
                    }
                }

                int index = final_listview.FindIndex(m => m.id == contact_id);
                if (index >= 0)
                    final_listview[index] = cont_list;

                CusListView.ItemsSource = null;

                CusListView.HeightRequest = 80 * final_listview.Count;
                CusListView.ItemsSource = final_listview;

            });

            MessagingCenter.Subscribe<string, ContactsList>("MyApp", "CreateMsg", (sender, arg) =>
            {
                final_listview.Add(arg);

                CusListView.ItemsSource = null;
                CusListView.HeightRequest = 80 * final_listview.Count;
                CusListView.ItemsSource = final_listview;
            });
        }

        private async void update_clickedAsync(object sender, EventArgs ea)
        {
            Dictionary<string, dynamic> vals = new Dictionary<string, dynamic>();

           
            vals["name"] = name_entry.Text;
            vals["email"] = email_entry.Text;
            vals["mobile"] = mobile_No_entry.Text;
            vals["street"] = street_entry.Text;
            vals["city"] = city_entry.Text;
            vals["zip"] = zip_entry.Text;
            vals["website"] = web_text_entry.Text;

   
            var currentpage = new LoadingAlert();
            await PopupNavigation.PushAsync(currentpage);

            var updated = Controller.InstanceCreation().UpdateCustomerData("res.partner", "write", cusobj.id, vals);

            if (updated)
            {
                App.Current.MainPage = new MasterPage(new CustomersPage());
            }
            else
            {
                await DisplayAlert("Alert", "Please try again", "Ok");
            }

            Loadingalertcall();

        }

        async void Loadingalertcall()
        {
            await PopupNavigation.PopAllAsync();
        }

        private void updatecancel_clickedAsync(object sender, EventArgs ea)
        {
            sq_editbtn.IsVisible = true;
            updatebtn.IsVisible = false;

            CusListView.IsEnabled = false;

            cus_image.IsEnabled = false;

            // label fields
            name.IsVisible = true;
            email.IsVisible = true;
            mobile_No.IsVisible = true;
            street.IsVisible = true;
            city.IsVisible = true;
            zip.IsVisible = true;
            web_text.IsVisible = true;

            name_label.IsVisible = false;
            email_label.IsVisible = false;
            mobile_No_label.IsVisible = false;
            street_label.IsVisible = false;
            city_label.IsVisible = false;
            zip_label.IsVisible = false;

            // Entry fields
            name_entry.IsVisible = false;
            email_entry.IsVisible = false;
            mobile_No_entry.IsVisible = false;
            street_entry.IsVisible = false;
            city_entry.IsVisible = false;
            zip_entry.IsVisible = false;
            web_text_entry.IsVisible = false;

            byte[] imageAsBytes = Encoding.UTF8.GetBytes(image);
            byte[] decodedByteArray = System.Convert.FromBase64String(Encoding.UTF8.GetString(imageAsBytes, 0, imageAsBytes.Length));
            var stream = new MemoryStream(decodedByteArray);
            cus_image.Source = ImageSource.FromStream(() => stream);

            AddContact_line.IsVisible = false;


        
        }

    }
}