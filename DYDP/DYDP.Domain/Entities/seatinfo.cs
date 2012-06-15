using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DYDP.Domain.Entities
{
    public class seatinfo
    {
        public virtual int totalid { get; set; }
        public virtual int seatid { get; set; }
        public virtual int hallid { get; set; }
        public virtual Boolean available { get; set; }
    }
}
