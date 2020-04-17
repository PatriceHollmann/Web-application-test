using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
        public int? Corporation_Id { get; set; }
        public Corporation Corporation { get; set; }
    }
}