using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Slalom
{
    class Animations
    {

        public static void trafficLightAnimation(object send, EventArgs e)
        {
            MainWindow.t++;
            switch (MainWindow.t)
            {
                case 1:
                    MainWindow.trafficLightSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/trafficLight/1.png"));
                    break;
                case 2:
                    MainWindow.trafficLightSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/trafficLight/2.png"));
                    break;
                case 3:
                    MainWindow.trafficLightSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/trafficLight/3.png"));
                    MainWindow.t = 0;
                    MainWindow.trafficLightTimer.Stop();
                    break;
            }
            MainWindow.trafficLight1.Fill = MainWindow.trafficLightSkin;
            MainWindow.trafficLight2.Fill = MainWindow.trafficLightSkin;
            MainWindow.trafficLightTimer.Interval = TimeSpan.FromMilliseconds(950);
        }

        public static void seaGullAnimation(object send, EventArgs e)
        {
            MainWindow.s++;
            switch (MainWindow.s)
            {
                case 1:
                    MainWindow.seagullSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/seagull/1.png"));
                    break;
                case 2:
                    MainWindow.seagullSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/seagull/2.png"));
                    break;
                case 3:
                    MainWindow.seagullSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/seagull/3.png"));
                    break;
                case 4:
                    MainWindow.seagullSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/seagull/4.png"));
                    break;
                case 5:
                    MainWindow.seagullSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/seagull/5.png"));
                    break;
                case 6:
                    MainWindow.seagullSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/seagull/6.png"));
                    break;
                case 7:
                    MainWindow.seagullSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/seagull/7.png"));
                    MainWindow.s = 0;
                    break;
            }
            MainWindow.seagull.Fill = MainWindow.seagullSkin;
        }

        public static void rabbitAnimation(object send, EventArgs e)
        {

            MainWindow.r++;
            switch (MainWindow.r)
            {
                case 1:
                    MainWindow.rabbit.Visibility = Visibility.Visible;
                    MainWindow.rabbitRun.Play();
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/1.png"));
                    break;
                case 2:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/2.png"));
                    break;
                case 3:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/3.png"));
                    break;
                case 4:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/4.png"));
                    break;
                case 5:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/5.png"));
                    break;
                case 6:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/6.png"));
                    break;
                case 7:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/7.png"));
                    break;
                case 8:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/8.png"));
                    break;
                case 9:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/9.png"));
                    break;
                case 10:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/10.png"));
                    break;
                case 11:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/11.png"));
                    break;
                case 12:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/12.png"));
                    break;
                case 13:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/13.png"));
                    break;
                case 14:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/14.png"));
                    break;
                case 15:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/15.png"));
                    break;
                case 16:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/16.png"));
                    break;
                case 17:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/17.png"));
                    break;
                case 18:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/18.png"));
                    break;
                case 19:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/19.png"));
                    break;
                case 20:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/20.png"));
                    break;
                case 21:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/21.png"));
                    break;
                case 22:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/22.png"));
                    break;
                case 23:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/23.png"));
                    break;
                case 24:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/24.png"));
                    break;
                case 25:
                    MainWindow.rabbitSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/rabbit/25.png"));
                    MainWindow.r = 0;
                    break;

            }
            MainWindow.rabbit.Fill = MainWindow.rabbitSkin;
        }

        public static void confettiAnimation(object send, EventArgs e)
        {
            MainWindow.c++;
            switch (MainWindow.c)
            {
                case 1:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/1.png"));
                    break;
                case 2:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/2.png"));
                    break;
                case 3:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/3.png"));
                    break;
                case 4:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/4.png"));
                    break;
                case 5:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/5.png"));
                    break;
                case 6:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/6.png"));
                    break;
                case 7:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/7.png"));
                    break;
                case 8:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/8.png"));
                    break;
                case 9:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/9.png"));
                    break;
                case 10:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/10.png"));
                    break;
                case 11:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/11.png"));
                    break;
                case 12:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/12.png"));
                    break;
                case 13:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/13.png"));
                    break;
                case 14:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/14.png"));
                    break;
                case 15:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/15.png"));
                    break;
                case 16:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/16.png"));
                    break;
                case 17:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/17.png"));
                    break;
                case 18:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/18.png"));
                    break;
                case 19:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/19.png"));
                    break;
                case 20:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/20.png"));
                    break;
                case 21:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/21.png"));
                    break;
                case 22:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/22.png"));
                    break;
                case 23:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/23.png"));
                    break;
                case 24:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/24.png"));
                    break;
                case 25:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/25.png"));
                    break;
                case 26:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/26.png"));
                    break;
                case 27:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/27.png"));
                    break;
                case 28:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/28.png"));
                    break;
                case 29:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/29.png"));
                    break;
                case 30:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/30.png"));
                    break;
                case 31:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/31.png"));
                    break;
                case 32:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/32.png"));
                    break;
                case 33:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/33.png"));
                    break;
                case 34:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/34.png"));
                    break;
                case 35:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/35.png"));
                    break;
                case 36:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/36.png"));
                    break;
                case 37:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/37.png"));
                    break;
                case 38:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/38.png"));
                    break;
                case 39:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/39.png"));
                    break;
                case 40:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/40.png"));
                    break;
                case 41:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/41.png"));
                    break;
                case 42:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/42.png"));
                    break;
                case 43:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/43.png"));
                    break;
                case 44:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/44.png"));
                    break;
                case 45:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/45.png"));
                    break;
                case 46:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/46.png"));
                    break;
                case 47:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/47.png"));
                    break;
                case 48:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/48.png"));
                    break;
                case 49:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/49.png"));
                    break;
                case 50:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/50.png"));
                    break;
                case 51:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/51.png"));
                    break;
                case 52:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/52.png"));
                    break;
                case 53:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/53.png"));
                    break;
                case 54:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/54.png"));
                    break;
                case 55:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/55.png"));
                    break;
                case 56:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/56.png"));
                    break;
                case 57:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/57.png"));
                    break;
                case 58:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/58.png"));
                    break;
                case 59:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/59.png"));
                    break;
                case 60:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/50.png"));
                    break;
                case 61:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/61.png"));
                    break;
                case 62:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/62.png"));
                    break;
                case 63:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/63.png"));
                    break;
                case 64:
                    MainWindow.confettiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/confetti/64.png"));
                    MainWindow.c = 0;
                    MainWindow.confetti.Visibility = Visibility.Collapsed;
                    MainWindow.confettiTimer.Stop();
                    break;
            }
            MainWindow.confetti.Fill = MainWindow.confettiSkin;
        }
    }
}
