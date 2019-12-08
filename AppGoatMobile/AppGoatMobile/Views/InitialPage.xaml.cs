using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGoatMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InitialPage : ContentPage
	{
        private int taps = 0;
        private CancellationTokenSource tokenSource2;

        public InitialPage ()
		{
			InitializeComponent();
            tokenSource2 = new CancellationTokenSource();
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            taps++;

            if (taps == 1)
            {
                InitTimer();
            }
            else if (taps == 10)
            {
                tokenSource2.Cancel();
               // Application.Current.MainPage = new LoginPage();
            }
        }

        private async void InitTimer()
        {
            await Task.Run(async () =>
            {
                var time = 0;
                do
                {
                    time++;
                    await Task.Delay(1000);
                } while (time < 10);

                taps = 0;

            }, tokenSource2.Token);
        }
    }
}