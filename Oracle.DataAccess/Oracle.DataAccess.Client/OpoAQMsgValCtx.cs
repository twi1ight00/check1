using System;
using System.Runtime.InteropServices;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct OpoAQMsgValCtx
{
	internal unsafe OpoUdtValCtx* pOpoUdtValCtx;

	public IntPtr pRefTDO;

	internal int payloadType;

	internal int rawPayloadLen;

	internal IntPtr pMsgId;

	internal int msgIdLen;

	internal IntPtr pMsgIdObject;

	internal IntPtr pPayloadObject;

	internal IntPtr pPayloadOut;

	internal IntPtr pXmlPayload;

	internal int isXmlOrUDTNull;
}
