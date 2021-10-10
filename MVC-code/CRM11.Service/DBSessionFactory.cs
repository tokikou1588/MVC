using CRM11.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace CRM11.Service
{
    public class DBSessionFactory
    {
        //[ThreadStatic]
        //private static IRespository.IDBSession _idbSession = null;

        public static IRespository.IDBSession GetDBSession()
        {
            //if (_idbSession == null) _idbSession = Utility.DI.GetObject<IRespository.IDBSession>("dalSession");
            //return _idbSession;


            //1.从线程中取出 键 对应的值
            var db = CallContext.GetData("IDBSession") as IDBSession;
            //2.如果为空（线程中不存在）
            if (db == null)
            {
                //3.实例化 EF容器 子类对象
                db = Utility.DI.GetObject<IRespository.IDBSession>("dalSession");
                //4.并存入线程
                CallContext.SetData("IDBSession", db);
            }
            //5.返回DBSession对象
            return db; 
        }
    }
}
