using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[TypeLibType(272)]
[Guid("000D0D11-0000-0000-C000-000000000046")]
[InterfaceType(1)]
public interface IVClientSite
{
	[DispId(1610678272)]
	Shape Shape
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
