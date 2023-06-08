using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C30-0000-0000-C000-000000000046")]
public enum VisSelectItemStatus
{
	visSelIsPrimaryItem = 1,
	visSelIsSubItem = 2,
	visSelIsSuperItem = 4
}
