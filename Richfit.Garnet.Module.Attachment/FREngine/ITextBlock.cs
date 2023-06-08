using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[TypeIdentifier]
[Guid("11001004-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
public interface ITextBlock : IBlock
{
	void _VtblGap1_27();

	Text Text
	{
		[DispId(52)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
