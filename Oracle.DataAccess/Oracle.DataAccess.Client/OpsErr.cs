using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsErr
{
	private OpsErr()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsErrGetOpoCtx")]
	public static extern int GetOpoCtx(IntPtr opsErrCtx, ref OpoErrCtx opoErrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsErrGetBatchErrCtx")]
	public static extern int GetBatchErrCtx(IntPtr opsErrCtx, IntPtr opsConCtx, int batchErrCnt, [In][Out] IntPtr[] batchOpsErrCtx, [In][Out] int[] batchOpsErrOffset);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsErrGetCtxCnt")]
	public static extern int GetCtxCnt(ref int cnt, IntPtr opsErrCtx, IntPtr opsSqlCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsErrAllocCtx")]
	public static extern int AllocCtx(ref IntPtr opsErrCtx, IntPtr opsConCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsErrFreeCtx")]
	public static extern int FreeCtx(ref IntPtr opsErrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsErrGetOraMesg")]
	public static extern int GetOraMesg(int errNum, out string errMsg);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsErrGetTypeMsg")]
	public static extern int GetTypeMsg(int errNum, out string typMsg);
}
