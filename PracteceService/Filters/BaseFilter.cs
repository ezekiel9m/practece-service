using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Filters
{
    public class BaseFilter
    {

        public DateTime? CreateDateStart { get; set; }

        public DateTime? CreateDateEnd { get; set; }

        public DateTime? UpdateDateStart { get; set; }

        public DateTime? UpdateDateEnd { get; set; }

        public bool? IsActive { get; set; }

        private string _orderDir = "desc";

        public string OrderDir
        {
            get
            {
                return _orderDir;
            }
            set
            {
                _orderDir = string.IsNullOrEmpty(value) ? "desc" : value;
            }
        }

        private string _orderField = "create_date";

        public string OrderField
        {
            get
            {
                return _orderField;
            }
            set
            {
                _orderField = string.IsNullOrEmpty(value) ? "create_date" : value;
            }
        }
    }
}
