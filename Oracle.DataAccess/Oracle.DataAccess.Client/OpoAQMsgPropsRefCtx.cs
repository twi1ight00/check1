using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OpoAQMsgPropsRefCtx
{
	internal string exceptionQueue;

	internal string correlationId;

	internal string transNo;

	internal OpoAQAgentRefCtx senderId;
}
