using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using UWP_Ocean.ViewModel;

namespace UWP_Ocean
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;

            //Loaded += (s, e) =>
            //{
            //    Vm.RunClock();
            //};

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Collapsed;
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            //if (Frame.CanGoBack)
            //{
            //    e.Handled = true;
            //    Frame.GoBack();
            //}
            ViewModelLocator.SERVICE.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Collapsed;
        }
        //protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        //{
        //    Vm.StopClock();
        //    base.OnNavigatingFrom(e);
        //}
    }
}
