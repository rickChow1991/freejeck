// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace com.iuixi.FreeJeck
{
	using Types.ShopItems;
	public class ShopGrid : TableGrid<entry, ShopCell>,IShopTip
	{
		private ShopModel shopModel;
		private List<entry> EntryHair;
		private List<entry> EntryCloth;
		private List<entry> EntryTrousers;
		private List<entry> EntryShoe;
		private Sprite Cloth;
		private static int s_SubCategory;

		[SerializeField] private  GameObject tip;
		[SerializeField] private  Text  tipname;
		[SerializeField] private  Text  tipdelname;
		[SerializeField] private  Text seven_days;
		[SerializeField] private  Text fifty_days;
		[SerializeField] private  Text thirty_days;
		[SerializeField] private  Image tipImage;
	
		public static int SubCtg{
			get{
				return s_SubCategory;
			}
		} 
	
		void Start()
		{
			Cloth=Resources.Load<Sprite>("ui/cloth");
			shopModel = Singletons.GET<ShopModel>();
			InitCells();
			EntryHair=shopModel.GetEntrysBySubCategory(Category.AVATAR, SubCategory.HAIR); 
			EntryCloth=shopModel.GetEntrysBySubCategory(Category.AVATAR, SubCategory.UPPER);
			EntryTrousers=shopModel.GetEntrysBySubCategory(Category.AVATAR, SubCategory.LOWER);
			EntryShoe=shopModel.GetEntrysBySubCategory(Category.AVATAR, SubCategory.SHOE);
			SetDataProvider(EntryHair);

		}

		public void SwitchSubCatetory(int index)
		{
			s_SubCategory=index;
			switch (index)
			{
				case 1:
					SetDataProvider(EntryHair);
					break;
				case 2:
					SetDataProvider(EntryCloth);
					break;
				case 3:
					SetDataProvider(EntryTrousers);
					break;
				case 4:
					SetDataProvider(EntryShoe);
					break;
			}
		}

		public void ShowTip()
		{
			tip.SetActive(true);
		}

		public void HideTip()
		{
			tip.SetActive(false);
		}

		public void TipMsg(int i)
		{
		  	switch (i)
			{	
				case 0:
				tip.GetComponent<RectTransform>().localPosition =new Vector3(-444,62,0);
				break;
				case 1:
				tip.GetComponent<RectTransform>().localPosition =new Vector3(-755,62,0);
				break;
				case 2:
				tip.GetComponent<RectTransform>().localPosition =new Vector3(-616,62,0);
				break;
				case 3:
				tip.GetComponent<RectTransform>().localPosition =new Vector3(-444,-94,0);
				break;
				case 4:
				tip.GetComponent<RectTransform>().localPosition =new Vector3(-755,-94,0);
				break;
				case 5:
				tip.GetComponent<RectTransform>().localPosition =new Vector3(-616,-94,0);
				break;
		   }
			tipname.text=dataProvider[start + i].szName;
			tipdelname.text=dataProvider[start + i].szDPText;
			tipImage.sprite=Cloth;
			seven_days.text=dataProvider[start + i].uiCash1.ToString();
			fifty_days.text=dataProvider[start + i].uiCash2.ToString();
			thirty_days.text=dataProvider[start + i].uiCash3.ToString();
		}

		public Sprite IconSprite()
		{
			return tipImage.sprite;
		}

		public string SevenDaysCash()
		{

			return seven_days.text;
		}
	}
}

