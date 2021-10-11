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
namespace PB.Entity
{
	/// <summary>
	///AccountInfo数据实体
	/// </summary>
	[Serializable]
	public class AccountInfoEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _account = String.Empty;
		///<summary>
		///
		///</summary>
		private string _accountName = String.Empty;
		///<summary>
		///MD5加密
		///</summary>
		private string _pwd = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public AccountInfoEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public AccountInfoEntity
		(
			int iD,
			string account,
			string accountName,
			string pwd
		)
		{
			_iD          = iD;
			_account     = account;
			_accountName = accountName;
			_pwd         = pwd;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public int ID
		{
			get {return _iD;}
			set {_iD = value;}
		}

		///<summary>
		///
		///</summary>
		public string Account
		{
			get {return _account;}
			set {_account = value;}
		}

		///<summary>
		///
		///</summary>
		public string AccountName
		{
			get {return _accountName;}
			set {_accountName = value;}
		}

		///<summary>
		///MD5加密
		///</summary>
		public string Pwd
		{
			get {return _pwd;}
			set {_pwd = value;}
		}
	
		#endregion
		
	}
}
