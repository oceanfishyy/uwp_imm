using App_Ocean.Common;
using App_Ocean.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Ocean.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public const string ClockPropertyName = "Clock";
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private readonly IMainService _dataService;
        private readonly INavigationService _navigationService;
        private string _clock = "Starting...";
        private int _counter;
        private RelayCommand _incrementCommand;
        private RelayCommand<string> _navigateCommand;
        private string _originalTitle;
        private bool _runClock;
        private RelayCommand _sendMessageCommand;
        private RelayCommand _showDialogCommand;
        private string _welcomeTitle = string.Empty;


        private ObservableCollection<HamburgerMenuGlyphItem> _HamburgerMenuItemSource;

        public ObservableCollection<HamburgerMenuGlyphItem> HamburgerMenuItemSource
        {
            get { return _HamburgerMenuItemSource; }
            set
            {
                if (_HamburgerMenuItemSource != value)
                {
                    _HamburgerMenuItemSource = value;
                    base.RaisePropertyChanged(nameof(HamburgerMenuItemSource));
                }
            }
        }

        public string Clock
        {
            get
            {
                return _clock;
            }
            set
            {
                Set(ClockPropertyName, ref _clock, value);
            }
        }

        public RelayCommand IncrementCommand
        {
            get
            {
                return _incrementCommand
                    ?? (_incrementCommand = new RelayCommand(
                    () =>
                    {
                        WelcomeTitle = string.Format("Counter clicked {0} times", ++_counter);
                    }));
            }
        }

        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return _navigateCommand
                       ?? (
                       _navigateCommand = new RelayCommand<string>(

                           p =>
                           {
                               _navigationService.NavigateTo(ViewModelLocator.ImagePageKey, p);
                           }

                           ));
            }
        }

        public RelayCommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand
                    ?? (_sendMessageCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send(
                            new NotificationMessageAction<string>(
                                "Testing",
                                reply =>
                                {
                                    WelcomeTitle = reply;
                                }));
                    }));
            }
        }

        public RelayCommand ShowDialogCommand
        {
            get
            {
                return _showDialogCommand
                       ?? (_showDialogCommand = new RelayCommand(
                           async () =>
                           {
                               var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                               await dialog.ShowMessage("Hello Universal Application", "it works...");
                           }));
            }
        }

        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public MainViewModel(
            IMainService dataService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            this.InitData();
        }

        private void InitData()
        {
            HamburgerMenuItemSource = new ObservableCollection<HamburgerMenuGlyphItem>();

            HamburgerMenuItemSource.Add(new HamburgerMenuGlyphItem() { Label = "相册", Glyph = "/Assets/Photos/BigFourSummerHeat.jpg" });
        }

        public void RunClock()
        {
            _runClock = true;

            Task.Run(async () =>
            {
                while (_runClock)
                {
                    try
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(() =>
                        {
                            Clock = DateTime.Now.ToString("HH:mm:ss");
                        });

                        await Task.Delay(1000);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
        }

        public void StopClock()
        {
            _runClock = false;
        }

        //private async Task Initialize()
        //{
        //    try
        //    {
        //        var item = await _dataService.GetData();
        //        _originalTitle = item.Title;
        //        WelcomeTitle = item.Title;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Report error here
        //        WelcomeTitle = ex.Message;
        //    }
        //}
    }
}
