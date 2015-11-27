using System;
using System.Collections;


namespace com.iuixi.FreeJeck
{
	public enum ServerType:byte
	{
		SERVER_LOGIN = 0, 
		SERVER_LOBBY, 
		SERVER_GAME, 
		SERVER_END
	};

	public class BaseServices<T> where T:NetWorkManager, new()
	{
		protected T m_Net = Singletons.GET<T>();

		virtual protected void Send(byte s_id, CPacket p)
		{
			m_Net.SendUserMessage (s_id, p);
		}

		virtual protected void SendbyP2P(CPacket p)
		{
			m_Net.SendP2pMessage (p);
		}
	}
}

