using DebtBook.Views;
using Prism.Ioc;
using System.Windows;
using DebtBook.Models;
using DebtBook.ViewModels;

namespace DebtBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddDebtor,AddDebtorViewModel>();
        }

        public Debtor GDebtor { get; set; }

    }
}
