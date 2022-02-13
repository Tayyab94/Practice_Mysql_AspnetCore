namespace Mysql.Models.Repos
{
    public interface IDepartmentRepo
    {
        IEnumerable<Dept> GetDepartments();
        void Add(Dept dept);

        void AddEmp(Emp emp);
    }
}
