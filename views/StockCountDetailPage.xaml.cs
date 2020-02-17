using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    public partial class StockCountDetailPage : PopupPage
    {
        List<StockWareHouseList> datalist = new List<StockWareHouseList>();

        public StockCountDetailPage(List<StockWareHouseList> objdatalist)
        {
            InitializeComponent();

            stockcountDetail.ItemsSource = objdatalist;

            var backRecognizer = new TapGestureRecognizer();
            backRecognizer.Tapped += (s, e) => {

                Navigation.PopAllPopupAsync();

            };
            backImg.GestureRecognizers.Add(backRecognizer);

        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAllPopupAsync();
            return true;
        }


        //private void ViewCell_Tapped(object sender, EventArgs e)
        //{
        //    ViewCell obj = (ViewCell)sender;
        //    obj.View.BackgroundColor = Color.FromHex("363E4B");    // Color.FromHex("363E4B");   // f0ebeb
        //}

    }


}