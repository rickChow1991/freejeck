// ------------------------------------------------------------------------------
//	This code was edit by Emacs.
//	author : albin
//	created at : Thu Apr  9 14:50:39 2015
//  	Copyright (c) icee.cn
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;

namespace com.iuixi.FreeJeck
{
	public delegate void JumpDelegate (ICharacter sender);
	public interface ICharacter
	{

		/// <summary>
		///   加速
		/// </summary>
		void Boost (BoostLevel level);

		/// <summary>
		///   被撞倒,或者撞触到其它机关
		///   可能是被栏杆撞到,可能是被人撞到,也可能是在爬绳的时候,被电梯砸等等
		/// </summary>
		void Plain (int type);

		/// <summary>
		///   跨栏
		/// </summary>
		void CrossHurdle (Vector3 pos, Quaternion rotation, int level);

		/// <summary>
		///   跳到指定的地点
		/// </summary>
		void JumpTo (ref Transform target);

		/// <summary>
		///   滑行,比如在楼梯上
		/// </summary>
		void Slide ();

		/// <summary>
		///   变换赛道,快速平移
		/// </summary>
		void SwitchTrack ();

		/// <summary>
		///   攀爬,比如缆索
		/// </summary>
		void Clamb ();

		/// <summary>
		///   蹦到赛道外了, 返回赛道
		/// </summary>
		void BackToTrack ();

		/// <summary>
		///   施加一个其它方向的力,比如在移动的船上行走等
		/// </summary>
		void AddForce ();

		/// <summary>
		/// Gets the jump delegate.
		/// </summary>
		/// <returns>The jump delegate.</returns>
		JumpDelegate GetJumpDelegate ();

		/// <summary>
		/// Sets the jump delegate.
		/// </summary>
		/// <param name="theDelegate">The delegate.</param>
		void SetJumpDelegate (JumpDelegate theDelegate);

		/// <summary>
		/// Gets the transform.
		/// </summary>
		/// <returns>The transform.</returns>
		Transform GetTransform ();
	}
}
