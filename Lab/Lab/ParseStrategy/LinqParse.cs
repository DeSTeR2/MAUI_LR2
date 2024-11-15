using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Lab.ParseStrategy
{
    public class LinqParse : IParse
    {
        public List<StaffMember> Parse(XmlDocument doc)
        {
            XElement element = XElement.Parse(doc.InnerXml);
            var list = element.Elements()
                        .GroupBy(x => x.Name)
                        .Select(group => new
                        {
                            Category = group.Key,
                            Member = group.Select(p => p.Elements().Select(x => x.Value).ToList())
                        });
            List<StaffMember> members = new();

            foreach (var item in list) {
                foreach (var mebmer in item.Member)
                {
                    members.Add(StaffMemberFactory.GetMember(mebmer));
                }
            }
            return null;
                                             
        }
    } 
}
