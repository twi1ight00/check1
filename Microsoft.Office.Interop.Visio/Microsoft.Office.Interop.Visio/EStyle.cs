using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[TypeLibType(4112)]
[InterfaceType(2)]
[Guid("000D0B06-0000-0000-C000-000000000046")]
public interface EStyle
{
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8196)]
	void StyleChanged([In][MarshalAs(UnmanagedType.Interface)] Style Style);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16388)]
	void BeforeStyleDelete([In][MarshalAs(UnmanagedType.Interface)] Style Style);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(300)]
	bool QueryCancelStyleDelete([In][MarshalAs(UnmanagedType.Interface)] Style Style);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(301)]
	void StyleDeleteCanceled([In][MarshalAs(UnmanagedType.Interface)] Style Style);
}
