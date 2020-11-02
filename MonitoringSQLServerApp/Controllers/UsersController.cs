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
        public IEnumerable<string> Get()
        {
            var users = _repositoryWrapper.User.FindAll();

            return new string[] { "value-1", "value-2" };
        }

        //ApplicationContext db;
        //public UsersController(ApplicationContext context)
        //{
        //    db = context;
        //    if (!db.Users.Any())
        //    {
        //        db.Users.Add(new User { Name = "Tom"} );
        //        db.Users.Add(new User { Name = "Alice"} );
        //        db.SaveChanges();
        //    }
        //}

        // GET: api/<UserController>
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> Get()
        //{
        //    return await db.Users.ToListAsync();
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> Get(int id)
        //{
        //    User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
        //    if (user == null)
        //        return NotFound();
        //    return new ObjectResult(user);
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public async Task<ActionResult<User>> Post(User user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }

        //    db.Users.Add(user);
        //    await db.SaveChangesAsync();
        //    return Ok(user);
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult<User>> Put(User user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (!db.Users.Any(x => x.Id == user.Id))
        //    {
        //        return NotFound();
        //    }

        //    db.Update(user);
        //    await db.SaveChangesAsync();
        //    return Ok(user);
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> Delete(int id)
        //{
        //    User user = db.Users.FirstOrDefault(x => x.Id == id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    await db.SaveChangesAsync();
        //    return Ok(user);
        //}
    }
}
