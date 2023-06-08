using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("110010F4-0000-1056-976E-008048D53AE3")]
[TypeIdentifier]
[CompilerGenerated]
public interface IPagePreprocessingParams
{
	void _VtblGap1_1();

	OrientationDetectionParams OrientationDetectionParams
	{
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
		[DispId(2)]
		[param: In]
		[param: MarshalAs(UnmanagedType.Interface)]
		set;
	}

	bool CorrectOrientation
	{
		[DispId(3)]
		get;
		[DispId(3)]
		[param: In]
		set;
	}

	bool CorrectInvertedImage
	{
		[DispId(4)]
		get;
		[DispId(4)]
		[param: In]
		set;
	}
}
