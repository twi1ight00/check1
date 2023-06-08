using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(AccelTableClass))]
[Guid("000D02A2-0000-0000-C000-000000000046")]
public interface AccelTable : IVAccelTable
{
}
