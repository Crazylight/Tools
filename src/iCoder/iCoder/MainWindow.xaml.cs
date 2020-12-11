using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace iCoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnCreateLayers_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            (new Views.DBChooser() { WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen }).Show();
        }

        private void BtnCreateUI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCreateDB_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            (new Views.DbCreater()).Show();
        }

        private void BtnCreateProj_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            (new Views.SolutionCreater()).Show();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
