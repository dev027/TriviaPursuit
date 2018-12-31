using System.Collections.Generic;
using System.Linq;
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

                return categories.Select(c => new QuestionBankSummary(
                        categoryId: c.Id,
                        categoryName: c.Name,
                        cheeseColour: c.CheeseColour,
                        questionCount: data.Question.GetCountByCategoryId(c.Id)))
                    .ToList();
            }
        }

        public Category GetById(int categoryId,
            Category.Include include = Category.Include.None)
        {
            using (var data = new Data.Data())
            {
                return data.Category.GetById(categoryId, include);
            }
        }
    }
}