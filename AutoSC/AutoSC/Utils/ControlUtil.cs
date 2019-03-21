using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSC.Utils
{
    public class ControlUtil
    {
        public void BindDropDownList(ComboBox ctrl, Enum selectedItem)
        {
            ctrl.Items.Clear();
            var names = Enum.GetNames(selectedItem.GetType());
            foreach (var name in names)
            {
                ctrl.Items.Add(name);
            }

            ctrl.SelectedItem = selectedItem.ToString();
        }
    }
}
