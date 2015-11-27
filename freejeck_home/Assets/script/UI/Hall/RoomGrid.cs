using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Common;
using Command;
using Cmdlib;
using System.Linq;
namespace com.iuixi.FreeJeck
{

	 
	public class RoomGrid : TableGrid<cs_RoomInfo,RoomCell> 
	{
		///三种模式
		private enum eButtonModel
		{
			ITEM_BUTTON=0,
			SPEED_BUTTON,
			CLUB_BUTTON,
		}
		[SerializeField]private GameObject RoomPassword;
		[SerializeField]private GameObject ErrorPassword;
		private static eButtonModel btnmodel=eButtonModel.ITEM_BUTTON;
		private RoomModel roommodel;
		private LobbyService proxy;
		private GameService gameService;
		private UserModel usermodel;
		private GameNetWork gameNetWork;

		private byte pageType;//页面类型,0为当前页，1为下一页,2为上一页
		private byte ModelType=1;//1为个人赛,2为组队赛
		private byte gameType=2;//参考（ematch_mode）
		private List<cs_RoomInfo> curRoomInfo;
		private byte mode1;
		private string password;
		private short roomNo;
		private string ip;
		private ushort gameport;
		public static int BtnModel(){
			return	(int)btnmodel;
		}


		// Use this for initialization

		void Start () {
			curRoomInfo=new List<cs_RoomInfo>();
			roommodel=Singletons.GET<RoomModel>();
			proxy=Singletons.GET<LobbyService>();
			gameService=Singletons.GET<GameService>();
			usermodel=Singletons.GET<UserModel>();
			gameNetWork=Singletons.GET<GameNetWork>();
		
			proxy.OnLobbyRoomList=OnRoomList;
			proxy.OnLobbyNotifyRoomListPage=OnRoomListPage;	
			proxy.OnLobbyNotifyRoomListAdd=OnRoomListAdd; 
			proxy.OnLobbyRoomCreate=OnRoomCreate;
			proxy.OnLobbyNotifyRoomListDel=OnRoomListDel;
			proxy.OnLobbyNotifyRoomListUpdate=OnRoomListUpdate;
			proxy.OnLobbyRoomLQuickJoin=OnRoomQuickJoin;

			gameService.OnGameRoomJoin=OnGameRoomJoin;
			roommodel.RoomInfo.Clear();
			proxy.LobbyEventList();

			proxy.OnLobbyEventList=delegate(cmdGAME_ANSWER_EVENT_LIST data) {
				roommodel.GAEL_EventList=data;
				proxy.LobbyRoomList((byte)eROOM_PAGE_TYPE.ROOM_PAGE_TYPE_NONE,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_ITEM,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_INDIVIDUAL);
			};


			InitCells();


		}

	
		/// <summary>
		///房间页码
		/// </summary>
		/// <param name="data">Data.</param>
		public void OnRoomList(cmdGAME_ANSWER_ROOM_LIST data) {
			if(data.GetAck()==1)
			{
				WebLog.Log(data);
					
			}
		}

		/// <summary>
		/// Raises the room list page event.
		/// </summary>
		/// <param name="data">Data.</param>
		public void OnRoomListPage(cmdGameNotifyRoomListPage data) 
		{
			roommodel.GNRLG_Page=data;
			WebLog.Log(data);
		}

		/// <summary>
		/// 添加房间到容器
		/// </summary>
		/// <param name="data">Data.</param>
		public void OnRoomListAdd(cmdGameNotifyRoomListAdd data) 
		{
			WebLog.Log("添加房间");
			roommodel.RoomInfo.Add(data.info);
			
		}

		/// <summary>
		/// 记录要删除房间的房间号
		/// </summary>
		/// <param name="data"></param>
		public void OnRoomListDel(cmdGameNotifyRoomListDel data)
		{
			WebLog.Log("删除房间");
			roommodel.RoomListDel.Add(data.roomNo);
		}

		/// <summary>
		/// 房间信息的更新
		/// </summary>
		/// <param name="data">Data.</param>
		public void OnRoomListUpdate(cmdGameNotifyRoomListUpdate data)
		{
			WebLog.Log("更新房间");
			roommodel.UpdatedRoom.Add(data.info);
		}

		//按下快速加入按钮
		public void RequestRoomQuickJoin()
		{	
			switch(btnmodel)
			{
				case eButtonModel.ITEM_BUTTON:
					if(ModelType==1)
						proxy.LobbyRoomLQuickJoin(gameType);
					else if(ModelType==2)
						proxy.LobbyRoomLQuickJoin(gameType);
					break;
				case eButtonModel.SPEED_BUTTON:
					if(ModelType==1)
						proxy.LobbyRoomLQuickJoin(gameType);
					else if(ModelType==2)
						proxy.LobbyRoomLQuickJoin(gameType);
					break;
				case eButtonModel.CLUB_BUTTON:
					if(ModelType==1)
					    proxy.LobbyRoomLQuickJoin(gameType);
					else if(ModelType==2)
						proxy.LobbyRoomLQuickJoin(gameType);
						break;
			}
		}
		//有房间就加入当前模式房间，没有就创建一个房间
	 	public void OnRoomQuickJoin(cmdGameAnswerRoomQuickJoin data)
		{
			if(data.GetAck()==1)
			{
				WebLog.Log(data);
				roommodel.GARQJ_RoomQuickJoin=data;
				gameNetWork.Connect(2,data.info.ip,data.info.usGamePort,OnGameQuickJoinConnected);
			}
			else if(data.GetAck()==0)
			{
				proxy.LobbyRoomCreate("我的房间","",255,gameType,2,8,true);
			}
		}
        
		private void OnGameQuickJoinConnected (bool success)
		{
			if(!success){
				// todo throw network error
				return;
			}
			WebLog.Log("连上game服务器");
			gameService.GameRoomJoin(roommodel.GARQJ_RoomQuickJoin.info.roomNo,Tools.ReadWchar(roommodel.GARQJ_RoomQuickJoin.info.password_info),roommodel.GARQJ_RoomQuickJoin.info.mode,usermodel.GALA_data.uid,usermodel.GALA_data.lobbyUid);
		}

		private void OnRoomCreate(cmdGameAnswerRoomCreate data)
		{
			if(data.GetAck()==1)
			{
				WebLog.Log(data);
				roommodel.GARC_RoomCreat=data;
				gameNetWork.Connect(2,data.ip,data.usGamePort,OnGameConnected);

			}

		}

		private void OnGameConnected (bool success)
		{
			if(!success){
				// todo throw network error
				return;
			}
			WebLog.Log("连上game服务器");
			gameService.GameRoomCreate(roommodel.GARC_RoomCreat.mode,roommodel.GARC_RoomCreat.roomNo,roommodel.GARC_RoomCreat.gameKey,usermodel.GALA_data.uid,usermodel.GALA_data.lobbyUid);
		}


		private void OnJoinGame(bool success)
		{
			if(!success){
				// todo throw network error
				return;
			}
			WebLog.Log("加入game");
			gameService.GameRoomJoin(roomNo,password,mode1,usermodel.GALA_data.uid,usermodel.GALA_data.lobbyUid);
		}
		//加入游戏房间
		public void OnGameRoomJoin(cmdGAME_ANSWER_ROOM_JOIN data)
		{
			if(data.GetAck()==1)
			{
				WebLog.Log(data);
				roommodel.GARJ_RoomJoin=data;
				Loom.DispatchToMainThread(() => Singletons.GET<SceneManager>().PushScene(SceneEnum.GAME_ROOM));

			}
			else if(data.GetAck()==0)
			{
				Singletons.GET<GameNetWork>().DisConnect();
				ErrorPassword.SetActive(true);
			}
		}

       
	

		// Update is called once per frame
		void Update () {

			//房间信息实时更新
			if(roommodel.RoomInfo.SequenceEqual(curRoomInfo))
			{

				foreach (var roomNum in roommodel.RoomListDel)
				{
					foreach (var item in roommodel.RoomInfo) 
					{
						if(roomNum==item.roomNo)
						{
							curRoomInfo.Remove(item);
							break;
						}
					}
				}
				roommodel.RoomInfo=curRoomInfo;
				foreach (var updatedRoom in roommodel.UpdatedRoom)
				{
					foreach (var item in roommodel.RoomInfo)
					{
						if(item.roomNo==updatedRoom.roomNo)
						{
						    int index=curRoomInfo.IndexOf(item);
							curRoomInfo.Remove(item);
							curRoomInfo.Insert(index,updatedRoom);
							break;
						}
					}
				}
				roommodel.RoomInfo=curRoomInfo;
				roommodel.UpdatedRoom.Clear();
				roommodel.RoomListDel.Clear();
				SetDataProvider(curRoomInfo);
			}
				
			else{
				curRoomInfo.Clear();
				foreach (var item in roommodel.RoomInfo) 
				{

					if(item.mode==gameType)
						curRoomInfo.Add(item);
				}
				roommodel.RoomInfo=curRoomInfo;
				SetDataProvider(curRoomInfo);
			}

		}
		//三种模式默认选取个人赛
		public void MatchMode(int model){
			roommodel.RoomInfo.Clear();
			pageType=0;
			switch (model)
			{	
				case 0:
					gameType=2;
					btnmodel=eButtonModel.ITEM_BUTTON;
					proxy.LobbyRoomList(pageType,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_ITEM,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_INDIVIDUAL);
					break;
				case 2:
					gameType=0;
					btnmodel =eButtonModel.SPEED_BUTTON;
					proxy.LobbyRoomList(pageType,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_SPEED,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_INDIVIDUAL);
					break;
				case 11:
					gameType=11;
					btnmodel =eButtonModel.CLUB_BUTTON;
					proxy.LobbyRoomList(pageType,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_MINI,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_INDIVIDUAL);
					break;
			}
		}
		//三种模式下的个人赛
		public void IndividualModel(int Page){
			roommodel.RoomInfo.Clear();
			pageType=(byte)Page;
			switch(btnmodel)
			{
				case eButtonModel.ITEM_BUTTON:
					gameType=2;
					proxy.LobbyRoomList(pageType,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_ITEM,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_INDIVIDUAL);
					break;
				case eButtonModel.SPEED_BUTTON:
					gameType=0;
					proxy.LobbyRoomList(pageType,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_SPEED,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_INDIVIDUAL);
					break;
				case eButtonModel.CLUB_BUTTON:
					gameType=11;
					proxy.LobbyRoomList(pageType,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_MINI,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_INDIVIDUAL);
					break;
			}
			ModelType=1;
		}
		//三种模式下的组队赛
		public void TeamModel(int Page){
			roommodel.RoomInfo.Clear();
			pageType=(byte)Page;
			switch(btnmodel)
			{
				case eButtonModel.ITEM_BUTTON:
					gameType=3;
					proxy.LobbyRoomList(pageType,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_ITEM,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_TEAM);
					break;
				case eButtonModel.SPEED_BUTTON:
					gameType=1;
					proxy.LobbyRoomList(pageType,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_SPEED,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_TEAM);
					break;
				case eButtonModel.CLUB_BUTTON:
					gameType=12;
					proxy.LobbyRoomList(pageType,(byte)eMATCH_VIEW_TYPE.MATCH_VIEW_TYPE_MINI,(byte)eROOM_VIEW_TYPE.ROOM_VIEW_TYPE_TEAM);
					break;
			}
			ModelType=2;
		}
	   //各种模式下的翻页
		public void PageType(int Page)
		{
			if(ModelType==1)
			{
				IndividualModel(Page);
				m_Ge.sprite=Instantiate(Resources.Load<Image>("cnt/"+(int)roommodel.GNRLG_Page.nPageNo).sprite)as Sprite ;
			}
			if(ModelType==2)
			{
				TeamModel(Page);
				m_Ge.sprite=Instantiate(Resources.Load<Image>("cnt/"+(int)roommodel.GNRLG_Page.nPageNo).sprite)as Sprite ;
			}
		}
        //进入房间
		public void GameRoom(int i)
		{
		
			 roomNo=dataProvider[start + i].roomNo;
			 password=Tools.ReadWchar(dataProvider[start + i].password_info);
			 mode1=dataProvider[start + i].mode;
			 ip=dataProvider[start + i].ip;
			 gameport=dataProvider[start + i].usGamePort;
			if(dataProvider[start + i].password==1)
			{
				RoomPassword.SetActive(true);

			}
			else
				gameNetWork.Connect(2,ip,(int)gameport,OnJoinGame);


		}
		//输入房间密码
		public void SendPassword()
		{
			password=GameObject.Find("roomPassword").GetComponent<InputField>().text;
			RoomPassword.SetActive(false);
			gameNetWork.Connect(2,ip,(int)gameport,OnJoinGame);
		}
		//隐藏错误密码面板
		public void HideErrorPassword()
		{
			ErrorPassword.SetActive(false);
		}
	}
}