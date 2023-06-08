using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(AddonClass))]
[Guid("000D0718-0000-0000-C000-000000000046")]
public interface Addon : IVAddon
{
}
