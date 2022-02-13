using System;
using System.Collections.Generic;

namespace Mysql.Models
{
    public partial class Emp
    {
        public int Empno { get; set; }
        public string? Ename { get; set; }
        public string? Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime? Hiredate { get; set; }
        public float? Sal { get; set; }
        public float? Comm { get; set; }
        public int? Deptno { get; set; }

        public virtual Dept? DeptnoNavigation { get; set; }
    }
}
