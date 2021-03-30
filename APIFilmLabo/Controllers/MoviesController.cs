using Api.Labo.DAL.Repositories;
using Api.Labo.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFilmLabo.Models;
using APIFilmLabo.Utils;
using Microsoft.AspNetCore.Authorization;

namespace APIFilmLabo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private MoviesRepository _moviesRepository { get; }
        private PersonRepository _personRepository { get; }
        private CastingRepository _castingRepository { get; }
        public MoviesController(MoviesRepository moviesRepository,PersonRepository personRepository,CastingRepository castingRepository)
        {
            this._moviesRepository = moviesRepository;
            this._personRepository = personRepository;
            this._castingRepository = castingRepository;
        }
        [HttpGet]
        [Authorize("user")]
        public IActionResult GetAll()
        {
            IEnumerable<MoviesEntity> movies = _moviesRepository.GetAll();
            return Ok(movies);
        }
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult GetFullMovieByID(int Id)
        {
            MoviesEntity movieEntity = _moviesRepository.get(Id);
            FullMovieById movie = _moviesRepository.get(Id).ToApi();
            movie.Director = _personRepository.GetAll().Where(p => p.Id == movieEntity.IdDirector).Select(x=>x.ToApi()).SingleOrDefault();
            movie.Writer = _personRepository.GetAll().Where(p => p.Id == movieEntity.IdWriter).Select(x=>x.ToApi()).SingleOrDefault();
            movie.Actor = _moviesRepository.GetActorByFilmID(movieEntity.Id);
            return Ok(movie);
        }
        [HttpPost]
        [Authorize("admin")]
        public IActionResult AddMovies(Movie movie)
        {
            if (movie is null || !ModelState.IsValid) return BadRequest();
            int idMovie = _moviesRepository.Insert(new MoviesEntity()
            {
                Title = movie.Title,
                YearRelease = movie.YearRelease,
                Synopsis = movie.Synopsis,
                IdDirector = movie.IdDirector,
                IdWriter = movie.IdWriter
            });
            foreach (Casting casting in movie.ListCasting)
            {
                casting.IdMovie = idMovie;
                _castingRepository.Insert(new CastingEntity() 
                {
                    IdMovie = casting.IdMovie,
                    IdPerson = casting.IdPerson,
                    RoleCasting = casting.RoleCasting
                });
            }
            return Ok();
        }
        [HttpPut]
        [Authorize("admin")]
        public IActionResult UpdateMovies(MoviesEntity m)
        {
            if (_moviesRepository.get(m.Id) == null) return BadRequest();
            return Ok(_moviesRepository.Update(m));
        }
        [HttpGet("Com/{Id}")]
        [Authorize("user")]
        public IActionResult GetComByMovie(int Id)
        {
            IEnumerable<EntityViewComFilm> listCom = _moviesRepository.GetComByFilmId(Id);
            return Ok(listCom);
        }
    }
}
