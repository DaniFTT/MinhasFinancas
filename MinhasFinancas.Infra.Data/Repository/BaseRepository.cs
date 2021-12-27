using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;
using System.Runtime.InteropServices;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : BaseEntity
    {
        private readonly DbContextOptions<Context> _optionsBuilder;
        public BaseRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }

        public async Task Add(T Object)
        {
            using (var data = new Context(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Object);
                await data.SaveChangesAsync();
            }
        }
        public async Task Update(T Object)
        {
            using (var data = new Context(_optionsBuilder))
            {
                data.Set<T>().Update(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(int Id)
        {
            using (var data = new Context(_optionsBuilder))
            {
                var obj = await GetById(Id);
                if (obj != null)
                {
                    data.Set<T>().Remove(obj);
                    await data.SaveChangesAsync();
                }
            }
        }

        public async Task<T?> GetById(int Id)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<IEnumerable<T>> List()
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
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
