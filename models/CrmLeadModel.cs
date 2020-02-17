using Plugin.Messaging;
using Rg.Plugins.Popup.Extensions;
using SalesApp.wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SalesApp.models
{
    public class CrmLeadModel
    {

        private Command<object> tapCommand;

        private INavigation navigation;

        public Command<object> TapCommand
        {
            get { return tapCommand; }
            set { tapCommand = value; }
        }

        public INavigation Navigation
        {
            get { return navigation; }
            set { navigation = value; }
        }

        public int CrmLeadId { get; set; }
        public string CrmName { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string EmailFrom { get; set; }
        public string Phone { get; set; }
        public string TeamName { get; set; }
        public string NextActivity { get; set; }
        public string DateAction { get; set; }
        public string TitleAction { get; set; }
        public string Priority { get; set; }
        public string ContactCustomerName { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ContactName { get; set; }
        public string ContactMobile { get; set; }
        public string State { get; set; }
        public string StageColour { get; set; }
        public string Probabilty { get; set; }
        public string PlannedRevenue { get; set; }

        public CrmLeadModel(int leadId, string leadName, int partnerId, string mainCustomerName, string emailFrom, string phone, string teamName, string nextActivity, string dateAction, string titleAction, string priority,
            string partnerName, string street, string streer2, string city, string country, string contactName, string contactMobile, string state, string stageColour,string plannedRevenue,string probability)
        {
            CrmLeadId = leadId;
            CrmName = leadName;
            PartnerId = partnerId;
            PartnerName = mainCustomerName;
            EmailFrom = emailFrom;
            Phone = phone;
            TeamName = teamName;
            NextActivity = nextActivity;
            DateAction = dateAction;
            TitleAction = titleAction;
            Priority = priority;
            ContactCustomerName = partnerName;
            Street = street;
            Street2 = Street2;
            City = city;
            Country = country;
            ContactName = contactName;
            ContactMobile = contactMobile;
            State = "  " + state + "  ";
            StageColour = stageColour;
            Probabilty = probability;
            PlannedRevenue = plannedRevenue;
            tapCommand = new Command<object>(OnTapped);
        }

        private void OnTapped(object obj)
        {
            CrmLeadModel myobj = obj as CrmLeadModel;
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall && myobj.Phone!="False")
            {
                phoneDialer.MakePhoneCall(myobj.Phone);
            }
            else
            {
                Navigation.PushPopupAsync(new PhoneCallWizard());
            }
        }

    }
}
