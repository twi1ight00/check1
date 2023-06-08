using System.Runtime.InteropServices;

namespace C5;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct RecConst
{
	[ComVisible(true)]
	public const int HASHFACTOR = 387281;
}
