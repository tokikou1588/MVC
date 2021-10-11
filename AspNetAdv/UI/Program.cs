using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    using Bll;
    class Program
    {
        static void Main(string[] args)
        {
            UserInfoBll bll = new UserInfoBll();
           string uname= bll.GetUserName();

           Console.WriteLine(uname);
           Console.Read();
        }
    }
}
