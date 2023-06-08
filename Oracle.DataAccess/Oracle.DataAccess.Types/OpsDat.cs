using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsDat
{
	private OpsDat()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDatAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OpoDatValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDatFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoDatValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDatAllocValCtxFromData")]
	public unsafe static extern int AllocValCtxFromData(int year, int month, int day, int hour, int minute, int second, out OpoDatValCtx* ctx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDatAllocValCtxFromBytes")]
	public unsafe static extern int AllocValCtxFromBytes(IntPtr dateCtx, out OpoDatValCtx* pValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDatAllocValCtxFromBytes")]
	public unsafe static extern int AllocValCtxFromBytes(byte[] bytes, out OpoDatValCtx* pValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDatAllocValCtxFromStr")]
	public unsafe static extern int AllocValCtxFromStr(string datStr, out OpoDatValCtx* pValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDatGetValCtxFromStr")]
	public unsafe static extern int GetValCtxFromStr(string datStr, OpoDatValCtx* pValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDatCompare")]
	public unsafe static extern int Compare(OpoDatValCtx* pValCtx1, OpoDatValCtx* pValCtx2, ref int result);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDatGetDaysBetween")]
	public unsafe static extern int GetDaysBetween(OpoDatValCtx* pValCtx1, OpoDatValCtx* pValCtx2, int* numOfDays);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDatAllocValCtxForSysDate")]
	public unsafe static extern int AllocValCtxForSysDate(out OpoDatValCtx* pValCtx1);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDatToString")]
	public unsafe static extern int ToString(OpoDatValCtx* pValCtx1, out string datStr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsDatAllocValCtxFromCtx")]
	public unsafe static extern int AllocValCtxFromCtx(OpoDatValCtx* oldCtx, out IntPtr pNewCtx);
}
