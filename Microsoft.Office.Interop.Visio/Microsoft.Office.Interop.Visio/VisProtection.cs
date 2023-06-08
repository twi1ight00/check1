using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C35-0000-0000-C000-000000000046")]
public enum VisProtection
{
	visProtectNone = 0,
	visProtectStyles = 1,
	visProtectShapes = 2,
	visProtectMasters = 4,
	visProtectBackgrounds = 8,
	visProtectPreviews = 0x10
}
