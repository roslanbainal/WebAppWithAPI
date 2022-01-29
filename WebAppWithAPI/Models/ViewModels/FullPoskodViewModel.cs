using System.Collections.Generic;

namespace WebAppWithAPI.Models.ViewModels
{
    public class FullPoskodViewModel
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string firstPage { get; set; }
        public string lastPage { get; set; }
        public int totalPages { get; set; }
        public int totalRecords { get; set; }
        public string nextPage { get; set; }
        public string previousPage { get; set; }
        public List<PoskodBandarViewModel> data { get; set; }

    }

    public class PoskodBandarViewModel
    {
        public string poskod { get; set; }
        public string bandar { get; set; }
    }

    public class PoskodRequest
    {
        public string Search { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
