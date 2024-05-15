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
    /// Логика взаимодействия для Menu_change.xaml
    /// </summary>
    public partial class ViborMenu : Page
    {
        public ViborMenu()
        {
            InitializeComponent();
            DataContext = new ViborMenuVM();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation anim = new DoubleAnimation();
            anim.From = Save.ActualHeight;
            anim.To = 50;
            anim.Duration = TimeSpan.FromSeconds(3);
            anim.FillBehavior = FillBehavior.Stop;
            anim.AutoReverse = true;
            Save.BeginAnimation(Button.HeightProperty, anim);
        }
    }
}
