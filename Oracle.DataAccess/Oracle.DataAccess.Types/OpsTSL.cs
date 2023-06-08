using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsTSL
{
	private OpsTSL()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSLAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OpoTSValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSLAllocValCtxFromData")]
	public unsafe static extern int AllocValCtxFromData(int year, int month, int day, int hour, int minute, int second, int fSecond, int tzHours, int tzMinuts, out OpoTSValCtx* pValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSLAllocValCtxFromBytes")]
	public unsafe static extern int AllocValCtxFromBytes(byte[] bytes, out OpoTSValCtx* pValCtx1, int fracSecPrecision);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSLAllocValCtxFromStr")]
	public unsafe static extern int AllocValCtxFromStr(string tsStr, OpoITLValCtx* pITLCtx, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoTSValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSLFreeOCI")]
	public static extern int FreeOCI(IntPtr TSCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSLToBytes")]
	public unsafe static extern int ToBytes(OpoTSValCtx* pValCtx1, byte[] bytes, int* len);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSLAllocValCtxForSysDate")]
	public unsafe static extern int AllocValCtxForSysDate(out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSLToString")]
	public unsafe static extern int ToString(OpoTSValCtx* pValCtx1, OpoITLValCtx* pTZCtx, int fSecondPrec, out string tsStr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSLAllocValCtxForFromDate")]
	public unsafe static extern int AllocValCtxForFromDate(OpoDatValCtx* pDatCtx1, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSLAllocValCtxFromOCI")]
	public unsafe static extern int AllocValCtxFromOCI(IntPtr pOCIDateTime, out OpoTSValCtx* pValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSLAllocOCIFromValCtx")]
	public unsafe static extern int AllocOCIFromValCtx(IntPtr pOpsConCtx, OpoTSValCtx* pValCtx, out IntPtr pOCIDateTime);
}
