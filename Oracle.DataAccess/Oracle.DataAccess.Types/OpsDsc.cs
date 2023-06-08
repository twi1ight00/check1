using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsDsc
{
	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscDescribeAllObjAttrs")]
	public unsafe static extern int DescribeAllObjAttrs(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, OpoDscValCtx* pOpoDscValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscDescribeArrElem")]
	public unsafe static extern int DescribeArrElem(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, OpoDscValCtx* pOpoDscValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscDescribeObjAttr")]
	public unsafe static extern int DescribeObjAttr(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, OpoDscValCtx* pOpoDscValCtx, int attrIndex);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscDescribeUdt")]
	public unsafe static extern int DescribeUdt(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, OpoDscValCtx* pOpoDscValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscDispose")]
	public unsafe static extern int Dispose(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, OpoDscValCtx* pOpoDscValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscGetArrTypeCode")]
	public unsafe static extern int GetArrTypeCode(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, OpoDscValCtx* pOpoDscValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscGetNumArrElems")]
	public unsafe static extern int GetNumArrElems(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, OpoDscValCtx* pOpoDscValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscGetNumObjAttrs")]
	public unsafe static extern int GetNumObjAttrs(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, OpoDscValCtx* pOpoDscValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscGetTDO")]
	public unsafe static extern int GetTDO(IntPtr opsConCtx, out IntPtr opsErrCtx, ref IntPtr opsDscCtx, out OpoDscValCtx* pOpoDscValCtx, OpoDscRefCtx opoDscRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscGetUdtTypeName")]
	public unsafe static extern int GetUdtTypeName(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, OpoDscValCtx* pOpoDscValCtx, ref OpoDscRefCtx opoDscRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsDscUnpinTDO")]
	public static extern int UnpinTDO(IntPtr opsConCtx, IntPtr tdo);
}
