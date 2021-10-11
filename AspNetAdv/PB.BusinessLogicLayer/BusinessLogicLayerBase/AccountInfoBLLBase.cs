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
    /// BLL Layer For dbo.AccountInfo.
    /// </summary>
    public class AccountInfoBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IAccountInfoDataAccessLayer _dal=DataAccessFactory.Create_AccountInfo();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public AccountInfoBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oAccountInfoInfo">AccountInfo??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_AccountInfoInsert(AccountInfoEntity oAccountInfoInfo)
		{
			// Validate input
			if (oAccountInfoInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_AccountInfoInsert(oAccountInfoInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oAccountInfoInfo">AccountInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_AccountInfoInsert(SqlTransaction sp,AccountInfoEntity oAccountInfoInfo)
		{
			if (oAccountInfoInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_AccountInfoInsert(sp,oAccountInfoInfo);
		}
		/// <summary>
		/// 向数据表AccountInfo更新一条记录。
		/// </summary>
		/// <param name="oAccountInfoInfo">oAccountInfoInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_AccountInfoUpdate(AccountInfoEntity oAccountInfoInfo)
		{
            // Validate input
			if (oAccountInfoInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_AccountInfoUpdate(oAccountInfoInfo);
		}
		/// <summary>
		/// 向数据表AccountInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oAccountInfoInfo">oAccountInfoInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_AccountInfoUpdate(SqlTransaction sp,AccountInfoEntity oAccountInfoInfo)
		{
			// Validate input
			if (oAccountInfoInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_AccountInfoUpdate(sp,oAccountInfoInfo);
		}
		
		/// <summary>
		/// 删除数据表AccountInfo中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_AccountInfoDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_AccountInfoDelete(iD);
		}
		/// <summary>
		/// 删除数据表AccountInfo中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_AccountInfoDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_AccountInfoDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 accountinfo 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>accountinfo 数据实体</returns>
		public static AccountInfoEntity Get_AccountInfoEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_AccountInfoEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表AccountInfo所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< AccountInfoEntity> Get_AccountInfoAll()
		{
			// Use the dal to get all records 
			return _dal.Get_AccountInfoAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistAccountInfo(int iD)
		{
			return _dal.IsExistAccountInfo(iD);
		}

        #endregion
		
		
    }
}

