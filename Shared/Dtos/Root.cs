using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class Root
    {
        public string? symbol { get; set; }
        public List<Price> prices { get; set; }
    }
}
