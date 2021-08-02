using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchTask.Models
{
    public class State1
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public List<City1> Cities { get; set; }
    }
}