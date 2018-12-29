using System.Collections.Generic;
using System.Linq;
using Tp.Domain;
using Tp.Website.Models.Shared;

namespace Tp.Website.Models.QuestionBank
{
    public class IndexViewModel
    {
        public IndexViewModel(
            ContentHeaderViewModel contentHeaderViewModel,
            IList<QuestionBankSummaryViewModel> questionBankSummaryViewModels)
        {
            ContentHeaderViewModel = contentHeaderViewModel;
            QuestionBankSummaryViewModels = questionBankSummaryViewModels;
        }

        public ContentHeaderViewModel ContentHeaderViewModel { get; }
        public IList<QuestionBankSummaryViewModel> QuestionBankSummaryViewModels { get; }

        public static IndexViewModel Create(IEnumerable<QuestionBankSummary> questionBankSummaries)
        {
            return new IndexViewModel(
                contentHeaderViewModel: new ContentHeaderViewModel("Question Bank"), 
                questionBankSummaryViewModels: questionBankSummaries
                    .Select(QuestionBankSummaryViewModel.Create)
                    .ToList());
        }
    }
}