using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsTSZ
{
	private OpsTSZ()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSZAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OpoTSValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSZAllocValCtxFromData")]
	public unsafe static extern int AllocValCtxFromData(int year, int month, int day, int hour, int minute, int second, int fSecond, int tzHours, int tzMinutes, string regionName, out OpoTSValCtx* pValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSZAllocValCtxFromBytes")]
	public unsafe static extern int AllocValCtxFromBytes(byte[] bytes, out OpoTSValCtx* pValCtx1, int fracSecPrecision);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSZAllocValCtxFromStr")]
	public unsafe static extern int AllocValCtxFromStr(string tsStr, OpoITLValCtx* pTZOffsetstring, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSZAllocValCtxFromOCI")]
	public unsafe static extern int AllocValCtxFromOCI(IntPtr pOCIDateTime, out OpoTSValCtx* pValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSZAllocOCIFromValCtx")]
	public unsafe static extern int AllocOCIFromValCtx(IntPtr pOpsConCtx, OpoTSValCtx* pValCtx, out IntPtr pOCIDateTime);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoTSValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSZFreeOCI")]
	public static extern int FreeOCI(IntPtr TSCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSZToBytes")]
	public unsafe static extern int ToBytes(OpoTSValCtx* pValCtx1, byte[] bytes, int* len);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSZAllocValCtxForSysDate")]
	public unsafe static extern int AllocValCtxForSysDate(out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSZGetTZName")]
	public static extern int GetTimeZoneName(int tzHours, int tzMinutes, int regId, out string tzStr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSZToString")]
	public unsafe static extern int ToString(OpoTSValCtx* pValCtx1, int fSecondPrec, out string tsStr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSZConvertToTSL")]
	public unsafe static extern int ConvertToTSL(OpoTSValCtx* pDatCtx1, OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSZAllocMaxValue")]
	public unsafe static extern int AllocMaxValue(int year, int month, int day, int hour, int minute, int second, int fSecond, int tzHours, int tzMinutes, out OpoTSValCtx* pTSCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSZAllocMinValue")]
	public unsafe static extern int AllocMinValue(int year, int month, int day, int hour, int minute, int second, int fSecond, int tzHours, int tzMinutes, out OpoTSValCtx* pTSCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSZAllocValCtxForFromDate")]
	public unsafe static extern int AllocValCtxForFromDate(OpoDatValCtx* pDatCtx1, out OpoTSValCtx* pValCtx1);
}
