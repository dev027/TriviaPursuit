using Tp.Models.BaseModels;

namespace Tp.Models.DbEntities
{
    public class Answer : BaseModelWithId
    {
        #region Constructors

        public Answer()
        {
        }
        public Answer(
            string text,
            int questionId,
            bool isCorrect,
            bool isCatchAllAnswer,
            int id = 0)
            :base(id: id)
        {
            Text = text;
            QuestionId = questionId;
            IsCorrect = isCorrect;
            IsCatchAllAnswer = isCatchAllAnswer;
        }

        #endregion

        #region Properties

        public string Text { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsCatchAllAnswer { get; set; }

        #endregion

        #region Parent Properties

        public Question Question { get; set; }

        #endregion

        public enum Include
        {
            None = 0,
            Question = 1 << 0
        }
    }
}