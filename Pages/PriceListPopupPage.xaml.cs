using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalesApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PriceListPopupPage : PopupPage
	{
		public PriceListPopupPage ()
		{
			InitializeComponent ();
		}
	}
}