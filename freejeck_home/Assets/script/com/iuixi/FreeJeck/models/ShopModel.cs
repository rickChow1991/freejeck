using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Xml;
using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace com.iuixi.FreeJeck
{
	using Types.ShopItems;

	/// <summary>
	/// ClassName:ShopModel
	/// Date:Wed Apr 29 16:15:05 2015
	/// Author: albin
	/// Description: 商城的model
	/// </summary>
	public class ShopModel
	{
		public  entry[] entrys;
		private Dictionary<uint, entry> indexed;
		private Dictionary<string,entry> byname;
		private Dictionary<int, List<entry>> byCategory;
		private Dictionary<int, List<entry>> bySubCategory;
		public ShopModel ()
		{
			TextAsset txt = Resources.Load<TextAsset> ("settings/ShopItem");
			XmlSerializer xs = new XmlSerializer (typeof(ShopItem));   
			MemoryStream memoryStream = new MemoryStream (txt.bytes);   
			XmlTextWriter xmlTextWriter = new XmlTextWriter (memoryStream, Encoding.UTF8);   
			ShopItem shop;
			try {
				shop = (ShopItem)xs.Deserialize (memoryStream); 
				entrys = shop.g_ShopItem;
			} catch (OverflowException e) {
				Debug.Log (e.Data.ToString ());
				Debug.Log (e.Source);
				Debug.Log (e.ToString ());
				Debug.Log (e.Message);
				Debug.Log (e.StackTrace);
			}
			 
			indexed = new Dictionary<uint, entry> ();
			byname =new Dictionary<string,entry>();
			byCategory = new Dictionary<int, List<entry>>();
			bySubCategory = new Dictionary<int, List<entry>>();
		}

		public entry GetItemByIndex (int index)
		{
			if (indexed.ContainsKey ((uint)index)) {
				return indexed [(uint)index];
			}
			foreach (var item in entrys) {
				if (item.uiIndex == index) {
					indexed.Add ((uint)index, item);
					return item;
				}
			}
			return new entry ();
		}
		public entry GetItemByName(string name)
		{
			if(byname.ContainsKey ((string)name))
				return byname [(string)name];
			foreach (var item in entrys) {
				if (item.szName == name) {
					byname.Add ((string)name, item);
					return item;
				}
			}
			return new entry ();
		}

		public List<entry> GetEntrysByCategory(Category ec)
		{
			int c = (int)ec;
			if(byCategory.ContainsKey(c))
				return byCategory[c];
			List<entry> result = new List<entry>();
			foreach (var item in entrys) {
				if(item.ucCategory == c) {
					result.Add(item);
				}
			}
			byCategory.Add(c, result);
			return result;
		}

		public List<entry> GetEntrysBySubCategory(Category ec, SubCategory esubc)
		{
			int c = (int)ec;
			int subc =(int)esubc;
			if(bySubCategory.ContainsKey(c * 100 + subc))
				return bySubCategory[c*100+subc];
			List<entry> cs = GetEntrysByCategory(ec);
			List<entry> result = new List<entry>();
			foreach (var item in cs) {
				if(item.ucSubCategory == subc)
					result.Add(item);
			}
			bySubCategory.Add(c*100+subc, result);
			return result;
		}
	}
}