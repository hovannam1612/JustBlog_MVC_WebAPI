namespace JustBlog.ViewModel.BaseEntity
{
    public class FilterPaging
    {
        public string Keyword { get; set; } = "";

        public string SearchBy { get; set; } = "";

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 3;

        public string TypeOfSoft { get; set; } = "ASC";
    }
}