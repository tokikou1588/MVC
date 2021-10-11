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
    /// BLL Layer For dbo.ContactInfo.
    /// </summary>
    public class ContactInfoBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IContactInfoDataAccessLayer _dal=DataAccessFactory.Create_ContactInfo();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public ContactInfoBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oContactInfoInfo">ContactInfo??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_ContactInfoInsert(ContactInfoEntity oContactInfoInfo)
		{
			// Validate input
			if (oContactInfoInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_ContactInfoInsert(oContactInfoInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oContactInfoInfo">ContactInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_ContactInfoInsert(SqlTransaction sp,ContactInfoEntity oContactInfoInfo)
		{
			if (oContactInfoInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_ContactInfoInsert(sp,oContactInfoInfo);
		}
		/// <summary>
		/// 向数据表ContactInfo更新一条记录。
		/// </summary>
		/// <param name="oContactInfoInfo">oContactInfoInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_ContactInfoUpdate(ContactInfoEntity oContactInfoInfo)
		{
            // Validate input
			if (oContactInfoInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_ContactInfoUpdate(oContactInfoInfo);
		}
		/// <summary>
		/// 向数据表ContactInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oContactInfoInfo">oContactInfoInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_ContactInfoUpdate(SqlTransaction sp,ContactInfoEntity oContactInfoInfo)
		{
			// Validate input
			if (oContactInfoInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_ContactInfoUpdate(sp,oContactInfoInfo);
		}
		
		/// <summary>
		/// 删除数据表ContactInfo中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_ContactInfoDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_ContactInfoDelete(iD);
		}
		/// <summary>
		/// 删除数据表ContactInfo中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_ContactInfoDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_ContactInfoDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 contactinfo 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>contactinfo 数据实体</returns>
		public static ContactInfoEntity Get_ContactInfoEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_ContactInfoEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表ContactInfo所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< ContactInfoEntity> Get_ContactInfoAll()
		{
			// Use the dal to get all records 
			return _dal.Get_ContactInfoAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistContactInfo(int iD)
		{
			return _dal.IsExistContactInfo(iD);
		}

        #endregion
		
		
    }
}

