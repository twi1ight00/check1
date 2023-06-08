using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[ClassInterface(0)]
[Guid("000D0A05-0000-0000-C000-000000000046")]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EPages\0\0")]
public class PagesClass : IVPages, Pages, EPages_Event, IEnumerable
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
	public virtual extern Page this[[In][MarshalAs(UnmanagedType.Struct)] object NameOrIndex]
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

	[DispId(5)]
	public virtual extern Document Document
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(6)]
	public virtual extern short Stat
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		get;
	}

	[DispId(7)]
	public virtual extern EventList EventList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(7)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(8)]
	public virtual extern short PersistsEvents
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(8)]
		get;
	}

	[DispId(10)]
	public virtual extern Page ItemU
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1610743821)]
	public virtual extern Page ItemFromID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743821)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	public virtual extern event EPages_PageAddedEventHandler PageAdded;

	public virtual extern event EPages_PageChangedEventHandler PageChanged;

	public virtual extern event EPages_BeforePageDeleteEventHandler BeforePageDelete;

	public virtual extern event EPages_ShapeAddedEventHandler ShapeAdded;

	public virtual extern event EPages_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	public virtual extern event EPages_ShapeChangedEventHandler ShapeChanged;

	public virtual extern event EPages_SelectionAddedEventHandler SelectionAdded;

	public virtual extern event EPages_BeforeShapeDeleteEventHandler BeforeShapeDelete;

	public virtual extern event EPages_TextChangedEventHandler TextChanged;

	public virtual extern event EPages_CellChangedEventHandler CellChanged;

	public virtual extern event EPages_FormulaChangedEventHandler FormulaChanged;

	public virtual extern event EPages_ConnectionsAddedEventHandler ConnectionsAdded;

	public virtual extern event EPages_ConnectionsDeletedEventHandler ConnectionsDeleted;

	public virtual extern event EPages_QueryCancelPageDeleteEventHandler QueryCancelPageDelete;

	public virtual extern event EPages_PageDeleteCanceledEventHandler PageDeleteCanceled;

	public virtual extern event EPages_ShapeParentChangedEventHandler ShapeParentChanged;

	public virtual extern event EPages_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	public virtual extern event EPages_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	public virtual extern event EPages_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	public virtual extern event EPages_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	public virtual extern event EPages_QueryCancelUngroupEventHandler QueryCancelUngroup;

	public virtual extern event EPages_UngroupCanceledEventHandler UngroupCanceled;

	public virtual extern event EPages_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	public virtual extern event EPages_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	public virtual extern event EPages_QueryCancelGroupEventHandler QueryCancelGroup;

	public virtual extern event EPages_GroupCanceledEventHandler GroupCanceled;

	public virtual extern event EPages_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;

	public virtual extern event EPages_ShapeLinkAddedEventHandler ShapeLinkAdded;

	public virtual extern event EPages_ShapeLinkDeletedEventHandler ShapeLinkDeleted;

	public virtual extern event EPages_ContainerRelationshipAddedEventHandler ContainerRelationshipAdded;

	public virtual extern event EPages_ContainerRelationshipDeletedEventHandler ContainerRelationshipDeleted;

	public virtual extern event EPages_CalloutRelationshipAddedEventHandler CalloutRelationshipAdded;

	public virtual extern event EPages_CalloutRelationshipDeletedEventHandler CalloutRelationshipDeleted;

	public virtual extern event EPages_QueryCancelReplaceShapesEventHandler QueryCancelReplaceShapes;

	public virtual extern event EPages_ReplaceShapesCanceledEventHandler ReplaceShapesCanceled;

	public virtual extern event EPages_BeforeReplaceShapesEventHandler BeforeReplaceShapes;

	public virtual extern event EPages_AfterReplaceShapesEventHandler AfterReplaceShapes;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Page Add();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(9)]
	public virtual extern void GetNames([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array localeSpecificNameArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(11)]
	public virtual extern void GetNamesU([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array localeIndependentNameArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-4)]
	[TypeLibFunc(1)]
	[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public virtual extern IEnumerator GetEnumerator();
}
