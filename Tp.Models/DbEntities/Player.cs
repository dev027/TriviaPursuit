using System.Collections.Generic;
using Tp.Models.BaseModels;

namespace Tp.Models.DbEntities
{
    public class Player: BaseModelWithId
    {
        #region Constructors

        public Player()
        {
        }
        public Player(
            string firstName,
            string surname, 
            int level, 
            int experience,
            int crown,
            int id = 0)
            : base(id: id)
        {
            FirstName = firstName;
            Surname = surname;
            Level = level;
            Experience = experience;
            Crown = crown;
        }

        public Player(
            string firstName,
            string surname)
        {
            FirstName = firstName;
            Surname = surname;
            Level = 1;
            Experience = 0;
            Crown = 1;
        }

        #endregion

        #region Properties

        public string FirstName { get; set; }
        public string Surname { get; set; }

        public int Level { get; set; }
        public int Experience { get; set; }
        public int Crown { get; set; }

        #endregion

        #region Child Properties

        public IList<PlayerCategory> PlayerCategories { get; set; }

        #endregion
    }
}