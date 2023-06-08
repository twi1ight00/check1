using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C25-0000-0000-C000-000000000046")]
public enum tagVisTraceFlags
{
	visTraceEvents = 1,
	visTraceAdvises = 2,
	visTraceAddonInvokes = 4,
	visTraceCallsToVBA = 8
}
