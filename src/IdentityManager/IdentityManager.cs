using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public static class IdentityManager
    {
        private static int _next = 0;

        public static int Next()
        {
            return ++_next;
        }
    }
}
