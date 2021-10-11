using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALOracle
{
    public class UserInfoDal : IDAL.IUserInfoDal
    {
        public string GetUserName()
        {
            return "名字来源于oracle数据库";
        }
    }
}
