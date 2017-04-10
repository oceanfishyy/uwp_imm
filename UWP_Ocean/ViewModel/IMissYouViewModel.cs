using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Ocean.ViewModel
{
    public class IMissYouViewModel: ViewModelBase
    {
        #region 字段

        private ObservableCollection<string> _Images_ItemSource;

        #endregion

        #region 属性

        public ObservableCollection<string> Images_ItemSource
        {
            get { return _Images_ItemSource; }
            set
            {
                if (_Images_ItemSource != value)
                {
                    _Images_ItemSource = value;
                    base.RaisePropertyChanged(nameof(Images_ItemSource));
                }
            }
        }

        #endregion

        #region 事件



        #endregion

        #region 方法

        public IMissYouViewModel(IMainService dataService,
            INavigationService navigationService)
        {
            Images_ItemSource = new ObservableCollection<string>();
            Images_ItemSource.Add(@"D:\20161123IMM\pic\20161229haiwang.png");
        }

        #endregion
    }
}
