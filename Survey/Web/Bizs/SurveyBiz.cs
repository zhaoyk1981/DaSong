using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using Web.ViewModels;

namespace Web.Bizs
{
    public class SurveyBiz
    {
        public SurveyViewModel GetViewModel()
        {
            var vm = new SurveyViewModel();
            #region
            vm.Questions = new List<QuestionModel>();
            var q1 = new QuestionModel()
            {
                ID = Guid.NewGuid(),
                SN = 1,
                Text = "请问您购买车位的心里价位是多少？",
                Answers = new List<AnswerModel>()
            };

            vm.Questions.Add(q1);

            q1.Answers.Add(new AnswerModel()
            {
                ID = Guid.NewGuid(),
                Question = q1,
                SN = 1,
                Text = "10万"
            });
            q1.Answers.Add(new AnswerModel()
            {
                ID = Guid.NewGuid(),
                Question = q1,
                SN = 2,
                Text = "20万"
            });
            q1.Answers.Add(new AnswerModel()
            {
                ID = Guid.NewGuid(),
                Question = q1,
                SN = 3,
                Text = "30万"
            });
            q1.Answers.Add(new AnswerModel()
            {
                ID = Guid.NewGuid(),
                Question = q1,
                SN = 4,
                Text = "40万"
            });

            #endregion
            return vm;
        }
    }
}