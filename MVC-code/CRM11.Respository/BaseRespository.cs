using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;

namespace CRM11.Respository
{
    /// <summary>
    /// 数据层公共 父类 - 负责实现 数据层公共父接口
    /// </summary>
    /// <typeparam name="TEntity">实体类 类型参数-对应 要操作的数据表</typeparam>
    public class BaseRespository<TEntity> : IRespository.IBaseRespository<TEntity>
        where TEntity :class
    {
        //1.先准备一个 EF 容器对象
        DbContext db = EFFatory.GetEFContext();//保证 针对 每个 浏览器请求 生成 线程唯一的 EF容器对象

        //2.准备一个 DBSet对象 操作 对应的 数据表
        DbSet<TEntity> dbSet = null;

        public BaseRespository() 
        {
            //关闭 EF容器的 为空检查
            db.Configuration.ValidateOnSaveEnabled = false;
            //在构造函数中 实例化 dbSet
            //2.通过EF容器对象 获取 一个 DbSet<TEntity> 用来操作 和 TEntity实体类 对应的数据表
            dbSet = db.Set<TEntity>();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.SingleOrDefault(where);
        }

        #region 1.0 新增 实体对象 +Add(TEntity model)
        /// <summary>
        /// 新增 实体对象
        /// </summary>
        /// <param name="model"></param>
        public void Add(TEntity model)
        {
            //SQO：标准查询运算符  Where  Single   Select ....
            //var list = new List<string>();
            ////var list2 = list.Where(delegate(string s) { return s.Length > 10; });
            //list.OrderBy(delegate(string s) { return s.Length; });

            //BaseRespository<MODEL.Department> bas = new BaseRespository<MODEL.Department>();

            //Func<MODEL.Department, string> d = delegate(MODEL.Department d1) { return d1.depName; };

            //bas.dbSet.OrderBy(d2 => d2.depName); // select * from Department order by depName
            

            //将要新增的实体对象 加入到 EF容器中
            dbSet.Add(model);
        } 
        #endregion

        #region 2.0 删除 指定的实体对象 +Remove(TEntity model)
        /// <summary>
        /// 删除 指定的实体对象
        /// </summary>
        /// <param name="model"></param>
        public void Remove(TEntity model)
        {
            dbSet.Attach(model);
            dbSet.Remove(model);
        }
        #endregion

        #region 2.1 根据条件删除实体 +RemoveBy(Expression<Func<TEntity, bool>> where)
        /// <summary>
        /// 2.1 根据条件删除实体
        /// </summary>
        /// <param name="where">查询条件表达式</param>
        public void RemoveBy(Expression<Func<TEntity, bool>> where)
        {
            //1.先查询出 要删除的集合
            var list = dbSet.Where(where);//查询出的对象已经存入EF容器了，但State都是 UnChanged
            //2.循环
            foreach (var item in list)
            {
                dbSet.Remove(item);//将 EF容器里的 对象的 State 都改成 Deleted
            }
        }
        #endregion

        #region 3.0 修改 指定实体 的 指定 属性 +Modify(TEntity model, params string[] updateProperties)
        /// <summary>
        /// 修改 指定实体 的 指定 属性
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="updateProperties">要修改的属性名数组</param>
        public void Modify(TEntity model, params string[] updateProperties)
        {
            //3.1 将 实体对象 添加到 EF容器中，并返回 代理类对象的 一个 指示器对象！
            DbEntityEntry<TEntity> entry = db.Entry<TEntity>(model);
            //3.2 手动将 代理对象里的State状态 改为 Unchanged，因为默认是 Detached，不能直接修改 IsModified属性！
            entry.State = System.Data.EntityState.Unchanged;
            //3.3 循环 要修改的 实体类属性名
            foreach (string propertyName in updateProperties)
            {
                //3.3设置 实体类对象的属性 为已修改状态 注意：实体对象的 第一次属性被修改时， State属性 被自动设置成 Modified
                entry.Property(propertyName).IsModified = true;
            }
        } 
        #endregion

        #region 3.1 根据条件 批量修改 +ModifyBy(Expression<Func<TEntity, bool>> where, string[] propertyNames, object[] values)
        /// <summary>
        /// 3.1 根据条件 批量修改
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="propertyNames">要修改的 属性名</param>
        /// <param name="values">要设置的新的 属性值</param>
        public void ModifyBy(Expression<Func<TEntity, bool>> where, string[] propertyNames, object[] values)
        {
            if (propertyNames == null || values == null) throw new ArgumentException("属性名和属性值数组都不能为null~~!");

            //查询要修改的实体对象集合
            var list = dbSet.Where(where);
            //获取要修改的实体类的 类型对象
            Type type = typeof(TEntity);

            //循环要修改的 实体对象
            foreach (var item in list)
            {
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    //获取要修改的 属性对象
                    PropertyInfo pi = type.GetProperty(propertyNames[i]);
                    //item.Name ="123"      pi.SetValue(item,"123");
                    //修改 item实体对象 里 pi属性 的值 为 values[i]  ： item.pi=values[i]
                    pi.SetValue(item, values[i], null);
                }
            }
        } 
        #endregion

        #region 4.0 根据条件查询 IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        /// <summary>
        /// 4.0 根据条件查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where);//为什么要ToList？因为返回的是IEnumerable，调用者据此 判断 返回的是集合！所以我们应该返回集合！
        }
        #endregion

        #region 4.1 根据条件查询 并且 排序 +IEnumerable<TEntity> WherePaged<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy)
        /// <summary>
        /// 4.1 根据条件查询 并且 排序
        /// </summary>
        /// <typeparam name="TKey">排序字段类型（可以不写，通过编译器类型推断出来）</typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">第一个排序条件</param>
        /// <returns></returns>
        public IQueryable<TEntity> Where<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true)
        {
            if (isAsc)
            {
                return dbSet.Where(where).OrderBy(orderBy);
            }
            else {
                return dbSet.Where(where).OrderByDescending(orderBy);
            }
        }
        #endregion


        public MODEL.FormatMODEL.PageData<TEntity> WherePaged<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true)
        {
            //dbSet.Include("导航属性名1").Include("导航属性名2").Where(where).OrderBy(orderBy).Skip(0).Take(10);
            //dbSet.Where(where).OrderBy(orderBy).Skip(0).Take(10);
            var dbSetWhered = dbSet.Where(where);
            IOrderedQueryable<TEntity> orderWhere = null;
            if (isAsc)
                orderWhere = dbSetWhered.OrderBy(orderBy);
            else
                orderWhere = dbSetWhered.OrderByDescending(orderBy);

            MODEL.FormatMODEL.PageData<TEntity> pageData = new MODEL.FormatMODEL.PageData<TEntity>();
            pageData.rows = orderWhere.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            pageData.total = dbSetWhered.Count();

            return pageData;
        }

        public MODEL.FormatMODEL.PageData<TEntity> WherePaged<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true,params string [] includeNames)
        {
            //dbSet.Include("导航属性名1").Include("导航属性名2").Include("导航属性名3").Where(where).OrderBy(orderBy).Skip(0).Take(10);
            //dbSet.Where(where).OrderBy(orderBy).Skip(0).Take(10);
            DbQuery<TEntity> dbQuery = dbSet;
            //循环 加入 要连接查询的 导航属性名称
            foreach (string includeN in includeNames)
            {
                dbQuery = dbQuery.Include(includeN);
            }

            var dbSetWhered = dbQuery.Where(where);
            IOrderedQueryable<TEntity> orderWhere = null;
            if (isAsc)
                orderWhere = dbSetWhered.OrderBy(orderBy);
            else
                orderWhere = dbSetWhered.OrderByDescending(orderBy);

            MODEL.FormatMODEL.PageData<TEntity> pageData = new MODEL.FormatMODEL.PageData<TEntity>();
            pageData.rows = orderWhere.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            pageData.total = dbSetWhered.Count();

            return pageData;
        }

    }
}
