// ------------------------------------------------------------------------------
//	This code was edit by Emacs.
//	author : albin
//	created at : Thu Apr  9 15:29:23 2015
//  	Copyright (c) icee.cn
// ------------------------------------------------------------------------------
using System;
using System.Collections;
using UnityEngine;

namespace com.iuixi.FreeJeck
{
	public class AnimEventArgs : EventArgs
	{
		public readonly AnimatorStateInfo info;
		public readonly Animator animator;
		public readonly int layerIndex;

		public AnimEventArgs (Animator anim, AnimatorStateInfo info, int lay)
		{
			this.animator = anim;
			this.info = info;
			this.layerIndex = lay;
		}
	}
    
	/// <summary>
	/// ClassName:AnimManager
	/// Date:Thu Apr  9 15:29:31 2015
	/// Author: albin
	/// Description: 动画事件分分器
	/// </summary>
	public class AnimManager
	{
		private static AnimManager m_Instance = null;

		public static AnimManager SharedInstance ()
		{
			if (m_Instance == null) {
				m_Instance = new AnimManager ();
			}
			return m_Instance;
		}

		public delegate void AnimHandler (AnimManager sender, AnimEventArgs e);

		public event AnimHandler OnEnter;
		public event AnimHandler OnStay;
		public event AnimHandler OnExit;

		/// <summary>
		/// 进入某个动画
		/// </summary>
		public void EnterAnim (Animator anim, AnimatorStateInfo info, int layer)
		{
			if (OnEnter != null) {
				OnEnter (this, new AnimEventArgs (anim, info, layer));
			}
		}

		/// <summary>
		/// 退出某段动画
		/// </summary>
		public void ExitAnim (Animator anim, AnimatorStateInfo info, int layer)
		{
			if (OnExit != null) {
				OnExit (this, new AnimEventArgs (anim, info, layer));
			}
		}

		/// <summary>
		/// 继续待在某个动画中
		/// </summary>
		public void StayAnim (Animator anim, AnimatorStateInfo info, int layer)
		{
			if (OnStay != null) {
				OnStay (this, new AnimEventArgs (anim, info, layer));
			}
		}
	}	
}
