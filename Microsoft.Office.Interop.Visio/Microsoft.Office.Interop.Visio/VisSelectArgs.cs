using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C0D-0000-0000-C000-000000000046")]
public enum VisSelectArgs
{
	visDeselect = 1,
	visSelect = 2,
	visSubSelect = 3,
	visSelectAll = 4,
	visDeselectAll = 256
}
