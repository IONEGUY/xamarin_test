using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StackLayout : ContentPage
	{
		public StackLayout ()
		{
			InitializeComponent ();
		}

        public void NumberHandler(object sender, ClickedEventArgs e)
        {
            //Button button = (Button)sender;
            //if (button.Text == "0" && button.Text.Length == 1)
            //{
            //    ExpressionText.Text += "0,";
            //}
            //else
            //{
            //    ExpressionText.Text += ((Button)sender).Text;
            //}
        }
        public void OperationHandler(object sender, ClickedEventArgs e)
        {

        }
    }
}