using UnityEngine;
using System.Collections;
using System ;
namespace com.iuixi.FreeJeck
{
	public interface IShopTip{

		/// <summary>
		/// Shows the tip.
		/// </summary>
		void ShowTip();

		/// <summary>
		/// Hides the tip.
		/// </summary>
		void HideTip();

		/// <summary>
		/// Tips the message.
		/// </summary>
		/// <param name="index">Index.</param>
		void TipMsg(int index);

		/// <summary>
		/// Icons the sprite.
		/// </summary>
		/// <returns>The sprite.</returns>
		Sprite IconSprite();
	
		/// <summary>
		/// Sevens the days cash.
		/// </summary>
		/// <returns>The days cash.</returns>
		string SevenDaysCash();
	}
}