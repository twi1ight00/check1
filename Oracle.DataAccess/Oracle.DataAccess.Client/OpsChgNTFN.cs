using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsChgNTFN
{
	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsChgNTFNRegisterNotificationCallback")]
	public static extern int RegisterNotificationCallback(OnChangeCallback s_onChangeOpsCallback);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsChgNTFNGetTableInfos")]
	public static extern int GetTableInfos(IntPtr pOpsEnvCtx, IntPtr pOpsErrCtx, int numTables, OracleNotificationType notiType, IntPtr opsChgNTFNDesc, IntPtr notiTblDescs, out IntPtr tableNames);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsChgNTFNGetRowInfos")]
	public static extern int GetRowInfos(IntPtr pOpsEnvCtx, IntPtr pOpsErrCtx, int numRows, IntPtr opsChgNTFNTableDesc, IntPtr notiRowDescs, out IntPtr rowids);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsChgNTFNGetQueryIds")]
	public static extern int GetQueryIds(IntPtr pOpsEnvCtx, IntPtr pOpsErrCtx, IntPtr opsChgNTFNDesc, int queryNum, ref IntPtr query_desc, ref long query_id, ref int numtables);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsChgNTFNFreeNotiTblRefs")]
	public static extern int FreeNotiTblRefs(ref IntPtr tables, int numTable);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsChgNTFNFreeNotiRowRefs")]
	public static extern int FreeNotiRowRefs(ref IntPtr rowids, int numRow);
}
