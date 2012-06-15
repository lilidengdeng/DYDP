using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DYDP.Domain.Entities
{
    public class schedule
    {
        public virtual string scheduleid { get; set; }
        public virtual string date { get; set; }
        public virtual string moviename { get; set; }
        public virtual int hallid { get; set; }
        public virtual string starttime { get; set; }
    }
}
