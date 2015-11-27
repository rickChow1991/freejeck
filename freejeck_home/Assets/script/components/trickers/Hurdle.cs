using UnityEngine;
using System.Collections;

namespace com.iuixi.FreeJeck
{
	public class Hurdle : BaseTricker
	{
		[SerializeField ] private float RestoreTime = 10f;

		private float m_CDTime = 0f;

		/// <summary>
		///   撞倒的时间
		/// </summary>
		private float npcTime;

		/// <summary>
		///   撞倒时栏的动画
		/// </summary>
		private Animation _npcAnimation;

		/// <summary>
		/// 是否被撞倒
		/// </summary>
		/// <value><c>bool</c></value>
		public bool IsCollison{ get; private set; }

		/// <summary>
		/// 当进入机关的时候, 有一些机关,有进入和离开的状态,这里我不好判断了
		/// </summary>
		/// <param name="c">C.</param>
		public override void OnEnterTrick (ICharacter c)
		{
			this.IsCollison = true;
			GetComponent<Collider> ().enabled = false;
			_npcAnimation.Play ("npc00_hurdle01_cheer");
			npcTime = Time.time;
			m_CDTime = RestoreTime;
			c.Plain (0);
		}

		/// <summary>
		/// 临时失效, 因为人物在跨栏的时候,这个栏杆是不会响应跌倒的事件的
		/// </summary>
		public void TmpLost()
		{
			GetComponent<Collider> ().enabled = false;
			npcTime = Time.time;
			m_CDTime = 0.5f;
			this.IsCollison = true;
		}

		void Start ()
		{
			_npcAnimation = gameObject.GetComponent<Animation> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (npcTime != 0 && IsCollison) {
				if (Time.time - npcTime > m_CDTime) {
					IsCollison = false;
					GetComponent<Collider> ().enabled = true;
					_npcAnimation.Play ("npc00_hurdle01_sit");
				}
			}
		}
	}
}