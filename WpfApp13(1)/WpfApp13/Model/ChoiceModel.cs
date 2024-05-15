using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13.Model
{
    internal class ChoiceModel
    {
        public string name;
        public string pathKartinki;
        public bool selected;

        public ChoiceModel(string name, string pathKartinki, bool selected)
        {
            this.name = name;
            this.pathKartinki = pathKartinki;
            this.selected = selected;
        }
    }
}
