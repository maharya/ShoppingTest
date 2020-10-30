using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoalTestBTS.Models
{
    public class Shopping
    {
        private ShoppingContext context;
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
