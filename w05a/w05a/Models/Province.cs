using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace w05a.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string ProvCode { get; set; }
        public string ProvName { get; set; }
        public ICollection<City>  Cities  { get; set; }

    }
}