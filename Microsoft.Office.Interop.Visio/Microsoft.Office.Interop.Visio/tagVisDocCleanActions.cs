using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C3D-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisDocCleanActions
{
	visDocCleanActLocalFormulas = 1,
	visDocCleanActEmptyRowsAndSects = 2,
	visDocCleanActNonDefaultFonts = 4,
	visDocCleanActStaleResults = 8,
	visDocCleanActMissingSubs = 16,
	visDocCleanActConstantFormulas = 32,
	visDocCleanActNearZero = 64,
	visDocCleanActDuplicateSubs = 128,
	visDocCleanActBadDisplayLists = 256,
	[TypeLibVar(64)]
	visDocCleanActBadFieldCounts = 512,
	visDocCleanActDeletedFields = 1024,
	visDocCleanActBadFieldFormulas = 2048,
	visDocCleanActBadFieldMarks = 4096,
	visDocCleanActBadReferences = 8192,
	visDocCleanActAll = 16383,
	visDocCleanActDefault = 8152,
	visDocCleanAlertDefault = 0,
	visDocCleanFixDefault = 984
}
