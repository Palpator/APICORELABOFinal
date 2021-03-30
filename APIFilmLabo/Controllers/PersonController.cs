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
    public class PersonController : Controller
    {
        private PersonRepository _personRepository { get; }
        public PersonController(PersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }
        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            IEnumerable<PersonEntity> persons = _personRepository.GetAll();
            return Ok(persons);
        }
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult GetByID(int Id)
        {
            PersonEntity person = _personRepository.get(Id);
            FullPersonById personFull = new FullPersonById()
            {
                Id = person.Id,
                LastName = person.LastName,
                FirstName = person.FirstName
            };
            personFull.ListFilmsActor = _personRepository.GetFilmsByIDActors(Id);
            personFull.ListFilmsDirector = _personRepository.GetFilmsByIDDirector(Id);
            personFull.ListFilmsWriter = _personRepository.GetFilmsByIDWriter(Id);
            return Ok(personFull);
        }
        [HttpPost]
        [Authorize("admin")]
        public IActionResult AddPerson(Person person)
        {
            if (person is null || !ModelState.IsValid) return BadRequest();
            _personRepository.Insert(new PersonEntity()
            {
                LastName = person.LastName,
                FirstName = person.FirstName,
            });
            return Ok();
        }
        [HttpPut]
        [Authorize("admin")]
        public IActionResult UpdatePerson(PersonEntity m)
        {
            if (_personRepository.get(m.Id) == null) return BadRequest();
            return Ok(_personRepository.Update(m));
        }
    }
}
