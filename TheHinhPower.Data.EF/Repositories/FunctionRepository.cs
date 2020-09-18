using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheHinhPower.Data.Entities;
using TheHinhPower.Data.IRepositories;

namespace TheHinhPower.Data.EF.Repositories
{
    public class FunctionRepository : EFRepository<Function, string>, IFunctionRepository
    {
        private AppDBContext _context;
        private IHttpContextAccessor _httpContextAccessor;

        public FunctionRepository(AppDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQueryable GetAllByOrder()
        {
            return _context.Functions.OrderBy(f => f.SortOrder);
        }
    }
}
