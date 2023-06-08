using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0242-0000-0000-C000-000000000046")]
[CoClass(typeof(ToolbarItemClass))]
public interface ToolbarItem : IVToolbarItem
{
}
