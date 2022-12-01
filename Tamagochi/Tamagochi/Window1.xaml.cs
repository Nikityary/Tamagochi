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
using System.Windows.Shapes;

namespace Tamagochi
{
    public partial class Window1 : Window
    {
        BitmapImage dn1 = new BitmapImage(new Uri("/Res/dn1.png", UriKind.Relative));
        BitmapImage dn2 = new BitmapImage(new Uri("/Res/dn2.png", UriKind.Relative));
        BitmapImage de1 = new BitmapImage(new Uri("/Res/de1.png", UriKind.Relative));
        BitmapImage ds2 = new BitmapImage(new Uri("/Res/ds2.png", UriKind.Relative));
        BitmapImage dp2 = new BitmapImage(new Uri("/Res/dp2.png", UriKind.Relative));
        BitmapImage tn1 = new BitmapImage(new Uri("/Res/tn1.png", UriKind.Relative));
        BitmapImage tn2 = new BitmapImage(new Uri("/Res/tn2.png", UriKind.Relative));
        BitmapImage te = new BitmapImage(new Uri("/Res/te.png", UriKind.Relative));
        BitmapImage tp = new BitmapImage(new Uri("/Res/tp.png", UriKind.Relative));
        BitmapImage ts = new BitmapImage(new Uri("/Res/ts.png", UriKind.Relative));
        public Window1()
        {
            InitializeComponent();
        }

        public void bt1_Click(object sender, RoutedEventArgs e)
        {
            if(Pet_Name.Text.Length < 38)
            {
                MainWindow mainWindow = new MainWindow(Pet_Name.Text, bt1.Content.ToString(), dif_sl.Value, dn1, dn2, de1, ds2, dp2);
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Имя питомца должно быть до 38 символов", "Слишком длинное имя", MessageBoxButton.OK);
            }
        }

        public void bt2_Click(object sender, RoutedEventArgs e)
        {
            if (Pet_Name.Text.Length < 38)
            {
                MainWindow mainWindow = new MainWindow(Pet_Name.Text, bt2.Content.ToString(), dif_sl.Value,  tn1, tn2, te, ts, tp);
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Имя питомца должно быть до 38 символов", "Слишком длинное имя", MessageBoxButton.OK);
            }
        }

        private void dif_sl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            switch (dif_sl.Value)
            {
                case 0:
                    Dif_lvl.Content = "Легко";
                    break;
                case 5:
                    Dif_lvl.Content = "Нормально";
                    break;
                case 10:
                    Dif_lvl.Content = "Сложно";
                    break;
            }
        }
    }   
}
