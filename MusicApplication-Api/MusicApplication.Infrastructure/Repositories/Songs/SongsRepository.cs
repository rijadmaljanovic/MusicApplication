using AutoMapper;
using MusicApp.Core.Entities;
using MusicApp.Infrastructure;
using MusicApplication.Core.Models;
using MusicApplication.Infrastructure.Repositories.Base;
using MusicApplication.Requests.Song;
using System.Collections.Generic;
using System.Linq;

namespace MusicApplication.Infrastructure.Repositories.Songs
{
    public class SongsRepository : BaseRepository<SongsModel, SongSearchRequest, Song, SongUpsertRequest, SongUpsertRequest>
    {
        private readonly IMapper _mapper;
        public SongsRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
        {
            _mapper = mapper;
        }
        public override IEnumerable<SongsModel> Get()
        {
            var result = _databaseContext.Song.ToList();

            return _mapper.Map<IEnumerable<SongsModel>>(result);
        }
        public override IEnumerable<SongsModel> Search(SongSearchRequest request)
        {
            var query = _databaseContext.Song.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.SongName))
            {
                query = query.Where(x => x.SongName.Contains(request.SongName));
            }

            return _mapper.Map<IEnumerable<SongsModel>>(query.ToList());
        }

    }
}
