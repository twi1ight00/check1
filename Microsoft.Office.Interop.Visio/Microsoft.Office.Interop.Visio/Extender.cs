using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(ExtenderClass))]
[Guid("000D0D0F-0000-0000-C000-000000000046")]
public interface Extender : IVDispExtender, EShape_Event
{
}
