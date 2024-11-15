using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab.ParseStrategy
{
    public class DomParse : IParse
    {
        public List<StaffMember> Parse(string contnet)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(contnet);

            List<StaffMember> members = new List<StaffMember>();
            XmlNodeList elements = doc.GetElementsByTagName("StaffMember");

            foreach (XmlNode member in elements)
            {
                Dictionary<string, string> values = new();
                XmlNodeList attributes = member.ChildNodes;
                for (int i = 0; i < attributes.Count; i++) {
                    values.Add(attributes[i].Name, attributes[i].InnerText);
                }

                StaffMember newMember = StaffMemberFactory.GetMember(values);
                members.Add(newMember);
            }

            return members;
        }
    }
}
