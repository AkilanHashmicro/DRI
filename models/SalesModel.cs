using Plugin.Messaging;
using SalesApp.wizard;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace SalesApp.models
{
    public class SalesModel
    {

        List<SalesModel> crmList = new List<SalesModel>();
        string tempColours = Settings.StageColourCode;
        Dictionary<string, string> stageColours = new Dictionary<string, string>();


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
        public string _state1;
        public string FullState
        {
            get
            {
                _state1 = "  " + State.Substring(0, 1).ToUpper() + State.Substring(1) + "  ";
                return _state1;
            }

            set
            {

            }
        }


        [JsonProperty("partner_id")]
        public object[] PartnerId { get; set; }

        public string _partnerName;
        public string PartnerName
        {
            get
            {

                return PartnerId[1].ToString();
            }

            set
            {

            }
        }

        public string _colorCode;
        public string ColorCode
        {
            get
            {
                stageColours.Add("draft", "#3498db");
                stageColours.Add("sent", "#e67e22");
                stageColours.Add("sale", "#c0392b");
                stageColours.Add("done", "#2ecc71");
                stageColours.Add("cancel", "#d35400");

                tempColours = tempColours.Substring(1, tempColours.Length - 1);

                foreach (String data in tempColours.Split(','))
                {
                    stageColours.Add(data.Split('^')[0], data.Split('^')[1]);
                }

                _colorCode = stageColours[State];

                return _colorCode;
            }
            set
            {

            }
        }

        [JsonProperty("date_order")]
        public string dateOrder;

        public string DateOrder
        {
            get
            {
                DateTime dt = Convert.ToDateTime(dateOrder.ToString());
                dateOrder = dt.ToString("d MMM");
                return dateOrder;
            }

            set
            {
                dateOrder = value;
            }
        }

    

        //private Command<object> tapCommand;

        //private INavigation navigation;

        //public Command<object> TapCommand
        //{
        //    get { return tapCommand; }
        //    set { tapCommand = value; }
        //}

        //public INavigation Navigation
        //{
        //    get { return navigation; }
        //    set { navigation = value; }
        //}

        //public int SalesId { get; set; }
        //public string OrderName { get; set; }
        //public string PartnerName { get; set; }
        //public int PartnerId { get; set; }
        //public string OrderDate { get; set; }
        //public string State { get; set; }        
        //public string StateColour { get; set; }
        //public string Phone { get; set; }

        //public SalesModel(int saleId,string orderName,int partnerId,String partnerName , string orderDate , string state,string stateColour)
        //{
        //    SalesId = saleId;
        //    OrderName = orderName;
        //    PartnerId = partnerId;
        //    PartnerName = partnerName;
        //    OrderDate = orderDate;
        //    State = "  "+state.Substring(0,1).ToUpper()+state.Substring(1)+"  ";
        //    StateColour = stateColour;
        // //   Phone = phone;
        //    tapCommand = new Command<object>(OnTapped);
        //}

        private void OnTapped(object obj)
        {
            
            //SalesModel myobj = obj as SalesModel;
            //var phoneDialer = CrossMessaging.Current.PhoneDialer;
            //if (phoneDialer.CanMakePhoneCall && myobj.Phone != "False")
            //{
            //    phoneDialer.MakePhoneCall(myobj.Phone);
            //}
            //else
            //{
            //    Navigation.PushPopupAsync(new PhoneCallWizard());
            //}
        }
    }
}
