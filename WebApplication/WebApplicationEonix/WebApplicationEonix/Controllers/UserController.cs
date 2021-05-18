using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplicationEonix.DataAccess;
using WebApplicationEonix.Models;
using WebApplicationEonix.Repositories;

namespace WebApplicationEonix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EonixContext _context;
        private readonly UserRepository _userRepository;

        public UserController(EonixContext context)
        {
            var services = new ServiceCollection();
            var serviceProvider = services.BuildServiceProvider();
            var _uowProvider = new UowProvider(serviceProvider);

            this._context = context;
            this._userRepository = new UserRepository(context, _uowProvider);
        }

        [HttpGet]
        public ActionResult<List<User>> Get(string filter)
        {
            try
            {
                var result = this._userRepository.GetUser(filter);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(string id)
        {
            try
            {
                var result = this._userRepository.GetUserById(id);
                if (result != null)
                    return Ok(result);
                else
                    return StatusCode(404);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User value)
        {
            try
            {
                var result = this._userRepository.PostUser(value);
                if (result != null)
                    return Ok(result);
                else
                    return StatusCode(404);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(string id, [FromBody] User value)
        {
            try
            {
                var result = this._userRepository.PutUser(id, value);
                if (result != null)
                    return Ok(result);
                else
                    return StatusCode(404);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<User> Patch(string id, [FromBody] User value)
        {
            try
            {
                var result = this._userRepository.PatchUser(id, value);
                if (result != null)
                    return Ok(result);
                else
                    return StatusCode(404);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(string id)
        {
            try
            {
                var result = this._userRepository.DeleteUser(id);
                if (result != null)
                    return Ok(result);
                else
                    return StatusCode(404);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }
        }


    }
}
