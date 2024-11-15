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
        public List<StaffMember> Parse(XmlDocument doc)
        {
            List<StaffMember> members = new List<StaffMember>();
            XmlNodeList elements = doc.GetElementsByTagName("StaffMember");

            foreach (XmlNode member in elements)
            {
                List<string> attributeList = new();
                XmlNodeList attributes = member.ChildNodes;
                for (int i = 0; i < attributes.Count; i++) {
                    attributeList.Add(attributes[i].InnerText);
                }

                StaffMember newMember = StaffMemberFactory.GetMember(attributeList);
                members.Add(newMember);
            }

            return members;
        }
    }
}
