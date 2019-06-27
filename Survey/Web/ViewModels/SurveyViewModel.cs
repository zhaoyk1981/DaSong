using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.ViewModels
{
    public class SurveyViewModel : ViewModel
    {
        public IList<QuestionModel> Questions { get; set; }
    }
}