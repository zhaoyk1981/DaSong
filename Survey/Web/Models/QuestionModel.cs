using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class QuestionModel
    {
        public Guid? ID { get; set; }

        public int? SN { get; set; }
        public string Text { get; set; }

        public IList<AnswerModel> Answers { get; set; }
    }
}