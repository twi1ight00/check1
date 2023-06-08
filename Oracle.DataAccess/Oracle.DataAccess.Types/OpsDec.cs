using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsDec
{
	private OpsDec()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtx")]
	public static extern int AllocValCtx(ref IntPtr numCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecFreeValCtx")]
	public static extern int FreeValCtx(IntPtr numCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocCtxFromBytes")]
	public static extern int AllocValCtxFromBytes(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxFromInteger")]
	public unsafe static extern int AllocValCtxFromInteger(void* pNum, int size, ref IntPtr numCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxWInfoFromReal")]
	public unsafe static extern int AllocValCtxWInfoFromReal(void* pNum, int size, out IntPtr numCtx, out int numberType, out int isPositive, out int isZero);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDecAllocValCtxWInfoFromStr")]
	public static extern int AllocValCtxWInfoFromStr(string numStr, string numFmt, out IntPtr numCtx, out int numberType, out int isPositive, out int isZero);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDecAllocValCtxFromNoFmtStr")]
	public static extern int AllocValCtxFromNoFmtStr(string numStr, out IntPtr numCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForPosInf")]
	public static extern int AllocValCtxForPosInf(out IntPtr pNumCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForNegInf")]
	public static extern int AllocValCtxForNegInf(out IntPtr pNumCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecToInteger")]
	public unsafe static extern int ToInteger(IntPtr numCtx, void* num, int size);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecToByte")]
	public unsafe static extern int ToByte(IntPtr numCtx, byte* num);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecToReal")]
	public unsafe static extern int ToReal(IntPtr numCtx, void* num, int size);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDecToStr")]
	public static extern int ToString(IntPtr numCtx, string numFmt, out string numStr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecCompare")]
	public unsafe static extern int Compare(IntPtr numCtx1, IntPtr numCtx2, int* result);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForAbs")]
	public static extern int AllocValCtxForAbs(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForAdd")]
	public static extern int AllocValCtxForAdd(IntPtr numCtx1, IntPtr numCtx2, out IntPtr numCtx3);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForCeiling")]
	public static extern int AllocValCtxForCeiling(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForConvertToPrecScale")]
	public static extern int AllocValCtxForConvertToPrecScale(IntPtr numCtx1, int precision, int scale, out IntPtr numCtx2, ref int result);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForDivide")]
	public static extern int AllocValCtxForDivide(IntPtr numCtx1, IntPtr numCtx2, out IntPtr numCtx3);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForFloor")]
	public static extern int AllocValCtxForFloor(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForModulus")]
	public static extern int AllocValCtxForModulus(IntPtr numCtx1, IntPtr numCtx2, out IntPtr numCtx3);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForMultiply")]
	public static extern int AllocValCtxForMultiply(IntPtr numCtx1, IntPtr numCtx2, out IntPtr numCtx3);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxFromPi")]
	public static extern int AllocValCtxFromPi(out IntPtr numCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForSetPrecWRound")]
	public static extern int AllocValCtxForSetPrecWRound(IntPtr numCtx1, int precision, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForSetPrecNoRound")]
	public static extern int AllocValCtxForSetPrecNoRound(IntPtr numCtx1, int precision, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecGetValCtxForSetPrecNoRound")]
	public static extern int GetValCtxForSetPrecNoRound(IntPtr numCtx1, int precision, IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForRound")]
	public static extern int AllocValCtxForRound(IntPtr numCtx1, int digit, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForShift")]
	public static extern int AllocValCtxForShift(IntPtr numCtx1, int decplace, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForNegate")]
	public static extern int AllocValCtxForNegate(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecSign")]
	public static extern int Sign(IntPtr numCtx1, ref int result);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForSqrt")]
	public static extern int AllocValCtxForSqrt(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForSubtract")]
	public static extern int AllocValCtxForSubtract(IntPtr numCtx1, IntPtr numCtx2, out IntPtr numCtx3);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForTruncate")]
	public static extern int AllocValCtxForTruncate(IntPtr numCtx1, int position, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForExp")]
	public static extern int AllocValCtxForExp(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForIntPower")]
	public static extern int AllocValCtxForIntPower(IntPtr numCtx1, int power, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForLn")]
	public static extern int AllocValCtxForLn(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForIntLog")]
	public static extern int AllocValCtxForIntLog(IntPtr numCtx1, int logBase, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForLog")]
	public static extern int AllocValCtxForLog(IntPtr numCtx1, IntPtr baseCtx, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForPower")]
	public static extern int AllocValCtxForPower(IntPtr numCtx1, IntPtr powerCtx, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForACos")]
	public static extern int AllocValCtxForACos(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForASin")]
	public static extern int AllocValCtxForASin(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForATan")]
	public static extern int AllocValCtxForATan(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForATan2")]
	public static extern int AllocValCtxForATan2(IntPtr numCtx1, IntPtr numCtx2, out IntPtr numCtx3);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForCos")]
	public static extern int AllocValCtxForCos(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForSin")]
	public static extern int AllocValCtxForSin(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForTan")]
	public static extern int AllocValCtxForTan(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForCosh")]
	public static extern int AllocValCtxForCosh(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForSinh")]
	public static extern int AllocValCtxForSinh(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecAllocValCtxForTanh")]
	public static extern int AllocValCtxForTanh(IntPtr numCtx1, out IntPtr numCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecGetInfo")]
	public static extern int GetInfo(IntPtr numCtx1, out int numberType, out int isPositive, out int isZero, int bCheck);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecGetValCtxFromBytes")]
	public static extern int GetValCtxFromBytes(IntPtr srcNumCtx, IntPtr destNumCtx2);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecGetValCtxFromInteger")]
	public unsafe static extern int GetValCtxFromInteger(void* pNum, int size, IntPtr numCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDecGetValCtxFromReal")]
	public unsafe static extern int GetValCtxFromReal(void* pNum, int size, IntPtr numCtx);
}
