namespace Katlen.WEB.ViewModels
{
    public class PageViewModel
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public List<int> Pages { get; private set; }

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            InitPagesList();
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

        public void InitPagesList()
        {
            if(TotalPages < 5)
            {
                Pages = new();
                for(int i = 1; i <= TotalPages; i++)
                {
                    Pages.Add(i);
                }
            }
            else
            {
                InitPagesNumbers(PageNumber);
            }
        }

        public void InitPagesNumbers(int pageNumber)
        {
            if (pageNumber == 1)
            {
                Pages = new() { pageNumber, pageNumber + 1, pageNumber + 2, pageNumber + 3, pageNumber + 4 };
            }
            else if (pageNumber == 2)
            {
                Pages = new() { pageNumber - 1, pageNumber, pageNumber + 1, pageNumber + 2, pageNumber + 3 };
            }
            else if (pageNumber == TotalPages)
            {
                Pages = new() { pageNumber - 4, pageNumber - 3, pageNumber - 2, pageNumber - 1, pageNumber };
            }
            else if (pageNumber == TotalPages - 1)
            {
                Pages = new() { pageNumber - 3, pageNumber - 2, pageNumber - 1, pageNumber, pageNumber + 1 };
            }
            else
            {
                Pages = new() { pageNumber - 2, pageNumber - 1, pageNumber, pageNumber + 1, pageNumber + 2 };
            }
        }
    }
}
