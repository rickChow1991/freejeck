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
	
	
	public class MsgGrid : NameGrid<cmdGAME_NOTIFY_ROOM_JOIN,MsgCell> 
	{
		private RoomModel roommodel;
		void Start(){
			roommodel=Singletons.GET<RoomModel>();
			InitCells();
		}
		void Update(){
             //SetDataProvider(roommodel.Msg);
		}
	
	}
}