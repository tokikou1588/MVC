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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using PB.Entity;
using PB.IDataAccessLayer;

namespace PB.DataAccessLayer
{
    /// <summary>
    /// 数据层实例化接口类 dbo.GroupInfo.
    /// </summary>
    public partial class GroupInfoDataAccessLayer : IGroupInfoDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public GroupInfoDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_GroupInfoModel">GroupInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_GroupInfoInsert(GroupInfoEntity _GroupInfoModel)
		{
			string sqlStr="CreateUpdateDelete_GroupInfoEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@GroupId",SqlDbType.Int),
			new SqlParameter("@GroupName",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_GroupInfoModel.GroupId;
			_param[2].Value=_GroupInfoModel.GroupName;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_GroupInfoModel">GroupInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_GroupInfoInsert(SqlTransaction sp,GroupInfoEntity _GroupInfoModel)
		{
			string sqlStr="CreateUpdateDelete_GroupInfoEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@GroupId",SqlDbType.Int),
			new SqlParameter("@GroupName",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_GroupInfoModel.GroupId;
			_param[2].Value=_GroupInfoModel.GroupName;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表GroupInfo更新一条记录。
		/// </summary>
		/// <param name="_GroupInfoModel">_GroupInfoModel</param>
		/// <returns>影响的行数</returns>
		public int Create_GroupInfoUpdate(GroupInfoEntity _GroupInfoModel)
		{
            string sqlStr="CreateUpdateDelete_GroupInfoEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@GroupId",SqlDbType.Int),
				new SqlParameter("@GroupName",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_GroupInfoModel.GroupId;
				_param[2].Value=_GroupInfoModel.GroupName;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表GroupInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_GroupInfoModel">_GroupInfoModel</param>
		/// <returns>影响的行数</returns>
		public int Create_GroupInfoUpdate(SqlTransaction sp,GroupInfoEntity _GroupInfoModel)
		{
            string sqlStr="CreateUpdateDelete_GroupInfoEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@GroupId",SqlDbType.Int),
				new SqlParameter("@GroupName",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_GroupInfoModel.GroupId;
				_param[2].Value=_GroupInfoModel.GroupName;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表GroupInfo中的一条记录
		/// </summary>
	    /// <param name="GroupId">groupId</param>
		/// <returns>影响的行数</returns>
		public int Create_GroupInfoDelete(int GroupId)
		{
        GroupInfoEntity _GroupInfoModel =new GroupInfoEntity();
			string sqlStr="CreateUpdateDelete_GroupInfoEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@GroupId",SqlDbType.Int),			
			new SqlParameter("@GroupName",SqlDbType.VarChar)
			};
			_param[0].Value=2;
			_param[1].Value=GroupId;
			_param[2].Value=_GroupInfoModel.GroupName;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表GroupInfo中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="GroupId">groupId</param>
		/// <returns>影响的行数</returns>
		public int Create_GroupInfoDelete(SqlTransaction sp,int GroupId)
		{
         GroupInfoEntity _GroupInfoModel =new GroupInfoEntity();
			string sqlStr="CreateUpdateDelete_GroupInfoEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@GroupId",SqlDbType.Int),
			new SqlParameter("@GroupName",SqlDbType.VarChar)
			};
			_param[0].Value=2;
			_param[1].Value=GroupId;
			_param[2].Value=_GroupInfoModel.GroupName;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  groupinfo 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>groupinfo 数据实体</returns>
		public GroupInfoEntity Populate_GroupInfoEntity_FromDr(DataRow row)
		{
			GroupInfoEntity Obj = new GroupInfoEntity();
			if(row!=null)
			{
				Obj.GroupId = (( row["GroupId"])==DBNull.Value)?0:Convert.ToInt32( row["GroupId"]);
				Obj.GroupName =  row["GroupName"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  groupinfo 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>groupinfo 数据实体</returns>
		public GroupInfoEntity Populate_GroupInfoEntity_FromDr(IDataReader dr)
		{
			GroupInfoEntity Obj = new GroupInfoEntity();
			
				Obj.GroupId = (( dr["GroupId"])==DBNull.Value)?0:Convert.ToInt32( dr["GroupId"]);
				Obj.GroupName =  dr["GroupName"].ToString();
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个GroupInfo对象
		/// </summary>
		/// <param name="groupId">groupId</param>
		/// <returns>GroupInfo对象</returns>
		public GroupInfoEntity Get_GroupInfoEntity (int groupId)
		{
			GroupInfoEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@GroupId",SqlDbType.Int)
			};
			_param[0].Value=groupId;
			string sqlStr="select * from GroupInfo where GroupId=@GroupId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_GroupInfoEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表GroupInfo所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< GroupInfoEntity> Get_GroupInfoAll()
		{
			IList< GroupInfoEntity> Obj=new List< GroupInfoEntity>();
			string sqlStr="select * from GroupInfo";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_GroupInfoEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="groupId">groupId</param>
        /// <returns>是/否</returns>
		public bool IsExistGroupInfo(int groupId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@groupId",SqlDbType.Int)
                                  };
            _param[0].Value=groupId;
            string sqlStr="select Count(*) from GroupInfo where GroupId=@groupId";
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
