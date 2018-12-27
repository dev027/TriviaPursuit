using System;
using Tp.Common.Constants;

namespace Tp.Domain
{
    public class QuestionBankSummary
    {
        public QuestionBankSummary(
            string categoryName,
            CheeseColour cheeseColour,
            int questionCount)
        {
            CategoryName = categoryName;
            CheeseColour = cheeseColour;
            QuestionCount = questionCount;
        }
        public string CategoryName { get; set; }
        public CheeseColour CheeseColour { get; set; }
        public int QuestionCount { get; set; }
    }
}
