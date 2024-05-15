using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp13.Model;

namespace WpfApp13.Model
{
    internal class ChoiceDayModel
    {
        public List<ChoiceModel> choiceModels;
        public DateTime data;

        public ChoiceDayModel(DateTime date, List<ChoiceModel> choiceModel)
        {
            this.data = date;
            this.choiceModels = choiceModel;

        }
    }
}