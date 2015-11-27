using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace com.iuixi.FreeJeck
{
	using Types.ShopItems;
	public class ShopCell : TableCell<entry>
	{
		private int goodsIndex;
		public  entry data;
		private bool show=false ;
		private IShopTip shoptip;
		private Sprite Cloth;
		// Use this for initialization
		void  Awake(){

		}
		void Start ()
		{
			Cloth=Resources.Load<Sprite>("ui/cloth");
			shoptip=GameObject.Find ("container").GetComponent<IShopTip>();

		
		}
	
		override public void Render (entry data)
		{
			this.data = data;
			transform.FindChild ("name0").GetComponent<Text> ().text = data.szName;
			transform.FindChild ("price").GetComponent<Text> ().text=data.uiCash1.ToString ();
			transform.FindChild ("icon").GetComponent<Image> ().sprite=Cloth;
		}
		public void Tip()
		{
			//通过每个面板上面的shopcell来找到其下的面板名称来转换成索引
			goodsIndex=int.Parse(transform.GetComponentInChildren<BoxCollider>().name);
			show=!show;
			if(show)
			{
				shoptip.ShowTip();
				shoptip.TipMsg(goodsIndex);
  
			}		
			else
				shoptip.HideTip();			
		}
				// Update is called once per frame
		void Update ()
		{
	
		}

		override public float GetWidth ()
		{
			return GetComponent<RectTransform> ().rect.width;
		}

		override public float GetHeight ()
		{
			return GetComponent<RectTransform> ().rect.height;
		}

		public void ToolTip()
		{
			Debug.Log(data.szName);
		}
	}

}