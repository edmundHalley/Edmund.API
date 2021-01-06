using Edmund.API.Domain.Persistence.Contexts;
using Edmund.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
