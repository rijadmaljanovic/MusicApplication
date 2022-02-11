using MusicApp.Infrastructure;
using MusicApplication.Infrastructure.Repositories.Categories;
using MusicApplication.Infrastructure.Repositories.Songs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _databaseContext;

        //private ISongsRepository _songsRepository;
        //public ISongsRepository SongsRepository => _songsRepository ??= new SongsRepository(_databaseContext);

        //private ICategoriesRepository _categoriesRepository;
        //public ICategoriesRepository CategoriesRepository => _categoriesRepository ??= new CategoriesRepository(_databaseContext);
        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<int> SaveChanges()
        {
            return await _databaseContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _databaseContext?.Dispose();
        }
    }
}
