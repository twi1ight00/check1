using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("11001013-0000-1056-976E-008048D53AE3")]
[TypeIdentifier]
[CompilerGenerated]
public interface IParagraphs : IEnumerable
{
	void _VtblGap1_1();

	[IndexerName("Element")]
	Paragraph this[[In] int Index]
	{
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap2_1();

	int Count
	{
		[DispId(3)]
		get;
	}
}
