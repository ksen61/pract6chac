using WpfApp13.ViewModel.Helperi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp13.ViewModel
{
    internal class MainWindowVM : BindingHelp
    {
        DateTime date = DateTime.Now;

        public BindingClick Next { get; set; }
        public BindingClick Back { get; set; }

        private string kakayaData;

        public string KakayaData
        {
            get { return kakayaData; }
            set { kakayaData = value; OnPropertyChanged(); }
        }

        private object contentXZ;

        public object ContentXZ
        {
            get { return contentXZ; }
            set { contentXZ = value; OnPropertyChanged(); }
        }

        public MainWindowVM()
        {
            Next = new BindingClick(_ => NextClick());
            Back = new BindingClick(_ => BackClick());
            Refresh();
        }

        public void Refresh()
        {
            KakayaData = date.ToString("Y");
            Main Main = new Main(date);
            ContentXZ = Main;
        }

        public void NextClick()
        {
            date = date.AddMonths(1);
            Refresh();
        }

        public void BackClick()
        {
            date = date.AddMonths(-1);
            Refresh();
        }

    }
}