using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
namespace com.iuixi.FreeJeck
{
	public class Meau<T> : MonoBehaviour 
		where T: MonoBehaviour
	{

		// Use this for initialization
		private bool Show_T=false;
		private bool Enter_T=false;
		protected  List<T> m_Children;
		protected void  Init()
		{
			m_Children = new List<T> ();
			T tmp=transform.GetComponentInChildren<T>();
			if(tmp == null)
			{
				throw new Exception("Error");
			}
			m_Children.Add(tmp);
	
			tmp.gameObject.SetActive(false);
		
		}

		public void ShowT()
		{
			Show_T=!Show_T;
			
			if(Show_T)
				foreach (var item in m_Children) {
					item.gameObject.SetActive(true);
				}
				
			else
				foreach (var item in m_Children) {
					item.gameObject.SetActive(false);
				}
				
		}

		public void EnterT()
		{
			Enter_T=!Enter_T;
			
			if(Enter_T)
			foreach (var item in m_Children) {
				item.gameObject.SetActive(true);
			}
			
			else
			foreach (var item in m_Children) {
				item.gameObject.SetActive(false);
			}
			
		}

		
	
	}
}