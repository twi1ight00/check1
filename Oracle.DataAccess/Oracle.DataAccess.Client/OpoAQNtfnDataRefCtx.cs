using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OpoAQNtfnDataRefCtx
{
	internal string queueName;

	internal string consumerName;
}
