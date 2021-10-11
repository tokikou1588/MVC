// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： DataCache.cs
// 项目名称：SunCity_MS
// 创建时间：2014/3/1
// 负责人：Chris
// ===================================================================
using System;
using System.Web;

namespace PB.DALFactory
{
	/// <summary>
	/// Summary description for DataCache.
	/// </summary>
	public class DataCache
	{
		public DataCache()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public static object GetCache(string CacheKey)
		{

			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			return objCache[CacheKey];

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject);
		}
	}
}
