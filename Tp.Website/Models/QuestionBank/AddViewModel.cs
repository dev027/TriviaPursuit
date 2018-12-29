using Tp.Common.Constants;
using Tp.Common.Extensions.CheeseColourExtensions;
using Tp.Models.DbEntities;
using Tp.Website.Models.Shared;

namespace Tp.Website.Models.QuestionBank
{
    public class AddViewModel
    {
        public AddViewModel(
            ContentHeaderViewModel contentHeaderViewModel,
            int categoryId,
            string categoryName,
            CheeseColour cheeseColour)
        {
            ContentHeaderViewModel = contentHeaderViewModel;
            CategoryId = categoryId;
            CategoryName = categoryName;
            IconClass = cheeseColour.ToIconClass();
            BackgroundColourClass = cheeseColour.ToBackgroundColourClass();
            BackgroundDarkColourClass = cheeseColour.ToBackgroundDarkColourClass();
            BorderColourClass = cheeseColour.ToBorderColourClass();
        }

        public ContentHeaderViewModel ContentHeaderViewModel { get; }

        public int CategoryId { get; }
        public string CategoryName { get; }
        public string IconClass { get; }
        public string BackgroundColourClass { get; }
        public string BackgroundDarkColourClass { get; }
        public string BorderColourClass { get; }


        public static AddViewModel Create(Category category)
        {
            return new AddViewModel(
                new ContentHeaderViewModel($"Add {category.Name} Question"),
                category.Id,
                category.Name,
                category.CheeseColour);
        }
    }
}