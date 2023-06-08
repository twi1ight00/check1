using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct NotiTblVal
{
	internal OracleNotificationInfo info;

	internal int numRows;

	internal IntPtr pOpsTableChangeDesc;
}
