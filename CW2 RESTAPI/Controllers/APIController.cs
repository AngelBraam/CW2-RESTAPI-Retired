using Microsoft.AspNetCore.Mvc;
using CW2_RESTAPI.Entities;
using CW2_RESTAPI.Entities.DataHandlers;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;
 

namespace CW2_RESTAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class APIController : ControllerBase
    {
        private readonly IRepository<T> _repository;

        public APIController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet("{Email}", Name = "GetAccount")]
        public IActionResult Get(string Email)
        {
            var account = _repository.Get(Email);
            if (account == null)
            {
                return NotFound("Account not found");
            }
            return Ok(account);
        }

        [HttpPut]
        public IActionResult Delete([FromBody] Admin model, object passwordCheck)
        {
            if (Password != passwordCheck)
            {
                return BadRequest("Incorrect password");
            }
            else
            {
                var account = _repository.Get(Email);
                if (account == null)
                {
                    return NotFound("Account not found");
                }
                else
                {
                    _repository.Delete(account);
                    return Ok("Account deleted");
                }
            }
        }
    }
        }


