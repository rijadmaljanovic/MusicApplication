using MusicApplication.Infrastructure.Repositories.Categories;
using MusicApplication.Infrastructure.Repositories.Songs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        //ISongsRepository SongsRepository { get; }
        //ICategoriesRepository CategoriesRepository { get; }
        Task<int> SaveChanges();
    }
}
