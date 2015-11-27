using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Cmdlib;
using UnityEngine .UI;
using UnityEngine.EventSystems;
using com.iuixi.FreeJeck.Types.ShopItems;
namespace com.iuixi.FreeJeck
{
	public class ShopController : MonoBehaviour {
		
		private IShopTip  WearThing;
		private GameObject _list;
		private int count=0;
		private int leftbtnClickCount=0;
		private int rightbtnClickCount=0;
		private int intCash;
		//装备系统
		private Image[] wear=new Image[7];
		private Image[] bg=new Image[7];
		private Image yangban;
		
		//翻页按钮
		[SerializeField] private Button buy_go;
		[SerializeField] private Button buy_back;
		[SerializeField] private Text totalCash;

		
		[SerializeField] private List<GameObject> buycar;
		
		void Start ()
		{
			WearThing=GameObject.Find ("container").GetComponent<IShopTip>();
			buycar =new List<GameObject>(); 
			for (int i = 0,j=1; i < 7; i++,j++) {
				wear[i]=GameObject.Find ("wear"+i).GetComponent<Image>();
				bg[i]=GameObject.Find ("bg"+j).GetComponent<Image>();
			}
			yangban =GameObject.Find("yangban").GetComponent<Image>();

		}
		void Update () {

		}
		public void Wear(){

			if(ShopGrid.SubCtg==1)
			{
				wear [0].enabled=true;
				wear [0].sprite=WearThing.IconSprite ();
				bg[0].sprite=yangban.sprite;
				
			}
			if(ShopGrid.SubCtg==2)
			{
				wear [1].enabled=true;
				wear [1].sprite=WearThing.IconSprite ();
				bg[1].sprite=yangban.sprite;
			}
			if(ShopGrid.SubCtg==3)
			{
				wear [2].enabled=true;
				wear [2].sprite=WearThing.IconSprite ();
				bg[2].sprite=yangban.sprite;
			}
			if(ShopGrid.SubCtg==4)
			{
				wear [3].enabled=true;
				wear [3].sprite=WearThing.IconSprite ();
				bg[3].sprite=yangban.sprite;
			}

		}
		//购物车按钮
		void Buy()
		{
			_list=Instantiate (Resources.Load<GameObject>("goods"));
			_list.transform.SetParent(GameObject.Find("buycar").transform);
			_list.transform.localScale=Vector3.one;
			_list.transform.FindChild("cargo").GetComponent<Image>().sprite=WearThing.IconSprite();
			intCash +=int.Parse(WearThing.SevenDaysCash());
			totalCash.text=intCash.ToString();
			buycar.Add(_list);
			if(count >=4)
			{
				buy_go.interactable=false;
				if(leftbtnClickCount>0)
				{
					for(;leftbtnClickCount-rightbtnClickCount>=0;leftbtnClickCount--)
					{
						buycar[count-4-leftbtnClickCount+rightbtnClickCount].SetActive(false);
						buycar[count-1-leftbtnClickCount+rightbtnClickCount].SetActive(true);
					}
					buy_back.interactable=true;
				}
				else
				{
					buy_back.interactable=true;
					buycar[count-4].SetActive(false);
				}
			}
			
			if(leftbtnClickCount-rightbtnClickCount<0)
			{
				leftbtnClickCount=0;
				rightbtnClickCount=0;
			}
			
			count ++;
		}
		//购物车向后翻页按钮
		void RightBtn()
		{
			
			if(leftbtnClickCount>1)
			{
				buycar[count-5-(leftbtnClickCount-1)+rightbtnClickCount].SetActive(false);
				buycar[count-1-(leftbtnClickCount-1)+rightbtnClickCount].SetActive(true);
			}
			else
			{
				buycar[count-5].SetActive(false);
				buycar[count-1].SetActive(true);
			}
			
			rightbtnClickCount++;
			if(leftbtnClickCount<=rightbtnClickCount)
				buy_go.interactable=false;
			if(rightbtnClickCount>0)
				buy_back.interactable=true;
		}
		//购物车向前翻页按钮
		void LeftBtn()
		{
			if(leftbtnClickCount>0)
			{	
				buycar[count-5-leftbtnClickCount+rightbtnClickCount].SetActive(true);
				buycar[count-1-leftbtnClickCount+rightbtnClickCount].SetActive(false);
			}
			else
			{
				buycar[count-5].SetActive(true);
				buycar[count-1].SetActive(false);
			}
			if(count>4)
				buy_go.interactable=true;
			if(count-5-leftbtnClickCount+rightbtnClickCount<=0)
				buy_back.interactable=false;
			leftbtnClickCount++;
		}
		//清空购物车按钮
		void ClearBtn()
		{
			foreach(var item in buycar)
				Destroy(item.gameObject);
			buycar.Clear();
			count =0;
			leftbtnClickCount=0;
			rightbtnClickCount=0;
			intCash =0;
			totalCash.text="0";
			buy_back.interactable =false ;
			buy_go.interactable =false ;
			Resources.UnloadUnusedAssets();
			
		}
	}
}