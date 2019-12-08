using Xamarin.Forms;

namespace AppGoatMobile.Models
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage()
        {
            BarBackgroundColor = Color.FromHex("#3f4041");
        }

        public CustomNavigationPage(Page root)
            : base(root)
        {
            BarBackgroundColor = Color.FromHex("#3f4041");
        }
    }
}