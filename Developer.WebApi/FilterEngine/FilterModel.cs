using System.Collections.Generic;
//using System.Data.Entity.Hierarchy;
namespace Developer.WebApi.FilterEngine
{

    public class FilterModel
    {
        public FilterModel()
        {
            Includes = new List<string>();
            Filters = new List<FilterDataModel>();
            ExportFile = new ExportFileModel();
        }
        public List<string> Includes { get; set; }
        public List<FilterDataModel> Filters { get; set; }
        public bool Count { get; set; } = false;
        public ExportFileModel ExportFile { get; set; }

        public long TotalRowData { get; set; }
        public int SkipRowData { get; set; } = 0;

        private int _privateCurrentPageNumber { get; set; }
        public int CurrentPageNumber
        {
            set
            {
                _privateCurrentPageNumber = value;
                if (_privateCurrentPageNumber < 1)
                    _privateCurrentPageNumber = 1;
            }
            get { return _privateCurrentPageNumber; }
        }
        private int privateRowPerPage { get; set; }
        public int RowPerPage
        {
            get
            {
                if (privateRowPerPage <= 0)
                    privateRowPerPage = 20;
                return privateRowPerPage;
            }
            set
            {
                privateRowPerPage = value;
            }
        }
        public SortType SortType { get; set; } = SortType.Descending;

        private string privateSortColumn;
        public string SortColumn
        {
            get
            {
                //if (string.IsNullOrEmpty(privateSortColumn) || string.IsNullOrEmpty(privateSortColumn.Trim()))
                //    privateSortColumn = "Id";
                return privateSortColumn;
            }
            set
            {
                privateSortColumn = value;

            }
        }

  
       

    }


}