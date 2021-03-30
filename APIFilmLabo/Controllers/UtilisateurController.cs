using Api.Labo.DAL.Entities;
using Api.Labo.DAL.Repositories;
using APIFilmLabo.Models;
using APIFilmLabo.TokenJWT;
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
    public class UtilisateurController : Controller
    {
        private UtilisateurRepository _utilisateurRepository { get; }
        private TokenManager TokenManager { get; }
        public UtilisateurController(UtilisateurRepository utilisateurRepository,TokenManager tokenManager)
        {
            this._utilisateurRepository = utilisateurRepository;
            TokenManager = tokenManager;
        }
        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            IEnumerable<UtilisateurEntity> users = _utilisateurRepository.GetAll();
            return Ok(users);
        }
        [HttpGet("{Id}")]
        [Authorize("admin")]
        public IActionResult GetByID(Guid Id)
        {
            return Ok(_utilisateurRepository.get(Id));
        }
        [HttpPost]
        public IActionResult AddUser(Utilisateur user)
        {
            if (user is null || !ModelState.IsValid) return BadRequest();
            _utilisateurRepository.Insert(new UtilisateurEntity()
            { 
                Email = user.Email,
                Pseudo = user.Pseudo,
                Birthdate = user.Birthdate,
                Password = user.Password
            });
            return Ok();
        }
        [HttpPut]
        [Authorize("user")]
        public IActionResult UpdateUtilisateur(UtilisateurUpdate u)
        {
            if (_utilisateurRepository.get(u.Id) == null) return BadRequest();
            return Ok(_utilisateurRepository.Update(new UtilisateurEntity()
            {
                Pseudo = u.Pseudo,
                Id = u.Id,
                Birthdate = u.Birthdate
            }));
        }
        [HttpPut("password/{Id}")]
        [Authorize("user")]
        public IActionResult UpdatePassword(UtilisateurUpdatePassword u)
        {
            if (_utilisateurRepository.get(u.Id) == null) return BadRequest();
            return Ok(_utilisateurRepository.Update(new UtilisateurEntity()
            {
                Id = u.Id,
                Password=u.Password
            }));
        }
        [HttpPost("Login")]
        public IActionResult Login(UtilisateurLogin user)
        {
            if (user is null || !ModelState.IsValid) return BadRequest();
            UtilisateurEntity utilisateur = _utilisateurRepository.Login(user.Email, user.Password);
            if (utilisateur is null) return new ForbidResult();
            return Ok(TokenManager.GenerateJWT(utilisateur));
        }
        [HttpPut("switchA")]
        [Authorize("admin")]
        public IActionResult SwitchAdmin(UtilisateurSwitch u)
        {
            UtilisateurEntity user = _utilisateurRepository.get(u.Id);
            return Ok(_utilisateurRepository.SwitchAdmin(user.Id));
        }
        [HttpPut("switchB")]
        [Authorize("admin")]
        public IActionResult SwitchBan(UtilisateurSwitch u)
        {
            UtilisateurEntity user = _utilisateurRepository.get(u.Id);
            return Ok(_utilisateurRepository.SwitchBan(user.Id));
        }
    }
}
