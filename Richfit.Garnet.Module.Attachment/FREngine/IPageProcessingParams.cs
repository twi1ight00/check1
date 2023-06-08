using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[TypeIdentifier]
[Guid("11001021-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
public interface IPageProcessingParams
{
	void _VtblGap1_3();

	RecognizerParams RecognizerParams
	{
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
		[DispId(3)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Interface)]
		set;
	}
}
