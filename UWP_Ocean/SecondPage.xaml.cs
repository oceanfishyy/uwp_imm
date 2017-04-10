using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Windows.UI.Core;

namespace UWP_Ocean
{
    public sealed partial class SecondPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private void GoBackButtonClick(object sender, RoutedEventArgs e)
        {
            var nav = ServiceLocator.Current.GetInstance<INavigationService>();
            nav.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DisplayText.Text = e.Parameter.ToString();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Collapsed;

            base.OnNavigatedTo(e);
        }
    }
}
