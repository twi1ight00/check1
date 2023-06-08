using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[TypeLibType(4112)]
[Guid("000D0B08-0000-0000-C000-000000000046")]
[InterfaceType(2)]
public interface EMaster
{
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8200)]
	void MasterChanged([In][MarshalAs(UnmanagedType.Interface)] Master Master);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16392)]
	void BeforeMasterDelete([In][MarshalAs(UnmanagedType.Interface)] Master Master);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32832)]
	void ShapeAdded([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(901)]
	void BeforeSelectionDelete([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8256)]
	void ShapeChanged([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(902)]
	void SelectionAdded([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16448)]
	void BeforeShapeDelete([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8320)]
	void TextChanged([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10240)]
	void CellChanged([In][MarshalAs(UnmanagedType.Interface)] Cell Cell);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12288)]
	void FormulaChanged([In][MarshalAs(UnmanagedType.Interface)] Cell Cell);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(33024)]
	void ConnectionsAdded([In][MarshalAs(UnmanagedType.Interface)] Connects Connects);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16640)]
	void ConnectionsDeleted([In][MarshalAs(UnmanagedType.Interface)] Connects Connects);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(400)]
	bool QueryCancelMasterDelete([In][MarshalAs(UnmanagedType.Interface)] Master Master);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(401)]
	void MasterDeleteCanceled([In][MarshalAs(UnmanagedType.Interface)] Master Master);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(802)]
	void ShapeParentChanged([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(803)]
	void BeforeShapeTextEdit([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(804)]
	void ShapeExitedTextEdit([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(903)]
	bool QueryCancelSelectionDelete([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(904)]
	void SelectionDeleteCanceled([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(905)]
	bool QueryCancelUngroup([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(906)]
	void UngroupCanceled([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(907)]
	bool QueryCancelConvertToGroup([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(908)]
	void ConvertToGroupCanceled([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(909)]
	bool QueryCancelGroup([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(910)]
	void GroupCanceled([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(807)]
	void ShapeDataGraphicChanged([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
}
