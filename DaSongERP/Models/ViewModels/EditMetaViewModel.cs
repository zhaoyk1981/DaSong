using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.ViewModels
{
    public class EditMetaViewModel : ViewModel
    {
        public MetaModel<Guid> Meta { get; set; }
    }
}
