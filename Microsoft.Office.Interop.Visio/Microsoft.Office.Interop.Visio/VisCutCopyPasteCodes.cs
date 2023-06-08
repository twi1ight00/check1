using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C39-0000-0000-C000-000000000046")]
public enum VisCutCopyPasteCodes
{
	visCopyPasteNormal = 0,
	visCopyPasteNoTranslate = 1,
	visCopyPasteCenter = 2,
	visCopyPasteNoHealConnectors = 4,
	visCopyPasteNoContainerMembers = 8,
	visCopyPasteNoAssociatedCallouts = 0x10,
	visCopyPasteDontAddToContainers = 0x20,
	visCopyPasteNoCascade = 0x40
}
