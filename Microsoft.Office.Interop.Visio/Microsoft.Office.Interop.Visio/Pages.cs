using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(PagesClass))]
[Guid("000D070A-0000-0000-C000-000000000046")]
public interface Pages : IVPages, EPages_Event
{
}
