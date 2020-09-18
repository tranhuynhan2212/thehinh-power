using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TheHinhPower.Infrastructure;
using TheHinhPower.Infrastructure.SharedKernel;

namespace TheHinhPower.Data.EF
{
    public class EFRepository<T, K> : IRepository<T, K>, IDisposable where T : DomainEntity<K>
    {
        private readonly AppDBContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public EFRepository(AppDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentUser(ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "UserId");
            return Guid.TryParse(claim.Value, out Guid newGuild) ? newGuild : Guid.Empty;
        }

        public void Add(T entity)
        {
            var userId = GetCurrentUser(httpContextAccessor.HttpContext.User);
            entity.UserCreated = userId;
            entity.UserModified = userId;
            entity.DateCreated = DateTime.Now;
            entity.DateModified = DateTime.Now;
            entity.IsDeleted = false;
            _context.Add(entity);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(i => i.IsDeleted == false);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate).Where(i => i.IsDeleted == false);
        }

        public IQueryable<T> FindAllWithPaging(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(filter).Where(i => i.IsDeleted == false);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return await items.Where(filter).Where(i => i.IsDeleted == false).ToListAsync();
        }

        public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id) && x.IsDeleted == false);
        }

        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).Where(x => x.IsDeleted == false).SingleOrDefault(predicate);
        }

        public void Remove(T entity)
        {
            var userId = GetCurrentUser(httpContextAccessor.HttpContext.User);
            entity.UserModified = userId;
            entity.DateModified = DateTime.Now;
            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
            _context.Entry<T>(entity).Property(x => x.UserCreated).IsModified = false;
            _context.Entry<T>(entity).Property(x => x.DateCreated).IsModified = false;
            _context.Set<T>().Update(entity);
        }

        public void Remove(K id)
        {
            T entity = FindById(id);
            var userId = GetCurrentUser(httpContextAccessor.HttpContext.User);
            entity.UserModified = userId;
            entity.DateModified = DateTime.Now;
            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
            _context.Entry<T>(entity).Property(x => x.UserCreated).IsModified = false;
            _context.Entry<T>(entity).Property(x => x.DateCreated).IsModified = false;
            _context.Set<T>().Update(entity);
        }

        public void RemoveMultiple(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            var userId = GetCurrentUser(httpContextAccessor.HttpContext.User);
            entity.UserModified = userId;
            entity.DateModified = DateTime.Now;
            _context.Set<T>().Update(entity);
            _context.Entry<T>(entity).Property(x => x.UserCreated).IsModified = false;
            _context.Entry<T>(entity).Property(x => x.DateCreated).IsModified = false;
        }

        public void UpdateRange(List<T> entity)
        {
            foreach (var item in entity)
            {
                item.UserModified = GetCurrentUser(httpContextAccessor.HttpContext.User);
                item.DateModified = DateTime.Now;
                _context.Set<T>().UpdateRange(item);
                _context.Entry<T>(item).Property(x => x.UserCreated).IsModified = false;
                _context.Entry<T>(item).Property(x => x.DateCreated).IsModified = false;
            }
        }
    }
}
