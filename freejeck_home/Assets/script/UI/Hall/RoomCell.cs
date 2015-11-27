using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Common;
namespace com.iuixi.FreeJeck
{
	public class RoomCell : TableCell<cs_RoomInfo> 
	{

		// Use this for initialization
		private int RoomIndex;
		private Sprite enterRoom;
		private Sprite exitRoom;
		[SerializeField]private RoomGrid roomContain;
		[SerializeField]private Image m_Ge;
		[SerializeField]private Image m_Shi;
		[SerializeField]private Image m_Bai;
		[SerializeField]private Image Lock;
		[SerializeField]private GameObject Strike;

			
		void Start () {

		}
		void  Awake(){
			enterRoom=Resources.Load<Sprite>("man3"); 
			exitRoom=Resources.Load<Sprite>("man1"); 
		}
		// Update is called once per frame
		void Update () {
		
		}
		override public void Render (cs_RoomInfo data)
		{
			m_Ge.sprite=Instantiate(Resources.Load<Image>("cnt/"+data.roomNo%10).sprite)as Sprite ;
			m_Shi.sprite=Instantiate(Resources.Load<Image>("cnt/"+data.roomNo/10%10).sprite)as Sprite ;
			m_Bai.sprite=Instantiate(Resources.Load<Image>("cnt/"+data.roomNo/100%10).sprite)as Sprite ;

			transform.FindChild ("RoomName").GetComponent<Text>().text =Tools.Readchar(data.name);
			transform.FindChild ("percet").GetComponent<Text>().text=string.Format("{0}/{1}",data.joinerNum,data.maxJoinerNum);
			for(int i=0;i<data.maxJoinerNum;i++)
				transform .FindChild("curplayerctn").FindChild("Player"+i).gameObject.SetActive(true);
			for(int i=data.maxJoinerNum;i<8;i++)
				transform .FindChild("curplayerctn").FindChild("Player"+i).gameObject.SetActive(false);
	
			for(int i=1;i<data.joinerNum;i++)
				transform .FindChild("curplayerctn").FindChild("Player"+i).GetComponent<Image>().sprite=enterRoom ;
			for(int i=data.joinerNum;i<data.maxJoinerNum;i++)
				transform .FindChild("curplayerctn").FindChild("Player"+i).GetComponent<Image>().sprite=exitRoom ;
			if(data.bStrikeAttack==0)
				transform.FindChild("Collider").GetComponent<Image>().enabled=false;
			else if(data.bStrikeAttack==1)
				transform.FindChild("Collider").GetComponent<Image>().enabled=true;

			if(data.password==1)
				Lock.enabled=true;

			if(data.password==0)
				Lock.enabled=false;
		
			if(data.bStrikeAttack==1)
				Strike.SetActive(true);

			if(data.bStrikeAttack==0)
				Strike.SetActive(false);

		//	transform.FindChild ("icon").GetComponent<Image> ().sprite=Cloth;
		}
		//点击房间面板进入房间
		public void EnterGameRoom()
		{
			//通过每个面板上面的shopcell来找到其下的面板名称来转换成索引
			RoomIndex=int.Parse(transform.GetComponentInChildren<BoxCollider>().name);
			roomContain.GameRoom(RoomIndex);
			print("点击加入");
			//.TipMsg(goodsIndex);
				
		}
	}
}