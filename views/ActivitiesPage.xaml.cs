using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Rg.Plugins.Popup.Extensions;
using SalesApp.models;
using SalesApp.Pages;
using SalesApp.wizard;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SalesApp.models.CRMModel;

//24/01/2019 00:00:00

namespace SalesApp.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActivitiesPage : ContentPage
	{

        List<CRMOpportunities> crmListViewList = new List<CRMOpportunities>();

      //  List<CRMLead> crmLeadAll;

        public ActivitiesPage()
        {
            Title = "Activities";
            BackgroundColor = Color.White;
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                //Fixes an android bug where the search bar would be hidden
                searchBar.HeightRequest = 40.0;
            }

            crmLeadListView.ItemsSource = App.crmList;
            crmLeadListView.Refreshing += this.RefreshRequested;

            var plusRecognizer = new TapGestureRecognizer();
            plusRecognizer.Tapped += (s, e) => {
                // Navigation.PushPopupAsync(new OppurtunityDetailPage());
                Navigation.PushPopupAsync(new CRMOpportunityCreationPage1());

                App.cpstring = "activity";

            };
            plus.GestureRecognizers.Add(plusRecognizer);

            DateTime dateTime = DateTime.Now;

           // List<CRMLead> crmLeadData = Controller.InstanceCreation().crmLeadData();

            List<CRMOpportunities> nextactData = Controller.InstanceCreation().nextActivity();

            //try
            //{
            //    dateTime = DateTime.ParseExact(dateTime.ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //}

            //catch
            //{
            //    try
            //    {
            //        dateTime = DateTime.ParseExact(dateTime.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //    }

            //    catch
            //    {
            //        try
            //        {
            //            dateTime = DateTime.ParseExact(dateTime.ToString(), "dd-MM-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //        }

            //        catch
            //        {
            //            try
            //            {
            //                dateTime = DateTime.ParseExact(dateTime.ToString(), "dd-MM-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //            }
            //            catch
            //            {

            //                try
            //                {
            //                    dateTime = DateTime.ParseExact(dateTime.ToString(), "dd-MM-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //                }
            //                catch
            //                {
            //                    try
            //                    {
            //                        dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            //                    }
            //                    catch
            //                    {

            //                        try
            //                        {
            //                            dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            //                        }

            //                        catch
            //                        {
            //                            try
            //                            {
            //                                dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //                            }
            //                            catch
            //                            {
            //                                try
            //                                {
            //                                    dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //                                }
            //                                catch
            //                                {
            //                                    try
            //                                    {
            //                                        dateTime = DateTime.ParseExact(dateTime.ToString(), "MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //                                    }

            //                                    catch
            //                                    {

            //                                        dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}


            //string convertdate = dateTime.ToString("yyyy-MM-dd");
            //DateTime startDate = DateTime.ParseExact(convertdate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);



           // crmListViewList = App.crmList.Where(p => p.conDate >= startDate).ToList();
         //   crmListViewList = App.crmOpprList.Where(p => p.pipe_datetime >= startDate).ToList();

            crmLeadListView.ItemsSource = nextactData;

            crmLeadListView.Refreshing += this.RefreshRequested;

        }

        private async void RefreshRequested(object sender, object e)
        {
            await Task.Delay(2000);
            List<CRMOpportunities> nextactData = Controller.InstanceCreation().nextActivity();

         //   DateTime dateTime = DateTime.Now;

          //  DateTime startdateTime = DateTime.ParseExact(dateTime.ToString(), "M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);


            //try
            //{
            //    dateTime = DateTime.ParseExact(dateTime.ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //}

            //catch
            //{
            //    try
            //    {
            //        dateTime = DateTime.ParseExact(dateTime.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //    }

            //    catch
            //    {
            //        try
            //        {
            //            dateTime = DateTime.ParseExact(dateTime.ToString(), "dd-MM-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //        }

            //        catch
            //        {
            //            try
            //            {
            //                dateTime = DateTime.ParseExact(dateTime.ToString(), "dd-MM-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //            }
            //            catch
            //            {

            //                try
            //                {
            //                    dateTime = DateTime.ParseExact(dateTime.ToString(), "dd-MM-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //                }
            //                catch
            //                {
            //                    try
            //                    {
            //                        dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            //                    }
            //                    catch
            //                    {

            //                        try
            //                        {
            //                            dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            //                        }

            //                        catch
            //                        {
            //                            try
            //                            {
            //                                dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //                            }
            //                            catch
            //                            {
            //                                try
            //                                {
            //                                    dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //                                }
            //                                catch
            //                                {
            //                                    try
            //                                    {
            //                                        dateTime = DateTime.ParseExact(dateTime.ToString(), "MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //                                    }

            //                                    catch
            //                                    {

            //                                        dateTime = DateTime.ParseExact(dateTime.ToString(), "dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}


            //string convertdate = dateTime.ToString("yyyy-MM-dd");

            //DateTime startDate = DateTime.ParseExact(convertdate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            //crmListViewList = App.crmOpprList.Where(p => p.pipe_datetime >= startDate).ToList();


            crmLeadListView.ItemsSource = nextactData;
            crmLeadListView.EndRefresh();
        }

        private void Toolbar_Search_Activated(object sender, EventArgs e)
        {
            if (searchBar.IsVisible)
            {
                searchBar.IsVisible = false;
            }
            else { searchBar.IsVisible = true; }
        }

        //private void Toolbar_Filter_Activated(object sender, EventArgs e)
        //{
        //   // Navigation.PushPopupAsync(new FilterPopupPage());

        //    var CrmFilterWizard = new CrmFilterWizard();
        //    Navigation.PushPopupAsync(CrmFilterWizard);
                     
        //    //Navigation.PushPopupAsync(new CrmFilterWizard());
        //    System.Diagnostics.Debug.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::;");

        //}

        async void phoneClicked(object sender, EventArgs e1)
        {
            // taxes myobj = sender as taxes;
            var args = (TappedEventArgs)e1;

            CRMOpportunities myobj = args.Parameter as CRMOpportunities;
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall && myobj.phone != "")
            {
                phoneDialer.MakePhoneCall(myobj.phone);
            }
            else
            {
                await Navigation.PushPopupAsync(new PhoneCallWizard());
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                crmLeadListView.ItemsSource = App.crmList;
            }

            else
            {
               // crmLeadListView.ItemsSource = App.crmList.Where(x => x.name.ToLower().Contains(e.NewTextValue.ToLower()));
                crmLeadListView.ItemsSource = App.crmList.Where(x => x.customer.ToLower().Contains(e.NewTextValue.ToLower()) || x.name.ToLower().Contains(e.NewTextValue.ToLower()));
            }    

        }

        private void crmLeadListView_ItemTapped(object sender, ItemTappedEventArgs ea)
        {
           // CRMLead masterItemObj = (CRMLead)ea.Item;
            CRMOpportunities masterItemObj = (CRMOpportunities)ea.Item;

            Navigation.PushPopupAsync(new CrmOppDetailWizard(masterItemObj));

          //  Navigation.PushPopupAsync(new CrmLeadDetailWizard(masterItemObj,"Activities"));

           // Navigation.PushPopupAsync(new CrmOppDetailWizard(masterItemObj, "Activities"));
            //  Navigation.PushPopupAsync(new DeleteDuplicatePopupPage());
        }
    }
}