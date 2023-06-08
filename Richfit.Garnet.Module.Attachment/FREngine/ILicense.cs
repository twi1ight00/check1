using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("11001054-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
[TypeIdentifier]
public interface ILicense
{
	void _VtblGap1_8();

	int Volume
	{
		[DispId(11)]
		get;
	}

	int VolumeRemaining
	{
		[DispId(12)]
		get;
	}

	void _VtblGap2_2();

	int AllowedCoresCount
	{
		[DispId(15)]
		get;
	}
}
