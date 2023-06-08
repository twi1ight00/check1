using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsTSA
{
	private OpsTSA()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSACompare")]
	public unsafe static extern int Compare(OpoTSValCtx* pValCtx1, OpoTSValCtx* pValCtx2, ref int result);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForAddInterval")]
	public unsafe static extern int AllocValCtxForAddInterval(OpoTSValCtx* pValCtx1, OpoITLValCtx* pIDS1, out OpoTSValCtx* pCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForSubInterval")]
	public unsafe static extern int AllocValCtxForSubInterval(OpoTSValCtx* pValCtx1, OpoITLValCtx* pIDS1, out OpoTSValCtx* pCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForSubTSToIDS")]
	public unsafe static extern int AllocValCtxForSubTSToIDS(OpoTSValCtx* pValCtx1, OpoTSValCtx* pCtx2, out OpoITLValCtx* pIDS1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForSubTSToIYM")]
	public unsafe static extern int AllocValCtxForSubTSToIYM(OpoTSValCtx* pValCtx1, OpoTSValCtx* pCtx2, out OpoITLValCtx* pIDS1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForToDate")]
	public unsafe static extern int AllocValCtxForToDate(OpoTSValCtx* pValCtx1, out OpoDatValCtx* pDatCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForAddYears")]
	public unsafe static extern int AllocValCtxForAddYears(OpoTSValCtx* pDatCtx1, int years, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForAddMonths")]
	public unsafe static extern int AllocValCtxForAddMonths(OpoTSValCtx* pDatCtx1, long months, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForAddDays")]
	public unsafe static extern int AllocValCtxForAddDays(OpoTSValCtx* pDatCtx1, double days, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForAddHours")]
	public unsafe static extern int AllocValCtxForAddHours(OpoTSValCtx* pDatCtx1, double hours, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForAddMinutes")]
	public unsafe static extern int AllocValCtxForAddMinutes(OpoTSValCtx* pDatCtx1, double minutes, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForAddSeconds")]
	public unsafe static extern int AllocValCtxForAddSeconds(OpoTSValCtx* pDatCtx1, double seconds, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForAddMilliseconds")]
	public unsafe static extern int AllocValCtxForAddMilliseconds(OpoTSValCtx* pDatCtx1, double milliseconds, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForAddNanoseconds")]
	public unsafe static extern int AllocValCtxForAddNanoseconds(OpoTSValCtx* pDatCtx1, long nanoseconds, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForToTS")]
	public unsafe static extern int AllocValCtxForToTS(OpoTSValCtx* pDatCtx1, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForToTSL")]
	public unsafe static extern int AllocValCtxForToTSL(OpoTSValCtx* pDatCtx1, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForToTSZ")]
	public unsafe static extern int AllocValCtxForToTSZ(OpoTSValCtx* pDatCtx1, out OpoTSValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAAllocValCtxForToUTC")]
	public unsafe static extern int AllocValCtxForToUTC(OpoTSValCtx* pValCtx1, out OpoTSValCtx* pCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsTSAGetSysTZName")]
	public static extern int GetSysTZName(out string tzStr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSAGetSysTZOffset")]
	public unsafe static extern int GetTimeZoneOffset(int* tzHours, int* tzMinutes);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTSADupValCtx")]
	public unsafe static extern int DupValCtx(OpoTSValCtx* pSrcCtx, out IntPtr pNewCtx, TimeStampType tsType);
}
