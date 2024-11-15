using System.Xml;

namespace Lab.ParseStrategy
{
    public interface IParse
    {
        public List<StaffMember> Parse(XmlDocument doc);
    }
}
