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
    [RoutePrefix("api/v1/DashBoard")]
    public class HomeController : ApiController
    {
        IAlbumService _albumService;
        public HomeController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet]
        [Route("Albums/{PageNumber}/{searchText?}")]
        public async Task<AlbumViews> GetAllAlbums( int PageNumber, string searchText = null)
        {
            return await _albumService.GetAllAlbums(searchText, PageNumber);
        }
        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return "Hello World";
        }

    }
}
