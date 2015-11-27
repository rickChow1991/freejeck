using UnityEngine;
using System.Collections;

namespace com.iuixi.FreeJeck
{
    public class SendMsg : IEnumerable
    {
        /// <summary>
        /// 服务器类型
        /// </summary>
        public readonly byte serverType;

        /// <summary>
        /// 消息
        /// </summary>
        public readonly CPacket msg;

        public SendMsg(ref byte type, ref CPacket msg)
        {
            this.serverType = type;
            this.msg = msg;
        }

        public IEnumerator GetEnumerator()
        {
            yield return null;
        }

    }
}
