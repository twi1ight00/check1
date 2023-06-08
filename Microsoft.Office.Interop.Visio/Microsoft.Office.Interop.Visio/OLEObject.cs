using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(OLEObjectClass))]
[Guid("000D071F-0000-0000-C000-000000000046")]
public interface OLEObject : IVOLEObject
{
}
