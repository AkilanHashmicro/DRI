using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using SalesApp.Pages;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    public partial class NewSalesTargetDetailPage : ContentPage
    {
        List<target_line> saleresult = new List<target_line>();
        public NewSalesTargetDetailPage(SalesTarget item)
        {
            InitializeComponent();
          //  targetListview.ItemsSource = item.target_line;
            name_val.Text = item.name;
            com_val.Text = item.commission_type;


            brandListview.HeightRequest = item.target_line.Count * 35;
            catListview.HeightRequest = item.target_line.Count * 35;
            subcatListview.HeightRequest = item.target_line.Count * 35;
            productListview.HeightRequest = item.target_line.Count * 35;
//Brand 
            var openimgbrandRecognizer = new TapGestureRecognizer();
            openimgbrandRecognizer.Tapped += (s, e) => {

                closeimg_brand.IsVisible = true;
                openimg_brand.IsVisible = false;

                brandGrid.IsVisible = true;
                brandList.IsVisible = true;
            };
            openimg_brand.GestureRecognizers.Add(openimgbrandRecognizer);


            var closeimgbrandRecognizer = new TapGestureRecognizer();
            closeimgbrandRecognizer.Tapped += (s, e) => {

                closeimg_brand.IsVisible = false;
                openimg_brand.IsVisible = true;

                brandGrid.IsVisible = false;
                brandList.IsVisible = false;

            };
            closeimg_brand.GestureRecognizers.Add(closeimgbrandRecognizer);

 // Category

            var openimgcatRecognizer = new TapGestureRecognizer();
            openimgcatRecognizer.Tapped += (s, e) => {

                closeimg_cat.IsVisible = true;
                openimg_cat.IsVisible = false;

                catGrid.IsVisible = true;
                catList.IsVisible = true;
            };
            openimg_cat.GestureRecognizers.Add(openimgcatRecognizer);


            var closeimgcatRecognizer = new TapGestureRecognizer();
            closeimgcatRecognizer.Tapped += (s, e) => {

                closeimg_cat.IsVisible = false;
                openimg_cat.IsVisible = true;

                catGrid.IsVisible = false;
                catList.IsVisible = false;

            };
            closeimg_cat.GestureRecognizers.Add(closeimgcatRecognizer);

 // Sub Category

            var openimgsubcatRecognizer = new TapGestureRecognizer();
            openimgsubcatRecognizer.Tapped += (s, e) => {

                closeimg_subcat.IsVisible = true;
                openimg_subcat.IsVisible = false;

                subcatGrid.IsVisible = true;
                subcatList.IsVisible = true;
            };
            openimg_subcat.GestureRecognizers.Add(openimgsubcatRecognizer);


            var closeimgsubcatRecognizer = new TapGestureRecognizer();
            closeimgsubcatRecognizer.Tapped += (s, e) => {

                closeimg_subcat.IsVisible = false;
                openimg_subcat.IsVisible = true;

                subcatGrid.IsVisible = false;
                subcatList.IsVisible = false;

            };
            closeimg_subcat.GestureRecognizers.Add(closeimgsubcatRecognizer);

            // Sub Category

            var openimgproductRecognizer = new TapGestureRecognizer();
            openimgproductRecognizer.Tapped += (s, e) => {

                closeimg_product.IsVisible = true;
                openimg_product.IsVisible = false;

                productGrid.IsVisible = true;
                productList.IsVisible = true;
            };
            openimg_product.GestureRecognizers.Add(openimgproductRecognizer);


            var closeimgproducttRecognizer = new TapGestureRecognizer();
            closeimgproducttRecognizer.Tapped += (s, e) => {

                closeimg_product.IsVisible = false;
                openimg_product.IsVisible = true;

                productGrid.IsVisible = false;
                productList.IsVisible = false;

            };
            closeimg_product.GestureRecognizers.Add(closeimgproducttRecognizer);


        }


        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell obj = (ViewCell)sender;
            obj.View.BackgroundColor = Color.FromHex("#FFFFFF");
        }

    }
}
