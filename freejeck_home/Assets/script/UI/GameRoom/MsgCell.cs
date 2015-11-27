using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Cmdlib;
using Common;
namespace com.iuixi.FreeJeck
{
	public class MsgCell : TableCell<cmdGAME_NOTIFY_ROOM_JOIN> 
	{

		private Sprite blue;
		private Sprite gray;
		private Sprite master;
		private Sprite ready;
		private RoomModel roommodel;
//		private Text[] Myname=new Text[8];
//		private Image[] Color=new Image[8];
//		private Image[] Master=new Image[8];
		// Use this for initialization
		void  Awake(){
			blue=Resources.Load<Sprite>("ui/blue");
			gray=Resources.Load<Sprite>("ui/gray");
			master=Resources.Load<Sprite>("ui/master");
			ready=Resources.Load<Sprite>("ui/ready");
			roommodel=Singletons.GET<RoomModel>();
//			for(int j=0;j<8;j++)
//			{
//				Myname[j]=GameObject.Find("myname"+j).GetComponent<Text>();
//				Master[j]=GameObject.Find("master"+j).GetComponent<Image>();
//				Color[j]=GameObject.Find("color"+j).GetComponent<Image>();
//			}
		}
		void Start () {
		

		}
		override public void Render (cmdGAME_NOTIFY_ROOM_JOIN data)
		{
			transform.FindChild ("myname").GetComponent<Text>().text=Tools.Readchar(data.nickname);
					
			if(data.roomMaster==1)
			{	
				transform.FindChild ("master").GetComponent<Image>().sprite=master;
			}
			else if(data.roomMaster==0)
			{
				transform.FindChild ("master").GetComponent<Image>().sprite=ready;
			}
			
					
			if(data.uid==roommodel.GARJ_RoomJoin.uid)
			{
				transform.FindChild ("color").GetComponent<Image>().sprite=blue;
			}
			else
			{
				transform.FindChild("color").GetComponent<Image>().sprite=gray;

			}

		}
//		public void Render (cmdGAME_NOTIFY_ROOM_JOIN data,int i)
//		{
//			Myname[i].text=Tools.Readchar(data.nickname);
//		
//			if(data.roomMaster==1)
//			{	
//				Master[i].sprite=master;
//			}
//			else if(data.roomMaster==0)
//			{
//				Master[i].sprite=ready;
//			}
//
//		
//			if(data.uid==(ushort)roommodel.GARJ_RoomJoin.uid)
//			{
//				Color[i].sprite=blue;
//			}
//			else
//			{
//				Color[i].sprite=gray;
//			}
//		}

		// Update is called once per frame
		void Update () {
		
		}
	}
}