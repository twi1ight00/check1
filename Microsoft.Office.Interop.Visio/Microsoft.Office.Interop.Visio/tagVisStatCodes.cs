using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C18-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisStatCodes
{
	visStatNormal = 0,
	visStatAppHasShutdown = 1,
	visStatDeleted = 2,
	[TypeLibVar(64)]
	visStatTouched = 4,
	visStatClosed = 8,
	visStatSuspended = 0x10
}
