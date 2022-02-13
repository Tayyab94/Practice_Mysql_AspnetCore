using Microsoft.EntityFrameworkCore;

namespace Mysql.Models.Repos
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly demoContext context;

        public DepartmentRepo(demoContext context)
        {
            this.context = context;
        }
        public void Add(Dept dept)
        {
            context.Depts.Add(dept);
            context.SaveChanges();
        }

        public void AddEmp(Emp emp)
        {
            context.Emps.Add(emp);
            context.SaveChanges();
        }

        public IEnumerable<Dept> GetDepartments()
        {
            return context.Depts.Include(s=>s.Emps).ToList();
        }
    }
}
