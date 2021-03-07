using System.Collections.Generic;
//using System.Data.Entity.Hierarchy;

namespace Developer.WebApi.FilterEngine
{
    public enum FilterDataModelSearchTypes
    {
        Equal = 0,
        NotEqual = 1,
        LessThan = 2,
        GreaterThan = 3,
        //Between = 4,
        Contains = 5,
        NotContains = 6,
        BeginsWith = 7,
        EndsWith = 8,
        LessThanOrEqualTo = 9,
        GreaterThanOrEqualTo = 10,
        //Any = 10

    }

    public enum ClauseType
    {
        Or = 1,
        And = 2
    }

    public class FilterDataModel
    {
        public FilterDataModel()
        {
            ClauseType = ClauseType.And;
            Filters = new List<FilterDataModel>();
            values = new List<string>();
        }
        public List<FilterDataModel> Filters { get; set; }
        public string PropertyName { get; set; }
        public string PropertyAnyName { get; set; }
        /// <summary>
        /// شرط مابین با شرط قبلی
        /// or / And
        /// </summary>
        public ClauseType ClauseType { get; set; } = ClauseType.And;
        /// <summary>
        /// شرایط با مقدار در حال سرچ
        /// مساوی / مابین/ نا مساوی/ بزرگتر/ کوچیکتر
        /// </summary>
        public FilterDataModelSearchTypes SearchType { get; set; }
        public string value { get; set; }
        public List<string> values { get; set; }
   
        public double? LatitudeValue { get; set; }
        public double? LongitudeValue { get; set; }
        public double? LatitudeLongitudeDistanceValue { get; set; }


    }
}