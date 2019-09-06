using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CTTPB.MESCDP.Application.WebApi
{
    public static class Security
    {
        private static List<string> DatabaseRoles;
        private static List<string> groups = new List<string>();

        //public static bool IsInGroup(this ClaimsPrincipal User, string GroupName)
        public static bool IsInGroup(WindowsIdentity user, string GroupName)
        {
            //var wi = (WindowsIdentity)User;
            if (groups.Count == 0)
            {
                if (user.Groups != null)
                {
                    foreach (var group in user.Groups)
                    {
                        try
                        {
                            string groupAd = group.Translate(typeof(NTAccount)).ToString();
                            groupAd = groupAd.Contains("\\")
                                ? groupAd.Split("\\").Last()
                                : groupAd;
                            groups.Add(groupAd.ToUpper());
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }
            }

            return groups.Contains(GroupName);


            //return false;
        }
    }
}
