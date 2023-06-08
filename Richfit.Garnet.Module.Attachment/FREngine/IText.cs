using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[TypeIdentifier]
[Guid("11001012-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
public interface IText
{
	void _VtblGap1_1();

	Paragraphs Paragraphs
	{
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
