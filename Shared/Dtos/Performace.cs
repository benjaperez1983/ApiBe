using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class Performance
    {
        public string symbol { get; set; }
        public DateTime date { get; set; }
        public double close { get; set; }
        public double percent { get; set; }

    }
}
