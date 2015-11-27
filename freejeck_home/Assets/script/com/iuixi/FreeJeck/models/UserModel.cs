using System;
using System.Collections;
using System.Collections.Generic;
using Cmdlib;
using UnityEngine;
using com.iuixi.FreeJeck.Types.ShopItems;
namespace com.iuixi.FreeJeck
{
	public class UserModel
	{
		private ShopModel shopModel = Singletons.GET<ShopModel> ();
		private IEnumerable<entry> m_Avatars = null;
		
		/// <summary>
		///  client往LoginSever发送 LOGIN_REQUEST_LOGIN_AUTH 后返回给client的消息 LOGIN_ANSWER_LOGIN_AUTH 的消息包
		/// </summary>
		public	Cmdlib.cmdLOGIN_ANSWER_LOGIN_AUTH LALA_data;
		
		/// <summary>
		///client往LobbySever发送 GAME_REQUEST_LOGIN_AUTH 后返回给client的消息 GAME_ANSWER_LOGIN_AUTH 的消息包
		/// </summary>
		public	Cmdlib.cmdGAME_ANSWER_LOGIN_AUTH GALA_data;
		
		/// <summary>
		///   用户基础属性
		/// </summary>
		public cmdGAME_ANSWER_USER_INFO GAUI_userinfo;
		public cmdGAME_ANSWER_CHAR_INFO GACI_charinfo;
		public CmdGameAnswerCashInfo GACI_cashinfo;
		
		private IEnumerable<entry> GetAvatars()
		{
			yield return shopModel.GetItemByIndex(GACI_charinfo.info.hair);
			yield return shopModel.GetItemByIndex(GACI_charinfo.info.lower);
			yield return shopModel.GetItemByIndex(GACI_charinfo.info.upper);
			yield return shopModel.GetItemByIndex(GACI_charinfo.info.shoes);
		}
		
		public IEnumerable<entry> avatars
		{
			get
			{
				if(m_Avatars == null)
				{
					m_Avatars = GetAvatars();
				}
				return m_Avatars;
			}
		}
	}
}

