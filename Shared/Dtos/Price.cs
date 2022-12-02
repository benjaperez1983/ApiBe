using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class Price
    {
        public int? date { get; set; }
        public double? open { get; set; }
        public double? high { get; set; }
        public double? low { get; set; }
        public double? close { get; set; }
        public int? volume { get; set; }
        public double? adjclose { get; set; }
        public double? amount { get; set; }
        public string? type { get; set; }
        public double? data { get; set; }
    }
}
