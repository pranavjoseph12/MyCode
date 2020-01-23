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
    public class UserService : IUserService
    {
        public async Task<UserView> GetUserDetails(int userId)
        {
            var userUrl = $"https://jsonplaceholder.typicode.com/users/{userId}";
            var postUrl = $"https://jsonplaceholder.typicode.com/users/{userId}/posts";
            var userDetails = await RestUtility.CallServiceAsync<UserData>(userUrl, string.Empty, null, "GET",
                string.Empty, string.Empty) as UserData;
            var posts= await RestUtility.CallServiceAsync<IList<Post>>(postUrl, string.Empty, null, "GET",
                string.Empty, string.Empty) as IList<Post>;
            return new UserView { UserData= userDetails,Posts=posts.ToList() };
        }
    }
}
