using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Entities;
using MusicApp.Infrastructure;
using MusicApplication.Core.Models;
using MusicApplication.Infrastructure.Repositories.Base;
using MusicApplication.Requests.Category;

namespace MusicApplication.Backoffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<CategoriesModel, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        public CategoryController(IBaseRepository<CategoriesModel, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest> repository) : base(repository)
        {
        }
    }
}
