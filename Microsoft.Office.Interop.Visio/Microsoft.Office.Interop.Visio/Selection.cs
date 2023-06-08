using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(SelectionClass))]
[Guid("000D070B-0000-0000-C000-000000000046")]
public interface Selection : IVSelection
{
}
