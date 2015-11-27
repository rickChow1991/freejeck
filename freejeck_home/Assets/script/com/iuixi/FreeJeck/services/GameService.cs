#define _NEW_PROUD_CHAR_MOVE_

using System;
using Cmdlib;
using Common;
using Command;
using InterfaceToSever;
using UnityEngine;

namespace com.iuixi.FreeJeck
{
	/// <summary>
	///   游戏比赛相关 
	/// </summary>
	public class GameService : BaseServices<GameNetWork>
	{
		public OnRecDta<cmdGAME_ANSWER_ROOM_JOIN> OnGameRoomJoin;
		public OnRecDta<cmdGAME_NOTIFY_ROOM_READY> OnGameNotifyRoomReady;
		public OnRecDta<cmdGAME_NOTIFY_ROOM_JOIN> OnGameNotifyRoomJoin;
		public OnRecDta<cmdGameNotifyRoomMaxJoinerNumChange> OnGameNotifyRoomMaxJoinerNumChange;
		public OnRecDta<cmdGAME_NOTIFY_ROOM_SETTING> OnGameNotifyRoomSetting;
		public OnRecDta<cmdGameNotiRoomStrikeAttackInfoChange> OnGameNotiRoomStrikeAttackInfoChange;
		//public OnRecDta<cmdGAME_NOTIFY_GAME_LOADED> OnGameNotifyGameLoaded;
		public OnRecDta<cmdGAME_NOTIFY_ROOM_LEAVE> OnGameRoomLeave;
		public OnRecDta<cmdGAME_NOTIFY_ROOM_TEAMCHANGE> OnGameRoomTeamChange;
		public OnRecDta<cmdGameNotifyHousingItemChange> OnGameHousingItemChange;
		public OnRecDta<cmdGAME_NOTIFY_ROOM_KICKOUT> OnGameRoomKickOut;
		public OnRecDta<cmdGAME_NOTIFY_ROOM_MAPSELECT> OnGameRoomMapSelect;

		public OnRecDta<cmdGAME_ANSWER_GAME_START_COUNT> OnGameStartCount;
		public OnRecDta<cmdGAME_NOTIFY_GAME_START_COUNT> OnGameNotifyStartCount;
		public OnRecDta<cmdGAME_NOTIFY_GAME_STOP_COUNT> OnGameNotifyStopCount;
		public OnRecDta<cmdGAME_ANSWER_ROOM_START> OnGameRoomStart;
		public OnRecDta<cmdGAME_NOTIFY_GAME_LOADING_WAIT> OnGameNotifyLoadingWait;
		public OnRecDta<cmdGAME_NOTIFY_ROOM_START> OnGameNotifyRoomStart;
		public OnRecDta<cmdGAME_NOTIFY_GAME_LOADING_PROGRESS_VALUE> OnGameNotifyLoadingProgressVal;
		public OnRecDta<cmdGAME_NOTIFY_GAME_LOADED> OnGameNotifyLoaded;
		public OnRecDta<cmdGAME_NOTIFY_GAME_LOADING_END> OnGameNotifyLoadingEnd;
		public OnRecDta<cmdGAME_NOTIFY_GAME_START> OnGameNotifyGameStart;
		public OnRecDta<cmdGAME_NOTIFY_GAME_SP_CHANGE> OnGameNotifySPChange;
		public OnRecDta<cmdGameNotifyMaxComboUser> OnGameNotifyMaxComboUser;
		public OnRecDta<cmdGameNotifyGameEventObject> OnGameNotifyGameEventObject;
		public OnRecDta<cmdGameAnswerServerSp> OnGameServerSp;
		public OnRecDta<cmdGAME_NOTIFY_GAME_CHECKPOINT> OnGameNotifyCheckPoint;
		public OnRecDta<cmdGAME_NOTIFY_GAME_STATUS_START> OnGameNotifyStatusStart;
		public OnRecDta<cmdGAME_NOTIFY_GAME_STATUS_STOP> OnGameNotifyStatusStop;
		public OnRecDta<cmdGAME_NOTIFY_GAME_GOALIN> OnGameNotifyGameGoalIn;
		public OnRecDta<cmdGAME_NOTIFY_GAME_FINISH> OnGameNotifyGameFinish;
		public OnRecDta<cmdGAME_NOTIFY_GAME_RESULT> OnGameNotifyGameResult;
		public OnRecDta<cmdRELAY_ECHO_POSITION> OnGameEchoPosition;


		public void GameRoomCreate(byte mode,Int32 roomNo,Int32 gameKey,UInt32 lobbyUserId,UInt32 lobbySrvId, OnRecDta<cmdGAME_ANSWER_ROOM_JOIN> dlg)
		{
			OnGameRoomJoin = dlg;
			GameRoomCreate (mode,roomNo,gameKey,lobbyUserId,lobbySrvId);		
		}
		public void GameRoomCreate(byte mode,Int32 roomNo,Int32 gameKey,UInt32 lobbyUserId,UInt32 lobbySrvId)
		{
			cmdGameRequestCreateGame_GameSrv pk = new cmdGameRequestCreateGame_GameSrv();
			pk.mode = mode;
			pk.roomNo = roomNo;
			pk.gameKey = gameKey;
			pk.lobbyUserId = lobbyUserId;
			pk.lobbySrvId = lobbySrvId;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_CREATE_GSRV, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);		
		}

		public void GameRoomReady(byte byReady,OnRecDta<cmdGAME_NOTIFY_ROOM_READY> dlg)
		{
			OnGameNotifyRoomReady = dlg;
			GameRoomReady (byReady);
		}
		public void GameRoomReady(byte byReady)
		{
			cmdGAME_REQUEST_ROOM_READY pk = new cmdGAME_REQUEST_ROOM_READY();
			pk.byReady = byReady;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_READY, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}


		public void LoadGameLobbyMembers(OnRecDta<cmdGAME_NOTIFY_ROOM_JOIN> dlg)
		{
			OnGameNotifyRoomJoin = dlg;
			LoadGameLobbyMembers ();
		}
		public void LoadGameLobbyMembers()
		{
			cmdGameRequestGameLobbyMembers pk = new cmdGameRequestGameLobbyMembers();
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_LOBBY_MEMBERS, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameRoomMaxJoinerNumChange(byte maxJoinerNum,OnRecDta<cmdGameNotifyRoomMaxJoinerNumChange> dlg)
		{
			OnGameNotifyRoomMaxJoinerNumChange = dlg;
			GameRoomMaxJoinerNumChange (maxJoinerNum);
		}
		public void GameRoomMaxJoinerNumChange(byte maxJoinerNum)
		{
			cmdGameRequestRoomMaxJoinerNumChange pk = new cmdGameRequestRoomMaxJoinerNumChange();
			pk.maxJoinerNum = maxJoinerNum;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_MAX_JOINER_NUM_CHANGE, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}


		public void GameRoomSetting(string name,string password,OnRecDta<cmdGAME_NOTIFY_ROOM_SETTING> dlg)
		{
			OnGameNotifyRoomSetting = dlg;
			GameRoomSetting (name,password);
		}
		public void GameRoomSetting(string name,string password)
		{
			cmdGAME_REQUEST_ROOM_SETTING pk = new cmdGAME_REQUEST_ROOM_SETTING();
			Array.Copy(name.ToCharArray(), pk.name, name.Length);
			Array.Copy(password.ToCharArray(), pk.password, password.Length);

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_SETTING, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}


		public void GameRoomStrikeAttackInfoChange(bool bStrikeAttack,OnRecDta<cmdGameNotiRoomStrikeAttackInfoChange> dlg)
		{
			OnGameNotiRoomStrikeAttackInfoChange = dlg;
			GameRoomStrikeAttackInfoChange (bStrikeAttack);
		}
		public void GameRoomStrikeAttackInfoChange(bool bStrikeAttack)
		{
			cmdGameRequestRoomStrikeAttackInfoChange pk = new cmdGameRequestRoomStrikeAttackInfoChange();
			pk.bStrikeAttack = bStrikeAttack;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_ROOM_STRIKEATTACK_INFO_CHANGE, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}




		public void GameRoomJoin(short roomNo,string password,byte mode,UInt32 lobbyUserId,UInt32 lobbySrvId, OnRecDta<cmdGAME_ANSWER_ROOM_JOIN> dlg)
		{
			OnGameRoomJoin = dlg;
			GameRoomJoin (roomNo,password,mode,lobbyUserId,lobbySrvId);		
		}
		public void GameRoomJoin(short roomNo,string password,byte mode,UInt32 lobbyUserId,UInt32 lobbySrvId)
		{
			cmdGAME_REQUEST_ROOM_JOIN pk = new cmdGAME_REQUEST_ROOM_JOIN();
			pk.roomNo = roomNo;
			Array.Copy(password.ToCharArray(), pk.password, password.Length);
			pk.mode = mode;
			pk.lobbyUserId = lobbyUserId;
			pk.lobbySrvId = lobbySrvId;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_JOIN, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);		
		}


		public void GameRoomTeamChange(UInt32 uid,OnRecDta<cmdGAME_NOTIFY_ROOM_TEAMCHANGE> dlg)
		{
			OnGameRoomTeamChange = dlg;
			GameRoomTeamChange (uid);
		}
		public void GameRoomTeamChange(UInt32 uid)
		{
			cmdGAME_REQUEST_ROOM_TEAMCHANGE pk = new cmdGAME_REQUEST_ROOM_TEAMCHANGE();
			pk.uid = uid;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_TEAMCHANGE, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}


		public void GameRoomKickOut(UInt32 uid,OnRecDta<cmdGAME_NOTIFY_ROOM_KICKOUT> dlg)
		{
			OnGameRoomKickOut = dlg;
			GameRoomKickOut (uid);
		}
		public void GameRoomKickOut(UInt32 uid)
		{
			cmdGAME_REQUEST_ROOM_KICKOUT pk = new cmdGAME_REQUEST_ROOM_KICKOUT();
			pk.uid = uid;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_KICKOUT, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}


		public void GameMapSelect(byte mapNum,OnRecDta<cmdGAME_NOTIFY_ROOM_MAPSELECT> dlg)
		{
			OnGameRoomMapSelect = dlg;
			GameMapSelect (mapNum);
		}
		public void GameMapSelect(byte mapNum)
		{
			cmdGAME_REQUEST_ROOM_MAPSELECT pk = new cmdGAME_REQUEST_ROOM_MAPSELECT();
			pk.mapNum = mapNum;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_MAPSELECT, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameStartCount(byte byAutoStart,OnRecDta<cmdGAME_ANSWER_GAME_START_COUNT> dlg)
		{
			OnGameStartCount = dlg;
			GameStartCount (byAutoStart);	
		}
		public void GameStartCount(byte byAutoStart)
		{
			cmdGAME_REQUEST_GAME_START_COUNT pk = new cmdGAME_REQUEST_GAME_START_COUNT();
			pk.byAutoStart = byAutoStart;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_START_COUNT, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameStopCount(byte byStop,OnRecDta<cmdGAME_NOTIFY_GAME_STOP_COUNT> dlg)
		{
			OnGameNotifyStopCount = dlg;
			GameStopCount (byStop);
		}
		public void GameStopCount(byte byStop)
		{
			cmdGAME_REQUEST_GAME_STOP_COUNT	pk = new cmdGAME_REQUEST_GAME_STOP_COUNT();
			pk.byStop = byStop;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_COUNT_STOP, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameRoomStart(OnRecDta<cmdGAME_ANSWER_ROOM_START> dlg)
		{
			OnGameRoomStart = dlg;
			GameRoomStart ();
		}
		public void GameRoomStart()
		{
			cmdGAME_REQUEST_ROOM_START	pk = new cmdGAME_REQUEST_ROOM_START();

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_ROOM_START, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}


		public void GameLoadingReady()
		{
			cmdGAME_REQUEST_GAME_LOADING_READY pk = new cmdGAME_REQUEST_GAME_LOADING_READY();

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_LOADING_READY, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameLoadingProgressVal(short val)
		{
			cmdGAME_REQUEST_GAME_LOADING_PROGRESS_VALUE pk = new cmdGAME_REQUEST_GAME_LOADING_PROGRESS_VALUE();
			pk.val = val;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_LOADING_PROGRESS_VALUE, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameRequestLoaded()
		{
			cmdGAME_REQUEST_GAME_LOADED pk = new cmdGAME_REQUEST_GAME_LOADED ();

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_LOADED, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameRequestGamePassZone(float x,float y,float z,Int32 passzone_id)
		{
			cmdGameRequestGamePassZone pk = new cmdGameRequestGamePassZone ();
			pk.x = x;
			pk.y = y;
			pk.z = z;
			pk.passzone_id = passzone_id;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_PASSZONE, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameRequestSkill(short type,short sp,short judge,short dir,byte skill_type)
		{
			cmdGAME_REQUEST_SKILL pk = new cmdGAME_REQUEST_SKILL ();
			pk.type = type; 				// 0&3 : 一次性, 1: 开始, 2:结束
			pk.sp = sp; 					// 最终SP（这个值只在type是2时使用）
			pk.judge = judge; 				//传送判定结果(参考SkillGradeDef)
			pk.dir = dir; 					//方向(参考SkillExtensionDef)
			pk.skill_type = skill_type; 	// 使用了哪些技能

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_SKILL, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameRequestGameSetMaxCombo(char max_combo_step,byte byUserItem,byte bIsPerfect)
		{
			cmdGameRequestGameSetMaxCombo pk = new cmdGameRequestGameSetMaxCombo ();
			pk.max_combo_step = max_combo_step; 	// (0 ~ 5)
			pk.byUserItem = byUserItem; 			// 0 : 技术 , 1 : 物品（没有实际的用处）
			pk.bIsPerfect = bIsPerfect; 			//[true（正常完美跳跃）false（非正常完美跳跃）] //没有实际的用处	

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_SET_MAX_COMBO, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameRequestGameEventObject(UInt32 managerHandle,UInt32 eventObjectHandle,UInt32 eventUnitHandle,UInt32 eventHandle)
		{
			cmdGameRequestGameEventObject pk = new cmdGameRequestGameEventObject ();
			pk.managerHandle = managerHandle; 			// 当前地图（包含路径）的hash值与固定值异或后的值
			pk.eventObjectHandle = eventObjectHandle; 	// EventObject节点的hash值
			pk.eventUnitHandle = eventUnitHandle; 		// 当前位置的事件（包含路径）的hash值与固定值异或后的值
			pk.eventHandle = eventHandle; 			    // 当前位置的事件（包含路径）的hash值与固定值异或后的值

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_EVENTOBJECT, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameRequestSPUse(Int16  type,Int16  sp)
		{
			cmdGAME_REQUEST_SPUSE pk = new cmdGAME_REQUEST_SPUSE ();
			// type
			// 0 : STRIKEATTACK
			// 1 : sp 使用开始(dash start减少量有)
			// 2 : sp 使用结束
			// 3 : 只在服务器里使用
			// 4 : sp 使用重新开始(dash start减少量无)
			pk.type = type;
			pk.sp = sp; 		// 最终SP（这个值只在type是2时使用）

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_SPUSE, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void  GameRequestCheckPoint(Int32 check_point)
		{
			cmdGameRequestGameCheckPoint pk = new cmdGameRequestGameCheckPoint ();
			pk.check_point = check_point;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_CHECKPOINT, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameUserInputStatusStop(UInt32 uiItemindex)
		{
			cmdGAME_REQUEST_USER_INPUT_STATUS_STOP pk = new cmdGAME_REQUEST_USER_INPUT_STATUS_STOP ();
			pk.uiItemindex = uiItemindex;

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_USER_INPUT_STATUS_STOP, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}


		public void GameRequestGoalIn(Int32 gameKey)
		{
			cmdGAME_REQUEST_GAME_GOALIN pk = new cmdGAME_REQUEST_GAME_GOALIN ();
			pk.gameKey = gameKey;		// 游戏密码

			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eLOBBY_REQUEST.GAME_REQUEST_GAME_GOALIN, pk);
			Send((Byte)ServerType.SERVER_GAME, obj);
		}

		public void GameEchoPosition(UInt32 uid,Vector3 pos,Vector3 velocity,float zRotSpeed,float zRotAng,float speed)
		{
			cmdRELAY_ECHO_POSITION pk = new cmdRELAY_ECHO_POSITION ();

			pk.cmdId = (short)Lobby.eRELAY_ECHO.RELAY_ECHO_POSITION;
			pk.uid = uid;

			pk.pos_x = pos.x;
			pk.pos_y = pos.y;
			pk.pos_z = pos.z;
			 
			#if _NEW_PROUD_CHAR_MOVE_
			pk.velocity_x = velocity.x;
			pk.velocity_y = velocity.y;
			pk.velocity_z = velocity.z;
			pk.zRotSpeed = zRotSpeed;
			#endif
			
			pk.zRotAng = zRotAng;
			pk.speed = speed;
			
			CPacket obj = Serialize.SerializePacket((ushort)Lobby.eRELAY_ECHO.RELAY_ECHO_POSITION, pk);

			Send((Byte)ServerType.SERVER_GAME, obj);
			//
			SendbyP2P(obj);
		}


	}
}

 