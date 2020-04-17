using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Corporation
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        public ICollection<Person> People { get; set; }
        public Corporation()
        {
            People = new List<Person>();
        }
    }
}