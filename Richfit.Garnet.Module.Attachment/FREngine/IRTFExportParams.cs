using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("11001029-0000-1056-976E-008048D53AE3")]
[TypeIdentifier]
[CompilerGenerated]
public interface IRTFExportParams
{
	void _VtblGap1_13();

	RTFPageSynthesisModeEnum PageSynthesisMode
	{
		[DispId(9)]
		get;
		[DispId(9)]
		[param: In]
		set;
	}
}
