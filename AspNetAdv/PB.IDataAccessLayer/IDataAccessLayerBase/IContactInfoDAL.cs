// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： ContactInfo.cs
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
    /// 数据层 dbo.ContactInfo 接口。
    /// </summary>
    public interface IContactInfoDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_ContactInfoModel">ContactInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_ContactInfoInsert(ContactInfoEntity _ContactInfoModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ContactInfoModel">ContactInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_ContactInfoInsert(SqlTransaction sp,ContactInfoEntity _ContactInfoModel);
		
		/// <summary>
		/// 向数据表ContactInfo更新一条记录。
		/// </summary>
		/// <param name="_ContactInfoModel">_ContactInfoModel</param>
		/// <returns>影响的行数</returns>
		int Create_ContactInfoUpdate(ContactInfoEntity _ContactInfoModel);
		
		/// <summary>
		/// 向数据表ContactInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ContactInfoModel">_ContactInfoModel</param>
		/// <returns>影响的行数</returns>
		int Create_ContactInfoUpdate(SqlTransaction sp,ContactInfoEntity _ContactInfoModel);
		
		/// <summary>
		/// 删除数据表ContactInfo中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_ContactInfoDelete(int iD);
		
		/// <summary>
		/// 删除数据表ContactInfo中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_ContactInfoDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据ContactInfo返回的查询DataRow创建一个ContactInfoEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>ContactInfo对象</returns>
		ContactInfoEntity Populate_ContactInfoEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 contactinfo 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>contactinfo 数据实体</returns>
		ContactInfoEntity Get_ContactInfoEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表ContactInfo所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< ContactInfoEntity> Get_ContactInfoAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistContactInfo(int iD);

        #endregion
    }
}

