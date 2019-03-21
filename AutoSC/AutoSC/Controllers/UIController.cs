using AutoSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoSC.Utils;

namespace AutoSC.Controllers
{
    public class UIController
    {
        private AppContextModel Context { get; set; }

        public UIController(AppContextModel context)
        {
            this.Context = context;
        }

        public void BindDropDownList(ComboBox ctrl, Enum selectedItem)
        {
            var util = new ControlUtil();
            util.BindDropDownList(ctrl, selectedItem);
        }
    }
}
