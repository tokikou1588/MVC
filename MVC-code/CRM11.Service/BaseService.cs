using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;

namespace CRM11.Service
{
    /// <summary>
    /// 数据层公共 父类 - 负责实现 数据层公共父接口
    /// </summary>
    /// <typeparam name="TEntity">实体类 类型参数-对应 要操作的数据表</typeparam>
    public abstract class BaseService<TEntity> : IService.IBaseService<TEntity>
        where TEntity :class
    {
        //数据父接口 对象！                                
        public IRespository.IBaseRespository<TEntity> iBaseDal = null;

        public BaseService() 
        {
            SetIDAL();
        }
        //专门要求 子类 为业务父类里的 数据父接口赋值！
        public abstract void SetIDAL();

        /// <summary>
        /// 获取一个 线程唯一的 数据仓储对象
        /// </summary>
        public IRespository.IDBSession DBSession
        {
            get
            {
                return DBSessionFactory.GetDBSession();
            }
        }


        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return iBaseDal.Single(where);
        }

        #region 1.0 新增 实体对象 +Add(TEntity model)
        /// <summary>
        /// 新增 实体对象
        /// </summary>
        /// <param name="model"></param>
        public void Add(TEntity model)
        {
            iBaseDal.Add(model);
        }
        #endregion

        #region 2.0 删除 指定的实体对象 +Remove(TEntity model)
        /// <summary>
        /// 删除 指定的实体对象
        /// </summary>
        /// <param name="model"></param>
        public void Remove(TEntity model)
        {
            iBaseDal.Remove(model);
        }
        #endregion

        #region 2.1 根据条件删除实体 +RemoveBy(Expression<Func<TEntity, bool>> where)
        /// <summary>
        /// 2.1 根据条件删除实体
        /// </summary>
        /// <param name="where">查询条件表达式</param>
        public void RemoveBy(Expression<Func<TEntity, bool>> where)
        {
            iBaseDal.RemoveBy(where);
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
            iBaseDal.Modify(model, updateProperties);
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
            iBaseDal.ModifyBy(where, propertyNames, values);
        } 
        #endregion

        #region 4.0 根据条件查询 IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        /// <summary>
        /// 4.0 根据条件查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            return iBaseDal.Where(where);
        }
        #endregion

        #region 4.1 根据条件查询 并且 排序 +IQueryable<TEntity> WherePaged<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy)
        /// <summary>
        /// 4.1 根据条件查询 并且 排序
        /// </summary>
        /// <typeparam name="TKey">排序字段类型（可以不写，通过编译器类型推断出来）</typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">第一个排序条件</param>
        /// <returns></returns>
        public IQueryable<TEntity> Where<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true)
        {
            return iBaseDal.Where<TKey>(where, orderBy, isAsc);
        }
        #endregion


        public MODEL.FormatMODEL.PageData<TEntity> WherePaged<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true)
        {
            return iBaseDal.WherePaged<TKey>(pageIndex, pageSize, where, orderBy, isAsc);
        }


        public MODEL.FormatMODEL.PageData<TEntity> WherePaged<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true, params string[] includeNames)
        {
            return iBaseDal.WherePaged<TKey>(pageIndex, pageSize, where, orderBy, isAsc, includeNames);
        }
    }
}
