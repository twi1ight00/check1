using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[TypeLibType(4112)]
[InterfaceType(2)]
[Guid("000D0B10-0000-0000-C000-000000000046")]
public interface EDataRecordsets
{
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32800)]
	void DataRecordsetAdded([In][MarshalAs(UnmanagedType.Interface)] DataRecordset DataRecordset);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16416)]
	void BeforeDataRecordsetDelete([In][MarshalAs(UnmanagedType.Interface)] DataRecordset DataRecordset);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8224)]
	void DataRecordsetChanged([In][MarshalAs(UnmanagedType.Interface)] DataRecordsetChangedEvent DataRecordsetChanged);
}
