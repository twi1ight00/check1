using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(MovedSelectionEventClass))]
[Guid("000D0738-0000-0000-C000-000000000046")]
public interface MovedSelectionEvent : IVMovedSelectionEvent
{
}
