using System;
using System.Collections.Generic;
using System.Text;
using TheHinhPower.Infrastructure.Interfaces;

namespace TheHinhPower.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        public EFUnitOfWork(AppDBContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
