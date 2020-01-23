using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Task.Model
{
    public class AlbumView
    {
        public string ThumbNail { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public List<Photo> Photo { get; set; }
        public int UserId { get; set; }
    }
    public class AlbumViews
    {
        public List<AlbumView> Albums { get; set; }
        public int ItemCount { get; set; }
        public int SelectedPage { get; set; }
    }
}
