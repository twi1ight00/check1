using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsIYM
{
	private OpsIYM()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OpoITLValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoITLValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMFreeOCI")]
	public static extern int FreeOCI(IntPtr intervalCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMAllocValCtxFromYears")]
	public unsafe static extern int AllocValCtxFromYears(double years, ref OpoITLValCtx* intervalCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMAllocValCtxFromStr")]
	public unsafe static extern int AllocValCtxFromStr(IntPtr ansiStr, ref OpoITLValCtx* intervalCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMAllocValCtxFromData")]
	public unsafe static extern int AllocValCtxFromData(int years, int months, ref OpoITLValCtx* intervalCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMAllocValCtxFromOCI")]
	public unsafe static extern int AllocValCtxFromOCI(IntPtr pConCtx, IntPtr pErrCtx, IntPtr pOCIInterval, out OpoITLValCtx* pCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMAllocOCIFromValCtx")]
	public unsafe static extern int AllocOCIFromValCtx(IntPtr pConCtx, IntPtr pErrCtx, OpoITLValCtx* pValCtx, out IntPtr pOCIInterval);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMToYears")]
	public unsafe static extern int ToYears(OpoITLValCtx* intervalCtx, double* years);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMToBytes")]
	public unsafe static extern int ToBytes(OpoITLValCtx* pValCtx1, byte[] bytes);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMAllocValCtxFromBytes")]
	public unsafe static extern int AllocValCtxFromBytes(byte[] bytes, out OpoITLValCtx* pValCtx1, int yearPrecision);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMNegate")]
	public unsafe static extern int Negate(OpoITLValCtx* pValCtx1, out OpoITLValCtx* pValCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIYMDupValCtx")]
	public unsafe static extern int DupValCtx(OpoITLValCtx* pSrcCtx, out IntPtr pNewCtx);
}
