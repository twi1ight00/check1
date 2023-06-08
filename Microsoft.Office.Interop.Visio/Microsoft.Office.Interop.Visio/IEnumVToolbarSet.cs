using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0263-0000-0000-C000-000000000046")]
[TypeLibType(528)]
[InterfaceType(1)]
public interface IEnumVToolbarSet
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Next([In] int celt, [MarshalAs(UnmanagedType.Interface)] out ToolbarSet rgelt, out int pceltFetched);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Skip([In] int celt);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Reset();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Clone([MarshalAs(UnmanagedType.Interface)] out IEnumVToolbarSet ppenm);
}
