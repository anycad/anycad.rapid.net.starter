using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCAD.Common.Models
{
    /// <summary>
    /// 通用实体基类
    /// </summary>
    public class BaseDto : BindableBase
    {
        private int id;
        private DateTime createdDate;
        private DateTime updateDate;
        /// <summary>
        /// ID编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }

    }
}
