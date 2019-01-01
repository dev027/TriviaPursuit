using System.ComponentModel.DataAnnotations;

namespace Tp.Website.Models
{
    public class AddQuestionPostModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a question")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Please enter a correct answer")]
        public string CorrectAnswer { get; set; }

        [Required(ErrorMessage = "Please enter a 1st wrong answer")]
        public string WrongAnswer1 { get; set; }

        [Required(ErrorMessage = "Please enter a 2nd wrong answer")]
        public string WrongAnswer2 { get; set; }

        [Required(ErrorMessage = "Please enter a 3rd wrong answer")]
        public string WrongAnswer3 { get; set; }

        public int AllNone { get; set; }
    }

}