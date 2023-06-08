using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C2F-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisSelectMode
{
	visSelModeSkipSuper = 0x100,
	visSelModeOnlySuper = 0x200,
	visSelModeSkipSub = 0x400,
	visSelModeOnlySub = 0x800
}
