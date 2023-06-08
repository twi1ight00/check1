using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[TypeLibType(4112)]
[Guid("000D0B0C-0000-0000-C000-000000000046")]
[InterfaceType(2)]
public interface ECharacters
{
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8320)]
	void TextChanged([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
}
