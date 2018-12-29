using Tp.Common.Constants;

namespace Tp.Domain
{
    public class QuestionBankSummary
    {
        public QuestionBankSummary(
            int categoryId,
            string categoryName,
            CheeseColour cheeseColour,
            int questionCount)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            CheeseColour = cheeseColour;
            QuestionCount = questionCount;
        }

        public int CategoryId { get; }
        public string CategoryName { get; }
        public CheeseColour CheeseColour { get; }
        public int QuestionCount { get; }
    }
}