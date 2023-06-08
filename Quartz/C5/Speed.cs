using System.Runtime.InteropServices;

namespace C5;

internal enum Speed : short
{
	[ComVisible(true)]
	PotentiallyInfinite = 1,
	[ComVisible(true)]
	Linear,
	[ComVisible(true)]
	Log,
	[ComVisible(true)]
	Constant
}
