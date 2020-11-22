using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Domain;
using MonitoringSQLServer.Infrastructure;
using MonitoringSQLServerApp.ActionFilters;

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
        [Obsolete]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Post([FromBody]User user)
        {
            // установить дату создания user
            user.RegDate = DateTime.Now;

            _repositoryWrapper.User.Create(user);
            _repositoryWrapper.Save();

            return Ok(user);
        }

        [HttpPut("{id}")]
        [Obsolete]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Put([FromBody] User updatedUser)
        {
            var user = _repositoryWrapper.User.FindByCondition(x => x.Id == updatedUser.Id);
            if (user == null)
            {
                return NotFound();
            }

            _repositoryWrapper.User.Update(updatedUser);
            _repositoryWrapper.Save();

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repositoryWrapper.User.FindByCondition(x => x.Id == id);
            User deleteUser = user.FirstOrDefault();

            if (deleteUser == null)
            {
                return NotFound();
            }
  
            _repositoryWrapper.User.Delete(deleteUser);
            _repositoryWrapper.Save();

            return Ok(deleteUser);
        }
    }
}
