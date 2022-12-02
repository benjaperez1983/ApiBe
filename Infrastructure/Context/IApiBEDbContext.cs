using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public interface IApiBEDbContext : IDisposable, IAsyncDisposable
    {
        public DbSet<PricesDetail> PricesDetail { get; set; }
        public DbSet<PricesHeader> PricesHeader { get; set; }
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
