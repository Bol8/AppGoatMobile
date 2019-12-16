using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppGoatMobile.Annotations;
using AppGoatMobile.Models;

namespace AppGoatMobile.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool _rememberCredentials;
        private string _userName;
        private string _password;

        public LoginViewModel()
        {
            UserName = "Oscar";
            RememberCredentials = true;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserName)));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }

        }

        public bool RememberCredentials
        {
            get => _rememberCredentials;
            set
            {
                _rememberCredentials = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RememberCredentials)));
            }
        }




        public void Login()
        {
           

            var user = new User(UserName, Password);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}