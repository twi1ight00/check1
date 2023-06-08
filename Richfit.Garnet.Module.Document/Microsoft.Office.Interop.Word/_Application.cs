using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word;

[ComImport]
[Guid("00020970-0000-0000-C000-000000000046")]
[CompilerGenerated]
[DefaultMember("Name")]
[TypeIdentifier]
public interface _Application
{
	void _VtblGap1_4();

	Documents Documents
	{
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap2_108();

	[DispId(1105)]
	void Quit([Optional][In][MarshalAs(UnmanagedType.Struct)] ref object SaveChanges, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object OriginalFormat, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object RouteDocument);
}
