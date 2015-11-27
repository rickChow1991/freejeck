using System;
using System.Collections;
using System.Collections.Generic;
using Cmdlib;
using UnityEngine;
using Common;
using Command;
using System.IO;
using System.Text;
namespace com.iuixi.FreeJeck
{
	public class RoomModel{
		//创建房间的信息
		public cmdGameAnswerRoomCreate     GARC_RoomCreat;
		//事件信息
		public cmdGAME_ANSWER_EVENT_LIST   GAEL_EventList;
		//房间当前页数
		public cmdGameNotifyRoomListPage   GNRLG_Page;
		//加入游戏房间后返回的数据
		public cmdGAME_ANSWER_ROOM_JOIN    GARJ_RoomJoin;
		//在游戏房间中的状态
		public cmdGAME_NOTIFY_ROOM_READY   GNRR_RoomReady;
		//有人加入游戏房间的通知
		public List<cmdGAME_NOTIFY_ROOM_JOIN>   GNRJ_RoomJoin=new List<cmdGAME_NOTIFY_ROOM_JOIN>();
		//更新房间
		public List<cs_RoomInfo> UpdatedRoom=new List<cs_RoomInfo>();
		//快速加入某个房间后的房间信息
		public cmdGameAnswerRoomQuickJoin  GARQJ_RoomQuickJoin;
		//房间动态数组
		public List<cs_RoomInfo> RoomInfo=new List<cs_RoomInfo>() ;
		public cmdGAME_ANSWER_MODE_SELECT  GAMS_ModeSelect;
		//删除房间
		public List<short>    RoomListDel=new List<short>(); 
		public List<cmdGAME_NOTIFY_ROOM_JOIN> Msg=new List<cmdGAME_NOTIFY_ROOM_JOIN>();

		/*private Dictionary<eMATCH_MODE, List<cs_RoomInfo>> ModelOfRoom=new Dictionary<eMATCH_MODE, List<cs_RoomInfo>>();

		public List<cs_RoomInfo> GetCs_ROOMINFOByModel(eMATCH_MODE c)
		{


			if(ModelOfRoom.ContainsKey(c))
				return ModelOfRoom[c];
			List<cs_RoomInfo> result = new List<cs_RoomInfo>();
			foreach (var item in RoomInfo) {
				if(item.mode ==(byte)c) {
					result.Add(item);
				}
			}
			ModelOfRoom.Add(c, result);
			return result;
		}*/
	} 
}