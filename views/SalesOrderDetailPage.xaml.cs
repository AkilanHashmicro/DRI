using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalesApp.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalesOrderDetailPage : ContentPage
    {
        public SalesOrderDetailPage(SalesModel item)
        {
            InitializeComponent();
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Activated_1(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Activated_2(object sender, EventArgs e)
        {

        }
    }
}