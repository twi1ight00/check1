using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[CompilerGenerated]
[Guid("11001001-0000-1056-976E-008048D53AE3")]
[TypeIdentifier]
public interface ILayout
{
	void _VtblGap1_1();

	LayoutBlocks Blocks
	{
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
