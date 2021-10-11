// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： GroupInfo.cs
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
    /// 数据层 dbo.GroupInfo 接口。
    /// </summary>
    public interface IGroupInfoDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_GroupInfoModel">GroupInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_GroupInfoInsert(GroupInfoEntity _GroupInfoModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_GroupInfoModel">GroupInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_GroupInfoInsert(SqlTransaction sp,GroupInfoEntity _GroupInfoModel);
		
		/// <summary>
		/// 向数据表GroupInfo更新一条记录。
		/// </summary>
		/// <param name="_GroupInfoModel">_GroupInfoModel</param>
		/// <returns>影响的行数</returns>
		int Create_GroupInfoUpdate(GroupInfoEntity _GroupInfoModel);
		
		/// <summary>
		/// 向数据表GroupInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_GroupInfoModel">_GroupInfoModel</param>
		/// <returns>影响的行数</returns>
		int Create_GroupInfoUpdate(SqlTransaction sp,GroupInfoEntity _GroupInfoModel);
		
		/// <summary>
		/// 删除数据表GroupInfo中的一条记录
		/// </summary>
	    /// <param name="groupId">groupId</param>
		/// <returns>影响的行数</returns>
		int Create_GroupInfoDelete(int groupId);
		
		/// <summary>
		/// 删除数据表GroupInfo中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="groupId">groupId</param>
		/// <returns>影响的行数</returns>
		int Create_GroupInfoDelete(SqlTransaction sp,int groupId);
		
		
		/// <summary>
		/// 根据GroupInfo返回的查询DataRow创建一个GroupInfoEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>GroupInfo对象</returns>
		GroupInfoEntity Populate_GroupInfoEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 groupinfo 数据实体
		/// </summary>
		/// <param name="groupId">groupId</param>
		/// <returns>groupinfo 数据实体</returns>
		GroupInfoEntity Get_GroupInfoEntity(int groupId);
		
		
		/// <summary>
		/// 得到数据表GroupInfo所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< GroupInfoEntity> Get_GroupInfoAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="groupId">groupId</param>
        /// <returns>是/否</returns>
		bool IsExistGroupInfo(int groupId);

        #endregion

    }
}

