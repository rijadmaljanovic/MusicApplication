using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace MusicApplication.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository<T, TSearch, TDataBase, TAdd, TUpdate> : IBaseRepository<T, TSearch, TAdd, TUpdate> where TDataBase : class
    {
        protected readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        protected BaseRepository(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public virtual T Add([FromBody] TAdd model)
        {
            var entity = _mapper.Map<TDataBase>(model);
            _databaseContext.Set<TDataBase>().Add(entity);
            _databaseContext.SaveChanges();
            return _mapper.Map<T>(entity);
        }

        public virtual IEnumerable<T> Get()
        {
            var list = _databaseContext.Set<TDataBase>().ToList();
            return _mapper.Map<IEnumerable<T>>(list);
        }

        public virtual T GetById(int id)
        {
            var entity = _databaseContext.Set<TDataBase>().Find(id);
            return _mapper.Map<T>(entity);
        }
        public virtual T Update(int id, [FromBody] TUpdate model)
        {
            var entity = _databaseContext.Set<TDataBase>().Find(id);
            _mapper.Map(model, entity);
            _databaseContext.SaveChanges();
            return _mapper.Map<T>(entity);
        }
        public virtual T Delete(int id)
        {
            var entity = _databaseContext.Set<TDataBase>().Find(id);
            _databaseContext.Set<TDataBase>().Remove(entity);
            _databaseContext.SaveChanges();
            return _mapper.Map<T>(entity);
        }
        public virtual IEnumerable<T> Search(TSearch request)
        {
            var list = _databaseContext.Set<TDataBase>().ToList();
            return _mapper.Map<IEnumerable<T>>(list);
        }
     
    }
}
