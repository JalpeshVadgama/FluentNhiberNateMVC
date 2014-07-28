namespace FluentNhibernateMVC.Models
{
    public class Employee
    {
        public virtual int EmployeeId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Designation { get; set; }
    }
}