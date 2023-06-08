using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C14-0000-0000-C000-000000000046")]
public enum VisToolbarFlavors
{
	[TypeLibVar(64)]
	visToolBarNone = -1,
	[TypeLibVar(64)]
	visToolBarOn = 0,
	[TypeLibVar(64)]
	visToolBarMSOffice = 0,
	[TypeLibVar(64)]
	visToolBarLotusSS = 0
}
