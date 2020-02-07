using System;
using AutoMapper;
using DataAccess.Common;
using DataAccess.Database;
using DataAccess.Database.Schema;
using Microsoft.AspNetCore.Mvc;
using TalasUrlManager.Models;
using Utility;

namespace TalasUrlManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortUrlController : ControllerBase
    {
        private readonly IRepository<ShortUrlSet> _repo;
        private readonly IMapper _mapper;
        private readonly IUtilityService _utility;

        public ShortUrlController(IDbManager dbManager, IMapper mapper, IUtilityService utility)
        {
            _repo = dbManager.Repository<ShortUrlSet>();
            _mapper = mapper;
            _utility = utility;
        }

        // GET api/ShortUrl
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_repo.Read());
        }

        // GET api/ShortUrl/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_repo.Read(p => p.Id == id));
        }

        // POST api/ShortUrl
        [HttpPost]
        public IActionResult Post([FromBody]ShortUrlDto data)
        {
            if (!ModelState.IsValid) return BadRequest();

            data.CreateDate = DateTime.Now;
            data.IsActive = true;

            var entity = _mapper.Map<ShortUrlDto, ShortUrlSet>(data);
            _repo.Create(entity);
            _repo.SaveChanges();

            entity.ShortUrl = _utility.ParseToCardinal(entity.Id);
            _repo.SaveChanges();

            return Get(entity.Id);
        }

        // PUT api/ShortUrl/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ShortUrlDto data)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = _repo.Read(p => p.Id == id);
            _repo.Update(_mapper.Map(data, entity));
            _repo.SaveChanges();

            return Get(entity.Id);
        }

        // DELETE api/ShortUrl/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(_repo.Read(p => p.Id == id));
            _repo.SaveChanges();

            return Accepted();
        }
    }
}
