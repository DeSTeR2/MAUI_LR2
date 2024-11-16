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
        private Dictionary<Attribute, string> values = new();

        public string? Name;
        public string? Department;
        public string? DepartmentSection;
        public string? Position;
        public string? Salary;
        public string? Duration;

        // Parameterless constructor
        public StaffMember()
        {
        }

        public StaffMember(IDictionary<string, string> properties)
        {
            foreach (var property in properties)
            {
                Attribute attribute = (Attribute)Enum.Parse(typeof(Attribute), property.Key);
                FillAttribute(attribute, property.Value);
            }

            FillInfo();
        }


        public void FillInfo()
        {
            values.TryGetValue(Attribute.Name, out Name);
            values.TryGetValue(Attribute.Department, out Department);
            values.TryGetValue(Attribute.DepartmentSection, out DepartmentSection);
            values.TryGetValue(Attribute.Position, out Position);
            values.TryGetValue(Attribute.Salary, out Salary);
            values.TryGetValue(Attribute.Duration, out Duration);
        }

        public Dictionary<Attribute, string> GetDictionary() => values;

        private void FillAttribute(Attribute attribute, string value)
        {
            if (values.ContainsKey(attribute))
            {
                values[attribute] = value;
            }
            else
            {
                values.Add(attribute, value);
            }
        }
    }

}
