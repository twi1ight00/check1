using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("1100101E-0000-1056-976E-008048D53AE3")]
[CompilerGenerated]
[TypeIdentifier]
public interface IRecognizerParams
{
	void _VtblGap1_34();

	[DispId(20)]
	void SetPredefinedTextLanguage([In][MarshalAs(UnmanagedType.BStr)] string Name);
}
