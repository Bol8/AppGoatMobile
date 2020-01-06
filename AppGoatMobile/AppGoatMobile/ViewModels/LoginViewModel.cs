using AppGoatMobile.Annotations;
using AppGoatMobile.Models;
using AppGoatMobile.Services;
using AppGoatMobile.Views;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGoatMobile.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private const string USER_DATA_CACHE_KEY = "AppGoatUserCredentials";

        private bool _rememberCredentials;
        private string _userName;
        private string _password;

        private AppService _appService;


        public LoginViewModel()
        {
            _appService = new AppService();
            LoadCacheUserData();
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

        public ICommand Login
        {
            get
            {
                return new Command(async () =>
                {
                    await _appService.LoginAsync(_userName, _password);

                    if (_rememberCredentials)
                    {
                        SaveCacheUserData();
                    }
                    else
                    {
                        CacheProvider.Remove(USER_DATA_CACHE_KEY);
                    }

                    Application.Current.MainPage = new MainPage();
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadCacheUserData()
        {
            var credentialsDataCache = CacheProvider.Get<CredentialsDataCache>(USER_DATA_CACHE_KEY);
            if (credentialsDataCache == null) return;

            _userName = credentialsDataCache.UserName;
            _password = credentialsDataCache.Password;
            _rememberCredentials = credentialsDataCache.RememberCredentials;
        }

        private void SaveCacheUserData()
        {
            var credentials = new CredentialsDataCache
            {
                UserName = _userName,
                Password = _password,
                RememberCredentials = _rememberCredentials
            };

            CacheProvider.Set(USER_DATA_CACHE_KEY, credentials, new DateTimeOffset(new DateTime(2020)));
        }
    }
}