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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using PB.Entity;
using PB.IDataAccessLayer;

namespace PB.DataAccessLayer
{
    /// <summary>
    /// 数据层实例化接口类 dbo.AccountInfo.
    /// </summary>
    public partial class AccountInfoDataAccessLayer : IAccountInfoDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public AccountInfoDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_AccountInfoModel">AccountInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_AccountInfoInsert(AccountInfoEntity _AccountInfoModel)
		{
			string sqlStr="CreateUpdateDelete_AccountInfoEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@Account",SqlDbType.VarChar),
			new SqlParameter("@AccountName",SqlDbType.VarChar),
			new SqlParameter("@Pwd",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_AccountInfoModel.ID;
			_param[2].Value=_AccountInfoModel.Account;
			_param[3].Value=_AccountInfoModel.AccountName;
			_param[4].Value=_AccountInfoModel.Pwd;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_AccountInfoModel">AccountInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_AccountInfoInsert(SqlTransaction sp,AccountInfoEntity _AccountInfoModel)
		{
			string sqlStr="CreateUpdateDelete_AccountInfoEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@Account",SqlDbType.VarChar),
			new SqlParameter("@AccountName",SqlDbType.VarChar),
			new SqlParameter("@Pwd",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_AccountInfoModel.ID;
			_param[2].Value=_AccountInfoModel.Account;
			_param[3].Value=_AccountInfoModel.AccountName;
			_param[4].Value=_AccountInfoModel.Pwd;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表AccountInfo更新一条记录。
		/// </summary>
		/// <param name="_AccountInfoModel">_AccountInfoModel</param>
		/// <returns>影响的行数</returns>
		public int Create_AccountInfoUpdate(AccountInfoEntity _AccountInfoModel)
		{
            string sqlStr="CreateUpdateDelete_AccountInfoEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@Account",SqlDbType.VarChar),
				new SqlParameter("@AccountName",SqlDbType.VarChar),
				new SqlParameter("@Pwd",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_AccountInfoModel.ID;
				_param[2].Value=_AccountInfoModel.Account;
				_param[3].Value=_AccountInfoModel.AccountName;
				_param[4].Value=_AccountInfoModel.Pwd;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表AccountInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_AccountInfoModel">_AccountInfoModel</param>
		/// <returns>影响的行数</returns>
		public int Create_AccountInfoUpdate(SqlTransaction sp,AccountInfoEntity _AccountInfoModel)
		{
            string sqlStr="CreateUpdateDelete_AccountInfoEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@Account",SqlDbType.VarChar),
				new SqlParameter("@AccountName",SqlDbType.VarChar),
				new SqlParameter("@Pwd",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_AccountInfoModel.ID;
				_param[2].Value=_AccountInfoModel.Account;
				_param[3].Value=_AccountInfoModel.AccountName;
				_param[4].Value=_AccountInfoModel.Pwd;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表AccountInfo中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_AccountInfoDelete(int ID)
		{
        AccountInfoEntity _AccountInfoModel =new AccountInfoEntity();
			string sqlStr="CreateUpdateDelete_AccountInfoEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),			
			new SqlParameter("@Account",SqlDbType.VarChar),
			new SqlParameter("@AccountName",SqlDbType.VarChar),
			new SqlParameter("@Pwd",SqlDbType.VarChar)
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			_param[2].Value=_AccountInfoModel.Account;
			_param[3].Value=_AccountInfoModel.AccountName;
			_param[4].Value=_AccountInfoModel.Pwd;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表AccountInfo中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_AccountInfoDelete(SqlTransaction sp,int ID)
		{
         AccountInfoEntity _AccountInfoModel =new AccountInfoEntity();
			string sqlStr="CreateUpdateDelete_AccountInfoEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@Account",SqlDbType.VarChar),
			new SqlParameter("@AccountName",SqlDbType.VarChar),
			new SqlParameter("@Pwd",SqlDbType.VarChar)
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			_param[2].Value=_AccountInfoModel.Account;
			_param[3].Value=_AccountInfoModel.AccountName;
			_param[4].Value=_AccountInfoModel.Pwd;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  accountinfo 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>accountinfo 数据实体</returns>
		public AccountInfoEntity Populate_AccountInfoEntity_FromDr(DataRow row)
		{
			AccountInfoEntity Obj = new AccountInfoEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.Account =  row["Account"].ToString();
				Obj.AccountName =  row["AccountName"].ToString();
				Obj.Pwd =  row["Pwd"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  accountinfo 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>accountinfo 数据实体</returns>
		public AccountInfoEntity Populate_AccountInfoEntity_FromDr(IDataReader dr)
		{
			AccountInfoEntity Obj = new AccountInfoEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.Account =  dr["Account"].ToString();
				Obj.AccountName =  dr["AccountName"].ToString();
				Obj.Pwd =  dr["Pwd"].ToString();
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个AccountInfo对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>AccountInfo对象</returns>
		public AccountInfoEntity Get_AccountInfoEntity (int iD)
		{
			AccountInfoEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from AccountInfo where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_AccountInfoEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表AccountInfo所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< AccountInfoEntity> Get_AccountInfoAll()
		{
			IList< AccountInfoEntity> Obj=new List< AccountInfoEntity>();
			string sqlStr="select * from AccountInfo";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_AccountInfoEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistAccountInfo(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from AccountInfo where ID=@iD";
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
