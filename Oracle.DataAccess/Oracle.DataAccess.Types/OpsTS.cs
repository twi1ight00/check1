using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsTS
{
	private OpsTS()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OpoTSValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAllocValCtxFromData")]
	public unsafe static extern int AllocValCtxFromData(int year, int month, int day, int hour, int minute, int second, int fSecond, out OpoTSValCtx* pValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAllocValCtxFromBytes")]
	public unsafe static extern int AllocValCtxFromBytes(byte[] bytes, out OpoTSValCtx* pValCtx1, int fracSecPrecision);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSAllocValCtxFromStr")]
	public unsafe static extern int AllocValCtxFromStr(string tsStr, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoTSValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSFreeOCI")]
	public static extern int FreeOCI(IntPtr TSCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSToBytes")]
	public unsafe static extern int ToBytes(OpoTSValCtx* pValCtx1, byte[] bytes, int* len);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAllocValCtxForSysDate")]
	public unsafe static extern int AllocValCtxForSysDate(out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSToString")]
	public unsafe static extern int ToString(OpoTSValCtx* pValCtx1, int fSecondPrec, out string tsStr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAllocValCtxForFromDate")]
	public unsafe static extern int AllocValCtxForFromDate(OpoDatValCtx* pDatCtx1, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAllocValCtxFromOCI")]
	public unsafe static extern int AllocValCtxFromOCI(IntPtr pOCIDateTime, out OpoTSValCtx* pLdiDateTimeCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAllocOCIFromValCtx")]
	public unsafe static extern int AllocOCIFromValCtx(IntPtr pOpsConCtx, OpoTSValCtx* pValCtx, out IntPtr pOCIDateTime);
}
