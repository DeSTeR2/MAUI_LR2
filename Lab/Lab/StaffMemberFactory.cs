using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public static class StaffMemberFactory
    {
        public static StaffMember GetMember(IDictionary<string, string> properties) {
            try
            {
                StaffMember member = new StaffMember(properties);
                return member;
            }
            catch (ArgumentException ex) {
                if (ex != null)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            return null;
        }
    }
}
