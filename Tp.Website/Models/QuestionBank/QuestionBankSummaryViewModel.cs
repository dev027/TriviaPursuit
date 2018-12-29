using Tp.Common.Extensions.CheeseColourExtensions;
using Tp.Domain;

namespace Tp.Website.Models.QuestionBank
{
    public class QuestionBankSummaryViewModel
    {
        public QuestionBankSummaryViewModel(
            int categoryId,
            string categoryName,
            int questionCount,
            string iconImage,
            string backgroundColourClass,
            string backgroundDarkColourClass)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            QuestionCount = questionCount;
            IconImage = iconImage;
            BackgroundColourClass = backgroundColourClass;
            BackgroundDarkColourClass = backgroundDarkColourClass;
        }

        public int CategoryId { get; }
        public string CategoryName { get; }
        public int QuestionCount { get; }
        public string IconImage { get; }
        public string BackgroundColourClass { get; }
        public string BackgroundDarkColourClass { get; }

        public static QuestionBankSummaryViewModel Create(QuestionBankSummary questionBankSummary)
        {
            return new QuestionBankSummaryViewModel(
                categoryId:questionBankSummary.CategoryId,
                categoryName: questionBankSummary.CategoryName,
                questionCount: questionBankSummary.QuestionCount,
                iconImage: questionBankSummary.CheeseColour.ToIconClass(),
                backgroundColourClass: questionBankSummary.CheeseColour.ToBackgroundColourClass(),
                backgroundDarkColourClass: questionBankSummary.CheeseColour.ToBackgroundDarkColourClass());
        }
    }
}