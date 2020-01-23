using Nest.Task.Domain.Constants;
using Nest.Task.Domain.Interfaces;
using Nest.Task.Domain.Util;
using Nest.Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Task.Domain.Services
{
    public class AlbumService : IAlbumService
    {
        public async Task<AlbumViews> GetAllAlbums(string searchText, int pageNumber)
        {
            int albumCount = 0;
            var albums = await RestUtility.CallServiceAsync<IList<Album>>(JsonPlaceHolderConstants.AlbumUrl, string.Empty, null, "GET",
                string.Empty, string.Empty) as IList<Album>;
            var users = await RestUtility.CallServiceAsync<IList<UserData>>(JsonPlaceHolderConstants.UsersUrl, string.Empty, null, "GET",
                string.Empty, string.Empty) as IList<UserData>;
            var albumsWithUserData = from a in albums
                                     join u in users on a.UserId equals u.Id
                                     select new
                                     {
                                         a.Id,
                                         a.Title,
                                         a.UserId,
                                         u.Name,
                                         u.Email,
                                         u.Address,
                                         u.Phone,
                                     };
            if (albumsWithUserData.Any())
            {
                if(!string.IsNullOrWhiteSpace(searchText))
                {
                    albumsWithUserData = albumsWithUserData.Where(x => x.Title.Contains(searchText) || x.Name.Contains(searchText));
                }
                albumCount = albumsWithUserData.Count();
                if (albumCount < (10 * pageNumber))
                    pageNumber = 1;
                albumsWithUserData = albumsWithUserData.Skip(10 * (pageNumber-1)).Take(10);
                List<AlbumView> albumView = new List<AlbumView>();
                foreach (var alb in albumsWithUserData)
                {
                    var photoUrl = $"https://jsonplaceholder.typicode.com/albums/{alb.Id}/photos";
                    var photos= await RestUtility.CallServiceAsync<IList<Photo>>(photoUrl, string.Empty, null, "GET",
                 string.Empty, string.Empty) as IList<Photo>;
                    var thumbnail = photos.Select(x => x.ThumbnailUrl).FirstOrDefault();
                    albumView.Add(new AlbumView{
                        Address=alb.Address,
                        Email=alb.Email,
                        Name=alb.Name,
                        Phone=alb.Phone,
                        Title=alb.Title,
                        ThumbNail=thumbnail,
                        UserId=alb.UserId,
                        Photo=photos.Take(5).ToList()
                    });
                }
                return new AlbumViews() { Albums = albumView, ItemCount = albumCount,SelectedPage=pageNumber };
            }
            return null;
        }
    }
}
