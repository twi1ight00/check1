using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(ToolbarsClass))]
[Guid("000D0255-0000-0000-C000-000000000046")]
public interface Toolbars : IVToolbars
{
}
