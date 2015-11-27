using UnityEngine;
using System.Collections;
using System;

namespace com.iuixi.FreeJeck
{
	/// <summary>
	/// ClassName:AnimStateController
	/// Date:Wed Apr  8 10:46:28 2015
	/// Author: albin
	/// Description: 测试第一个场景的demo, 后续会添加
	/// </summary>
	public class MyCharacter : MonoBehaviour, ICharacter, IFllowTarget
	{

		/// <summary>
		/// injector attrbuite: 极限最大速度, 一般来说是吃了道具,或者碰触到一些机关的时候
		/// </summary>
		[SerializeField] private float m_BoostSpeed = 0.3f;
	
		/// <summary>
		/// injector attrbuite: 正常时候的最大速度,非道具等其它效果的时候
		/// </summary>
		[SerializeField] private float m_NormalSpeed = 0.3f;
	
		/// <summary>
		/// injector attrbuite: 当反向运动的时候,以正常加速度的多少倍进行反向加速
		/// </summary>
		[SerializeField] private float m_ReverseMult = 4.0f;
	
		/// <summary>
		/// injector attrbuite: 加速度
		/// </summary>
		[SerializeField] private float m_Acce = 0.1f;
	
		/// <summary>
		/// injector attrbuite: 转向的灵敏度
		/// </summary>
		[SerializeField] private float m_TurnSen = 0.1f;
	
		/// <summary>
		/// injector attrbuite: 加速带效果的持续时间
		/// </summary>
		[SerializeField] private float m_BoostTime = 3.0f;
	
		/// <summary>
		/// injector attrbuite: 起跳的速度,决定了角色能够跳多高
		/// </summary>
		[SerializeField] private float m_JumpSpeed = 0f;
	
		/// <summary>
		/// injector attrbuite: 对characterController向下的力
		/// </summary>
		[SerializeField] private float m_StickToGroundForce = 1f;
	
		/// <summary>
		/// injector attrbuite:  重力
		/// </summary>
		[SerializeField] private float m_GravityMultiplier = 1f;

		/// <summary>
		/// 当前速度 
		/// </summary>
		public float Speed { get; private set; }

		/// <summary>
		/// 是否处于漂移状态
		/// </summary>
		public bool IsDrift { get; private set; }

		private float m_MaxSpeed;
		// 当前状态可以达到的最大速度,会根据不同的状态而改变
		private float m_Accelerator;
		// 当前的加速度
		private bool m_IsJumpArea = false;
		// 是否在跨栏区域
		private Transform m_JumpTarget = null;
		// 跨栏的时候,角色的左手所碰触到的点
		private float m_BoostLeft = 0.0f;
		// 加速状态还剩余多少时间
		private bool m_Jumping;
		// 是否处于跳跃状态
		private bool m_Jump;
		// 是否按下起跳键
		private Vector3 m_MoveDir;
		// 下一帧应该移动的距离
		private bool m_PreviouslyGrounded;
		// 上一帧是否在地上,也就是没跳
		private bool m_LockInput = false;

	
		private Animator m_Animator;
		// 角色动画控制器
		private CharacterController m_Controller;
		// 角色行走控制器

		private JumpDelegate m_JumpDelegate = null;

		private AnimManager m_AnimManager;

		void Start ()
		{
			m_AnimManager = AnimManager.SharedInstance ();
			m_AnimManager.OnEnter += OnAnimEnter;
			m_AnimManager.OnExit += OnAnimExit;

			m_Controller = GetComponent<CharacterController> ();
			m_Animator = GetComponent<Animator> ();
			if (m_Animator.layerCount >= 2)
				m_Animator.SetLayerWeight (1, 1);
			m_Animator.speed = 1.5f;
		}

		/// <summary>
		/// Raises the animation enter event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnAnimEnter (AnimManager sender, AnimEventArgs e)
		{
			if (e.animator == this.m_Animator) {
				if (e.info.IsName ("Plain")) {

				}
			}
		}

		/// <summary>
		/// Raises the animation exit event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnAnimExit (AnimManager sender, AnimEventArgs e)
		{
			if (e.animator == this.m_Animator) {
				if (e.info.IsName ("Plain")) {
					m_LockInput = false;
				}
			}
		}

		private float GetAxis(string s){
			if (!m_LockInput) {
				return Input.GetAxis (s);
			}
			return 0;
		}

		private float GetAccelerator ()
		{
			if (IsDrift || m_Jumping) {
				return 0f;
			}
			return m_Acce * (m_BoostLeft > 0f ? 2 : 1);
		}


		void FixedUpdate ()
		{
			float fdt = Time.fixedDeltaTime;

			if (m_Controller.isGrounded) {
				m_MoveDir.y = -m_StickToGroundForce;

				if (m_Jump && !m_Jumping) {
					if (m_JumpDelegate != null){
						m_JumpDelegate (this);
					} else {
						if (m_Animator.GetFloat ("Speed") < 0.3f) {
							m_Animator.SetFloat ("JumpType", 1f);
						} else {
							m_Animator.SetFloat ("JumpType", 2f);
						}
						m_MoveDir.y = m_JumpSpeed;
						m_Jumping = true;
					}
					m_Jump = false;
				}
			} else {
				m_MoveDir += Physics.gravity * m_GravityMultiplier * fdt;
			}
			m_Controller.Move (m_MoveDir * fdt);

			float drift = GetAxis ("Drift");
			float hAxis = GetAxis ("Horizontal");

			float speed = Speed / m_BoostSpeed;
			if (speed < 0f)
				speed = -1f;
			else if (speed >= 0f && speed < 0.2f)
				speed = 0f;
			else if (speed >= 0.2f && speed < 0.75f)
				speed = 0.5f;
			else
				speed = 1f;
			m_Animator.SetFloat ("Speed", speed);
			hAxis = hAxis > 0 ? 1 : (hAxis < 0f ? -1 : 0f);
			m_Animator.SetFloat ("hAxis", hAxis > 0 ? 1 : (hAxis < 0f ? -1 : 0f));


			if (Speed != 0f || hAxis != 0f) {
				m_Animator.SetBool ("Move", true);
			} else {
				m_Animator.SetBool ("Move", false);
			}
			if ((drift > 0f || Input.GetKeyDown (KeyCode.LeftShift)) && hAxis != 0) {
				this.IsDrift = true;
				m_Animator.SetBool ("Drift", true);
			} else {
				this.IsDrift = false;
				m_Animator.SetBool ("Drift", false);
			}
			Quaternion m_CharacterTargetRot = transform.localRotation;
			m_CharacterTargetRot *= Quaternion.Euler (0f, hAxis * (IsDrift ? 2f * m_TurnSen : m_TurnSen) * fdt, 0f);
			transform.localRotation = m_CharacterTargetRot;

		}

		// Update is called once per frame
		void Update ()
		{
			float dt = Time.deltaTime;
			if ((m_BoostLeft -= dt) <= 0f) {
				m_BoostLeft = 0f;
				m_MaxSpeed = m_NormalSpeed;
			}
			if (m_Animator.GetCurrentAnimatorStateInfo (0).IsName ("JumpHurdles")) {
				return;
			}

			if (!m_PreviouslyGrounded && m_Controller.isGrounded) {
				m_MoveDir.y = 0f;
				m_Jumping = false;
			}
			if (!m_Controller.isGrounded && !m_Jumping && m_PreviouslyGrounded) {
				m_MoveDir.y = 0f;
			}
			m_PreviouslyGrounded = m_Controller.isGrounded;

			if (!m_Controller.isGrounded) {
				return;
			}

			float vAxis = GetAxis ("Vertical");
			m_Jump = GetAxis ("Jump") > 0f;
			m_Accelerator = GetAccelerator () * dt;

			if (vAxis > 0) { // 向前
				Speed += (Speed < 0 ? m_ReverseMult : 1) * m_Accelerator;
			} else if (vAxis < 0) { // 向后
				this.Speed -= (this.Speed > 0 ? m_ReverseMult : 1) * m_Accelerator;
			} else {
				if (this.Speed > 0f) {
					this.Speed -= m_Accelerator;
					if (this.Speed < 0f)
						this.Speed = 0;
				} else if (this.Speed < 0f) {
					this.Speed += m_Accelerator;
					if (this.Speed > 0f)
						this.Speed = 0;
				}
			}

			if (this.Speed > m_MaxSpeed)
				this.Speed = m_MaxSpeed;
			if (this.Speed < -m_NormalSpeed / 2f)
				this.Speed = -m_NormalSpeed / 2f;

			Vector3 tmp = transform.forward;
			m_MoveDir.x = tmp.x * this.Speed;
			m_MoveDir.z = tmp.z * this.Speed;
		}

		/// <summary>
		/// Raises the trigger enter event.
		/// </summary>
		/// <param name="c">C.</param>
		void OnTriggerEnter (Collider c)
		{
			if (c != null) {
				if (c.tag == "Tricker") {
					c.gameObject.BroadcastMessage("OnEnterTrick", this);
				}
			}
		}

		/// <summary>
		/// Raises the trigger exit event.
		/// </summary>
		/// <param name="c">C.</param>
		void OnTriggerExit (Collider c)
		{
			if (c != null) {
				if (c.tag == "Tricker") {
					ITrick trick = c.gameObject.GetComponent<ITrick> ();
					if (trick != null) {
						trick.OnExitTrick (this);
					}
				}
			}
		}

		// ------------------------------------------------------------------------------------
		// implements ICharacter
		// ------------------------------------------------------------------------------------

		/// <summary>
		/// 加速
		/// </summary>
		/// <param name="level">Level.</param>
		public void Boost (BoostLevel level)
		{
			switch (level) {
			case BoostLevel.NORMAL_BOOST:
				{
					this.Speed = this.m_MaxSpeed = this.m_BoostSpeed;
					break;
				}
			}
		}
			
		/// <summary>
		/// 被撞倒,或者撞触到其它机关
		///  可能是被栏杆撞到,可能是被人撞到,也可能是在爬绳的时候,被电梯砸等等
		/// </summary>
		/// <param name="type">Type.</param>
		public void Plain (int type)
		{
			m_Animator.SetTrigger ("Plain");
			this.Speed = 0f;
			m_LockInput = true;
		}

		/// <summary>
		/// 跨栏
		/// </summary>
		/// <param name="pos">Position.</param>
		/// <param name="rotation">Rotation.</param>
		/// <param name="level">Level.</param>
		public void CrossHurdle (Vector3 pos, Quaternion rotation, int level)
		{
			transform.rotation = rotation;
			m_Animator.Play ("JumpHurdles");
			m_Animator.MatchTarget (pos, rotation, AvatarTarget.LeftFoot, new MatchTargetWeightMask (Vector3.zero, 0f), 0.1f, 0.4f);
		}

		/// <summary>
		/// 跳到指定的地点
		/// </summary>
		/// <param name="target">Target.</param>
		public void JumpTo (ref Transform target)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// 滑行,比如在楼梯上
		/// </summary>
		public void Slide ()
		{
			throw new NotImplementedException ();
		}
			
		///<summary>
		///  变换赛道,快速平移
		///</summary>
		public void SwitchTrack ()
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// 攀爬,比如缆索
		/// </summary>
		public void Clamb ()
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// 蹦到赛道外了, 返回赛道
		/// </summary>
		public void BackToTrack ()
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// 施加一个其它方向的力,比如在移动的船上行走等
		/// </summary>
		public void AddForce ()
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Gets the jump delegate.
		/// </summary>
		/// <returns>The jump delegate.</returns>
		public JumpDelegate GetJumpDelegate ()
		{
			return m_JumpDelegate;
		}

		/// <summary>
		/// Sets the jump delegate.
		/// </summary>
		/// <param name="theDelegate">The delegate.</param>
		public void SetJumpDelegate (JumpDelegate theDelegate)
		{
			m_JumpDelegate = theDelegate;
		}

		/// <summary>
		/// Gets the transform.
		/// </summary>
		/// <returns>The transform.</returns>
		public Transform GetTransform ()
		{
			return transform;
		}
			
		/// <summary>
		/// Gets the current speed.
		/// </summary>
		/// <returns>The current speed.</returns>
		public float GetCurrentSpeed ()
		{
			return Speed;
		}

		/// <summary>
		/// Gets the max speed.
		/// </summary>
		/// <returns>The max speed.</returns>
		public float GetMaxSpeed ()
		{
			return m_BoostSpeed;
		}

		/// <summary>
		/// Gets the is drift.
		/// </summary>
		/// <returns>true</returns>
		/// <c>false</c>
		public bool GetIsDrift ()
		{
			return IsDrift;
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the <see cref="MyCharacter"/> is
		/// reclaimed by garbage collection.
		/// </summary>
		~MyCharacter ()
		{
			if(m_AnimManager != null) m_AnimManager.OnEnter -= OnAnimEnter;
		}
	}
}