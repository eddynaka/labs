using Entity;
using System;
using System.Windows;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBankAccountService _bankAccountService;

        public MainWindow(IBankAccountService bankAccountService)
        {
            InitializeComponent();
            _bankAccountService = bankAccountService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _bankAccountService.Register(Guid.NewGuid().ToString());
        }
    }
}
