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

        public string Name;

        public CheeseColour CheeseColour;

        #endregion Properties

        #region Child Properties

        public IList<PlayerCategory> PlayerCategories { get; set; }

        #endregion Child Properties
    }
}