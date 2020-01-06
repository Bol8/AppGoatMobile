using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGoatMobile.Models;
using AppGoatMobile.Services;
using AppGoatMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGoatMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _loginViewModel;

		public LoginPage ()
		{
			InitializeComponent();
            BindingContext = _loginViewModel = new LoginViewModel();


        }

        private void BtnSigIn_OnClicked(object sender, EventArgs e)
        {
            try
            {
              //  _loginViewModel.Login();
                
                //_loginViewModel.Login();

                //var user = new User(txtEmail.Text, txtPassword.Text);
                //if (user.HasValidCredentials())
                //{
                //    CacheProvider.Set("AppGoatUser",user, new DateTimeOffset(new DateTime(2020)));
                //    Application.Current.MainPage = new MainPage();
                //}
                //else
                //{
                //    DisplayAlert("Warning", "Invalid Credentials !!!", "Accept");
                //}
            }
            catch (Exception exception)
            {
                DisplayAlert("Error", "Error...", "Aceptar");
            }
        }

      
    }
}