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
namespace PB.Entity
{
	/// <summary>
	///ContactInfo数据实体
	/// </summary>
	[Serializable]
	public class ContactInfoEntity
	{
		#region 变量定义
		///<summary>
		///主键 自增
		///</summary>
		private int _iD;
		///<summary>
		///联系人id
		///</summary>
		private string _contactId = String.Empty;
		///<summary>
		///0:正常 1：删除
		///</summary>
		private int _isDelete;
		///<summary>
		///账号
		///</summary>
		private string _account = String.Empty;
		///<summary>
		///联系人名称
		///</summary>
		private string _contactName = String.Empty;
		///<summary>
		///联系电话
		///</summary>
		private string _commonMobile = String.Empty;
		///<summary>
		///联系人头像
		///</summary>
		private string _headPortrait = String.Empty;
		///<summary>
		///联系人的附件
		///</summary>
		private string _attFile = String.Empty;
		///<summary>
		///联系人所属组
		///</summary>
		private int _groupId;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public ContactInfoEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public ContactInfoEntity
		(
			int iD,
			string contactId,
			int isDelete,
			string account,
			string contactName,
			string commonMobile,
			string headPortrait,
			string attFile,
			int groupId
		)
		{
			_iD           = iD;
			_contactId    = contactId;
			_isDelete     = isDelete;
			_account      = account;
			_contactName  = contactName;
			_commonMobile = commonMobile;
			_headPortrait = headPortrait;
			_attFile      = attFile;
			_groupId      = groupId;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///主键 自增
		///</summary>
		public int ID
		{
			get {return _iD;}
			set {_iD = value;}
		}

		///<summary>
		///联系人id
		///</summary>
		public string ContactId
		{
			get {return _contactId;}
			set {_contactId = value;}
		}

		///<summary>
		///0:正常 1：删除
		///</summary>
		public int IsDelete
		{
			get {return _isDelete;}
			set {_isDelete = value;}
		}

		///<summary>
		///账号
		///</summary>
		public string Account
		{
			get {return _account;}
			set {_account = value;}
		}

		///<summary>
		///联系人名称
		///</summary>
		public string ContactName
		{
			get {return _contactName;}
			set {_contactName = value;}
		}

		///<summary>
		///联系电话
		///</summary>
		public string CommonMobile
		{
			get {return _commonMobile;}
			set {_commonMobile = value;}
		}

		///<summary>
		///联系人头像
		///</summary>
		public string HeadPortrait
		{
			get {return _headPortrait;}
			set {_headPortrait = value;}
		}

		///<summary>
		///联系人的附件
		///</summary>
		public string AttFile
		{
			get {return _attFile;}
			set {_attFile = value;}
		}

		///<summary>
		///联系人所属组
		///</summary>
		public int GroupId
		{
			get {return _groupId;}
			set {_groupId = value;}
		}
	
		#endregion
		
	}
}
