// ------------------------------------------------------------------------------
//	This code was edit by Emacs.
//	author : albin
//	created at : Thu Apr  9 14:08:05 2015
//  	Copyright (c) icee.cn
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;

namespace com.iuixi.FreeJeck
{
	/// <summary>
	/// ClassName:BaseTricker
	/// Date:Thu Apr  9 14:08:17 2015
	/// Author: albin
	/// Description: 机关的基类
	/// </summary>
	public class BaseTricker : MonoBehaviour, ITrick
	{
                
		/// <summary>
		/// Standard Start
		/// </summary>
		void Start ()
		{
                   
		}

		/// <summary>
		/// Standart update
		void Updtae ()
		{
                        
		}

		/// <summary>
		/// 机关的名字
		/// </summary>
		/// <value><c>string</c></value>
		public virtual string Name{ get; private set; }


		// ----------------------------------------------------------------------
		// implements ITricker
		// ----------------------------------------------------------------------
		/// <summary>
		/// 机关触发的时候, 有些机关不是碰到就触发的,比如栏杆,还需要玩家跳一下才可以
		/// </summary>
		public virtual void OnTrick (ICharacter c)
		{
                        
		}

		/// <summary>
		/// 进入机关,有些进入机关的时候就要求调用OnTrick
		/// </summary>
		public virtual void OnEnterTrick (ICharacter c)
		{
                        
		}

		/// <summary>
		/// 离开机关
		/// </summary>
		public virtual void OnExitTrick (ICharacter c)
		{
			throw new Exception("basetricker can not be initialized");            
		}

		/// <summary>
		/// 机关状态更新
		/// </summary>
		public virtual void OnTrickUpdate (float dt)
		{
                        
		}
	}
}
