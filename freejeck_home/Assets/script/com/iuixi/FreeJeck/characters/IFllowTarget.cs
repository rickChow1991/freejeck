using System;

namespace com.iuixi.FreeJeck
{
	public interface IFllowTarget
	{
		/// <summary>
		/// Gets the current speed.
		/// </summary>
		/// <returns>The current speed.</returns>
		float GetCurrentSpeed();
		/// <summary>
		/// Gets the max speed.
		/// </summary>
		/// <returns>The max speed.</returns>
		float GetMaxSpeed();
		/// <summary>
		/// Gets the is drift.
		/// </summary>
		/// <returns><c>true</c>, if is drift was gotten, <c>false</c> otherwise.</returns>
		bool GetIsDrift();
	}
}

