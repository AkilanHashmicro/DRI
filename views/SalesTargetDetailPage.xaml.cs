using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using SalesApp.Pages;
using Xamarin.Forms;
using static SalesApp.models.CRMModel;

namespace SalesApp.views
{
    public partial class SalesTargetDetailPage : ContentPage
    {
        public SalesTargetDetailPage(SalesTarget item)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //tar_name.Text = item.name;
            //tar_type.Text = item.target_type;

            //orderListview.ItemsSource = item.brand;
            //ProductCatListview.ItemsSource = item.category;

            var backImgRecognizer = new TapGestureRecognizer();
            backImgRecognizer.Tapped += async (s, e) =>
            {
                // handle the tap              
                var currentpage = new LoadingAlert();
                await PopupNavigation.PushAsync(currentpage);
                Application.Current.MainPage = new MasterPage(new SalesTargetPage());
                //  orderListview.ItemsSource = null;
                Loadingalertcall();

            };
            backImg.GestureRecognizers.Add(backImgRecognizer);
        }

        async void Loadingalertcall()
        {
            await PopupNavigation.PopAllAsync();
        }


        private void Tab1Clicked(object sender, EventArgs ea)
        {
            tab1stack.BackgroundColor = Color.Silver;
            tab1.BackgroundColor = Color.Silver;
            tab2stack.BackgroundColor = Color.White;
            tab2.BackgroundColor = Color.White;
            tab2frame.BackgroundColor = Color.Gray;
            tab2borderstack.BackgroundColor = Color.White;
            orderLineList.IsVisible = true;
            OtherInfoStack1.IsVisible = false;
            ProductCatList.IsVisible = false;
            // OtherInfoStack2.IsVisible = false;
            tab1frame.BackgroundColor = Color.Silver;
            tab1borderstack.BackgroundColor = Color.Silver;
            OrderLineList1.IsVisible = true;
        }

        private void Tab2Clicked(object sender, EventArgs ea)
        {
            tab2stack.BackgroundColor = Color.Silver;
            tab2.BackgroundColor = Color.Silver;
            tab1stack.BackgroundColor = Color.White;
            tab1.BackgroundColor = Color.White;
            tab2borderstack.BackgroundColor = Color.Silver;
            tab2frame.BackgroundColor = Color.Silver;
            orderLineList.IsVisible = false;
            OtherInfoStack1.IsVisible = true;

            ProductCatList.IsVisible = true;
            //  OtherInfoStack2.IsVisible = true;
            tab1frame.BackgroundColor = Color.Gray;
            tab1borderstack.BackgroundColor = Color.White;
            OrderLineList1.IsVisible = false;

        }

    }
}
