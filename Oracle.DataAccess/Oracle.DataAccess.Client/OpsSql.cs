using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsSql
{
	private OpsSql()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlAllocValCtx")]
	public unsafe static extern int AllocSqlValCtx(ref OpoSqlValCtx* pOpoSqlValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlCopyValCtx")]
	public unsafe static extern int CopySqlValCtx(OpoSqlValCtx* pOpoSqlValCtxSrc, ref OpoSqlValCtx* pOpoSqlValCtxDst);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlFreeCtx")]
	public static extern int FreeCtx(ref IntPtr opsSqlCtx, IntPtr opsErrCtx, int bStmtCache);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoSqlValCtx* pOpoSqlValCtx, int bFreeStmtHnd);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlFreeRefTDOandOCISnapShot")]
	public unsafe static extern int FreeRefTDOandOCISnapShot(OpoPrmCtx* pOpoPrmCtx, OpoSqlValCtx* pOpoSqlValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlExecuteReader")]
	public unsafe static extern int ExecuteReader(IntPtr opsConCtx, ref IntPtr opsErrCtx, ref IntPtr opsSqlCtx, ref IntPtr opsDacCtx, out IntPtr opsReaderErrCtx, IntPtr opsSubscrCtx, ref int isSubscrRegistered, int bchgNTFNExcludeRowidInfo, int bQueryBasedNTFNRegistration, ref long query_id, ref OpoSqlValCtx* pOpoSqlValCtx, string pCommandText, ref OpoDacValCtx* pOpoDacValCtx, [In][Out] IntPtr[] pOpoPrmValCtx, string[] ppOpoPrmRefCtx, ref OpoMetValCtx* pOpoMetValCtx, int NoOfParams);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlPrepare")]
	public unsafe static extern int Prepare(IntPtr opsConCtx, ref IntPtr opsErrCtx, ref IntPtr opsSqlCtx, ref IntPtr opsDacCtx, ref OpoSqlValCtx* pOpoSqlValCtx, string pCommandText, ref OpoMetValCtx* pOpoMetValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlPrepare2")]
	public unsafe static extern int Prepare2(IntPtr opsConCtx, ref IntPtr opsErrCtx, ref IntPtr opsSqlCtx, ref IntPtr opsDacCtx, ref OpoSqlValCtx* pOpoSqlValCtx, string pCommandText, ref IntPtr pUTF8CommandText, ref OpoMetValCtx* pOpoMetValCtx, int prmCnt);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlExecuteNonQuery")]
	public unsafe static extern int ExecuteNonQuery(IntPtr opsConCtx, ref IntPtr opsErrCtx, ref IntPtr opsSqlCtx, ref IntPtr opsDacCtx, IntPtr opsSubscrCtx, ref int isSubscrRegistered, int bchgNTFNExcludeRowidInfo, int bQueryBasedNTFNRegistration, ref long query_id, ref OpoSqlValCtx* pOpoSqlValCtx, string pCommandText, ref IntPtr pUTF8CommandText, [In][Out] IntPtr[] pOpoPrmValCtx, string[] ppOpoPrmRefCtx, ref OpoMetValCtx* pOpoMetValCtx, int prmCnt, int bFromPool);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSqlBreakExecution")]
	public static extern int BreakExecution(IntPtr opsConCtx, ref IntPtr opsErrCtx);
}
