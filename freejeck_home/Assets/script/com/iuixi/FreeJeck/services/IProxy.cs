using System;

namespace com.iuixi.FreeJeck
{
	public interface IProxy<T>
	{
		void OnSuccess (T data);
	}
}

