using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.DBModel;
using SalesApp.models;
using SalesApp.Pages;
using SalesApp.Persistance;
using SalesApp.wizard;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    public partial class SalesQuotationCreationPage : PopupPage
    {

        string taxname = "";
        string overper_string = "";
        bool new_customer = false;

        int cus_id = 0;

        bool add_orderline_btn_clicked = false;

        void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            throw new NotImplementedException();
        }

        void multidiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool entry = false;

            //  bool res = Regex.IsMatch(dis1.Text, @"^-?\d+$");

            //    bool res1 = Regex.IsMatch(multidis.Text, @"^\d+$");

            bool res = Regex.IsMatch(multidis.Text, @"\d");


            if (multidis.Text == "+")
            {
                entry = true;
            }

            else if (multidis.Text == "+" || multidis.Text == "." || res == true)
            {
                entry = true;
            }

            else
            {
                entry = false;
            }

            if( entry && res)
            {

                var foos = multidis.Text;
                var fooArray = foos.Split('+');  

                double discount_per = 100;    

                //string[] stringArray = foos.Split(',').ToArray();

                //foos = String.Join(",", fooArray).toa;


                for (int i = 0; i < fooArray.Length; i++)
                {
                    if (fooArray[i] != "")
                    {
                        double val = Convert.ToDouble(fooArray[i]);
                        discount_per = discount_per - ((val / 100) * discount_per);
                    }
                }


                double overper = 100 - discount_per;

                overper =  Convert.ToDouble(overper.ToString("n2"));

                overper_string = overper.ToString();

                dis1.Text = overper.ToString();
             
            }


            else
            {
                if (dis1.Text == "" && multidis.Text == "")
                {

                }
                else
                {
                    DisplayAlert("Alert", "Please give valid input", "Ok");
                }

            }

            //if(e.NewTextValue != "+" && !="")
            //{
                
            //}

            //else

        }

        List<KeyValuePair<string, dynamic>> order_lines = new List<KeyValuePair<string, dynamic>>();
        List<int> taxidList = new List<int>();

        List<Dictionary<string, dynamic>> abc = new List<Dictionary<string, dynamic>>();
        List<OrderLinesList> orderLineList1 = new List<OrderLinesList>();
        List<OrderLinesList> orderLineList2 = new List<OrderLinesList>();

        Dictionary<int, string> cusdictdb = new Dictionary<int, string>();
        List<taxes> taxListdb = new List<taxes>();
        List<paytermList> payment_termsdb = new List<paytermList>();
        List<commisiongroupList> commission_groupdb = new List<commisiongroupList>();

        List<Brand> brand_List = new List<Brand>();

        List<Category> category_List = new List<Category>();

     //   Dictionary<int, object> salesteamdict = new Dictionary<int, object>(

       
        public SalesQuotationCreationPage()
        {
            InitializeComponent();
            orderListview.HeightRequest = 0;
       //     App.tap_plusbtncheck = true;


          //  addorderline_Btn.Clicked += addorderline_Btn_clicked;

            if (App.NetAvailable == true)
            {

                //cuspicker1.ItemsSource = App.cusdict.Select(x => x.Value).ToList();
                //cuspicker1.SelectedIndex = 0;

                var dropdownImgRecognizer = new TapGestureRecognizer();
                dropdownImgRecognizer.Tapped += (s, e) =>
                {
                     Navigation.PushPopupAsync(new PickerSelectionPage());               
                    searchprod.IsVisible = true;

                };
                pickerdropimg.GestureRecognizers.Add(dropdownImgRecognizer);


                var empimgImgRecognizer = new TapGestureRecognizer();
                empimgImgRecognizer.Tapped += (s, e) =>
                {
                    empimg1.IsVisible = false;
                    fillimg1.IsVisible = true;
                    new_customer = true;

                };
                empimg1.GestureRecognizers.Add(empimgImgRecognizer);

                var fillimgImgRecognizer = new TapGestureRecognizer();
                fillimgImgRecognizer.Tapped += (s, e) =>
                {
                    empimg1.IsVisible = true;
                    fillimg1.IsVisible = false;
                    new_customer = false;

                };
                fillimg1.GestureRecognizers.Add(fillimgImgRecognizer);


                //taxpicker.ItemsSource = App.taxList.Select(x => x.Name).ToList();
                //taxpicker.SelectedIndex = 0;

                ptpicker.ItemsSource = App.paytermList.Select(x => x.name).ToList();
                ptpicker.SelectedIndex = 0;

                brand_picker.ItemsSource = App.brandList.Select(x => x.name).ToList();
                brand_picker.SelectedItem = 0;

                category_picker.ItemsSource = App.categoriesList.Select(x => x.display_name).ToList();
                category_picker.SelectedItem = 0;

                //comgroup_picker.ItemsSource = App.commisiongroupList.Select(x => x.name).ToList();
                //comgroup_picker.SelectedIndex = 0;

            }

            else if(App.NetAvailable ==false)
            {
                int user_iddb = 0;
                int partner_iddb = 0;

                JArray taxtlist_array = new JArray();

                foreach (var res in App.UserListDb)
                {
                    
                    cusdictdb = JsonConvert.DeserializeObject<Dictionary<int, string>>(res.customers_list);
                    taxtlist_array = JsonConvert.DeserializeObject<JArray>(res.tax_list);                   
                    payment_termsdb = JsonConvert.DeserializeObject<List<paytermList>>(res.payment_terms);
                    commission_groupdb = JsonConvert.DeserializeObject<List<commisiongroupList>>(res.commission_group);

                    user_iddb = res.userid;
                    partner_iddb = res.partnerid;

                }

                foreach (JObject obj in taxtlist_array)
                        {
                           taxes  taxesdb = new taxes("");                                      
                            taxesdb.Id  = obj["id"].ToObject<int>();
                            taxesdb.Name  = obj["name"].ToString();
                            taxListdb.Add(taxesdb);
                        }


                App.taxListdb = taxListdb;

                //cuspicker1.ItemsSource = cusdictdb.Select(x => x.Value).ToList();
                //cuspicker1.SelectedIndex = 0;

                var dropdownImgRecognizer = new TapGestureRecognizer();
                dropdownImgRecognizer.Tapped += (s, e) =>
                {
                    Navigation.PushPopupAsync(new PickerSelectionPage());
                };
                pickerdropimg.GestureRecognizers.Add(dropdownImgRecognizer);

                //taxpicker.ItemsSource = taxListdb.Select(x => x.Name).ToList();
                //taxpicker.SelectedIndex = 0;

                ptpicker.ItemsSource = payment_termsdb.Select(x => x.name).ToList();
                ptpicker.SelectedIndex = 0;

                //comgroup_picker.ItemsSource = commission_groupdb.Select(x => x.name).ToList();
                //comgroup_picker.SelectedIndex = 0;
            }

            var AirConImgRecognizer = new TapGestureRecognizer();
            AirConImgRecognizer.Tapped += (s, e) => {
                // handle the tap 
                //pd.ItemsSource = App.productList.Select(x => x.Name).ToList();
                //pd.SelectedIndex = 0;
                airconImg1.IsVisible = true;
                AddAirCon.IsVisible = false;
                orderLineGrid.IsVisible = true;
                discount_grid.IsVisible = true;
            //    orderLineGrid_1.IsVisible = true;

                 taxname = "";

                taxlistviewGrid.IsVisible = true;

                Addtax_line.IsVisible = true;

                dis1.Text = "";
                multidis.Text = "";
              //  addtaxGrid.IsVisible = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
              //  taxpicker.SelectedIndex = 0;
                taxListView.ItemsSource = null;

                //taxStackLayout.BackgroundColor = Color.FromHex("#F0EEEF");
                //taxListView.HeightRequest = 0;
                //taxStackLayout.CornerRadius = 0;
                //taxListView.BackgroundColor = Color.FromHex("#FOEEF");
                taxStackLayout.IsVisible = false;

                App.taxListRemove.Clear();
                orderListview.ItemsSource = orderLineList1;
            };
            AddAirCon.GestureRecognizers.Add(AirConImgRecognizer);

          

            var Addtax_lineImgRecognizer = new TapGestureRecognizer();
            Addtax_lineImgRecognizer.Tapped += (s, e) => {

               // addtaxGrid.IsVisible = true;
                Addtax_line.IsVisible = false;

                Navigation.PushPopupAsync(new TaxSelectionPage());

            };
            Addtax_line.GestureRecognizers.Add(Addtax_lineImgRecognizer);



         var overallcloseImgRecognizer = new TapGestureRecognizer();
            overallcloseImgRecognizer.Tapped += (s, e) => {
                // handle the tap              
                Navigation.PopAllPopupAsync();
            };
            overall_close.GestureRecognizers.Add(overallcloseImgRecognizer);
        }


        void customerentry(object sender, EventArgs args)
        {
            Navigation.PushPopupAsync(new CustomerSelectionPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string, string>("MyApp", "NotifyMsg", (sender, arg) =>
            {
               // HideLbl.Text = "New Quotation Creation";

            });

            MessagingCenter.Subscribe<string, int>("MyApp", "CusPickerMsg", (sender, arg) =>
            {
                // HideLbl.Text = "New Quotation Creation";

                if (App.cusList.Count != 0)
                {
                    var productlis = from pro in App.cusList
                                     where pro.id == arg
                                     select pro;

                    foreach (var prodresults in productlis)
                    {
                        searchcus.Text = prodresults.name;
                        cus_id = prodresults.id;
                    }
                }

                else
                {
                    var productlis = from pro in App.cusList
                                     where pro.id == arg
                                     select pro;

                    foreach (var prodresults in productlis)
                    {
                        searchcus.Text = prodresults.name;
                        cus_id = prodresults.id;
                    }
                }

                int i = 0;

            });


            MessagingCenter.Subscribe<string, string>("MyApp", "taxPickerMsg", (sender, arg) =>
            {
                
                taxListView.ItemsSource = null;

                App.taxListRemove.Add(new taxes(arg));

                App.taxListRemove = App.taxListRemove.GroupBy(i => i.Name).Select(g => g.First()).ToList();
                // taxpicker.IsVisible = false;
                taxStackLayout.IsVisible = true;
                taxListView.ItemsSource = App.taxListRemove;

                taxListView.RowHeight = 35;
                taxListView.HeightRequest = 35 * App.taxListRemove.Count;

                taxStackLayout.BackgroundColor = Color.FromHex("#363E4B");
                taxListView.BackgroundColor = Color.FromHex("#363E4B");
                taxStackLayout.CornerRadius = 20;

                taxStackLayout.Padding = 5;

                // taxpickstringList.Add(taxpicker.SelectedItem.ToString());
                var taxesid =
               (
               from i in App.taxList
               where i.Name == arg

               select new
               {
                   i.Id,
               }
               ).ToList();

                foreach (var person in taxesid)
                {
                    int selecttaxid = person.Id;
                    taxidList.Add(selecttaxid);
                    taxidList = taxidList.GroupBy(i => i).Select(g => g.First()).ToList();
                }

                Addtax_line.IsVisible = true;

            });



            MessagingCenter.Subscribe<string, int>("MyApp", "PickerMsg", (sender, arg) =>
            {
                // HideLbl.Text = "New Quotation Creation";

                if (App.productList.Count != 0)
                {
                    var productlis = from pro in App.productList
                                               where pro.Id == arg
                                               select pro;

                    foreach (var prodresults in productlis)
                    {
                        searchprod.Text = prodresults.Name;
                        orderline_des.Text = prodresults.Name;
                        up.Text = prodresults.list_price;
                        pro_id.Text = prodresults.default_code;
                        brand_picker.SelectedItem = prodresults.product_brand_name;
                        category_picker.SelectedItem = prodresults.product_categ_name;
                    }
                }

                else
                {
                    var productlis = from pro in App.ProductListDb
                                               where pro.Id == arg
                                               select pro;

                    foreach (var prodresults in productlis)
                    {
                        searchprod.Text = prodresults.Name;
                        orderline_des.Text = prodresults.Name;
                        up.Text = prodresults.list_price;
                        pro_id.Text = prodresults.default_code;
                        brand_picker.SelectedItem = prodresults.product_brand_name;
                        category_picker.SelectedItem = prodresults.product_categ_name;
                    }
                }

                int i = 0;

            });
        }


        private void Button_Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAllPopupAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
           // return base.OnBackButtonPressed();

            Navigation.PopAllPopupAsync();
            return true;
        }

        async void Loadingalertcall()
        {
            await PopupNavigation.PopAllAsync();
        }


        private void Tab1Clicked(object sender, EventArgs ea)
        {
            tab1stack.BackgroundColor = Color.FromHex("#363E4B");
            tab1.BackgroundColor = Color.FromHex("#363E4B");
            tab2stack.BackgroundColor = Color.White;
            tab2.BackgroundColor = Color.White;
            tab2frame.BackgroundColor = Color.FromHex("#363E4B");
            tab2borderstack.BackgroundColor = Color.White;
            orderLineList.IsVisible = true;
           OtherInfoStack1.IsVisible = false;
          //  OtherInfoStack2.IsVisible = false;
            tab1frame.BackgroundColor = Color.FromHex("#363E4B");
            tab1borderstack.BackgroundColor = Color.FromHex("#363E4B");
            OrderLineList1.IsVisible = true;

           // tap2_clicked = false;

            //if (editbtn_clicked == true)
            //{
            //    addbtn_orderline.IsVisible = true;
            //}
              //savebtn_layout.IsVisible = true;

            tab1.TextColor = Color.White;
            tab2.TextColor = Color.Black;

            airconImg.IsVisible = true;
        }

        private void Tab2Clicked(object sender, EventArgs ea)
        {
            tab2stack.BackgroundColor = Color.FromHex("#363E4B");
            tab2.BackgroundColor = Color.FromHex("#363E4B");
            tab1stack.BackgroundColor = Color.White;
            tab1.BackgroundColor = Color.White;
            tab2borderstack.BackgroundColor = Color.FromHex("#363E4B");
            tab2frame.BackgroundColor = Color.FromHex("#363E4B");
            orderLineList.IsVisible = false;
           OtherInfoStack1.IsVisible = true;
          //  OtherInfoStack2.IsVisible = true;
            tab1frame.BackgroundColor = Color.FromHex("#363E4B");
            tab1borderstack.BackgroundColor = Color.White;
            OrderLineList1.IsVisible = false;

          //  listview_editlayout.IsVisible = false;
            discount_grid.IsVisible = false;
            taxlistviewGrid.IsVisible = false;
         //   addbtn_orderline.IsVisible = false;

            tab1.TextColor = Color.Black;
            tab2.TextColor = Color.White;

            if (salesperson_picker.SelectedItem == null)
            {
                salesperson_picker.ItemsSource = App.salespersons.Select(x => x.Value).ToList();
            }

            if (salesteam_picker.SelectedItem == null)
            {
                salesteam_picker.ItemsSource = App.salesteam.Select(x => x.Value).ToList();
            }
            //   tap2_clicked = true;

            airconImg.IsVisible = false;

            //  savebtn_layout.IsVisible = false;

        }

        private async void Button_Add_ClickedAsync(object sender, EventArgs e)
        {
            var currentpage = new LoadingAlert();
            await PopupNavigation.PushAsync(currentpage);

            int selectpaytermid = 0;
            int selectcomgroupid = 0;
            Dictionary<string, dynamic> vals = new Dictionary<string, dynamic>();
                   
            //try
            //{
            //    List<CRMLead> crmLeadData = Controller.InstanceCreation().crmLeadData();
                             
            //}

            //catch (Exception ea)
            //{
             //   if (ea.Message.Contains("(Network is unreachable)") || ea.Message.Contains("NameResolutionFailure"))
             //   {
             //       App.NetAvailable = false;
             //   }

             //   else if (ea.Message.Contains("(503) Service Unavailable"))
             //   {
             //       App.responseState = false;
             //   }

             //}

            if(searchcus.Text =="")
            {
                await DisplayAlert("Alert", "Please select customer", "Ok");
                await PopupNavigation.PopAsync();
            }

            else if(orderLineList1.Count == 0)
            {
               await DisplayAlert("Alert", "Please select atleast one", "Ok");

                // await Navigation.PopAsync();

                await PopupNavigation.PopAsync();

               // Loadingalertcall();
            }


            else
            {
                // vals["customer"] = cuspicker1.SelectedItem;

             
                vals["order_date"] = orDatePicker.Date;

                vals["expiration_date"] = exDatePicker.Date;

                if (ptpicker.SelectedItem == null)
                {
                    vals["payment_terms"] = false;
                }
                else
                {
                    var paytermid =
                    (
                            from i in App.paytermList
                            where i.name == ptpicker.SelectedItem.ToString()
                            select new
                            {
                                i.id,
                            }
               ).ToList();

                    foreach (var person in paytermid)
                    {
                        selectpaytermid = person.id;
                    }

                    vals["payment_terms"] = selectpaytermid;
                }

               // if (comgroup_picker.SelectedItem == null)
               // {
               //     vals["commission_group"] = false;
               // }

               // else
               // {
               //     var comgroupid =
               //     (
               //             from i in App.commisiongroupList
               //             where i.name == comgroup_picker.SelectedItem.ToString()
               //             select new
               //             {
               //                 i.id,
               //             }
               //).ToList();

                //    foreach (var comgroup in comgroupid)
                //    {
                //        selectcomgroupid = comgroup.id;
                //    }

                //    vals["commission_group"] = selectcomgroupid;
                //}


                vals["user_id"] = App.userid;

               // var cusid = App.cusdict.FirstOrDefault(x => x.Value == cuspicker1.SelectedItem.ToString()).Key;
                vals["customer"] = cus_id;

                vals["order_lines"] = orderLineList1;
                vals["state"] = "draft";

                vals["is_direct_so"] = false;

                vals["name"] = saleorder_name.Text;
                vals["is_new_customer"] = new_customer;

              //  vals["discount"] = dis1.Text;
               // vals["multi_discount"] = overper_string;

                //var brand_id = App.brandList.FirstOrDefault(x => x.name == brand_picker.SelectedItem.ToString()).id;
                //vals["product_brand_id"] = brand_id;

                //var category_id = App.categoriesList.FirstOrDefault(x => x.display_name == category_picker.SelectedItem.ToString()).id;
                //vals["categ_id"] = category_id;

                //vals["default_code"] = pro_id.Text;


               // if (App.NetAvailable == true)
                if (CrossConnectivity.Current.IsConnected == true)
                {

                    try
                    {
                        string updated = Controller.InstanceCreation().UpdateCRMOpporData("sale.crm", "create_sale_quotation", vals);


                        if (updated == "True")
                        {
                            // App.Current.MainPage = new MasterPage(new CrmTabbedPage());
                            // Navigation.PushPopupAsync(new MasterPage(  );
                            // await  DisplayAlert("Alert", "Successfully created", "Ok");
                            //  await Navigation.PopAllPopupAsync();

                            App.Current.MainPage = new MasterPage(new CrmTabbedPage("tab3"));

                            Loadingalertcall();
                        }

                        else
                        {
                            int index = updated.IndexOf("\n");
                            if (index > 0)
                                updated = updated.Substring(0, index);

                            await DisplayAlert("Alert", updated, "Ok");
                            await  PopupNavigation.PopAsync();
                          //  Loadingalertcall();
                        }//
                    }

                    catch(Exception exc)
                    {
                        await DisplayAlert("Alert", "Please try again", "Ok");
                        Loadingalertcall(); 
                    }
                }

                else if(App.NetAvailable == false)
                {

                    string ptpickerstring = ptpicker.SelectedItem.ToString();

                    //string cgpickerstring = "";

                    //try
                    //{
                    //     cgpickerstring = comgroup_picker.SelectedItem.ToString();
                    //}
                    //catch
                    //{
                    //    cgpickerstring = "";
                    //}

                   // ptpickerstring = ptpicker.SelectedItem.ToString();

                    if (ptpicker.SelectedItem == null)
                    {
                        //  vals["payment_terms"] = false;

                        ptpickerstring = "";
                    }
                    else
                    {
                        
                        var paytermid =
                        (
                                from i in payment_termsdb
                                where i.name == ptpicker.SelectedItem.ToString()
                                select new
                                {
                                    i.id,
                                }
                   ).ToList();


                        foreach (var person in paytermid)
                        {
                            selectpaytermid = person.id;
                        }

                    }

                   vals["payment_terms"] = selectpaytermid;


                   // if (comgroup_picker.SelectedItem == null)
                   // {
                   //     //vals["commission_group"] = false;
                   //     cgpickerstring = "";
                   // }

                   // else
                   // {
                   //     var comgroupid =
                   //     (
                   //             from i in commission_groupdb
                   //             where i.name == comgroup_picker.SelectedItem.ToString()
                   //             select new
                   //             {
                   //                 i.id,
                   //             }
                   //).ToList();

                    //    foreach (var comgroup in comgroupid)
                    //    {
                    //        selectcomgroupid = comgroup.id;
                    //    }

                    //    vals["commission_group"] = selectcomgroupid;
                    //}

                    //var cusiddb = App.cusdictDb.FirstOrDefault(x => x.Value == cuspicker1.SelectedItem.ToString()).Key;
                    //vals["customer"] = cusiddb;
    

                    List<OrderLine> or_linelistdb = new List<OrderLine>();


                    foreach (var obj in orderLineList1)
                    {
                        OrderLine or_line = new OrderLine();

                        List<int> tax_id = new List<int>();

                        or_line.product_name = obj.product.ToString();
                        or_line.product_uom_qty = obj.ordered_qty.ToString();
                        or_line.price_subtotal = obj.ordered_qty.ToString();
                        or_line.discount = obj.discount;
                        or_line.multi_discount = obj.multi_discount;

                        or_line.taxesid = obj.tax_id;

                       // or_line.taxes = tax_id;

                        or_linelistdb.Add(or_line);
                    }

                    var orderLineListnew = JsonConvert.SerializeObject(or_linelistdb);


                    string order_date = orDatePicker.Date.ToString();
                  //  DateTime oDate = DateTime.ParseExact(order_date, "yyyy-MM-dd HH:mm tt", null);
                
                    String order_date_string = String.Format("{0:yyyy-MM-dd HH:mm:ss}", orDatePicker.Date);
                    String expiration_date_string = String.Format("{0:yyyy-MM-dd HH:mm:ss}", exDatePicker.Date);


                    var sample = new SalesQuotationDB
                    {
                        //  id = item.id,

                        order_date = order_date_string,
                        expiration_date = expiration_date_string,
                        payment_term = ptpickerstring,
                       // commission_group = cgpickerstring,
                        payment_term_id = selectpaytermid,
                        commission_group_id = selectcomgroupid,
                        user_id = App.userid_db,
                        //customer_id = cusiddb,
                        order_line = orderLineListnew,
                      //  customer = cuspicker1.SelectedItem.ToString(),
                        date_Order = orDatePicker.Date.ToString(),
                        name = "LocalSO",
                        FullState = "  Draft  ",
                        state = "  Draft  ",
                        // state_colour = "#3498db", 
                        state_colour = "#EC04DA",

                        yellowimg_string = "yellowcircle.png",
                       
                     //   ColorCode  = "#3498db"
                    
                        //order_line = item.order_line[0].ToString()
                    };
                    App._connection.Insert(sample);

                                   
                    App._connection.CreateTable<SalesQuotationDB>();
                    try
                    {
                        var details = (from y in App._connection.Table<SalesQuotationDB>() select y).ToList();
                        App.SalesQuotationListDb = details;
                    }
                    catch (Exception ex)
                    {
                        int i = 0;
                    }


                    App.Current.MainPage = new MasterPage(new CrmTabbedPage("tab3"));

                   // await DisplayAlert("Alert", "Created Successfull", "Ok");
                   // await Navigation.PopAllPopupAsync();

                    Loadingalertcall();

                }

            }
        }

        void productentry(object sender, EventArgs args)
        {
            Navigation.PushPopupAsync(new PickerSelectionPage());
        }

       
        private void ol_clicked(object sender, EventArgs e)
        {
           


            airconImg1.IsVisible = false;
            taxlistviewGrid.IsVisible = false;
            //  addtaxGrid.IsVisible = false;

            orderListview.ItemsSource = orderLineList2;
            Dictionary<string, dynamic> xyz = new Dictionary<string, dynamic>();

            if (up.Text == "" || oqty.Text == null || oqty.Text == "" || searchprod.Text == "")
            {

                DisplayAlert("Alert", "Please fill all the fields", "Ok");

                orderLineGrid.IsVisible = false;
                discount_grid.IsVisible = false;
                // orderLineGrid_1.IsVisible = false;
                airconImg.IsVisible = true;
                AddAirCon.IsVisible = true;
                Addtax_line.IsVisible = false;

                orderListview.ItemsSource = orderLineList1;

            }
            else
            {

                //  xyz.Add("product", pd.SelectedItem.ToString());
                xyz.Add("product", searchprod.Text);

                try
                {
                    xyz.Add("ordered_qty", Convert.ToDouble(oqty.Text));
                }

                catch
                {
                    DisplayAlert("Alert", "Please fill all the fields", "Ok");
                }


                try
                {
                    xyz.Add("unit_price", Convert.ToDouble(up.Text));
                }
                catch
                {
                    DisplayAlert("Alert", "Please fill all the fields", "Ok");
                }

                xyz.Add("description", orderline_des.Text);

                xyz.Add("default_code", pro_id.Text);



              //  var brand_id = App.brandList.FirstOrDefault(x => x.name == brand_picker.SelectedItem.ToString()).id;
              //  xyz.Add("product_brand_id", brand_id);

              ////  vals["product_brand_id"] = brand_id;

               //var category_id = App.categoriesList.FirstOrDefault(x => x.display_name == category_picker.SelectedItem.ToString()).id;
                //xyz.Add("categ_id", category_id);
                ////vals["categ_id"] = category_id;

                //vals["default_code"] = pro_id.Text;


                if (taxidList.Count > 0)
                {


                    foreach (var tax_string in taxidList)
                    {
                        string namenew = App.taxList.Where(item => item.Id == tax_string).Select(x => x.Name).SingleOrDefault();

                        taxname = taxname + "," + namenew;
                    }


                    taxname = taxname.Substring(2);
                }

                var brand_id = App.brandList.FirstOrDefault(x => x.name == brand_picker.SelectedItem.ToString()).id;
                //vals["product_brand_id"] = brand_id;

               var category_id = App.categoriesList.FirstOrDefault(x => x.display_name == category_picker.SelectedItem.ToString()).id;
                //vals["categ_id"] = category_id;

                orderLineList1.Add(new OrderLinesList(searchprod.Text, Convert.ToDouble(oqty.Text), Convert.ToDouble(up.Text), taxidList, orderline_des.Text, taxname,dis1.Text,multidis.Text,pro_id.Text,brand_picker.SelectedItem.ToString(),category_picker.SelectedItem.ToString(),brand_id,category_id));
                //  abc.Add(new Dictionary<string, dynamic>(xyz));

                orderListview.ItemsSource = orderLineList1;
                orderListview.RowHeight = 40;

                orderLineGrid.IsVisible = false;
                discount_grid.IsVisible = false;
                // orderLineGrid_1.IsVisible = false;
                airconImg.IsVisible = true;
                AddAirCon.IsVisible = true;

                orderListview.HeightRequest = 40 * orderLineList1.Count;

                searchprod.Text = "";
                oqty.Text = "";
                up.Text = "";
                orderline_des.Text = "";

                Addtax_line.IsVisible = false;


            }
        }



        public void ListviewcloseClicked(object sender, EventArgs e1)
        {
            try
            {
                var args = (TappedEventArgs)e1;
                taxes t2 = args.Parameter as taxes;

                var itemToRemove = App.taxListRemove.Single(r => r.Name == t2.Name);

                App.taxListRemove.Remove(itemToRemove);

               
                taxListView.ItemsSource = null;

             
              //  taxStackLayout.Padding = 0;

                taxListView.ItemsSource = App.taxListRemove;
                taxListView.RowHeight = 35;
                taxListView.HeightRequest = 35 * App.taxListRemove.Count;

            

                if(App.taxListRemove.Count == 0)
                {
                    taxStackLayout.BackgroundColor = Color.White;
                    taxListView.BackgroundColor = Color.White;
                    taxStackLayout.CornerRadius = 0;
                    taxStackLayout.Padding = 0;
                }

              
           
            }
            catch( Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
               
            }

        }

   
        private void ViewCelltax_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            obj.View.BackgroundColor = Color.FromHex("#102b1e");
            //  m_title.TextColor = Color.Red;
        }

    }
}
