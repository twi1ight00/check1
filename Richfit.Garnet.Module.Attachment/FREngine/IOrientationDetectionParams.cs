using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[CompilerGenerated]
[TypeIdentifier]
[Guid("110010D7-0000-1056-976E-008048D53AE3")]
public interface IOrientationDetectionParams
{
	void _VtblGap1_1();

	OrientationDetectionModeEnum OrientationDetectionMode
	{
		[DispId(2)]
		get;
		[DispId(2)]
		[param: In]
		set;
	}
}
