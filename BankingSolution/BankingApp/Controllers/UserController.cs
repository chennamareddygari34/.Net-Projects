﻿using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace BankAcountEstatementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("Login")]
        public ActionResult Login(UserDTO userDTO)
        {
            var result = _service.Login(userDTO);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        [HttpPost("Register")]
        public ActionResult Register(UserDTO userDTO)
        {
            var result = _service.Register(userDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
