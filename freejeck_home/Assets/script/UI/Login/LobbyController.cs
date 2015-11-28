using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Cmdlib;
using Command;
using Common;
namespace com.iuixi.FreeJeck{
	public class LobbyController : MonoBehaviour {
		
		// Use this for initialization
		private Image[] loadingpercent=new Image[56] ;
		private bool[] up_down=new bool[10];
		private RectTransform[] load=new RectTransform[10];
		private float[] y=new float[10]; 
		private int count=0;
		private bool Hasloaded=false;
		private RectTransform guy_rect;
		private Image  guy_image;
		private int act=1;
		private  float  time;
           

		private  Text textMessage;
		private  InputField password;
		private  InputField username;
		private  Toggle nextAutoLogin;
		private LobbyService proxy;
		private UserModel model;
		private RoomModel roommodel;
		private LobbyNetWork lobbynetwork;
		public  float BeginConnectTime=0;
		public  float EndConnectTime=0;
	

	
		void Start ()
		{

			for(int i=0;i<56;i++)
			{
				loadingpercent[i]=GameObject.Find("percent"+i).GetComponent<Image>();
				
			}
			for(int i=0;i<10;i++)
			{
				load[i]=GameObject.Find(""+i).GetComponent<RectTransform>();
				y[i]=load [i].localPosition.y;
				up_down[i] =false ;
				
			}
			BeginConnectTime=Time.time;
			time=Time.time;
			guy_image=GameObject.Find ("guy").GetComponent<Image>();
			guy_rect=GameObject.Find ("guy").GetComponent<RectTransform>();
		

			proxy = Singletons.GET<LobbyService>();
			model = Singletons.GET<UserModel>();
			roommodel=Singletons.GET <RoomModel>();
			proxy.OnLobbyUserInfo = OnUserInfo;
			proxy.OnLobbyMyHousingItemList=OnMyHousingItemList;
			proxy.OnLobbyCharInfo=OnCharInfo;
			proxy.OnLobbyCashInfo=OnCashInfo;
			proxy.OnLobbyConnectAuth = delegate(Cmdlib.cmdGAME_ANSWER_CONNECT_AUTH data) {
				if (data.GetAck () == 1) {
					proxy.LobbyLoginAuth (model.LALA_data.login_name, model.LALA_data.auth_key, 0, 0, 0);
				} else {
					
				}
			};
		
			proxy.OnLobbyLoginAuth = delegate(Cmdlib.cmdGAME_ANSWER_LOGIN_AUTH data) {
				if (data.GetAck () == 1) {
					model.GALA_data=data;
					WebLog.Log("登陆成功了！！！！");
					proxy.LobbyUserInfo(data.security_key);       
				} else {
					
				}
			};
			proxy.OnLobbyEnterLobby=delegate(cmdGAME_ANSWER_ENTER_LOBBY data) {
				if(data.GetAck()==1)
				{
					WebLog.Log(data+"进入大厅");
					//proxy.LobbyEventList();
				}
			};
		/*	proxy.OnLobbyEventList=delegate(cmdGAME_ANSWER_EVENT_LIST data) {
				roommodel.GAEL_EventList=data;
				proxy.LobbyRoomList((byte)eROOM_PAGE_TYPE.ROOM_PAGE_TYPE_NONE,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_ITEM,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_INDIVIDUAL);
			};
			proxy.OnLobbyRoomList=delegate(cmdGAME_ANSWER_ROOM_LIST data) {
				if(data.GetAck()==1)
				{
					WebLog.Log(data);
				//	roommodel.RoomInfo.Clear();
				}
			};
			proxy.OnLobbyNotifyRoomListPage=delegate(cmdGameNotifyRoomListPage data) {
				roommodel.GNRLG_Page=data;
				WebLog.Log(data);
			};
					
			proxy.OnLobbyNotifyRoomListAdd=delegate(cmdGameNotifyRoomListAdd data) {
				WebLog.Log("添加房间");
				roommodel.RoomInfo.Add(data.info);

			};*/
			lobbynetwork=Singletons.GET<LobbyNetWork>();
			lobbynetwork.Connect(1,model.LALA_data.ip,model.LALA_data.port,OnConnected);


		}

		private void OnConnected (bool success)
		{
			if(!success){
				// todo throw network error
				return;
			}

			proxy.LobbyConnectAuth();
		}
		private void OnUserInfo(cmdGAME_ANSWER_USER_INFO d){
			if(d.GetAck() == 1){
				WebLog.Log(d);
				model.GAUI_userinfo = d;
				proxy.LobbyCharInfo(d.avatar_no);
				
			}
			else {
				/// todo fix error
			}
		}
		private void OnCashInfo(CmdGameAnswerCashInfo data){
			if(data.GetAck ()==1){
				WebLog.Log(data);
				model.GACI_cashinfo=data ;
			}
			else{}
		}
		private void OnMyHousingItemList(cmdGAME_ANSWER_MYHOUSINGITEM_LIST d)
		{
			
		}
		private void OnCharInfo(cmdGAME_ANSWER_CHAR_INFO d)
		{
			if(d.GetAck()==1)
			{
				WebLog.Log (d);
				model.GACI_charinfo = d;
				EndConnectTime=Time.time;
				proxy.LobbyEnterLobby();


			}
			else{}
		}
	   void Update()
	   {
		    if(Hasloaded==false)
			{
				
				if(Time.time>time+(EndConnectTime-BeginConnectTime)/56)
				{

					time=Time.time;
					loadingpercent[count].enabled=true;
					count++;
					
					if(count==56)
					{
						Loom.DispatchToMainThread(() => Singletons.GET<SceneManager>().PushScene(SceneEnum.USER_INFO));
						Hasloaded =true;

					}
					
				guy_rect.localPosition=new Vector3(guy_rect.localPosition.x+17,guy_rect.localPosition.y,guy_rect.localPosition.z);
					//guy_image.sprite=Instantiate(Resources.LoadAssetAtPath<Sprite>(spritepath+act+".png")) as Sprite ;
		//			guy_image.sprite=Instantiate(Resources.Load<Image>("xiaoren/guy"+act).sprite) as Sprite ;
					act++;
					if(act==5)
						act=1;
				}
				for(int i=0;i<10;i++)
				{
					if(up_down[i]==false)
					{
						
						y[i]+= UnityEngine.Random.Range(2,4);
						if(y[i]>295)
							up_down[i]=true;
					}
					if(up_down[i])
					{
						
						y[i]-= UnityEngine.Random.Range(2,4);
						if(y[i]<237)
							up_down[i]=false;
					}
					
					load [i].localPosition=new Vector3(load [i].localPosition.x,y[i],load [i].localPosition.z);
				}
				
			}
		}
	
	}
}

