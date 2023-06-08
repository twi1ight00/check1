using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0704-0000-0000-C000-000000000046")]
[CoClass(typeof(ConnectsClass))]
public interface Connects : IVConnects
{
}
