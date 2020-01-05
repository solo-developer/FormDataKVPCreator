using System;
using System.Collections.Generic;
using System.Text;

namespace FormDataKVPCreator.Models
{
    public class ChildCollection : ICloneable
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal decimal_value { get; set; }

        public List<ChildCollection> collections { get; set; } = new List<ChildCollection>();

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
