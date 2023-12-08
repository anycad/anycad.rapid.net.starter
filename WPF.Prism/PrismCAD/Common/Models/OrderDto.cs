using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCAD.Common.Models
{
    public class OrderDto : BaseDto
    {
        #region Private Field

        private string batchNumber;
        private string workpieceName;
        private string material;
        private decimal length;
        private decimal width;
        private string lockset;
        private string handle;
        private string hinged;
        private int amount;
        private Dictionary<string, object> alternateStrDictionary;

        #endregion

        #region Public Property
        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNumber
        {
            get { return batchNumber; }
            set { batchNumber = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 工件名称
        /// </summary>
        public string WorkpieceName
        {
            get { return workpieceName; }
            set { workpieceName = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 材质
        /// </summary>
        public string Material
        {
            get { return material; }
            set { material = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 长度
        /// </summary>
        public decimal Length
        {
            get { return length; }
            set { length = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 宽度
        /// </summary>
        public decimal Width
        {
            get { return width; }
            set { width = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 锁具
        /// </summary>
        public string Lockset
        {
            get { return lockset; }
            set { lockset = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 拉手,把手
        /// </summary>
        public string Handle
        {
            get { return handle; }
            set { handle = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 铰链
        /// </summary>
        public string Hinged
        {
            get { return hinged; }
            set { hinged = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 总数
        /// </summary>
        public int Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 备用字段字典
        /// </summary>
        public Dictionary<string,object> AlternateStrDictionary
        {
            get { return alternateStrDictionary; }
            set { alternateStrDictionary = value; RaisePropertyChanged(); }
        }
        #endregion

    }
}
