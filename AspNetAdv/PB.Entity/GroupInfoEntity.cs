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
namespace PB.Entity
{
	/// <summary>
	///GroupInfo数据实体
	/// </summary>
	[Serializable]
	public class GroupInfoEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _groupId;
		///<summary>
		///
		///</summary>
		private string _groupName = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public GroupInfoEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public GroupInfoEntity
		(
			int groupId,
			string groupName
		)
		{
			_groupId   = groupId;
			_groupName = groupName;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public int GroupId
		{
			get {return _groupId;}
			set {_groupId = value;}
		}

		///<summary>
		///
		///</summary>
		public string GroupName
		{
			get {return _groupName;}
			set {_groupName = value;}
		}
	
		#endregion
		
	}
}
