namespace Utilities.Objects
{
    public class PageList
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int MaxCount { get; set; }

        public PageList(ItemPage page, int maxCount)
        {
            this.Page = page.Page;
            this.PageSize = page.PageSize;
            this.TotalPages = (int)Math.Ceiling((double)maxCount / page.PageSize);
            this.MaxCount = maxCount;
        }

    }
}
