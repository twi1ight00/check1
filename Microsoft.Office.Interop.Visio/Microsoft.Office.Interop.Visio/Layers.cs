using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(LayersClass))]
[Guid("000D0713-0000-0000-C000-000000000046")]
public interface Layers : IVLayers
{
}
