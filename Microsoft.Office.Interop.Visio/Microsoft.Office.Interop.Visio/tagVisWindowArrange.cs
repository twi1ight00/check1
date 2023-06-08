using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C2D-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisWindowArrange
{
	visArrangeTileVertical = 1,
	visArrangeTileHorizontal,
	visArrangeCascade
}
