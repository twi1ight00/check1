using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(MasterClass))]
[Guid("000D0707-0000-0000-C000-000000000046")]
public interface Master : IVMaster, EMaster_Event
{
}
