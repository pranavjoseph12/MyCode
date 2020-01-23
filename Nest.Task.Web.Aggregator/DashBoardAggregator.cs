using Nest.Task.Model;
using Nest.Task.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.Task.Web.Aggregator.Helper;
namespace Nest.Task.Web.Aggregator
{
    public class DashBoardAggregator
    {
        readonly string apiUrl;
        public DashBoardAggregator()
        {
            apiUrl = ConfigurationHelper.BaseUrl;
        }
        public async Task<AlbumViews> GetAllAlbums(string searchTerm,int pageNumber)
        {
            var searchUrl = $"{apiUrl}DashBoard/Albums/{pageNumber}/{searchTerm}";
            var albums = await RestUtility.CallServiceAsync<AlbumViews>(searchUrl, string.Empty, null, "GET",
                 string.Empty, string.Empty) as AlbumViews;
            return albums;
        }
        public async Task<UserView> GetUserDetails(string Id)
        {
            var userUrl = $"{apiUrl}User/Details/{Id}";
            var userDetails = await RestUtility.CallServiceAsync<UserView>(userUrl, string.Empty, null, "GET",
                 string.Empty, string.Empty) as UserView;
            return userDetails;
        }
    }
}
