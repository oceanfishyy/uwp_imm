using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UWP_Ocean.Common;
using UWP_Ocean.Model;
using UWP_Ocean.Pages;
using Windows.UI.Core;

namespace UWP_Ocean.ViewModel
{
    public class ViewModelLocator
    {
        public const string SecondPageKey = "SecondPage";
        public const string ImagePageKey = "ImagePage";
        public const string IMissYouKey = "IMissYouPage";
        public static CNavigationService SERVICE;


        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SERVICE = new CNavigationService();
            SERVICE.Configure(SecondPageKey, typeof(SecondPage));
            SERVICE.Configure(ImagePageKey, typeof(BlankPage1));
            SERVICE.Configure(IMissYouKey, typeof(IMissYouPage));
            SimpleIoc.Default.Register<INavigationService>(() => SERVICE);

            SimpleIoc.Default.Register<IDialogService, DialogService>();

            //SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) => {
                //nav.GoBack();
            //};

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
    }
}
