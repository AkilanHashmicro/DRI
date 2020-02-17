using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalesApp.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OppurtunityDetailPage : PopupPage
    {
        public OppurtunityDetailPage()
        {
            InitializeComponent();

            var backImgRecognizer = new TapGestureRecognizer();
            backImgRecognizer.Tapped += (s, e) => {
                Navigation.PopAllPopupAsync();
            };
            backImg.GestureRecognizers.Add(backImgRecognizer);

            var dropImgRecognizer = new TapGestureRecognizer();
            dropImgRecognizer.Tapped += (s, e) => {
                cuspicker.Focus();
               
            };
            cusdropimg.GestureRecognizers.Add(dropImgRecognizer);

            var salImgRecognizer = new TapGestureRecognizer();
            salImgRecognizer.Tapped += (s, e) => {

                salpicker.Focus();
            };
            saldropimg.GestureRecognizers.Add(salImgRecognizer);

            var pickImgRecognizer = new TapGestureRecognizer();
            salImgRecognizer.Tapped += (s, e) => {

                salpicker.Focus();
            };
            saldropimg.GestureRecognizers.Add(salImgRecognizer);


            var tagImgRecognizer = new TapGestureRecognizer();
            tagImgRecognizer.Tapped += (s, e) => {

                tagpicker.Focus();
            };
            tagdropimg.GestureRecognizers.Add(tagImgRecognizer);

            var mailRecognizer = new TapGestureRecognizer();
            mailRecognizer.Tapped += (s, e) => {

                emailpicker.Focus();
            };
            maildropimg.GestureRecognizers.Add(mailRecognizer);

        }

    }
}