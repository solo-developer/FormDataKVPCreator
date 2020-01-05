using System;
using System.Collections.Generic;
using System.Text;

namespace FormDataKVPCreator.Models
{
    public class Basic
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal decimal_value { get; set; }

        public List<int> int_values { get; set; } = new List<int>();
    }
}
