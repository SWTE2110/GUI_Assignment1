using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using DebtBook.Models;
using Prism.Services.Dialogs;

namespace DebtBook.ViewModels
{
    public class AddDebtorViewModel : BindableBase, IDialogAware
    {
        private Debtor _debtor;

        public Debtor Debtor
        {
            get => _debtor;
            set => SetProperty(ref _debtor, value);
        }

        private string _title = "Add Debtor";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
        _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        protected virtual void CloseDialog(string par)
        {
            ButtonResult result = ButtonResult.None;
            if (par?.ToLower() == "true")
                result = ButtonResult.OK;
            else if (par?.ToLower() == "false")
                result = ButtonResult.Cancel;
            RequestClose?.Invoke(new DialogResult(result));

        }

        public event Action<IDialogResult> RequestClose;

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed(){}

        public virtual void OnDialogOpened(IDialogParameters par)
        {
            Debtor = par.GetValue<Debtor>("hm?");
        }

        public AddDebtorViewModel()
        {

        }
    }
}
