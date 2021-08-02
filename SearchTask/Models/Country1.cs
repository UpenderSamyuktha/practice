using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchTask.Models
{
    public class Country1
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<State1> States { get; set; }

    }
}