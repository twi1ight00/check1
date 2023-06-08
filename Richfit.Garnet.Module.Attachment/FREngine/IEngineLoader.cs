using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[TypeIdentifier]
[CompilerGenerated]
[Guid("110010EC-0000-1056-976E-008048D53AE3")]
public interface IEngineLoader
{
	[DispId(1)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Engine GetEngineObject([In][MarshalAs(UnmanagedType.BStr)] string ProjectId = "0");

	void _VtblGap1_1();

	[DispId(3)]
	void ExplicitlyUnload();
}
