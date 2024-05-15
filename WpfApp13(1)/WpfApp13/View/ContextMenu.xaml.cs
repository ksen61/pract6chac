using WpfApp13.Model;
using WpfApp13.ViewModel;
using WpfApp13.ViewModel.Helperi;
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
using WpfApp13;

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для ContextMenu.xaml
    /// </summary>
    public partial class ContextMenu : UserControl
    {
        DateTime date1 = DateTime.Now;
        public ContextMenu(DateTime date)
        {
            InitializeComponent();
            date1 = date;
            DataContext = new ContextMenuVM(date1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenCheck();
        }
        private void See_Click(object sender, RoutedEventArgs e)
        {
            OpenCheck();
        }
        private void OpenCheck()
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.abc.KakayaData = date1.ToString("dd MMMM yyyy г.");
            Frame frame = window.frame;
            ViborMenu menu_Change = new ViborMenu();
            frame.Content = menu_Change;
        }
    }
}
