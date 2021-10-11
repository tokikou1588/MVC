// ===================================================================
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： DataAccessFactory.cs
// 项目名称：SunCity_MS
// 创建时间：2014/3/1
// 负责人：Chris
// ===================================================================
using System;
using System.Reflection;
using PB.IDataAccessLayer;

namespace PB.DALFactory
{
    /// <summary>
    /// 数据层工厂
    /// </summary>
    public class DataAccessFactory
    {
		private static readonly string path = System.Configuration.ConfigurationManager.AppSettings["PBDAL"]; 
		
		private static object CreateObject(string path,string CacheKey)
		{			
			object objType = DataCache.GetCache(CacheKey);
			if (objType == null)
			{
				try
				{
					objType = Assembly.Load(path).CreateInstance(CacheKey);					
					DataCache.SetCache(CacheKey, objType);
				}
				catch{}

			}
			return objType;
		}
		/// <summary>
    	/// 通过反射机制，实例化AccountInfo接口对象。
    	/// </summary>
		///<returns>AccountInfo接口对象</returns>
		public static IAccountInfoDataAccessLayer Create_AccountInfo()
		{		
			string CacheKey = path+".AccountInfoDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IAccountInfoDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化ContactInfo接口对象。
    	/// </summary>
		///<returns>ContactInfo接口对象</returns>
		public static IContactInfoDataAccessLayer Create_ContactInfo()
		{		
			string CacheKey = path+".ContactInfoDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IContactInfoDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化GroupInfo接口对象。
    	/// </summary>
		///<returns>GroupInfo接口对象</returns>
		public static IGroupInfoDataAccessLayer Create_GroupInfo()
		{		
			string CacheKey = path+".GroupInfoDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IGroupInfoDataAccessLayer)objType;		
		}

		
    }
}

