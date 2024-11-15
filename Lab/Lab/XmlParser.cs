using Lab.ParseStrategy;

namespace Lab
{
    public class XmlParser
    {
        List<StaffMember> members;
        string[] attributes;

        Attribute selectedAttibute;
        string searchBy;
        IParse parser;

        string content;
        
        public void Parse(IParse parser, string input)
        {
            this.parser = parser;
            content = input;
            members = parser.Parse(input);
        }

        public void Parse()
        {
            Parse(parser, content);
        }

        public string[] GetAttributes()
        {
            if (attributes != null) return attributes;

            int enumNumber = Enum.GetValues(typeof(Attribute)).Length;
            attributes = new string[enumNumber];

            for (int i = 0; i < enumNumber; i++) {
                attributes[i] = ((Attribute)i).ToString();
            }

            return attributes;
        }

        public void SelectAttribute(Attribute attribute) => selectedAttibute = attribute;
        public void SelectSearhBy(string searhBy) => this.searchBy = searhBy;
        public void SelectParser(IParse parser) => this.parser = parser;
    
        public List<StaffMember> GetMebmersByAttribute()
        {
            if (selectedAttibute == Attribute.None || string.IsNullOrEmpty(searchBy)) return members;

            List<StaffMember> selected = new();
            foreach (StaffMember member in members) {
                if (member.values[selectedAttibute] == searchBy)
                {
                    selected.Add(member);
                }
            }

            return selected;
        }
    }
}
