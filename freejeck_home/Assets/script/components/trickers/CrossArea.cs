using System;
using UnityEngine;

namespace com.iuixi.FreeJeck
{
	public class CrossArea : BaseTricker
	{
		/// <summary>
		/// 当进入机关的时候, 有一些机关,有进入和离开的状态,这里我不好判断了
		/// </summary>
		/// <param name="c">C.</param>
		public override void OnEnterTrick (ICharacter c)
		{
			if (!transform.parent.GetComponent<Hurdle> ().IsCollison) {
				c.SetJumpDelegate (Jump);
			}
		}

		/// <summary>
		/// 当离开机关的时候
		/// </summary>
		/// <param name="c">C.</param>
		public override void OnExitTrick (ICharacter c)
		{
			c.SetJumpDelegate (null);
		}

		/// <summary>
		/// Jump the specified c.
		/// </summary>
		/// <param name="c">C.</param>
		private void Jump (ICharacter c)
		{
			transform.parent.GetComponent<Hurdle> ().TmpLost ();
			Vector3 pos;
			Quaternion roa;
			GetJumpArgs (out pos, out roa, c.GetTransform ());
			c.CrossHurdle (pos, roa, 0);
		}

		private void GetJumpArgs (out Vector3 pos, out Quaternion roa, Transform trans)
		{
			Transform jumpTarget = transform.parent.FindChild ("target").transform;
			Vector3 t = jumpTarget.position;
			Vector3 m = trans.position;
			roa = jumpTarget.rotation;
			Vector3 direction = jumpTarget.forward;
			float dis = Vector3.Distance (t, m);
			float angle = Vector3.Angle (direction, m - t);
			float d = Mathf.Cos (angle * Mathf.PI / 180f);
			pos = direction * d * dis + t;
		}
	}
}

