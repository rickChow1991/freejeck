using UnityEngine;
using System.Collections;
using System ;
namespace com.iuixi.FreeJeck
{
	public class ChangeInterface : MonoBehaviour {

		[SerializeField] private GameObject Shop;
		[SerializeField] private GameObject MyModel;
		[SerializeField] private GameObject MyMsg;
		[SerializeField] private GameObject GameRoom;
		// Use this for initialization
		void Start () {

		}
		
		// Update is called once per frame
		void Update () {
		if(MyMsg.active||Shop.active)
				MyModel.SetActive(true);
		}
		public void ShowShop(){
			Shop.SetActive(true);
			//MyModel.SetActive(true);
			MyMsg.SetActive(false);
			GameRoom.SetActive(false);

		}
		public void ShowMyMsg(){
			//MyModel.SetActive(true);
			MyMsg.SetActive(true);
		}
		public void ShowGameRoom(){
			Shop.SetActive(false);
			MyModel.SetActive(false);
			MyMsg.SetActive(false );
			GameRoom.SetActive(true);
		}
		public void CloseBtn()
		{
			MyMsg.SetActive(false );
			MyModel.SetActive(false);
		}
	}
}