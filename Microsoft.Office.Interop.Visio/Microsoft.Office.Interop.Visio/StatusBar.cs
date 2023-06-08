using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(StatusBarClass))]
[Guid("000D0282-0000-0000-C000-000000000046")]
public interface StatusBar : IVStatusBar
{
}
