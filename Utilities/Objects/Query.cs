using static Utilities.Utilities.Enumerations;

namespace Utilities.Objects
{
    public class Query
    {
        public List<ItemFilter> Filters { set; get; }
        public ItemSort Sort { set; get; }
        public ItemPage Page { set; get; }
    }

    public class ItemSort
    {        
        public string Name { set; get; }        
        public string Direction { set; get; }
    }

    public class ItemFilter
    {        
        public string Name { set; get; }

        public object Value { set; get; }
        
        public FilterOperation Operator { set; get; }        
    }

    public class ItemPage
    {
        public int Page { set; get; }
        public int PageSize { set; get; }
    }
}
