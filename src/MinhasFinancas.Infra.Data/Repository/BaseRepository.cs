using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : BaseEntity
    {
        private readonly DbContextOptions<DataContext> _optionsBuilder;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly string _currentUserId;

        public BaseRepository()
        {
            _optionsBuilder = new DbContextOptions<DataContext>();
            _httpContextAccessor = new HttpContextAccessor();
            _currentUserId = GetCurrentUserId();
        }

        public virtual async Task Add(T Object)
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Object);
                await data.SaveChangesAsync();
            }
        }
        public virtual async Task Update(T Object)
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                data.Set<T>().Update(Object);
                await data.SaveChangesAsync();
            }
        }

        public virtual async Task Delete(T obj)
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                if (obj != null)
                {
                    data.Set<T>().Remove(obj);
                    await data.SaveChangesAsync();
                }
            }
        }

        public virtual async Task<T?> GetById(int Id)
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                //var queries = Enumerable.Empty<T>().AsQueryable();
                //queries..Where(x => x.Id == Id);
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public virtual async Task<IEnumerable<T>> List()
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }
        public string GetCurrentUserId()
        {
            var identity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var result = string.Empty;

            if (identity?.IsAuthenticated ?? false)
            {
                result = identity?.FindFirst("userId")?.Value;
            }

            return result ?? string.Empty;
        }

        #region IDisposable
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;

        }
        #endregion
    }
}
