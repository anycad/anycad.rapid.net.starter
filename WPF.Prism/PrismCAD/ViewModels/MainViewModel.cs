using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismCAD.Extensions;
using PrismCAD.Common.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

namespace PrismCAD.ViewModels
{
    public class MainViewModel : BindableBase
    {


        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            MeunBars = new ObservableCollection<MenuBar>();
            CreatedMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);//实例化导航委托

            GoBackCommand = new DelegateCommand(() =>//实例化返回一步委托
            {
                if (_navigationJournal.CanGoBack && _navigationJournal != null)
                {
                    _navigationJournal.GoBack();
                }
            });
            GoForwardCommand = new DelegateCommand(() =>//实例化向前一步委托
            {
                if (_navigationJournal.CanGoForward && _navigationJournal != null)
                {
                    _navigationJournal.GoForward();
                }
            });
        }

        private void Navigate(MenuBar obj)//导航方法
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
            {
                return;
            }
            _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, callback =>
            {
                _navigationJournal = callback.Context.NavigationService.Journal;
            });//导航调用的具体方法,按传入的Menubar的NameSpace,再用一个回调方法记录导航日志
        }
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }//导航委托
        public DelegateCommand GoBackCommand { get; private set; }//返回上一步委托
        public DelegateCommand GoForwardCommand { get; private set; }//向前一步委托
        private ObservableCollection<MenuBar> meunBars;//菜单集合
        private readonly IRegionManager _regionManager;//注入区域管理
        private IRegionNavigationJournal _navigationJournal;//注入导航日志

        public ObservableCollection<MenuBar> MeunBars
        {
            get { return meunBars; }
            set { meunBars = value; RaisePropertyChanged(); }
        }

        private void CreatedMenuBar()//创建左侧菜单Items
        {
            MeunBars.Clear();
            MeunBars.Add(new MenuBar() { Icon = "Home", Title = "订单导入页面", NameSpace = "OrderManagementView" });
            MeunBars.Add(new MenuBar() { Icon = "Home", Title = "工艺编辑", NameSpace = "ProcessDesignView" });
        }

    }
}
