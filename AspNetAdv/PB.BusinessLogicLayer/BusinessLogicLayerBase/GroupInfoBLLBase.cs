using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using PB.Entity;
using PB.IDataAccessLayer;
using PB.DALFactory;

namespace PB.BusinessLogicLayer
{
    /// <summary>
    /// BLL Layer For dbo.GroupInfo.
    /// </summary>
    public class GroupInfoBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IGroupInfoDataAccessLayer _dal=DataAccessFactory.Create_GroupInfo();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public GroupInfoBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oGroupInfoInfo">GroupInfo??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_GroupInfoInsert(GroupInfoEntity oGroupInfoInfo)
		{
			// Validate input
			if (oGroupInfoInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_GroupInfoInsert(oGroupInfoInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oGroupInfoInfo">GroupInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_GroupInfoInsert(SqlTransaction sp,GroupInfoEntity oGroupInfoInfo)
		{
			if (oGroupInfoInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_GroupInfoInsert(sp,oGroupInfoInfo);
		}
		/// <summary>
		/// 向数据表GroupInfo更新一条记录。
		/// </summary>
		/// <param name="oGroupInfoInfo">oGroupInfoInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_GroupInfoUpdate(GroupInfoEntity oGroupInfoInfo)
		{
            // Validate input
			if (oGroupInfoInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_GroupInfoUpdate(oGroupInfoInfo);
		}
		/// <summary>
		/// 向数据表GroupInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oGroupInfoInfo">oGroupInfoInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_GroupInfoUpdate(SqlTransaction sp,GroupInfoEntity oGroupInfoInfo)
		{
			// Validate input
			if (oGroupInfoInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_GroupInfoUpdate(sp,oGroupInfoInfo);
		}
		
		/// <summary>
		/// 删除数据表GroupInfo中的一条记录
		/// </summary>
	    /// <param name="groupId">groupId</param>
		/// <returns>影响的行数</returns>
		public static int Create_GroupInfoDelete(int groupId)
		{
			// Validate input
			if(groupId<0)
				return 0;
			return _dal.Create_GroupInfoDelete(groupId);
		}
		/// <summary>
		/// 删除数据表GroupInfo中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="GroupId">groupId</param>
		/// <returns>影响的行数</returns>
		public static int Create_GroupInfoDelete(SqlTransaction sp,int groupId)
		{
			// Validate input
			if(groupId<0)
				return 0;
			return _dal.Create_GroupInfoDelete(sp,groupId);
		}
		#endregion
		
        /// <summary>
		/// 得到 groupinfo 数据实体
		/// </summary>
		/// <param name="groupId">groupId</param>
		/// <returns>groupinfo 数据实体</returns>
		public static GroupInfoEntity Get_GroupInfoEntity(int groupId)
		{
			// Validate input
			if(groupId<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_GroupInfoEntity(groupId);
		}
		
		/// <summary>
		/// 得到数据表GroupInfo所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< GroupInfoEntity> Get_GroupInfoAll()
		{
			// Use the dal to get all records 
			return _dal.Get_GroupInfoAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="groupId">groupId</param>
        /// <returns>是/否</returns>
		public static bool IsExistGroupInfo(int groupId)
		{
			return _dal.IsExistGroupInfo(groupId);
		}

        #endregion
		
		
    }
}

