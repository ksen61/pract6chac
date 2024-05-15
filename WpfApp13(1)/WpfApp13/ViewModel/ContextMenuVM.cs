using WpfApp13.ViewModel.Helperi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using WpfApp13.Model;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;
using WpfApp13;

namespace WpfApp13.ViewModel
{
    internal class ContextMenuVM : BindingHelp
    {
        public BindingClick Clear { get; set; }

        public ContextMenuVM(DateTime data1)
        {
            Clear = new BindingClick(_ => ClearClick(data1));
        }

        public void ClearClick(DateTime date)
        {
            Converter converter = new Converter();
            var list = converter.Jsonviser<List<ChoiceDayModel>>("Mood.json");
            for (int i = 0; i < list.Count; i++)
            {
                if (date.Day == list[i].data.Day)
                {
                    list.Remove(list[i]);
                }
            }
            converter.Jsonser(list, "Mood.json");
            MainWindow window = System.Windows.Application.Current.MainWindow as MainWindow;
            window.frame.Content = new Main(date);
        }
    }
}