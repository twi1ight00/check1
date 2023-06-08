using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C8B-0000-0000-C000-000000000046")]
public enum VisUIButtonState
{
	visButtonUp = 0,
	visButtonDown = -1,
	[TypeLibVar(64)]
	visButtonMixed = 2
}
