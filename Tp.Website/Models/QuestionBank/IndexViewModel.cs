using System.Collections.Generic;
using System.Linq;
using Tp.Domain;
using Tp.Website.Models.Category;

namespace Tp.Website.Models.QuestionBank
{
    public class IndexViewModel
    {
        public IndexViewModel(IList<QuestionBankSummaryViewModel> questionBankSummaryViewModels)
        {
            QuestionBankSummaryViewModels = questionBankSummaryViewModels;
        }

        public IList<QuestionBankSummaryViewModel> QuestionBankSummaryViewModels { get; }

        public static IndexViewModel Create(IEnumerable<QuestionBankSummary> questionBankSummaries)
        {
            return new IndexViewModel(
                questionBankSummaries
                    .Select(QuestionBankSummaryViewModel.Create)
                    .ToList());
        }
    }
}