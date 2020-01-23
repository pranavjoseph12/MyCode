using Nest.Task.Web.Aggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace Nest.Task.Web.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly DashBoardAggregator _dashBoardAggregator;
        public DashBoardController()
        {
            _dashBoardAggregator = new DashBoardAggregator();
        }
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Search(string term, int pageNumber)
        {
            var albums =  await _dashBoardAggregator.GetAllAlbums(term, pageNumber);
            return View("SearchResults", albums);
        }
       
    }
}