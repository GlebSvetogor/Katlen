namespace Katlen.WEB.ViewModels
{
    public class PageViewModel
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public List<int> Pages {get; private set; }

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Pages = new();
            Pages.Add(pageNumber - 2); Pages.Add(pageNumber - 1); Pages.Add(pageNumber); Pages.Add(pageNumber + 1); Pages.Add(pageNumber + 2);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
    }
}
