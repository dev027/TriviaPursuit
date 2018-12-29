namespace Tp.Website.Models.Shared
{
    public class ContentHeaderViewModel
    {
        public ContentHeaderViewModel(string title)
        {
            Title = title;
        }
        public string Title { get; }
    }
}