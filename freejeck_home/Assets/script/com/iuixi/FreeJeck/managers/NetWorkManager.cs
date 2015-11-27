using System;
using System.Text;
using Nettention.Proud;
using InterfaceFromSever;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Frankfort.Threading;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
namespace com.iuixi.FreeJeck
{

	public class CPacket:Message
	{
		public struct Header
		{
			public ushort pId;
			public ushort pSize;
			public ushort pGuidId;
		}

		Header header;

		public int GetHeaderLength ()
		{
			return 6;// todo: find why catch web crash and fix it

			Header header = new Header ();
			return Marshal.SizeOf (header);
		}

		public  void SetID (ushort id)
		{
			header.pId = id;  
		}

		public ushort GetID ()
		{
			return header.pId;
		}

		public void SetGuid (ushort usGuid)
		{
			header.pGuidId = usGuid; 
		}

		public ushort GetGuid ()
		{
			return header.pGuidId;
		}

		public void SetpSize (ushort uspSize)
		{
			header.pSize = uspSize;      
		}

		public ushort GetpSize ()
		{
			return header.pSize;
		}

		public void WriteHeader (ushort cmd, ushort size, ushort GuidId)
		{
			SetID (cmd);
			SetpSize (size);
			SetGuid (GuidId);
			Write (cmd); 
			Write (size);
			Write (GuidId);
		}

		public void WriteBytes(byte[] Bytes,int size)
		{
			if (Bytes.Length >= size) 
			{
				for (int i = 0; i < size; i++)
				{
					Write(Bytes[i]);
				}
			}

		}
		
		public void WriteChars(char[] Chars, int size)
		{
			if (Chars.Length >= size) 
			{
				for (int i = 0; i < size; i++)
				{
					Write(Chars[i]);
				}
			}

		}

		public void WriteCharsCut0(char[] Chars, int size)
		{
			if (Chars.Length >= size) 
			{
				char[] t_chars = new char[size];
				int j = 0;
				for (int i=0; i<size; i+=2) 
				{
					t_chars[j]=Chars[i];
					j++;
				}
				for (int i = 0; i < size; i++)
				{
					Write(t_chars[i]);
				}
			}

		}

		
		public void WriteString(string s, int size)
		{
			if (s.Length >= size) 
			{
				for (int i = 0; i < size; i++)
				{
					byte b=(byte)s[i];
					Write(b);
				}
			}

		}

		
		public void ReadHeader (ByteArray payload)
		{
			header.pId = BitConverter.ToUInt16 (payload.data, 0);
			header.pSize = System.BitConverter.ToUInt16 (payload.data, 2);
			header.pGuidId = System.BitConverter.ToUInt16 (payload.data, 4);
               
		}

		public byte[] ReadData (ByteArray payload)
		{
			int size = payload.Count - 6;
			byte[] b = new byte[size];
			Array.Copy (payload.data, 6, b, 0, size);


			return b;
		}

		public static string GetMD5(string myString)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
			byte[] targetData = md5.ComputeHash(fromData);
			string byte2String = null;
			
			for (int i = 0; i < targetData.Length; i++)
			{
				byte2String += targetData[i].ToString("x2");
			}
			
			return byte2String;
		}

		public static string GetMD5(byte[] bytes)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] targetData = md5.ComputeHash(bytes);
			string byte2String = null;
			
			for (int i = 0; i < targetData.Length; i++)
			{
				byte2String += targetData[i].ToString("x2");
			}		
			return byte2String;
		} 

	}

	public delegate void OnRecDta<T> (T data);

	/// <summary>
	/// Account net work.
	/// </summary>
	public class NetWorkManager
	{
		private static NetWorkManager m_Instance = null;
		public static NetWorkManager SharedInstance () {
			if (m_Instance == null) {
				m_Instance = new NetWorkManager ();
			}
			return m_Instance;
		}

        /// <summary>
        /// 同时有几个发包程线 -1 表示不限，默认-1
        /// </summary>
        public int MaxThreads { get; set; }

        /// <summary>
        /// 发包的scheduler,可以判断worker是否完成
        /// </summary>
        private ThreadPoolScheduler myScheduler;
        private Queue<SendMsg> m_SendMsgs;
 
        public NetWorkManager()
		{
            MaxThreads = -1;
			m_Client = new NetClient ();
            m_SendMsgs = new Queue<SendMsg>();
			m_Client.JoinServerCompleteHandler = OnJoinServerComplete;
			m_Client.LeaveServerHandler = OnLeaveServer;
			m_Client.ReceivedUserMessageHandler = OnReceiveUserMessage;
			m_Client.P2PMemberJoinHandler = OnP2PMemberJoin;
			m_Client.P2PMemberLeaveHandler = OnP2PMemberLeave;
            Loom.StartSingleThread(SendMessages, System.Threading.ThreadPriority.Normal, false);
            myScheduler = Loom.CreateThreadPoolScheduler("myScheduler");
            myScheduler.ForceToMainThread = false;
		}

		public NetClient m_Client;
		public HostID m_GroupHostID;
		public bool m_IsConnectWaiting = true;
		public bool m_IsConnected = false;
		public bool m_IsGroupHostID = false;
		public HostID m_memberhostid = HostID.None;
        public delegate void OnConnect(bool success);
        public event OnConnect ConnectHandler;

		public bool IsConnectWating ()
		{
			return m_IsConnectWaiting;
		}

		public bool IsConnected ()
		{
			return m_IsConnected;
		}

		public HostID GetGroupHostID()
		{
			return m_GroupHostID;
		}

		public void OnP2PMemberJoin (HostID memberHostID, HostID groupHostID, int memberCount, ByteArray customField)
		{
			m_GroupHostID = groupHostID;
			m_IsGroupHostID = true;
		}

		public void OnP2PMemberLeave (HostID memberHostID, HostID groupHostID, int memberCount)
		{
		}

		public void OnJoinServerComplete (ErrorInfo info, ByteArray replyFromServer)
		{
			m_IsConnectWaiting = false;
			if (info.errorType == Nettention.Proud.ErrorType.Ok) {
				m_IsConnected = true;
			}

            if (ConnectHandler != null)
            {
				WebLog.Log("");
                ConnectHandler(m_IsConnected);
            }
		}

		public void OnLeaveServer (ErrorInfo errorInfo)
		{
			m_IsConnected = false;
			m_IsGroupHostID = false;
		}

		public void OnReceiveUserMessage (HostID sender, RmiContext rmiContext, ByteArray payload)
		{

			if (payload.Count <= (int)Command.Constant.MAX_PACKET_SIZE) {
                Loom.DispatchToMainThread(() => Deserialize.DeserializePacket(payload)); 
			}          
		}

		public void Connect (byte chServerType, String m_serverIP, int m_serverPort, OnConnect dlg = null)
		{  
			Guid m_Version = new Guid ("{0x5f6f921f,0x285f,0x40dc,{0x8f,0xd3,0xcf,0x5a,0xb3,0x84,0x80,0x66}}");
  
			NetConnectionParam cp = new NetConnectionParam ();
			cp.protocolVersion = m_Version;
			cp.serverIP = m_serverIP;
			cp.serverPort = (ushort)m_serverPort;

#if UNITY_WEBPLAYER
            Security.PrefetchSocketPolicy(m_serverIP, m_serverPort);
#endif
			if(dlg != null) {
				ConnectHandler = dlg;
			}
			if (m_Client.Connect (cp) == false) {
                if (dlg != null)
                {
                    dlg(false);
                }
			}
		}

		public  void DisConnect ()
		{
			ConnectHandler = null;
			m_Client.Disconnect ();
		}

		public bool SendP2pMessage(CPacket msg)
		{
			if (m_IsGroupHostID) {
				return m_Client.SendUserMessage (m_GroupHostID, Nettention.Proud.RmiContext.UnreliableSend, msg.Data.data);
			} else {
				WebLog.Log("P2p Message processed failed");
			}

			return false;
		}

        /// <summary>
        /// 把包放到队列中，用子线程去发送，子线程非每一帧检查，并且每一帧只会发一个
        /// </summary>
        /// <param name="chServerType"></param>
        /// <param name="msg"></param>
        public void SendUserMessage(byte chServerType, CPacket msg)
        {
            Loom.DispatchToMainThread(()=> m_SendMsgs.Enqueue(new SendMsg(ref chServerType, ref msg)));
        }

        /// <summary>
        /// 立即发送
        /// </summary>
        /// <param name="chServerType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
		public bool SendUserMessageIme (byte chServerType, CPacket  message)
		{
			return m_Client.SendUserMessage (Nettention.Proud.HostID.Server, Nettention.Proud.RmiContext.SecureReliableSend, message.Data.data);
		}
        private void SendMessages()
        {
            /// thread 不会退出
            while (true)
            {
                Loom.WaitForNextFrame();
                if (m_IsConnected || m_IsConnectWaiting)
                {
                    m_Client.FrameMove();


                    /// 有消息，并且上一次发送的全部完成
					if (m_IsConnected && m_SendMsgs.Count > 0 && !myScheduler.isBusy)
                    {
                        /// 跳到主线程派发发送worker
                        Loom.DispatchToMainThread(() =>
                        {
                            SendMsg[] msgs = m_SendMsgs.ToArray();
                            m_SendMsgs.Clear();
                            Loom.StartMultithreadedWorkloadExecution<SendMsg>(RealSend, msgs, onComplete, onPackageComplete, MaxThreads, myScheduler, true);
                        });
                    }
                }
                else
                {

                }
            }
        }

        /// <summary>
        /// 发包
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="i"></param>
        private void RealSend(SendMsg msg, int i)
        {
            /// todo
            /// 前边几个参数是什么意思，还没有搞清楚
            m_Client.SendUserMessage(Nettention.Proud.HostID.Server, Nettention.Proud.RmiContext.SecureReliableSend, msg.msg.Data.data);
        }

        private void onComplete(SendMsg[] workLoad)
        {
            WebLog.Log("All workload processed: " + workLoad.Length);
        }

        private void onPackageComplete(SendMsg[] workLoadPartial, int firstIndex, int lastIndex)
        {
            WebLog.Log("partial workload processed: " + workLoadPartial.Length + ", from: " + firstIndex + ", to:  " + lastIndex);
        }
	}

	/// <summary>
	/// Lobby net work.
	/// </summary>
	public class LobbyNetWork : NetWorkManager{}

    public class AccountNetWork : NetWorkManager { }

	public class GameNetWork : NetWorkManager{}

}