﻿using System;
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
    /// Interaction logic for KeteranganSampahPage.xaml
    /// </summary>
    public partial class KeteranganSampahPage : Page
    {
        Item item;
        Action<MainWindow.Navigation> Navigate;
        public KeteranganSampahPage(Item item, Action<MainWindow.Navigation> Navigate)
        {
            InitializeComponent();
            this.item = item;
            this.Navigate = Navigate;
        }

        private void NavigateSignIn(object sender, RoutedEventArgs e)
        {

        }

        private void onKontak(object sender, RoutedEventArgs e)
        {

        }

        private void ClickEditBarang(object sender, RoutedEventArgs e)
        {

        }

        private void onChangeStatus(object sender, RoutedEventArgs e)
        {

        }
    }
}
