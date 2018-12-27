using System.Collections.Generic;
using Tp.Common.Constants;
using Tp.Models.BaseModels;

namespace Tp.Models.DbEntities
{
    public class Category : BaseModelWithId
    {
        #region Constructors

        public Category()
        {
        }

        public Category(
            string name,
            CheeseColour cheeseColour,
            int id = 0)
            : base(id: id)
        {
            Name = name;
            CheeseColour = cheeseColour;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; set; }

        public CheeseColour CheeseColour { get; set; }

        #endregion Properties

        #region Child Properties

        public IList<PlayerCategory> PlayerCategories { get; set; }
        public IList<Question> Questions { get; set; }

        #endregion Child Properties

        public enum Include
        {
            None = 0,
            PlayerCategories = 1 << 0,
            Questions = 1 << 1
        }

        public enum OrderBy
        {
            None,
            Id,
            Name,
            CheeseColour
        }
    }
}