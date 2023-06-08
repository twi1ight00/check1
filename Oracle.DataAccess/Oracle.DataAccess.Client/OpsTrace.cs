using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsTrace
{
	private OpsTrace()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "OpsTrace")]
	public static extern void Trace(uint level, params string[] args);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public static extern int GetRegTraceInfo(out uint TrcLevel, out int StmtCacheSize, out int FetchSize, out int PSPE, out int PerfCounters);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public static extern int SyncInfo(string strTraceFileName, uint ChkConStatus, uint DynamicEnlist, int FetchSize, int OciEvnts, int PerfCounters, int PromotableTxn, int StmtCacheSize, int StmtCacheWithUdts, int ThreadPoolMaxSize, uint TraceLevel, uint TraceOption, uint UdtCacheSize, int FetchArrayPooling);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "OpsTraceCreateMiniDump")]
	public static extern int CreateMiniDump(int threadId, IntPtr pExPtrs);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "OpsTraceGetLastErrorCode")]
	public static extern int GetLastErrorCode(out int lastErrorCode);
}
