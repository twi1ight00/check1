using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("11001081-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
[TypeIdentifier]
public interface IFRPage
{
	void _VtblGap1_2();

	Layout Layout
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
