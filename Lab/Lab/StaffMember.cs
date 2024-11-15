using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{

    public enum Attribute
    {
        None,
        Name,
        Department,
        DepartmentSection,
        Position,
        Salary,
        Duration
    }
    public class StaffMember
    {
        public Dictionary<Attribute, string> values { get; private set; } = new();

        public StaffMember(IDictionary<string, string> properties)
        {
            foreach (var property in properties) {
                Attribute attribute = (Attribute)Enum.Parse(typeof(Attribute), property.Key);
                FillAttribute(attribute, property.Value);
            }
        }

        private void FillAttribute(Attribute attribute, string value) {
            if (values.ContainsKey(attribute))
            {
                values[attribute] = value;
            } else
            {
                values.Add(attribute, value);
            }
        }
    }
}
