using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[CoClass(typeof(MasterShortcutClass))]
[Guid("000D0727-0000-0000-C000-000000000046")]
public interface MasterShortcut : IVMasterShortcut
{
}
