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

namespace trashure.pages
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        Action<MainWindow.Navigation> Navigate;
        public SignUpPage(Action<MainWindow.Navigation> Navigate)
        {
            InitializeComponent();
            this.Navigate = Navigate;
        }

        private void signupbutton_onClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void onSignIn(object sender, MouseButtonEventArgs e)
        {
            Navigate(MainWindow.Navigation.signin);
        }
    }
}
