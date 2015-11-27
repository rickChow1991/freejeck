﻿// ------------------------------------------------------------------------------
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
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace com.iuixi.FreeJeck
{

	public class NameGrid<T, B> : MonoBehaviour
		where B: TableCell<T>, new ()
	{

	
		public GameObject FirstCell;
		public int maxCells;
		protected  int start;
		protected List<T> dataProvider;
		
		protected List<B> cells;
		
		private int maxPages;
		private int currentPage;

		
		//计算个位十位百位的页数


		
		public void SetDataProvider(List<T> dp)
		{
			
			this.dataProvider = dp;
			if(dp.Count < maxCells )
			{

				maxPages = 1;
				currentPage = 0;
			}
			else
			{
				maxPages = dp.Count / (maxCells)+1;//加上最后一页
				currentPage = 0;
			}
			RenderCells();
		}
		
		private void RenderCells()
		{
			//Debug.Log(dataProvider.Count);
			start = currentPage * maxCells;
			int max = Math.Min(maxCells, dataProvider.Count - start);
			if(cells.Count > max)
			{
				int i = 0;
				for (; i < max; i++) 
				{
					cells[i].gameObject.SetActive(true);
					cells[i].Render(dataProvider[start + i]);
				}
				for(; i < cells.Count; i++)
				{
					cells[i].gameObject.SetActive(false);
				}
			}
			else
			{
				for(int i = 0; i < max; i++)
				{
					cells[i].gameObject.SetActive(true);
					cells[i].Render(dataProvider[start + i]);
				}
			}
			//	SortCells();

		}
		
		protected void InitCells ()
		{
			if(FirstCell == null)
			{
				throw new Exception("FirstCell is not assigned");
			}
			cells = new List<B> ();
			cells.Add(GetCellController(FirstCell));
			GameObject obj;
			for (int i = 1; i  < maxCells; i++) {
				obj = Instantiate<GameObject>(FirstCell);
				obj.transform.SetParent(FirstCell.transform.parent);
				obj.transform.position = FirstCell.transform.position;
				obj.transform.rotation = FirstCell.transform.rotation;
				obj.transform.localScale = FirstCell.transform.localScale;
				cells.Add(GetCellController(obj));
			}
			
		
		}
		

		private B GetCellController(GameObject obj)
		{
			B tmp = obj.GetComponent<B>();
			if(tmp == null)
			{
				throw new Exception("Error");
			}
			tmp.transform.gameObject.SetActive(false);
			return tmp;
		}
	}
}
