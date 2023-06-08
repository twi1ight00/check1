using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OpoAQDeqOptionsRefCtx
{
	internal string consumerName;

	internal string correlationId;

	internal byte[] msgId;
}
