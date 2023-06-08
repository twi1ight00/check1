using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C2E-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisDrawRegionFlags
{
	visDrawRegionDeleteInput = 4,
	visDrawRegionIncludeHidden = 0x10,
	visDrawRegionIgnoreVisible = 0x20,
	visDrawRegionIncludeDataGraphics = 0x40
}
