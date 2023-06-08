using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C29-0000-0000-C000-000000000046")]
public enum VisWindowStates
{
	visWSNone = 0,
	visWSMaximized = 1073741824,
	visWSMinimized = 536870912,
	visWSRestored = 268435456,
	visWSVisible = 134217728,
	visWSDockedLeft = 1,
	visWSDockedTop = 2,
	visWSDockedRight = 4,
	visWSDockedBottom = 8,
	visWSFloating = 16,
	visWSAnchorLeft = 32,
	visWSAnchorTop = 64,
	visWSAnchorRight = 128,
	visWSAnchorBottom = 256,
	visWSAnchorAutoHide = 512,
	visWSAnchorMerged = 1024,
	visWSActive = 67108864
}
