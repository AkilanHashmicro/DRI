using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using FFImageLoading.Forms;
using Newtonsoft.Json;
using Plugin.Messaging;
using Rg.Plugins.Popup.Extensions;
using SalesApp.wizard;
using SQLite;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.models
{
    public class CRMModel
    {
        // List<SalesModel> crmList = new List<SalesModel>();
        public class CRMLead
        {
            string tempColours = Settings.StageColourCode;
            Dictionary<string, string> stageColours = new Dictionary<string, string>();

            public int id { get; set; }
            public string customer { get; set; }
            public string next_activity { get; set; }
            public string name { get; set; }
            public int probability { get; set; }
            public string phone { get; set; }
            //public object[] tags { get; set; }
            public string title_action { get; set; }
            public string expected_revenue { get; set; }
            public string expected_closing { get; set; }
            public string team_name { get; set; }
            public int priority { get; set; }
            public string state { get; set; }
            public string street { get; set; }
            public string street2 { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string contact_name { get; set; }
            public string pipe_date { get; set; }

            public string mobile { get; set; }
            public string email { get; set; }

            public string sales_person { get; set; }

            public string pipe_date1 { get; set; }

            public DateTime conDate1 { get; set; }

            public DateTime conDate
            {
                get
                {
                    try
                    {
                        conDate1 = DateTime.ParseExact(pipe_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                        //  pipe_date1 = dt.ToString("d MMM");
                        return conDate1;
                    }
                    catch
                    {
                        return conDate1;
                    }
                }

                set
                {
                    // pipe_date = value;
                }
            }



            public string DateOrder
            {
                get
                {
                    try
                    {
                        DateTime dt = DateTime.ParseExact(pipe_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                        pipe_date1 = dt.ToString("d MMM");
                        return pipe_date1;
                    }
                    catch
                    {
                        return pipe_date1;
                    }
                }

                set
                {
                    // pipe_date = value;
                }
            }





            public string _state1;
            public string FullState
            {
                get
                {
                    _state1 = "  " + state.Substring(0, 1).ToUpper() + state.Substring(1) + "  ";
                    return _state1;
                }

                set
                {

                }
            }

            public string state_colour { get; set; }
            //    tapCommand = new Command<object>(OnTapped);
        }


        public class CRMOpportunities
        {
            public int id { get; set; }
            public string customer { get; set; }
            public string next_activity { get; set; }
            public string name { get; set; }
            public int probability { get; set; }
            public string phone { get; set; }
            //public object[] tags { get; set; }
            public string title_action { get; set; }
            public string expected_revenue { get; set; }
            public string expected_closing { get; set; }
            public string team_name { get; set; }
           // public int priority { get; set; }

            public string priority { get; set; }

            public string state { get; set; }
            public string street { get; set; }
            public string street2 { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string contact_name { get; set; }
            public string mobile { get; set; }
            public string email { get; set; }
            public string sales_person { get; set; }

            public string stage { get; set; }

            public string _state1;
            public string FullState
            {
                get
                {
                    _state1 = "  " + state.Substring(0, 1).ToUpper() + state.Substring(1) + "  ";
                    return _state1;
                }

                set
                {

                }
            }

            public string state_colour { get; set; }

            public string pipe_date { get; set; }



            public DateTime pipe_datetime1 { get; set; }

            public DateTime pipe_datetime
            {

                get
                {
                    try
                    {
                        pipe_datetime1 = DateTime.ParseExact(pipe_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                        pipe_datetime1 = pipe_datetime1.Date;
                        // pipe_date = dt.ToString("d MMM");
                        //  return pipe_date;
                        return pipe_datetime1;
                    }
                    catch
                    {

                        // pipe_datetime1 = DateTime.ParseExact(pipe_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                        DateTime pipe_datetime1 = DateTime.Now;

                        string today_statestring = pipe_datetime1.ToString("yyy-MM-dd");

                        pipe_datetime1 = DateTime.ParseExact(today_statestring, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);


                        return pipe_datetime1;
                    }
                }

                set
                {
                    // pipe_date = value;
                }
            }

            public string newpipe_date { get; set; }

            public string DateOrder
            {
                get
                {
                    try
                    {
                        DateTime dt = DateTime.ParseExact(pipe_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                        newpipe_date = dt.ToString("d MMM");
                        //  return pipe_date;
                        return newpipe_date;
                    }
                    catch
                    {

                        return newpipe_date;
                    }
                }

                set
                {
                    pipe_date = value;
                }
            }





        }

        //  [Table("SalesQuotation")]
        public class SalesQuotation
        {
            public int id { get; set; }
            public string customer { get; set; }
            public string next_activity { get; set; }
            public string name { get; set; }
            public int probability { get; set; }
            public string phone { get; set; }
            //public object[] tags { get; set; }
            public string title_action { get; set; }
            public string expected_revenue { get; set; }
            // public bool expected_closing { get; set; }
            public string payment_term { get; set; }
            public string commission_group { get; set; }

            public string team_name { get; set; }

            public int priority { get; set; }
            public string state { get; set; }
            public string street { get; set; }
            public string street2 { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string contact_name { get; set; }
            public string mobile { get; set; }
            public string email { get; set; }
            public string state_colour { get; set; }
            public string sales_person { get; set; }
            public string sales_team { get; set; }
            public string customer_reference { get; set; }
            public string fiscal_position { get; set; }

            public string _state1;
            public string FullState
            {
                get
                {
                    _state1 = "  " + state.Substring(0, 1).ToUpper() + state.Substring(1) + "  ";
                    return _state1;
                }

                set
                {

                }
            }


            public string _colorCode;
            //public string ColorCode
            //{
            //    get
            //    {
            //        string tempColours = Settings.StageColourCode;
            //        Dictionary<string, string> stageColours = new Dictionary<string, string>();

            //        stageColours.Add("draft", "#3498db");
            //        stageColours.Add("sent", "#e67e22");
            //        stageColours.Add("sale", "#c0392b");
            //        stageColours.Add("done", "#2ecc71");
            //        stageColours.Add("cancel", "#d35400");

            //        tempColours = tempColours.Substring(1, tempColours.Length - 1);

            //        foreach (String data in tempColours.Split(','))
            //        {
            //            stageColours.Add(data.Split('^')[0], data.Split('^')[1]);
            //        }
            //        _colorCode = stageColours[state];

            //        return _colorCode;
            //    }
            //    set
            //    {

            //    }
            //}


            public string sale_update_date
            {

                get
                {
                    // DateTime dt = Convert.ToDateTime(dateOrder.ToString());
                    // DateTime dt = DateTime.ParseExact(dateOrder, "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture);
                    //  dateOrder = dt.ToString("d MMM");
                    return dateOrder;
                }

                set
                {
                    dateOrder = value;
                }

            }


            [JsonProperty("date_order")]
            public string dateOrder { get; set; }




            public string DateOrder
            {
                get
                {
                    DateTime dt = Convert.ToDateTime(dateOrder.ToString());
                    // DateTime dt = DateTime.ParseExact(dateOrder, "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture);
                    string dateOrder_old = dt.ToString("d MMM");
                    return dateOrder_old;
                }

                set
                {
                    dateOrder = value;
                }
            }
            public string validity_date { get; set; }
            public List<OrderLine> order_line { get; set; }


            public string amount_untaxed { get; set; }
            public string amount_tax { get; set; }
            public string amount_total { get; set; }
        }


        public class SalesOrder
        {
            // [PrimaryKey,AutoIncrement] 

            public int id { get; set; }
            public string customer { get; set; }
            public string next_activity { get; set; }
            public string name { get; set; }
            public int probability { get; set; }
            public string phone { get; set; }
            //public object[] tags { get; set; }
            public string title_action { get; set; }
            public string expected_revenue { get; set; }
            // public bool expected_closing { get; set; }
            public string payment_term { get; set; }

            public string team_name { get; set; }
            public int priority { get; set; }
            public string state { get; set; }
            public string street { get; set; }
            public string street2 { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string contact_name { get; set; }
            public string mobile { get; set; }
            public string email { get; set; }
            public string state_colour { get; set; }
            public string sales_person { get; set; }
            public string sales_team { get; set; }
            public string customer_reference { get; set; }
            public string fiscal_position { get; set; }
            // public string sales_team { get; set; }

            public string amount_untaxed { get; set; }
            public string amount_tax { get; set; }
            public string amount_total { get; set; }

            public string _state1;
            public string FullState
            {
                get
                {
                    _state1 = "  " + state.Substring(0, 1).ToUpper() + state.Substring(1) + "  ";
                    return _state1;
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
                    string tempColours = Settings.StageColourCode;
                    Dictionary<string, string> stageColours = new Dictionary<string, string>();

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
                    _colorCode = stageColours[state];

                    return _colorCode;
                }
                set
                {

                }
            }

            [JsonProperty("date_order")]
            public string dateOrder { get; set; }

            public string DateOrder
            {
                get
                {
                    DateTime dt = Convert.ToDateTime(dateOrder.ToString());
                    // DateTime dt = DateTime.ParseExact(dateOrder, "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture);
                    dateOrder = dt.ToString("d MMM");
                    return dateOrder;
                }

                set
                {
                    dateOrder = value;
                }
            }

            public List<OrderLine> order_line { get; set; }

            //   var rootObj = JsonConvert.DeserializeObject<sa>(myjson);

        }

        public class OrderLine
        {
            // [JsonProperty("customer_lead")]

            public int id { get; set; }

            public int product_id { get; set; }

            public string customer_lead { get; set; }
                
            // [JsonProperty("price_unit")]
            public string price_unit { get; set; }

            // [JsonProperty("product_uom_qty")]
            public string product_uom_qty { get; set; }

            // [JsonProperty("price_subtotal")]
            public string price_subtotal { get; set; }

            // [JsonProperty("taxes")]
            public object[] taxes { get; set; }

            //[JsonProperty("product_name")]
            public string product_name { get; set; }

            public string tax_names { get; set; }


            public Object[] tax_id { get; set; }

            public Object[] taxes_id { get; set; }
                 

            public string discount { get; set; }

            public string multi_discount { get; set; }

            public List<int> taxesid { get; set; }

            // public string description { get; set; }

            public bool is_promotion { get; set; }

            public string product_brand_name { get; set; }
            public string categ_name { get; set; }
            public string default_code { get; set; }

            public int product_brand_id { get; set; }
            public int categ_id { get; set; }
        }

        public class Customers
        {
            // [JsonProperty("customer_lead")]
            public int id { get; set; }

            // [JsonProperty("price_unit")]
            public string name { get; set; }
        }

        [Table("stages")]
        public class stages
        {
            // [PrimaryKey,AutoIncrement] 
            // [JsonProperty("customer_lead")]
            public int id { get; set; }

            // [JsonProperty("price_unit")]
            public string name { get; set; }
        }

        public class next_activity
        {
            // [JsonProperty("customer_lead")]
            public int id { get; set; }

            // [JsonProperty("price_unit")]
            public string name { get; set; }
        }

        public class paytermList
        {
            // [JsonProperty("customer_lead")]
            public int id { get; set; }

            // [JsonProperty("price_unit")]
            public string name { get; set; }
        }

        public class commisiongroupList
        {
            // [JsonProperty("customer_lead")]
            public int id { get; set; }

            // [JsonProperty("price_unit")]
            public string name { get; set; }
        }

        public class AttendeesList
        {
            public int Id { get; set; }
            public string name { get; set; }


            public AttendeesList(string aName)
            {
                // Id = id;
                name = aName;
            }

            public AttendeesList(int id, string aName)
            {
                Id = id;
                name = aName;
            }
        }

        public class ReasonsList
        {
            public int Id { get; set; }
            public string name { get; set; }

            public ReasonsList(string aName)
            {
                // Id = id;
                name = aName;
            }

            public ReasonsList(int id)
            {
                Id = id;
                // name = aName;
            }
        }

        //  [Table("Productslist")]
        public class ProductsList
        {
            // [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
            public string list_price { get; set; }

            public string default_code { get; set; }

            public string product_brand_name { get; set; }

            public string product_categ_name { get; set; }

            public int product_categ_id { get; set; }  
            public int product_brand_id { get; set; }

            public ProductsList(string name)
            {
                // Id = id;
                Name = name;
            }
        }

        public class LocationsList
        {

            public int id { get; set; }
            public string name { get; set; }

        }

        public class taxes
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public taxes(string name)
            {
                // Id = id;
                Name = name;
                // tapCommand = new Command<object>(OnTapped);
            }

            private void OnTapped(object obj)
            {
                taxes myobj = obj as taxes;

                var itemToRemove = App.taxListRemove.Single(r => r.Name == myobj.Name);

                App.taxListRemove.Remove(itemToRemove);
            }
        }



        public class OrderLinesListForUpdate
        {
            public int id { get; set; }
            public int product_id { get; set; }
            public string product { get; set; }
            public string ordered_qty { get; set; }
            public string unit_price { get; set; }
            public string tax_namecut { get; set; }
            public string tax_names { get; set; }

            public string discount { get; set; }

            public string multi_discount { get; set; }
            //  public string description { get; set; }
            // public string Taxes { get; set; }
            public object[] tax_id { get; set; }

            public string brand_name { get; set; }
            public string category_name { get; set; }
            public int product_brand_id { get; set; }
            public int categ_id { get; set; }
            public string default_code { get; set; }

        }

        public class OrderLinesList
        {
            public string product { get; set; }
            public double ordered_qty { get; set; }
            public double unit_price { get; set; }
            public string description { get; set; }

            public string taxstring { get; set; }
            public string discount { get; set; }

            public string multi_discount { get; set; }

            public string default_code { get; set; }
            public string brand_name { get; set; }
            public string category_name { get; set; }
            public int product_brand_id { get; set; }
            public int categ_id { get; set; }


            //var brand_id = App.brandList.FirstOrDefault(x => x.name == brand_picker.SelectedItem.ToString()).id;
            //vals["product_brand_id"] = brand_id;

            //var category_id = App.categoriesList.FirstOrDefault(x => x.display_name == category_picker.SelectedItem.ToString()).id;
            //vals["categ_id"] = category_id;

            //vals["default_code"] = pro_id.Text;

            // public string Taxes { get; set; }

            public List<int> tax_id { get; set; }

            public OrderLinesList(string Product, double Ordered_Qty, double UnitPrice, List<int> TaxesIdList, string order_description, string tax_string, string fin_discount, string multidiscount,string Default_code,string Brand_name,string Category_name, int Product_brand_id, int Categ_id)
            {
                product = Product;
                ordered_qty = Ordered_Qty;
                unit_price = UnitPrice;
                tax_id = TaxesIdList;
                description = order_description;
                taxstring = tax_string;
                discount = fin_discount;
                multi_discount = multidiscount;
                default_code = Default_code;
                brand_name = Brand_name;
                category_name = Category_name;
                product_brand_id = Product_brand_id;
                categ_id = Categ_id;

            }


            //public OrderLinesList(string Product, double Ordered_Qty, double UnitPrice,  string order_description)
            //{
            //    product = Product;
            //    ordered_qty = Ordered_Qty;
            //    unit_price = UnitPrice;
            //   // tax_id = TaxesIdList;
            //    description = order_description;
            //}

        }


        public class OrderLinesListDB
        {
            //public string product { get; set; }
            //public string ordered_qty { get; set; }
            //public string unit_price { get; set; }
            //public string description { get; set; }
            // public string Taxes { get; set; }


            public string customer_lead { get; set; }

            // [JsonProperty("price_unit")]
            public string price_unit { get; set; }

            // [JsonProperty("product_uom_qty")]
            public string product_uom_qty { get; set; }

            // [JsonProperty("price_subtotal")]
            public string price_subtotal { get; set; }

            // [JsonProperty("taxes")]
            public object[] taxes { get; set; }

            //[JsonProperty("product_name")]
            public string product_name { get; set; }

            //   public List<int> tax_id { get; set; }


            public OrderLinesListDB(string Product, string Ordered_Qty, string UnitPrice)
            {
                product_name = Product;
                product_uom_qty = Ordered_Qty;
                price_subtotal = UnitPrice;
                // tax_id = TaxesIdList;
                // description = order_description;
            }

        }

        public class MeetingLinesList
        {
            public string subject { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public string location { get; set; }
            public double duration { get; set; }
            public List<int> attendees { get; set; }

            public MeetingLinesList(string Subject, string Start_date, string End_date, string Location, double Duration, List<int> AttendeesList)
            {
                subject = Subject;
                start_date = Start_date;
                end_date = End_date;
                location = Location;
                duration = Duration;
                attendees = AttendeesList;
            }
        }

        public class all_events
        {
            public string meeting_subject { get; set; }

            public bool sign_in { get; set; }

            public bool sign_out { get; set; }

            public float sign_in_lat { get; set; }
            public float sign_in_long { get; set; }

            public float sign_out_lat { get; set; }
            public float sign_out_long { get; set; }

            public string id { get; set; }
         //   public int id { get; set; }
            // [JsonProperty("price_unit")]
            public List<EventsAtts> attendees { get; set; }

            // [JsonProperty("product_uom_qty")]
            public List<TagsList> tags { get; set; }

            // [JsonProperty("price_subtotal")]
            public string starting_at { get; set; }

            public string start { get; set; }

            public string sign_in_time { get; set; }

            public string sign_out_time { get; set; }


            // [JsonProperty("taxes")]

            public DateTime showStart
            {
                get
                {
                    DateTime data = Convert.ToDateTime(this.starting_at).ToLocalTime();
                    return data;
                }

                set { }
            }

            public DateTime showStop
            {
                get
                {
                    DateTime data = Convert.ToDateTime(this.stop).ToLocalTime();

                    return data;
                }

                set { }
            }

            public string location { get; set; }

            public string stop { get; set; }

            //[JsonProperty("product_name")]
            public string duration { get; set; }

            public string description { get; set; }

            public bool allday { get; set; }

            public List<string> meeting_days { get; set; }


            public bool ContainsLoop(List<string> list, string value)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Split(' ')[0] == value)
                    {
                        return true;
                    }
                }
                return false;
            }

            //   public List<string> show_meeting_days1;


            public List<string> show_meeting_days
            {
                get
                {
                    // return meeting_days;
                    List<string> show_meeting_days1 = new List<string>();
                    DateTime dateTime = new DateTime();


                    for (int i = 0; i < meeting_days.Count; i++)
                    {
                        string md = meeting_days[i];

                        string convertstartdate = Convert.ToDateTime(md).ToLocalTime().ToString("yyyy-MM-dd");

                      //  string convertstartdate = dateTime.ToString("yyyy-MM-dd");

                        //  string mdfin = "01/16/2019 00:00:00";

                        //try
                        //{
                        //    dateTime = DateTime.ParseExact(mdfin, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        //}

                        //catch
                        //{

                        //    try
                        //    {
                        //        dateTime = DateTime.ParseExact(mdfin, "M/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        //    }

                        //    catch
                        //    {
                        //        try
                        //        {
                        //            dateTime = DateTime.ParseExact(mdfin, "MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                        //        }

                        //        catch
                        //        {
                        //            try
                        //            {
                        //                dateTime = DateTime.ParseExact(mdfin, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        //            }

                        //            catch
                        //            {
                        //                try
                        //                {
                        //                    dateTime = DateTime.ParseExact(mdfin, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        //                }

                        //                catch
                        //                {
                        //                    try
                        //                    {
                        //                        dateTime = DateTime.ParseExact(mdfin, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        //                    }

                        //                    catch
                        //                    {

                        //                        try
                        //                        {
                        //                            dateTime = DateTime.ParseExact(mdfin, "dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
                        //                        }
                        //                        catch
                        //                        {

                        //                            try
                        //                            {
                        //                                dateTime = DateTime.ParseExact(mdfin, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        //                            }

                        //                            catch
                        //                            {
                        //                                try
                        //                                {
                        //                                    dateTime = DateTime.ParseExact(mdfin, "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                        //                                }

                        //                                catch
                        //                                {

                        //                                    try
                        //                                    {
                        //                                        dateTime = DateTime.ParseExact(mdfin, "dd-MM-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
                        //                                    }

                        //                                    catch
                        //                                    {
                        //                                        try
                        //                                        {
                        //                                            dateTime = DateTime.ParseExact(mdfin, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        //                                        }

                        //                                        catch
                        //                                        {
                        //                                            try
                        //                                            {
                        //                                                dateTime = DateTime.ParseExact(mdfin, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                        //                                            }
                        //                                            catch
                        //                                            {
                        //                                                try
                        //                                                {
                        //                                                    dateTime = DateTime.ParseExact(mdfin, "M/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        //                                                }
                        //                                                catch
                        //                                                {
                        //                                                    try
                        //                                                    {
                        //                                                        dateTime = DateTime.ParseExact(mdfin, "M/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                        //                                                    }
                        //                                                    catch
                        //                                                    {
                        //                                                        dateTime = DateTime.ParseExact(mdfin, "M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                        //                                                    }
                        //                                                }
                        //                                            }
                        //                                        }
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

                     //   string convertstartdate = dateTime.ToString("yyyy-MM-dd");

                        show_meeting_days1.Add(convertstartdate);
                    }

                    return show_meeting_days1;
                }

                set
                {

                }

            }

            public string allDay
            {

                get
                {
                    //string data = DateTime.Parse(starting_at).ToLocalTime().ToString("yyyy-MM-dd HH:mm ");
                    //return data;
                    if (allday == true)
                    {
                        string ad = "AllDay";
                        return ad;
                    }

                    else
                    {
                        return "";
                    }

                }
                set
                {

                }
            }


            public string duration1
            {
                get
                {
                    //string data = DateTime.Parse(starting_at).ToLocalTime().ToString("yyyy-MM-dd HH:mm ");
                    //return data;
                    string dur = duration + "-Hrs";
                    return dur;
                }
                set
                {

                }
            }

            public all_events(string aName)
            {
                // Id = id;
                string name = aName;
            }

            public all_events()
            {

            }

            public string StartAt
            {
                get
                {
                    //string data = DateTime.Parse(starting_at).ToLocalTime().ToString("yyyy-MM-dd HH:mm ");
                    //return data;
                    DateTime dateTime = DateTime.ParseExact(start, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    string dat = dateTime.ToLocalTime().ToString("dd/MM/yyyy HH:mm ");
                    return dat;
                }
                set
                {

                }
            }

        }

        public class EventsAtts
        {
            public int id { get; set; }
            public string name { get; set; }
            public string image_small { get; set; }
        }

        public class MeetingsModel
        {
            //public int id { get; set; }
            //public string name { get; set; }
            //public string image_small { get; set; }
        }


        public class TagsList
        {
            public string name { get; set; }
            public string colour { get; set; }
            //  public int Id { get; set; }

            public TagsList(string aName)
            {
                // Id = id;
                name = aName;
            }

            //public TagsList(int id, string aName)
            //{
            //    Id = id;
            //    name = aName;
            //}
        }


        public class CustomersModel
        {
            public string name { get; set; }
            public string email { get; set; }
            public string street { get; set; }
            public string city { get; set; }
            public int crm_count { get; set; }
            public int sales_count { get; set; }
            public int meeting_count { get; set; }
            public string mobile { get; set; }
            public string phone { get; set; }
            public string zip { get; set; }

            public int id { get; set; }

            //    public string image_medium { get; set; }
            public string image_small { get; set; }

            public string website { get; set; }

            public Dictionary<int, string> tags { get; set; }

            public ImageSource imagetest { get; set; }

            public List<ContactsList> contacts { get; set; }

            public ImageSource CustomerImg
            {
                get
                {
                    if (image_small != "")
                    {
                        byte[] imageAsBytes = Encoding.UTF8.GetBytes(image_small);
                        byte[] decodedByteArray = System.Convert.FromBase64String(Encoding.UTF8.GetString(imageAsBytes, 0, imageAsBytes.Length));
                        imagetest = ImageSource.FromStream(() => new MemoryStream(decodedByteArray));
                        // imagetest = ImageSource.FromStream(() => stream);
                        return imagetest;
                    }
                    else
                    {
                        imagetest = "unknown.png";
                        return imagetest;
                    }

                }
                set
                {
                    // image = value;
                }
            }

        }

        public class ContactsList
        {
            public int id { get; set;  }
            public string mobile { get; set; }
            public string phone { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string image_small { get; set; }
            public string position { get; set; }
            public ImageSource imagetest { get; set; }

            public ImageSource CustomerImg
            {
                get
                {
                    if (image_small != "")
                    {
                        byte[] imageAsBytes = Encoding.UTF8.GetBytes(image_small);
                        byte[] decodedByteArray = System.Convert.FromBase64String(Encoding.UTF8.GetString(imageAsBytes, 0, imageAsBytes.Length));
                        imagetest = ImageSource.FromStream(() => new MemoryStream(decodedByteArray));
                        // imagetest = ImageSource.FromStream(() => stream);
                        return imagetest;
                    }
                    else
                    {
                        imagetest = "unknown.png";
                        return imagetest;
                    }
                }
                set
                {
                }
            }

            public string PhoneNo
            {
                get
                {
                    if (phone == "False")
                    {
                        phone = "";
                        return phone;
                    }
                    else
                    {
                        return phone;
                    }
                }
                set
                {

                }
            }

        }

        public class ContactsCreationList
        {
            public string Mobile { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public ImageSource Image { get; set; }

            public string ImageString { get; set; }

            public ContactsCreationList(string name, string mobile, string email, string img, string test)
            {
                Mobile = mobile;
                Name = name;
                Email = email;
                ImageString = img;

                byte[] imageAsBytes = Encoding.UTF8.GetBytes(img);
                byte[] decodedByteArray = System.Convert.FromBase64String(Encoding.UTF8.GetString(imageAsBytes, 0, imageAsBytes.Length));
                Image = ImageSource.FromStream(() => new MemoryStream(decodedByteArray));
            }
        }

        public class ContactsCreationList1
        {

            public string mobile { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string image { get; set; }

            public ContactsCreationList1(string Name, string Mobile, string Email, string Img)
            {
                mobile = Mobile;
                name = Name;
                email = Email;
                image = Img;
            }

        }

        public class StockWareHouseList
        {
            public string item_no { get; set; }
            public int qty { get; set; }
            public string location { get; set; }
            public string product { get; set; }

            public string Date { get; set; }

            public string DATENOW
            {
                get
                {
                    string date = DateTime.Now.ToString("MMMM dd");

                    return date;
                }
                set
                {

                }
            }

        }

        public class SalesTarget
        {
            // [JsonProperty("customer_lead")]
            //public List<SalesTargetcategory> category { get; set; }

            //// [JsonProperty("price_unit")]
            //public List<SalesTargetBrand> brand { get; set; }


            public List<target_line> target_line { get; set; }


            public int id { get; set; }

            // [JsonProperty("product_uom_qty")]
            public string name { get; set; }

            // [JsonProperty("price_subtotal")]
            //  public string target_type { get; set; }

            public string commission_type { get; set; }

        }



        public class target_line
        {
            public string max_target { get; set; }
            public string amount { get; set; }
            public string min_target { get; set; }
        }

        public class SalesTargetcategory
        {
            public string category { get; set; }
            public int target { get; set; }
        }

        public class SalesTargetBrand
        {
            public string brand { get; set; }
            public int target { get; set; }
        }



        public class ActivePromotions
        {
            public string name { get; set; }
            public string product { get; set; }
            public string type { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public string category { get; set; }
            public string minimum_amount { get; set; }

            public List<type_list> type_list { get; set; }

            public List<list1> list1 { get; set; }

            public List<list2> list2 { get; set; }


            public string fstart_date { get; set; }
            public string fend_date { get; set; }

            public string Fstart_date
            {
                get
                {
                    try
                    {
                        DateTime dt = DateTime.ParseExact(start_date, "yyyy-MM-dd hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                        fstart_date = dt.ToString("d MMM");
                        //  return pipe_date;
                        return fstart_date;
                    }
                    catch
                    {

                        return start_date;
                    }
                }

                set
                {
                    start_date = value;
                }
            }


            public string Fend_date
            {
                get
                {
                    try
                    {
                        DateTime dt = DateTime.ParseExact(end_date, "yyyy-MM-dd hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                        fend_date = dt.ToString("d MMM");
                        //  return pipe_date;
                        return fend_date;
                    }
                    catch
                    {

                        return end_date;
                    }
                }

                set
                {
                    end_date = value;
                }
            }

            public string endcolor { get; set; }
            public string EndDateColor
            {
                get
                {
                    try
                    {
                        if (end_date == "")
                        {
                            endcolor = "#ffffff";
                        }

                        else
                        {
                            endcolor = "#f96060";

                        }

                        //  return pipe_date;
                        return endcolor;
                    }
                    catch
                    {

                        return endcolor;
                    }
                }

                set
                {
                    end_date = value;
                }
            }


        }

        public class list1
        {
            public string product { get; set; }
            public string minimum_quantity { get; set; }
            public string maximum_quantity { get; set; }
        }

        public class list2
        {
            public string discount { get; set; }
            public string product { get; set; }
            public string account { get; set; }
            public string quantity_free { get; set; }

        }

        public class type_list
        {
            public string category { get; set; }
            public string discount { get; set; }

            public string product { get; set; }
            public string total_price { get; set; }
            public string minimum_quantity { get; set; }
            public string maximum_quantity { get; set; }

            public string minimum_amount { get; set; }
            public string list_price { get; set; }

        }


        public class LoggedCalls
        {
            public string user_id { get; set; }
            public string name { get; set; }
            public string partner_name { get; set; }
            public string user_name { get; set; }
            public string state { get; set; }
            public string duration { get; set; }
            public string partner_phone { get; set; }
            public string opportunity_id { get; set; }
            public string partner_id { get; set; }
            public string opportunity_name { get; set; }
            public string date { get; set; }
        }

        public class Attachments
        {
            // [JsonProperty("customer_lead")]
            public int id { get; set; }

            // [JsonProperty("price_unit")]
            public string file { get; set; }

            public string file_name { get; set; }

          //  public string datas { get; set; }

            public string datas_fname { get; set; }

        }


        public class Brand
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public string display_name { get; set; }
        }

    }

}

