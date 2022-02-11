using AutoMapper;
using MusicApp.Core.Entities;
using MusicApplication.Core.Models;
using MusicApplication.Requests.Category;
using MusicApplication.Requests.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Backoffice.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Song, SongsModel>().ReverseMap();
            CreateMap<Song, SongUpsertRequest>().ReverseMap();
            CreateMap<SongsModel, SongSearchRequest>().ReverseMap();

            CreateMap<Category, CategoriesModel>().ReverseMap();
            CreateMap<Category, CategoryUpsertRequest>().ReverseMap();
            CreateMap<CategoriesModel, CategorySearchRequest>().ReverseMap();
        }

    }
}
