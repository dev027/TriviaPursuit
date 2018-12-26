using System.Collections.Generic;
using Tp.Models.BaseModels;

namespace Tp.Models.DbEntities
{
    public class Question : BaseModelWithId
    {
        #region Constructors

        public Question()
        {
        }

        public Question(
            string text,
            int categoryId,
            int id = 0)
            : base(id: id)
        {
            Text = text;
            CategoryId = categoryId;
        }

        #endregion Constructors

        #region Properties

        public int CategoryId { get; set; }

        public string Text { get; set; }

        #endregion Properties

        #region Parent Properties

        public Category Category { get; set; }

        #endregion Parent Properties

        #region Child Properties

        public IList<Answer> Answers { get; set; }

        #endregion Child Properties

        public enum Include
        {
            None = 0,
            Category = 1 << 0,
            Answers = 1 << 1
        }

        public enum OrderBy
        {
            None,
            Id,
            CategoryName
        }
    }
}