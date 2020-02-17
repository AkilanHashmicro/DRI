using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.DBModel;
using SalesApp.models;
using SalesApp.Persistance;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    public partial class ActivePromotionDetailPage : PopupPage
    {
        List<list1> list_1t = new List<list1>();
        List<list2> list_2 = new List<list2>();
        List<type_list> type_list = new List<type_list>();

        List<SalesOrder> promoresult = new List<SalesOrder>();

        public ActivePromotionDetailPage(ActivePromotions item)
        {
            InitializeComponent();

            //  act_promo = item;

            title.Text = item.name;
            type_val.Text = item.type;
            proservice_val.Text = item.product;
            startdate_val.Text = item.start_date;
            enddate_val.Text = item.end_date;


            //  promoresult = Controller.InstanceCreation().GetSalesData(cus_id);

            if (item.type == "7_total_price_product_filter_by_quantity")
            {

                sevan_totalpricefilter_stack.IsVisible = true;
                sevan_totalListview.ItemsSource = item.type_list;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;

            }

            else if (item.type == "6_price_filter_quantity")
            {
                six_unitpricefilter_stack.IsVisible = true;
                six_unitpriceListview.ItemsSource = item.type_list;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else if (item.type == "5_pack_free_gift")
            {
                five_bypackfree_stack.IsVisible = true;
                fiveaaa_bypackfree2_stack.IsVisible = true;

                five_bypackfreeListview.ItemsSource = item.list1;
                bypackfreeListview2.ItemsSource = item.list2;

                five_bypackfreeListview.HeightRequest = item.list1.Count * 50;
                bypackfreeListview2.HeightRequest = item.list2.Count * 50;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else if (item.type == "4_pack_discount")
            {
                four_bypackdiscount_stack.IsVisible = true;
                fouraaa_bypackdiscount2_stack.IsVisible = true;

                four_bypackdiscountListview.ItemsSource = item.list1;
                four_bypackdiscountListview2.ItemsSource = item.list2;

                four_bypackdiscountListview.HeightRequest = item.list1.Count * 50;
                four_bypackdiscountListview2.HeightRequest = item.list2.Count * 50;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;

            }

            else if (item.type == "3_discount_by_quantity_of_product")
            {
                three_dis_by_quan_stack.IsVisible = true;

                three_dis_by_quanListview.ItemsSource = item.type_list;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;

                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else if (item.type == "2_discount_category")
            {

                two_dis_on_cat_stack.IsVisible = true;
                two_dis_on_catListview.ItemsSource = item.type_list;

                one_dis_on_totorder_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else if (item.type == "1_discount_total_order")
            {
                one_dis_on_totorder_stack.IsVisible = true;
                one_dis_on_totorderListview.ItemsSource = item.type_list;

                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else
            {

            }

            var backRecognizer = new TapGestureRecognizer();
            backRecognizer.Tapped += (s, e) => {

                PopupNavigation.PopAsync();
                //    Navigation.PopAllPopupAsync();
                //   Navigation.PushAsync(new CalendarPage());
                //  App.Current.MainPage = new MasterPage(new CalendarPage());


            };
            backImg.GestureRecognizers.Add(backRecognizer);


        }



        public ActivePromotionDetailPage(ActivePromotionsDB item)
        {
            InitializeComponent();

            //  act_promo = item;


            List<type_list> type_listdb = new List<type_list>();

            List<list1> list1db = new List<list1>();
            List<list2> list2db = new List<list2>();

            var json_list_type = JsonConvert.SerializeObject(item.type_list);
            var json_list1 = JsonConvert.SerializeObject(item.list1);
            var json_list2 = JsonConvert.SerializeObject(item.list2);

            String type_list_str = json_list_type.ToString();
            String list1string = json_list1.ToString();
            String list2string = json_list2.ToString();

            //type_list starts here

            String fin_type_string = type_list_str.Replace("\\", "");
            fin_type_string = fin_type_string.Substring(1);
            fin_type_string = fin_type_string.Remove(fin_type_string.Length - 1);
            JArray type_list_string = JsonConvert.DeserializeObject<JArray>(fin_type_string);

            //list 1 starts here

            String finlist1string = list1string.Replace("\\", "");
            finlist1string = finlist1string.Substring(1);
            finlist1string = finlist1string.Remove(finlist1string.Length - 1);
            JArray list1_string = JsonConvert.DeserializeObject<JArray>(finlist1string);

            //list 2 starts here

            String finlist2string = list2string.Replace("\\", "");
            finlist2string = finlist2string.Substring(1);
            finlist2string = finlist2string.Remove(finlist2string.Length - 1);
            JArray list2_string = JsonConvert.DeserializeObject<JArray>(finlist2string);

            if (list1_string != null)
            {

                foreach (JObject obj in list1_string)
                {
                    list1 list1new = new list1();

                    try
                    {
                        list1new.product = obj["product"].ToString();
                    }
                    catch
                    {
                        list1new.product = "";
                    }

                    try
                    {
                        list1new.minimum_quantity = obj["minimum_quantity"].ToString();
                    }
                    catch
                    {
                        list1new.minimum_quantity = "";
                    }

                    try
                    {
                        list1new.maximum_quantity = obj["maximum_quantity"].ToString();
                    }
                    catch
                    {
                        list1new.maximum_quantity = "";
                    }


                    list1db.Add(list1new);
                }

            }


            if (list2_string != null)
            {

                //        public string discount { get; set; }
                //public string product { get; set; }
                //public string account { get; set; }
                //public string quantity_free { get; set; }

                foreach (JObject obj in list2_string)
                {
                    list2 list2new = new list2();
                    try
                    {
                        list2new.product = obj["product"].ToString();
                    }

                    catch
                    {
                        list2new.product = "";
                    }

                    try
                    {
                        list2new.discount = obj["discount"].ToString();
                    }
                    catch
                    {
                        list2new.discount = "";
                    }

                    try
                    {
                        list2new.account = obj["account"].ToString();
                    }

                    catch
                    {
                        list2new.account = "";
                    }

                    try
                    {
                        list2new.quantity_free = obj["quantity_free"].ToString();
                    }

                    catch
                    {
                        list2new.quantity_free = "";
                    }

                    list2db.Add(list2new);
                }

            }


            if (type_list_string != null)
            {

                foreach (JObject obj in type_list_string)
                {
                    type_list type_listnew = new type_list();

                    try
                    {
                        type_listnew.category = obj["category"].ToString();
                    }

                    catch
                    {
                        type_listnew.category = "";
                    }

                    try
                    {
                        type_listnew.discount = obj["discount"].ToString();
                    }

                    catch
                    {
                        type_listnew.discount = "";
                    }

                    try
                    {
                        type_listnew.product = obj["product"].ToString();
                    }

                    catch
                    {
                        type_listnew.product = "";
                    }


                    try
                    {
                        type_listnew.total_price = obj["total_price"].ToString();
                    }

                    catch
                    {
                        type_listnew.total_price = "";
                    }

                    try
                    {
                        type_listnew.minimum_quantity = obj["minimum_quantity"].ToString();
                    }

                    catch
                    {
                        type_listnew.minimum_quantity = "";
                    }

                    try
                    {
                        type_listnew.maximum_quantity = obj["maximum_quantity"].ToString();
                    }

                    catch
                    {
                        type_listnew.maximum_quantity = "";
                    }
                    try
                    {
                        type_listnew.minimum_amount = obj["minimum_amount"].ToString();
                    }

                    catch
                    {
                        type_listnew.minimum_amount = "";
                    }

                    try
                    {
                        type_listnew.list_price = obj["list_price"].ToString();
                    }

                    catch
                    {
                        type_listnew.list_price = "";
                    }

                    type_listdb.Add(type_listnew);
                }

            }

            title.Text = item.name;
            type_val.Text = item.type;
            proservice_val.Text = item.product;
            startdate_val.Text = item.start_date;
            enddate_val.Text = item.end_date;

            if (item.type == "7_total_price_product_filter_by_quantity")
            {

                sevan_totalpricefilter_stack.IsVisible = true;
                sevan_totalListview.ItemsSource = type_listdb;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;

            }

            else if (item.type == "6_price_filter_quantity")
            {
                six_unitpricefilter_stack.IsVisible = true;
                six_unitpriceListview.ItemsSource = type_listdb;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else if (item.type == "5_pack_free_gift")
            {
                five_bypackfree_stack.IsVisible = true;
                fiveaaa_bypackfree2_stack.IsVisible = true;

                five_bypackfreeListview.ItemsSource = list1db;
                bypackfreeListview2.ItemsSource = list2db;

                five_bypackfreeListview.HeightRequest = list1db.Count * 50;
                bypackfreeListview2.HeightRequest = list2db.Count * 50;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else if (item.type == "4_pack_discount")
            {
                four_bypackdiscount_stack.IsVisible = true;
                fouraaa_bypackdiscount2_stack.IsVisible = true;



                four_bypackdiscountListview.ItemsSource = list1db;
                four_bypackdiscountListview2.ItemsSource = list2db;

                four_bypackdiscountListview.HeightRequest = list1db.Count * 50;
                four_bypackdiscountListview2.HeightRequest = list2db.Count * 50;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;

            }

            else if (item.type == "3_discount_by_quantity_of_product")
            {
                three_dis_by_quan_stack.IsVisible = true;

                three_dis_by_quanListview.ItemsSource = type_listdb;

                one_dis_on_totorder_stack.IsVisible = false;
                two_dis_on_cat_stack.IsVisible = false;

                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else if (item.type == "2_discount_category")
            {

                two_dis_on_cat_stack.IsVisible = true;
                two_dis_on_catListview.ItemsSource = type_listdb;

                one_dis_on_totorder_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else if (item.type == "1_discount_total_order")
            {
                one_dis_on_totorder_stack.IsVisible = true;
                one_dis_on_totorderListview.ItemsSource = type_listdb;

                two_dis_on_cat_stack.IsVisible = false;
                three_dis_by_quan_stack.IsVisible = false;
                four_bypackdiscount_stack.IsVisible = false;
                fouraaa_bypackdiscount2_stack.IsVisible = false;
                five_bypackfree_stack.IsVisible = false;
                fiveaaa_bypackfree2_stack.IsVisible = false;
                six_unitpricefilter_stack.IsVisible = false;
                sevan_totalpricefilter_stack.IsVisible = false;
            }

            else
            {

            }

            var backRecognizer = new TapGestureRecognizer();
            backRecognizer.Tapped += (s, e) => {

                PopupNavigation.PopAsync();
                //    Navigation.PopAllPopupAsync();
                //   Navigation.PushAsync(new CalendarPage());
                //  App.Current.MainPage = new MasterPage(new CalendarPage());


            };
            backImg.GestureRecognizers.Add(backRecognizer);
        }


        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            obj.View.BackgroundColor = Color.FromHex("#FFFFFF");
        }

        protected override bool OnBackButtonPressed()
        {

            PopupNavigation.PopAsync();
            return true;
        }


    }
}
