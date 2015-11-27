using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Cmdlib;
namespace com.iuixi.FreeJeck{
	public class RoomController : MonoBehaviour {

		// Use this for initialization
		[SerializeField]private GameObject m_Strike;
		[SerializeField]private GameObject creatRoom;
		[SerializeField]private Toggle isCollider;
		private CreatRoomMsg creatRoomMsg;

		void Start () {
			creatRoomMsg=creatRoom.GetComponent<CreatRoomMsg>();
		}
		
		// Update is called once per frame
		void Update () {

		}
		/// <summary>
		/// 显示创建房间面板以及碰撞的模式
		/// </summary>
		public void CreatRoom(){
			creatRoom.SetActive(true);
			switch(RoomGrid.BtnModel()){
			case 0:
				m_Strike.SetActive(false);

				break;
			case 1:
				m_Strike.SetActive(true);
				isCollider.isOn=true;
				break;
			case 2:
				m_Strike.SetActive(true);
				isCollider.isOn=true;
				break;
			}
		}


	}
}