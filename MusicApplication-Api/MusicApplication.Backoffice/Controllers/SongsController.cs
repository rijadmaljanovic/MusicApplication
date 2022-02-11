using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Entities;
using MusicApp.Infrastructure;
using MusicApplication.Core.Models;
using MusicApplication.Infrastructure.Repositories.Base;
using MusicApplication.Requests.Song;

namespace MusicApplication.Backoffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : BaseController<SongsModel, SongSearchRequest, SongUpsertRequest, SongUpsertRequest>
    {
        public SongsController(IBaseRepository<SongsModel, SongSearchRequest, SongUpsertRequest, SongUpsertRequest> repository) : base(repository)
        {
        }
    }
}
