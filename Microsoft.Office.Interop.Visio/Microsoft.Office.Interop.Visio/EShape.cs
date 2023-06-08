using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[InterfaceType(2)]
[Guid("000D0B0B-0000-0000-C000-000000000046")]
[TypeLibType(4112)]
public interface EShape
{
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10240)]
	void CellChanged([In][MarshalAs(UnmanagedType.Interface)] Cell Cell);

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
	[DispId(12288)]
	void FormulaChanged([In][MarshalAs(UnmanagedType.Interface)] Cell Cell);

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

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(805)]
	void ShapeLinkAdded([In][MarshalAs(UnmanagedType.Interface)] Shape Shape, [In] int DataRecordsetID, [In] int DataRowID);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(806)]
	void ShapeLinkDeleted([In][MarshalAs(UnmanagedType.Interface)] Shape Shape, [In] int DataRecordsetID, [In] int DataRowID);
}
