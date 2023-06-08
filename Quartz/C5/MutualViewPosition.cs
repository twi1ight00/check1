using System.Runtime.InteropServices;

namespace C5;

internal enum MutualViewPosition
{
	[ComVisible(true)]
	Contains,
	[ComVisible(true)]
	ContainedIn,
	[ComVisible(true)]
	NonOverlapping,
	[ComVisible(true)]
	Overlapping
}
