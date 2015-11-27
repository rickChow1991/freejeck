// ------------------------------------------------------------------------------
//	This code was edit by Emacs.
//	author : albin
//	created at : Wed Apr  8 15:08:47 2015
//  	Copyright (c) icee.cn
// ------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

namespace com.iuixi.FreeJeck
{
	/// <summary>
	///   机关触发的时候,完成的百分比
	/// </summary>
	public class TrickEventArgs : EventArgs
	{
		public float Percent { get; private set; }

		public TrickEventArgs (float percent)
		{
			this.Percent = percent;
		}
	}

	/// <summary>
	///   机关的接口
	/// </summary>
	public interface ITrick
	{
		/// <summary>
		///   当机关触发的时候
		/// </summary>
		void OnTrick (ICharacter c);

		/// <summary>
		///   当进入机关的时候, 有一些机关,有进入和离开的状态,这里我不好判断了
		/// </summary>
		void OnEnterTrick (ICharacter c);

		/// <summary>
		///   当离开机关的时候
		/// </summary>
		void OnExitTrick (ICharacter c);

		/// <summary>
		///   机关状态的更新
		/// </summary>
		void OnTrickUpdate (float dt);
	}
}

