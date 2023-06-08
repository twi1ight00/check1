using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0295-0000-0000-C000-000000000046")]
[CoClass(typeof(AccelItemsClass))]
public interface AccelItems : IVAccelItems
{
}
