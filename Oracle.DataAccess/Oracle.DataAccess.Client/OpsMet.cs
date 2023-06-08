using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsMet
{
	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsMetCopyValCtx")]
	public unsafe static extern int CopyValCtx(OpoMetValCtx* pOpoMetValCtxSrc, ref OpoMetValCtx* pOpoMetValCtxDst);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsMetFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoMetValCtx* pOpoMetValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsMetGetValCtx")]
	public unsafe static extern int GetValCtx(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsSqlCtx, OpoSqlValCtx* pOpoSqlValCtx, ref OpoMetValCtx* pOpoMetValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsMetResetValCtx")]
	public unsafe static extern int ResetMetValCtx(IntPtr opsConCtx, OpoSqlValCtx* pOpoSqlValCtx, OpoMetValCtx* pOpoMetValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsGetPrimaryKey")]
	public unsafe static extern int GetPrimaryKey(IntPtr opsConCtx, IntPtr opsErrCtx, OpoMetValCtx* pOpoMetValCtx, int bSchemaTable, int bAddRowid, int bAddToStmtCache);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsGetSchemaMetaData")]
	public unsafe static extern int GetSchemaMetaData(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, OpoMetValCtx* pOpoMetValCtx, int AddRowid, int AddToStmtCache);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsMetAddRef")]
	public unsafe static extern int AddRef(OpoMetValCtx* pOpoMetValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsMetRelRef")]
	public unsafe static extern void RelRef(OpoMetValCtx* pOpoMetValCtx);
}
