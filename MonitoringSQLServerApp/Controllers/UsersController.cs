using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Domain;
using MonitoringSQLServer.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonitoringSQLServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UsersController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _repositoryWrapper.User.FindAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _repositoryWrapper.User.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            //if (string.IsNullOrEmpty(user.Name))
            //{
            //    return BadRequest(new ErrorModel(){ FieldName = "Name", Message = "Empty name"});
            //}
            var validator = new UserValidator();
            var result = validator.Validate(user);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            _repositoryWrapper.User.Create(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repositoryWrapper.User.FindByCondition(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            User deleteUser = user.FirstOrDefault();
            _repositoryWrapper.User.Delete(deleteUser);
            return Ok(deleteUser);
        }

        [HttpPut("{id}")]
        public IActionResult Put(User updatedUser)
        {
            if (updatedUser == null)
            { 
                return BadRequest();
            }

            var user = _repositoryWrapper.User.FindByCondition(x => x.Id == updatedUser.Id);
            if (user == null)
            {
                return NotFound();
            }

            _repositoryWrapper.User.Update(updatedUser);
            return Ok(updatedUser);
        }
    }
}
