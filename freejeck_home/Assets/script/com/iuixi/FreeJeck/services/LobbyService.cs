using System;
using Cmdlib;
using Common;
using Command;
using InterfaceToSever;

namespace com.iuixi.FreeJeck
{
	/// <summary>
	///   用户登陆服务,包含版本验证与用户登陆
	/// </summary>
	public class LobbyService : BaseServices<LobbyNetWork>
	{
	
		/// <summary>
		/// LobbyConnectAuth回包的回调
		/// </summary>
		public OnRecDta<cmdGAME_ANSWER_CONNECT_AUTH> OnLobbyConnectAuth;

		/// <summary>
		/// LobbyLoginAuth回包的回调
		/// </summary>
		public OnRecDta<cmdGAME_ANSWER_LOGIN_AUTH> OnLobbyLoginAuth;

		public OnRecDta<cmdGAME_ANSWER_USER_INFO> OnLobbyUserInfo;
		public OnRecDta<cmdGAME_ANSWER_MYHOUSINGITEM_LIST > OnLobbyMyHousingItemList;
		public OnRecDta< CmdGameAnswerCashInfo> OnLobbyCashInfo;
		public OnRecDta< cmdGAME_ANSWER_CHAR_INFO> OnLobbyCharInfo;
		public OnRecDta< cmdGAME_NOTIFY_GIFT_NEW> OnLobbyNotifyGiftNew;
		public OnRecDta< cmdMSG_NOTIFY_CLUB_AUTHLEVEL_NAME> OnLobbyNotifyClubAuthlevelName;


		public OnRecDta<cmdGAME_ANSWER_ABILITY_CARD_STAT > OnLobbyAbilityCardStat;
		public OnRecDta< cmdGAME_ANSWER_MYITEM_LIST> OnLobbyMyItemList;
		public OnRecDta<cmdGAME_ANSWER_ENTER_LOBBY > OnLobbyEnterLobby;
		public OnRecDta<cmdGAME_PING_INFO> OnLobbyEchoPing;


		public OnRecDta<cmdGAME_ANSWER_EVENT_LIST> OnLobbyEventList;
		public OnRecDta<cmdGAME_ANSWER_ROOM_LIST> OnLobbyRoomList;
		public OnRecDta<cmdGameAnswerRoomQuickJoin> OnLobbyRoomLQuickJoin;
		public OnRecDta<cmdGameAnswerRoomCreate> OnLobbyRoomCreate;
		public OnRecDta<cmdGameNotifyRoomListPage> OnLobbyNotifyRoomListPage;
		public OnRecDta<cmdGameNotifyRoomListAdd> OnLobbyNotifyRoomListAdd;
		public OnRecDta<cmdGameNotifyRoomListDel> OnLobbyNotifyRoomListDel;
		public OnRecDta<cmdGameNotifyRoomListUpdate> OnLobbyNotifyRoomListUpdate;
		public OnRecDta<cmdGAME_ANSWER_MODE_SELECT> OnGameModeSelect;

		
		/// <summary>
		/// Lobbies the connect auth.
		/// </summary>
		/// <param name="dlg">Dlg.</param>
		///
		public void LobbyConnectAuth( OnRecDta<cmdGAME_ANSWER_CONNECT_AUTH> dlg)
		{
			OnLobbyConnectAuth = dlg;
			LobbyConnectAuth ();		
		}
		public void LobbyConnectAuth()
		{
			cmdGAME_REQUEST_CONNECT_AUTH pk = new cmdGAME_REQUEST_CONNECT_AUTH();

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_CONNECT_AUTH, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);		
		}

		/// <summary>
		/// Lobbies the login auth.
		/// </summary>
		/// <param name="login_name">Login_name.</param>
		/// <param name="auth_key">Auth_key.</param>
		/// <param name="auth_checksum">Auth_checksum.</param>
		/// <param name="divisionLv">Division lv.</param>
		/// <param name="channelNo">Channel no.</param>
		/// <param name="dlg">Dlg.</param>
		public void LobbyLoginAuth(char[] login_name,string auth_key,int auth_checksum,byte divisionLv,byte channelNo,OnRecDta<cmdGAME_ANSWER_LOGIN_AUTH> dlg)
		{
			OnLobbyLoginAuth = dlg;
			LobbyLoginAuth(login_name, auth_key, auth_checksum, divisionLv, channelNo);
		}
        public void LobbyLoginAuth(char[] login_name, string auth_key, int auth_checksum, byte divisionLv, byte channelNo)
        {
            cmdGAME_REQUEST_LOGIN_AUTH pk = new cmdGAME_REQUEST_LOGIN_AUTH();
            pk.login_name = login_name;
            pk.auth_key = auth_key;
            pk.auth_checksum = auth_checksum;
            pk.divisionLv = divisionLv;
            pk.channelNo = channelNo;

            CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_LOGIN_AUTH, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
        }
	
		/// <summary>
		/// Lobbies the user info.
		/// </summary>
		/// <param name="security_key">Security_key.</param>
		/// <param name="dlg">Dlg.</param>
		public void LobbyUserInfo(uint security_key,OnRecDta<cmdGAME_ANSWER_USER_INFO> dlg)
		{
			OnLobbyUserInfo = dlg;
			LobbyUserInfo (security_key);
		}
		public void LobbyUserInfo(uint security_key)
		{
			cmdGAME_REQUEST_USER_INFO pk = new cmdGAME_REQUEST_USER_INFO ();
			
			pk.security_key = security_key;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_USER_INFO, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		/// <summary>
		/// Lobbies my housing item list.
		/// </summary>
		/// <param name="dlg">Dlg.</param>
		public void LobbyMyHousingItemList(OnRecDta<cmdGAME_ANSWER_MYHOUSINGITEM_LIST > dlg)
		{
			OnLobbyMyHousingItemList = dlg;
			LobbyMyHousingItemList ();
		}
		public void LobbyMyHousingItemList()
		{
			cmdGAME_REQUEST_MYHOUSINGITEM_LIST pk = new cmdGAME_REQUEST_MYHOUSINGITEM_LIST ();
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_MYHOUSINGITEM_LIST, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		/// <summary>
		/// Lobbies the char info.
		/// </summary>
		/// <param name="avatar">Avatar.</param>
		/// <param name="dlg">Dlg.</param>
		public void LobbyCharInfo(byte avatar,OnRecDta< cmdGAME_ANSWER_CHAR_INFO> dlg)
		{
			OnLobbyCharInfo = dlg;
			LobbyCharInfo (avatar);
		}
		public void LobbyCharInfo(byte avatar)
		{
			cmdGAME_REQUEST_CHAR_INFO pk = new cmdGAME_REQUEST_CHAR_INFO ();
			
			pk.avatar = avatar;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_CHAR_INFO, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		/// <summary>
		/// Lobbies the ability card stat.
		/// </summary>
		/// <param name="dlg">Dlg.</param>
		public void LobbyAbilityCardStat(OnRecDta<cmdGAME_ANSWER_ABILITY_CARD_STAT > dlg)
		{
			OnLobbyAbilityCardStat = dlg;
			LobbyAbilityCardStat();
		}
		public void LobbyAbilityCardStat()
		{
			cmdGAME_REQUEST_ABILITY_CARD_STAT pk = new cmdGAME_REQUEST_ABILITY_CARD_STAT ();
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ABILITY_CARD_STAT, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		/// <summary>
		/// Lobbies my item list.
		/// </summary>
		/// <param name="dlg">Dlg.</param>
		public void LobbyMyItemList(OnRecDta< cmdGAME_ANSWER_MYITEM_LIST> dlg)
		{
			OnLobbyMyItemList = dlg;
			LobbyMyItemList();
		}
		public void LobbyMyItemList()
		{
			cmdGAME_REQUEST_MYITEM_LIST pk = new cmdGAME_REQUEST_MYITEM_LIST ();
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_MYITEM_LIST, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}
		
		/// <summary>
		/// Lobbies the enter lobby.
		/// </summary>
		/// <param name="dlg">Dlg.</param>
		public void LobbyEnterLobby(OnRecDta<cmdGAME_ANSWER_ENTER_LOBBY > dlg)
		{
			OnLobbyEnterLobby = dlg;
			LobbyEnterLobby ();
		}
		public void LobbyEnterLobby()
		{
			cmdGAME_REQUEST_ENTER_LOBBY pk = new cmdGAME_REQUEST_ENTER_LOBBY ();
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ENTER_LOBBY, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		/// <summary>
		/// Lobbies the echo ping.
		/// </summary>
		/// <param name="dlg">Dlg.</param>
		public void LobbyEchoPing(OnRecDta< cmdGAME_PING_INFO> dlg)
		{
			OnLobbyEchoPing = dlg;
			LobbyEchoPing();
		}
		public void LobbyEchoPing()
		{
			cmdGAME_PING_INFO pk = new cmdGAME_PING_INFO ();
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eRELAY_ECHO.RELAY_ECHO_PING, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		//事件列表
		public void LobbyEventList(OnRecDta<cmdGAME_ANSWER_EVENT_LIST> dlg)
		{
			OnLobbyEventList = dlg;
			LobbyEchoPing();
		}

		public void LobbyEventList()
		{
			cmdGAME_REQUEST_EVENT_LIST pk = new cmdGAME_REQUEST_EVENT_LIST ();
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_EVENT_LIST, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		//房间列表
		public void LobbyRoomList(byte pageType,byte matchViewType,byte roomViewType,OnRecDta<cmdGAME_ANSWER_ROOM_LIST> dlg)
		{
			OnLobbyRoomList = dlg;
			LobbyRoomList(pageType,matchViewType,roomViewType);
		}

		public void LobbyRoomList(byte pageType,byte matchViewType,byte roomViewType)
		{
			cmdGAME_REQUEST_ROOM_LIST pk = new cmdGAME_REQUEST_ROOM_LIST ();
			pk.pageType = pageType;
			pk.matchViewType = matchViewType;
			pk.roomViewType = roomViewType;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_LIST, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		//快速加入房间
		public void LobbyRoomLQuickJoin(byte mode,OnRecDta<cmdGameAnswerRoomQuickJoin> dlg)
		{
			OnLobbyRoomLQuickJoin = dlg;	
			LobbyRoomLQuickJoin (mode);
		}
		public void LobbyRoomLQuickJoin(byte mode)
		{
			cmdGameRequestRoomQuickJoin pk = new cmdGameRequestRoomQuickJoin ();
			pk.mode = mode;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_QUICKJOIN, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		//创建房间
		public void LobbyRoomCreate(string name,string password,byte mapNum,byte mode,byte mapLaps,byte maxJoinerNum,bool bStrikeAttack,OnRecDta<cmdGameAnswerRoomCreate> dlg)
		{
			OnLobbyRoomCreate = dlg;
			LobbyRoomCreate (name,password,mapNum,mode,mapLaps,maxJoinerNum,bStrikeAttack);
		}

		public void LobbyRoomCreate(string name,string password,byte mapNum,byte mode,byte mapLaps,byte maxJoinerNum,bool bStrikeAttack)
		{
			cmdGameRequestRoomCreate pk = new cmdGameRequestRoomCreate ();
			Array.Copy(name.ToCharArray(), pk.name, name.Length);
			Array.Copy(password.ToCharArray(), pk.password, password.Length);
			pk.mapNum = mapNum;
			pk.mode = mode;
			pk.mapLaps = mapLaps;
			pk.maxJoinerNum = maxJoinerNum;
			pk.StrikeAttack = bStrikeAttack;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_CREATE, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}

		public void GameModeSelect(byte mode,OnRecDta<cmdGAME_ANSWER_MODE_SELECT> dlg)
		{
			OnGameModeSelect = dlg;
			GameModeSelect (mode);
		}
		public void GameModeSelect(byte mode)
		{
			cmdGAME_REQUEST_MODE_SELECT pk = new cmdGAME_REQUEST_MODE_SELECT();
			pk.mode = mode;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_MODE_SELECT, pk);
			Send((Byte)ServerType.SERVER_LOBBY, obj);
		}
		
	}
}
