// ------------------------------------------------------------------------------
//	This code was edit by Emacs.
//	author : albin
//	created at : Wed Apr 22 17:09:31 2015
//  	Copyright (c) icee.cn
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System ;

namespace com.iuixi.FreeJeck{
	/// <summary>
	/// ClassName:HallController
	/// Date:Wed Apr 22 17:09:43 2015
	/// Author: albin
	/// Description: 用户大厅的Controller
	/// </summary>
	public class MeauController : MonoBehaviour {

		[SerializeField] private Text name;
		[SerializeField] private Text level;
		[SerializeField] private Text money;
		[SerializeField] private GameObject store;
		[SerializeField] private GameObject msg;
		
		//打开ui按钮
		[SerializeField] private Button openui;
		[SerializeField] private Button openshop;

		private UserModel model = Singletons.GET<UserModel>();
		private LobbyService proxy = Singletons.GET<LobbyService>();

		/// <summary>
		/// Standard Start
		/// </summary>
		void Start() {
			//Instantiate ( Resources .Load("prefabs/personmsg"));
		

		}
		
		/// <summary>
		/// Standart update
		void Updtae() {


		}
		void OpenPersonBtn ()
		{
			msg.SetActive (true);
		}
		void OpenShopBtn ()
		{
			store.SetActive(true);
			msg.SetActive (false);

		}

		
	}
	
}
