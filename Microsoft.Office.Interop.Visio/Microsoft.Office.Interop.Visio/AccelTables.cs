using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D02A5-0000-0000-C000-000000000046")]
[CoClass(typeof(AccelTablesClass))]
public interface AccelTables : IVAccelTables
{
}
