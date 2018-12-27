using System.Collections.Generic;
using Tp.Common.Constants;
using Tp.Domain;
using Tp.Models.DbEntities;

namespace Tp.Service
{
    public class CategoryService
    {
        public IList<Category> GetAll()
        {
            using (var data = new Data.Data())
            {
                return data.Category.GetAll(
                    orderBy:Category.OrderBy.CheeseColour);
            }
        }

        public bool Any()
        {
            using (var data = new Data.Data())
            {
                return data.Category.Any();
            }
        }

        public void Create(string name, CheeseColour cheeseColour)
        {
            using (var data = new Data.Data())
            {
                var category = new Category(name, cheeseColour);
                data.Category.Create(category);
            }
        }

        public IList<QuestionBankSummary> GetQuestionBankSummaries()
        {
            using (var data = new Data.Data())
            {
                var categories = data.Category.GetAll();

                IList< QuestionBankSummary > questionBankSummaries = new List<QuestionBankSummary>();

                foreach (var category in categories)
                {
                    var questionBankSummary = new QuestionBankSummary(
                        categoryName: category.Name,
                        cheeseColour: category.CheeseColour,
                        questionCount: 0);

                    questionBankSummaries.Add(questionBankSummary);

                }

                return questionBankSummaries;
            }
        }
    }
}