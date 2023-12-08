using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCAD.Common.Models
{
    /// <summary>
    /// 系统导航菜单实体类
    /// </summary>
    public class MenuBar : BindableBase
    {
        private string icon;
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { icon = value; RaisePropertyChanged(); }
        }
        private string title;
        /// <summary>
        /// 菜单标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }
        private string namrSpace;
        /// <summary>
        /// 菜单命名空间
        /// </summary>
        public string NameSpace
        {
            get { return namrSpace; }
            set { namrSpace = value; RaisePropertyChanged(); }
        }
    }
}
