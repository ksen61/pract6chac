using WpfApp13.Model;
using WpfApp13.ViewModel.Helperi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WpfApp13;
using System.ComponentModel;
using System.Windows.Navigation;
using System.Data;
using System.Windows.Controls;


namespace WpfApp13.ViewModel
{
    internal class ViborMenuVM : BindingHelp
    {
        public BindingClick Selected { get; set; }
        public BindingClick Save { get; set; }
        public BindingClick Nazad { get; set; }
       
        private BitmapImage pathKartinkiOtlicno;

        public BitmapImage PathKartinkiOtlicno
        {
            get { return pathKartinkiOtlicno; }
            set { pathKartinkiOtlicno = value; OnPropertyChanged(); }
        }

        private string otlicnotxt;

        public string Otlicnotxt
        {
            get { return otlicnotxt; }
            set { otlicnotxt = value; OnPropertyChanged(); }
        }

        private bool checkOtlicno;

        public bool CheckOtlicno
        {
            get { return checkOtlicno; }
            set { checkOtlicno = value; OnPropertyChanged(); }
        }

        private BitmapImage pathKartinkiHoroch;

        public BitmapImage PathKartinkiHoroch
        {
            get { return pathKartinkiHoroch; }
            set { pathKartinkiHoroch = value; OnPropertyChanged(); }
        }

        private string horochtxt;

        public string Horochtxt
        {
            get { return horochtxt; }
            set { horochtxt = value; OnPropertyChanged(); }
        }

        private bool checkHoroch;

        public bool CheckHoroch
        {
            get { return checkHoroch; }
            set { checkHoroch = value; OnPropertyChanged(); }
        }

        private BitmapImage pathKartinkiTak;

        public BitmapImage PathKartinkiTak
        {
            get { return pathKartinkiTak; }
            set { pathKartinkiTak = value; OnPropertyChanged(); }
        }

        private string taktxt;

        public string Taktxt
        {
            get { return taktxt; }
            set { taktxt = value; OnPropertyChanged(); }
        }

        private bool checkTak;

        public bool CheckTak
        {
            get { return checkTak; }
            set { checkTak = value; OnPropertyChanged(); }
        }

        private BitmapImage pathKartinkiPloho;

        public BitmapImage PathKartinkiPloho
        {
            get { return pathKartinkiPloho; }
            set { pathKartinkiPloho = value; OnPropertyChanged(); }
        }

        private string plohotxt;

        public string Plohotxt
        {
            get { return plohotxt; }
            set { plohotxt = value; OnPropertyChanged(); }
        }

        private bool checkPloho;

        public bool CheckPloho
        {
            get { return checkPloho; }
            set { checkPloho = value; OnPropertyChanged(); }
        }

        private BitmapImage pathKartinkiYjacno;

        public BitmapImage PathKartinkiYjacno
        {
            get { return pathKartinkiYjacno; }
            set { pathKartinkiYjacno = value; OnPropertyChanged(); }
        }

        private string yjacnotxt;

        public string Yjacnotxt
        {
            get { return yjacnotxt; }
            set { yjacnotxt = value; OnPropertyChanged(); }
        }

        private bool checkYjacno;

        public bool CheckYjacno
        {
            get { return checkYjacno; }
            set { checkYjacno = value; OnPropertyChanged(); }
        }

        private List<ChoiceModel> viborList = new List<ChoiceModel>();
        private List<ChoiceDayModel> ChoiceList = new List<ChoiceDayModel>();
        Converter Converter = new Converter();
        public ViborMenuVM()
        {
            PathKartinkiOtlicno = new BitmapImage(new Uri("/Img/photo1714828088 (5).jpeg", UriKind.Relative));
            Otlicnotxt = "Отлично";
            PathKartinkiHoroch = new BitmapImage(new Uri("/Img/photo1714828088 (3).jpeg", UriKind.Relative));
            Horochtxt = "Хорошо";
            PathKartinkiTak = new BitmapImage(new Uri("/Img/300px-Шаблон_кот.jpg", UriKind.Relative));
            Taktxt = "Так себе";
            PathKartinkiPloho = new BitmapImage(new Uri("/Img/photo1714828088 (1).jpeg", UriKind.Relative));
            Plohotxt = "Плохо";
            PathKartinkiYjacno = new BitmapImage(new Uri("/Img/Я ваша кукуха и я готова к отлету.jpeg", UriKind.Relative));
            Yjacnotxt = "Ужасно";
            Selected = new BindingClick(Select);
            Save = new BindingClick(_ => SaveClick());
            Nazad = new BindingClick(_ => NazadClick());
            ChoiceList = Converter.Jsonviser<List<ChoiceDayModel>>("Mood.json") ?? new List<ChoiceDayModel>();
            MainWindow window = Application.Current.MainWindow as MainWindow;
            DateTime date = DateTime.Parse(window.abc.KakayaData);
            foreach (var item in ChoiceList)
                {
                    if (item.data == date)
                    {
                        viborList = item.choiceModels;
                    }
                }
                foreach (var item in viborList)
                {
                    if (item.name == "Отлично")
                    {
                        CheckOtlicno = item.selected;
                    }
                    else if (item.name == "Хорошо")
                    {
                        CheckHoroch = item.selected;
                    }
                    else if (item.name == "Так себе")
                    {
                        CheckTak = item.selected;
                    }
                    else if (item.name == "Плохо")
                    {
                        CheckPloho = item.selected;
                    }
                    else if (item.name == "Ужасно")
                    {
                        CheckYjacno = item.selected;
                    }
                }
                if (viborList.Count == 0)
                {
                    ChoiceModel Otlicno = new ChoiceModel(Otlicnotxt, PathKartinkiOtlicno.ToString(), CheckOtlicno);
                    viborList.Add(Otlicno);
                    ChoiceModel Horoch = new ChoiceModel(Horochtxt, PathKartinkiHoroch.ToString(), CheckHoroch);
                    viborList.Add(Horoch);
                    ChoiceModel Tak = new ChoiceModel(Taktxt, PathKartinkiTak.ToString(), CheckTak);
                    viborList.Add(Tak);
                    ChoiceModel Ploho = new ChoiceModel(Plohotxt, PathKartinkiPloho.ToString(), CheckPloho);
                    viborList.Add(Ploho);
                    ChoiceModel Yjacno = new ChoiceModel(Yjacnotxt, PathKartinkiYjacno.ToString(), CheckYjacno);
                    viborList.Add(Yjacno);
                }
        }

        public void Select(object nomer)
        {
            switch (nomer)
            {
                case "Otlicno":
                    if (CheckOtlicno == true)
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Отлично")
                            {
                                item.selected = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Отлично")
                            {
                                item.selected = false;
                            }
                        }
                    }
                    break;
                case "Horoch":
                    if (CheckHoroch == true)
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Хорошо")
                            {
                                item.selected = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Хорошо")
                            {
                                item.selected = false;
                            }
                        }
                    }
                    break;
                case "Tak":
                    if (CheckTak == true)
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Так себе")
                            {
                                item.selected = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Так себе")
                            {
                                item.selected = false;
                            }
                        }
                    }
                    break;
                case "Ploho":
                    if (CheckPloho == true)
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Плохо")
                            {
                                item.selected = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Плохо")
                            {
                                item.selected = false;
                            }
                        }
                    }
                    break;
                case "Yjacno":
                    if (CheckYjacno == true)
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Ужасно")
                            {
                                item.selected = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in viborList)
                        {
                            if (item.name == "Ужасно")
                            {
                                item.selected = false;
                            }
                        }
                    }
                    break;
            }
        }

        public void SaveClick()
        {

            MainWindow window = Application.Current.MainWindow as MainWindow;
                DateTime date = DateTime.Parse(window.abc.KakayaData);
                for (int i = 0; i < ChoiceList.Count; i++)
                {
                    if (ChoiceList[i].data == date)
                    {
                        ChoiceList.Remove(ChoiceList[i]);
                        Converter.Jsonser(ChoiceList, "Mood.json");
                    }
                }
                ChoiceDayModel choice = new ChoiceDayModel(date, viborList);
                ChoiceList.Add(choice);
                Converter.Jsonser(ChoiceList, "Mood.json");
                Refresh();
        }
        public void NazadClick()
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                if (mainWindow.frame.CanGoBack)
                {
                    mainWindow.frame.GoBack();
                }
            }

        }

        private object contentXZ;

        public object ContentXZ
        {
            get { return contentXZ; }
            set { contentXZ = value; OnPropertyChanged(); }
        }
        public void Refresh()
        {
            Main Main = new Main();
            ContentXZ = Main;
        }

    }
}