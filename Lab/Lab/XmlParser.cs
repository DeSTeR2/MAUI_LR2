using Lab.ParseStrategy;
using System.Xml;

namespace Lab
{
    public class XmlParser
    {
        List<StaffMember> members;

        public void Parse(IParse parser, string input)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(input);
            members = parser.Parse(doc);
        }
    }
}
