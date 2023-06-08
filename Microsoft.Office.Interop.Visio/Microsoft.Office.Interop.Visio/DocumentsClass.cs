using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[Guid("000D0A00-0000-0000-C000-000000000046")]
[ClassInterface(0)]
[ComSourceInterfaces("Microsoft.Office.Interop.Visio.EDocuments\0\0")]
public class DocumentsClass : IVDocuments, Documents, EDocuments_Event, IEnumerable
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
	public virtual extern Document this[[In][MarshalAs(UnmanagedType.Struct)] object NameOrIndex]
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

	[DispId(1610743819)]
	public virtual extern Document ItemFromID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1610743819)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	public virtual extern event EDocuments_DocumentOpenedEventHandler DocumentOpened;

	public virtual extern event EDocuments_DocumentCreatedEventHandler DocumentCreated;

	public virtual extern event EDocuments_DocumentSavedEventHandler DocumentSaved;

	public virtual extern event EDocuments_DocumentSavedAsEventHandler DocumentSavedAs;

	public virtual extern event EDocuments_DocumentChangedEventHandler DocumentChanged;

	public virtual extern event EDocuments_BeforeDocumentCloseEventHandler BeforeDocumentClose;

	public virtual extern event EDocuments_StyleAddedEventHandler StyleAdded;

	public virtual extern event EDocuments_StyleChangedEventHandler StyleChanged;

	public virtual extern event EDocuments_BeforeStyleDeleteEventHandler BeforeStyleDelete;

	public virtual extern event EDocuments_MasterAddedEventHandler MasterAdded;

	public virtual extern event EDocuments_MasterChangedEventHandler MasterChanged;

	public virtual extern event EDocuments_BeforeMasterDeleteEventHandler BeforeMasterDelete;

	public virtual extern event EDocuments_PageAddedEventHandler PageAdded;

	public virtual extern event EDocuments_PageChangedEventHandler PageChanged;

	public virtual extern event EDocuments_BeforePageDeleteEventHandler BeforePageDelete;

	public virtual extern event EDocuments_ShapeAddedEventHandler ShapeAdded;

	public virtual extern event EDocuments_BeforeSelectionDeleteEventHandler BeforeSelectionDelete;

	public virtual extern event EDocuments_ShapeChangedEventHandler ShapeChanged;

	public virtual extern event EDocuments_SelectionAddedEventHandler SelectionAdded;

	public virtual extern event EDocuments_BeforeShapeDeleteEventHandler BeforeShapeDelete;

	public virtual extern event EDocuments_TextChangedEventHandler TextChanged;

	public virtual extern event EDocuments_CellChangedEventHandler CellChanged;

	public virtual extern event EDocuments_RunModeEnteredEventHandler RunModeEntered;

	public virtual extern event EDocuments_DesignModeEnteredEventHandler DesignModeEntered;

	public virtual extern event EDocuments_BeforeDocumentSaveEventHandler BeforeDocumentSave;

	public virtual extern event EDocuments_BeforeDocumentSaveAsEventHandler BeforeDocumentSaveAs;

	public virtual extern event EDocuments_FormulaChangedEventHandler FormulaChanged;

	public virtual extern event EDocuments_ConnectionsAddedEventHandler ConnectionsAdded;

	public virtual extern event EDocuments_ConnectionsDeletedEventHandler ConnectionsDeleted;

	public virtual extern event EDocuments_QueryCancelDocumentCloseEventHandler QueryCancelDocumentClose;

	public virtual extern event EDocuments_DocumentCloseCanceledEventHandler DocumentCloseCanceled;

	public virtual extern event EDocuments_QueryCancelStyleDeleteEventHandler QueryCancelStyleDelete;

	public virtual extern event EDocuments_StyleDeleteCanceledEventHandler StyleDeleteCanceled;

	public virtual extern event EDocuments_QueryCancelMasterDeleteEventHandler QueryCancelMasterDelete;

	public virtual extern event EDocuments_MasterDeleteCanceledEventHandler MasterDeleteCanceled;

	public virtual extern event EDocuments_QueryCancelPageDeleteEventHandler QueryCancelPageDelete;

	public virtual extern event EDocuments_PageDeleteCanceledEventHandler PageDeleteCanceled;

	public virtual extern event EDocuments_ShapeParentChangedEventHandler ShapeParentChanged;

	public virtual extern event EDocuments_BeforeShapeTextEditEventHandler BeforeShapeTextEdit;

	public virtual extern event EDocuments_ShapeExitedTextEditEventHandler ShapeExitedTextEdit;

	public virtual extern event EDocuments_QueryCancelSelectionDeleteEventHandler QueryCancelSelectionDelete;

	public virtual extern event EDocuments_SelectionDeleteCanceledEventHandler SelectionDeleteCanceled;

	public virtual extern event EDocuments_QueryCancelUngroupEventHandler QueryCancelUngroup;

	public virtual extern event EDocuments_UngroupCanceledEventHandler UngroupCanceled;

	public virtual extern event EDocuments_QueryCancelConvertToGroupEventHandler QueryCancelConvertToGroup;

	public virtual extern event EDocuments_ConvertToGroupCanceledEventHandler ConvertToGroupCanceled;

	public virtual extern event EDocuments_QueryCancelGroupEventHandler QueryCancelGroup;

	public virtual extern event EDocuments_GroupCanceledEventHandler GroupCanceled;

	public virtual extern event EDocuments_ShapeDataGraphicChangedEventHandler ShapeDataGraphicChanged;

	public virtual extern event EDocuments_BeforeDataRecordsetDeleteEventHandler BeforeDataRecordsetDelete;

	public virtual extern event EDocuments_DataRecordsetChangedEventHandler DataRecordsetChanged;

	public virtual extern event EDocuments_DataRecordsetAddedEventHandler DataRecordsetAdded;

	public virtual extern event EDocuments_ShapeLinkAddedEventHandler ShapeLinkAdded;

	public virtual extern event EDocuments_ShapeLinkDeletedEventHandler ShapeLinkDeleted;

	public virtual extern event EDocuments_AfterRemoveHiddenInformationEventHandler AfterRemoveHiddenInformation;

	public virtual extern event EDocuments_ContainerRelationshipAddedEventHandler ContainerRelationshipAdded;

	public virtual extern event EDocuments_ContainerRelationshipDeletedEventHandler ContainerRelationshipDeleted;

	public virtual extern event EDocuments_CalloutRelationshipAddedEventHandler CalloutRelationshipAdded;

	public virtual extern event EDocuments_CalloutRelationshipDeletedEventHandler CalloutRelationshipDeleted;

	public virtual extern event EDocuments_RuleSetValidatedEventHandler RuleSetValidated;

	public virtual extern event EDocuments_QueryCancelReplaceShapesEventHandler QueryCancelReplaceShapes;

	public virtual extern event EDocuments_ReplaceShapesCanceledEventHandler ReplaceShapesCanceled;

	public virtual extern event EDocuments_BeforeReplaceShapesEventHandler BeforeReplaceShapes;

	public virtual extern event EDocuments_AfterReplaceShapesEventHandler AfterReplaceShapes;

	public virtual extern event EDocuments_AfterDocumentMergeEventHandler AfterDocumentMerge;

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Document Add([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Document Open([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Document OpenEx([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] short Flags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(9)]
	public virtual extern void GetNames([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out Array NameArray);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-4)]
	[TypeLibFunc(1)]
	[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public virtual extern IEnumerator GetEnumerator();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743820)]
	public virtual extern bool CanCheckOut([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743821)]
	public virtual extern void CheckOut([In][MarshalAs(UnmanagedType.BStr)] string FileName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610743822)]
	[return: MarshalAs(UnmanagedType.Interface)]
	public virtual extern Document AddEx([In][MarshalAs(UnmanagedType.BStr)] string FileName, [In] VisMeasurementSystem MeasurementSystem = VisMeasurementSystem.visMSDefault, [In] int Flags = 0, [In] int LangID = 0);
}
