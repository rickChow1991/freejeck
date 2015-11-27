#define _NEW_PROUD_CHAR_MOVE_

using System;
using System.Text;
using System.Security.Cryptography;


using Cmdlib;
using Command;
using Nettention.Proud;
using InterfaceToSever;
using com.iuixi.FreeJeck;


namespace InterfaceToSever
{
    public class Serialize 
    {

		/// <summary>
		/// Serializes the packet.
		/// </summary>
		/// <returns>The packet.</returns>
		/// <param name="cmd">Cmd.</param>
		/// <param name="obj">Object.</param>
		public static CPacket SerializePacket(ushort cmd, object obj)
        {
            switch(cmd)
            {
                case (int)Login.eLOGIN_REQUEST.LOGIN_REQUEST_CONNECT_AUTH:
                    return LoginSeverInterface.SerializeLOGIN_REQUEST_CONNECT_AUTH(cmd, obj);
                case (int)Login.eLOGIN_REQUEST.LOGIN_REQUEST_LOGIN_AUTH:
                    return LoginSeverInterface.SerializeLOGIN_REQUEST_LOGIN_AUTH(cmd, obj);

				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_CONNECT_AUTH:
					return LobbySeverInterface.SerializeGAME_REQUEST_CONNECT_AUTH(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_LOGIN_AUTH:
					return LobbySeverInterface.SerializeGAME_REQUEST_LOGIN_AUTH(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_USER_INFO:
					return LobbySeverInterface.SerializeGAME_REQUEST_USER_INFO(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_MYHOUSINGITEM_LIST:
					return LobbySeverInterface.SerializeGAME_REQUEST_MYHOUSINGITEM_LIST(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_CHAR_INFO:
					return LobbySeverInterface.SerializeGAME_REQUEST_CHAR_INFO(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ABILITY_CARD_STAT:
					return LobbySeverInterface.SerializeGAME_REQUEST_ABILITY_CARD_STAT(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_MYITEM_LIST:
					return LobbySeverInterface.SerializeGAME_REQUEST_MYITEM_LIST(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ENTER_LOBBY:
					return LobbySeverInterface.SerializeGAME_REQUEST_ENTER_LOBBY(cmd, obj);
				case (int)Lobby.eRELAY_ECHO.RELAY_ECHO_PING:
					return LobbySeverInterface.SerializeRELAY_ECHO_PING(cmd, obj);

				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_EVENT_LIST:
					return LobbySeverInterface.SerializeGAME_REQUEST_EVENT_LIST(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_LIST:
					return LobbySeverInterface.SerializeGAME_REQUEST_ROOM_LIST(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_QUICKJOIN:
					return LobbySeverInterface.SerializeGAME_REQUEST_ROOM_QUICKJOIN(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_CREATE:
					return LobbySeverInterface.SerializeGAME_REQUEST_ROOM_CREATE(cmd, obj);
			case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_MODE_SELECT:
				return LobbySeverInterface.SerializeGAME_REQUEST_MODE_SELECT(cmd, obj);

				//Game Msg
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_CREATE_GSRV:
					return GameSeverInterface.SerializeGAME_REQUEST_ROOM_CREATE_GSRV(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_READY:
					return GameSeverInterface.SerializeGAME_REQUEST_ROOM_READY(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_LOBBY_MEMBERS:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_LOBBY_MEMBERS(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_MAX_JOINER_NUM_CHANGE:
					return GameSeverInterface.SerializeGAME_REQUEST_ROOM_MAX_JOINER_NUM_CHANGE(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_SETTING:
					return GameSeverInterface.SerializeGAME_REQUEST_ROOM_SETTING(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_ROOM_STRIKEATTACK_INFO_CHANGE:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_ROOM_STRIKEATTACK_INFO_CHANGE(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_JOIN:
					return GameSeverInterface.SerializeGAME_REQUEST_ROOM_JOIN(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_TEAMCHANGE:
					return GameSeverInterface.SerializeGAME_REQUEST_ROOM_TEAMCHANGE(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_KICKOUT:
					return GameSeverInterface.SerializeGAME_REQUEST_ROOM_KICKOUT(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_MAPSELECT:
					return GameSeverInterface.SerializeGAME_REQUEST_ROOM_MAPSELECT(cmd, obj);

				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_START_COUNT:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_START_COUNT(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_COUNT_STOP:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_COUNT_STOP(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_START:
					return GameSeverInterface.SerializeGAME_REQUEST_ROOM_START(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_LOADING_READY:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_LOADING_READY(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_LOADING_PROGRESS_VALUE:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_LOADING_PROGRESS_VALUE(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_LOADED:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_LOADED(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_PASSZONE:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_PASSZONE(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_SKILL:
					return GameSeverInterface.SerializeGAME_REQUEST_SKILL(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_SET_MAX_COMBO:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_SET_MAX_COMBO(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_EVENTOBJECT:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_EVENTOBJECT(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_SPUSE:
					return GameSeverInterface.SerializeGAME_REQUEST_SPUSE(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_CHECKPOINT:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_CHECKPOINT(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_USER_INPUT_STATUS_STOP:
					return GameSeverInterface.SerializeGAME_REQUEST_USER_INPUT_STATUS_STOP(cmd, obj);
				case (int)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_GOALIN:
					return GameSeverInterface.SerializeGAME_REQUEST_GAME_GOALIN(cmd, obj);
				case (int)Lobby.eRELAY_ECHO.RELAY_ECHO_POSITION:
					return GameSeverInterface.SerializeRELAY_ECHO_POSITION(cmd, obj);
                    
            }
            return null;
        }
    }	
    
    public class LoginSeverInterface 
    {
		/// <summary>
		/// Serializes the LOGIN_REQUEST_CONNECT_AUTH.
		/// </summary>
		/// <returns>The LOGI n_ REQUES t_ CONNEC t_ AUT.</returns>
		/// <param name="cmd">Cmd.</param>
		/// <param name="obj">Object.</param>
        public static CPacket SerializeLOGIN_REQUEST_CONNECT_AUTH(ushort cmd, object obj)
        {
           cmdLOGIN_REQUEST_CONNECT_AUTH pk=( cmdLOGIN_REQUEST_CONNECT_AUTH)obj;
            CPacket __msg = new CPacket();
            ushort size = (ushort)pk.szVersionInfo.Length;

            __msg.WriteHeader(cmd, size, 0);
			__msg.WriteBytes(pk.szVersionInfo,size);
			
			return __msg;
        }

		/// <summary>
		/// Serializes the LOGIN_REQUEST_LOGN_AUTH.
		/// </summary>
		/// <returns>The LOGI n_ REQUES t_ LOGI n_ AUT.</returns>
		/// <param name="cmd">Cmd.</param>
		/// <param name="obj">Object.</param>
        public static CPacket SerializeLOGIN_REQUEST_LOGIN_AUTH(ushort cmd, object obj)
        {
            cmdLOGIN_REQUEST_LOGIN_AUTH pk = (cmdLOGIN_REQUEST_LOGIN_AUTH)obj;
            CPacket __msg = new CPacket();
			ushort size = Constant.MAX_LOGIN_NAME_LEN + 1 + Constant.MAX_PASSWORD_LEN + 1;
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.WriteChars(pk.login_name,Constant.MAX_LOGIN_NAME_LEN + 1);
			__msg.WriteChars(pk.password,Constant.MAX_PASSWORD_LEN + 1);

            return __msg;
        }
    }

	public class LobbySeverInterface 
	{
		/// <summary>
		/// Serializes the GAME_REQUEST_CONNECT_AUTH.
		/// </summary>
		/// <returns>The GAM e_ REQUES t_ CONNEC t_ AUT.</returns>
		/// <param name="cmd">Cmd.</param>
		/// <param name="obj">Object.</param>
		public static CPacket SerializeGAME_REQUEST_CONNECT_AUTH(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_CONNECT_AUTH pk=(cmdGAME_REQUEST_CONNECT_AUTH)obj;
			CPacket __msg = new CPacket();

			__msg.WriteHeader(cmd, 0, 0);

			return __msg;
		}
		
		/// <summary>
		/// Serializes the GAME_REQUEST_LOGIN_AUTH.
		/// </summary>
		/// <returns>The GAM e_ REQUES t_ LOGI n_ AUT.</returns>
		/// <param name="cmd">Cmd.</param>
		/// <param name="obj">Object.</param>
		public static CPacket SerializeGAME_REQUEST_LOGIN_AUTH(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_LOGIN_AUTH pk = (cmdGAME_REQUEST_LOGIN_AUTH)obj;
			CPacket __msg = new CPacket();
			ushort size = Constant.MAX_LOGIN_NAME_LEN + 1 + Constant.MAX_AUTH_LEN + sizeof(int)+2*sizeof(byte);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.WriteCharsCut0(pk.login_name,Constant.MAX_LOGIN_NAME_LEN + 1);
			__msg.WriteString(pk.auth_key,Constant.MAX_AUTH_LEN);
			__msg.Write(pk.auth_checksum);
			__msg.Write(pk.divisionLv);
			__msg.Write(pk.channelNo);
				
			return __msg;
		}


		public static CPacket SerializeGAME_REQUEST_USER_INFO(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_USER_INFO pk = (cmdGAME_REQUEST_USER_INFO)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(uint);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write(pk.security_key);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_MYHOUSINGITEM_LIST(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_MYHOUSINGITEM_LIST pk = (cmdGAME_REQUEST_MYHOUSINGITEM_LIST)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;

			__msg.WriteHeader(cmd, size, 0);

			return __msg;

		}

		public static CPacket SerializeGAME_REQUEST_CHAR_INFO(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_CHAR_INFO pk = (cmdGAME_REQUEST_CHAR_INFO)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(byte);

			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.avatar);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ABILITY_CARD_STAT(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ABILITY_CARD_STAT pk = (cmdGAME_REQUEST_ABILITY_CARD_STAT)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;
			__msg.WriteHeader(cmd, size, 0);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_MYITEM_LIST(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_MYITEM_LIST pk = (cmdGAME_REQUEST_MYITEM_LIST)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;
			__msg.WriteHeader(cmd, size, 0);
			
			return __msg;
		}
	
		public static CPacket SerializeGAME_REQUEST_ENTER_LOBBY(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ENTER_LOBBY pk = (cmdGAME_REQUEST_ENTER_LOBBY)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;
			__msg.WriteHeader(cmd, size, 0);
			
			return __msg;
		}
	
		public static CPacket SerializeRELAY_ECHO_PING(ushort cmd, object obj)
		{
			cmdGAME_PING_INFO pk = (cmdGAME_PING_INFO)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;
			__msg.WriteHeader(cmd, size, 0);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_EVENT_LIST(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_EVENT_LIST pk = (cmdGAME_REQUEST_EVENT_LIST)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;
			__msg.WriteHeader(cmd, size, 0);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_LIST(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ROOM_LIST pk = (cmdGAME_REQUEST_ROOM_LIST)obj;
			CPacket __msg = new CPacket();
			ushort size = 3* sizeof(byte);
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.pageType);
			__msg.Write (pk.matchViewType);
			__msg.Write (pk.roomViewType);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_QUICKJOIN(ushort cmd, object obj)
		{
			cmdGameRequestRoomQuickJoin pk = (cmdGameRequestRoomQuickJoin)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(byte);
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.mode);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_CREATE(ushort cmd, object obj)
		{
			cmdGameRequestRoomCreate pk = (cmdGameRequestRoomCreate)obj;
			CPacket __msg = new CPacket();
			ushort size = Constant.MAX_ROOM_NAME_LEN + 1 + Constant.MAX_ROOM_PASSWORD_LEN + 1 + sizeof(bool) + 4*sizeof(byte);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.WriteChars(pk.name,Constant.MAX_ROOM_NAME_LEN + 1);
			__msg.WriteChars(pk.password,Constant.MAX_ROOM_PASSWORD_LEN + 1);
			__msg.Write(pk.mapNum);
			__msg.Write(pk.mode);
			__msg.Write(pk.mapLaps);
			__msg.Write(pk.maxJoinerNum);
			__msg.Write(pk.StrikeAttack);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_MODE_SELECT(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_MODE_SELECT pk = (cmdGAME_REQUEST_MODE_SELECT)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(byte);
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.mode);
			
			return __msg;
		}
	}


	public class GameSeverInterface 
	{
		public static CPacket SerializeGAME_REQUEST_ROOM_CREATE_GSRV(ushort cmd, object obj)
		{
			cmdGameRequestCreateGame_GameSrv pk = (cmdGameRequestCreateGame_GameSrv)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(byte) + 4*sizeof(Int32);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write(pk.mode);
			__msg.Write(pk.roomNo);
			__msg.Write(pk.gameKey);
			__msg.Write(pk.lobbyUserId);
			__msg.Write(pk.lobbySrvId);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_READY(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ROOM_READY pk = (cmdGAME_REQUEST_ROOM_READY)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(byte);
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.byReady);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_LOBBY_MEMBERS(ushort cmd, object obj)
		{
			cmdGameRequestGameLobbyMembers pk = (cmdGameRequestGameLobbyMembers)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;
			__msg.WriteHeader(cmd, size, 0);
						
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_MAX_JOINER_NUM_CHANGE(ushort cmd, object obj)
		{
			cmdGameRequestRoomMaxJoinerNumChange pk = (cmdGameRequestRoomMaxJoinerNumChange)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(byte);
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.maxJoinerNum);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_SETTING(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ROOM_SETTING pk = (cmdGAME_REQUEST_ROOM_SETTING)obj;
			CPacket __msg = new CPacket();
			ushort size = Constant.MAX_ROOM_NAME_LEN + 1 + Constant.MAX_ROOM_PASSWORD_LEN + 1;
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.WriteChars(pk.name,Constant.MAX_ROOM_NAME_LEN + 1);
			__msg.WriteChars(pk.password,Constant.MAX_ROOM_PASSWORD_LEN + 1);

			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_ROOM_STRIKEATTACK_INFO_CHANGE(ushort cmd, object obj)
		{
			cmdGameRequestRoomStrikeAttackInfoChange pk = (cmdGameRequestRoomStrikeAttackInfoChange)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(bool);
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.bStrikeAttack);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_JOIN(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ROOM_JOIN pk = (cmdGAME_REQUEST_ROOM_JOIN)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(short) + Constant.MAX_ROOM_PASSWORD_LEN + 1 + sizeof(byte) + 2*sizeof(UInt32);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write(pk.roomNo);
			__msg.WriteChars(pk.password,Constant.MAX_ROOM_PASSWORD_LEN + 1);
			__msg.Write(pk.mode);
			__msg.Write(pk.lobbyUserId);
			__msg.Write(pk.lobbySrvId);
						
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_TEAMCHANGE(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ROOM_TEAMCHANGE pk = (cmdGAME_REQUEST_ROOM_TEAMCHANGE)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(UInt32);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write(pk.uid);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_KICKOUT(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ROOM_KICKOUT pk = (cmdGAME_REQUEST_ROOM_KICKOUT)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(int);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write(pk.uid);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_MAPSELECT(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ROOM_MAPSELECT pk = (cmdGAME_REQUEST_ROOM_MAPSELECT)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(byte);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write(pk.mapNum);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_START_COUNT(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_GAME_START_COUNT pk = (cmdGAME_REQUEST_GAME_START_COUNT)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(byte);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write(pk.byAutoStart);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_COUNT_STOP(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_GAME_STOP_COUNT pk = (cmdGAME_REQUEST_GAME_STOP_COUNT)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(byte);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write(pk.byStop);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_ROOM_START(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_ROOM_START pk = (cmdGAME_REQUEST_ROOM_START)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;
			
			__msg.WriteHeader(cmd, size, 0);
						
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_LOADING_READY(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_GAME_LOADING_READY pk = (cmdGAME_REQUEST_GAME_LOADING_READY)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;
			
			__msg.WriteHeader(cmd, size, 0);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_LOADING_PROGRESS_VALUE(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_GAME_LOADING_PROGRESS_VALUE pk = (cmdGAME_REQUEST_GAME_LOADING_PROGRESS_VALUE)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(short);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write(pk.val);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_LOADED(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_GAME_LOADED pk = (cmdGAME_REQUEST_GAME_LOADED)obj;
			CPacket __msg = new CPacket();
			ushort size = 0;
			
			__msg.WriteHeader(cmd, size, 0);
						
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_PASSZONE(ushort cmd, object obj)
		{
			cmdGameRequestGamePassZone pk = (cmdGameRequestGamePassZone)obj;
			CPacket __msg = new CPacket();
			ushort size = 3 * sizeof(float) + sizeof(Int32);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.x);
			__msg.Write (pk.y);
			__msg.Write (pk.z);
			__msg.Write (pk.passzone_id);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_SKILL(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_SKILL pk = (cmdGAME_REQUEST_SKILL)obj;
			CPacket __msg = new CPacket();
			ushort size = 4 * sizeof(short) + sizeof(byte);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.type);
			__msg.Write (pk.sp);
			__msg.Write (pk.judge);
			__msg.Write (pk.dir);
			__msg.Write (pk.skill_type);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_SET_MAX_COMBO(ushort cmd, object obj)
		{
			cmdGameRequestGameSetMaxCombo pk = (cmdGameRequestGameSetMaxCombo)obj;
			CPacket __msg = new CPacket();
			ushort size = 2 * sizeof(byte) + sizeof(char);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.max_combo_step);
			__msg.Write (pk.byUserItem);
			__msg.Write (pk.bIsPerfect);
					
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_EVENTOBJECT(ushort cmd, object obj)
		{
			cmdGameRequestGameEventObject pk = (cmdGameRequestGameEventObject)obj;
			CPacket __msg = new CPacket();
			ushort size = 4 * sizeof(UInt32);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.managerHandle);
			__msg.Write (pk.eventObjectHandle);
			__msg.Write (pk.eventUnitHandle);
			__msg.Write (pk.eventHandle);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_SPUSE(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_SPUSE pk = (cmdGAME_REQUEST_SPUSE)obj;
			CPacket __msg = new CPacket();
			ushort size = 2 * sizeof(Int16);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.type);
			__msg.Write (pk.sp);

			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_CHECKPOINT(ushort cmd, object obj)
		{
			cmdGameRequestGameCheckPoint pk = (cmdGameRequestGameCheckPoint)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(Int32);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.check_point);
					
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_USER_INPUT_STATUS_STOP(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_USER_INPUT_STATUS_STOP pk = (cmdGAME_REQUEST_USER_INPUT_STATUS_STOP)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(UInt32);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.uiItemindex);
			
			return __msg;
		}

		public static CPacket SerializeGAME_REQUEST_GAME_GOALIN(ushort cmd, object obj)
		{
			cmdGAME_REQUEST_GAME_GOALIN pk = (cmdGAME_REQUEST_GAME_GOALIN)obj;
			CPacket __msg = new CPacket();
			ushort size = sizeof(Int32);
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.gameKey);
			
			return __msg;
		}


		public static CPacket SerializeRELAY_ECHO_POSITION(ushort cmd, object obj)
		{
			cmdRELAY_ECHO_POSITION pk = (cmdRELAY_ECHO_POSITION)obj;
			CPacket __msg = new CPacket();
			ushort size = 5 * sizeof(float) + sizeof(short) + sizeof(UInt32);

			#if _NEW_PROUD_CHAR_MOVE_
			size = 9 * sizeof(float) + sizeof(short) + sizeof(UInt32);
			#endif
			
			__msg.WriteHeader(cmd, size, 0);
			__msg.Write (pk.cmdId);
			__msg.Write (pk.uid);

			__msg.Write (pk.pos_x);
			__msg.Write (pk.pos_y);
			__msg.Write (pk.pos_z);

			#if _NEW_PROUD_CHAR_MOVE_
			__msg.Write (pk.velocity_x);
			__msg.Write (pk.velocity_y);
			__msg.Write (pk.velocity_z);
			__msg.Write (pk.zRotSpeed);
			#endif

			__msg.Write (pk.zRotAng);
			__msg.Write (pk.speed);
			
			return __msg;
		}


	}
}


