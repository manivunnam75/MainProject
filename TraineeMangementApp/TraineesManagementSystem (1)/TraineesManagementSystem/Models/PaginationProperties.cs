
using System.Drawing.Printing;

namespace TraineesManagementSystem.Models
{
    public class PaginationProperties
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPge { get; set; }
        public PaginationProperties()
        {

        }
        public PaginationProperties(int totalItems,int page,int pageSize)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page; 
            int startPage = currentPage - 2;
            int endPage = currentPage + 2; if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 4)
                {
                    startPage = endPage - 3;
                }
            }
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPge = endPage;
        }
    }
   
}

