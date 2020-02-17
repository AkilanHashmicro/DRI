using Newtonsoft.Json.Linq;
using SalesApp.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using SalesApp.Pages;
using Rg.Plugins.Popup.Services;


namespace SalesApp.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        bool crmFlag = false;

        IDictionary<string, int> menuClick = new Dictionary<string, int>();

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public MasterPage(Page pageRef)
        {
            try
            {
                InitializeComponent();

                ObservableCollection<MasterPageItem> otherGroups = new ObservableCollection<MasterPageItem>();
                MasterPageItem crmPage = new MasterPageItem { Title = "CRM",  Icon = "crmnavy.png", TargetType = typeof(CrmTabbedPage) };
                MasterPageItem cusPage = new MasterPageItem { Title = "Customer", Icon = "customersnavy.png", TargetType = typeof(CustomersPage) };
                MasterPageItem calendarPage = new MasterPageItem { Title = "Calendar", Icon = "calendarnavy.png", TargetType = typeof(CalendarPage) };
                MasterPageItem activityPage = new MasterPageItem { Title = "Activities", Icon = "activitynavy.png", TargetType = typeof(ActivitiesPage) };
                MasterPageItem LoggedCallPage = new MasterPageItem { Title = "Logged Calls", Icon = "calllog.png", TargetType = typeof(LoggedCallsPage) };
                MasterPageItem stockPage = new MasterPageItem { Title = "Stock Count", Icon = "stocknavy.png", TargetType = typeof(StockCountPage) };
              //  MasterPageItem targetPage = new MasterPageItem { Title = "Sales Commission Target", Icon = "targetnavy.png", TargetType = typeof(SalesTargetPage) };
                MasterPageItem promotionPage = new MasterPageItem { Title = "Active Promotions", Icon = "offer.png", TargetType = typeof(ActivePromotionsPage) };
              //  MasterPageItem salestargetPage = new MasterPageItem { Title = "Sales Target", Icon = "salestarget.png", TargetType = typeof(NewSalesTargetPage) };
                MasterPageItem reportingPage = new MasterPageItem { Title = "Reporting", Icon = "charts.png", TargetType = typeof(WebviewPage) };
                MasterPageItem profilePage = new MasterPageItem { Title = "Profile", Icon = "profilemenu.png", TargetType = typeof(ProfilePage) };
                MasterPageItem signoutPage = new MasterPageItem { Title = "Sign Out", Icon = "exit.png", TargetType = typeof(LogoutPage) };
                otherGroups.Add(crmPage);
                otherGroups.Add(cusPage);
                otherGroups.Add(calendarPage);
                otherGroups.Add(activityPage);
                otherGroups.Add(LoggedCallPage);
                otherGroups.Add(stockPage);
               // otherGroups.Add(targetPage);
                otherGroups.Add(promotionPage);
                otherGroups.Add(reportingPage);
              //  otherGroups.Add(salestargetPage);
                otherGroups.Add(profilePage);
                otherGroups.Add(signoutPage);
                otherDrawerList.ItemsSource = otherGroups;

            }
            catch (Exception ea)
            {
                System.Diagnostics.Debug.WriteLine(ea.Message);
            }

            menuList = new List<MasterPageItem>();
            string tmpImage = App.partner_image;
            this.masterPageName.Text = App.partner_name;
            this.masterPageRole.Text = App.partner_email;

            if (App.NetAvailable == true)
            {

                if (tmpImage.Equals("False"))
                {
                    userImage.Source = "unknownPerson.png";
                }
                else
                {
                    byte[] imageAsBytes = Encoding.UTF8.GetBytes(tmpImage);
                    byte[] decodedByteArray = System.Convert.FromBase64String(Encoding.UTF8.GetString(imageAsBytes, 0, imageAsBytes.Length));
                    var stream = new MemoryStream(decodedByteArray);
                    userImage.Source = ImageSource.FromStream(() => stream);
                }

            }

            else if(App.NetAvailable == false)
            {
                foreach (var obj in App.UserListDb)
                {
                    this.masterPageName.Text = obj.user_name;
                    this.masterPageRole.Text = App.partner_email;

                    if (tmpImage.Equals("False"))
                    {
                        userImage.Source = "unknownPerson.png";
                    }

                    else if(tmpImage == "")
                    {
                        userImage.Source = "unknownPerson.png";
                    }
                    else
                    {
                        byte[] imageAsBytes = Encoding.UTF8.GetBytes(obj.user_image_medium);
                        byte[] decodedByteArray = System.Convert.FromBase64String(Encoding.UTF8.GetString(imageAsBytes, 0, imageAsBytes.Length));
                        var stream = new MemoryStream(decodedByteArray);
                        userImage.Source = ImageSource.FromStream(() => stream);
                    }
                }

            }

            Page page = pageRef;

            //Detail = new NavigationPage((page)) { BarBackgroundColor = Color.FromHex("#414141") };

            Detail = new NavigationPage((page)) { BarBackgroundColor = Color.FromHex("#363E4B") };


          //  { BarBackgroundColor = Color.FromHex("#414141") }

            this.IsPresented = false;

        }

        private async Task OnMenuItemTappedAsync(object sender, ItemTappedEventArgs ea)
        {
          
            try
            {

                MasterPageItem masterItemObj = (MasterPageItem)ea.Item;
                string name = masterItemObj.Title;
                //Settings.CurrentMenu = name;

                //if(masterItemObj.Title == "CRM")
                //{
                //    masterItemObj.Icon = "crmcolor.png";
                //    masterItemObj.Title = "Test Tiele";
                //}

                if (name == "Sign Out")
                {
                    //var alertResult = new LogoutAlert();
                    //await PopupNavigation.PushAsync(alertResult);
                    var data = await DisplayAlert("Logout Alert", "Are you sure you want to log out?", "OK", "Cancel");
                    if (data)
                    {
                        Settings.UserName = "";
                        Settings.UserPassword = "";
                        Settings.PrefKeyUserDetails = "";
                        App.userid = 0;
                        App.Current.MainPage = new NavigationPage(new LoginPage());
                    }
                    else
                    {

                    }
                }

                else
                {
                    Type page = masterItemObj.TargetType;

                  //  masterItemObj.Icon = "crmcolor.png";

                    var currentpage = new LoadingAlert();
                    await PopupNavigation.PushAsync(currentpage);

                    Detail = new NavigationPage((Page)Activator.CreateInstance(page)) { BarBackgroundColor = Color.FromHex("#363E4B") };

                    IsPresented = false;


                    //await Task.Run(() =>
                    //{
                    //    Device.BeginInvokeOnMainThread(() =>
                    //    {
                    //        Detail = new NavigationPage((Page)Activator.CreateInstance(page)) ;  
                    //        //{ BarBackgroundColor = Color.FromHex("#414141") }
                    //        IsPresented = false;

                    //    });
                    //});

                    Loadingalertcall();
                }
            }

            catch(Exception exc)
            {
                if (App.NetAvailable == false)
                {
                    await DisplayAlert("Alert", "Need Internet Connection", "Ok");
                    Loadingalertcall();
                }

            }

        }

       
        async void Loadingalertcall()
        {
            await PopupNavigation.PopAllAsync();
        }



        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            obj.View.BackgroundColor = Color.FromHex("#F0EEEF");
          //  m_title.TextColor = Color.Red;
        }


    }
}
