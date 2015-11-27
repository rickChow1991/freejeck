#define _MODIFY_PASSWORD
#define _MAPTABLE_RENEWAL
#define _CHAT_ROOM_
//#define _AUDIENCE_MODE_
#define _EVENTOBJECT_CHANGE
#define _TEAM_MAXBOOSTER 
#define _NEW_PROUD_CHAR_MOVE_

using Command;
using Common;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Cmdlib
{
	[Serializable]
	public class cmdLOGIN_REQUEST_CONNECT_AUTH
	{
		public byte[] szVersionInfo = new byte[Constant.MAX_VERSION_INFO_LEN + 1];
       
	}

	public class cmdLOGIN_ANSWER_CONNECT_AUTH : cs_ACK
	{     
	}

	[Serializable]
	public  class cmdLOGIN_REQUEST_LOGIN_AUTH
	{
		public char[] login_name = new char[Constant.MAX_LOGIN_NAME_LEN + 1];
		public char[] password = new char[Constant.MAX_PASSWORD_LEN + 1];
	}

	public  class cmdLOGIN_ANSWER_LOGIN_AUTH : cs_ACK
	{
		public char[] login_name = new char[Constant.MAX_LOGIN_NAME_LEN + 1];
		public string auth_key = new string (new char[Constant.MAX_AUTH_LEN]);
		public uint security_key;
		public byte warning;
		public string ip = new string (new char[Constant.MAX_IP_ADDRESS_LEN + 1]);
		public ushort port;
		public ushort gameSrvPort;
	}

	[Serializable]
	public class cmdGAME_REQUEST_CONNECT_AUTH
	{
	}

	public class cmdGAME_ANSWER_CONNECT_AUTH:cs_ACK
	{		
	}

	[Serializable]
	public class cmdGAME_REQUEST_LOGIN_AUTH
	{
		public char[] login_name = new char[Constant.MAX_LOGIN_NAME_LEN + 1];
		public string auth_key = new string (new char[Constant.MAX_AUTH_LEN]);
		public int auth_checksum;
		public byte divisionLv;
		public byte channelNo;
	}

	public class cmdGAME_ANSWER_LOGIN_AUTH:cs_ACK
	{
		public string auth_key = new string (new char[Constant.MAX_AUTH_LEN]);
		public uint security_key;
		public ushort	uid;								
		public ushort	lobbyUid;		
	}

	[Serializable]
	public class cmdGAME_REQUEST_USER_INFO
	{
		public uint security_key; 
	}
		
	public class cmdGAME_ANSWER_USER_INFO : cs_ACK
	{
		public int ukey; 
		public char[] nickname = new char[Constant.MAX_NICKNAME_LEN + 1];
		public byte level;
		public byte avatar_no; 
		public int exp;
		public int money;
		public int tutorial;
		public byte tutorial_try;
		public int[] mission = new int[Constant.MAX_MISSION_CHAPTER];
		public cs_Emblem emblem = new cs_Emblem(); 
		
		public char[] clubname = new char[Constant.MAX_CLUB_NAME_LEN + 1]; 
		public uint clubId; 
		public byte clubEmblemNo; 
		public byte clubSubEmblemNo; 
		public byte guide_number; 

		public int achievement_point;
		public int achievement_total;
		public byte bySex;
		public byte byItemModeClick;
		
		public string Privilege = new string(new char[4]); //0:无特权 1:有特权 0-3位置:美眉特权,公会,媒体,网吧
		public int[] PrivilegePercent = new int[3]; //0-2:经验比例 金钱比例 商城折扣

	}

	[Serializable]
	public class cmdGAME_REQUEST_MYHOUSINGITEM_LIST
	{
	}

	public class cmdGAME_ANSWER_MYHOUSINGITEM_LIST : cs_ACK
	{
		public int cnt;
		public cs_HousingItemInfo[]	housingitems=new cs_HousingItemInfo[100];	// 每次最多100个	
	}

	public class  CmdGameAnswerCashInfo : cs_ACK 
	{
		public	long cash;  //MB信息，要充值才能获得
	}


	[Serializable]
	public class cmdGAME_REQUEST_CHAR_INFO
	{
		public byte	 avatar;		// avatar号码
	}

	public class cmdGAME_ANSWER_CHAR_INFO : cs_ACK
	{
		public	cs_CharInfo info=new cs_CharInfo();		// 角色信息
		public	cs_ItemInfo[] equips=new cs_ItemInfo[Constant.MAX_EQUIP_SLOT];	// 佩戴物品信息 MAX_EQUIP_SLOT = 11
	}


	public class  cmdGAME_NOTIFY_GIFT_NEW
	{
	}

	public class cmdMSG_NOTIFY_CLUB_AUTHLEVEL_NAME
	{
		public char[,] arrAuthLevelStr = new char[Constant.MAX_CLUB_AUTHLEVEL, Constant.MAX_CLUB_AUTHLEVEL_LEN + 1];
	}

	[Serializable]
	public class cmdGAME_REQUEST_ABILITY_CARD_STAT
	{
	}

	public class cmdGAME_ANSWER_ABILITY_CARD_STAT : cs_ACK
	{
		public byte[] cardStat = new byte[Constant.MAX_ABILITY_CARD_TYPE];
	}

	[Serializable]
	public class cmdGAME_REQUEST_MYITEM_LIST
	{
	}

	public class cmdGAME_ANSWER_MYITEM_LIST : cs_ACK
	{
		public int cnt; //数量
		public  cs_ShopItemInfo[] shopitems=new cs_ShopItemInfo[50];	// 每次最多50个
	}

	//返回大厅
	[Serializable]
	public class cmdGAME_REQUEST_ENTER_LOBBY
	{
	}

	public class cmdGAME_ANSWER_ENTER_LOBBY :cs_ACK
	{
	}

	[Serializable]
	public class  cmdGAME_PING_INFO
	{
	}

	//事件列表
	[Serializable]
	public class  cmdGAME_REQUEST_EVENT_LIST
	{
	}

	public class cmdGAME_ANSWER_EVENT_LIST
	{
		public byte cnt; //事件总量
		public List<cs_EVENT> events = new List<cs_EVENT>();
	}

	//房间列表
	[Serializable]
	public class  cmdGAME_REQUEST_ROOM_LIST
	{
		public byte pageType;		//页面类型(参考eROOM_PAGE_TYPE)
		public byte matchViewType;	//比赛类型(参考eMATCH_VIEW_TYPE)
		public byte roomViewType;	//房间类型(参考eROOM_VIEW_TYPE)
	}
	
	public class cmdGAME_ANSWER_ROOM_LIST :cs_ACK
	{
	}

	//更新显示的房间列表的页码
	public class cmdGameNotifyRoomListPage
	{
		public byte nPageNo; //当前房间页码 
	}

	//添加房间目录
	public class cmdGameNotifyRoomListAdd
	{
		public	cs_RoomInfo info=new cs_RoomInfo();		// 房间信息 
	}

	//删除房间目录
	public class cmdGameNotifyRoomListDel
	{
		public	short roomNo;		// 房间号码 
	}

	//房间目录更新
	public class cmdGameNotifyRoomListUpdate
	{
		public	cs_RoomInfo info=new cs_RoomInfo();		// 房间信息 
	}

	//快速开始
	[Serializable]
	public class cmdGameRequestRoomQuickJoin
	{
		public	byte mode;		// 比赛模式(参考eMATCH_MODE) 
	}

	public class cmdGameAnswerRoomQuickJoin :cs_ACK
	{
		public	cs_RoomInfo info=new cs_RoomInfo();		// 房间信息 
	}

	//在lobby服务器创建房间
	[Serializable]
	public class cmdGameRequestRoomCreate
	{
		public char[] name = new char[Constant.MAX_ROOM_NAME_LEN + 1]; //房间名字
		public char[] password = new char[Constant.MAX_ROOM_PASSWORD_LEN + 1]; //房间密码
		public	byte mapNum;		// 地图ID
		public	byte mode;			// 比赛模式(参考eMATCH_MODE)
		public	byte mapLaps;		// 圈数
		public	byte maxJoinerNum;	// 比赛模式(参考eMATCH_MODE)
		public	bool StrikeAttack;	// 是否开启碰撞
	}
	
	public class cmdGameAnswerRoomCreate :cs_ACK
	{
		public	short roomNo;		// 房间号码 
		public  char[] name = new char[Constant.MAX_ROOM_NAME_LEN + 1]; //房间名字
		public	byte password;		// 房间是否有密码(1:有房间密码)
		public	byte mapNum;		// 地图ID
		public	byte mode;			// 比赛模式(参考eMATCH_MODE)
		public	byte mapLaps;		// 圈数
		public	byte maxJoinerNum;	// 最大可进入的人

		public	Int32 gameKey;	
		public	string ip = new string (new char[Constant.MAX_IP_ADDRESS_LEN + 1]); //IP地址
		public	Int32 gameSrvRoomNo;// 游戏服务器里面的房间

#if _MODIFY_PASSWORD
		public char[] password_info = new char[Constant.MAX_ROOM_PASSWORD_LEN + 1]; //房间密码
		public UInt16  usGamePort;	//游戏服务器端口
#endif

	}

	//在游戏服务器请求进入房间
	[Serializable]
	public class cmdGameRequestCreateGame_GameSrv
	{
		public	byte mode;			// 比赛模式(参考eMATCH_MODE)
		public	Int32 roomNo;		// 比赛模式(参考eMATCH_MODE)
		public	Int32 gameKey;	
		public	UInt32 lobbyUserId;// 游戏服务器里面的房间 (从cmdGAME_ANSWER_LOGIN_AUTH中获取)
		public	UInt32 lobbySrvId;// 游戏服务器里面的房间 (从cmdGAME_ANSWER_LOGIN_AUTH中获取)
	}

	public class cmdGAME_ANSWER_ROOM_JOIN :cs_ACK
	{
		public	short roomNo;		// 房间号码
		public  char[] name = new char[Constant.MAX_ROOM_NAME_LEN + 1]; //房间名字
		public	byte password;		// 房间是否有密码(1:有房间密码)
		public	byte mode;			// 比赛模式(参考eMATCH_MODE)
		public	byte mapNum;		// 地图ID
		public	byte playerIndex;	// playr位置号码
		public	byte teamcolor;		// 团队(参考eTEAM_COLOR )
		public  int[] arrHousingItems = new int[Constant.MAX_HOUSINGITEM_SLOT];

		public	byte mapLaps;		// 圈数
		public	byte maxJoinerNum;	// 最大可进入的人
		public  UInt16  uid;			//用户ID
		public  byte isRoomMaster;	//是不是房主
		public  byte bStrikeAttack;	// 可不可以碰撞
		public  byte byWarning;		//等级低的玩家连接等级高的玩家的房间【0：同级的表示×，1：等级高的房间很危险表示0】
		
	#if _MAPTABLE_RENEWAL
		public byte  byLevelType;	//等级类型
	#endif

	#if _CHAT_ROOM_
		public byte  age;			//年龄段
		public byte  chatmode;		//聊天模式
		public byte  region;		//地域
		public byte  JoinGender;	//性别

		public byte  byManNum;		//男性的数量
		public byte  byGirlNum;		//女性的数量
	#endif

	#if _AUDIENCE_MODE_
		public bool  isAudience;	//是不是旁观
		public byte  byAudienceNum;	//旁观人数
	#endif
		
	}

	//若进入房间的人是房主的话，进入房间之后立即发送准备OK的请求，若进入房间的人不是房主的话，要等到收到GAME_ANSWER_ROOM_JOIN消息之后发送准备OK的请求
	[Serializable]
	public class cmdGAME_REQUEST_ROOM_READY
	{
		public	byte byReady;			// 是否就绪
	}

	public class cmdGAME_NOTIFY_ROOM_READY
	{
		public UInt16  uid;			//已准备的玩家ID/游戏中的玩家ID
		public byte state;			// 准备状态（1：准备完毕，0：未准备）
	}

	//加载游戏房间大厅的成员
	[Serializable]
	public class cmdGameRequestGameLobbyMembers
	{
	}
	
	public class cmdGAME_NOTIFY_ROOM_JOIN
	{
		public UInt16 uid;			// 玩家ID
		public Int32  ukey;			// 玩家原有号码(db key)
		public byte playerIndex;	// playr位置号码
		public char[] nickname = new char[Constant.MAX_CHAR_NAME_LEN + 1]; //角色名

		public byte avatarNo;		// avatar(0~)	
		public byte skincolor;		// 皮肤色

		public Int32  faceIndex;	// 脸部索引
		public Int32  hair;			// 头发
		public Int32  upper;		// 上装
		public Int32  lower;		// 下装
		public Int32  shoes;		// 鞋子

		public byte level;			// 等级	
		public short emblemNo;		// 所属的Eemblem号码
		public byte ready;			// 准备状态（1：准备完毕，0：未准备）	
		public byte roomMaster;		// 房主（1：房主）
		public byte teamcolor;		// 团队(参考eTEAM_COLOR )	

		public char[] clubname = new char[Constant.MAX_CLUB_NAME_LEN + 1]; //CLUB名称
		public UInt32 clubId;		// CLUB ID		
		public byte clubEmblemNo;	// CLUB emblem	
		public byte clubSubEmblemNo;// CLUB派生 emblem
		public byte enteredUser;	// 新进入的玩家

		public cs_ItemInfo[] equips=new cs_ItemInfo[Constant.MAX_EQUIP_SLOT];	// 佩戴物品信息 MAX_EQUIP_SLOT = 11 
		public byte bySex;			// 性别
		public string Privilege = new string(new char[4]); //0:无特权 1:有特权 0-3位置:美眉特权,公会,媒体,网吧

	}

	//游戏房间最多入场人数变更请求
	[Serializable]
	public class cmdGameRequestRoomMaxJoinerNumChange
	{
		public byte maxJoinerNum;		// 最大人数	
	}

	public class cmdGameNotifyRoomMaxJoinerNumChange
	{
		public byte maxJoinerNum;		// 最大人数	
	}

	//在房间里面设置房间信息
	[Serializable]
	public class cmdGAME_REQUEST_ROOM_SETTING
	{
		public char[] name = new char[Constant.MAX_ROOM_NAME_LEN + 1]; //房间名
		public char[] password = new char[Constant.MAX_ROOM_PASSWORD_LEN + 1]; //房间密码
	}
	
	public class cmdGAME_NOTIFY_ROOM_SETTING
	{
		public char[] name = new char[Constant.MAX_ROOM_NAME_LEN + 1]; //房间名
		public char[] password = new char[Constant.MAX_ROOM_PASSWORD_LEN + 1]; //房间密码
	}


	//在房间里面变更碰撞设置
	[Serializable]
	public class cmdGameRequestRoomStrikeAttackInfoChange
	{
		public bool bStrikeAttack;		//是否开启碰撞	
	}
	
	public class cmdGameNotiRoomStrikeAttackInfoChange
	{
		public byte bStrikeAttack;		//是否开启碰撞	
	}

	//变换游戏模式
	[Serializable]
	public class cmdGAME_REQUEST_MODE_SELECT
	{
		public byte mode;				//游戏模式(参考eGAME_MODE )	
	}
	
	public class cmdGAME_ANSWER_MODE_SELECT :cs_ACK
	{
		public byte mode;				//游戏模式(参考eGAME_MODE )		
	}

	//玩家离开房间
	public class cmdGAME_NOTIFY_ROOM_LEAVE
	{
		public UInt16 leave_uid;		//退出的玩家ID/游戏中的玩家ID	
		public UInt16 roomMaster_uid;	//接替房主位置的玩家ID	
	}
	
	//请求加入房间 相应的回复为cmdGAME_ANSWER_ROOM_JOIN
	[Serializable]
	public class cmdGAME_REQUEST_ROOM_JOIN
	{
		public short roomNo;			//房间号码	
		public char[] password = new char[Constant.MAX_ROOM_PASSWORD_LEN + 1]; //房间密码
		public byte mode;				//游戏模式(参考eGAME_MODE )	
		public UInt32 lobbyUserId;		//	
		public UInt32 lobbySrvId;	//接替房主位置的玩家ID	
	}

	//交换队伍
	[Serializable]
	public class cmdGAME_REQUEST_ROOM_TEAMCHANGE
	{
		public UInt32 uid;				//要换团队的玩家（比赛）玩家的ID，如果是本人的情况就是自己的ID，是房主的情况就是要换队的玩家ID	
	}
	
	public class cmdGAME_NOTIFY_ROOM_TEAMCHANGE
	{
		public UInt32 uid;				//交换的玩家（比赛）的玩家ID
		public byte teamcolor;			//游戏模式(参考eTEAM_COLOR )		
	}

	//通知更换房间装修物品
	public class cmdGameNotifyHousingItemChange
	{
		public int[] arrHousings=new int[Constant.MAX_HOUSINGITEM_SLOT];	// 房间的装饰物品 
	}

	//踢出房间
	[Serializable]
	public class cmdGAME_REQUEST_ROOM_KICKOUT
	{
		public UInt32 uid;				//强退的玩家ID/游戏中的玩家ID 
	}

	public class cmdGAME_NOTIFY_ROOM_KICKOUT
	{
		public UInt32 uid;				//强退的玩家ID/游戏中的玩家ID 
	}


	//选择地图
	[Serializable]
	public class cmdGAME_REQUEST_ROOM_MAPSELECT
	{
		public byte mapNum;				//地图ID	
	}
	
	public class cmdGAME_NOTIFY_ROOM_MAPSELECT
	{
		public byte mapNum;				//地图ID
		public byte mapLaps;			//圈数		
	}


	//比赛相关的协议
	//游戏开始倒计时请求(房主才有的权限)
	public class cmdGAME_REQUEST_GAME_START_COUNT
	{
		public byte byAutoStart;		//是否自动开发 0表示否 1表示是
	}

	//游戏开始倒计时应答
	public class cmdGAME_ANSWER_GAME_START_COUNT :cs_ACK
	{
	}

	//游戏开始倒计时通知
	public class cmdGAME_NOTIFY_GAME_START_COUNT
	{
		public byte byAutoStart;		//是否自动开发 0表示否 1表示是
	}

	//取消游戏倒计时请求(房主才有的权限)
	public class cmdGAME_REQUEST_GAME_STOP_COUNT
	{
		public byte byStop; 			//是否取消游戏倒计时 0表示否 1表示是
	}

	//取消游戏倒计时通知
	public class cmdGAME_NOTIFY_GAME_STOP_COUNT
	{
		public byte byStop; 			//是否取消游戏倒计时 0表示否 1表示是
	}

	//在房间里开始游戏请求(房主才有的权限)
	public class cmdGAME_REQUEST_ROOM_START
	{
	}

	//在房间里开始游戏应答
	public class cmdGAME_ANSWER_ROOM_START :cs_ACK
	{
	}

	//通知玩家转换到准备画面
	public class cmdGAME_NOTIFY_GAME_LOADING_WAIT
	{
	}

	//客户端做好转换到游戏准备画面，提示给服务器
	public class cmdGAME_REQUEST_GAME_LOADING_READY
	{
	}

	//通知玩家在房间里开始游戏
	public class cmdGAME_NOTIFY_ROOM_START
	{
		public byte mapNo; 			//地图ID
		public byte mapLaps; 		//地图圈数
		public Int32 startPos; 		//位置信息相关，有具体算法构成

	#if _EVENTOBJECT_CHANGE
		public UInt32  seed; 		//当前服务器的时间值，客户端暂时未用此值
	#endif
	}

	//进入赛场时资源加载进度条的值
	public class cmdGAME_REQUEST_GAME_LOADING_PROGRESS_VALUE
	{
		public short val;  			//进度条的数值（0~100）
	}

	//通知玩家其他玩家的加载进度情况
	public class cmdGAME_NOTIFY_GAME_LOADING_PROGRESS_VALUE
	{
		public UInt16 uid; 			//游戏(用于比赛)服务器内部分配的玩家索引
		public short val;  			//进度条的数值（0~100）
	}

	//加载资源完毕
	public class cmdGAME_REQUEST_GAME_LOADED
	{
	}

	//把某个玩家的资源加载完毕消息广播给所以玩家
	public class cmdGAME_NOTIFY_GAME_LOADED
	{
		public UInt16 uid;			// 登陆的玩家(玩家)的UID
	}

	//通知所有人准备完毕
	public class cmdGAME_NOTIFY_GAME_LOADING_END
	{
	}

	//告诉服务器通过终点时的位置
	public class cmdGameRequestGamePassZone
	{
		public float x;
		public float y;
		public float z;
		public Int32 passzone_id; //区域
	}

	//比赛开发通知
	public class cmdGAME_NOTIFY_GAME_START :cs_TimeStamp
	{
	}

	//使用技能请求
	// 使用技能时需要传送判定结果和方向(LUST, RAPID) :获得sp以及特殊技术GAGE值
	public class cmdGAME_REQUEST_SKILL 
	{
		public short type; 			// 0&3 : 一次性, 1: 开始, 2:结束
		public short sp; 			// 最终SP（这个值只在type是2时使用）
		public short judge; 		//传送判定结果(参考SkillGradeDef)
		public short dir; 			//方向(参考SkillExtensionDef)
		public byte skill_type; 	// 使用了哪些技能
	}

	//SP变更信息
	public class cmdGAME_NOTIFY_GAME_SP_CHANGE
	{
		public Int32 delta; 	//增量值，有正负之分
	}

	//在游戏中设置max-combo
	public class cmdGameRequestGameSetMaxCombo 
	{
		public char max_combo_step; // (0 ~ 5)
		public byte byUserItem; 	// 0 : 技术 , 1 : 物品（没有实际的用处）
		public byte bIsPerfect; 	//[true（正常完美跳跃）false（非正常完美跳跃）] //没有实际的用处	
	}

	//广播max-combo
	public class cmdGameNotifyMaxComboUser
	{
		public Int32 uid; 			// 对应玩家
		public byte max_combo; 		// ture的话就是maxcombo,false的话就是maxcombo解除
		// 维持时间[是max_combo true 的时候添加]
		public double dEndTime;
	}

	//获得事件对象
	public class cmdGameRequestGameEventObject
	{
		public UInt32 managerHandle; 		// 当前地图（包含路径）的hash值与固定值异或后的值
		public UInt32 eventObjectHandle; 	// EventObject节点的hash值
		public UInt32 eventUnitHandle; 		// 当前位置的事件（包含路径）的hash值与固定值异或后的值
		public UInt32 eventHandle; 			// 当前位置的事件（包含路径）的hash值与固定值异或后的值
	}

	//广播玩家获得的事件对象消息
	public class cmdGameNotifyGameEventObject
	{
		public Int32 uid; 					// 游戏(用于比赛)服务器内部分配的玩家索引
		public UInt32 managerHandle; 		// 当前地图（包含路径）的hash值与固定值异或后的值
		public UInt32 eventObjectHandle; 	// EventObject节点的hash值
		public UInt32 eventUnitHandle; 		// 当前位置的事件（包含路径）的hash值与固定值异或后的值
		public UInt32 eventHandle; 			// 当前位置的事件（包含路径）的hash值与固定值异或后的值
	}

	//SP的使用(只在使用sp时发送.) 回复cmdGAME_NOTIFY_GAME_SP_CHANGE
	public class cmdGAME_REQUEST_SPUSE
	{
		// type
		// 0 : STRIKEATTACK
		// 1 : sp 使用开始(dash start减少量有)
		// 2 : sp 使用结束
		// 3 : 只在服务器里使用
		// 4 : sp 使用重新开始(dash start减少量无)
		public Int16  type;
		public Int16  sp; 		// 最终SP（这个值只在type是2时使用）
	}

	//设置成服务器sp 
	public class cmdGameAnswerServerSp
	{
		public Int32 nSp;		// 服务器里的sp
	}

	//游戏时检查wdr确认点数
	public class cmdGameRequestGameCheckPoint
	{
		public Int32 check_point;
	}
	
	//checkpoint提示
	public class cmdGAME_NOTIFY_GAME_CHECKPOINT :cs_TimeStamp
	{
		public UInt16 uid;			// 玩家ID(玩家原有号码)
		public byte checkpointA;	// 关口A
		public byte checkpointB;	// 关口B
	}

	//玩家状态开始
	public class cmdGAME_NOTIFY_GAME_STATUS_START
	{
		public UInt16 usUserID;
		public byte byStatusCount; //按照个数添加cmdStatus_Info 构造体
		//可变数据包
		public List<cmdStatus_Info> events = new List<cmdStatus_Info>();
	}
	
	
	//玩家点击按键解除特定道具的状态
	//玩家key输入状态强制解除【客户端->服务器】
	public class cmdGAME_REQUEST_USER_INPUT_STATUS_STOP
	{
		public UInt32 uiItemindex;		//
	}
	
	
	//广播游戏状态结束
	public class cmdGAME_NOTIFY_GAME_STATUS_STOP
	{
		public UInt16 usUserID;
		public byte byStatusCount; //按照个数添加cmdStatus_Info 构造体
		//可变数据包
		public List<cmdStatus_Info> events = new List<cmdStatus_Info>();
	}

	//发送GOALIN请求
	public class cmdGAME_REQUEST_GAME_GOALIN
	{
		public Int32 gameKey;		// 游戏密码
	}
	
	//广播GOALIN消息（终点）
	public class cmdGAME_NOTIFY_GAME_GOALIN :cs_TimeStamp
	{
		public UInt32 uid;			// 已GOALIN的玩家ID
		public cs_Time lapTime = new cs_Time();			// 
		public byte rank;			// 排名(1~)
	}
	
	
	//比赛结束通知
	public class cmdGAME_NOTIFY_GAME_FINISH :cs_TimeStamp
	{
		public byte retire;			//是否撤退(1:撤退) 
	}
	
	
	//处理比赛结果
	public class cmdGAME_NOTIFY_GAME_RESULT
	{
		#if _TEAM_MAXBOOSTER
		public Int16 GreenMvpUID;   //绿队的MVP
		public Int16 RedMvpUID;		//红队的MVP
		#endif
		
		public cs_Time	worldRecord = new cs_Time();		// 世界记录
		public cs_Time	personalRecord = new cs_Time();		// 个人记录
		public byte newWorldRecord;		// 世界记录更新(1：更新)
		public byte newPersonalRecord;	// 个人记录更新(1：更新)
		public byte winningTeam;		// 胜利团队(0:个人战, 1:绿色团队, 2:红色团队, 参考eTEAM_COLOR , 团队战时所用)
		public Int16 cp_green;			// CLUB战时获得的cp(绿色团队)
		public Int16 cp_red;			// CLUB战时获得的cp(红色团队)
		
		public UInt16 count;			// 结果个数(玩家数)
		public cs_Result[] results = new cs_Result[Constant.MAX_PLAYERS]; 	// 结果信息
	}


	//同步位置信息 RELAY_ECHO_POSITION
	public class cmdRELAY_ECHO_POSITION
	{
		public short cmdId;
		public UInt32 uid;
		public float pos_x;
		public float pos_y;
		public float pos_z;

		#if _NEW_PROUD_CHAR_MOVE_
		public float velocity_x;
		public float velocity_y;
		public float velocity_z;
		public float zRotSpeed;
		#endif

		public float zRotAng;
		public float speed;
	}




}

