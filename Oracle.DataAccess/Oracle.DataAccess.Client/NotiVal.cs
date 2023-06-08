using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct NotiVal
{
	internal OracleNotificationType type;

	internal OracleNotificationSource source;

	internal OracleNotificationInfo info;

	internal int numTables;

	internal int numQueries;
}
