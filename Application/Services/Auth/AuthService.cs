using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Auth
{
    public class AuthService1 : IAuthService1
    {
        public static int Test = 0;
        public AuthService1()
        {
            Test++;
        }
    }
    public class AuthService2 : IAuthService2
    {
        public static int Test = 0;
        public AuthService2()
        {
            Test++;
        }
    }
    public class AuthService3 : IAuthService3
    {
        public static int Test = 0;
        public AuthService3()
        {
            Test++;
        }
    }
}
