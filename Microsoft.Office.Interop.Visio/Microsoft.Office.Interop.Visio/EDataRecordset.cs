using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0B11-0000-0000-C000-000000000046")]
[TypeLibType(4112)]
[InterfaceType(2)]
public interface EDataRecordset
{
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8224)]
	void DataRecordsetChanged([In][MarshalAs(UnmanagedType.Interface)] DataRecordsetChangedEvent DataRecordsetChanged);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16416)]
	void BeforeDataRecordsetDelete([In][MarshalAs(UnmanagedType.Interface)] DataRecordset DataRecordset);
}
