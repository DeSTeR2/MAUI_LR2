using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class StaffMember
    {
        string name;
        string departament;
        string departmentSection;
        string position;
        string salary;
        string duration;

        public string Name { get => name; }
        public string Departament { get => departament; }
        public string DepartmentSection { get => departmentSection; }
        public string Position { get => position; }
        public string Salary { get => salary; }
        public string Duration { get => duration; }

        public StaffMember(string name, string departament, string position, string salary, string duration)
        {
            this.name = name;
            this.departament = departament;
            this.position = position;
            this.salary = salary;
            this.duration = duration;
        }

        public StaffMember(ICollection<string> properties)
        {
            List<string> list = properties.ToList();

            if (list.Count < 5)
            {
                throw new ArgumentException("There is less that 5 properties");
            }

            name = list[0];
            departament = list[1];
            departmentSection = list[2];
            position = list[3];
            salary = list[4];
            duration = list[5];
        }
    }
}
