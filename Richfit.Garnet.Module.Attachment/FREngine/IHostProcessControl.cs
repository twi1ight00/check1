using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[Guid("110010ED-0000-1056-976E-008048D53AE3")]
[TypeIdentifier]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[CompilerGenerated]
public interface IHostProcessControl
{
	void _VtblGap1_1();

	void SetClientProcessId([In] int Id);

	int ProcessId { get; }
}
