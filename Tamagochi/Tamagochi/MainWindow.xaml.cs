using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Tamagochi
{
    //Добавить магазин с едой
    //Добавть шанс заболеть
    //Добавить музыку
    public partial class MainWindow : Window
    {
        BitmapImage n1;
        BitmapImage n2;
        BitmapImage eat;
        BitmapImage slp;
        BitmapImage ply;
        long x = 0;
        int time;
        double pain;
        bool chance = true;
        bool sick = false;
        bool anim = false;
        int bint;
        double mnog;
        Random ran = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow(string name, string type, double dif_sl, BitmapImage a, BitmapImage b, BitmapImage c, BitmapImage d,BitmapImage g)
        {
            InitializeComponent();
            n1 = a;
            n2 = b;
            eat = c;
            slp = d;
            ply = g;
            bints.Content = "Бинтов: " + bint.ToString();
            Pet_Name.Content = name;
            Pet_Type.Content = type;
            switch (dif_sl)
            {
                case 0:
                    pain = 0.3;
                    time = 100;
                    mnog = 0.9;
                    break;
                case 5:
                    pain = 0.5;
                    time = 80;
                    mnog = 1;
                    break;
                case 10:
                    pain = 0.8;
                    time = 60;
                    mnog = 1.15;
                    break;
            }
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            if (Pet_Name.Content.ToString() == "123")
            {
                pain = 10;
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            happy.Value = happy.Value - pain;
            food.Value = food.Value - (pain + 0.2);
            sleep.Value = sleep.Value + pain;
            x++;
            if (bint >= 1 && sick == true)
            {
                Heal.IsEnabled = true;
                Heal.Foreground = Brushes.Red;
            }
            else if (bint >= 1)
                Heal.IsEnabled = true;
            else if (bint <= 0)
                Heal.IsEnabled = false;
            x_check();
            stat_check();
        }

        public void stat_check()
        {
            if (happy.Value < 0.5 && food.Value < 0.5 && sleep.Value > 99.5)
            {
                mnog = mnog * x;
                MessageBox.Show(Pet_Name.Content.ToString() + " умер/ла\nОчки: " + mnog, "Вы проиграли", MessageBoxButton.OK);
                timer.Stop();
                Window1 window1 = new Window1();
                window1.Show();
                Close();

            }
            else if (sleep.Value == 100)
            {
                timer.Stop();
                sleep.Value -= 20;
                img.Source = slp;
                Thread.Sleep(350);
                timer.Start();
            }

        }

        public void x_check()
        {
            if (anim == false)
            {
                Sleep.IsEnabled = true;
                Give_food.IsEnabled = true;
                Play.IsEnabled = true;
                if (x % 2 == 0)
                    img.Source = n1;
                else
                    img.Source = n2;
            }
            if (x % (time+40) == 0 && chance == true)
                if ((_ = ran.Next(1, 3)) == 1)
                {
                    MessageBox.Show(Pet_Name.Content.ToString() + " заболел/а", "Болезнь", MessageBoxButton.OK);
                    pain += 0.6;
                    chance = false;
                    sick = true;
                }
            if (x % time == 0)
                if (_ = ran.Next(1, 3) == 1)
                {
                    MessageBox.Show(Pet_Name.Content.ToString() + " нашёл/а бинт", "Удача на вашей стороне", MessageBoxButton.OK);
                    bint++;
                    bints.Content = "Бинтов: " + bint.ToString();
                }
        }

        private void Give_food_Click(object sender, RoutedEventArgs e)
        {
            img.Source = eat;
            food.Value += 20;
            anim = true;
            Give_food.IsEnabled = false;
            Thread.Sleep(350);
            anim = false;
        }

        private void Sleep_Click(object sender, RoutedEventArgs e)
        {
            img.Source = slp;
            sleep.Value -= 17;
            anim = true;
            Sleep.IsEnabled = false;
            Thread.Sleep(350);
            anim = false;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            img.Source = ply;
            happy.Value += 13;
            anim = true;
            Play.IsEnabled = false;
            Thread.Sleep(350);
            anim = false;
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            if(bint>=1 && sick == true)
            {
                sick = false;
                pain -= 0.6;
                Heal.Foreground = Brushes.Black;
                bint--;
                bints.Content = "Бинтов: " + bint.ToString();
            }
            else if (bint <= 0)
                MessageBox.Show("У вас нет бинтов", ":(", MessageBoxButton.OK);
            else if (bint >= 1 && sick == false)
                MessageBox.Show(Pet_Name.Content.ToString() + " не болеет", "Зачем бинт достал", MessageBoxButton.OK);
        }
    }
}
