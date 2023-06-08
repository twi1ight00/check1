using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[TypeIdentifier]
[Guid("11001003-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
public interface IBlock
{
	void _VtblGap1_15();

	[DispId(20)]
	[return: MarshalAs(UnmanagedType.Interface)]
	TextBlock GetAsTextBlock();
}
