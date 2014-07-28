using FluentNHibernate.Mapping;

namespace FluentNhibernateMVC.Models
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.EmployeeId);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Designation);
            Table("Employee");
        }
    }
}