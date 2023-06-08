using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsDac
{
	private OpsDac()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacRead")]
	public unsafe static extern int Read(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsSqlCtx, ref IntPtr opsDacCtx, OpoSqlValCtx* pOpoSqlValCtx, OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OpoDacValCtx* pOpoDacValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacFreeCtx")]
	public static extern int FreeCtx(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDacCtx, IntPtr opoMetValCtx, IntPtr opoSqlValCtx, int bFreeOCIHnds);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacDispose")]
	public unsafe static extern int Dispose(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsSqlCtx, IntPtr opsDacCtx, OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx, OpoSqlValCtx* pOpoSqlValCtx, int bFreeOCIHndls);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacNextResult")]
	public unsafe static extern int NextResult(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr[] opsSqlCtx, IntPtr opsDacCtx, OpoSqlValCtx* pOpoSqlValCtx, ref OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacGetType")]
	public unsafe static extern int GetType(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsDacCtx, OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx, int bSkip);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacGetOraType")]
	public unsafe static extern int GetOraType(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsDacCtx, OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacGetInd")]
	public unsafe static extern int GetInd(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsDacCtx, OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacGetAllInd")]
	public unsafe static extern int GetAllInd(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsDacCtx, OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx, IntPtr nullIndicator);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDacGetLen")]
	public unsafe static extern int GetLen(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsDacCtx, OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDacGetPlsqlOutput")]
	public static extern int GetPlsqlOutput(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, [In][Out] string[] outputlines, ref int rowsToFetch);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDacGetColumnValues")]
	public unsafe static extern int GetColumnValues(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsDacCtx, OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx, OracleDbType[] oracleDbTypes, ref IntPtr columnsDataBuffers, long fetchArraylocation, long rowsize, uint[] columnOffset, uint[] columnIndOffset, uint[] columnLenOffset, uint[] colDatOffset, uint[] colDatSize);
}
