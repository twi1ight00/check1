using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C17-0000-0000-C000-000000000046")]
public enum tagVisFontAttributes
{
	[TypeLibVar(64)]
	visFontRaster = 0x10,
	[TypeLibVar(64)]
	visFontDevice = 0x20,
	[TypeLibVar(64)]
	visFontScalable = 0x40,
	visFont0Alias = 0x80
}
