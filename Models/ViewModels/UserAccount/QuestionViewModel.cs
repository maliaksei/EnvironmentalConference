﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.UserAccount
{
    public class QuestionViewModel
    {
        public Guid AnswerQuestionId { get; set; }

        public string Answer { get; set; }
        public string Question { get; set; }
    }
}
