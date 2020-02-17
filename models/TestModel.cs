using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalesApp.models
{
    public class TestModel
    {        
      //  List<SalesModel> crmList = new List<SalesModel>();
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
      
    }


}


