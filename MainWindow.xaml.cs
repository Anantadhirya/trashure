using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using trashure.pages;

namespace trashure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigate(Navigation.signin);
        }
        public enum Navigation
        {
            back,
            home,
            dashboard,
            signin,
            register,
            tambahSampah,
            keteranganSampah,
            editSampah,
            editProfil,
        }
        public void Navigate(Navigation target)
        {
            switch (target)
            {
                case Navigation.back:
                    if(mainFrame.CanGoBack) mainFrame.GoBack();
                    break;
                case Navigation.home:
                    mainFrame.Navigate(new HomePage());
                    break;
                case Navigation.dashboard:
                    mainFrame.Navigate(new DashboardPage());
                    break;
                case Navigation.signin:
                    mainFrame.Navigate(new SignInPage());
                    break;
                case Navigation.register:
                    mainFrame.Navigate(new RegisterPage());
                    break;
                case Navigation.tambahSampah:
                    mainFrame.Navigate(new TambahSampahPage());
                    break;
            }
        }
    }
}
