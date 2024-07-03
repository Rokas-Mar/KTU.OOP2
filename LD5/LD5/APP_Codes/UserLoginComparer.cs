using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5
{
    public class UserLoginComparer : IEqualityComparer<UserLogin>
    {
        public TaskUtils UserLoginComparerLink
        {
            get => default;
            set
            {
            }
        }

        public bool Equals(UserLogin x, UserLogin y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.WebLink == y.WebLink;
        }

        public int GetHashCode(UserLogin obj)
        {
            if (obj is null) return 0;

            int hashUserLink = obj.WebLink == null ? 0 : obj.WebLink.GetHashCode();

            int hashUserIp = obj.IPaddress.GetHashCode();

            return hashUserLink ^ hashUserIp;
        }
    }
}