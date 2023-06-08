using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D072F-0000-0000-C000-000000000046")]
[CoClass(typeof(DataRecordsetClass))]
public interface DataRecordset : IVDataRecordset, EDataRecordset_Event
{
}
