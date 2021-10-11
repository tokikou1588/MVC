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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using PB.Entity;
using PB.IDataAccessLayer;

namespace PB.DataAccessLayer
{
    /// <summary>
    /// 数据层实例化接口类 dbo.ContactInfo.
    /// </summary>
    public partial class ContactInfoDataAccessLayer : IContactInfoDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public ContactInfoDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_ContactInfoModel">ContactInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_ContactInfoInsert(ContactInfoEntity _ContactInfoModel)
		{
			string sqlStr="CreateUpdateDelete_ContactInfoEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ContactId",SqlDbType.VarChar),
			new SqlParameter("@IsDelete",SqlDbType.Int),
			new SqlParameter("@Account",SqlDbType.VarChar),
			new SqlParameter("@ContactName",SqlDbType.VarChar),
			new SqlParameter("@CommonMobile",SqlDbType.VarChar),
			new SqlParameter("@HeadPortrait",SqlDbType.VarChar),
			new SqlParameter("@AttFile",SqlDbType.VarChar),
			new SqlParameter("@GroupId",SqlDbType.Int)
			};
			_param[0].Value=0;
			_param[1].Value=_ContactInfoModel.ID;
			_param[2].Value=_ContactInfoModel.ContactId;
			_param[3].Value=_ContactInfoModel.IsDelete;
			_param[4].Value=_ContactInfoModel.Account;
			_param[5].Value=_ContactInfoModel.ContactName;
			_param[6].Value=_ContactInfoModel.CommonMobile;
			_param[7].Value=_ContactInfoModel.HeadPortrait;
			_param[8].Value=_ContactInfoModel.AttFile;
			_param[9].Value=_ContactInfoModel.GroupId;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ContactInfoModel">ContactInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_ContactInfoInsert(SqlTransaction sp,ContactInfoEntity _ContactInfoModel)
		{
			string sqlStr="CreateUpdateDelete_ContactInfoEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ContactId",SqlDbType.VarChar),
			new SqlParameter("@IsDelete",SqlDbType.Int),
			new SqlParameter("@Account",SqlDbType.VarChar),
			new SqlParameter("@ContactName",SqlDbType.VarChar),
			new SqlParameter("@CommonMobile",SqlDbType.VarChar),
			new SqlParameter("@HeadPortrait",SqlDbType.VarChar),
			new SqlParameter("@AttFile",SqlDbType.VarChar),
			new SqlParameter("@GroupId",SqlDbType.Int)
			};
			_param[0].Value=0;
			_param[1].Value=_ContactInfoModel.ID;
			_param[2].Value=_ContactInfoModel.ContactId;
			_param[3].Value=_ContactInfoModel.IsDelete;
			_param[4].Value=_ContactInfoModel.Account;
			_param[5].Value=_ContactInfoModel.ContactName;
			_param[6].Value=_ContactInfoModel.CommonMobile;
			_param[7].Value=_ContactInfoModel.HeadPortrait;
			_param[8].Value=_ContactInfoModel.AttFile;
			_param[9].Value=_ContactInfoModel.GroupId;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表ContactInfo更新一条记录。
		/// </summary>
		/// <param name="_ContactInfoModel">_ContactInfoModel</param>
		/// <returns>影响的行数</returns>
		public int Create_ContactInfoUpdate(ContactInfoEntity _ContactInfoModel)
		{
            string sqlStr="CreateUpdateDelete_ContactInfoEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ContactId",SqlDbType.VarChar),
				new SqlParameter("@IsDelete",SqlDbType.Int),
				new SqlParameter("@Account",SqlDbType.VarChar),
				new SqlParameter("@ContactName",SqlDbType.VarChar),
				new SqlParameter("@CommonMobile",SqlDbType.VarChar),
				new SqlParameter("@HeadPortrait",SqlDbType.VarChar),
				new SqlParameter("@AttFile",SqlDbType.VarChar),
				new SqlParameter("@GroupId",SqlDbType.Int)
				};
				_param[0].Value=1;
				_param[1].Value=_ContactInfoModel.ID;
				_param[2].Value=_ContactInfoModel.ContactId;
				_param[3].Value=_ContactInfoModel.IsDelete;
				_param[4].Value=_ContactInfoModel.Account;
				_param[5].Value=_ContactInfoModel.ContactName;
				_param[6].Value=_ContactInfoModel.CommonMobile;
				_param[7].Value=_ContactInfoModel.HeadPortrait;
				_param[8].Value=_ContactInfoModel.AttFile;
				_param[9].Value=_ContactInfoModel.GroupId;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表ContactInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ContactInfoModel">_ContactInfoModel</param>
		/// <returns>影响的行数</returns>
		public int Create_ContactInfoUpdate(SqlTransaction sp,ContactInfoEntity _ContactInfoModel)
		{
            string sqlStr="CreateUpdateDelete_ContactInfoEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ContactId",SqlDbType.VarChar),
				new SqlParameter("@IsDelete",SqlDbType.Int),
				new SqlParameter("@Account",SqlDbType.VarChar),
				new SqlParameter("@ContactName",SqlDbType.VarChar),
				new SqlParameter("@CommonMobile",SqlDbType.VarChar),
				new SqlParameter("@HeadPortrait",SqlDbType.VarChar),
				new SqlParameter("@AttFile",SqlDbType.VarChar),
				new SqlParameter("@GroupId",SqlDbType.Int)
				};
				_param[0].Value=1;
				_param[1].Value=_ContactInfoModel.ID;
				_param[2].Value=_ContactInfoModel.ContactId;
				_param[3].Value=_ContactInfoModel.IsDelete;
				_param[4].Value=_ContactInfoModel.Account;
				_param[5].Value=_ContactInfoModel.ContactName;
				_param[6].Value=_ContactInfoModel.CommonMobile;
				_param[7].Value=_ContactInfoModel.HeadPortrait;
				_param[8].Value=_ContactInfoModel.AttFile;
				_param[9].Value=_ContactInfoModel.GroupId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表ContactInfo中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_ContactInfoDelete(int ID)
		{
        ContactInfoEntity _ContactInfoModel =new ContactInfoEntity();
			string sqlStr="CreateUpdateDelete_ContactInfoEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),			
			new SqlParameter("@ContactId",SqlDbType.VarChar),
			new SqlParameter("@IsDelete",SqlDbType.Int),
			new SqlParameter("@Account",SqlDbType.VarChar),
			new SqlParameter("@ContactName",SqlDbType.VarChar),
			new SqlParameter("@CommonMobile",SqlDbType.VarChar),
			new SqlParameter("@HeadPortrait",SqlDbType.VarChar),
			new SqlParameter("@AttFile",SqlDbType.VarChar),
			new SqlParameter("@GroupId",SqlDbType.Int)
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			_param[2].Value=_ContactInfoModel.ContactId;
			_param[3].Value=_ContactInfoModel.IsDelete;
			_param[4].Value=_ContactInfoModel.Account;
			_param[5].Value=_ContactInfoModel.ContactName;
			_param[6].Value=_ContactInfoModel.CommonMobile;
			_param[7].Value=_ContactInfoModel.HeadPortrait;
			_param[8].Value=_ContactInfoModel.AttFile;
			_param[9].Value=_ContactInfoModel.GroupId;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表ContactInfo中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_ContactInfoDelete(SqlTransaction sp,int ID)
		{
         ContactInfoEntity _ContactInfoModel =new ContactInfoEntity();
			string sqlStr="CreateUpdateDelete_ContactInfoEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ContactId",SqlDbType.VarChar),
			new SqlParameter("@IsDelete",SqlDbType.Int),
			new SqlParameter("@Account",SqlDbType.VarChar),
			new SqlParameter("@ContactName",SqlDbType.VarChar),
			new SqlParameter("@CommonMobile",SqlDbType.VarChar),
			new SqlParameter("@HeadPortrait",SqlDbType.VarChar),
			new SqlParameter("@AttFile",SqlDbType.VarChar),
			new SqlParameter("@GroupId",SqlDbType.Int)
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			_param[2].Value=_ContactInfoModel.ContactId;
			_param[3].Value=_ContactInfoModel.IsDelete;
			_param[4].Value=_ContactInfoModel.Account;
			_param[5].Value=_ContactInfoModel.ContactName;
			_param[6].Value=_ContactInfoModel.CommonMobile;
			_param[7].Value=_ContactInfoModel.HeadPortrait;
			_param[8].Value=_ContactInfoModel.AttFile;
			_param[9].Value=_ContactInfoModel.GroupId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  contactinfo 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>contactinfo 数据实体</returns>
		public ContactInfoEntity Populate_ContactInfoEntity_FromDr(DataRow row)
		{
			ContactInfoEntity Obj = new ContactInfoEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.ContactId =  row["ContactId"].ToString();
				Obj.IsDelete = (( row["IsDelete"])==DBNull.Value)?0:Convert.ToInt32( row["IsDelete"]);
				Obj.Account =  row["Account"].ToString();
				Obj.ContactName =  row["ContactName"].ToString();
				Obj.CommonMobile =  row["CommonMobile"].ToString();
				Obj.HeadPortrait =  row["HeadPortrait"].ToString();
				Obj.AttFile =  row["AttFile"].ToString();
				Obj.GroupId = (( row["GroupId"])==DBNull.Value)?0:Convert.ToInt32( row["GroupId"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  contactinfo 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>contactinfo 数据实体</returns>
		public ContactInfoEntity Populate_ContactInfoEntity_FromDr(IDataReader dr)
		{
			ContactInfoEntity Obj = new ContactInfoEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.ContactId =  dr["ContactId"].ToString();
				Obj.IsDelete = (( dr["IsDelete"])==DBNull.Value)?0:Convert.ToInt32( dr["IsDelete"]);
				Obj.Account =  dr["Account"].ToString();
				Obj.ContactName =  dr["ContactName"].ToString();
				Obj.CommonMobile =  dr["CommonMobile"].ToString();
				Obj.HeadPortrait =  dr["HeadPortrait"].ToString();
				Obj.AttFile =  dr["AttFile"].ToString();
				Obj.GroupId = (( dr["GroupId"])==DBNull.Value)?0:Convert.ToInt32( dr["GroupId"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个ContactInfo对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ContactInfo对象</returns>
		public ContactInfoEntity Get_ContactInfoEntity (int iD)
		{
			ContactInfoEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from ContactInfo where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_ContactInfoEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表ContactInfo所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< ContactInfoEntity> Get_ContactInfoAll()
		{
			IList< ContactInfoEntity> Obj=new List< ContactInfoEntity>();
			string sqlStr="select * from ContactInfo";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_ContactInfoEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistContactInfo(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from ContactInfo where ID=@iD";
            int a=Convert.ToInt32(SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.Text,sqlStr,_param));
            if(a>0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

        #endregion
		
		#region----------自定义实例化接口函数----------
		#endregion
    }
}
