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
    public partial class CRMLeadEditAddressPage : ContentPage
    {
        public CRMLeadEditAddressPage()
        {
            InitializeComponent();
        }

        private void check1_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if (check1.Checked == true)
            {
                check2.Checked = false;
            }

            else
            {
                check2.Checked = true;
            }

            addr.IsVisible = true;
            webs.IsVisible = true;
            tags.IsVisible = true;
            avail.IsVisible = true;

            phone.IsVisible = false;
            vgn.IsVisible = false;
            mob.IsVisible = false;
            fax.IsVisible = false;
            mail.IsVisible = false;
            lang.IsVisible = false;
        }

        private void check2_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if (check2.Checked == true)
            {
                check1.Checked = false;
            }

            else
            {
                check1.Checked = true;
            }

            addr.IsVisible = false;
            webs.IsVisible = false;
            tags.IsVisible = false;
            avail.IsVisible = false;

            phone.IsVisible = true;
            vgn.IsVisible = true;
            mob.IsVisible = true;
            fax.IsVisible = true;
            mail.IsVisible = true;
            lang.IsVisible = true;
        }
    }
}