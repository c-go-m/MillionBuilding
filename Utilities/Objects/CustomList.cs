namespace Utilities.Objects
{
    public class CustomList<T>
        where T : class, new()
    {
        public IEnumerable<T> List { set; get; }
        public PageList Page { set; get; }

        public CustomList(IEnumerable<T> List, PageList Page)
        {
            this.List = List;
            this.Page = Page;
        }
    }
}
