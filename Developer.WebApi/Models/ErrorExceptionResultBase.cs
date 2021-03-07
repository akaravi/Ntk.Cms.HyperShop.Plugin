using System.Collections.Generic;
using System.Linq;
using Developer.WebApi.Enums;

namespace Developer.WebApi.Models
{

    public class ErrorExceptionResult
    {
        public ErrorExceptionResult()
        {
            IsSuccess = true;
            ErrorType = ResultErrorType.None;
            errors = new Dictionary<string, List<string>>();
        }
        #region Standard Error
        public int Status { get; set; }
        public Dictionary<string, List<string>> errors { get; set; }
        public string Title { get; set; }
        public string traceId { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        public ResultErrorType ErrorType { get; set; }
   
        public string LinkFile { get; set; } = "";

        public bool IsSuccess { get; set; } = true;
        public void errorAdd(string fileName, params ResultErrorType[] errorType)
        {
            if (errors == null)
                errors = new Dictionary<string, List<string>>();
            if (errorType != null)
            {
                List<string> errorsStr = new List<string>();
                foreach (var item in errorType)
                    errorsStr.Add(item.ToString());
                errors.Add(fileName, errorsStr);
            }
        }
        public void errorAdd(string fileName, params string[] errorType)
        {
            if (errors == null)
                errors = new Dictionary<string, List<string>>();
            if (errorType != null)
            {
                errors.Add(fileName, errorType.ToList());
            }
        }
      
    }

}