using System;
using System.Runtime.InteropServices;

namespace C5;

[Flags]
internal enum EventTypeEnum
{
	[ComVisible(true)]
	None = 0,
	[ComVisible(true)]
	Changed = 1,
	[ComVisible(true)]
	Cleared = 2,
	[ComVisible(true)]
	Added = 4,
	[ComVisible(true)]
	Removed = 8,
	[ComVisible(true)]
	Basic = 0xF,
	[ComVisible(true)]
	Inserted = 0x10,
	[ComVisible(true)]
	RemovedAt = 0x20,
	[ComVisible(true)]
	All = 0x3F
}
