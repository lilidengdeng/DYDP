using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DYDP.Domain.Entities
{
    public class ticketinfo
    {
        public virtual int ticketid { get; set; }
        public virtual string moviename { get; set; }
        public virtual string starttime { get; set; }
        public virtual int seatid { get; set; }
        public virtual int hallid { get; set; }
        public virtual int movietime { get; set; }
        public virtual int price { get; set; }
        public virtual int seller { get; set; }
    }
}
