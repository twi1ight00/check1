using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(MastersClass))]
[Guid("000D0708-0000-0000-C000-000000000046")]
public interface Masters : IVMasters, EMasters_Event
{
}
