//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AnswersQuestions
    {
        public System.Guid AnswerQuestionId { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public Nullable<System.Guid> ApplicationId { get; set; }
        public Nullable<System.DateTime> AnswerDateTime { get; set; }
        public System.DateTime QuestionDateTime { get; set; }
    
        public virtual Application Application { get; set; }
    }
}
