using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Windows;
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

        private Debtor _currentDebtor;

        public Debtor CurrentDebtor
        {
            set => _currentDebtor = value;
            get => _currentDebtor;
        }

        private string _title = "Prism Application";
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
            

            _dialogService.ShowDialog("AddDebtor", null, r =>
            {
                if (r.Result == ButtonResult.None) {}
                else if (r.Result == ButtonResult.OK)
                    Debtors.Add(((App)Application.Current).GDebtor);
                else if(r.Result == ButtonResult.Cancel) {}
                
            });

        }
    }
}
