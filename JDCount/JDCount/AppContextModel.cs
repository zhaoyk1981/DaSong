using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDCount
{
    public class AppContextModel
    {
        public List<商品Model> List { get; set; } = new List<商品Model>();

        public int KeywordColIndex { get; set; } = -1;

        public int CountColIndex { get; set; } = -1;

        public bool 京东物流 { get; set; } = true;
    }
}
