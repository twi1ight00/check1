using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsXmlType
{
	public const int TYPE_STRING = 1;

	public const int TYPE_CLOB = 2;

	public const int TYPE_STREAM = 3;

	public const int TYPE_XML = 4;

	private OpsXmlType()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeAllocXmlTypeCtxEmpty")]
	public unsafe static extern int AllocXmlTypeCtxEmpty(IntPtr pOpsConCtx, ref IntPtr ppOpsXmlTypeCtx, ref IntPtr ppOpsErrCtx, ref OpoXmlTypeValCtx* ppOpoXmlTypeValCtx, OpoXmlTypeRefCtx pOpoXmlTypeRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeAllocXmlTypeCtx")]
	public unsafe static extern int AllocXmlTypeCtx(IntPtr pOpsConCtx, ref IntPtr ppOpsXmlTypeCtx, ref IntPtr ppOpsErrCtx, ref OpoXmlTypeValCtx* ppOpoXmlTypeValCtx, IntPtr pBuffer, int flag);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeAllocCtx")]
	public unsafe static extern int AllocCtx(IntPtr pOpsConCtx, ref IntPtr ppOpsErrCtx, ref OpoXmlTypeValCtx* ppOpoXmlTypeValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeCopy")]
	public static extern int Copy(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsXmlTypeCtx, ref IntPtr ppNewOpsXmlTypeCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeFreeCtx")]
	public unsafe static extern int FreeCtx(ref IntPtr ppOpsConCtx, ref IntPtr ppOpsErrCtx, ref OpoXmlTypeValCtx* ppOpoXmlTypeValCtx, int bFreeXmlHnd);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeExtract")]
	public static extern int Extract(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsXmlTypeCtx, string xpathExpr, string nsMap, ref IntPtr ppOpsXmlTypeCtx_result);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeExists")]
	public static extern int Exists(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsXmlTypeCtx, string xpathExpr, string nsMap, ref int pResult);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeTransform")]
	public static extern int Transform(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsXmlTypeCtx, IntPtr pBuffer, int flag, string paramMap, ref IntPtr ppOpsXmlTypeCtx_result);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeUpdateFromString")]
	public static extern int UpdateFromString(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsXmlTypeCtx, string xpathExpr, string nsMap, string newValue);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeUpdateFromXmlType")]
	public static extern int UpdateFromXmlType(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsXmlTypeCtx, string xpathExpr, string nsMap, IntPtr pNewValue);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeValidate")]
	public static extern int Validate(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsXmlTypeCtx, string schemaUrl, ref int pResult);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeIsSchemaBased")]
	public unsafe static extern int IsSchemaBased(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsXmlTypeCtx, ref OpoXmlTypeValCtx* ppOpoXmlTypeValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeIsFragment")]
	public unsafe static extern void IsFragment(IntPtr pOpsXmlTypeCtx, ref OpoXmlTypeValCtx* ppOpoXmlTypeValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeGetSchema")]
	public static extern int GetSchema(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pOpsXmlTypeCtx, ref OpoXmlTypeRefCtx ppOpoXmlTypeRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeAddRef")]
	public static extern int AddRef(IntPtr pOpsXmlTypeCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeRelRef")]
	public static extern int RelRef(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, ref IntPtr ppOpsXmlTypeCtx, int bFreeOciXmlType);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeAllocNewCtx")]
	public static extern int AllocNewCtx(IntPtr pOpsConCtx, ref IntPtr ppOpsXmlTypeCtx, IntPtr pOCIXmlType, int allocOciXmlType);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsXmlTypeGetOCIXMLType")]
	public static extern int GetOCIXMLType(IntPtr pOpsXmlTypeCtx, ref IntPtr ppOCIXMLType);
}
