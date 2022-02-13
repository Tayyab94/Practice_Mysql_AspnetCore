using System;
using System.Collections.Generic;

namespace Mysql.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Addresss { get; set; }
    }
}
