using Microsoft.AspNetCore.Mvc;
using MusicApplication.Infrastructure.Repositories.Base;
using System;


namespace MusicApplication.Backoffice.Controllers
{
    public class BaseController<T, TSearch, TAdd, TUpdate> : ControllerBase
    {
        private readonly IBaseRepository<T, TSearch, TAdd, TUpdate> _repository = null;

        public BaseController(IBaseRepository<T, TSearch, TAdd, TUpdate> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] TAdd request)
        {
            try
            {
                return Ok(_repository.Add(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody] TUpdate request)
        {
            try
            {
                return Ok(_repository.Update(id, request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_repository.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [Route("search")]
        public IActionResult Search([FromQuery] TSearch request)
        {
            try
            {
                return Ok(_repository.Search(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
