#define _CHAT_ROOM_
#define _MATCH_POINT
#define _MODIFY_PASSWORD
#define _MAPTABLE_RENEWAL
#define _EVENTOBJECT_CHANGE
#define _TEAM_MAXBOOSTER
#define _NEW_REWARD_RESULT
#define _NEW_REWARD_RESULT_V2
#define _NEW_PROUD_CHAR_MOVE_

using com.iuixi.FreeJeck;
using Nettention.Proud;
using Command;
using Cmdlib;
using UnityEngine;
using System;
using Common;

namespace InterfaceFromSever
{
	public class Deserialize
	{
		/// <summary>
		/// Deserializes the packet.
		/// </summary>
		/// <returns><c>true</c>, if packet was deserialized, <c>false</c> otherwise.</returns>
		/// <param name="payload">Payload.</param>
		public static bool DeserializePacket (ByteArray payload)
		{        
			CPacket __msg = new CPacket ();
			if (payload.Count < __msg.GetHeaderLength ()) {
				return false;
			}

			__msg.ReadHeader (payload);
           
			byte[] b = __msg.ReadData (payload);
			WebLog.Log (__msg.GetID ());
			switch (__msg.GetID ()) {
			case (int)Login.eLOGIN_ANSWER.LOGIN_ANSWER_CONNECT_AUTH:
				LoginSeverInterface.DeserializeLOGIN_ANSWER_CONNECT_AUTH (b);
				break;
			case (int)Login.eLOGIN_ANSWER.LOGIN_ANSWER_LOGIN_AUTH:
				LoginSeverInterface.DeserializeLOGIN_ANSWER_LOGIN_AUTH (b);
				break;

			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_CONNECT_AUTH:
				LobbySeverInterface.DeserializeGAME_ANSWER_CONNECT_AUTH (b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_LOGIN_AUTH:
				LobbySeverInterface.DeserializeGAME_ANSWER_LOGIN_AUTH (b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_USER_INFO:
				LobbySeverInterface.DeserializeGAME_ANSWER_USER_INFO (b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_CASH_INFO:
				LobbySeverInterface.DeserializeGAME_ANSWER_CASH_INFO (b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_CHAR_INFO:
				LobbySeverInterface.DeserializeGAME_ANSWER_CHAR_INFO (b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GIFT_NEW:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GIFT_NEW (b);
				break;
			case (int)Lobby.eMSG_NOTIFY.MSG_NOTIFY_CLUB_AUTH_LEVEL_NAME:
				LobbySeverInterface.DeserializeMSG_NOTIFY_CLUB_AUTH_LEVEL_NAME (b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_MYHOUSINGITEM_LIST:
				LobbySeverInterface.DeserializeGAME_ANSWER_MYHOUSINGITEM_LIST (b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_ABILITY_CARD_STAT:
				LobbySeverInterface.DeserializeGAME_ANSWER_ABILITY_CARD_STAT (b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_MYITEM_LIST:
				LobbySeverInterface.DeserializeGAME_ANSWER_MYITEM_LIST (b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_ENTER_LOBBY:
				LobbySeverInterface.DeserializeGAME_ANSWER_ENTER_LOBBY (b);
				break;
			case (int)Lobby.eRELAY_ECHO.RELAY_ECHO_PING:
				LobbySeverInterface.DeserializeRELAY_ECHO_PING (b);
				break;

			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_EVENT_LIST:
				LobbySeverInterface.DeserializeGAME_ANSWER_EVENT_LIST(b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_ROOM_LIST:
				LobbySeverInterface.DeserializeGAME_ANSWER_ROOM_LIST(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_LIST_PAGE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_LIST_PAGE(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_LIST_ADD:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_LIST_ADD(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_LIST_DELETE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_LIST_DELETE(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_LIST_UPDATE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_LIST_UPDATE(b);
				break;

			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_ROOM_QUICKJOIN:
				LobbySeverInterface.DeserializeGAME_ANSWER_ROOM_QUICKJOIN(b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_ROOM_CREATE:
				LobbySeverInterface.DeserializeGAME_ANSWER_ROOM_CREATE(b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_ROOM_JOIN:
				LobbySeverInterface.DeserializeGAME_ANSWER_ROOM_JOIN(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_READY:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_READY(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_JOIN:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_JOIN(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_MAX_JOINER_NUM_CHANGE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_MAX_JOINER_NUM_CHANGE(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_SETTING:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_SETTING(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_ROOM_STRIKEATTACK_INFO_CHANGE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_ROOM_STRIKEATTACK_INFO_CHANGE(b);
				break;

			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_MODE_SELECT:
				LobbySeverInterface.DeserializeGAME_ANSWER_MODE_SELECT(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_LEAVE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_LEAVE(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_TEAMCHANGE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_TEAMCHANGE(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_HOUSINGITEM_CHANGE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_HOUSINGITEM_CHANGE(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_KICKOUT:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_KICKOUT(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_MAPSELECT:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_MAPSELECT(b);
				break;

			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_GAME_START_COUNT:
				LobbySeverInterface.DeserializeGAME_ANSWER_GAME_START_COUNT(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_START_COUNT:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_START_COUNT(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_COUNT_STOP:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_COUNT_STOP(b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_ROOM_START:
				LobbySeverInterface.DeserializeGAME_ANSWER_ROOM_START(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_LOADING_WAIT:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_LOADING_WAIT(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_ROOM_START:
				LobbySeverInterface.DeserializeGAME_NOTIFY_ROOM_START(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_LOADING_PROGRESS_VALUE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_LOADING_PROGRESS_VALUE(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_LOADED:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_LOADED(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_LOADING_END:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_LOADING_END(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_START:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_START(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_SP_CHANGE:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_SP_CHANGE(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_MAX_COMBO_USER:
				LobbySeverInterface.DeserializeGAME_NOTIFY_MAX_COMBO_USER(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_EVENTOBJECT:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_EVENTOBJECT(b);
				break;
			case (int)Lobby.eLOBBY_ANSWER.GAME_ANSWER_GAME_CHANGE_SERVER_SP:
				LobbySeverInterface.DeserializeGAME_ANSWER_GAME_CHANGE_SERVER_SP(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_CHECKPOINT:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_CHECKPOINT(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_STATUS_START:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_STATUS_START(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_STATUS_STOP:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_STATUS_STOP(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_GOALIN:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_GOALIN(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_FINISH:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_FINISH(b);
				break;
			case (int)Lobby.eGAME_NOTIFY.GAME_NOTIFY_GAME_RESULT:
				LobbySeverInterface.DeserializeGAME_NOTIFY_GAME_RESULT(b);
				break;

			//同步玩家位置
			case (int)Lobby.eRELAY_ECHO.RELAY_ECHO_POSITION:
				LobbySeverInterface.DeserializeRELAY_ECHO_POSITION(b);
				break;

			default:
				{
					WebLog.Log("未进行处理的消息: " + __msg.GetID ());
				}
				break;
			}

			return true;
		}
	}

	public class LoginSeverInterface
	{
		/// <summary>
		/// Deserializes the LOGIN_ANSWER_CONNECT_AUTH.
		/// </summary>
		/// <param name="bytes">Bytes.</param>
		public static void DeserializeLOGIN_ANSWER_CONNECT_AUTH (byte[] bytes)
		{
			cmdLOGIN_ANSWER_CONNECT_AUTH pk = new cmdLOGIN_ANSWER_CONNECT_AUTH ();

			pk.Make (bytes [0], bytes [1]);

		
			WebLog.Log ("cmdLOGIN_ANSWER_CONNECT_AUTH rec");
			OnRecDta<Common.cs_ACK> dlg = Singletons.GET<LoginService> ().OnValid;
			if (dlg != null) {
				dlg (pk);
			}
		}

		/// <summary>
		/// Deserializes the LOGIN_ANSWER_LOGIN_AUTH.
		/// </summary>
		/// <param name="bytes">Bytes.</param>
		public static void DeserializeLOGIN_ANSWER_LOGIN_AUTH (byte[] bytes)
		{
			cmdLOGIN_ANSWER_LOGIN_AUTH pk = new cmdLOGIN_ANSWER_LOGIN_AUTH ();
			pk.Make (bytes [0], bytes [1]);
			
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) { 
				//初始化偏移
				int ReadOffset = 2;
				
				//获取login_name
				Array.Copy (bytes, ReadOffset, pk.login_name, 0, (Constant.MAX_LOGIN_NAME_LEN + 1));
				ReadOffset += (Constant.MAX_LOGIN_NAME_LEN + 1) * sizeof(char);
				
				//获取 auth_key
				byte[] auth_key = new byte[Constant.MAX_AUTH_LEN * sizeof(char)];
				Array.Copy (bytes, ReadOffset, auth_key, 0, Constant.MAX_AUTH_LEN);
				pk.auth_key = System.Text.Encoding.Default.GetString (auth_key);
				ReadOffset += Constant.MAX_AUTH_LEN;
				
				//获取 security_key
				pk.security_key = System.BitConverter.ToUInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(uint);
				
				//获取warning
				pk.warning = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				//获取ip
				byte[] ip = new byte[(Constant.MAX_IP_ADDRESS_LEN + 1) * sizeof(char)];
				Array.Copy (bytes, ReadOffset, ip, 0, (Constant.MAX_IP_ADDRESS_LEN + 1));
				pk.ip = System.Text.Encoding.Default.GetString (ip);
				ReadOffset += (Constant.MAX_IP_ADDRESS_LEN + 1);
				
				//获取port
				pk.port = System.BitConverter.ToUInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(ushort);
				
				//获取gameSrvPort
				pk.gameSrvPort = System.BitConverter.ToUInt16 (bytes, ReadOffset);           
			}
			// todo Deserialize
			OnRecDta<cmdLOGIN_ANSWER_LOGIN_AUTH> dlg = Singletons.GET<LoginService> ().OnLogin;
			if (dlg != null) {
				dlg (pk);
			}
		}
	}
	
	public class LobbySeverInterface
	{
		/// <summary>
		/// Deserializes the GAME_ANSWER_CONNECT_AUTH.
		/// </summary>
		/// <param name="bytes">Bytes.</param>
		public static void DeserializeGAME_ANSWER_CONNECT_AUTH (byte[] bytes)
		{
			cmdGAME_ANSWER_CONNECT_AUTH pk = new cmdGAME_ANSWER_CONNECT_AUTH ();
			pk.Make (bytes [0], bytes [1]);

			OnRecDta<cmdGAME_ANSWER_CONNECT_AUTH> dlg = Singletons.GET<LobbyService> ().OnLobbyConnectAuth;
			if (dlg != null) {
				dlg (pk);
			}
		}
		/// <summary>
		/// Deserializes the GAME_ANSWER_LOGIN_AUTH.
		/// </summary>
		/// <param name="bytes">Bytes.</param>
		public static void DeserializeGAME_ANSWER_LOGIN_AUTH (byte[] bytes)
		{
			cmdGAME_ANSWER_LOGIN_AUTH pk = new cmdGAME_ANSWER_LOGIN_AUTH ();
			pk.Make (bytes [0], bytes [1]);

			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {	
				//初始化偏移
				int ReadOffset = 2;

				//获取 auth_key
				byte[] auth_key = new byte[Constant.MAX_AUTH_LEN * sizeof(char)];
				Array.Copy (bytes, ReadOffset, auth_key, 0, Constant.MAX_AUTH_LEN);
				pk.auth_key = System.Text.Encoding.Default.GetString (auth_key);
				ReadOffset += Constant.MAX_AUTH_LEN;

				//获取security_key
				pk.security_key = System.BitConverter.ToUInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(uint);

				//获取uid
				pk.uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(ushort);

				//获取lobbyUid
				pk.lobbyUid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(ushort);

			}

			OnRecDta<cmdGAME_ANSWER_LOGIN_AUTH> dlg = Singletons.GET<LobbyService> ().OnLobbyLoginAuth;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_USER_INFO (byte[] bytes)
		{

			cmdGAME_ANSWER_USER_INFO pk = new cmdGAME_ANSWER_USER_INFO ();
			pk.Make (bytes [0], bytes [1]);
			
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {	
				//初始化偏移
				int ReadOffset = 2;

				pk.ukey = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				byte[] chinese=new byte [(Constant.MAX_NICKNAME_LEN + 1)];
				Array.Copy (bytes, ReadOffset, chinese, 0, (Constant.MAX_NICKNAME_LEN + 1));
				string str=System.Text.Encoding.Unicode.GetString(chinese);
				pk.nickname=str.ToCharArray();
				ReadOffset += (Constant.MAX_NICKNAME_LEN + 1) * sizeof(char);

				pk.level = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				pk.avatar_no = bytes [ReadOffset]; 
				ReadOffset += sizeof(byte);

				pk.exp = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.money = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.tutorial = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.tutorial_try = bytes [ReadOffset]; 
				ReadOffset += sizeof(byte);

				for (int i=0; i<Constant.MAX_MISSION_CHAPTER; i++) {
					pk.mission [i] = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);
				}

				pk.emblem.emblemNo = System.BitConverter.ToUInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(short);

				for (int i=0; i<Command.Constant.MAX_EMBLEMS; i++) {
					pk.emblem.cnt [i] = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);
				}
				 
				byte[] clubname = new byte [(Constant.MAX_CLUB_NAME_LEN + 1)];
				Array.Copy (bytes, ReadOffset, clubname, 0, (Constant.MAX_CLUB_NAME_LEN + 1));
				string strClubName =System.Text.Encoding.Unicode.GetString(clubname);
				pk.clubname = strClubName.ToCharArray();
				ReadOffset += (Constant.MAX_CLUB_NAME_LEN + 1) * sizeof(char);

				pk.clubId = System.BitConverter.ToUInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(uint); 

				pk.clubEmblemNo = bytes [ReadOffset]; 
				ReadOffset += sizeof(byte);

				pk.clubSubEmblemNo = bytes [ReadOffset]; 
				ReadOffset += sizeof(byte);

				pk.guide_number = bytes [ReadOffset]; 
				ReadOffset += sizeof(byte);
				
				pk.achievement_point = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.achievement_total = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.bySex = bytes [ReadOffset]; 
				ReadOffset += sizeof(byte);

				pk.byItemModeClick = bytes [ReadOffset]; 
				ReadOffset += sizeof(byte);

				byte[] Privilege = new byte[4 * sizeof(char)];
				Array.Copy (bytes, ReadOffset, Privilege, 0, 4);
				pk.Privilege = System.Text.Encoding.Default.GetString (Privilege);
				ReadOffset += 4;

				for (int i=0; i<3; i++) {
					pk.PrivilegePercent [i] = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);
				}
			}


			OnRecDta<cmdGAME_ANSWER_USER_INFO> dlg = Singletons.GET<LobbyService> ().OnLobbyUserInfo;
			if (dlg != null) {
				dlg (pk);
			}
		}
	
		public static void DeserializeGAME_ANSWER_CASH_INFO (byte[] bytes)
		{
			CmdGameAnswerCashInfo pk = new CmdGameAnswerCashInfo ();
			pk.Make (bytes [0], bytes [1]);
			
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {
				//初始化偏移
				int ReadOffset = 2;

				pk.cash = System.BitConverter.ToInt64 (bytes, ReadOffset);

			}

			OnRecDta<CmdGameAnswerCashInfo> dlg = Singletons.GET<LobbyService> ().OnLobbyCashInfo;
			if (dlg != null) {
				dlg (pk);
			}
		}
	
		public static void DeserializeGAME_ANSWER_CHAR_INFO (byte[] bytes)
		{
			cmdGAME_ANSWER_CHAR_INFO pk = new cmdGAME_ANSWER_CHAR_INFO ();
			pk.Make (bytes [0], bytes [1]);
			
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {
				//初始化偏移
				int ReadOffset = 2;

				pk.info.cid = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.info.skincolor = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				pk.info.avatarno = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				pk.info.faceIndex = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.info.hair = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.info.upper = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.info.lower = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.info.shoes = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				pk.info.speed = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				pk.info.strength = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				pk.info.agility = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				pk.info.technic = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

/*				for (int i=0; i<Constant.MAX_EQUIP_SLOT; i++) {
					pk.equips [i].i_no = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.equips [i].item_id = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.equips [i].slot = bytes [ReadOffset];
					ReadOffset += sizeof(byte);

					pk.equips [i].socket_cnt = bytes [ReadOffset];
					ReadOffset += sizeof(byte);

					for (int j=0; j<Constant.MAX_SOCKET_NUM; j++) {
						pk.equips [i].sockets [j] = bytes [ReadOffset];
						ReadOffset += sizeof(byte);
					}
				
					pk.equips [i].stock = System.BitConverter.ToInt16 (bytes, ReadOffset);
					ReadOffset += sizeof(short);

					pk.equips [i].restMinute = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.equips [i].cid = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.equips [i].utility_id = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);
				}*/
				
			}
			
			OnRecDta<cmdGAME_ANSWER_CHAR_INFO> dlg = Singletons.GET<LobbyService> ().OnLobbyCharInfo;
			if (dlg != null) {
				dlg (pk);
			}


		}

		public static void DeserializeGAME_NOTIFY_GIFT_NEW (byte[] bytes)
		{
			cmdGAME_NOTIFY_GIFT_NEW pk = new cmdGAME_NOTIFY_GIFT_NEW ();

			OnRecDta<cmdGAME_NOTIFY_GIFT_NEW> dlg = Singletons.GET<LobbyService> ().OnLobbyNotifyGiftNew;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeMSG_NOTIFY_CLUB_AUTH_LEVEL_NAME (byte[] bytes)
		{
			cmdMSG_NOTIFY_CLUB_AUTHLEVEL_NAME pk = new cmdMSG_NOTIFY_CLUB_AUTHLEVEL_NAME ();
		
			int ReadOffset = 0;

			for (int i=0; i<Constant.MAX_CLUB_AUTHLEVEL; i++) {
				for (int j=0; j<Constant.MAX_CLUB_AUTHLEVEL_LEN + 1; j++) {
					pk.arrAuthLevelStr [i, j] = System.BitConverter.ToChar (bytes, ReadOffset);
					ReadOffset += sizeof(char);
				}	
			}

			OnRecDta<cmdMSG_NOTIFY_CLUB_AUTHLEVEL_NAME> dlg = Singletons.GET<LobbyService> ().OnLobbyNotifyClubAuthlevelName;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_MYHOUSINGITEM_LIST (byte[] bytes)
		{
			cmdGAME_ANSWER_MYHOUSINGITEM_LIST pk = new cmdGAME_ANSWER_MYHOUSINGITEM_LIST ();
			pk.Make (bytes [0], bytes [1]);
			
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {
				//初始化偏移
				int ReadOffset = 2;
				
				pk.cnt = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				for (int i=0; (i<pk.cnt && i<100); i++) {
					pk.housingitems [i].nIid = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.housingitems [i].nItemCode = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.housingitems [i].ucCategory = bytes [ReadOffset];
					ReadOffset += sizeof(byte);

					pk.housingitems [i].ucIsSet = bytes [ReadOffset];
					ReadOffset += sizeof(byte);

					pk.housingitems [i].nRestMinutes = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.housingitems [i].nPeriodic = bytes [ReadOffset];
					ReadOffset += sizeof(byte);
				}

				OnRecDta<cmdGAME_ANSWER_MYHOUSINGITEM_LIST> dlg = Singletons.GET<LobbyService> ().OnLobbyMyHousingItemList;
				if (dlg != null) {
					dlg (pk);
				}
			}
		}

		public static void DeserializeGAME_ANSWER_ABILITY_CARD_STAT (byte[] bytes)
		{
			cmdGAME_ANSWER_ABILITY_CARD_STAT pk = new cmdGAME_ANSWER_ABILITY_CARD_STAT ();
			pk.Make (bytes [0], bytes [1]);
			
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {
				//初始化偏移
				int ReadOffset = 2;
				
				for (int i=0; i<Constant.MAX_ABILITY_CARD_TYPE; i++) {
					pk.cardStat [i] = bytes [ReadOffset];
					ReadOffset += sizeof(byte);
				}	
			}

			OnRecDta<cmdGAME_ANSWER_ABILITY_CARD_STAT> dlg = Singletons.GET<LobbyService> ().OnLobbyAbilityCardStat;
			if (dlg != null) {
				dlg (pk);
			}

		}

		public static void DeserializeGAME_ANSWER_MYITEM_LIST (byte[] bytes)
		{
			cmdGAME_ANSWER_MYITEM_LIST pk = new cmdGAME_ANSWER_MYITEM_LIST ();
			pk.Make (bytes [0], bytes [1]);
			
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {
				//初始化偏移
				int ReadOffset = 2;
				
				pk.cnt = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);

				for (int i=0; (i<pk.cnt && i<50); i++) {
					pk.shopitems [i].i_no = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);
					
					pk.shopitems [i].cid = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.shopitems [i].item_id = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.shopitems [i].slot = bytes [ReadOffset];
					ReadOffset += sizeof(byte);

					pk.shopitems [i].is_wearing = bytes [ReadOffset];
					ReadOffset += sizeof(byte);

					pk.shopitems [i].socket_cnt = bytes [ReadOffset];
					ReadOffset += sizeof(byte);

					for (int j=0; j<Constant.MAX_SOCKET_NUM; j++) {
						pk.shopitems [i].socket [j] = bytes [ReadOffset];
						ReadOffset += sizeof(byte);
					}

					pk.shopitems [i].stock = System.BitConverter.ToUInt16 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.shopitems [i].rest_minutes = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);

					pk.shopitems [i].is_periodic = bytes [ReadOffset];
					ReadOffset += sizeof(byte);

					pk.shopitems [i].utility_id = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(int);
				}		
			}

			OnRecDta<cmdGAME_ANSWER_MYITEM_LIST> dlg = Singletons.GET<LobbyService> ().OnLobbyMyItemList;
			if (dlg != null) {
				dlg (pk);
			}
		}
	
		public static void DeserializeGAME_ANSWER_ENTER_LOBBY (byte[] bytes)
		{
			cmdGAME_ANSWER_ENTER_LOBBY pk = new cmdGAME_ANSWER_ENTER_LOBBY ();
			pk.Make (bytes [0], bytes [1]);
			
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {
					
			}

			OnRecDta<cmdGAME_ANSWER_ENTER_LOBBY> dlg = Singletons.GET<LobbyService> ().OnLobbyEnterLobby;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeRELAY_ECHO_PING (byte[] bytes)
		{

			cmdGAME_PING_INFO pk = new cmdGAME_PING_INFO ();
			OnRecDta<cmdGAME_PING_INFO> dlg = Singletons.GET<LobbyService> ().OnLobbyEchoPing;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_EVENT_LIST(byte[] bytes)
		{
			cmdGAME_ANSWER_EVENT_LIST pk = new cmdGAME_ANSWER_EVENT_LIST ();
	
			//初始化偏移
			int ReadOffset = 0;			
			pk.cnt = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			for (int i=0; i<pk.cnt; i++) 
			{
				cs_EVENT event_index = new cs_EVENT();

				event_index.eventType = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				event_index.isOpened = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				pk.events.Add(event_index);
			}		

			OnRecDta<cmdGAME_ANSWER_EVENT_LIST> dlg = Singletons.GET<LobbyService> ().OnLobbyEventList;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_ROOM_LIST(byte[] bytes)
		{
			cmdGAME_ANSWER_ROOM_LIST pk = new cmdGAME_ANSWER_ROOM_LIST ();
			pk.Make (bytes [0], bytes [1]);
			
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {
				
			} else {
			}
			
			OnRecDta<cmdGAME_ANSWER_ROOM_LIST> dlg = Singletons.GET<LobbyService> ().OnLobbyRoomList;
			if (dlg != null) {
				dlg (pk);
			}
		}


		public static void DeserializeGAME_NOTIFY_ROOM_LIST_PAGE(byte[] bytes)
		{
			cmdGameNotifyRoomListPage pk = new cmdGameNotifyRoomListPage ();
			//初始化偏移
			int ReadOffset = 0;
			pk.nPageNo = bytes [ReadOffset];

			OnRecDta<cmdGameNotifyRoomListPage> dlg = Singletons.GET<LobbyService> ().OnLobbyNotifyRoomListPage;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_LIST_ADD(byte[] bytes)
		{
			cmdGameNotifyRoomListAdd pk = new cmdGameNotifyRoomListAdd ();
			//初始化偏移
			int ReadOffset = 0;

			//房间序号
			pk.info.roomNo = System.BitConverter.ToInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(short);

			//房间名字
			byte[] chinese=new byte [(Constant.MAX_NICKNAME_LEN + 1)];
			Array.Copy (bytes, ReadOffset, chinese, 0, (Constant.MAX_NICKNAME_LEN + 1));
			string str=System.Text.Encoding.Unicode.GetString(chinese);
			pk.info.name=str.ToCharArray();
			ReadOffset += (Constant.MAX_ROOM_NAME_LEN + 1) * sizeof(char);

			//页面类型
			pk.info.mode = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//地图序号
			pk.info.mapNum = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(int);

			//当前人数
			pk.info.joinerNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//房间是否有密码(1:有房间密码)
			pk.info.password = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//房间状态（0:等待开始, 1:进行中）
			pk.info.status = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//圈数
			pk.info.mapLaps = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//最大人数
			pk.info.maxJoinerNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//IP地址
			byte[] byteIP = new byte[(Constant.MAX_IP_ADDRESS_LEN + 1)* sizeof(char)];
			Array.Copy (bytes, ReadOffset, byteIP, 0, Constant.MAX_IP_ADDRESS_LEN + 1);
			pk.info.ip = System.Text.Encoding.Default.GetString (byteIP);
			ReadOffset += Constant.MAX_IP_ADDRESS_LEN + 1;

			//俱乐部名称
			Array.Copy (bytes, ReadOffset, pk.info.clubname1, 0, Constant.MAX_CLUB_NAME_LEN + 1);
			ReadOffset += (Constant.MAX_CLUB_NAME_LEN + 1) * sizeof(char);

			//俱乐部名称
			Array.Copy (bytes, ReadOffset, pk.info.clubname2, 0, Constant.MAX_CLUB_NAME_LEN + 1);
			ReadOffset += (Constant.MAX_CLUB_NAME_LEN + 1) * sizeof(char);

			//是否开启碰撞
			pk.info.bStrikeAttack = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//男的数量
			pk.info.byManNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//女的数量
			pk.info.byGirlNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//等级类型
			pk.info.byLevelType = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

		#if _CHAT_ROOM_
			//年龄
			pk.info.age = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//聊天模式
			pk.info.chatMode = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//地域
			pk.info.region = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//性别
			pk.info.JoinGender = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
		#endif

		#if _AUDIENCE_MODE_
			//观察者数量
			pk.info.byAudienceNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);	
		#endif

		#if _MATCH_POINT
			//比赛分数
			pk.info.nRoomMatchPoint = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);
		#endif

		#if _MODIFY_PASSWORD
			//密码
			Array.Copy (bytes, ReadOffset, pk.info.password_info, 0, Constant.MAX_ROOM_PASSWORD_LEN + 1);
			ReadOffset += (Constant.MAX_ROOM_PASSWORD_LEN + 1)* sizeof(char);
		#endif


			//游戏服务器端口
			pk.info.usGamePort = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);

			//房主天梯分数
			pk.info.score = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			OnRecDta<cmdGameNotifyRoomListAdd> dlg = Singletons.GET<LobbyService> ().OnLobbyNotifyRoomListAdd;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_LIST_DELETE(byte[] bytes)
		{
			cmdGameNotifyRoomListDel pk = new cmdGameNotifyRoomListDel ();
			//初始化偏移
			int ReadOffset = 0;
			pk.roomNo = bytes [ReadOffset];
			
			OnRecDta<cmdGameNotifyRoomListDel> dlg = Singletons.GET<LobbyService> ().OnLobbyNotifyRoomListDel;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_LIST_UPDATE(byte[] bytes)
		{
			cmdGameNotifyRoomListUpdate pk = new cmdGameNotifyRoomListUpdate ();
			//初始化偏移
			int ReadOffset = 0;
			
			//房间序号
			pk.info.roomNo = System.BitConverter.ToInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(short);
			
			//房间名字
			byte[] name = new byte [(Constant.MAX_ROOM_NAME_LEN + 1)];
			Array.Copy (bytes, ReadOffset, name, 0, (Constant.MAX_ROOM_NAME_LEN + 1));
			string strName =System.Text.Encoding.Unicode.GetString(name);
			pk.info.name = strName.ToCharArray();
			ReadOffset += (Constant.MAX_ROOM_NAME_LEN + 1) * sizeof(char);
			
			//页面类型
			pk.info.mode = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//地图序号
			pk.info.mapNum = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(int);
			
			//当前人数
			pk.info.joinerNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//房间是否有密码(1:有房间密码)
			pk.info.password = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//房间状态（0:等待开始, 1:进行中）
			pk.info.status = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//圈数
			pk.info.mapLaps = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//最大人数
			pk.info.maxJoinerNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//IP地址
			byte[] byteIP = new byte[(Constant.MAX_IP_ADDRESS_LEN + 1)* sizeof(char)];
			Array.Copy (bytes, ReadOffset, byteIP, 0, Constant.MAX_IP_ADDRESS_LEN + 1);
			pk.info.ip = System.Text.Encoding.Default.GetString (byteIP);
			ReadOffset += Constant.MAX_IP_ADDRESS_LEN + 1;
			
			//俱乐部名称
			Array.Copy (bytes, ReadOffset, pk.info.clubname1, 0, Constant.MAX_CLUB_NAME_LEN + 1);
			ReadOffset += (Constant.MAX_CLUB_NAME_LEN + 1)* sizeof(char);
			
			//俱乐部名称
			Array.Copy (bytes, ReadOffset, pk.info.clubname2, 0, Constant.MAX_CLUB_NAME_LEN + 1);
			ReadOffset += (Constant.MAX_CLUB_NAME_LEN + 1) * sizeof(char);
			
			//是否开启碰撞
			pk.info.bStrikeAttack = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//男的数量
			pk.info.byManNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//女的数量
			pk.info.byGirlNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//等级类型
			pk.info.byLevelType = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
		#if _CHAT_ROOM_
			//年龄
			pk.info.age = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//聊天模式
			pk.info.chatMode = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//地域
			pk.info.region = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			//性别
			pk.info.JoinGender = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
		#endif
			
		#if _AUDIENCE_MODE_
			//观察者数量
			pk.info.byAudienceNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);	
		#endif
			
		#if _MATCH_POINT
			//比赛分数
			pk.info.nRoomMatchPoint = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);
		#endif
			
		#if _MODIFY_PASSWORD
			//密码
			Array.Copy (bytes, ReadOffset, pk.info.password_info, 0, Constant.MAX_ROOM_PASSWORD_LEN + 1);
			ReadOffset += (Constant.MAX_ROOM_PASSWORD_LEN + 1) * sizeof(char);
		#endif
			
			
			//游戏服务器端口
			pk.info.usGamePort = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);
			
			//房主天梯分数
			pk.info.score = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);
			
			OnRecDta<cmdGameNotifyRoomListUpdate> dlg = Singletons.GET<LobbyService> ().OnLobbyNotifyRoomListUpdate;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_ROOM_QUICKJOIN(byte[] bytes)
		{
			cmdGameAnswerRoomQuickJoin pk = new cmdGameAnswerRoomQuickJoin ();
			pk.Make (bytes [0], bytes [1]);
			if (pk.GetAck () == 0) {
				WebLog.Log(pk.GetEno());
			} else if (pk.GetAck () == 1) { 
				//初始化偏移
				int ReadOffset = 2;
			
				//房间序号
				pk.info.roomNo = System.BitConverter.ToInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(short);
			
				//房间名字
				byte[] name = new byte [(Constant.MAX_ROOM_NAME_LEN + 1)];
				Array.Copy (bytes, ReadOffset, name, 0, (Constant.MAX_ROOM_NAME_LEN + 1));
				string strName =System.Text.Encoding.Unicode.GetString(name);
				pk.info.name = strName.ToCharArray();
				ReadOffset += (Constant.MAX_ROOM_NAME_LEN + 1) * sizeof(char);
			
				//页面类型
				pk.info.mode = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//地图序号
				pk.info.mapNum = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);
			
				//当前人数
				pk.info.joinerNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//房间是否有密码(1:有房间密码)
				pk.info.password = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//房间状态（0:等待开始, 1:进行中）
				pk.info.status = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//圈数
				pk.info.mapLaps = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//最大人数
				pk.info.maxJoinerNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//IP地址
				byte[] byteIP = new byte[(Constant.MAX_IP_ADDRESS_LEN + 1) * sizeof(char)];
				Array.Copy (bytes, ReadOffset, byteIP, 0, Constant.MAX_IP_ADDRESS_LEN + 1);
				pk.info.ip = System.Text.Encoding.Default.GetString (byteIP);
				ReadOffset += Constant.MAX_IP_ADDRESS_LEN + 1;
			
				//俱乐部名称
				Array.Copy (bytes, ReadOffset, pk.info.clubname1, 0, Constant.MAX_CLUB_NAME_LEN + 1);
				ReadOffset += (Constant.MAX_CLUB_NAME_LEN + 1) * sizeof(char);
			
				//俱乐部名称
				Array.Copy (bytes, ReadOffset, pk.info.clubname2, 0, Constant.MAX_CLUB_NAME_LEN + 1);
				ReadOffset += (Constant.MAX_CLUB_NAME_LEN + 1) * sizeof(char);
			
				//是否开启碰撞
				pk.info.bStrikeAttack = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//男的数量
				pk.info.byManNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//女的数量
				pk.info.byGirlNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//等级类型
				pk.info.byLevelType = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				#if _CHAT_ROOM_
				//年龄
				pk.info.age = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//聊天模式
				pk.info.chatMode = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//地域
				pk.info.region = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//性别
				pk.info.JoinGender = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				#endif
			
				#if _AUDIENCE_MODE_
				//观察者数量
				pk.info.byAudienceNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);	
				#endif
			
				#if _MATCH_POINT
				//比赛分数
				pk.info.nRoomMatchPoint = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(Int32);
				#endif
			
				#if _MODIFY_PASSWORD
				//密码
				Array.Copy (bytes, ReadOffset, pk.info.password_info, 0, Constant.MAX_ROOM_PASSWORD_LEN + 1);
				ReadOffset += (Constant.MAX_ROOM_PASSWORD_LEN + 1)* sizeof(char);
				#endif			
			
				//游戏服务器端口
				pk.info.usGamePort = System.BitConverter.ToUInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(UInt16);
			
				//房主天梯分数
				pk.info.score = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(Int32);
			}
			
			OnRecDta<cmdGameAnswerRoomQuickJoin> dlg = Singletons.GET<LobbyService> ().OnLobbyRoomLQuickJoin;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_ROOM_CREATE(byte[] bytes)
		{
			cmdGameAnswerRoomCreate pk = new cmdGameAnswerRoomCreate ();
			pk.Make (bytes [0], bytes [1]);

			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) { 
				//初始化偏移
				int ReadOffset = 2;			

				//房间号码
				pk.roomNo = System.BitConverter.ToInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(short);

				//房间名字
				byte[] chinese=new byte [(Constant.MAX_NICKNAME_LEN + 1)];
				Array.Copy (bytes, ReadOffset, chinese, 0, (Constant.MAX_NICKNAME_LEN + 1));
				string str=System.Text.Encoding.Unicode.GetString(chinese);
				pk.name=str.ToCharArray();
				ReadOffset += (Constant.MAX_ROOM_NAME_LEN + 1) * sizeof(char);

				// 房间是否有密码(1:有房间密码)
				pk.password = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 地图ID
				pk.mapNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 比赛模式(参考eMATCH_MODE)
				pk.mode = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 圈数
				pk.mapLaps = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 最大可进入的人
				pk.maxJoinerNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				pk.gameKey = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(Int32);

				//IP地址
				byte[] byteIP = new byte[(Constant.MAX_IP_ADDRESS_LEN + 1) * sizeof(char)];
				Array.Copy (bytes, ReadOffset, byteIP, 0, Constant.MAX_IP_ADDRESS_LEN + 1);
				pk.ip = System.Text.Encoding.Default.GetString (byteIP);
				ReadOffset += Constant.MAX_IP_ADDRESS_LEN + 1;

				// 游戏服务器里面的房间
				pk.gameSrvRoomNo = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(Int32);

				#if _MODIFY_PASSWORD
				//房间密码
				Array.Copy (bytes, ReadOffset, pk.password_info, 0, Constant.MAX_ROOM_PASSWORD_LEN + 1);
				ReadOffset += (Constant.MAX_ROOM_PASSWORD_LEN + 1) * sizeof(char);
				//游戏服务器端口
				pk.usGamePort = System.BitConverter.ToUInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(UInt16);
				#endif
			}
			
			OnRecDta<cmdGameAnswerRoomCreate> dlg = Singletons.GET<LobbyService> ().OnLobbyRoomCreate;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_MODE_SELECT(byte[] bytes)
		{
			cmdGAME_ANSWER_MODE_SELECT pk = new cmdGAME_ANSWER_MODE_SELECT ();
			pk.Make (bytes [0], bytes [1]);
			
			//初始化偏移
			int ReadOffset = 2;
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) 
			{
				// 是否开启碰撞
				pk.mode = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			}
			
			OnRecDta<cmdGAME_ANSWER_MODE_SELECT> dlg = Singletons.GET<LobbyService> ().OnGameModeSelect;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_ROOM_JOIN(byte[] bytes)
		{
			cmdGAME_ANSWER_ROOM_JOIN pk = new cmdGAME_ANSWER_ROOM_JOIN ();
			pk.Make (bytes [0], bytes [1]);
			//初始化偏移
			int ReadOffset = 2;
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) {
			
				//房间号码
				pk.roomNo = System.BitConverter.ToInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(short);
			
				//房间名字
				byte[] name = new byte [(Constant.MAX_ROOM_NAME_LEN + 1)];
				Array.Copy (bytes, ReadOffset, name, 0, (Constant.MAX_ROOM_NAME_LEN + 1));
				string strName =System.Text.Encoding.Unicode.GetString(name);
				pk.name = strName.ToCharArray();
				ReadOffset += (Constant.MAX_ROOM_NAME_LEN + 1) * sizeof(char);
			
				// 房间是否有密码(1:有房间密码)
				pk.password = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 比赛模式(参考eMATCH_MODE)
				pk.mode = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 地图ID
				pk.mapNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// playr位置号码
				pk.playerIndex = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 团队(参考eTEAM_COLOR )
				pk.teamcolor = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//装饰物品
				for (int i=0; i<Constant.MAX_HOUSINGITEM_SLOT; i++) {
					pk.arrHousingItems [i] = System.BitConverter.ToUInt16 (bytes, ReadOffset);
					ReadOffset += sizeof(int);
				}

				// 圈数
				pk.mapLaps = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				// 最大可进入的人
				pk.maxJoinerNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//用户ID
				pk.uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(Int32);

				//是不是房主
				pk.isRoomMaster = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//可不可以碰撞
				pk.bStrikeAttack = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//等级低的玩家连接等级高的玩家的房间【0：同级的表示×，1：等级高的房间很危险表示0】
				pk.byWarning = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				#if _MAPTABLE_RENEWAL
				//等级类型
				pk.byLevelType = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				#endif

				#if _CHAT_ROOM_
				//年龄段
				pk.age = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//聊天模式
				pk.chatmode = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//地域
				pk.region = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//性别
				pk.JoinGender = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
			
				//男性的数量
				pk.byManNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//女性的数量
				pk.byGirlNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				#endif
			
				#if _AUDIENCE_MODE_
				//是不是旁观
				pk.isAudience = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//旁观人数
				pk.byAudienceNum = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				#endif
			}

			OnRecDta<cmdGAME_ANSWER_ROOM_JOIN> dlg = Singletons.GET<GameService> ().OnGameRoomJoin;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_READY(byte[] bytes)
		{
			cmdGAME_NOTIFY_ROOM_READY pk = new cmdGAME_NOTIFY_ROOM_READY ();
			//初始化偏移
			int ReadOffset = 0;

			//已准备的玩家ID/游戏中的玩家ID
			pk.uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);

			// 准备状态（1：准备完毕，0：未准备）
			pk.state = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			OnRecDta<cmdGAME_NOTIFY_ROOM_READY> dlg = Singletons.GET<GameService> ().OnGameNotifyRoomReady;
			if (dlg != null) {
				dlg (pk);
			}
		}


		public static void DeserializeGAME_NOTIFY_ROOM_JOIN(byte[] bytes)
		{
			cmdGAME_NOTIFY_ROOM_JOIN pk = new cmdGAME_NOTIFY_ROOM_JOIN ();
			//初始化偏移
			int ReadOffset = 0;

			//玩家ID
			pk.uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);

			//玩家原有号码(db key)
			pk.ukey = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			// playr位置号码
			pk.playerIndex = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//角色名
			byte[] nickname = new byte [(Constant.MAX_CHAR_NAME_LEN + 1)];
			Array.Copy (bytes, ReadOffset, nickname, 0, (Constant.MAX_CHAR_NAME_LEN + 1));
			string strNickName =System.Text.Encoding.Unicode.GetString(nickname);
			pk.nickname = strNickName.ToCharArray();
			ReadOffset += (Constant.MAX_CHAR_NAME_LEN + 1) * sizeof(char);

			// avatar(0~)
			pk.avatarNo = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 皮肤色
			pk.skincolor = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//脸部索引
			pk.faceIndex = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			//头发
			pk.hair = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			//上装
			pk.upper = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			//下装
			pk.lower = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			//鞋子
			pk.shoes = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			// 等级
			pk.level = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//所属的Eemblem号码
			pk.emblemNo = System.BitConverter.ToInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(short);

			// 准备状态（1：准备完毕，0：未准备）
			pk.ready = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 房主（1：房主）
			pk.roomMaster = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 团队(参考eTEAM_COLOR )
			pk.teamcolor = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//CLUB名称
			byte[] clubname = new byte [(Constant.MAX_CLUB_NAME_LEN + 1)];
			Array.Copy (bytes, ReadOffset, clubname, 0, (Constant.MAX_CLUB_NAME_LEN + 1));
			string strClubName =System.Text.Encoding.Unicode.GetString(clubname);
			pk.clubname = strClubName.ToCharArray();
			ReadOffset += (Constant.MAX_CLUB_NAME_LEN + 1) * sizeof(char);

			//CLUB ID
			pk.clubId = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);

			// CLUB emblem
			pk.clubEmblemNo = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// CLUB派生 emblem
			pk.clubSubEmblemNo = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 新进入的玩家
			pk.enteredUser = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//佩戴物品信息 MAX_EQUIP_SLOT = 11 
			/*for (int i=0; i<Constant.MAX_EQUIP_SLOT; i++) {
				pk.equips [i].i_no = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);
				
				pk.equips [i].item_id = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);
				
				pk.equips [i].slot = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				pk.equips [i].socket_cnt = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				for (int j=0; j<Constant.MAX_SOCKET_NUM; j++) {
					pk.equips [i].sockets [j] = bytes [ReadOffset];
					ReadOffset += sizeof(byte);
				}
				
				pk.equips [i].stock = System.BitConverter.ToInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(short);
				
				pk.equips [i].restMinute = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);
				
				pk.equips [i].cid = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);
				
				pk.equips [i].utility_id = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);
			}

			// 性别
			pk.bySex = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			byte[] Privilege = new byte[4 * sizeof(char)];
			Array.Copy (bytes, ReadOffset, Privilege, 0, 4);
			pk.Privilege = System.Text.Encoding.Default.GetString (Privilege);
			ReadOffset += 4;*/

			OnRecDta<cmdGAME_NOTIFY_ROOM_JOIN> dlg = Singletons.GET<GameService> ().OnGameNotifyRoomJoin;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_MAX_JOINER_NUM_CHANGE(byte[] bytes)
		{
			cmdGameNotifyRoomMaxJoinerNumChange pk = new cmdGameNotifyRoomMaxJoinerNumChange ();
			//初始化偏移
			int ReadOffset = 0;
			// 最大人数
			pk.maxJoinerNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			OnRecDta<cmdGameNotifyRoomMaxJoinerNumChange> dlg = Singletons.GET<GameService> ().OnGameNotifyRoomMaxJoinerNumChange;
			if (dlg != null) {
				dlg (pk);
			}
 		}

		public static void DeserializeGAME_NOTIFY_ROOM_SETTING(byte[] bytes)
		{
			cmdGAME_NOTIFY_ROOM_SETTING pk = new cmdGAME_NOTIFY_ROOM_SETTING ();
			//初始化偏移
			int ReadOffset = 0;

			//房间名
			byte[] name = new byte [(Constant.MAX_ROOM_NAME_LEN + 1)];
			Array.Copy (bytes, ReadOffset, name, 0, (Constant.MAX_ROOM_NAME_LEN + 1));
			string str=System.Text.Encoding.Unicode.GetString(name);
			pk.name=str.ToCharArray();
			ReadOffset += (Constant.MAX_ROOM_NAME_LEN + 1) * sizeof(char);

			//房间密码
			Array.Copy (bytes, ReadOffset, pk.password, 0, Constant.MAX_ROOM_PASSWORD_LEN + 1);
			ReadOffset += (Constant.MAX_ROOM_PASSWORD_LEN + 1) * sizeof(char);

			OnRecDta<cmdGAME_NOTIFY_ROOM_SETTING> dlg = Singletons.GET<GameService> ().OnGameNotifyRoomSetting;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_ROOM_STRIKEATTACK_INFO_CHANGE(byte[] bytes)
		{
			cmdGameNotiRoomStrikeAttackInfoChange pk = new cmdGameNotiRoomStrikeAttackInfoChange ();
			//初始化偏移
			int ReadOffset = 0;

			// 是否开启碰撞
			pk.bStrikeAttack = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			OnRecDta<cmdGameNotiRoomStrikeAttackInfoChange> dlg = Singletons.GET<GameService> ().OnGameNotiRoomStrikeAttackInfoChange;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_LEAVE(byte[] bytes)
		{
			cmdGAME_NOTIFY_ROOM_LEAVE pk = new cmdGAME_NOTIFY_ROOM_LEAVE ();
			//初始化偏移
			int ReadOffset = 0;

			//退出的玩家ID/游戏中的玩家ID	
			pk.leave_uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);

			//接替房主位置的玩家ID	
			pk.roomMaster_uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);

			OnRecDta<cmdGAME_NOTIFY_ROOM_LEAVE> dlg = Singletons.GET<GameService> ().OnGameRoomLeave;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_TEAMCHANGE(byte[] bytes)
		{
			cmdGAME_NOTIFY_ROOM_TEAMCHANGE pk = new cmdGAME_NOTIFY_ROOM_TEAMCHANGE ();
			//初始化偏移
			int ReadOffset = 0;

			//交换的玩家（比赛）的玩家ID
			pk.uid = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);

			//游戏模式(参考eTEAM_COLOR )	
			pk.teamcolor = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			OnRecDta<cmdGAME_NOTIFY_ROOM_TEAMCHANGE> dlg = Singletons.GET<GameService> ().OnGameRoomTeamChange;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_HOUSINGITEM_CHANGE(byte[] bytes)
		{
			cmdGameNotifyHousingItemChange pk = new cmdGameNotifyHousingItemChange ();
			//初始化偏移
			int ReadOffset = 0;

			//房间的装饰物品
			for (int i=0; i<Constant.MAX_HOUSINGITEM_SLOT; i++) {
				pk.arrHousings [i] = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(int);
			}

			OnRecDta<cmdGameNotifyHousingItemChange> dlg = Singletons.GET<GameService> ().OnGameHousingItemChange;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_KICKOUT(byte[] bytes)
		{
			cmdGAME_NOTIFY_ROOM_KICKOUT pk = new cmdGAME_NOTIFY_ROOM_KICKOUT ();
			//初始化偏移
			int ReadOffset = 0;

			//强退的玩家ID/游戏中的玩家ID 
			pk.uid = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);

			OnRecDta<cmdGAME_NOTIFY_ROOM_KICKOUT> dlg = Singletons.GET<GameService> ().OnGameRoomKickOut;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_MAPSELECT(byte[] bytes)
		{
			cmdGAME_NOTIFY_ROOM_MAPSELECT pk = new cmdGAME_NOTIFY_ROOM_MAPSELECT ();
			//初始化偏移
			int ReadOffset = 0;

			//地图ID
			pk.mapNum = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//圈数
			pk.mapLaps = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			OnRecDta<cmdGAME_NOTIFY_ROOM_MAPSELECT> dlg = Singletons.GET<GameService> ().OnGameRoomMapSelect;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_GAME_START_COUNT(byte[] bytes)
		{
			cmdGAME_ANSWER_GAME_START_COUNT pk = new cmdGAME_ANSWER_GAME_START_COUNT ();
			pk.Make (bytes [0], bytes [1]);
			//初始化偏移
			int ReadOffset = 2;
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) 
			{
			}

			OnRecDta<cmdGAME_ANSWER_GAME_START_COUNT> dlg = Singletons.GET<GameService> ().OnGameStartCount;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_START_COUNT(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_START_COUNT pk = new cmdGAME_NOTIFY_GAME_START_COUNT ();
			//初始化偏移
			int ReadOffset = 0;
			
			//是否自动开发 0表示否 1表示是
			pk.byAutoStart = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			OnRecDta<cmdGAME_NOTIFY_GAME_START_COUNT> dlg = Singletons.GET<GameService> ().OnGameNotifyStartCount;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_COUNT_STOP(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_STOP_COUNT pk = new cmdGAME_NOTIFY_GAME_STOP_COUNT ();
			//初始化偏移
			int ReadOffset = 0;

			//是否取消游戏倒计时 0表示否 1表示是
			pk.byStop = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			OnRecDta<cmdGAME_NOTIFY_GAME_STOP_COUNT> dlg = Singletons.GET<GameService> ().OnGameNotifyStopCount;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_ROOM_START(byte[] bytes)
		{
			cmdGAME_ANSWER_ROOM_START pk = new cmdGAME_ANSWER_ROOM_START ();
			pk.Make (bytes [0], bytes [1]);
			//初始化偏移
			int ReadOffset = 2;
			if (pk.GetAck () == 0) {
				
			} else if (pk.GetAck () == 1) 
			{
			}

			OnRecDta<cmdGAME_ANSWER_ROOM_START> dlg = Singletons.GET<GameService> ().OnGameRoomStart;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_LOADING_WAIT(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_LOADING_WAIT pk = new cmdGAME_NOTIFY_GAME_LOADING_WAIT ();
			//初始化偏移
			int ReadOffset = 0;
			
			OnRecDta<cmdGAME_NOTIFY_GAME_LOADING_WAIT> dlg = Singletons.GET<GameService> ().OnGameNotifyLoadingWait;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_ROOM_START(byte[] bytes)
		{
			cmdGAME_NOTIFY_ROOM_START pk = new cmdGAME_NOTIFY_ROOM_START ();
			//初始化偏移
			int ReadOffset = 0;

			//地图ID
			pk.mapNo = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//地图圈数
			pk.mapLaps = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			//位置信息相关，有具体算法构成
			pk.startPos = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);
			
			#if _EVENTOBJECT_CHANGE
			//当前服务器的时间值，客户端暂时未用此值
			pk.seed = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);
			#endif
			
			OnRecDta<cmdGAME_NOTIFY_ROOM_START> dlg = Singletons.GET<GameService> ().OnGameNotifyRoomStart;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_LOADING_PROGRESS_VALUE(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_LOADING_PROGRESS_VALUE pk = new cmdGAME_NOTIFY_GAME_LOADING_PROGRESS_VALUE ();
			//初始化偏移
			int ReadOffset = 0;

			//游戏(用于比赛)服务器内部分配的玩家索引
			pk.uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);

			//进度条的数值（0~100）
			pk.val = System.BitConverter.ToInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(short);

			OnRecDta<cmdGAME_NOTIFY_GAME_LOADING_PROGRESS_VALUE> dlg = Singletons.GET<GameService> ().OnGameNotifyLoadingProgressVal;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_LOADED(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_LOADED pk = new cmdGAME_NOTIFY_GAME_LOADED ();
			//初始化偏移
			int ReadOffset = 0;
			
			pk.uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);
			
			OnRecDta<cmdGAME_NOTIFY_GAME_LOADED> dlg = Singletons.GET<GameService> ().OnGameNotifyLoaded;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_LOADING_END(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_LOADING_END pk = new cmdGAME_NOTIFY_GAME_LOADING_END ();
			//初始化偏移
			int ReadOffset = 0;

			OnRecDta<cmdGAME_NOTIFY_GAME_LOADING_END> dlg = Singletons.GET<GameService> ().OnGameNotifyLoadingEnd;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_START(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_START pk = new cmdGAME_NOTIFY_GAME_START ();
			//初始化偏移
			int ReadOffset = 0;
			
			OnRecDta<cmdGAME_NOTIFY_GAME_START> dlg = Singletons.GET<GameService> ().OnGameNotifyGameStart;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_SP_CHANGE(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_SP_CHANGE pk = new cmdGAME_NOTIFY_GAME_SP_CHANGE ();
			//初始化偏移
			int ReadOffset = 0;

			//增量值，有正负之分
			pk.delta = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);
			
			OnRecDta<cmdGAME_NOTIFY_GAME_SP_CHANGE> dlg = Singletons.GET<GameService> ().OnGameNotifySPChange;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_MAX_COMBO_USER(byte[] bytes)
		{
			cmdGameNotifyMaxComboUser pk = new cmdGameNotifyMaxComboUser ();
			//初始化偏移
			int ReadOffset = 0;
			
			// 对应玩家
			pk.uid = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			// ture的话就是maxcombo,false的话就是maxcombo解除
			pk.max_combo = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			pk.dEndTime = 0;
			// 维持时间[是max_combo true 的时候添加]
			if (pk.max_combo == 1) 
			{
				pk.dEndTime = System.BitConverter.ToInt64 (bytes, ReadOffset);
				ReadOffset += sizeof(Int64);
			}

			OnRecDta<cmdGameNotifyMaxComboUser> dlg = Singletons.GET<GameService> ().OnGameNotifyMaxComboUser;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_EVENTOBJECT(byte[] bytes)
		{
			cmdGameNotifyGameEventObject pk = new cmdGameNotifyGameEventObject ();
			//初始化偏移
			int ReadOffset = 0;

			// 游戏(用于比赛)服务器内部分配的玩家索引
			pk.uid = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			// 当前地图（包含路径）的hash值与固定值异或后的值
			pk.managerHandle = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);

			// EventObject节点的hash值
			pk.eventObjectHandle = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);

			// 当前位置的事件（包含路径）的hash值与固定值异或后的值
			pk.eventUnitHandle = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);

			// 当前位置的事件（包含路径）的hash值与固定值异或后的值
			pk.eventHandle = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);

			OnRecDta<cmdGameNotifyGameEventObject> dlg = Singletons.GET<GameService> ().OnGameNotifyGameEventObject;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_ANSWER_GAME_CHANGE_SERVER_SP(byte[] bytes)
		{
			cmdGameAnswerServerSp pk = new cmdGameAnswerServerSp ();
			//初始化偏移
			int ReadOffset = 0;

			// 服务器里的sp
			pk.nSp = System.BitConverter.ToInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(Int32);

			OnRecDta<cmdGameAnswerServerSp> dlg = Singletons.GET<GameService> ().OnGameServerSp;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_CHECKPOINT(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_CHECKPOINT pk = new cmdGAME_NOTIFY_GAME_CHECKPOINT ();
			//初始化偏移
			int ReadOffset = 0;
			
			// 玩家ID(玩家原有号码)
			pk.uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);

			// 关口A
			pk.checkpointA = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 关口B
			pk.checkpointB = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			
			OnRecDta<cmdGAME_NOTIFY_GAME_CHECKPOINT> dlg = Singletons.GET<GameService> ().OnGameNotifyCheckPoint;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_STATUS_START(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_STATUS_START pk = new cmdGAME_NOTIFY_GAME_STATUS_START ();
			//初始化偏移
			int ReadOffset = 0;

			pk.usUserID = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);

			//按照个数添加cmdStatus_Info 构造体
			pk.byStatusCount = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			for (byte i=0; i<pk.byStatusCount; i++) 
			{
				cmdStatus_Info status = new cmdStatus_Info();
				
				status.byStatusType = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				status.byValue = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				pk.events.Add(status);
			}
			
			
			OnRecDta<cmdGAME_NOTIFY_GAME_STATUS_START> dlg = Singletons.GET<GameService> ().OnGameNotifyStatusStart;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_STATUS_STOP(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_STATUS_STOP pk = new cmdGAME_NOTIFY_GAME_STATUS_STOP ();
			//初始化偏移
			int ReadOffset = 0;
			
			pk.usUserID = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);
			
			//按照个数添加cmdStatus_Info 构造体
			pk.byStatusCount = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			for (byte i=0; i<pk.byStatusCount; i++) 
			{
				cmdStatus_Info status = new cmdStatus_Info();
				
				status.byStatusType = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				status.byValue = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				pk.events.Add(status);
			}
			
			
			OnRecDta<cmdGAME_NOTIFY_GAME_STATUS_STOP> dlg = Singletons.GET<GameService> ().OnGameNotifyStatusStop;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_GOALIN(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_GOALIN pk = new cmdGAME_NOTIFY_GAME_GOALIN ();
			//初始化偏移
			int ReadOffset = 0;

			// 已GOALIN的玩家ID
			pk.uid = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);

			//耗时  
			pk.lapTime.hour = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			pk.lapTime.minute = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			pk.lapTime.second = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			pk.lapTime.centisecond = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 排名(1~)
			pk.rank = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			OnRecDta<cmdGAME_NOTIFY_GAME_GOALIN> dlg = Singletons.GET<GameService> ().OnGameNotifyGameGoalIn;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_FINISH(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_FINISH pk = new cmdGAME_NOTIFY_GAME_FINISH ();
			//初始化偏移
			int ReadOffset = 0;

			//是否撤退(1:撤退)
			pk.retire = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			OnRecDta<cmdGAME_NOTIFY_GAME_FINISH> dlg = Singletons.GET<GameService> ().OnGameNotifyGameFinish;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeGAME_NOTIFY_GAME_RESULT(byte[] bytes)
		{
			cmdGAME_NOTIFY_GAME_RESULT pk = new cmdGAME_NOTIFY_GAME_RESULT ();
			//初始化偏移
			int ReadOffset = 0;

			#if _TEAM_MAXBOOSTER
			//绿队的MVP
			pk.GreenMvpUID = System.BitConverter.ToInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(Int16);

			//红队的MVP
			pk.RedMvpUID = System.BitConverter.ToInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(Int16);
			#endif
			
			// 世界记录
			pk.worldRecord.hour = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			pk.worldRecord.minute = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			pk.worldRecord.second = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			pk.worldRecord.centisecond = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 个人记录
			pk.personalRecord.hour = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			pk.personalRecord.minute = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			pk.personalRecord.second = bytes [ReadOffset];
			ReadOffset += sizeof(byte);
			
			pk.personalRecord.centisecond = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 世界记录更新(1：更新)
			pk.newWorldRecord = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 个人记录更新(1：更新)
			pk.newPersonalRecord = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// 胜利团队(0:个人战, 1:绿色团队, 2:红色团队, 参考eTEAM_COLOR , 团队战时所用)
			pk.winningTeam = bytes [ReadOffset];
			ReadOffset += sizeof(byte);

			// CLUB战时获得的cp(绿色团队)
			pk.cp_green = System.BitConverter.ToInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(Int16);

			// CLUB战时获得的cp(红色团队)
			pk.cp_red = System.BitConverter.ToInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(Int16);
			
			// 结果个数(玩家数)
			pk.count = System.BitConverter.ToUInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt16);

			// 结果信息
			for(UInt16 index=0;(index < pk.count && index< Constant.MAX_PLAYERS);++index)
			{
				// 玩家ID
				pk.results[index].uid = System.BitConverter.ToUInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(UInt16);

				//角色名
				byte[] name = new byte [(Constant.MAX_CHAR_NAME_LEN + 1)];
				Array.Copy (bytes, ReadOffset, name, 0, (Constant.MAX_CHAR_NAME_LEN + 1));
				string str=System.Text.Encoding.Unicode.GetString(name);
				pk.results[index].charname=str.ToCharArray();
				ReadOffset += (Constant.MAX_CHAR_NAME_LEN + 1) * sizeof(char);
				
				// avatar(0~)
				pk.results[index].avatarNo = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 等级
				pk.results[index].level = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 所属emblem
				pk.results[index].emblemNo = System.BitConverter.ToInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(Int16);

				// 排名
				pk.results[index].rank = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 是否撤退(1:撤退) 
				pk.results[index].retire = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//耗时  
				pk.results[index].lapTime.hour = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				pk.results[index].lapTime.minute = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				pk.results[index].lapTime.second = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				pk.results[index].lapTime.centisecond = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 获得经验值
				pk.results[index].exp = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(Int32);

				// 获得金钱
				pk.results[index].money = System.BitConverter.ToInt32 (bytes, ReadOffset);
				ReadOffset += sizeof(Int32);

				// 获得emblems
				for(Int16 i=0;i<Constant.MAX_EMBLEMS;++i)
				{
					pk.results[index].emblems[i] = System.BitConverter.ToInt16 (bytes, ReadOffset);
					ReadOffset += sizeof(Int16);
				}
				
				#if _NEW_REWARD_RESULT
				//结果奖金
				for (int i=0; i<(int)ePlusRewardType.ePlusRewardType_MAX; i++) {
					for (int j=0; j<(int)ePlusRewardEffect.ePlusRewardEffect_MAX; j++) {
						pk.results[index].plusReward [i, j] = System.BitConverter.ToInt16 (bytes, ReadOffset);
						ReadOffset += sizeof(Int16);
					}	
				}
				#if _NEW_REWARD_RESULT_V2	
				//材料物品号码0 : 材料ID, 1 : 材料Count
				for (int i=0; i<2; i++) {
					for (int j=0; j<Constant.MAX_REWARD_MATERIAL; j++) {
						pk.results[index].materialItemID [i, j] = System.BitConverter.ToInt32 (bytes, ReadOffset);
						ReadOffset += sizeof(Int32);
					}	
				}
				#else
				// 材料物品号码
				for(Int32 i=0;i<Constant.MAX_REWARD_MATERIAL;++i)
				{
					pk.results[index].materialItemID[i] = System.BitConverter.ToInt32 (bytes, ReadOffset);
					ReadOffset += sizeof(Int32);
				}
				#endif
				#endif
				// 团队(0:个人战, 1:绿色团队, 2:红色团队)
				pk.results[index].teamcolor = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// 胜利积分(团队战时所用)
				pk.results[index].point = System.BitConverter.ToInt16 (bytes, ReadOffset);
				ReadOffset += sizeof(Int16);

				// 参考GameEventType enum type
				pk.results[index].eventType = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				//JACKUp 标志
				pk.results[index].byJackUp = bytes [ReadOffset];
				ReadOffset += sizeof(byte);

				// ExpUp 标志
				pk.results[index].byExpUp = bytes [ReadOffset];
				ReadOffset += sizeof(byte);
				
				//0:无特权1:有特权0-3位置:美眉特权,公会,媒体,网吧
				byte[] Privilege = new byte[4 * sizeof(char)];
				Array.Copy (bytes, ReadOffset, Privilege, 0, 4);
				pk.results[index].Privilege = System.Text.Encoding.Default.GetString (Privilege);
				ReadOffset += 4 * sizeof(char);
			}

			OnRecDta<cmdGAME_NOTIFY_GAME_RESULT> dlg = Singletons.GET<GameService> ().OnGameNotifyGameResult;
			if (dlg != null) {
				dlg (pk);
			}
		}

		public static void DeserializeRELAY_ECHO_POSITION(byte[] bytes)
		{
			cmdRELAY_ECHO_POSITION pk = new cmdRELAY_ECHO_POSITION ();
			//初始化偏移
			int ReadOffset = 0;

			pk.cmdId = System.BitConverter.ToInt16 (bytes, ReadOffset);
			ReadOffset += sizeof(short);

			pk.uid = System.BitConverter.ToUInt32 (bytes, ReadOffset);
			ReadOffset += sizeof(UInt32);

			pk.pos_x = System.BitConverter.ToSingle (bytes, ReadOffset);
			ReadOffset += sizeof(float);

			pk.pos_y = System.BitConverter.ToSingle (bytes, ReadOffset);
			ReadOffset += sizeof(float);

			pk.pos_z = System.BitConverter.ToSingle (bytes, ReadOffset);
			ReadOffset += sizeof(float);

			#if _NEW_PROUD_CHAR_MOVE_
			pk.velocity_x = System.BitConverter.ToSingle (bytes, ReadOffset);
			ReadOffset += sizeof(float);
			
			pk.velocity_y = System.BitConverter.ToSingle (bytes, ReadOffset);
			ReadOffset += sizeof(float);
			
			pk.velocity_z = System.BitConverter.ToSingle (bytes, ReadOffset);
			ReadOffset += sizeof(float);

			pk.zRotSpeed = System.BitConverter.ToSingle (bytes, ReadOffset);
			ReadOffset += sizeof(float);
			#endif

			pk.zRotAng = System.BitConverter.ToSingle (bytes, ReadOffset);
			ReadOffset += sizeof(float);
			
			pk.speed = System.BitConverter.ToSingle (bytes, ReadOffset);
			ReadOffset += sizeof(float);

			OnRecDta<cmdRELAY_ECHO_POSITION> dlg = Singletons.GET<GameService> ().OnGameEchoPosition;
			if (dlg != null) {
				dlg (pk);
			}
		}

	}


}