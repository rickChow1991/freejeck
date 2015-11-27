using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Common;
using Command;
using Cmdlib;
using System.Linq;
using UnityStandardAssets.Utility;
namespace com.iuixi.FreeJeck
{

	public class GameRoomController : MonoBehaviour {

		// Use this for initialization
		//修改游戏模式面板
		[SerializeField]private InputField m_ChangeRoomName;
		[SerializeField]private InputField m_ChangePassWord;
		[SerializeField]private Button m_ForwardBtn;
		[SerializeField]private Button m_BackwardBtn;
		[SerializeField]private Button m_Plus;
		[SerializeField]private Button m_Minus;
		[SerializeField]private Image m_ChangeMap;
		[SerializeField]private Image m_ChangePlayerConut;

		//当前房间模式面板
		[SerializeField]private Image m_ge;
		[SerializeField]private Image m_shi;
		[SerializeField]private Image m_bai;
		[SerializeField]private Text roomName;
		[SerializeField]private Text lapNum;
		[SerializeField]private Text model;
		[SerializeField]private Text playerPercet;

		[SerializeField]private GameObject ChangeSetting;
		[SerializeField]private GameObject Lock;
		[SerializeField]private GameObject TeamGame;
		[SerializeField]private GameObject SingleGame;
		[SerializeField]private GameObject SetBtn;
		[SerializeField]private GameObject StartGame;
		[SerializeField]private GameObject Cancel;
		[SerializeField]private GameObject yes_Strike;
		[SerializeField]private GameObject no_Strike;
		[SerializeField]private GameObject Player;
		[SerializeField]private GameObject IsStrike;
		[SerializeField]private Toggle isCollider;

		private  GameObject player;//队友
		private  GameObject myself;//自己
		private Dictionary<byte,GameObject> PlayerMsg;//所有的人

		private byte byReady=1;//1为游戏准备
		private Vector3 position;

		private GameService gameService;
		private RoomModel  roomModel;
		private UserModel userModel;
		private LobbyService proxy;

		private byte curMaxCount;
		private byte m_CurrentPlayerCount;
		private byte curCount;

//		private GameObject[] MsgList;
//		private MsgCell msgcell;
		private float time=0;
		private cmdGAME_NOTIFY_ROOM_JOIN me;
		private List<cmdGAME_NOTIFY_ROOM_JOIN> MsgName;
		private MsgGrid msgGrid;

		void Start () {
			MsgName=new List<cmdGAME_NOTIFY_ROOM_JOIN>();
			gameService=Singletons.GET<GameService>();
			roomModel=Singletons.GET<RoomModel>();
			proxy=Singletons.GET<LobbyService>();
			userModel=Singletons.GET<UserModel>();

			gameService.GameRoomReady(byReady);
			gameService.LoadGameLobbyMembers();

			proxy.OnGameModeSelect=GameModeSelect;
			proxy.OnLobbyEnterLobby=OnEnterLobby;

			gameService.OnGameNotifyRoomJoin=OnGameNotifyRoomjoin;
			gameService.OnGameNotifyRoomSetting=OnGameNotifyRoomSetting;
			gameService.OnGameNotiRoomStrikeAttackInfoChange=OnStrikeChange;
			gameService.OnGameNotifyRoomMaxJoinerNumChange=OnMaxJoinerNumChange;
			gameService.OnGameRoomLeave=OnGameRoomLeave;
			gameService.OnGameEchoPosition=PlayerPosition;

			msgGrid=GameObject.Find("MsgContain").GetComponent<MsgGrid>();
			PlayerMsg=new Dictionary<byte,GameObject>() ;
			me=new cmdGAME_NOTIFY_ROOM_JOIN() ;
			roomModel.GNRJ_RoomJoin.Clear();

			curMaxCount=roomModel.GARJ_RoomJoin.maxJoinerNum;
			m_CurrentPlayerCount=curMaxCount;//记录房间内最大人数
		
			//是否有碰撞的处理
			ChangeSetting.SetActive(true);
			switch(RoomGrid.BtnModel()){
				case 0:
					IsStrike.SetActive(false);
					break;
				case 1:
					IsStrike.SetActive(true);
					if(roomModel.GARJ_RoomJoin.bStrikeAttack==1)
					{
						yes_Strike.SetActive(true);
						isCollider.isOn=true;
					}
					else
					{
						isCollider.isOn=false;
						no_Strike.SetActive(true);

					}
					break;
				case 2:
					IsStrike.SetActive(true);
					if(roomModel.GARJ_RoomJoin.bStrikeAttack==1)
					{
						yes_Strike.SetActive(true);
						isCollider.isOn=true;
					}
					else
					{	
						no_Strike.SetActive(true);
						isCollider.isOn=false;
					}
					break;
			}
			ChangeSetting.SetActive(false);
		
			//显示当前房间信息小面板
			//--------------------------------------------------
			switch(roomModel.GARJ_RoomJoin.mode)
			{
				case 0:
					model.text="个人竞速赛";
					break;
				case 1:
					model.text="组队竞速赛";
					break;
				case 2:
					model.text="个人道具赛";
					break;
				case 3:
					model.text="组队道具赛";
					break;
				case 11:
					model.text="个人迷你赛"; 
					break;
				case 12:
					model.text="组队道具赛";
					break;
			}
			roomName.text=Tools.Readchar(roomModel.GARJ_RoomJoin.name);
			m_ge.sprite=Instantiate(Resources.Load<Image>("cnt/"+roomModel.GARJ_RoomJoin.roomNo%10).sprite)as Sprite ;
			m_shi.sprite=Instantiate(Resources.Load<Image>("cnt/"+roomModel.GARJ_RoomJoin.roomNo/10%10).sprite)as Sprite ;
			m_bai.sprite=Instantiate(Resources.Load<Image>("cnt/"+roomModel.GARJ_RoomJoin.roomNo/100%10).sprite)as Sprite ;
			lapNum.text=roomModel.GARJ_RoomJoin.mapLaps.ToString()+"圈";
			playerPercet.text=string.Format("{0}/{1}",1,roomModel.GARJ_RoomJoin.maxJoinerNum);
			if(roomModel.GARJ_RoomJoin.password==1)
				Lock.SetActive(true);
			//------------------------------------------------------

			//是不是房主
			if(roomModel.GARJ_RoomJoin.isRoomMaster==1)
				SetBtn.GetComponent<Button>().interactable=true;
			if(roomModel.GARJ_RoomJoin.isRoomMaster==0)
				SetBtn.GetComponent<Button>().interactable=false;

			//实例化人物
			position = new Vector3(UnityEngine.Random.Range(-5.4f,-2.8f), -0.6f, UnityEngine.Random.Range(-1.5f,0.8f));
			myself=Instantiate(Player,position, Quaternion.identity)as GameObject;
			PlayerMsg.Add(roomModel.GARJ_RoomJoin.playerIndex,myself);

			//相机照着自己
			GameObject.Find("Main Camera").GetComponent<DoneCameraMovement>().player=myself.transform;


			//显示自己的信息
			me.uid=roomModel.GARJ_RoomJoin.uid;
			me.roomMaster=roomModel.GARJ_RoomJoin.isRoomMaster;
			me.nickname=userModel.GAUI_userinfo.nickname;
			roomModel.Msg.Add(me);
			MsgName.Add(me);
		    msgGrid.SetDataProvider(MsgName);

		}

		public void OnGameNotifyRoomReady(cmdGAME_NOTIFY_ROOM_READY data)
		{
			WebLog.Log(data);
			roomModel.GNRR_RoomReady=data;

		}
	
		public void OnGameNotifyRoomjoin(cmdGAME_NOTIFY_ROOM_JOIN data)
		{
			WebLog.Log(Tools.ReadWchar( data.nickname)+"加入房间");
			roomModel.GNRJ_RoomJoin.Add(data);
			player =Instantiate(Player,position, Quaternion.identity)as GameObject;
			player.GetComponent<MyCharacter>().enabled=false;
			PlayerMsg.Add(data.playerIndex,player);
		   
			curCount=(byte)(roomModel.GNRJ_RoomJoin.Count+1);
			playerPercet.text=string.Format("{0}/{1}",curCount,curMaxCount);

			roomModel.Msg.Add(data);
			MsgName.Add(data);
			msgGrid.SetDataProvider(MsgName);

		}

		//返回大厅按键按下触发
		public void ReturnLobby()
		{
			proxy.GameModeSelect((byte)eGAME_MODE.GAME_MODE_VERSUS);

		}

		public void GameModeSelect(cmdGAME_ANSWER_MODE_SELECT data)
		{
			if(data.GetAck()==1)
			{
				roomModel.GAMS_ModeSelect=data;
				proxy.LobbyEnterLobby();
			}
		}

		public void OnEnterLobby(cmdGAME_ANSWER_ENTER_LOBBY data)
		{
			 
			if(data.GetAck()==1)
			{
				WebLog.Log(data+"返回大厅");
				Singletons.GET<GameNetWork>().DisConnect();
				Loom.DispatchToMainThread(() => Singletons.GET<SceneManager>().PushScene(SceneEnum.USER_INFO));
			}
			
		}
		//按下更改设置后的确定按钮
	    public void ShowChangeSetting()
		{
			ChangeSetting.SetActive(true);
		}

		public void RoomSetting()
		{
			gameService.GameRoomSetting(m_ChangeRoomName.text,m_ChangePassWord.text);
			gameService.GameRoomStrikeAttackInfoChange(isCollider.isOn);
			if(curMaxCount!=m_CurrentPlayerCount)
			{
				gameService.GameRoomMaxJoinerNumChange(m_CurrentPlayerCount);
			}
			ChangeSetting.SetActive(false);
		}

		public void OnGameNotifyRoomSetting(cmdGAME_NOTIFY_ROOM_SETTING data)
		{
			roomName.text=Tools.Readchar(data.name);
			if(data.password[0]!='\0')
				Lock.SetActive(true);

		    else
				Lock.SetActive(false);
		}

		public void OnStrikeChange(cmdGameNotiRoomStrikeAttackInfoChange data)
		{
			if(roomModel.GARJ_RoomJoin.mode!=2&&roomModel.GARJ_RoomJoin.mode!=3)
			{
				if(data.bStrikeAttack==1)
				{
					yes_Strike.SetActive(true);
					no_Strike.SetActive(false);
				}
				else
				{
					yes_Strike.SetActive(false);
					no_Strike.SetActive(true);
				}
			}

		}

		public void OnMaxJoinerNumChange(cmdGameNotifyRoomMaxJoinerNumChange data)
		{
		    curCount=(byte)(roomModel.GNRJ_RoomJoin.Count+1);
			playerPercet.text=string.Format("{0}/{1}",curCount,data.maxJoinerNum);
			curMaxCount=data.maxJoinerNum;
		}

		public void PlusPlayer()
		{
			m_CurrentPlayerCount++;
			m_ChangePlayerConut.sprite=Instantiate(Resources.Load<Image>("MaxPlayer/"+m_CurrentPlayerCount).sprite)as Sprite ;
			if(m_CurrentPlayerCount ==9)
				m_Plus.interactable =false ;
			if(m_CurrentPlayerCount >1)
				m_Minus.interactable =true ;
		}
		
		public void MinusPlayer()
		{
			m_CurrentPlayerCount--;
			m_ChangePlayerConut.sprite=Instantiate(Resources.Load<Image>("MaxPlayer/"+m_CurrentPlayerCount).sprite)as Sprite ;
			if(m_CurrentPlayerCount ==1)
				m_Minus.interactable =false ;
			if(m_CurrentPlayerCount <9)
				m_Plus.interactable =true ;
		}

		public void CancelSetting()
		{
			m_ChangePassWord.text="";
			m_ChangeRoomName.text="";
			m_ChangePlayerConut.sprite=Instantiate(Resources.Load<Image>("MaxPlayer/"+curMaxCount).sprite)as Sprite ;
			ChangeSetting.SetActive(false);
		}

		/// <summary>
		/// 有人离开房间的处理
		/// </summary>
		/// <param name="data">Data.</param>
		public void OnGameRoomLeave(cmdGAME_NOTIFY_ROOM_LEAVE data)
		{
			WebLog.Log(data);
			cmdGAME_NOTIFY_ROOM_JOIN RoomId=new cmdGAME_NOTIFY_ROOM_JOIN();
			foreach (var item in roomModel.GNRJ_RoomJoin) {
				if(item.uid==data.leave_uid)
				{
					RoomId=item;
					break;
				}
			}
			roomModel.Msg.Remove(RoomId);
			MsgName.Remove(RoomId);
			roomModel.GNRJ_RoomJoin.Remove(RoomId);
			if(data.roomMaster_uid==roomModel.GARJ_RoomJoin.uid)
			{
				SetBtn.GetComponent<Button>().interactable=true;
				roomModel.Msg[0].roomMaster=1;
				MsgName[0].roomMaster=1;
			
			}
			else
			{
				foreach (var item in roomModel.GNRJ_RoomJoin) {
					if(item.uid==data.roomMaster_uid)
					{
						MsgName[MsgName.IndexOf(item)].roomMaster=1;
					}
				}
			}

			msgGrid.SetDataProvider(MsgName);
		
			Destroy(PlayerMsg[RoomId.playerIndex]);
			PlayerMsg.Remove(RoomId.playerIndex);
		    curCount=(byte)(roomModel.GNRJ_RoomJoin.Count+1);
			playerPercet.text=string.Format("{0}/{1}",curCount,curMaxCount);
		}

	   /// <summary>
	   /// 获取客户端之间的信息
	   /// </summary>
	   /// <param name="data">Data.</param>
		public void PlayerPosition(cmdRELAY_ECHO_POSITION data)
		{

			foreach (var item in roomModel.GNRJ_RoomJoin) {
				WebLog.Log("data"+data.uid    +"item"+item.uid);
				if(data.uid==item.uid) 
				{	
					Vector3 prepos=PlayerMsg[item.playerIndex].transform.position;
					PlayerMsg[item.playerIndex].transform.position=new Vector3(data.pos_x,data.pos_y,data.pos_z);
					PlayerMsg[item.playerIndex].transform.eulerAngles=new Vector3(PlayerMsg[item.playerIndex].transform.eulerAngles.x,data.zRotAng,PlayerMsg[item.playerIndex].transform.eulerAngles.z);
					if(prepos!=PlayerMsg[item.playerIndex].transform.position)
						PlayerMsg[item.playerIndex].GetComponent<Animator> ().SetBool ("Move", true);
					else
						PlayerMsg[item.playerIndex].GetComponent<Animator> ().SetBool ("Move", false);
				}

			}

		}

	
		void Update () {

			if(Time.time>time)
			{
				time=Time.time+0.1f;
				gameService.GameEchoPosition((uint)roomModel.GARJ_RoomJoin.uid,myself.transform.position,Vector3.zero,0,myself.transform.eulerAngles.y,0);
			}
		
	}
}
}