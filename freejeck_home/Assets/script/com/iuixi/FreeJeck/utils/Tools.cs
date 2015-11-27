// ------------------------------------------------------------------------------
//	This code was edit by Emacs.
//	author : albin
//	created at : Wed Apr 22 17:32:18 2015
//  	Copyright (c) icee.cn
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;

namespace com.iuixi.FreeJeck{
    public class Tools
    {
        /// <summary>
        /// Description
        /// </summary>
        /// <returns><c>void static</c></returns>
        public  static  void DumpBytes(byte[] bytes)
        {
            int len = bytes.Length;
            string hex = "";
            for (int i = 0; i < len; ++i)
            {
                if(i % 10 == 0){
                    WebLog.Log(hex);
                    hex = "";
                }
                hex += bytes[i].ToString("x2") + " ";
            }

        }

        public static string  ReadWchar(char[] chars)
        {
            string res = "";
            int len = chars.Length;
            for (int i = 0; i < len; i+=2)
            {
                res += chars[i];
            }
            return res;
        }
		public static string  Readchar(char[] chars)
		{
			string res = "";
			int len = chars.Length;
			for (int i = 0; i < len; i+=1)
			{
				res += chars[i];
			}
			return res;
		}
		public static string  ReadBytes(byte [] bytes)
		{
			string ss = System.Text.Encoding.ASCII.GetString(bytes); 
			return ss;
		}
    }
}
