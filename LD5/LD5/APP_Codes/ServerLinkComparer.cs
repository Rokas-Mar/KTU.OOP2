using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5.APP_Codes
{
    public class ServerLinkComparer : IEqualityComparer<string>
    {
        public TaskUtils ServerLinkComparerLink
        {
            get => default;
            set
            {
            }
        }

        public bool Equals(string x, string y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (x is null || y is null)
                return false;

            return x == y;
        }

        public int GetHashCode(string obj)
        {
            if (obj is null) return 0;

            int hashUserLink = obj == null ? 0 : obj.GetHashCode();

            return hashUserLink;
        }
    }
}