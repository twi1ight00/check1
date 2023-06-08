using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(EventClass))]
[Guid("000D071A-0000-0000-C000-000000000046")]
public interface Event : IVEvent
{
}
