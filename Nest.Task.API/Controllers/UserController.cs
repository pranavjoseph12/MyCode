using Nest.Task.Domain.Interfaces;
using Nest.Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Nest.Task.API.Controllers
{
    [RoutePrefix("api/v1/User")]
    public class UserController : ApiController
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("Details/{userId}")]
        public async Task<UserView> GetAllAlbums(int userId)
        {
            return await _userService.GetUserDetails(userId);
        }
    }
}
