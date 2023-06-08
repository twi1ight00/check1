using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(StatusBarsClass))]
[Guid("000D0285-0000-0000-C000-000000000046")]
public interface StatusBars : IVStatusBars
{
}
