using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace com.iuixi.FreeJeck
{
	public class ViewModal : MonoBehaviour
	{
		public void AddModal()
		{
			GameObject obj = Instantiate(Resources.Load("ui/loading/loading_sync")) as GameObject;
			GameObject canvas = GameObject.FindGameObjectWithTag("MainUI");
			GameObject button = obj.transform.FindChild("yellow_man0005").gameObject;
			button.transform.parent = canvas.transform;
			button.transform.localPosition = Vector3.zero;
			button.transform.localScale = Vector3.one;
			
			GameObject AObj = canvas.transform.FindChild("forgetButton").gameObject;
			
			button.transform.SetSiblingIndex(AObj.transform.GetSiblingIndex());
		}

		public void RemoveModal()
		{

		}
	}
}

