using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGoatMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGoatMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent();
            BindingContext = this;
        }

        private void BtnSigIn_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var user = new User(txtEmail.Text, txtPassword.Text);
                if (user.HasValidCredentials())
                {
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    DisplayAlert("Warning", "Invalid Credentials !!!", "Accept");
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("Error", "Error...", "Aceptar");
            }
        }
    }
}