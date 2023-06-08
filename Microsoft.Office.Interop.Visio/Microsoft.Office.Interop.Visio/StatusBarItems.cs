using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(StatusBarItemsClass))]
[Guid("000D0275-0000-0000-C000-000000000046")]
public interface StatusBarItems : IVStatusBarItems
{
}
