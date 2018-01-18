using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FacturaUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

	    private async void BtnRegister_OnClicked(object sender, EventArgs e)
	    {
	        var register = new Register();
	        await Navigation.PushAsync(register);
	    }

	    private async void BtnLogin_OnClicked(object sender, EventArgs e)
	    {
	        try
	        {
	            var mainPage = new MainPage();
	            await Navigation.PushAsync(mainPage);
	        }
	        catch (Exception ex)
	        {
	            Console.WriteLine(ex.Message);
	        }
	    }
	}
}