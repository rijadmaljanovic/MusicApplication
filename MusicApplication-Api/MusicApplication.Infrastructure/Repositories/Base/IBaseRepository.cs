using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication.Infrastructure.Repositories.Base
{
    public interface IBaseRepository<T, TSearch, TAdd, TUpdate>
    {
        T Add(TAdd model);
        IEnumerable<T> Get();
        T GetById(int id);
        T Update(int id, TUpdate model);
        T Delete(int id);
        IEnumerable<T> Search(TSearch request);

    }
}
