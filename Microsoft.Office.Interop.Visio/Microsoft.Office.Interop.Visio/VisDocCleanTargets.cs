using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C3C-0000-0000-C000-000000000046")]
public enum VisDocCleanTargets
{
	visDocCleanTargFPages = 1,
	visDocCleanTargBPages = 2,
	visDocCleanTargMasters = 4,
	visDocCleanTargStyles = 8,
	visDocCleanTargDoc = 16,
	visDocCleanTargRPages = 32,
	visDocCleanPageSheet = 256,
	visDocCleanTargAll = 255
}
