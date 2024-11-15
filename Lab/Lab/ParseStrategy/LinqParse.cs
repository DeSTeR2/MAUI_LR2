using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Lab.ParseStrategy
{
    public class LinqParse : IParse
    {
        public List<StaffMember> Parse(string content)
        {
            XDocument doc = XDocument.Parse(content);

            var staffMemberElements = doc.Root.Elements("StaffMember");

            List<StaffMember> members = staffMemberElements
                .Select(member =>
                    StaffMemberFactory.GetMember(
                        member.Elements()
                              .ToDictionary(
                                  element => element.Name.LocalName, 
                                  element => element.Value           
                              )
                    )
                )
                .ToList();

            return members;
        }
    }
}
