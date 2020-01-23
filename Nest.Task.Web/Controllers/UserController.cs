using Nest.Task.Web.Aggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Nest.Task.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly DashBoardAggregator _dashBoardAggregator;
        public UserController()
        {
            _dashBoardAggregator = new DashBoardAggregator();
        }
        // GET: User
        public async Task<ActionResult> Index(string id)
        {
            var userDetails = await _dashBoardAggregator.GetUserDetails(id);
            return View(userDetails);
        }
    }
}