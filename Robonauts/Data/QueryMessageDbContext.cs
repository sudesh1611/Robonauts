using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Robonauts.Models
{
    public class QueryMessageDbContext : DbContext
    {
        public QueryMessageDbContext (DbContextOptions<QueryMessageDbContext> options)
            : base(options)
        {
        }

        public DbSet<Robonauts.Models.QueryMessage> QueryMessage { get; set; }
    }
}
