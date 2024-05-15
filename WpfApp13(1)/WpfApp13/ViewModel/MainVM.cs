using WpfApp13.Model;
using WpfApp13.ViewModel.Helperi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfApp13;

namespace WpfApp13.ViewModel
{
    internal class MainVM : BindingHelp
    {
        private List<ContextMenu> colvoContext = new List<ContextMenu>();

        public List<ContextMenu> ColvoMenu
        {
            get { return colvoContext; }
            set { colvoContext = value; OnPropertyChanged(); }
        }

        private string chislo;

        public string Chislo
        {
            get { return chislo; }
            set { chislo = value; OnPropertyChanged(); }
        }

        public MainVM(DateTime date)
        {
            Conver(date);
        }

        public void Conver(DateTime date)
        {
            Converter converter = new Converter();
            var ViborsList = converter.Jsonviser<List<ChoiceDayModel>>("Mood.json") ?? new List<ChoiceDayModel>();
            ColvoMenu.Clear();
            for (int i = 1; i <= DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                DateTime dat = new DateTime(date.Year, date.Month, i);
                ContextMenu ContextMenu = new ContextMenu(dat);
                foreach (var item in ViborsList)
                {
                    if (item.data == dat)
                    {
                        foreach (var item1 in item.choiceModels)
                        {
                            if (item1.selected == true)
                            {
                                ContextMenu.KartinkaImg.Source = new BitmapImage(new Uri(item1.pathKartinki, UriKind.Relative));
                                break;
                            }
                        }
                    }
                }
                ContextMenu.date.Text = i.ToString();
                ColvoMenu.Add(ContextMenu);
            }
        }
    }
}