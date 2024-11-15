using System.Xml;

namespace Lab.ParseStrategy
{
    public class SaxParse : IParse
    {
        public List<StaffMember> Parse(string contnent)
        {
            List<StaffMember> members = new();

            using (XmlReader reader = XmlReader.Create(new StringReader(contnent)))
            {
                string currentElement = "";

                Dictionary<string, string> attributes = new();
                bool isStaff = false;

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            currentElement = reader.Name;

                            if (currentElement == "StaffMember")
                            {
                                isStaff = true;
                                if (attributes.Count != 0)
                                {
                                    members.Add(StaffMemberFactory.GetMember(attributes));
                                    attributes.Clear();
                                }
                            }
                            break;
                        case XmlNodeType.Text:
                            if (string.IsNullOrEmpty(currentElement) == false)
                            {
                                if (isStaff)
                                {
                                    attributes.Add(currentElement, reader.Value);
                                }
                            }
                            break;
                        case XmlNodeType.EndElement:
                            Console.WriteLine("End");
                            break;
                    }
                }
                if (attributes.Count != 0)
                {
                    try
                    {
                        members.Add(StaffMemberFactory.GetMember(attributes));
                        attributes.Clear();
                    }
                    catch { }
                }
            }

            return members;
        }
    }
}
