using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskOne
{
    /// <summary>
    /// Interaction logic for IntialPage.xaml
    /// </summary>
    public partial class IntialPage : Window
    {
        public IntialPage()
        {
            InitializeComponent();
        }

        private void btnSearchCallNumbers_Click(object sender, RoutedEventArgs e)
        {

            // MessageBox.Show("Finding for call number will be coming soon :)" + "\n" + "Expected date: 21st Novemebr 2022 " + "\n");
            FindingCallNumbers fcn = new FindingCallNumbers();
            this.Close();
            fcn.Show();

        }

        private void btnReplacingBooks_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
            
        }

        private void btnIdentifyingBooks_Click(object sender, RoutedEventArgs e)
        {
            IdentifyingAreas ia = new IdentifyingAreas();
            this.Close();
            ia.Show();
            
        

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
