using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Cmdlib;
namespace com.iuixi.FreeJeck{
	public class CreatRoomMsg : MonoBehaviour {

		// Use this for initialization
		[SerializeField]private InputField m_RoomName;
		[SerializeField]private InputField m_PassWord;
		[SerializeField]private Toggle m_SingleGame;
		[SerializeField]private Toggle m_TeamGame;
		[SerializeField]private Toggle m_ClubGame;
		[SerializeField]private Toggle m_LevelLimit;
		[SerializeField]private Toggle m_IsCollider;
		[SerializeField]private Button m_ForwardBtn;
		[SerializeField]private Button m_BackwardBtn;
		[SerializeField]private Button m_Plus;
		[SerializeField]private Button m_Minus;
		[SerializeField]private Image m_Map;
		[SerializeField]private Image m_PlayerConut;
	
		private byte model;
		private byte m_CurrentPlayerCount=8;
		private byte MapId=2;
		private byte MapLaps=3;
		private RoomModel roommodel;
		private LobbyService proxy;
		private GameService gameService;
		private UserModel usermodel;
		/// <summary>
		/// Gets the name of the room.
		/// </summary>
		/// <value>The name of the room.</value>
		public string RoomName
		{
			get{return m_RoomName.text;} 
		}
		/// <summary>
		/// Gets the pass word.
		/// </summary>
		/// <value>The pass word.</value>
		public string  PassWord{
			get{return m_PassWord.text;} 
		}
		/// <summary>
		/// Gets the game model.
		/// </summary>
		/// <value>The game model.</value>
		public int gameModel{
			get{return model;}
		}
		/// <summary>
		/// Gets the current player count.
		/// </summary>
		/// <value>The current player count.</value>
		public int CurrentPlayerCount{
			get{return m_CurrentPlayerCount;}
		}
		/// <summary>
		/// Gets a value indicating whether this <see cref="com.iuixi.FreeJeck.CreatRoomMsg"/> level limit.
		/// </summary>
		/// <value><c>true</c> if level limit; otherwise, <c>false</c>.</value>
		public bool LevelLimit{
			get{return m_LevelLimit.isOn;} 
		}
		/// <summary>
		/// 
		/// </summary>
		/// <value></value>
		public bool IsCollider{
			get{return m_IsCollider.isOn;} 
		}


		void Start () {
			roommodel=Singletons.GET<RoomModel>();
			proxy=Singletons.GET<LobbyService>();
			gameService=Singletons.GET<GameService>();
			usermodel=Singletons.GET<UserModel>();
		//	proxy.OnLobbyRoomCreate=OnRoomCreate;
		//	gameService.OnGameRoomJoin=OnGameRoomJoin;
			switch(RoomGrid.BtnModel()){
			case 0:
				model=2;
				m_IsCollider.isOn=false;
				break;
			case 1:
				model=0;
				m_IsCollider.isOn=true;
				break;
			case 2:
				model=11;
				m_IsCollider.isOn=true;
				break;
			}
		}
		
		// Update is called once per frame
		void Update () {

		}
		/// <summary>
		/// 选择个人模式
		/// </summary>
		private void SingleModle(){
			m_SingleGame.isOn =true ;
			m_TeamGame.isOn =false ;
			m_ClubGame.isOn =false ;
			switch(RoomGrid.BtnModel()){
			case 0:
				model=2;
				break;
			case 1:
				model=0;
				break;
			case 2:
				model=11;
				break;
			}
		}
		/// <summary>
		/// 选择组队模式
		/// </summary>
		private void TeamModel(){
			m_TeamGame.isOn =true ;
			m_SingleGame.isOn =false ;
			m_ClubGame.isOn =false ;
			switch(RoomGrid.BtnModel()){
			case 0:
				model=3;
				break;
			case 1:
				model=1;
				break;
			case 2:
				model=12;
				break;
			}

		}
		/// <summary>
		/// 增加人数
		/// </summary>
		private void PlusPlayer()
		{
			m_CurrentPlayerCount++;
			m_PlayerConut.sprite=Instantiate(Resources.Load<Image>("MaxPlayer/"+m_CurrentPlayerCount).sprite)as Sprite ;
			if(m_CurrentPlayerCount ==9)
				m_Plus.interactable =false ;
			if(m_CurrentPlayerCount >1)
				m_Minus.interactable =true ;
		}
		/// <summary>
		///减少人数
		/// </summary>
		private void MinusPlayer()
		{
			m_CurrentPlayerCount--;
			m_PlayerConut.sprite=Instantiate(Resources.Load<Image>("MaxPlayer/"+m_CurrentPlayerCount).sprite)as Sprite ;
			if(m_CurrentPlayerCount ==1)
				m_Minus.interactable =false ;
			if(m_CurrentPlayerCount <9)
				m_Plus.interactable =true ;
		}
		/// <summary>
		/// 确定房间创建的模式，创建房间
		/// </summary>
		private void Confirm(){
		
			proxy.LobbyRoomCreate(m_RoomName.text,m_PassWord.text,MapId,model,MapLaps,m_CurrentPlayerCount,IsCollider);
			gameObject.SetActive(false);
		}

	   /// <summary>
	   /// 取消创建房间
	   /// </summary>
	   /// <returns><c>true</c> if this instance cancel ; otherwise, <c>false</c>.</returns>
		private void Cancel(){
			m_RoomName.text="";
			m_PassWord.text="";
			m_IsCollider.isOn=false ;
			m_LevelLimit.isOn=false ;
			model=0;
			m_CurrentPlayerCount=8;
			gameObject.SetActive(false );
		}

	}
}