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
	public partial class Grid : ContentPage
	{
        Processor processor;
   		public Grid ()
		{
			InitializeComponent ();

            processor = new Processor();
        }

        public void NumberHandler(object sender, ClickedEventArgs e)
        {
            Button button = (Button)sender;
            ExpressionText.Text += processor.CheckExpression(button.Text, ExpressionText.Text);
        }

        public void OperationHandler(object sender, ClickedEventArgs e)
        {
            Button button = (Button)sender;
            string operat = button.Text.Trim();
            ExpressionText.Text = processor.GetResult(operat, ExpressionText.Text);
        }
    }
}