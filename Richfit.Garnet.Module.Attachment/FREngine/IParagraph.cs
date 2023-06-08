using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("11001014-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
[TypeIdentifier]
public interface IParagraph
{
	void _VtblGap1_9();

	string Text
	{
		[DispId(11)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}
}
