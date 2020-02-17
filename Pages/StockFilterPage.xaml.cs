using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using SalesApp.views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockFilterPage : PopupPage
    {
        public StockFilterPage()
        {
            InitializeComponent();

            //Ware-Month

            warefillimg.IsVisible = true;
           App.StockFilterWarehouse = "Ware";


            if (App.StockFilterWarehouse == "Ware" && App.StockFilterProduct == "")
            {
                warefillimg.IsVisible = true;
                wareimg.IsVisible = false;
                productfillimg.IsVisible = false;
              //  datefillimg.IsVisible = false;
            }

            else if (App.StockFilterProduct == "Product" && App.StockFilterWarehouse == "")
            {
                warefillimg.IsVisible = false;
                productfillimg.IsVisible = false;
                productimg.IsVisible = false;
              //  datefillimg.IsVisible = true;
            }

            else if (App.StockFilterProduct == "Product" && App.StockFilterWarehouse == "Ware")
            {
               // warefillimg.IsVisible = false;
                productfillimg.IsVisible = true;
                warefillimg.IsVisible = true;
                //  datefillimg.IsVisible = true;
            }

            var daysfillimgRecognizer = new TapGestureRecognizer();
            daysfillimgRecognizer.Tapped += (s, e) => {
              //  warefillimg.IsVisible = false;
               
                productfillimg.IsVisible = true;
                productimg.IsVisible = false;
                mainlayout.HeightRequest = 150;
               
               
                wareimg.IsVisible = true;
               


                App.StockFilterProduct = "Product";

              
                //  MessagingCenter.Send<string, string>("MyApp", "NotifyMsg", filterstring);

            };
            productimg.GestureRecognizers.Add(daysfillimgRecognizer);

            var monthfillimgRecognizer = new TapGestureRecognizer();
            monthfillimgRecognizer.Tapped += (s, e) => {
              //  productfillimg.IsVisible = false;

                warefillimg.IsVisible = true;
                wareimg.IsVisible = false;
                mainlayout.HeightRequest = 150;
               
                productimg.IsVisible = true;
            
                App.StockFilterWarehouse = "Ware";

                //  MessagingCenter.Send<string, string>("MyApp", "NotifyMsg", filterstring);

            };
            wareimg.GestureRecognizers.Add(monthfillimgRecognizer);


            var productfillimgRecognizer = new TapGestureRecognizer();
            productfillimgRecognizer.Tapped += (s, e) => {
                productfillimg.IsVisible = false;

               // warefillimg.IsVisible = true;
               // wareimg.IsVisible = false;
                mainlayout.HeightRequest = 150;

               // productimg.IsVisible = true;

                if(App.StockFilterProduct == "Product" )
                {
                    App.StockFilterProduct = "";
                    productfillimg.IsVisible = false;
                    productimg.IsVisible = true;
                }

                else if (App.StockFilterProduct == "")
                {
                    App.StockFilterProduct = "Product";
                    productfillimg.IsVisible = true;
                    productimg.IsVisible = false;
                }
               

                //  MessagingCenter.Send<string, string>("MyApp", "NotifyMsg", filterstring);

            };
            productfillimg.GestureRecognizers.Add(productfillimgRecognizer);


            var warefillimgRecognizer = new TapGestureRecognizer();
            warefillimgRecognizer.Tapped += (s, e) => {
               
                if (App.StockFilterWarehouse == "Ware")
                {
                    App.StockFilterWarehouse = "";
                    warefillimg.IsVisible = false;
                    wareimg.IsVisible = true;
                }

                else if (App.StockFilterWarehouse == "")
                {
                    App.StockFilterWarehouse = "Ware";
                    warefillimg.IsVisible = true;
                    wareimg.IsVisible = false;
                }

                //  MessagingCenter.Send<string, string>("MyApp", "NotifyMsg", filterstring);

            };
            warefillimg.GestureRecognizers.Add(warefillimgRecognizer);


        }


        void cancel_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAllPopupAsync();
            App.StockFilterWarehouse = "";
            App.StockFilterProduct = "";
           
        }

        void save_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAllPopupAsync();
          //  StockFilterWarehouse
            App.Current.MainPage = new MasterPage(new StockCountPage());
        }
    }
}
