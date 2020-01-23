using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Task.Model
{
    public class UserView
    {
        public UserData UserData { get; set; }
        public List<Post> Posts { get; set; }
    }
}
