using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(EventListClass))]
[Guid("000D071B-0000-0000-C000-000000000046")]
public interface EventList : IVEventList
{
}
