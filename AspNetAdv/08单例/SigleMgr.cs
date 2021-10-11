using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08单例
{

    /// <summary>
    /// 单例类的写法
    /// </summary>
    public class SigleMgr
    {
        #region 1.0 单例类基本的写法步骤
        private static readonly SigleMgr instance = new SigleMgr();
        //private static readonly SigleMgr instance;
        //static SigleMgr()
        //{
        //    instance = new SigleMgr();
        //}

        private SigleMgr() { }

        public static SigleMgr Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        private Dictionary<int, string> dic = new Dictionary<int, string>();
        private static object syncHelper = new object();


        #region 2.0 此单例类具体的业务逻辑

        public void Add(int key, string str)
        {

            //lock()中的参数类型一定是一个引用类型  
            //lock 关键字是方便程序员代码编写的 语法糖
            //lock (syncHelper)  // 本质 System.Threading.Monitor.Enter(object obj)
            //{
            //    if (dic.ContainsKey(key) == false)
            //    {
            //        dic.Add(key, str);
            //    }
            //}   // 本质 System.Threading.Monitor.Exit(object obj)

            System.Threading.Monitor.Enter(syncHelper);
            if (dic.ContainsKey(key) == false)
            {
                dic.Add(key, str);
            }
            System.Threading.Monitor.Exit(syncHelper);
        }

        public void Remove(int key)
        {
            lock (syncHelper)
            {
                if (dic.ContainsKey(key) == false)
                {
                    dic.Remove(key);
                }
            }
        }

        public List<int> Keys
        {
            get
            {
                return dic.Keys.ToList();
            }
        }

        #endregion
    }
}
