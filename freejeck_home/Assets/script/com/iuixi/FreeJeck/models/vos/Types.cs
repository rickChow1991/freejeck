using UnityEngine;
using System.Collections;

namespace com.iuixi.FreeJeck.Types
{
	namespace ShopItems
	{
		public enum Category
		{
			AVATAR = 1,
		}

		public enum SubCategory
		{
			HAIR = 1,
			UPPER=2,
			LOWER=3,
			SHOE=4,
		}

		public class entry
		{
			/// <summary>
			///  预留,商城表
			/// </summary>
			/// <value><c ;</c></value>
			public int type {get; set;}
			/// <summary>
			///  这个物品是否可用
			/// </summary>
			/// <value><c ;</c></value>
			public int use {get; set;}
			/// <summary>
			///  序列号,ID
			/// </summary>
			/// <value><c ; </c></value>
			public uint uiIndex {get; set;}
			/// <summary>
			///  物品名称
			/// </summary>
			/// <value><c ;</c></value>
			public string szName {get; set;}
			/// <summary>
			///  分类
			/// </summary>
			/// <value><c ;</c></value>
			public byte ucCategory {get; set;}
			/// <summary>
			/// 子分类
			/// </summary>
			/// <value><c ;</c></value>
			public byte ucSubCategory {get; set;}
			/// <summary>
			/// 可以使用物品的角色性别
			/// </summary>
			/// <value><c ;</c></value>
			public byte ucGender {get; set;}
			/// <summary>
			///  可以使用该物品的角色
			/// </summary>
			/// <value><c ;</c></value>
			public byte ucCharacter {get; set;}
			/// <summary>
			/// 是否上架
			/// </summary>
			/// <value><c ;</c></value>
			public byte ucSelling {get; set;}
//			/// <summary>
//			///  G币价格, 第一档时效的价格
//			/// </summary>
//			/// <value><c ;</c></value>
			public uint uiJack1 {get; set;}
//			/// <summary>
//			/// 第二档时效的g币价格
//			/// </summary>
//			/// <value><c ;</c></value>
			public uint uiJack2 {get; set;}
//			/// <summary>
//			///  第三档时效的g币价格
//			/// </summary>
//			/// <value><c ;</c></value>
			public uint uiJack3 {get; set;}
//			/// <summary>
//			///  第一档时效的m币价格
//			/// </summary>
//			/// <value><c ;</c></value>
			public uint uiCash1 {get; set;}
//			/// <summary>
//			///  第二档时效的m币价格
//			/// </summary>
//			/// <value><c ;</c></value>
			public uint uiCash2 {get; set;}
//			/// <summary>
//			///  第三档时效的m币价格
//			/// </summary>
//			/// <value><c ;</c></value>
			public uint uiCash3 {get; set;}
//			
//			public uint uiAttritionType {get; set;}
//			public uint uiContribution1 ;
//			public uint uiContribution2 ;
//			public uint uiContribution3 ;
//			public uint uiDuration1 ;
//			public uint uiDuration2 ;
//			public uint uiDuration3 ;
//			public uint uiStock1 ;
//			public uint uiStock2 ;
//			public uint uiStock3 ;
//			public byte ucHot ;
//			public byte ucNew ;
//			public byte ucEmblem ;
//			public byte ucHyper ;
//			public byte ucExtraInfo1 ;
//			public byte ucExtraInfo2 ;
//			public byte usLevelLimit ;
//			public string ItemLevel ;
//			public uint usClubLevel ;
//			public string Ability1 ;
//			public string Ability2 ;
//			public string Socket ;
//			public string MaxSocket ;
//			public uint uiDefault ;
//			public int uiFace ;
//			public int uiSkinColor ;
//			public uint uiEquip ;
//			public string Utility ;
//			public string Sequence ;
			public string szItemNif ;
			public string szItemTex ;
			public string szDPiconimg ;
			public string szDPText ;
		}
		
		public struct ShopItem
		{
			public entry[] g_ShopItem;
		}
		
		public struct ShopItemSpace
		{
			public ShopItem ShopItem;
		}
	}
}