using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(RowClass))]
[Guid("000D0725-0000-0000-C000-000000000046")]
public interface Row : IVRow, ERow_Event
{
}
