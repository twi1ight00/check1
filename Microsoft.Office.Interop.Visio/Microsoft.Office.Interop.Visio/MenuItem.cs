using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0212-0000-0000-C000-000000000046")]
[CoClass(typeof(MenuItemClass))]
public interface MenuItem : IVMenuItem
{
}
