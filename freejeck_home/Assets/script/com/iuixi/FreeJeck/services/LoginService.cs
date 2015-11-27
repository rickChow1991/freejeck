using System;
using Cmdlib;
using Common;
using Command;
using InterfaceToSever;

namespace com.iuixi.FreeJeck
{
    /// <summary>
    ///   用户登陆服务,包含版本验证与用户登陆
    /// </summary>
	public class LoginService : BaseServices<AccountNetWork>
	{
        /// <summary>
        ///   版本验证委托
        /// </summary>
		public OnRecDta<cs_ACK> OnValid;

        /// <summary>
        ///   用户登陆委托
        /// </summary>
		public OnRecDta<cmdLOGIN_ANSWER_LOGIN_AUTH> OnLogin;

    	/// <summary>
    	/// Validates the version.
    	/// </summary>
		public void ValidateVersion(string version, OnRecDta<cs_ACK> dlg = null){
			OnValid = dlg;
			cmdLOGIN_REQUEST_CONNECT_AUTH pk = new cmdLOGIN_REQUEST_CONNECT_AUTH();
			char[] arr = version.ToCharArray ();
			if (arr.Length > pk.szVersionInfo.Length) {
				throw new Exception ("版本号的长度大于最大长度");
			}
			for (int i = 0; i < arr.Length; i++) {
				pk.szVersionInfo[i] = (byte) arr[i];	
			}
						
			CPacket obj = Serialize.SerializePacket((ushort)Login.eLOGIN_REQUEST.LOGIN_REQUEST_CONNECT_AUTH, pk);
			Send((Byte)ServerType.SERVER_LOGIN, obj);

		}

		public void LoginServer(string name, string passwd, OnRecDta<cmdLOGIN_ANSWER_LOGIN_AUTH> dlg = null)
		{
			//passwd="e10adc3949ba59abbe56e057f20f883e";
			byte[] bytes = new byte[passwd.Length];
			for (int i=0; i<passwd.Length; i++)
			{
				bytes[i]=(byte)passwd[i];
			}
			string MD5Passwd=CPacket.GetMD5(bytes);

			OnLogin = dlg;
			cmdLOGIN_REQUEST_LOGIN_AUTH pk = new cmdLOGIN_REQUEST_LOGIN_AUTH ();
			Array.Copy(name.ToCharArray(), pk.login_name, name.Length);
		
			Array.Copy(MD5Passwd.ToCharArray(), pk.password, MD5Passwd.Length);
			CPacket obj = Serialize.SerializePacket((ushort)Login.eLOGIN_REQUEST.LOGIN_REQUEST_LOGIN_AUTH, pk);
			Send ((byte)Nettention.Proud.HostID.Server, obj);
		}
	}
}

