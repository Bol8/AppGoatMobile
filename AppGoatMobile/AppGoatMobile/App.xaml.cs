using AppGoatMobile.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppGoatMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new InitialPage();
        }

        protected override void OnStart()
        {
            #region Handle PushNotificationReceived Event

            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += PushOnPushNotificationReceived;
            }

            #endregion

            #region Start the device

            AppCenter.Start($"android=1806a5f4-1633-478a-a20c-b4bd9122b51d;",
                typeof(Push));

            #endregion

            #region "Save" VS App Center Install Id

            AppCenter.GetInstallIdAsync().ContinueWith(installId =>
            {
                System.Diagnostics.Debug.WriteLine("*********************************************************");
                System.Diagnostics.Debug.WriteLine($"VS App Center InstallId={installId.Result}");
                System.Diagnostics.Debug.WriteLine("*********************************************************");
            });

            #endregion
        }

        private void PushOnPushNotificationReceived(object sender, PushNotificationReceivedEventArgs e)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    Current.MainPage.DisplayAlert(e.Title, e.Message, "OK");
                });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
