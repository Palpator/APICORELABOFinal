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
    public class CommentariesController : Controller
    {
        private CommentariesRepository _commentariesRepository { get; }
        public CommentariesController(CommentariesRepository commentariesRepository)
        {
            this._commentariesRepository = commentariesRepository;
        }
        [HttpGet]
        [Authorize("user")]
        public IActionResult GetAll()
        {
            IEnumerable<CommentariesEntity> comments = _commentariesRepository.GetAll();
            return Ok(comments);
        }
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult GetByID(int Id)
        {
            return Ok(_commentariesRepository.get(Id));
        }
        [HttpPost]
        [Authorize("user")]
        public IActionResult AddComments(Commentary comment)
        {
            if (comment is null || !ModelState.IsValid) return BadRequest();
            _commentariesRepository.Insert(new CommentariesEntity() 
            { 
                Content = comment.Content,
                IdMovie = comment.IdMovie,
                IdUtilisateur = comment.IdUser
            });
            return Ok();
        }
        [HttpPut]
        [Authorize("user")]
        public IActionResult UpdateComments(CommentariesUpdateMessage comment)
        {
            //verif si c'est le user qui a ecrit le com
            if (_commentariesRepository.get(comment.ID) == null) return BadRequest();
            return Ok(_commentariesRepository.Update(new CommentariesEntity()
            {
                Id = comment.ID,
                Content = comment.Content
            }));
        }
        [HttpPut("{Id}")]
        [Authorize("admin")]
        public IActionResult UpdateStateComments(int Id)
        {
            if (_commentariesRepository.get(Id) == null) return BadRequest();
            return Ok(_commentariesRepository.SwitchStateMessage(Id));
        }
        [HttpDelete("{Id}")]
        [Authorize("admin")]
        public IActionResult DeleteComments(int Id)
        {
            if (_commentariesRepository.get(Id) == null) return BadRequest();
            return Ok(_commentariesRepository.Delete(Id));
        }
    }
}
