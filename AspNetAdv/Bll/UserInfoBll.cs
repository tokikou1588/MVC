using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    using IDAL;
    using Factory;

    public class UserInfoBll
    {
        IUserInfoDal dal = Factor.CreateUserinfoInstance();
        public string GetUserName()
        {
            return dal.GetUserName();
        }
    }
}
