using App_Ocean.Services;
using App_Ocean.ViewModels;
using App_Ocean.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace App_Ocean.Common
{
    public class ViewModelLocator
    {
        public const string ImagePageKey = "ImagePage";
        public static CNavigationService SERVICE;


        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SERVICE = new CNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => SERVICE);
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SERVICE.Configure(ImagePageKey, typeof(IMissYouPage));

            //SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) =>
            //{
            //    SERVICE.GoBack();
            //};

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IMainService, MainService>();
            }
            else
            {
                SimpleIoc.Default.Register<IMainService, MainService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IMissYouViewModel>();

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public IMissYouViewModel IMissYou => ServiceLocator.Current.GetInstance<IMissYouViewModel>();
    }
}
