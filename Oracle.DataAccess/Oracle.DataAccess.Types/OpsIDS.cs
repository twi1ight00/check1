using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsIDS
{
	private OpsIDS()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OpoITLValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoITLValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSAllocValCtxFromDays")]
	public unsafe static extern int AllocValCtxFromDays(double days, ref OpoITLValCtx* intervalCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSAllocValCtxFromStr")]
	public unsafe static extern int AllocValCtxFromStr(IntPtr strCtx, ref OpoITLValCtx* intervalCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSAllocValCtxFromData")]
	public unsafe static extern int AllocValCtxFromData(int days, int hours, int minutes, int seconds, int fSeconds, ref OpoITLValCtx* intervalCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSAllocValCtxFromOCI")]
	public unsafe static extern int AllocValCtxFromOCI(IntPtr pConCtx, IntPtr pErrCtx, IntPtr pOCIInterval, out OpoITLValCtx* pCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSAllocOCIFromValCtx")]
	public unsafe static extern int AllocOCIFromValCtx(IntPtr pConCtx, IntPtr pErrCtx, OpoITLValCtx* pValCtx, out IntPtr pOCIInterval);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSFreeOCI")]
	public static extern int FreeOCI(IntPtr intervalCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSToDays")]
	public unsafe static extern int ToDays(OpoITLValCtx* intervalCtx, double* days);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSToBytes")]
	public unsafe static extern int ToBytes(OpoITLValCtx* pValCtx1, byte[] bytes);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSAllocValCtxFromBytes")]
	public unsafe static extern int AllocValCtxFromBytes(byte[] bytes, out OpoITLValCtx* pValCtx1, int dayPrecision, int fracSecPrecision);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSNegate")]
	public unsafe static extern int Negate(OpoITLValCtx* pValCtx1, out OpoITLValCtx* pValCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsIDSDupValCtx")]
	public unsafe static extern int DupValCtx(OpoITLValCtx* oldCtx, out IntPtr pNewCtx);
}
