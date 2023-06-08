using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsITL
{
	private OpsITL()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsITLToStr")]
	public unsafe static extern int ToString(OpoITLValCtx* intervalCtx, int lPrec, int fPrec, out IntPtr strCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsITLCompare")]
	public unsafe static extern int Compare(OpoITLValCtx* intervalCtx1, OpoITLValCtx* intervalCtx2, ref int result);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsITLAdd")]
	public unsafe static extern int Add(OpoITLValCtx* intervalCtx1, OpoITLValCtx* intervalCtx2, out OpoITLValCtx* intervalCtx3);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsITLSubtract")]
	public unsafe static extern int Subtract(OpoITLValCtx* intervalCtx1, OpoITLValCtx* intervalCtx2, out OpoITLValCtx* intervalCtx3);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsITLMultiply")]
	public unsafe static extern int Multiply(OpoITLValCtx* intervalCtx1, int multiplier, out OpoITLValCtx* intervalCtx3);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsITLDivide")]
	public unsafe static extern int Divide(OpoITLValCtx* intervalCtx1, int divisor, out OpoITLValCtx* intervalCtx3);
}
