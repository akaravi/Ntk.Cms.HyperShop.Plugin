using System;
using System.Collections.Generic;

namespace Developer.WebApi.Models
{
    public class ErrorExceptionResult<T> : ErrorExceptionResult where T : class//, new()
    {
        public ErrorExceptionResult()
        {
            try
            {
                ListItems = new List<T>();
                Item = Activator.CreateInstance<T>();
            }
            catch
            {

            }
        }
        public IList<T> ListItems { get; set; }
        public T Item { get; set; }
        public int CurrentPageNumber { get; set; }
        public long TotalRowCount { get; set; }
        public int RowPerPage { get; set; }
        
    }
}
