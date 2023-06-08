using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0720-0000-0000-C000-000000000046")]
[CoClass(typeof(PathsClass))]
public interface Paths : IVPaths
{
}
