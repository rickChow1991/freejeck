using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace com.iuixi.FreeJeck
{
	public class LoginController : MonoBehaviour
	{
		
		[SerializeField]
		private InputField password;
		[SerializeField]
		private InputField username;
		[SerializeField]
		private Toggle nextAutoLogin;
		[SerializeField]
		private  GameObject errortip;
		[SerializeField]
		private  Text textMessage;
		[SerializeField]
		private GameObject modal;
		private int count = 0;
		
		void Start ()
		{
			Debug.Log(Singletons.GET<ShopModel>().GetItemByIndex(410000014).szName);
			AccountNetWork _net = Singletons.GET<AccountNetWork> ();
			_net.Connect (0, "192.168.36.93", 60001, OnConnected);
			username.characterLimit = 16;
			password.characterLimit = 12;
			errortip.SetActive (false);

		}
		
		// Update is called once per frame
		// Update is called once per frame
		void Update ()
		{
			
			//name =username.text;
			
			if (Input.GetKeyDown (KeyCode.Tab)) {
				
				if (username.isFocused) {
					password.Select ();
					
				} else if (password.isFocused) {
					username.Select ();
				}
			} else if (Input.GetKeyDown (KeyCode.Return)) {
				OnLoginClick ();
			}
		}
		
		private void OnConnected (bool success)
		{
			RemoveModal ();
			if (success) {
				WebLog.Log("连接服务器成功");
			} else {
				WebLog.Log("连接服务器失败"); 
			}
		}
		
		public void AddModal ()
		{
			try {
				modal.SetActive (true);
			} catch (Exception e) {
				Loom.DispatchToMainThread (() =>
				                           {
					modal.SetActive (true);
				});   
			}
		}
		
		public void RemoveModal ()
		{
			try {
				modal.SetActive (false);
			} catch (Exception e) {
				Loom.DispatchToMainThread (() =>
				                           {
					modal.SetActive (false);
				});   
			}
			
		}
	    
		/// <summary>
		///账号密码格式
		/// </summary>
		/// <returns><c>true</c>, if format was checked, <c>false</c> otherwise.</returns>
		private bool CheckFormat ()
		{
			if (username.text == "") {
				errortip.SetActive (true);
				textMessage.text = "请输入账号后再登录";
				count = 0;
				return false;
			} else if (password.text == "") {
				errortip.SetActive (true);
				textMessage .text = "请输入密码后再登录";
				return false;
			}
			// 验证用户名，密码是否合乎规范
			
			for (int i=0; i<username.text.Length; i++) {
				if ((username.text [i] >= '0' && username.text [i] <= '9') || (username.text [i] >= 'A' && username.text [i] <= 'Z') || (username.text [i] >= 'a' && username.text [i] <= 'z') || username.text [i] == '_') {
					
					if (i == username.text.Length - 1) {
						count = 1;
					}
				} else {
					
					errortip.SetActive (true);	
					textMessage.text = "请输入正确格式账号";
					return false;
				}
			}
			
			if (count == 1) {	
				for (int i=0; i<password.text.Length; i++) {
					if (password.text [i] < 127) {	
						if (i == password.text.Length - 1) {
							count = 2;
						}
					} else {
						errortip.SetActive (true);
						textMessage.text = "请输入正确格式密码";
						return false;
					}
				}
			}
			return true;
		}
		/// <summary>
		/// 用户点击登录按钮， 登录
		/// </summary>
		private void OnLoginClick ()
		{
			if (CheckFormat ()) {
				AddModal ();
				Singletons.GET<LoginService> ().ValidateVersion ("1025", OnVailded);
				count = 0;
				textMessage.text = "";
				errortip.SetActive (false);
			}
		}
		
		private void OnVailded (Common.cs_ACK data)
		{
			if (data.GetAck () == 1) {
				WebLog.Log ("版本验证成功");
				Singletons.GET<LoginService> ().LoginServer (username.text, password.text, OnLoin);
			} else {
				// todo 
				WebLog.Log ("服务器版本不对");
			}
		}
		
		private void OnLoin (Cmdlib.cmdLOGIN_ANSWER_LOGIN_AUTH data)
		{
			// todo 验证用户基本信息
			WebLog.Log(data.GetAck ());
			WebLog.Log(data.GetEno());
			if (data.GetAck () == 1) {
				WebLog.Log("用户登陆成功");
				Singletons.GET<UserModel>().LALA_data = data;
				//Application.LoadLevel("main");
				//跟login断开链接
				Singletons.GET<AccountNetWork> ().DisConnect ();
				Loom.DispatchToMainThread(() => Singletons.GET<SceneManager>().PushScene(SceneEnum.LOADING));

				
			} else {
				// 提示用户 登陆失败
				Loom.DispatchToMainThread(()=>{
					errortip.SetActive (true);
					textMessage.text = "账号或密码错误";
				});
				
			}
			RemoveModal ();
		}
	}
}

