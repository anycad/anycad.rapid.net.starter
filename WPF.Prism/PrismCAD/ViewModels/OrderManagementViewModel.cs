using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCAD.ViewModels
{
    public class OrderManagementViewModel
    {
        private readonly IDialogService _dialogService;

        public OrderManagementViewModel(IDialogService _dialogService)
        {
            this._dialogService = _dialogService;

            OpenCommand = new DelegateCommand<string>(Open);

        }

      
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set {  _title = value; }
        }
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public DelegateCommand<string> OpenCommand { get; set; }

        private void Open(string obj)
        {
            _dialogService.ShowDialog(obj);
        }
    }
}
