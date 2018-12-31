using System.Collections.Generic;
using Tp.Models.DbEntities;

namespace Tp.Service
{
    public class QuestionService
    {
        public void Create(
            int categoryId,
            string questionText, 
            string correctAnswerText,
            string wrongAnswer1Text,
            string wrongAnswer2Text,
            string wrongAnswer3Text,
            int allNone)
        {
            using (var data = new Data.Data())
            {
                var question = new Question(questionText, categoryId);
                var correctAnswer = new Answer(correctAnswerText, true, allNone == 1);
                var wrongAnswer1 = new Answer(wrongAnswer1Text, false, allNone == 2);
                var wrongAnswer2 = new Answer(wrongAnswer2Text, false, allNone == 3);
                var wrongAnswer3 = new Answer(wrongAnswer3Text, false, allNone == 4);

                question.Answers = new List<Answer>()
                {
                    correctAnswer,
                    wrongAnswer1,
                    wrongAnswer2,
                    wrongAnswer3
                };

                data.Question.Add(question);
            }
        }
    }
}