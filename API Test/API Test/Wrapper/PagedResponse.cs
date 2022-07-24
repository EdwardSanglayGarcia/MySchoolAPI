namespace API_Test.Wrapper
{
    public class PagedResponse
    {
        private int MAX_ITEMS_PER_PAGE = 5;

        private int itemsPerPage;
        public int ItemsPerPage 
        {
            get
            {

                return itemsPerPage > MAX_ITEMS_PER_PAGE ? MAX_ITEMS_PER_PAGE : itemsPerPage;
                //if (itemsPerPage > MAX_ITEMS_PER_PAGE)
                //{
                //    return MAX_ITEMS_PER_PAGE;
                //}
                //else
                //{
                //    return itemsPerPage;    
                //}
            }
            set
            {
                itemsPerPage = value;
            }
        }
        public int Page { get; set; }

    }
}
