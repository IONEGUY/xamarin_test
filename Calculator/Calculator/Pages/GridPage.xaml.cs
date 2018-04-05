using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GridPage : ContentPage
	{
	    private readonly Processor _processor = new Processor();
   		public GridPage()
		{
			InitializeComponent ();
        }

        public void NumberHandler(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            ExpressionText.Text += _processor.CheckExpression(button.Text, ExpressionText.Text);
        }

        public void OperationHandler(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            var operat = button.Text.Trim();
            ExpressionText.Text = _processor.GetResult(operat, ExpressionText.Text);
        }
    }
}