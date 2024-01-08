using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Data.SQLite;

namespace LF08_C_Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //testComment
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ponies!");
            /*
            GetValue(ponyImage.VisibilityProperty);
            ponyImage.SetValue(VisibilityProperty, );
            */
        }

        private void testie() {
            ArrayList users = new ArrayList();

            users.Add("ponk");
            users.Add("twi");
            users.Add("dashie");

           // DataGrid.ItemsSource = users;

        }
    }
}
