
namespace Command
{
    public class Constant
    {
		public const int MAX_PACKET_SIZE                = 4096;//最大包的大小
		public const int  MAX_VERSION_INFO_LEN       = 10;//版本信息的最大长度
		public const int  MAX_CHANNEL_NAME_LEN	=30;//频道名长度
		public const int MAX_LOGIN_NAME_LEN = 50;//登录名长度
		public const int MAX_IP_ADDRESS_LEN = 15;//IP地址长度 
		public const int MAX_PASSWORD_LEN = 32;//密码长度
		public const int MAX_AUTH_LEN = 32;	//认证字段串的长度
		public const int MAX_EMBLEMS	=8; //微章最大数量 
		public const int MAX_MISSION_CHAPTER =	15	;//任务模式最多CHAPTER个数
		public const int MAX_CLUB_NAME_LEN	=	15;//CLUB名字最长限度
		public const int MAX_NICKNAME_LEN		=	20;//角色名最长限度(英文20字，中文10字）
		public const int MAX_SOCKET_NUM			=	2;//SOCKET 最多个数
		public const int MAX_EQUIP_SLOT			=	11;//可佩戴最多SLOT个数 == CAvatarCodiDef::SLOT_NUM
		public const int MAX_CLUB_AUTHLEVEL	=	6;//CLUB等级名个数
		public const int MAX_CLUB_AUTHLEVEL_LEN =10;//CLUB等级名最长限度
		public const int MAX_ABILITY_CARD_TYPE=4;//ABILITY卡片种类个数
		public const int MAX_ROOM_NAME_LEN=18;//房间名字长度
		public const int MAX_ROOM_PASSWORD_LEN=4;//密码的长度
		public const int MAX_HOUSINGITEM_SLOT=21;//房间的装饰物品
		public const int MAX_CHAR_NAME_LEN=20;//角色名最长限度(英文20字，中文10字）
		public const int MAX_REWARD_MATERIAL = 5; // 最大结果，材料个数
		public const int MAX_PLAYERS = 8;
    } 

    public enum ServerType:ushort
    {
		    SERVER_TYPE_LOGIN			        =10000,// 与login服务器通信时使用
		    SERVER_TYPE_LOGINRELAY	            =15000,// LoginRelay - LoginServer
		    SERVER_TYPE_GAME			        =20000,// 与game服务器通信时使用
		    SERVER_TYPE_RELAY			        =30000,// 与Relay服务器通信时使用
			SERVER_TYPE_QUERY		            =40000,// 与DB Query服务器通信时使用
			SERVER_TYPE_LOG			            =45000,// 与log服务器通信时使用
			SERVER_TYPE_SERVER		            =50000,// 服务器之间通信时使用
			SERVER_TYPE_MONITOR		        	=52000,// 与Monitor服务器通信时使用
			SERVER_TYPE_MESSENGER	        	=56000,// 与Messenger 服务器通信时使用
			SERVER_TYPE_MESSENGER_RELAY	    	=58000,// Messenger与Relay服务器通信时使用
			SERVER_TYPE_NONE                    =60000,// 其他协议
      }

    public enum PostType : ushort
    {
		POST_TYPE_REQUEST		=0000,// Client -> Server 请求
		POST_TYPE_ANSWER		=320,// Server -> Client 回应, 有回应值
		POST_TYPE_NOTIFY		=1000,//Server -> Client 一般服务器通报，而不是对请求的反馈, 无回应值 
		POST_TYPE_ECHO          =1500,// 同时使用请求和反馈时, 无回应值

    }

    public class Login
    {
       public enum eLOGIN_REQUEST:ushort
        {
            LOGIN_REQUEST = ServerType.SERVER_TYPE_LOGIN + PostType.POST_TYPE_REQUEST,

			LOGIN_REQUEST_CONNECT_AUTH,			// 连接认证
			LOGIN_REQUEST_LOGIN_AUTH,			// 登录认证
			LOGIN_REQUEST_LOGIN_AUTH_WITH_EKEY, // 登录认证(发送Ekey)
			LOGIN_REQUEST_CHANNEL_LIST,			// 申请频道目录
			LOGIN_REQUEST_CHANNEL_MOVE,			// 申请频道移动
			LOGIN_REQUEST_LOGIN_AUTH_WITH_ECARD,// 登录认证(发送ECard
			LOGIN_REQUEST_LOGIN_AUTH_HBS_MIDDLE,// 登录认证发送TOKEN)
            LOGIN_REQUEST_
        };

       public enum eLOGIN_ANSWER :ushort
        {
            LOGIN_ANSWER = ServerType.SERVER_TYPE_LOGIN + PostType.POST_TYPE_ANSWER,

			LOGIN_ANSWER_CONNECT_AUTH,			// 连接认证
			LOGIN_ANSWER_LOGIN_AUTH,			// 登录认证
			LOGIN_ANSWER_LOGIN_AUTH_NEED_EKEY,	// 登录认证(回应需要EKey时的情况下)
			LOGIN_ANSWER_CHANNEL_LIST,			// 回应频道目录
			LOGIN_ANSWER_CHANNEL_MOVE,			// 回应频道移动
			LOGIN_ANSWER_USER_BLOCK,			// 回应账号封停
			LOGIN_ANSWER_LOGIN_AUTH_NEED_ECARD,	// 登录认证(回应需要Ecard时的情况下)
			LOGIN_ANSWER_LOGIN_AUTH_HBS_MIDDLE, // 登录认证(发送结果)
            LOGIN_ANSWER_ENCRYPT_STR,			//加密密钥
            LOGIN_ANSWER_
        };

    }

	public class Lobby
	{
		public enum eLOBBY_REQUEST:ushort
		{
			GAME_REQUEST = ServerType.SERVER_TYPE_GAME + PostType.POST_TYPE_REQUEST,
			
			GAME_REQUEST_CONNECT_AUTH,				// 连接认证
			GAME_REQUEST_LOGIN_AUTH,				// 登录认证
			GAME_REQUEST_USER_INFO,					// 申请玩家信息
			
			GAME_REQUEST_CHAR_INFO,					// 读取角色信息
			GAME_REQUEST_CHAR_CREATE,				// 创建角色
			GAME_REQUEST_CHAR_SELECT,				// 选择角色
			GAME_REQUEST_CHAR_DELETE,				// 删除角色
			
			GAME_REQUEST_CHANNEL_LIST,				// 申请频道目录
			GAME_REQUEST_CHANNEL_SELECT,			// 选择频道
			GAME_REQUEST_CHANNEL_MOVE,				// 申请频道移动
			
			GAME_REQUEST_MODE_SELECT,				// 选择游戏模式
			
			GAME_REQUEST_ROOM_LIST,					// 申请房间目录
			GAME_REQUEST_ROOM_CREATE,				// 创建房间
			GAME_REQUEST_ROOM_JOIN,					// 进入房间
			GAME_REQUEST_ROOM_QUICKJOIN,			// 马上进入房间
			GAME_REQUEST_ROOM_LEAVE,				// 离开房间
			GAME_REQUEST_ROOM_KICKOUT,				// 强制退出房间
			GAME_REQUEST_ROOM_LOADED,				// 等待房间
			GAME_REQUEST_ROOM_READY,				// 在房间内准备游戏
			GAME_REQUEST_ROOM_MAPSELECT,			// 选择地图
			GAME_REQUEST_ROOM_SETTING,				// 设置房间
			GAME_REQUEST_ROOM_TEAMCHANGE,			// 换组
			GAME_REQUEST_ROOM_START,				// 在房间里开始游戏
			
			GAME_REQUEST_GAME_USE_LR_GAGE,			// 使用LR GAGE
			
			GAME_REQUEST_GAME_LOADED,				// 准备完毕
			GAME_REQUEST_GAME_GOALIN,				// GOALIN
			GAME_REQUEST_GAME_RETIRE,				// 退出
			
			GAME_REQUEST_ENTER_CHANNELSELECT,		// 以选择频道的方式入场
			GAME_REQUEST_ENTER_CURRENTCHANNEL,	    // 以现在的频道入场
			GAME_REQUEST_ENTER_MODESELECT,			// 以选择模式的方式入场
			GAME_REQUEST_ENTER_MYROOM,				// 进入我的房间
			GAME_REQUEST_ENTER_LOBBY,				// 进入大厅
			GAME_REQUEST_ENTER_TUTORIAL,			// 进入新手引导
			GAME_REQUEST_ENTER_MISSIONLOBBY,		// 进入任务大厅
			GAME_REQUEST_ENTER_ITEMSHOP,			// 进入商城
			GAME_REQUEST_ENTER_RANKVIEW,			// 进入查看排名
			
			GAME_REQUEST_TUTORIAL_CLEAR,			// 完成新手引导
			GAME_REQUEST_TUTORIAL_TRY,				// 尝试新手引导
			
			GAME_REQUEST_ITEMSHOP_BUY,				// 购买物品
			
			GAME_REQUEST_MYITEM_LIST,				// 我的物品目录
			GAME_REQUEST_MYITEM_WEAR,				// 穿戴自己的物品
			GAME_REQUEST_MYITEM_TAKEOFF,			// 脱下我的物品
			GAME_REQUEST_MYITEM_ENCHANT,			// 申请ENCHANT
			
			GAME_REQUEST_MYBAG_LIST,				// 我的背包目录
			GAME_REQUEST_MYBAG_BUY,					// 购买背包
			GAME_REQUEST_MYBAG_SAVE,				// 保存背包
			
			GAME_REQUEST_MYCHAR_LIST,				// 我的角色列表
			GAME_REQUEST_CHAR_SLOT_BUY,				// 角色槽购买
			GAME_REQUEST_SCHAR_SLOT_OPEN,			// 特殊角色槽开放
			
			GAME_REQUEST_EXIT,						// 结束游戏
			
			GAME_REQUEST_CHAT,						// 聊天
			
			GAME_REQUEST_GAME_GAIN_ITEM,			// 申请获得游戏物品
			GAME_REQUEST_GAME_ITEM_USE,				// 使用物品
			GAME_REQUEST_GAME_ITEM_CASTER_APPLY,	// 将物品效果适用在使用者身上
			GAME_REQUEST_GAME_ITEM_TARGET_APPLY,	// 对目标适用道具效果
			GAME_REQUEST_GAME_CRASHED_ITEM,			// 角色设置与携带物品冲突
			GAME_REQUEST_GAME_LOADING_PROGRESS_VALUE,// 准备进行状态 ( % )
			
			GAME_REQUEST_SKILL,						// 使用技能
			GAME_REQUEST_STUN_END,					// 停止眩晕状态
			GAME_REQUEST_REDUCE_HP,					// HP 减少
			GAME_REQUEST_SPUSE,						//SP使用
			GAME_REQUEST_MISSION_CLEAR,				//
			GAME_REQUEST_LOGOUT,					// 申请玩家的登录退出
			GAME_REQUEST_RANK_LIST,					// 申请排名列表
			GAME_REQUEST_RANK_SEARCH,				// 申请用角色名在排名中搜索
			
			GAME_REQUEST_ENTER_GAMBLE,				// 赌博画面登录
			GAME_REQUEST_GAMBLE_SELECT,				// 赌博 – 选择徽章
			GAME_REQUEST_GAMBLE_CHALLANGE,			// 赌博 – 挑战
			GAME_REQUEST_GAMBLE_NEXT_LEVEL,         // 赌博 - 获得卡片/选择下一个等级
			
			GAME_REQUEST_ABILITY_CARD_LIST,			// 申请ABILITY卡片目录
			GAME_REQUEST_ABILITY_CARD_STAT,			// 申请因ABILITY卡片带来的能力值变动
			GAME_REQUEST_ABILITY_CARD_HOLD,			// 保持能力卡
			
			GAME_REQUEST_GAME_CREATE,				// 申请用游戏服务器生成游戏
			GAME_REQUEST_GAME_CONNECT,				// 连接游戏服务器以及进入对应游戏 
			
			GAME_REQUEST_ENTER_VLOBBY,				// 请求登录大厅
			
			GAME_REQUEST_GIFT_LIST,				    // 申请礼物箱子目录
			GAME_REQUEST_GIFT_SEND,					// 申请送出礼物
			GAME_REQUEST_GIFT_RECEIVE,				// 确认礼物 提示
			
			GAME_REQUEST_HOUSINGSHOPITEM_BUY,		// 申请购买HOUSING商铺物品 
			GAME_REQUEST_MYHOUSINGITEM_LIST,		// 申请我的HOUSING物品目录
			GAME_REQUEST_MYHOUSINGITEM_PLACE,		// 设置HOUSING道具
			GAME_REQUEST_MYHOUSINGITEM_UNPLACE,		// 解除HOUSING道具
			
			GAME_REQUEST_CHANGE_GRAFFITIMAN,		// 旗战 – 变更旗子所有
			GAME_REQUEST_STRIKE_ATTACK,				// 请求STRIKEATTACK
			
			GAME_REQUEST_VISIT_MYROOM,				// 进入房间
			GAME_REQUEST_LEAVE_MYROOM,				// 离开房间
			
			GAME_REQUEST_ENTER_CLUBVIEW,			// CLUB查询登录	
			GAME_REQUEST_CREATE_CLUB,				// 申请创建CLUB
			GAME_REQUEST_ROOM_INVITE,				// 邀请到房间
			GAME_REQUEST_ROOM_INVITE_ANSWER,		// 对邀请的回应
			
			GAME_REQUEST_ITEM_ADD_SOCKET,			// 道具添加镶嵌
			GAME_REQUEST_CARD_EXTRACT,				// 把镶嵌的卡取回
			GAME_REQUEST_DEC_ITEM_COUNT,			// 减少物品剩余使用次数
			GAME_REQUEST_DUPLICATE_CHECK_CHARNAME,	// 确认角色名是否重复
			GAME_REQUEST_GUIDE_CLEAR,				// 新手引导系统 CLEAR
			GAME_REQUEST_GAME_CHECKPOINT,			// 申请游戏时确认wdr确认点数
			GAME_REQUEST_GAME_PASSZONE,				// wdr – 通过终点时发送到服务器
			GAME_REQUEST_GAME_LOBBY_MEMBERS,		// 申请游戏大厅参加者信息
			GAME_REQUEST_VLOBBY_MEMBERS,			// 申请广场参加者信息
			GAME_REQUEST_MYROOM_MEMBERS,			// 申请参加房间玩家的信息
			GAME_REQUEST_GAME_LOADING_READY,		// 将已做好转换到游戏登录画面，提示给服务器
			GAME_REQUEST_ROOM_MAX_JOINER_NUM_CHANGE,// 可以入场的最多玩家数（游戏房间）
			GAME_REQUEST_ROOM_MAX_MAP_LAPS_CHANGE,	// 游戏圈数变更(游戏房间)
			GAME_REQUEST_GAME_SET_MAX_COMBO,		// 在游戏中设置max-combo
			GAME_REQUEST_CLUB_INVITATION,  			// 申请CLUB邀请信息
			GAME_REQUEST_USER_EXTRAINFO,  			// 请求其他信息(转职,统计等)
			GAME_REQUEST_CASH_INFO, 				//申请cash信息
			GAME_REQUEST_GAME_FALLDOWN, 			// 玩家摔倒时客户端发送的数据
			GAME_REQUEST_ENTER_LAPTIMEMODE, 		// 竞速模式登录
			GAME_REQUEST_LAPTIMEMODE_RANKINFO, 		// 该圈的排名信息(1~5名自己的记录)
			GAME_REQUEST_LAPTIMEMODE_START, 		// 竞速模式开始(个人记录)	
			GAME_REQUEST_LAPTIMEMODE_CREATE, 		// 向游戏服务器请求 生成竞速模式房间
			GAME_REQUEST_LAPTIMEMODE_GOALIN, 		// 竞速模式到达终点时发送的数据
			GAME_REQUEST_DELETE_EXPIRED_ITEM, 		// 传送期限已过的物品
			GAME_REQUEST_DELETE_EXPIRED_HOUSINGITEM,// 传送期限已过的HOUSING物品
			GAME_REQUEST_LAPTIMEMODE_WINNERINFO, 	// 按地图读取排名
			GAME_REQUEST_LAPTIMEMODE_EXIT, 			// 退出竞速模式
			GAME_REQUEST_OPEN_LUCKY_BOX, 			// 开启幸运箱子
			GAME_REQUEST_OPEN_HALLOWEEN_BOX, 		// 开启万圣节箱子（万圣节活动）
			GAME_REQUEST_ENTER_ACHIEVEMENT, 		// 请求登录成就
			GAME_REQUEST_ACHIEVEMENT_DEPTH1, 		// 成功成就列表(1次分类)
			GAME_REQUEST_ACHIEVEMENT_DEPTH2, 		//成功成就列表(2次分类)
			GAME_REQUEST_ACHIEVEMENT_DEPTH3, 		// 请求成就进行阶段 -> ex) 1名次数 5/15
			GAME_REQUEST_CHECK_NEWBIE_24H, 			// 检查是否是第一个角色生成24小时以内
			GAME_REQUEST_OPEN_CHRISTMAS_BOX, 		// 开启圣诞箱子	
			GAME_REQUEST_SPRAY_ACQUIRE, 			// 获得喷雾
			GAME_REQUEST_SPRAY_USE, 				// 胶橇饭捞 荤侩
			GAME_REQUEST_SPRAY_MISS, 				// 胶橇饭捞 冻崩	
			GAME_REQUEST_OPEN_CANDY_BOX, 			//开启糖果箱子
			GAME_REQUEST_NICKNAME_CHANGE, 			// 申请角色名变更
			GAME_REQUEST_USER_POS,  				// 申请周边玩家位置）
			GAME_REQUEST_MY_POS,  					// 申请周边玩家位置）
			GAME_REQUEST_GACHAPON_CHARACTER, 		// GACHAPON 角色赌博
			GAME_REQUEST_GACHAPON_ITEM, 			//GACHAPON 道具 赌博
			GAME_REQUEST_GAIN_LANDINGROLL_SP, 		// LANDINGROLL时获得 sp
			
			////////道具更新///////////
			GAME_REQUEST_GAME_NEW_ITEM_USE,			// 使用物品
			/////////////////////////////////
			
			GAME_REQUEST_GAME_EVENTOBJECT,					
			
			GAME_REQUEST_GAME_NEW_ITEM_DELETE,		//物品删除【客户端->服务器】
			
			GAME_REQUEST_GAME_COLLISION_ITEM,		// 与设置物品发生冲突
			
			GAME_REQUEST_GAME_ITEM_AVOID_CHECK,		// 回避检查
			
			
			GAME_REQUEST_GAME_CHARGE_ITEMGAUGE,		// 充值胶囊
			
			GAME_REQUEST_GAME_START_COUNT,    		//游戏开始倒计时
			GAME_REQUEST_GAME_COUNT_STOP,     		//游戏倒计时暂停
			
			
			GAME_REQUEST_GAME_SERVER_TIME_TICK_START,     		//游戏时间 TICK【游戏开始】
			GAME_REQUEST_GAME_SERVER_TIME_TICK_PERIODIC,     	//游戏时间 TICK【按周期】
			
			GAME_REQUEST_GAME_SERVER_SYNC_POS,     				//保存玩家位置【按周期】
			
			GAME_REQUEST_GAME_ROOM_STRIKEATTACK_INFO_CHANGE, 	//变更房间有无STRIKEATTACK的信息
			
			GAME_REQUEST_GAME_ITEM_MODE_CLICK,      //要进行物品战的玩家
			
			GAME_REQUEST_ENTER_GOLDENRACE,			// 黄金模式 请求登录
			GAME_REQUEST_JOIN_GOLDENRACE,			// 黄金模式 请求参与
			
			GAME_REQUEST_USER_INPUT_STATUS_STOP,	//玩家点击按键解除特定道具的状态
			
			GAME_REQUEST_ITEM_CHANGER_USE,			//使用 ITEM CHANGER
			GAME_REQUEST_SLOT_CHANGER_USE,			//使用 SLOT CHANGER
			GAME_REQUEST_EVENT_LIST,
			
			GAME_REQUEST_CHAT_ROOM_CREATE,			// 创建房间
			GAME_REQUEST_CHAT_ROOM_SETTING,			// 设置房间
			GAME_REQUEST_USER_DETAILINFO,			// 申请玩家详细信息
			GAME_REQUEST_UPDATE_USER_DETAILINFO,    // 申请玩家详细信息更新
			GAME_REQUEST_WHISPER,					// 私聊(Lobby)
			
			GAME_REQUEST_SP_PLUS,					// sp上传
			
			
			GAME_REQUEST_JTE_GET_USER,				// 热门活动申请列表
			GAME_REQUEST_JTE_SET_USER,				// 热门活动招募
			GAME_REQUEST_JTE_REWARD,				// 申请热门活动接收礼物
			
			GAME_REQUEST_EXCHANGE_COMPOUNDITEM,		// 申请收集商交换物品
			GAME_REQUEST_GET_MATERIAL_ITEM_LIST,	// MATERIAL_ITEM 申请列表 
			GAME_REQUEST_OPEN_PACKAGE,				// 申请处理Package
			
			GAME_REQUEST_PACKAGE,					// 申请处理Package
			
			GAME_REQUEST_TEAMGAUGE_CONTROL,			// TEAMGAUGE适用的临时 数据
			GAME_REQUEST_AHN_HS_VERIFYRESPONSE,		//反外挂 回应 VerifyResponse
			
			GAME_REQUEST_CONSUME_ITEM_USE_UTILITY,	//消耗性使用物品（用(UTILITY NO 搜索）
			GAME_REQUEST_CONSUME_ITEM_USE_ITEM,		//消耗性使用物品（用ITEM ID搜索）
			
			GAME_REQUEST_CHAR_SLOT_GIFT_SEND,		//申请赠送角色礼物
			
			GAME_REQUEST_CHAT_MSG,					// 聊天
			GAME_REQUEST_CHAT_MSG_WHISPER,			// 私聊
			GAME_REQUEST_SET_CHAT_BLOCK,			//聊天模块
			
			//--CPS 客户端发给服务器的消息---------
			
			GAME_REQUEST_CPS_CHECK_RESULT,			//客户端->服务器  返回检验值
			
			GAME_REQUEST_CPS_HAD_RECEIVE_HDB,		//客户端->服务器  返回接收到hdb通知信息
			
			GAME_REQUEST_CPS_HDB_COMPLETE,			//客户端->服务器  返回hdb完整性结果
			
			GAME_REQUEST_CPS_ALT_INIT_RESULT,		//客户端->服务器  返回hdb初始化结果
			
			GAME_REQUEST_CPS_SCAN_RESULT,			//客户端->服务器  向服务器发送扫描结果信息密文
			
			
			//签到
			GAME_REQUEST_SIGN_LIST,					//[客户端请求签到列表]
			
			GAME_REQUEST_SIGN_IN,					//客户端请求签到协议
			
			
			//任务  客户端发给服务器的消息 -----
			GAME_REQUEST_TASK_RECEIVE_TASK,			//客户端->服务器 接受任务
			
			GAME_REQUEST_TASK_SUBMIT_TASK,			//客户端->服务器 提交任务
			
			GAME_REQUEST_TASK_GET_TASK_LIST,		//客户端->服务器 获取任务列表
			
			GAME_REQUEST_TASK_UNLOCK_TASK,			//客户端->服务器 解锁任务
			
			GAME_REQUEST_TASK_GIVEUP_TASK,			//客户端->服务器 放弃任务
			
			//排行榜
			GAME_REQUEST_MAP_LAPTIME,				//赛道排行
			
			GAME_REQUEST_TOTAL_MAP_LAPTIME,			//全地图排行
			
			//[公会升级]
			GAME_REQUEST_CLUB_LEVELUP = 20190,
			//[会员贡献]
			GAME_REQUEST_MAKE_CONTRIBUTION,
			//[兑换道具]
			GAME_REQUEST_EXCHANGE_ITEM,
			//[商城列表]
			GAME_REQUEST_SHOP_LIST,
			//[活跃度列表请求]
			GAME_REQUEST_GIFT_ACT,
			//[领取活跃度奖励]
			GAME_REQUEST_GET_GIFT,
			
			GAME_REQUEST_FCM,
			
			//[房间查找]
			GAME_REQUEST_FIND_ROOM,
			//[gameserver密钥]
			GAME_REQUEST_ENCRYPT_STR,
			
			//购买极限挑战次数
			GAME_REQUEST_LAPTIME_BUY_COUNT,
						
			GAME_REQUEST_HIGH_LADDER,				//打开天梯面板
			GAME_REQUEST_HIGH_LADDER_RANK_LIST,		//获取排名列表
			GAME_REQUEST_HIGH_LADDER_AWARD,			//排名奖励
			GAME_REQUEST_HIGH_LADDER_RESET_MYSCORE, //重置天梯积分
			GAME_REQUEST_HIGH_LADDER_FIND,			//查找
			GAME_REQUEST_HIGH_LADDER_CHALLENGE,		//天梯挑战
			GAME_REQUEST_TASK_NEW_STATE,			//[任务状态更新]
			GAME_REQUEST_SET_CLUB_AHTH,				//[设置俱乐部权限]
			GAME_REQUEST_CLUB_RANK,					//[俱乐部排行]
			GAME_REQUEST_ROOM_CREATE_GSRV,			//在Game创建房间
						
			GAME_REQUEST_
		};
		
		public enum eLOBBY_ANSWER :ushort
		{
			GAME_ANSWER = ServerType.SERVER_TYPE_GAME + PostType.POST_TYPE_ANSWER,
			
			GAME_ANSWER_CONNECT_AUTH,				// 连接认证
			GAME_ANSWER_LOGIN_AUTH,					// 登录认证
			GAME_ANSWER_USER_INFO,					// 申请玩家信息
			
			GAME_ANSWER_CHAR_INFO,					// 读取角色信息
			GAME_ANSWER_CHAR_CREATE,				// 生成角色
			GAME_ANSWER_CHAR_SELECT,				// 选择角色
			GAME_ANSWER_CHAR_DELETE,				// 删除角色
			
			GAME_ANSWER_CHANNEL_LIST,				// 申请频道目录
			GAME_ANSWER_CHANNEL_SELECT,				// 选择频道
			GAME_ANSWER_CHANNEL_MOVE,				// 申请频道移动
			
			GAME_ANSWER_MODE_SELECT,				// 选择模式
			
			GAME_ANSWER_ROOM_LIST,					// 申请房间目录
			GAME_ANSWER_ROOM_CREATE,				// 创建房间
			GAME_ANSWER_ROOM_JOIN,					// 进入房间
			GAME_ANSWER_ROOM_QUICKJOIN,				// 马上进入房间
			GAME_ANSWER_ROOM_LEAVE,					// 离开房间
			GAME_ANSWER_ROOM_KICKOUT,				// 强制退出房间
			GAME_ANSWER_ROOM_LOADED,				// 准备完毕
			GAME_ANSWER_ROOM_READY,					// 在房间内准备游戏
			GAME_ANSWER_ROOM_MAPSELECT,				// 选择地图
			GAME_ANSWER_ROOM_SETTING,				// 设置房间
			GAME_ANSWER_ROOM_TEAMCHANGE,			// 换组
			
			GAME_ANSWER_ROOM_START,					// 在房间里开始游戏
			
			GAME_ANSWER_GAME_USE_LR_GAGE,			// 使用LR GAGE
			
			GAME_ANSWER_GAME_LOADED,				// 登录
			GAME_ANSWER_GAME_GOALIN,				// GOALIN
			GAME_ANSWER_GAME_RETIRE,				// 退出
			
			GAME_ANSWER_ENTER_CHANNELSELECT,		// 以选择频道的方式入场
			GAME_ANSWER_ENTER_CURRENTCHANNEL,		// 以现在的频道入场
			GAME_ANSWER_ENTER_MODESELECT,			// 以选择模式的方式入场
			GAME_ANSWER_ENTER_MYROOM,				// 进入我的房间
			GAME_ANSWER_ENTER_LOBBY,				// 进入大厅
			GAME_ANSWER_ENTER_TUTORIAL,			    // 进入新手引导
			GAME_ANSWER_ENTER_MISSIONLOBBY,			// 进入任务大厅
			GAME_ANSWER_ENTER_ITEMSHOP,				// 进入商城
			GAME_ANSWER_ENTER_RANKVIEW,				// 进入查看排名
			
			GAME_ANSWER_ITEMSHOP_BUY,				// 购买物品
			
			GAME_ANSWER_MYITEM_LIST,				// 我的物品目录
			GAME_ANSWER_MYITEM_WEAR,				// 穿戴自己的物品
			GAME_ANSWER_MYITEM_TAKEOFF,				// 脱下我的物品
			GAME_ANSWER_MYITEM_ENCHANT,				// 我的ENCHANT
			
			GAME_ANSWER_MYBAG_LIST,					// 我的背包目录
			GAME_ANSWER_MYBAG_BUY,					// 购买背包
			GAME_ANSWER_MYBAG_SAVE,					// 保存背包
			
			GAME_ANSWER_MYCHAR_LIST,				// 我的角色目录
			GAME_ANSWER_CHAR_SLOT_BUY,				// 购买角色槽
			
			GAME_ANSWER_GAME_ITEM_USE,				// 使用物品
			GAME_ANSWER_GAME_ITEM_CASTER_APPLY,		// 将物品效果适用在使用者身上
			GAME_ANSWER_GAME_ITEM_TARGET_APPLY,		// 目标适用道具效果
			GAME_ANSWER_GAME_CRASHED_ITEM,			// 角色设置与携带物品冲突
			
			GAME_ANSWER_EXIT,						// 结束游戏
			
			GAME_ANSWER_CHAT,						// 聊天
			GAME_ANSWER_MISSION_CLEAR,				// 任务完成
			GAME_ANSWER_LOGOUT,						// 对退出游戏的回应
			GAME_ANSWER_RANK_LIST,					// 对排名申请列表的回应
			GAME_ANSWER_RANK_SEARCH,				// 对用角色名搜索排名的回应
			
			GAME_ANSWER_ENTER_GAMBLE,				// 赌博画面登录
			GAME_ANSWER_GAMBLE_SELECT,				// 赌博 - 选择徽章
			GAME_ANSWER_GAMBLE_CHALLANGE,			// 赌博 - 挑战
			GAME_ANSWER_GAMBLE_NEXT_LEVEL,
			
			GAME_ANSWER_ABILITY_CARD_LIST,			// 对能力卡请求的回应
			GAME_ANSWER_ABILITY_CARD_STAT,			// 因能力卡的能力变更回应
			GAME_ANSWER_ABILITY_CARD_HOLD,			// 能力卡保持回应
			
			GAME_ANSWER_GAME_CREATE,				// 对申请用游戏服务器生成游戏的回应
			GAME_ANSWER_GAME_CONNECT,				// 对连接游戏服务器以及进入对应游戏的回应
			
			GAME_ANSWER_ENTER_VLOBBY,				// 请求进入大厅的回应
			
			GAME_ANSWER_GIFT_LIST,					// 对礼物箱子目录的回应
			GAME_ANSWER_GIFT_SEND,					// 对赠送礼物的回应
			GAME_ANSWER_GIFT_RECEIVE,				// 对确认礼物的回应
			
			GAME_ANSWER_HOUSINGSHOPITEM_BUY,		// 对购买HOUSING商铺物品的回应 
			GAME_ANSWER_MYHOUSINGITEM_LIST,			// 我的HOUSING物品目录回应
			GAME_ANSWER_MYHOUSINGITEM_PLACE,		// 我的HOUSING道具佩戴
			GAME_ANSWER_MYHOUSINGITEM_UNPLACE,		// 我的HOUSING道具解除
			
			GAME_ANSWER_CHANGE_GRAFFITIMAN,			// 旗战 - 变更旗子所有
			
			GAME_ANSWER_VISIT_MYROOM,				// 进入房间访问应答
			GAME_ANSWER_LEAVE_MYROOM,				// 对离开房间的应答
			
			GAME_ANSWER_ENTER_CLUBVIEW,				// CLUB入场 回应
			GAME_ANSWER_CREATE_CLUB,				// 对创建CLUB的回应
			GAME_ANSWER_ROOM_INVITE,				// 对邀请到房间的回应
			GAME_ANSWER_ROOM_INVITE_ANSWER,			// 对邀请的回应
			GAME_ANSWER_ITEM_ADD_SOCKET,			// 道具添加镶嵌 回应
			GAME_ANSWER_CARD_EXTRACT,				// 取回镶嵌的卡  回应
			GAME_ANSWER_DEC_ITEM_COUNT,				// 减少物品剩余使用次数 回应
			GAME_ANSWER_DUPLICATE_CHECK_CHARNAME,	// 确认角色名是否重复
			GAME_ANSWER_GUIDE_CLEAR,				// 新手引导系统 CLEAR
			GAME_ANSWER_GAME_CHECKPOINT,			// chek point提示确认请求回应
			GAME_ANSWER_GAME_PASSZONE,				// 申请确认PASSZONE
			GAME_ANSWER_GAME_LOBBY_MEMBERS,			
			GAME_ANSWER_VLOBBY_MEMBERS,			
			GAME_ANSWER_MYROOM_MEMBERS,	
			GAME_ANSWER_GAME_LOADING_READY,
			GAME_ANSWER_ROOM_MAX_JOINER_NUM_CHANGE,
			GAME_ANSWER_ROOM_MAX_MAP_LAPS_CHANGE,	
			GAME_ANSWER_GAME_SET_MAX_COMBO,
			GAME_ANSWER_CLUB_INVITATION,
			GAME_ANSWER_USER_EXTRAINFO,
			GAME_ANSWER_CASH_INFO,
			GAME_ANSWER_GAME_FALLDOWN,
			GAME_ANSWER_ENTER_LAPTIMEMODE,
			GAME_ANSWER_LAPTIMEMODE_RANKINFO,
			GAME_ANSWER_LAPTIMEMODE_START,
			GAME_ANSWER_LAPTIMEMODE_CREATE,
			GANE_ANSWER_LAPTIMEMODE_GOALIN,
			GAME_ANSWER_DELETE_EXPIRED_ITEM,
			GAME_ANSWER_DELETE_EXPIRED_HOUSINGITEM,
			GAME_ANSWER_LAPTIMEMODE_WINNERINFO, 
			GAME_ANSWER_LAPTIMEMODE_EXIT,
			GAME_ANSWER_OPEN_LUCKY_BOX,
			GAME_ANSWER_OPEN_HALLOWEEN_BOX,
			GAME_ANSWER_ENTER_ACHIEVEMENT,
			GAME_ANSWER_ACHIEVEMENT_DEPTH1,
			GAME_ANSWER_ACHIEVEMENT_DEPTH2,
			GAME_ANSWER_ACHIEVEMENT_DEPTH3,
			GAME_ANSWER_CHECK_NEWBIE_24H,
			GAME_ANSWER_OPEN_CHRISTMAX_BOX,	
			GAME_ANSWER_SPRAY_ACQUIRE,
			GAME_ANSWER_SPRAY_USE,
			GAME_ANSWER_SPRAY_MISS,
			GAME_ANSWER_OPEN_CANDY_BOX,
			GAME_ANSWER_NICKNAME_CHANGE,
			GAME_ANSWER_USER_POS,  						// 传达保存自己的位置值后重新发送到服务器
			GAME_ANSWER_MY_POS,  						// 申请周边玩家位置）
			GAME_ANSWER_GACHAPON_CHARACTER,
			GAME_ANSWER_GACHAPON_ITEM,
			GAME_ANSWER_GAIN_LANDINGROLL_SP, 
			
			
			///////////道具相关////////// 
			GAME_ANSWER_GAME_NEW_ITEM_USE_FAILED,		// 使用物品失败
			GAME_ANSWER_GAME_NEW_ITEM_USE_SUCCESS,		// 使用物品成功
			
			GAME_ANSWER_GAME_NEW_ITEM_DELETE,			//物品删除结果【服务器->客户端】	
			GAME_ANSWER_GAME_SERVER_TIME_TICK,			//游戏开始TICK
			////////////////////////////////////////
			
			GAME_ANSWER_GAME_CHANGE_SERVER_SP ,			//设置成服务器sp
			
			GAME_ANSWER_GAME_START_COUNT,				//开始倒计时结果
			GAME_ANSWER_ENTER_GOLDENRACE,
			GAME_ANSWER_JOIN_GOLDENRACE,				//GOLDENRACE回应
			
			GAME_ANSWER_ITEM_CHANGER_USE,				//使用 ITEM CHANGER
			GAME_ANSWER_SLOT_CHANGER_USE,				//使用 SLOT CHANGER
			
			GAME_ANSWER_GAME_GAIN_ITEM,					//获得物品 
			
			GAME_ANSWER_GAME_ITEM_AUTO_DESTROY,			//获得物品一定时间后自动删除
			GAME_ANSWER_EVENT_LIST,
			
			GAME_ANSWER_CHAT_ROOM_CREATE,				//创建聊天房间
			GAME_ANSWER_CHAT_ROOM_SETTING,				// 房间设置变更	
			GAME_ANSWER_USER_DETAILINFO,				// 申请玩家详细信息
			GAME_ANSWER_UPDATE_USER_DETAILINFO,    		// 申请玩家详细信息更新
			
			GAME_ANSWER_WHISPER,						//私聊回复
			
			GAME_ANSWER_JTE_GET_USER_LIST,				// HOT活动 信息
			GAME_ANSWER_JTE_SET_USER,					// 登录HOT活动
			GAME_ANSWER_JTE_REWARD,						// HOT活动 接收礼物
			
			GAME_ANSWER_EXCHANGE_COMPOUNDITEM,			// 收集商交换物品 请求
			GAME_ANSWER_GET_MATERIAL_ITEM_LIST,			// MATERIAL_ITEM 申请列表
			
			GAME_ANSWER_OPEN_PACKAGE,					// Package列表应答
			
			GAME_ANSWER_AHN_HS_MAKEREQUEST,				// 反外挂动作确认请求数据 MakeRequest
			GAME_ANSWER_AHN_HS_ERRCODE,					// 反外挂 ERRO 数据 ERRO 发生情况在客户端强退前传达. 
			
			GAME_ANSWER_CONSUME_ITEM_USE,				//消耗使用性物品
			
			GAME_ANSWER_CHAR_SLOT_GIFT_SEND,			//角色赠送礼物
			
			GAME_ANSWER_SET_CHAT_BLOCK,					// 聊天BLOK 
			
			
			//---------cps服务器通知客户端的-------
			
			//服务器->客户端 要求文件/模块校验值(通知前端执行CPS_IntegrityCheck函数)
			GAME_ANSWER_CPS_CHECK,
			
			//服务器->客户端 下发hash value和有害进程特征码数据(hbd文件)
			GAME_ANSWER_CPS_HASH_VALUE,
			
			//服务器->客户端 通知客户端进行有害进程扫描
			GAME_ANSWER_CPS_SCAN_HARMFUL_PROC,
			
			//服务器->客户端 通知客户端有害进程信息
			GAME_ANSWER_CPS_NOTIFY_HARMFUL_PROC,
			
			//服务器->客户端 通知客户端退出
			GAME_ANSWER_CPS_EXIT,
			
			
			//签到
			GAME_ANSWER_SIGN_LIST,//[服务端返回签到列表]
			
			GAME_ANSWER_SIGN_IN,//服务器->客户端 通知客户端签到是否成功
			
			//-------task 服务器回应客户端的---
			
			//服务器->客户端 接取任务
			GAME_ANSWER_TASK_RECEIVE_TASK,
			
			//服务器->客户端 提交任务
			GAME_ANSWER_TASK_SUBMIT_TASK,
			
			//服务器->客户端 获取任务列表
			GAME_ANSWER_TASK_GET_TASK_LIST,
			
			//服务器->客户端 解锁任务
			GAME_ANSWER_TASK_UNLOCK_TASK,
			
			//服务器->客户端 放弃任务
			GAME_ANSWER_TASK_GIVEUP_TASK,
			
			GAME_ANSWER_MAP_LAPTIME,
			
			GAME_ANSWER_TOTAL_MAP_LAPTIME,
			
			GAME_ANSWER_TOTAL_MAP_LAPTIME_BEGIN,
			
			GAME_ANSWER_TOTAL_MAP_LAPTIME_END,
			
			//[公会升级]
			GAME_ANSWER_CLUB_LEVELUP = 20491,
			//[会员贡献]
			GAME_ANSWER_MAKE_CONTRIBUTION,
			//[兑换道具]
			GAME_ANSWER_EXCHANGE_ITEM,
			//[商城列表]
			GAME_ANSWER_SHOP_LIST,
			//[商城列表结束包]
			GAME_ANSWER_SHOP_LIST_END,
			//[活跃度列表返回]
			GAME_ANSWER_GIFT_ACT,
			//[领取活跃度奖励]
			GAME_ANSWER_GET_GIFT,
			//[任务更新包]
			GAME_ANSWER_TASK_UPDATE,
			
			GAME_ANSWER_FCM,
			//[房间查找返回]
			GAME_ANSWER_FIND_ROOM,
			//[房间查找error]
			GAME_ANSWER_FIND_ERROR,
			//[创建房间数已达最大]
			GAME_ANSWER_MAX_ROOM_ERROR,
			GAME_ANSWER_TOO,
			//[lobby加解密字符串]
			GAME_LS_ANSWER_ENCRYPT_STR,
			//[game加解密字符串]
			GAME_GS_ANSWER_ENCRYPT_STR,
						
			//购买极限挑战
			GAME_ANSWER_LAPTIME_BUY_COUNT,
						
			GAME_ANSWER_HIGH_LADDER,//打开天梯面板
			GAME_ANSWER_HIGH_LADDER_RANK_LIST,//获取排名列表
			GAME_ANSWER_HIGH_LADDER_AWARD,//排名奖励
			GAME_ANSWER_HIGH_LADDER_RESET_MYSCORE,//重置天梯积分
			GAME_ANSWER_HIGH_LADDER_FIND,
			GAME_ANSWER_HIGH_LADDER_CHALLENGE,//天梯挑战
			GAME_ANSWER_TASK_NEW_STATE,//[任务状态更新]
			
			GAME_ANSWER_
		};


		public enum eGAME_NOTIFY
		{
			GAME_NOTIFY = ServerType.SERVER_TYPE_GAME + PostType.POST_TYPE_NOTIFY,
			GAME_NOTIFY_KEEPALIVE,				// keep alive
			GAME_NOTIFY_PAUSE,					// 游戏暂停
			GAME_NOTIFY_CLOSE,
			GAME_NOTIFY_DUPLICATE,				// 重复登录提示, 客户端提示后结束
			
			GAME_NOTIFY_ROOM_LIST_ADD,			// 添加房间目录
			GAME_NOTIFY_ROOM_LIST_DELETE,		// 删除房间目录
			GAME_NOTIFY_ROOM_LIST_UPDATE,		// 房间目录更新
			
			GAME_NOTIFY_ROOM_JOIN,				// 进入房间
			GAME_NOTIFY_ROOM_LEAVE,				// 离开房间
			GAME_NOTIFY_ROOM_KICKOUT,			// 强制退出房间
			GAME_NOTIFY_ROOM_LOADED,			// 等待房间
			GAME_NOTIFY_ROOM_READY,				// 在房间内准备游戏
			GAME_NOTIFY_ROOM_MAPSELECT,			// 选择地图
			GAME_NOTIFY_ROOM_SETTING,			// 设置房间
			GAME_NOTIFY_ROOM_TEAMCHANGE,		// 换组
			GAME_NOTIFY_ROOM_START,				// 在房间里开始游戏
			
			GAME_NOTIFY_GAME_START,				// 出发
			
			GAME_NOTIFY_GAME_USE_LR_GAGE,		// 使用LR GAGE
			
			GAME_NOTIFY_GAME_LOADED,			// 特定玩家已准备完毕提示
			GAME_NOTIFY_GAME_GOALIN,			// GOALIN
			GAME_NOTIFY_GAME_FINISH,			// 结束比赛
			GAME_NOTIFY_GAME_RESULT,			// 处理游戏结果
			GAME_NOTIFY_GAME_LOBBYRETURN,		// 进入游戏大厅
			GAME_NOTIFY_GAME_CHECKPOINT,		// chek point提示 提示
			GAME_NOTIFY_GAME_STATE,				// hp,sp等 信息
			
			
			GAME_NOTIFY_CHAT,					// 聊天
			GAME_NOTIFY_NOTICE,
			
			GAME_NOTIFY_DBFAILED,				// DB保存失败提示,无法在DB进行UPdate.因网络错误导致连接DB失败 客户端提示后结束
			
			GAME_NOTIFY_GAME_LOADING_END,		// 准备完毕
			GAME_NOTIFY_FCM_STATE,
			
			GAME_NOTIFY_GAME_GAIN_ITEM,			// 游戏物品获得结果
			GAME_NOTIFY_GAME_ITEM_USE,			// 使用物品
			GAME_NOTIFY_GAME_ITEM_CASTER_APPLY,	// 将物品效果适用在使用者身上
			GAME_NOTIFY_GAME_ITEM_TARGET_APPLY,	// 目标适用道具效果
			GAME_NOTIFY_GAME_CRASHED_ITEM,		// 角色设置与携带物品冲突
			GAME_NOTIFY_GAME_INFLUENCE_SPEED,	// 因为物品等原因导致速度变化
			GAME_NOTIFY_GAME_LOADING_PROGRESS_VALUE,	// 准备进行状态( % )
			
			GAME_NOTIFY_MONITOR_SERVER_INFO,	// 向监测服务器传达游戏服务器信息
			GAME_NOTIFY_LOGIN,					// 大厅-》登录服务器传达登录信息
			GAME_NOTIFY_LOGOUT,					// 玩家终止游戏时传达的信息
			GAME_NOTIFY_CHANNEL_MOVE,			// 换频道
			
			GAME_NOTIFY_RANK_LIST,				// 传达排名列表信息
			
			GAME_NOTIFY_LEVELUP,				// 传达升级时必要的一些信息
			
			GAME_NOTIFY_GAME_EXPIRE,			// 结束比赛 提示 (游戏服务器->大厅服务器)
			
			GAME_NOTIFY_GAME_LEAVE,				// 在游戏服务器等待 or游戏中退出的情况
			
			GAME_NOTIFY_VLOBBY_ENTER,			// 特定玩家登录大厅 提示
			GAME_NOTIFY_VLOBBY_LEAVE,			// 特定玩家退出大厅 提示
			
			GAME_NOTIFY_GIFT_NEW,				// 提示有新的礼物
			
			GAME_NOTIFY_GAME_HP_CHANGE,			// hp变更信息
			GAME_NOTIFY_GAME_SP_CHANGE,			// sp变更信息
			
			GAME_NOTIFY_VLOBBY_USERINFO,		// 提示入场时已在的玩家信息
			
			GAME_NOTIFY_CHANGE_GRAFFITIMAN,		// 旗帜权限变更提示
			GAME_NOTIFY_INIT_GRAFFITIPOS,		// 将旗帜移动到开始位置
			GAME_NOTIFY_INIT_CHARPOS,			// 将角色移动到开始位置
			
			GAME_NOTIFY_REWARD,					// 奖励 提示 数据, ex) 任务模式完成,新手引导完成
			GAME_NOTIFY_STRIKE_ATTACKED,		// 被STRIKEATTACK时提示
			
			GAME_NOTIFY_ROOM_INVITE,			// 传达给收到邀请的玩家
			GAME_NOTIFY_VISIT_MYROOM,			// 进入房间 提示
			GAME_NOTIFY_LEAVE_MYROOM,			// 离开房间 提示
			
			GAME_NOTIFY_CLUBMATCH_TEAMNAME,		// 在CLUB战变更CLUB名称
			GAME_NOTIFY_CLUBINFO_TO_MSG,		// 向聊天服务器发送CLUB情报
			GAME_NOTIFY_CLUB_INVITATION,		// 邀请到CLUB的提示
			GAME_NOTIFY_GAME_ITEMGAUGE,			// 发送物品GAUGE状态
			GAME_NOTIFY_GAME_LOADING_WAIT,		// 点击游戏开始时发送——（为了向玩家询问是否转换到准备画面）
			GAME_NOTIFY_ROOM_MAX_JOINER_NUM_CHANGE,	// 游戏房间入场玩家数变更
			GAME_NOTIFY_ROOM_MAX_MAP_LAPS_CHANGE, // 游戏房间LAPS数变更提示
			GAME_NOTIFY_MAX_COMBO_USER,			// 特定玩家在 max combo时/ 解除时发送的 数据
			GAME_NOTIFY_USER_NUM,				// 游戏服务器里的玩家数提示
			GAME_NOTIFY_LAPTIME_RESULT, 		// 竞速模式 结果 提示
			GAME_NOTIFY_LAPTIME_EXPIRE,
			GAME_NOTIFY_LAPTIME_RANK_LIST, 		// 竞速模式 排行 提示
			GAME_NOTIFY_EXPIRED_ITEMS, 			// 使用期限已经结束的物品提示
			GAME_NOTIFY_EXPIRED_HOUSINGITEMS, 	// 使用期限已结束的HOUSING物品提示
			GAME_NOTIFY_NEW_HALLOWEEN_DAILY_REWARD, // 新的halloween daily物品提示
			GAME_NOTIFY_ROOM_LIST_PAGE, 		// 在房间列表中提示页面号
			GAME_NOTIFY_ACHIEVEMENT_SUCCESS, 	// 成就成功 提示
			GAME_NOTIFY_ACHIEVEMENT_DEPTH3_GAUGE, // 成就 进行情况
			GAME_NOTIFY_ACHIEVEMENT_DEPTH3_LIST, // 成就 进行情况列表
			GAME_NOTIFY_SKILL_COUNT, 			// 各技能使用次数（为写进成就）
			GAME_NOTIFY_LAPTIME_TOP5_RANK, 		// 竞速模式 top5以内排行提示
			GAME_NOTIFY_SPRAY_ACQUIRE, 			// 喷雾 获得 提示
			GAME_NOTIFY_SPRAY_USE, 				// 喷雾 使用 提示
			GAME_NOTIFY_SPRAY_MISS, 			// 喷雾 掉落 提示
			GAME_NOTIFY_SPRAY_GEN, 				// 喷雾 生成 提示
			GAME_NOTIFY_PAINTING_SCORE, 		// 为了GRAFFITI 的分数提示
			GAME_NOTIFY_GRAFFITI_TIME, 			// GRAFFITI 战时间 提示
			
			GAME_NOTIFY_SHIELDITEM_USE_TIME, 	//盾牌道具维持时间
			GAME_NOTIFY_GRAFFITI_ACQUIRED_SCORE, // GRAFFITI战目前得到的分数提示
			GAME_NOTIFY_ROOM_CREATED,			// 游戏房间生成提示
			GAME_NOTIFY_ROOM_DELETED,			// 游戏房间删除提示
			GAME_NOTIFY_ROOM_UPDATED,			// 游戏房间变更提示
			
			
			////////////////////////////道具 模式//////////////////////////////////
			GAME_NOTIFY_GAME_NEW_ITEM_RESULT,	// 使用物品 提示
			///////////////////////////////////////////////////////////////////////////////
			
			GAME_NOTIFY_GAME_EVENTOBJECT,				
			
			GAME_NOTIFY_GAME_STATUS_START, 		//玩家状态开始!
			GAME_NOTIFY_GAME_STATUS_STOP, 		//玩家状态结束!
			
			GAME_NOTIFY_GAME_START_COUNT, 		//游戏开始倒计时
			GAME_NOTIFY_GAME_COUNT_STOP, 		//游戏开始倒计时
			GAME_NOTIFY_KICKOUT_CLEAR,
			
			///////////////////////////////////////////////////////////////////////////////
			GAME_NOTIFY_GAME_ROOM_STRIKEATTACK_INFO_CHANGE,		//变更房间 有无STRIKEATTACK的信息
			GAME_NOTIFY_HOUSINGITEM_CHANGE,
			GAME_NOTIFY_EVENT_CLOSED,
			GAME_NOTIFY_CHAT_ROOM_SETTING,
			
			GAME_NOTIFY_WHISPER,				// 私聊
			
			GAME_NOTIFY_GAME_EXPIRE_V2,
			
			GAME_NOTIFY_LOBBY_SERVER_TIME,		//LOBBY SERVER TIME
			
			GAME_NOTIFY_MAX_TEAMGAUGE,
			GAME_NOTIFY_CHANGE_MYTEAMGAUGE,
			GAME_NOTIFY_CHANGE_OTHERTEAMGAUGE,
			GAME_NOTIFY_TEAMGAUGE_RESULT,	
			GAME_NOTIFY_TEAMMAXBOOSTER_STOP,	
			
			GAME_NOTIFY_PLAYER_PLAY_TIME,		// 每间隔一个小时发送游戏开始时间.
			
			GAME_NOTIFY_XIGNCOCE,
			
			GAME_NOTIFY_CHAT_MSG,				// 聊天
			GAME_NOTIFY_CHAT_MSG_WHISPER,		// 私聊
			GAME_NOTIFY_CHAT_BLOCK_LIST,		// 聊天模块 列表
			
			
			//GAME_NOTIFY_SIGN_IN,	//zyz每天12点通知可以签到了
					
			//task
			GAME_NOTIFY_TASK_TASK_CHANGE,
			
			GAME_NOTIFY_HIGH_LADDER_CHALLENGE,	//天梯挑战
			GAME_NOTIFY_HIGH_LADDER_GAME_RESULT,
		};

		/*********************************************************************/
		/***** Command : Echo *****/
		public enum eGAME_ECHO
		{
			GAME_ECHO = ServerType.SERVER_TYPE_GAME + PostType.POST_TYPE_ECHO,
			GAME_ECHO_PING,						// ping
			GAME_ECHO_SPEED_HACK,				// SPEED_HACK (S -> C -> S) 努扼捞攫飘俊辑 5檬 第俊 倒妨霖促.
			
			GAME_ECHO_
		};

		/*********************************************************************/
		/***** Command : Request *****/
		public enum eMSG_REQUEST
		{
			MSG_REQUEST = ServerType.SERVER_TYPE_MESSENGER + PostType.POST_TYPE_REQUEST,
			
			MSG_REQUEST_LOGIN_AUTH,						// 邮箱 서버 登录认证
			MSG_REQUEST_ADD_FRIEND,						// 申请添加好友
			MSG_REQUEST_ACCEPT_FRIEND,					// 申请接受好友邀请
			MSG_REQUEST_DELETE_FRIEND,					// 删除好友请求
			MSG_REQUEST_BLOCK_FRIEND,					// 屏蔽好友请求
			MSG_REQUEST_UNBLOCK_FRIEND,					// 解除屏蔽请求
			MSG_REQUEST_MODIFY_MEMO,					// 申请记录变更
			MSG_REQUEST_MULTICHAT_START,				// 多重聊天（3人以上）申请开始（第一次邀请时）
			MSG_REQUEST_MULTICHAT_INVITE,				// 邀请好友
			MSG_REQUEST_MULTICHAT_LEAVE,				//关闭聊天
			MSG_REQUEST_CHAT,							// 大厅,大厅 聊天
			MSG_REQUEST_MYROOM_INFO,					// 查看房间信息（自己的房间信息）
			MSG_REQUEST_MYROOM_POST,					// 炫耀自己的房间
			MSG_REQUEST_MYROOM_LIST,					// 查看房间列表
			MSG_REQUEST_MYROOM_SEARCH,					// 搜索房间
			MSG_REQUEST_MYROOM_VISIT,					// 进入房间
			MSG_REQUEST_MYROOM_USER_INFO,				// 查看其它玩家的房间信息
			MSG_REQUEST_MYROOM_VOTE,					// 推荐房间
			MSG_REQUEST_MYROOM_LEAVE,					// 申请离开房间
			MSG_REQUEST_MY_CLUB_INFOS,					// 申请CLUB信息
			MSG_REQUEST_CLUB_LEAVE,						// 申请退出CLUB
			MSG_REQUEST_CLUB_CHANGE_NOTICE,				// CLUB公告内容变更
			MSG_REQUEST_CLUB_CHANGE_COMMENT,			// CLUB介绍变更
			MSG_REQUEST_CLUB_CHANGE_AUTH,				// CLUB权限变更
			MSG_REQUEST_CLUB_LIST,						// 查看CLUB列表
			MSG_REQUEST_CLUB_SEARCH,					// 申请搜索CLUB
			MSG_REQUEST_CLUB_CHANGE_AUTHNAME,			// CLUB等级名变更
			MSG_REQUEST_CLUB_KICKOUT,					// 强制退出CLUB
			MSG_REQUEST_CLUB_JOIN,						// 申请加入CLUB
			MSG_REQUEST_CLUB_INVITE,					// 申请CLUB邀请
			MSG_REQUEST_CLUB_COMMENT,					// 申请CLUB介绍语
			MSG_REQUEST_CLUB_INVITATION_ACCEPT,			// CLUB邀请信息接受/拒绝
			MSG_REQUEST_DISCONNECT_USER,
		};

		/*********************************************************************/
		/***** Command : Answer *****/
		public enum eMSG_ANSWER
		{
			MSG_ANSWER = ServerType.SERVER_TYPE_MESSENGER + PostType.POST_TYPE_ANSWER,
			
			MSG_ANSWER_LOGIN_AUTH,						// 邮箱服务器登录认证应答
			MSG_ANSWER_ADD_FRIEND,						// 添加好友邀请应答
			MSG_ANSWER_ACCEPT_FRIEND,					// 接受好友邀请应答
			MSG_ANSWER_DELETE_FRIEND,					// 删除好友应答
			MSG_ANSWER_BLOCK_FRIEND,					// 屏蔽好友 回应
			MSG_ANSWER_UNBLOCK_FRIEND,					// 解除屏蔽 回应
			MSG_ANSWER_MODIFY_MEMO,						// 记录变更应答
			MSG_ANSWER_MULTICHAT_START,					// 多重聊天开始应答
			MSG_ANSWER_MULTICHAT_INVITE,				// 邀请好友应答
			MSG_ANSWER_MULTICHAT_LEAVE,					// 退出聊天应答
			MSG_ANSWER_CHAT,							// 大厅,大厅 聊天
			MSG_ANSWER_MYROOM_INFO,						// 查看房间信息应答
			MSG_ANSWER_MYROOM_POST,						// 炫耀我的房间 回应
			MSG_ANSWER_MYROOM_LIST,						// 查看房间列表应答
			MSG_ANSWER_MYROOM_SEARCH,					// 搜索房间应答
			MSG_ANSWER_MYROOM_VISIT,					// 关闭房间访问应答
			MSG_ANSWER_MYROOM_USER_INFO,				// 查看其它玩家的房间信息应答
			MSG_ANSWER_MYROOM_VOTE,						// 推荐房间应答
			MSG_ANSWER_MYROOM_LEAVE,					// 离开房间应答
			MSG_ANSWER_MY_CLUB_INFOS,					// CLUB信息应答
			MSG_ANSWER_CLUB_LEAVE,						// 退出CLUB应答
			MSG_ANSWER_CLUB_CHANGE_NOTICE,				// CLUB公告内容变更应答
			MSG_ANSWER_CLUB_CHANGE_COMMENT,				// CLUB介绍变更应答
			MSG_ANSWER_CLUB_CHANGE_AUTH,				// CLUB权限应答
			MSG_ANSWER_CLUB_LIST,						// CLUB列表应答
			MSG_ANSWER_CLUB_SEARCH,						// 搜索CLUB应答
			MSG_ANSWER_CLUB_CHANGE_AUTHNAME,			// CLUB等级名变更 回应
			MSG_ANSWER_CLUB_KICKOUT,					// 强制退出CLUB
			MSG_ANSWER_CLUB_JOIN,						// 应答申请加入CLUB
			MSG_ANSWER_CLUB_INVITE,						// CLUB邀请应答
			MSG_ANSWER_CLUB_COMMENT,					// CLUB介绍语应答
			MSG_ANSWER_CLUB_INVITATION_ACCEPT,			// CLUB邀请信息接受/拒绝应答
		};
		
		/*********************************************************************/

		public enum eMSG_NOTIFY
		{
			MSG_NOTIFY = ServerType.SERVER_TYPE_MESSENGER + PostType.POST_TYPE_NOTIFY,
			
			MSG_NOTIFY_FRIEND_LIST,						// 好友列表提示
			MSG_NOTIFY_FRIEND_REQUESTS,					// 别人给自己发送的还有邀请列表提示
			MSG_NOTIFY_FRIEND_STATE,					// 好友状态提示
			MSG_NOTIFY_MULTICHAT_START,					// 多重聊天开始提示
			MSG_NOTIFY_MULTICHAT_INVITED,				// 自己被邀请聊天时的提示
			MSG_NOTIFY_MULTICHAT_INVITE_FRIEND,			// 其他人被邀请聊天时的提示
			MSG_NOTIFY_MULTICHAT_LEAVE,					// 退出聊天提示
			MSG_NOTIFY_LEVELUP,							// 升级 提示
			MSG_NOTIFY_CHARSELECT,						// 角色变更 提示
			MSG_NOTIFY_CHAT,							// 大厅，大厅 聊天 提示
			MSG_NOTIFY_MYROOM_LIST,						// 房间列表信息 提示
			MSG_NOTIFY_MYROOM_SEARCH,					// 搜索房间 提示
			MSG_NOTIFY_CLUB_MEMBERS,					// CLUB人员列表 提示
			MSG_NOTIFY_CLUB_LIST,						// CLUB列表提示
			MSG_NOTIFY_CLUB_SEARCH,						// 搜索CLUB 提示
			MSG_NOTIFY_CLUBMEMBER_LIST,					// 提示CLUB人员目录
			MSG_NOTIFY_CLUB_AUTH_LEVEL_NAME,			// 提示CLUB等级名称
			MSG_NOTIFY_CLUB_LEAVE,						// 提示已退出CLUB
			MSG_NOTIFY_CLUB_JOIN,						// 提示已加入CLUB.（对已加入的人）
			MSG_NOTIFY_CLUB_INVITED,					// 提示已被CLUB邀请
		};		

		/***** Command : Echo *****/
		public enum eMSG_ECHO
		{
			MSG_ECHO = ServerType.SERVER_TYPE_MESSENGER + PostType.POST_TYPE_ECHO,
			MSG_ECHO_UPDATE_POSITION_STATE, 			// 玩家位置信息提示 (lobby -> messenger)
			MSG_ECHO_GIFT,								// 赠送礼物信息提示 (lobby -> messenger)
			MSG_ECHO_CHAT,								// 两人聊天时的信息
			MSG_ECHO_MULTICHAT,							// 三人以上聊天时的信息
			MSG_ECHO_CHANNEL_MOVE,						// 换频道提示 (lobby -> messenger)
			MSG_ECHO_LEVELUP,							// 升级信息提示 (lobby -> messenger)
			MSG_ECHO_CLUBCHAT,							// CLUB聊天信息
			MSG_ECHO_SERVERINFO,						// 服务器信息提示(div, channel)
			MSG_ECHO_MYROOMCHAT,						// 在房间里聊天
			MSG_ECHO_
		};

		/*********************************************************************/
		/***** Command : Request *****/
		public enum eMSGRELAY_REQUEST
		{
			MSGRELAY_REQUEST = ServerType.SERVER_TYPE_MESSENGER_RELAY + PostType.POST_TYPE_REQUEST,
			MSGRELAY_REQUEST_LOGIN,				// 玩家的登录提示
			MSGRELAY_REQUEST_LOGOUT,			// 玩家的登录退出提示
			MSGRELAY_REQUEST_SENDPACKET,		// 给特定玩家发送数据请求
			MSGRELAY_REQUEST_MULTICHAT_START,	// 多重聊天开始时发送(邮箱->邮箱连续)
			MSGRELAY_REQUEST_MULTICHAT_INVITE,	// 邀请参加多重聊天
			MSGRELAY_REQUEST_MULTICHAT_LEAVE,	// 结束多重聊天
			MSGRELAY_REQUEST_MULTICHAT_MSG,
			MSGRELAY_REQUEST_ROOM_JOIN,			// 申请访问房间	
			MSGRELAY_REQUEST_ROOM_LEAVE,		// 申请退出房间	
			MSGRELAY_REQUEST_ROOM_USERINFO,		// 申请房间内的玩家信息
			MSGRELAY_REQUEST_ROOM_KICKOUT,		// 申请强制退出房间
			MSGRELAY_REQUEST_CLUB_BROADCAST,	// CLUB - BROADCAST
			MSGRELAY_REQUEST_CLUB_CHAT,			// CLUB - 聊天
			MSGRELAY_REQUEST_CLUB_NOTIFYSTATE,	// CLUB - 申请状态信息
			MSGRELAY_REQUEST_MULTICHAT_EXPIRE,	// 申请删除聊天房间
			MSGRELAY_REQUEST_LOBBY_AUTH,		// 连接大厅服务器认证申请
			MSGRELAY_REQUEST_CREATE_ROOM,		// 申请游戏房间生成
			MSGRELAY_REQUEST_USER_INFO,			// 申请玩家信息
			MSGRELAY_REQUEST_LOBBY_CHAT,		// 申请大厅聊天
			MSGRELAY_REQUEST_LOBBY_TO_GAME,		// 大厅->游戏 数据连续 请求
			MSGRELAY_REQUEST_GAME_TO_LOBBY,		// 游戏->大厅 数据连续 请求
			MSGRELAY_REQUEST_ROOM_INVITE,		// 邀请到游戏房间
			MSGRELAY_REQUEST_CHAT_MSG,		// 聊天
			MSGRELAY_REQUEST_LOBBY_CHAT_WHISPER,		// 私聊
			MSGRELAY_REQUEST_LOBBY_USER_TASK,
			MSGRELAY_REQUEST_LOBBY_SEND_ENCRYPT,//[lobby发送key给game]
			
			//fcm
			MSGRELAY_REQUEST_LOBBY_FCM,
		};
		
		/*********************************************************************/
		/***** Command : Answer *****/
		public enum eMSGRELAY_ANSWER
		{
			MSGRELAY_ANSWER = ServerType.SERVER_TYPE_MESSENGER_RELAY + PostType.POST_TYPE_ANSWER,
			MSGRELAY_ANSWER_LOGIN,
			MSGRELAY_ANSWER_LOGOUT,
			MSGRELAY_ANSWER_SENDPACKET,
			MSGRELAY_ANSWER_MULTICHAT_START,
			MSGRELAY_ANSWER_MULTICHAT_INVITE,
			MSGRELAY_ANSWER_MULTICHAT_LEAVE,
			MSGRELAY_ANSWER_MULTICHAT_MSG,
			MSGRELAY_ANSWER_ROOM_JOIN,		// 回应访问我的房间
			MSGRELAY_ANSWER_ROOM_LEAVE,		// 回应退出我的房间
			MSGRELAY_ANSWER_ROOM_USERINFO,	// 回应我的房间我的玩家信息申请
			MSGRELAY_ANSWER_CLUB_BROADCAST,	// 回应CLUB - BROADCAST 
			MSGRELAY_ANSWER_CLUB_CHAT,		// 回应CLUB聊天
			MSGRELAY_ANSWER_CLUB_NOTIFYSTATE,	// 回应CLUB-状态信息申请
			MSGRELAY_ANSWER_MULTICHAT_EXPIRE,	// 回应聊天房删除信息
			MSGRELAY_ANSWER_LOBBY_AUTH,
			MSGRELAY_ANSWER_CREATE_ROOM,
			MSGRELAY_ANSWER_USER_INFO,
			MSGRELAY_ANSWER_LOBBY_CHAT,
			MSGRELAY_ANSWER_LOBBY_TO_GAME,
			MSGRELAY_ANSWER_GAME_TO_LOBBY,
			MSGRELAY_ANSWER_ROOM_INVITE,
			MSGRELAY_ANSWER_LOBBY_CHAT_WHISPER,
			MSGRELAY_ANSWER_GAME_LOST,
			MSGRELAY_ANSWER_GAME_NUM,
		};
		
		/*********************************************************************/
		/***** Command : Notify *****/
		public enum eMSGRELAY_NOTIFY
		{
			MSGRELAY_NOTIFY = ServerType.SERVER_TYPE_MESSENGER_RELAY + PostType.POST_TYPE_NOTIFY,
			MSGRELAY_NOTIFY_SENDPACKET,		//给特定玩家发送数据提示
			MSGRELAY_NOTIFY_MULTICHAT_MSG,
			MSGRELAY_NOTIFY_ROOM_CREATED,	// 游戏房间生成提示
			MSGRELAY_NOTIFY_ROOM_DELETED,	// 游戏房间删除提示
			MSGRELAY_NOTIFY_ROOM_UPDATED,	// 游戏房间变更提示
			MSGRELAY_NOTIFY_RELAY_GAME_TO_LOBBY, // 游戏服务器向大厅服务器传达信息提示
			MSGRELAY_NOTIFY_RELAY_LOBBY_TO_GAME, // 大厅服务器向游戏服务器传达信息提示
			MSGRELAY_NOTIFY_CHAT_MSG,		// 聊天
			
		};

		public enum eRELAY_ECHO
		{
			RELAY =  ServerType.SERVER_TYPE_RELAY +  PostType.POST_TYPE_ECHO,
			
			// 同步 相关
			RELAY_ECHO,
			RELAY_ECHO_VLOBBY,
			RELAY_ECHO_EVENT,
			RELAY_ECHO_ROTATION_BEGIN,		// 开始旋转
			RELAY_ECHO_ROTATION_END,		// 旋转结束
			RELAY_ECHO_ACC_BEGIN,			// 开始加速
			RELAY_ECHO_DEACC_BEGIN,			// 开始减速
			RELAY_ECHO_PING,
			RELAY_ECHO_FLOAT1,
			RELAY_ECHO_FLOAT2,
			RELAY_ECHO_FLOAT3,
			RELAY_ECHO_STRING,
			RELAY_ECHO_EVENT_VLOBBY,
			RELAY_ECHO_KEEPALIVE,			// KEEPALIVE 数据
			// sofa slot相关的 relay packet
			RELAY_ECHO_SOFA_SLOT,
			RELAY_ECHO_POSITION,
			RELAY_ECHO_LANDING,
			
			RELAY_
		};

		
	}

   



 
}
 
