
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    using IDAL;

    public class UserInfoDal : IUserInfoDal
    {

        public string GetUserName()
        {
            return "名字来源于sqlserver数据库";
        }
    }
}
