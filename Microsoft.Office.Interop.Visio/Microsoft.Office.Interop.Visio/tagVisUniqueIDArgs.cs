using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C0E-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisUniqueIDArgs
{
	visGetGUID,
	visGetOrMakeGUID,
	visDeleteGUID,
	visGetOrMakeGUIDWithUndo,
	visDeleteGUIDWithUndo
}
