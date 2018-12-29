namespace Tp.Service
{
    public class Service
    {
        private CategoryService _category;
        private QuestionService _question;

        public CategoryService Category => _category ?? (_category = new CategoryService());
        public QuestionService Question => _question ?? (_question = new QuestionService());
    }
}