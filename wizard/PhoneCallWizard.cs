using Plugin.Messaging;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SalesApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SalesApp.wizard
{   

    class PhoneCallWizard : PopupPage
    {
        public PhoneCallWizard()
        {
            
            BackgroundColor = Color.FromHex("#414141");

            Label alertTitle = new Label
            {
                TextColor = Color.Black,
                Text = "Alert !",
                BackgroundColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            // CRM Lead             
            Label appointmentDetailsLabel = new Label
            {
                TextColor = Color.Gray,
                Text = "Phone Number not updated for this customer.Please contact admin.",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),                
                HorizontalOptions = LayoutOptions.FillAndExpand,                
            };
            

            Button btnBackAction = new Button() { Text = "Back" };
            btnBackAction.Clicked += BtnBackAction;
            btnBackAction.BackgroundColor = Color.FromHex("#414141");
            btnBackAction.TextColor = Color.White;
            btnBackAction.WidthRequest = 60;

            StackLayout allAppointmentLayout = new StackLayout
            {
                Margin = 0,
                Padding = 10
            };

            Frame frame = new Frame { Margin= new Thickness(20,150) , BackgroundColor = Color.White, CornerRadius = 20 };

            allAppointmentLayout.Children.Add(alertTitle);
            allAppointmentLayout.Children.Add(appointmentDetailsLabel);
            allAppointmentLayout.Children.Add(new BoxView { HeightRequest = 20, BackgroundColor = Color.Transparent });
            allAppointmentLayout.Children.Add(btnBackAction);
            allAppointmentLayout.Children.Add(new BoxView { HeightRequest = 20, BackgroundColor = Color.Transparent });

            frame.Content = allAppointmentLayout;

            //allAppointmentLayout.Children.Add(appointmentDetailsLabel);
            //allAppointmentLayout.Children.Add(new BoxView { HeightRequest=20,BackgroundColor=Color.Transparent});
            var scrollView = new ScrollView { Content = frame };
            Content = scrollView;

        }

        private void BtnBackAction(object sender, EventArgs eventArgs)
        {
            PopupNavigation.PopAsync();
        }
    }
}
