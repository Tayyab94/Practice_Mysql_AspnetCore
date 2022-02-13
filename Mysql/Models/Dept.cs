using System;
using System.Collections.Generic;

namespace Mysql.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emps = new HashSet<Emp>();
        }

        public int Deptno { get; set; }
        public string? Dname { get; set; }
        public string? Loc { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
