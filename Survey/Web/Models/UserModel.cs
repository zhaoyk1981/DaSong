using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserModel
    {
        public Guid? ID { get; set; }

        public string Mobile { get; set; }

        public string IDNumbers { get; set; }
    }
}