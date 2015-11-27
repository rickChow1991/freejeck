// ------------------------------------------------------------------------------
//	This code was edit by Emacs.
//	author : albin
//	created at : Thu Apr  9 15:29:23 2015
//  	Copyright (c) icee.cn
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace com.iuixi.FreeJeck
{
	/// <summary>
	/// Singletons.
	/// </summary>
	class Singletons
	{

		private static Dictionary<Type, object> dic = new Dictionary<Type, object> ();

		/// <summary>
		/// 获得指定类型的实例
		/// </summary>
		/// <param name="addifnil">If set to <c>true</c> addifnil.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T GET<T> (bool addifnil = true) where T : new()
		{
			Type d1 = typeof(T);

			try {
				T res = (T)dic [d1];
				return res;
			} catch (KeyNotFoundException ex) {
				if (!addifnil)
					throw ex;
				Console.WriteLine ("{0} 未实例化过, 将被实例,并添加", d1);
			}

			T res2 = new T ();
			dic.Add (d1, res2);

			return res2;

		}

		/// <summary>
		/// 手动添加实例,实例名必须和实例的类型完全一致
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static void STORE<T> (T obj)
		{
			if (typeof(T) != obj.GetType ()) {

				throw new Exception ("要添加的类型与指定的类型不一致");
			}
			try{
				dic.Add (obj.GetType (), obj);
			}catch(Exception ex){

			}
		}
	}
}

