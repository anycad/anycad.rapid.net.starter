using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;
using PrismCAD.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCAD.ViewModels
{
    public class CreateDxfViewModel:IDialogAware
    {
        private readonly IEventAggregator aggregator;

        public CreateDxfViewModel(IEventAggregator aggregator)//构造函数注入IEventAggregator aggregator
        {
            CancelCommand = new DelegateCommand(Cancel);
            SaveCommand = new DelegateCommand(Save);
            this.aggregator = aggregator;

        }

        public void Save()
        {
            OnDialogClosed();//保存时执行在弹窗关闭时的一个方法
            aggregator.GetEvent<MessageEvent>().Prune();//清楚Cancel发布的消息,不清除会消息会叠加
        }

        public void Cancel()
        {
            aggregator.GetEvent<MessageEvent>().Publish("这是由Prism从ViewA发布的一个消息");//通过获取MessageEvent事件发布一个消息
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));

        }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
