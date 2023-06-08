using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(OLEObjectsClass))]
[Guid("000D071E-0000-0000-C000-000000000046")]
public interface OLEObjects : IVOLEObjects
{
}
