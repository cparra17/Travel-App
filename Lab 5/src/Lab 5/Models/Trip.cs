using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5.Models
{
    public class Trip
    {
        public int TripID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public ICollection Stops { get; set; }
    }
}
