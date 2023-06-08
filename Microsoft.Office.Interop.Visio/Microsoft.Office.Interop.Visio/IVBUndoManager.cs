using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D1306-0000-0000-C000-000000000046")]
[TypeLibType(4176)]
public interface IVBUndoManager
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743808)]
	void Add([In][MarshalAs(UnmanagedType.Interface)] IVBUndoUnit pUnit);
}
