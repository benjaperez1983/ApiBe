using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities.Contracts
{
    public abstract class IdEntity
    {
        [Key]
        public Guid guid { get; set; }
        public DateTime? created { get; set; } 
    }
}
