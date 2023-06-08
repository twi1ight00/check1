using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C3A-0000-0000-C000-000000000046")]
public enum VisOnComponentEnterCodes
{
	visComponentStateModal = 1,
	visModalDeferEvents = 0x10000,
	visModalNoBeforeAfter = 0x20000,
	visModalDontBlockMessages = 0x40000,
	visModalDisableVisiosFrame = 0x80000
}
