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
	public class UserController : MonoBehaviour {
		//概况面板
       
		[SerializeField] private Text exp;
		[SerializeField] private InputField  namedel;
		[SerializeField] private Text leveldel;
		[SerializeField] private Text clubid;
		[SerializeField] private InputField personsign;


		//能力值面板
		[SerializeField] private Text	Speed; //速度
		[SerializeField] private Text	Strength;//力量
		[SerializeField] private Text	Agility;//敏捷
		[SerializeField] private Text	Technic;//技巧

		private bool ischangename=false ;
		private bool[] zhuangbei=new bool[7];
        private UserModel model = Singletons.GET<UserModel>();
		private LobbyService proxy = Singletons.GET<LobbyService>();
		private string jiahao="+";
		private string maxexp="10020";
        /// <summary>
        /// Standard Start
        /// </summary>
        void Start() {
			namedel.text = Tools.Readchar(model.GAUI_userinfo.nickname);
			leveldel.text="Lv "+model.GAUI_userinfo .level.ToString();
			exp.text=string.Format("{0}/{1}", model.GAUI_userinfo .exp.ToString(), maxexp);
			char[] _club = model.GAUI_userinfo.clubname ;
			clubid.text =Tools .ReadWchar(_club);
        	
			Speed.text=model .GACI_charinfo.info.speed.ToString()+jiahao ;
			Strength.text=model .GACI_charinfo.info.strength.ToString()+jiahao;
			Agility.text=model .GACI_charinfo.info.agility.ToString()+jiahao;
			Technic.text=model .GACI_charinfo.info.technic.ToString()+jiahao;

			for(int i=0;i<7;i++)
				zhuangbei[i]=false ;
        }
        
        /// <summary>
        /// Standart update
        void Updtae() {

		
        }
	
	
		void ChangeNameBtn()
		{
			namedel.enabled =true;
			namedel.Select();
			ischangename=true;
		
		}
	


    }

}
