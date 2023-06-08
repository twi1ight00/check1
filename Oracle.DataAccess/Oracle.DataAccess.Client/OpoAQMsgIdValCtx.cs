using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct OpoAQMsgIdValCtx
{
	internal IntPtr pMsgId;

	internal int msgIdLen;

	internal IntPtr pMsgIdObject;
}
