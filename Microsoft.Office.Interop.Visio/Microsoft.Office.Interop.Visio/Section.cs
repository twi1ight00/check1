using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0724-0000-0000-C000-000000000046")]
[CoClass(typeof(SectionClass))]
public interface Section : IVSection, ESection_Event
{
}
