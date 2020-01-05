using System;
using System.Collections.Generic;
using System.Text;

namespace FormDataKVPCreator.Models
{
    public class ReferenceToAnotherObject:ICloneable
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal decimal_value { get; set; }

        public ReferenceToAnotherObject reference { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
