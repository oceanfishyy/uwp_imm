using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Ocean.ViewModels
{
    public class IMissYouViewModel : ViewModelBase
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

        public IMissYouViewModel()
        {
            Images_ItemSource = new ObservableCollection<string>();
            Images_ItemSource.Add(@"http://c.hiphotos.baidu.com/zhidao/pic/item/c83d70cf3bc79f3da25bb440b8a1cd11728b2903.jpg");
        }

        #endregion
    }
}
