#define _CHAT_ROOM_
#define _MATCH_POINT
#define _MODIFY_PASSWORD
#define _TEAM_MAXBOOSTER
#define _NEW_REWARD_RESULT
#define _NEW_REWARD_RESULT_V2

using System;
using System.Text;
using Command;

namespace Common
{
	/// <summary>
	/// _ack为1 成功 0:失败  _ack=0时 _eno表示失败原因错误码
	/// </summary>
    public class cs_ACK
    {
		private ushort _ack; 
		private ushort _eno;

		public ushort GetAck()
		{
			return _ack;
		}
		
		public ushort GetEno()
		{
			return _eno;
		}
		
		public void Make(byte ack_code, byte eno_code)
		{
			_ack = ack_code;
			_eno = eno_code;
		}
	
	}

	//游戏模式
	public enum eGAME_MODE:byte
	{
		GAME_MODE_VERSUS = 0,		//大战
		GAME_MODE_TUTORIAL,			//新手引导
		GAME_MODE_TIMEATTACK,		//攻击类型
		GAME_MODE_MISSION,			//任务
		GAME_MODE_TRAINING,			//训练
		GAME_MODE_LAPTIME,			//竞速
	}

	//竞技模式
	public enum eMATCH_MODE:byte
	{
		MATCH_MODE_INDIVIDUAL = 0,	//速度个人战
		MATCH_MODE_TEAM,			//速度团队战
		MATCH_MODE_ITEM_INDIVIDUAL,	//物品个人战
		MATCH_MODE_ITEM_TEAM,		//物品团队战
		MATCH_MODE_CLUB,			//CLUB战
		MATCH_MODE_ITEM_CLUB,		//物品CLUB战
		MATCH_MODE_LAPTIME,			//物品CLUB战
		MATCH_MODE_GOLDENRACE,		//黄金模式
		MATCH_MODE_CHAT,			//聊天模式
		MATCH_MODE_HELL_INDIVIDUAL,	//地狱模式
		MATCH_MODE_HELL_TEAM,		//地狱模式团队战
		MATCH_MODE_MINI_INDIVIDUAL,	//迷你模式
		MATCH_MODE_MINI_TEAM,		//迷你模式团队战

		MATCH_MODE_HELL_CLUB,		//地狱模式CLUB战
		MATCH_MODE_MINI_CLUB,		//迷你模式CLUB战

		MATCH_MODE_ITEM_HIGH_LADDER,//天梯道具
		MATCH_MODE_HIGH_LADDER,		//天梯竞速

		MAX_MATCH_MODE
	}

	//页码类型
	public enum eROOM_PAGE_TYPE:byte
	{
		ROOM_PAGE_TYPE_NONE= 0,		//无,表示第一页
		ROOM_PAGE_TYPE_NEXT,		//下一页
		ROOM_PAGE_TYPE_PREV,		//上一页
	}

	public enum eMATCH_VIEW_TYPE:byte
	{
		MATCH_VIEW_TYPE_SPEED= 0,	//速度赛
		MATCH_VIEW_TYPE_ITEM,		//道具赛
		MATCH_VIEW_TYPE_LAPTIME,	//竞速模式
		MATCH_VIEW_TYPE_GOLDENRACE,	//黄金模式
		MATCH_VIEW_TYPE_CHAT,		//聊天模式
		MATCH_VIEW_TYPE_HELL,		//地狱模式
		MATCH_VIEW_TYPE_MINI,		//迷你模式

		MATCH_VIEW_ITEM_HIGH_LADDER,//天梯道具
		MATCH_VIEW_HIGH_LADDER,		//天梯竞速

		MAX_MATCH_VIEW_TYPE,
		MATCH_VIEW_TYPE_INVALD,		//错误的查看类型
	}

	//房间查看类型
	public enum eROOM_VIEW_TYPE:byte
	{
		ROOM_VIEW_TYPE_ALL= 0,		//查看所以房间
		ROOM_VIEW_TYPE_INDIVIDUAL,	//查看个人战房间
		ROOM_VIEW_TYPE_TEAM,		//查看团队战房间
		ROOM_VIEW_TYPE_CLUB,		//查看CLUB战房间
		ROOM_VIEW_TYPE_CHAT,		//查看聊天房间
		MAX_ROOM_VIEW_TYPE,			
	}

	public enum eTEAM_COLOR
	{
		TEAM_COLOR_NONE= 0,
		TEAM_COLOR_GREEN,				// 队友
		TEAM_COLOR_RED,					// 对手
		#if _TEAM_MAXBOOSTER
		TEAM_COLOR_END
		#endif
	}

	public enum ePlusRewardType
	{
		ePlusRewardType_EXP = 0,
		ePlusRewardType_Jack,
		ePlusRewardType_MAX,
	};
	
	public enum ePlusRewardEffect
	{
		ePlusRewardEffect_Event = 0,//活动
		ePlusRewardEffect_PCBang,	//网吧
		ePlusRewardEffect_Utility,//新手
		ePlusRewardEffect_Char,//妹子
		ePlusRewardEffect_MAX,
	};

	public enum GameEventType 
	{
		GameEventTypeNone = 0,
		GameEventTypeResultReward,
		GameEventTypeGoldenRace,
	};

	public enum SkillGradeDef //判定结果类型
	{
		SKILL_PERFECT = 0,
		SKILL_EXCELLENT,
		SKILL_COOL,
		SKILL_NOTBAD,
		SKILL_MOVE,
		SKILL_MISS,
	};

	public enum SkillExtensionDef  //方向
	{
		SKILL_BASE = 0,
		SKILL_UPPER,
		SKILL_UBER,
	};


	///以后在具体的类结构
	public class cs_Emblem
	{
		public ushort	emblemNo;			
		public int[] cnt=new int[Constant.MAX_EMBLEMS];	
	}

	public class cs_HousingItemInfo
	{
		public int		nIid;		// (DBid) 
		public int		nItemCode;	// 表的ID
		public byte	ucCategory;	// 类型
		public byte	ucIsSet;	// 是否可为放置状态， 0表示非放置状态，1表示放置状态
		public int     nRestMinutes; // 剩余时间
		public byte    nPeriodic; //是否有使用周期1:有 0：无
	}

	public class cs_CharInfo
	{
		public int		cid;		// 角色ID
		public byte	    skincolor;	// 皮肤颜色
		public byte  	avatarno;	// avatar号码
		public int		faceIndex;//表情索引
		public int		hair;//头发索引
		public int		upper;//上装
		public int		lower;//下装
		public int		shoes;//鞋子
		
		//
		public byte	speed; //速度
		public byte	strength;//力量
		public byte	agility;//敏捷
		public byte	technic;//技巧		
	}
	
	public class cs_ItemInfo
	{
		public int		i_no;		// 物品索引
		public int		item_id;	     // 物品id（表中的ID）
		public byte	slot;		// 佩戴位置slot
		public byte	socket_cnt;	//孔的数量
		public byte[]	sockets=new byte[Constant.MAX_SOCKET_NUM];	// MAX_SOCKET_NUM=2 //孔里面的内容
		public short	stock;		// 巢篮荤侩冉荐
		public int		restMinute;	// 剩余时间
		public int		cid;//可佩戴的角色ID 
		public int      utility_id; // 技能ID
	}

	public class cs_ShopItemInfo
	{
		public int i_no; //(dbId)  
		public int cid; // 角色ID  
		public int item_id; // 表ID 
		public byte slot;  // 佩戴位置
		public byte is_wearing; // 穿戴的状态 1:穿戴在身上 0：未穿戴
		public byte socket_cnt;  // 洞的数量
		public byte[] socket=new byte[Constant.MAX_SOCKET_NUM];  //洞的镶嵌的内容
		public ushort stock;  // 巢篮荐樊
		public int  rest_minutes;  // 剩余时间)
		public byte is_periodic;  //是否有使用周期1:有 0：无
		public int utility_id; // 技能ID
		
	}

	public class cs_EVENT
	{
		public byte eventType;	// 事件类型
		public byte isOpened;	// 是否开放
	}
	
	public class cs_RoomInfo
	{
		public short roomNo;	//房间序号
		public char[] name = new char[Constant.MAX_ROOM_NAME_LEN + 1]; //房间名字
		public byte mode;		//页面类型(参考eMATCH_MODE)
		public int  mapNum;		//地图序号
		public byte joinerNum;	//当前人数
		public byte password;	//房间是否有密码(1:有房间密码)
		public byte status;		//房间状态（0:等待开始, 1:进行中）
		public byte mapLaps;	//圈数
		public byte maxJoinerNum;//最大人数
		public string ip = new string (new char[Constant.MAX_IP_ADDRESS_LEN + 1]); //IP地址

		public char[] clubname1 = new char[Constant.MAX_CLUB_NAME_LEN + 1]; //俱乐部名称
		public char[] clubname2 = new char[Constant.MAX_CLUB_NAME_LEN + 1]; //俱乐部名称
		public byte bStrikeAttack; //是否开启碰撞
		public byte byManNum;		//男的数量
		public byte byGirlNum;		//女的数量
		public byte byLevelType;	//等级类型
#if _CHAT_ROOM_
		public byte age;			//年龄
		public byte chatMode;		//聊天模式
		public byte region;			//地域
		public byte JoinGender;		//性别
#endif

#if _AUDIENCE_MODE_
		public byte byAudienceNum;	//观察者数量
#endif

#if _MATCH_POINT
		public int nRoomMatchPoint;//比赛分数
#endif

#if _MODIFY_PASSWORD
		public char[]  password_info = new char[Constant.MAX_ROOM_PASSWORD_LEN + 1]; //密码
#endif

		public UInt16  usGamePort;	//游戏服务器端口
		public Int32   score;		//房主天梯分数

	}

	public class cs_TimeStamp
	{
		public UInt32 dwTimeStamp;  //服务器时间点 以秒为单位，暂时客户端不用

		void SetTimeStamp(UInt32 timestamp)
		{ 
			dwTimeStamp = timestamp; 
		}

		UInt32 GetTimeStamp() 
		{ 
			return dwTimeStamp; 
		}
	}

	//必要时（设置类）可以另外使用（附加于cmdGAME_REQUEST_GAME_NEW_ITEM_USE结构之后）
	public class cmdMapItemLocation
	{
		public UInt16 usMapItemID; //物品ID
		public float x;
		public float y;
		public float z;
	};

	//状态信息
	public class  cmdStatus_Info
	{
		public byte byStatusType;  //状态的类型
		public byte byValue;	   //状态的值
	};

	public class  cs_Time
	{
		public byte hour;
		public byte minute;
		public byte second;
		public byte centisecond;

		void Set( byte hh, byte mm, byte ss, byte csec) { hour=hh; minute=mm; second=ss; centisecond=csec; }
	}

	//比赛结果
	public class   cs_Result 
	{
		public UInt16 uid;			// 玩家ID
		public char[] charname = new char[Constant.MAX_CHAR_NAME_LEN + 1]; //角色名

		public byte avatarNo;		// avatar(0~)
		public byte level;			// 等级
		public Int16 emblemNo;		// 所属emblem
		public byte rank;			// 排名
		public byte retire;			// 是否撤退(1:撤退) 
		public cs_Time lapTime = new cs_Time();	// lapTime
		public Int32 exp;			// 获得经验值
		public Int32 money;			// 获得金钱
		public Int16[] emblems=new Int16[Constant.MAX_EMBLEMS];	// 获得emblems

	#if _NEW_REWARD_RESULT
		public short[,] plusReward = new short[(int)ePlusRewardType.ePlusRewardType_MAX, (int)ePlusRewardEffect.ePlusRewardEffect_MAX];//结果奖金
		#if _NEW_REWARD_RESULT_V2	
		public int[,] materialItemID = new int[2, Constant.MAX_REWARD_MATERIAL];//材料物品号码0 : 材料ID, 1 : 材料Count
		#else
		public int[] materialItemID = new int[MAX_REWARD_MATERIAL];		// 材料物品号码
		#endif
	#endif
		public byte teamcolor;		// 团队(0:个人战, 1:绿色团队, 2:红色团队)
		public Int16 point;			// 胜利积分(团队战时所用)
		public byte eventType; // 参考GameEventType enum type
		public byte byJackUp;  //JACKUp 标志
		public byte byExpUp;  // ExpUp 标志
		
		public string Privilege = new string(new char[4]);	//0:无特权1:有特权0-3位置:美眉特权,公会,媒体,网吧
	};


	
}