using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
[Guid("11001089-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
[TypeIdentifier]
public interface DIFRDocumentEvents
{
	[PreserveSig]
	[DispId(1)]
	void OnProgress([In][MarshalAs(UnmanagedType.Interface)] FRDocument Sender, [In] int Percentage, [In][Out] ref bool Cancel);
}
