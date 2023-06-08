using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C48-0000-0000-C000-000000000046")]
public enum VisKeyButtonFlags
{
	visMouseLeft = 1,
	visMouseMiddle = 16,
	visMouseRight = 2,
	visKeyShift = 4,
	visKeyControl = 8
}
