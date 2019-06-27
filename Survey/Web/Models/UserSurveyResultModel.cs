using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserSurveyResultModel
    {
        public Guid? UserID { get; set; }

        public IList<Guid> Answers { get; set; }

        public IDictionary<Guid, string> TextAnswers { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}