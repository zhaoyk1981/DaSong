using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class AnswerModel
    {
        public Guid? ID { get; set; }

        public int? SN { get; set; }
        public QuestionModel Question { get; set; }

        public Guid? QuestionID
        {
            get
            {
                return this.Question?.ID;
            }
            set
            {
                if (this.Question == null)
                {
                    this.Question = new QuestionModel();
                }

                this.Question.ID = value;
            }
        }

        public string Text { get; set; }

        public string Value { get; set; }
    }
}