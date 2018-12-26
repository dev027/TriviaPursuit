using Tp.Models.BaseModels;

namespace Tp.Models.DbEntities
{
    public class PlayerCategory: BaseModelWithId
    {
        #region Constructors

        public PlayerCategory()
        {
            
        }

        public PlayerCategory(
            int playerId,
            int categoryId,
            int questionsAsked,
            int questionsCorrect,
            int id = 0)
            : base(id: id)
        {
            PlayerId = playerId;
            CategoryId = categoryId;
            QuestionsAsked = questionsAsked;
            QuestionsCorrect = questionsCorrect;
        }

        #endregion

        #region Properties

        public int PlayerId { get; set; }
        public int CategoryId { get; set; }
        public int QuestionsAsked { get; set; }
        public int QuestionsCorrect { get; set; }

        #endregion

        #region Parent Properties

        public Player Player { get; set; }
        public Category Category { get; set; }

        #endregion
    }
}