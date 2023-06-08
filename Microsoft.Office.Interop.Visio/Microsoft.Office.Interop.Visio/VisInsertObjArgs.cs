using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C0B-0000-0000-C000-000000000046")]
public enum VisInsertObjArgs
{
	visInsertLink = 8,
	visInsertIcon = 16,
	visInsertDontShow = 4096,
	visInsertAsControl = 8192,
	visInsertAsEmbed = 16384,
	visInsertNoDesignModeTransition = 256
}
