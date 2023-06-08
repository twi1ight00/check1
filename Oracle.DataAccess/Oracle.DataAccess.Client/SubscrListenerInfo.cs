using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential)]
internal class SubscrListenerInfo
{
	internal int port;

	internal bool bListenerStart;

	internal SubscrListenerInfo()
	{
		port = OraTrace.m_DBNotificationPort;
		bListenerStart = false;
	}
}
