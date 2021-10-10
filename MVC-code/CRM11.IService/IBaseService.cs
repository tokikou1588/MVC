using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CRM11.IService
{
    /// <summary>
    /// 业务公共父接口
    /// </summary>
    /// <typeparam name="TEntity">实体类 类型参数-对应 要操作的数据表</typeparam>
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity Single(Expression<Func<TEntity, bool>> where);

        #region 1.0 新增实体 +Add(TEntity model)
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        void Add(TEntity model); 
        #endregion

        #region 2.0 删除实体 +Remove(TEntity model)
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        void Remove(TEntity model); 
        #endregion

        #region 2.1 根据条件删除实体 +RemoveBy(Expression<Func<TEntity, bool>> where)
        /// <summary>
        /// 2.1 根据条件删除实体
        /// </summary>
        /// <param name="where">查询条件表达式</param>
        void RemoveBy(Expression<Func<TEntity, bool>> where); 
        #endregion

        #region 3.0 修改 指定实体 的 指定 属性 +Modify(TEntity model, params string[] updateProperties)
        /// <summary>
        /// 修改 指定实体 的 指定 属性
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="updateProperties">要修改的属性名数组</param>
        void Modify(TEntity model, params string[] updateProperties); 
        #endregion

        #region 3.1 根据条件删除实体 +ModifyBy(Expression<Func<TEntity, bool>> where, string[] propertyNames, object[] values);
        /// <summary>
        /// 3.1 根据条件删除实体
        /// </summary>
        /// <param name="where">查询条件表达式</param>
        void ModifyBy(Expression<Func<TEntity, bool>> where, string[] propertyNames, object[] values);
        #endregion

        #region 4.0 根据条件查询 IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        /// <summary>
        /// 4.0 根据条件查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where); 
        #endregion

        #region 4.1 根据条件查询 并且 排序 +IQueryable<TEntity> WherePaged<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy)
        /// <summary>
        /// 4.1 根据条件查询 并且 排序
        /// </summary>
        /// <typeparam name="TKey">排序字段类型（可以不写，通过编译器类型推断出来）</typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">第一个排序条件</param>
        /// <returns></returns>
        IQueryable<TEntity> Where<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true);
        #endregion

        MODEL.FormatMODEL.PageData<TEntity> WherePaged<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true);

        MODEL.FormatMODEL.PageData<TEntity> WherePaged<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true, params string[] includeNames);
    }
}
