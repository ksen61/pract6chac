using WpfApp13.ViewModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp13;

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal MainWindowVM abc;
        public MainWindow()
        {
            InitializeComponent();

            abc = new MainWindowVM();
            DataContext = abc;
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            ColorAnimation coloranim = new ColorAnimation();
            NextBtn.Background = ((SolidColorBrush)NextBtn.Background).Clone();
            coloranim.To = Colors.DarkRed;
            coloranim.Duration = TimeSpan.FromSeconds(2);
            NextBtn.Background.BeginAnimation(SolidColorBrush.ColorProperty, coloranim);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimationUsingKeyFrames sizeanim = new DoubleAnimationUsingKeyFrames();
            sizeanim.Duration = TimeSpan.FromSeconds(3);
            sizeanim.KeyFrames.Add(new LinearDoubleKeyFrame(600, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.5))));
            sizeanim.KeyFrames.Add(new LinearDoubleKeyFrame(650, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1))));
            this.BeginAnimation(WidthProperty, sizeanim);
            ColorAnimation color = new ColorAnimation();
            BackBtn.Background = ((SolidColorBrush)BackBtn.Background).Clone();
            color.To = Colors.BlueViolet;
            color.Duration = TimeSpan.FromSeconds(2);
            BackBtn.Background.BeginAnimation(SolidColorBrush.ColorProperty, color);
        }
    }
}
