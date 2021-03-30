using Api.Labo.DAL.Entities;
using Api.Labo.DAL.Repositories;
using APIFilmLabo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastingController : Controller
    {
        private CastingRepository _castingRepository { get; }
        public CastingController(CastingRepository castingRepository)
        {
            this._castingRepository = castingRepository;
        }
        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            IEnumerable<CastingEntity> castings = _castingRepository.GetAll();
            return Ok(castings);
        }
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult GetByID(int Id)
        {
            return Ok(_castingRepository.get(Id));
        }
        [HttpPost]
        [Authorize("admin")]
        public IActionResult AddCasting(Casting casting)
        {
            if (casting is null || !ModelState.IsValid) return BadRequest();
            _castingRepository.Insert(new CastingEntity()
            {
                IdMovie= casting.IdMovie,
                IdPerson = casting.IdPerson,
                RoleCasting = casting.RoleCasting 
            });
            return Ok();
        }
        [HttpPut]
        [Authorize("admin")]
        public IActionResult UpdateCasting (CastingEntity c)
        {
            if (_castingRepository.get(c.Id) == null) return BadRequest();
            return Ok(_castingRepository.Update(c));
        }
    }
}
