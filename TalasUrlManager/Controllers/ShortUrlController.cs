using System;
using AutoMapper;
using DataAccess;
using DataAccess.Repository;
using DataAccess.Schema;
using Microsoft.AspNetCore.Mvc;
using TalasUrlManager.Models;

namespace TalasUrlManager.Controllers
{
    [Route("api/[controller]")]
    public class ShortUrlController : Controller
    {
        private readonly IRepository<ShortUrlSet> _repo;
        private readonly IMapper _mapper;
        public ShortUrlController(IDbManager dbManager, IMapper mapper)
        {
            _repo = dbManager.Repository<ShortUrlSet>();
            _mapper = mapper;
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
            if (!ModelState.IsValid) return new BadRequestResult();

            data.CreateDate = DateTime.Now;
            data.IsActive = true;

            var entity = _mapper.Map<ShortUrlDto, ShortUrlSet>(data);
            _repo.Create(entity);
            _repo.SaveChanges();

            return Get(entity.Id);
        }

        // PUT api/ShortUrl/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ShortUrlDto data)
        {
            if (!ModelState.IsValid) return;

            var entity = _repo.Read(p => p.Id == id);
            _repo.Update(_mapper.Map(data, entity));
            _repo.SaveChanges();
        }

        // DELETE api/ShortUrl/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(_repo.Read(p => p.Id == id));
            _repo.SaveChanges();
        }
    }
}
