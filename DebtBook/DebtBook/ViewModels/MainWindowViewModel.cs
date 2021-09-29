using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace DebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Debtor> debtors;
        private IDialogService _dialogService;

        public ObservableCollection<Debtor> Debtors
        {
            get => debtors;
            set => SetProperty(ref debtors, value);

        }
        private string _title = "The Debt Book";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            Debtors = new ObservableCollection<Debtor>();
            Debtors.Add(new Debtor(new Debt(new DateTime(2017,09,28),100),"Baren"));

        }

        private DelegateCommand _showCloseAddDebtor;

        public DelegateCommand ShowCloseAddDebtor =>
            _showCloseAddDebtor ?? (_showCloseAddDebtor = new DelegateCommand(ExecuteShowCloseAddDebtor));

        void ExecuteShowCloseAddDebtor()
        {
            Debtor d = new Debtor();

            _dialogService.ShowDialog("Add Debtor", new DialogParameters($"debtor={d}"), r =>
            {
                if (r.Result == ButtonResult.None) {}
                else if (r.Result == ButtonResult.OK)
                    Debtors.Add(d);
                else if(r.Result == ButtonResult.Cancel) {}
                else
                {
                }
            });

        }
    }
}
