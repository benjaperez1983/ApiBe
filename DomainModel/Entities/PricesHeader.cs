using DomainModel.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class PricesHeader : IdEntity
    {
        public string? symbol { get; set; }
        public List<PricesDetail> pricesDetail { get; set; }
    }
}
