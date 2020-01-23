using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Task.Model
{
    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geography { get; set; }
    }

    public class UserData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
    }
    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
