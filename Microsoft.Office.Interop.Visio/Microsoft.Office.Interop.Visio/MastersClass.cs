using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[ClassInterface(0)]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EMasters\0\0")]
[Guid("000D0A03-0000-0000-C000-000000000046")]
public class MastersClass : IVMasters, Masters, EMasters_Event, IEnumerable
{
	[DispId(3)]
	public virtual extern Application Application
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(2)]
	public virtual extern short ObjectType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		get;
	}

	[DispId(0)]
	public virtual extern Master this[[In][MarshalAs(UnmanagedType.Struct)] object NameUIDOrIndex]
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1)]
	public virtual extern short Count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		get;
	}

	[DispId(4)]
	public virtual extern Document Document
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(5)]
	public virtual extern short Stat
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		get;
	}

	[DispId(6)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(7)]
	public virtual extern short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(7)]
		get;
	}

	[DispId(11)]
	public virtual extern Master ItemU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(11)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743822)]
	public virtual extern Master ItemFromID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743822)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	public virtual extern event EMasters_MasterAddedEventHandler MasterAdded;

	public virtual extern event EMasters_MasterChangedEventHandler MasterChanged;

	public virtual extern event EMasters_BeforeMasterDeleteEventHandler BeforeMasterDelete;

	public virtual extern event EMasters_ShapeAddedEventHandler ShapeAdded;

	public virtual extern event EMasters_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	public virtual extern event EMasters_ShapeChangedEventHandler ShapeChanged;

	public virtual extern event EMasters_SelectionAddedEventHandler SelectionAdded;

	public virtual extern event EMasters_BeforeShapeDeleteEventHandler BeforeShapeDelete;

	public virtual extern event EMasters_TextChangedEventHandler TextChanged;

	public virtual extern event EMasters_CellChangedEventHandler CellChanged;

	public virtual extern event EMasters_FormulaChangedEventHandler FormulaChanged;

	public virtual extern event EMasters_ConnectionsAddedEventHandler ConnectionsAdded;

	public virtual extern event EMasters_ConnectionsDeletedEventHandler ConnectionsDeleted;

	public virtual extern event EMasters_QueryCancelMasterDeleteEventHandler QueryCancelMasterDelete;

	public virtual extern event EMasters_MasterDeleteCanceledEventHandler MasterDeleteCanceled;

	public virtual extern event EMasters_ShapeParentChangedEventHandler ShapeParentChanged;

	public virtual extern event EMasters_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	public virtual extern event EMasters_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	public virtual extern event EMasters_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	public virtual extern event EMasters_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	public virtual extern event EMasters_QueryCancelUngroupEventHandler QueryCancelUngroup;

	public virtual extern event EMasters_UngroupCanceledEventHandler UngroupCanceled;

	public virtual extern event EMasters_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	public virtual extern event EMasters_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	public virtual extern event EMasters_QueryCancelGroupEventHandler QueryCancelGroup;

	public virtual extern event EMasters_GroupCanceledEventHandler GroupCanceled;

	public virtual extern event EMasters_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Master Add();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(9)]
	public virtual extern void GetNames([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array localeSpecificNameArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Master Drop([In][MarshalAs(UnmanagedType.IUnknown)] object ObjectToDrop, [In] short xPos, [In] short yPos);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12)]
	public virtual extern void GetNamesU([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array localeIndependentNameArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[TypeLibFunc(1)]
	[DispId(-4)]
	[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public virtual extern IEnumerator GetEnumerator();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743823)]
	public virtual extern void Paste([Optional][In][MarshalAs(UnmanagedType.Struct)] object Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743824)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Master AddEx([In] VisMasterTypes Type);
}
