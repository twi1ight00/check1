using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C0F-0000-0000-C000-000000000046")]
public enum tagVisExistsFlags
{
	visExistsLocally = 1,
	visExistsAnywhere = 0
}
