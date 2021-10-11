// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： AccountInfo.cs
// 项目名称：SunCity_MS 
// 创建时间：2014/3/1
// 负责人：Chris
// ===================================================================
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using PB.Entity;
using System.Collections.Generic;
namespace PB.IDataAccessLayer
{
    /// <summary>
    /// 数据层 dbo.AccountInfo 接口。
    /// </summary>
    public interface IAccountInfoDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_AccountInfoModel">AccountInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_AccountInfoInsert(AccountInfoEntity _AccountInfoModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_AccountInfoModel">AccountInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_AccountInfoInsert(SqlTransaction sp,AccountInfoEntity _AccountInfoModel);
		
		/// <summary>
		/// 向数据表AccountInfo更新一条记录。
		/// </summary>
		/// <param name="_AccountInfoModel">_AccountInfoModel</param>
		/// <returns>影响的行数</returns>
		int Create_AccountInfoUpdate(AccountInfoEntity _AccountInfoModel);
		
		/// <summary>
		/// 向数据表AccountInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_AccountInfoModel">_AccountInfoModel</param>
		/// <returns>影响的行数</returns>
		int Create_AccountInfoUpdate(SqlTransaction sp,AccountInfoEntity _AccountInfoModel);
		
		/// <summary>
		/// 删除数据表AccountInfo中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_AccountInfoDelete(int iD);
		
		/// <summary>
		/// 删除数据表AccountInfo中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_AccountInfoDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据AccountInfo返回的查询DataRow创建一个AccountInfoEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>AccountInfo对象</returns>
		AccountInfoEntity Populate_AccountInfoEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 accountinfo 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>accountinfo 数据实体</returns>
		AccountInfoEntity Get_AccountInfoEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表AccountInfo所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< AccountInfoEntity> Get_AccountInfoAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistAccountInfo(int iD);

        #endregion
    }
}

