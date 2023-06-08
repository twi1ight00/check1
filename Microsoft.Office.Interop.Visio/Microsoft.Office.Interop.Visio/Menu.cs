using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(MenuClass))]
[Guid("000D0222-0000-0000-C000-000000000046")]
public interface Menu : IVMenu
{
}
