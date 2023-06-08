using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0728-0000-0000-C000-000000000046")]
[TypeLibType(4160)]
public interface IVisEventProc
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743808)]
	[return: MarshalAs(UnmanagedType.Struct)]
	object VisEventProc([In] short nEventCode, [In][MarshalAs(UnmanagedType.IDispatch)] object pSourceObj, [In] int nEventID, [In] int nEventSeqNum, [In][MarshalAs(UnmanagedType.IDispatch)] object pSubjectObj, [In][MarshalAs(UnmanagedType.Struct)] object vMoreInfo);
}
