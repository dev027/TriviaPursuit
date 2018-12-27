namespace Tp.Service
{
    public class Service
    {
        private CategoryService _category;

        public CategoryService Category => _category ?? (_category = new CategoryService());
    }
}