using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    using System.Reflection;

    public class Factor
    {
        public static IDAL.IUserInfoDal CreateUserinfoInstance()
        {
            //return new DALOracle.UserInfoDal();
            //为了将工厂与dal层解耦出来，所以应该利用反射+ xml的配置来动态创建具体类的对象
            //1.0 获取app.config或者web.config 配置好的dalnamespace 配置节的数据
            string dalns = System.Configuration.ConfigurationManager.AppSettings["dalnamespace"];

            //2.0 开始动态创建类的对象
            //2.0.1 先获取Assembly
            Assembly ass = Assembly.Load(dalns);  //会去ui层的bin目录查找dalns 值对应的程序集 DAL.dll
            object obj = ass.CreateInstance(dalns + ".UserInfoDal");

            return obj as IDAL.IUserInfoDal;
        }
    }
}
