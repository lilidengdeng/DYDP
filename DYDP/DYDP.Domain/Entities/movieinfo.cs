using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DYDP.Domain.Entities
{
    public class movieinfo
    {
        public virtual string moviename { get; set; }
        public virtual string director { get; set; }
        public virtual int movietime { get; set; }
        public virtual string actor { get; set; }
        public virtual string description { get; set; }
        public virtual string poster { get; set; }
        public virtual int price { get; set; }
    }
}
