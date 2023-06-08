using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(DataColumnsClass))]
[Guid("000D0731-0000-0000-C000-000000000046")]
public interface DataColumns : IVDataColumns
{
}
