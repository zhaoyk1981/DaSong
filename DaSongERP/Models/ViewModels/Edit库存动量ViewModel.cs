using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.ViewModels
{
    public class Edit库存动量ViewModel : ViewModel
    {
        public 库存动量Model EditModel { get; set; }

        public 库存商品Model 库存商品 { get; set; }
    }
}
