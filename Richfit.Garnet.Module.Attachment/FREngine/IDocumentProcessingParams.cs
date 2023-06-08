using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("110010F0-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
[TypeIdentifier]
public interface IDocumentProcessingParams
{
	void _VtblGap1_1();

	PageProcessingParams PageProcessingParams
	{
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
		[DispId(2)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Interface)]
		set;
	}
}
