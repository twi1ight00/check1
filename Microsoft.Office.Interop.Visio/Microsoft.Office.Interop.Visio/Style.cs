using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(StyleClass))]
[Guid("000D070E-0000-0000-C000-000000000046")]
public interface Style : IVStyle, EStyle_Event
{
}
