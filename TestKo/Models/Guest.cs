using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestKo.Models
{
    public class Guest
    {
        public string Name { get; set; }
        public StateCode State { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}