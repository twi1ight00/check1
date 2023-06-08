using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComImport]
[TypeLibType(4112)]
[Guid("000D0B00-0000-0000-C000-000000000046")]
[InterfaceType(2)]
public interface EApplication
{
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4097)]
	void AppActivated([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4098)]
	void AppDeactivated([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4100)]
	void AppObjActivated([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4104)]
	void AppObjDeactivated([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4112)]
	void BeforeQuit([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4128)]
	void BeforeModal([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4160)]
	void AfterModal([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32769)]
	void WindowOpened([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(701)]
	void SelectionChanged([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16385)]
	void BeforeWindowClosed([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4224)]
	void WindowActivated([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(702)]
	void BeforeWindowSelDelete([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(703)]
	void BeforeWindowPageTurn([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(704)]
	void WindowTurnedToPage([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2)]
	void DocumentOpened([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1)]
	void DocumentCreated([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3)]
	void DocumentSaved([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4)]
	void DocumentSavedAs([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8194)]
	void DocumentChanged([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16386)]
	void BeforeDocumentClose([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32772)]
	void StyleAdded([In][MarshalAs(UnmanagedType.Interface)] Style Style);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8196)]
	void StyleChanged([In][MarshalAs(UnmanagedType.Interface)] Style Style);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16388)]
	void BeforeStyleDelete([In][MarshalAs(UnmanagedType.Interface)] Style Style);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32776)]
	void MasterAdded([In][MarshalAs(UnmanagedType.Interface)] Master Master);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8200)]
	void MasterChanged([In][MarshalAs(UnmanagedType.Interface)] Master Master);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16392)]
	void BeforeMasterDelete([In][MarshalAs(UnmanagedType.Interface)] Master Master);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32784)]
	void PageAdded([In][MarshalAs(UnmanagedType.Interface)] Page Page);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8208)]
	void PageChanged([In][MarshalAs(UnmanagedType.Interface)] Page Page);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(16400)]
	void BeforePageDelete([In][MarshalAs(UnmanagedType.Interface)] Page Page);

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
	[DispId(4352)]
	void MarkerEvent([In][MarshalAs(UnmanagedType.Interface)] Application app, [In] int SequenceNum, [In][MarshalAs(UnmanagedType.BStr)] string ContextString);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(4608)]
	void NoEventsPending([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5120)]
	void VisioIsIdle([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(200)]
	void MustFlushScopeBeginning([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(201)]
	void MustFlushScopeEnded([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(5)]
	void RunModeEntered([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(6)]
	void DesignModeEntered([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(7)]
	void BeforeDocumentSave([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8)]
	void BeforeDocumentSaveAs([In][MarshalAs(UnmanagedType.Interface)] Document doc);

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
	[DispId(202)]
	void EnterScope([In][MarshalAs(UnmanagedType.Interface)] Application app, [In] int nScopeID, [In][MarshalAs(UnmanagedType.BStr)] string bstrDescription);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(203)]
	void ExitScope([In][MarshalAs(UnmanagedType.Interface)] Application app, [In] int nScopeID, [In][MarshalAs(UnmanagedType.BStr)] string bstrDescription, [In] bool bErrOrCancelled);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(204)]
	bool QueryCancelQuit([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(205)]
	void QuitCanceled([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8193)]
	void WindowChanged([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(705)]
	void ViewChanged([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(706)]
	bool QueryCancelWindowClose([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(707)]
	void WindowCloseCanceled([In][MarshalAs(UnmanagedType.Interface)] Window Window);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(9)]
	bool QueryCancelDocumentClose([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10)]
	void DocumentCloseCanceled([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(300)]
	bool QueryCancelStyleDelete([In][MarshalAs(UnmanagedType.Interface)] Style Style);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(301)]
	void StyleDeleteCanceled([In][MarshalAs(UnmanagedType.Interface)] Style Style);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(400)]
	bool QueryCancelMasterDelete([In][MarshalAs(UnmanagedType.Interface)] Master Master);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(401)]
	void MasterDeleteCanceled([In][MarshalAs(UnmanagedType.Interface)] Master Master);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(500)]
	bool QueryCancelPageDelete([In][MarshalAs(UnmanagedType.Interface)] Page Page);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(501)]
	void PageDeleteCanceled([In][MarshalAs(UnmanagedType.Interface)] Page Page);

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
	[DispId(206)]
	bool QueryCancelSuspend([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(207)]
	void SuspendCanceled([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(208)]
	void BeforeSuspend([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(209)]
	void AfterResume([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(708)]
	bool OnKeystrokeMessageForAddon([In][MarshalAs(UnmanagedType.Interface)] MSGWrap MSG);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(709)]
	void MouseDown([In] int Button, [In] int KeyButtonState, [In] double x, [In] double y, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(710)]
	void MouseMove([In] int Button, [In] int KeyButtonState, [In] double x, [In] double y, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(711)]
	void MouseUp([In] int Button, [In] int KeyButtonState, [In] double x, [In] double y, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(712)]
	void KeyDown([In] int KeyCode, [In] int KeyButtonState, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(713)]
	void KeyPress([In] int KeyAscii, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(714)]
	void KeyUp([In] int KeyCode, [In] int KeyButtonState, [In][Out] ref bool CancelDefault);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(210)]
	bool QueryCancelSuspendEvents([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(211)]
	void SuspendEventsCanceled([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(212)]
	void BeforeSuspendEvents([In][MarshalAs(UnmanagedType.Interface)] Application app);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(213)]
	void AfterResumeEvents([In][MarshalAs(UnmanagedType.Interface)] Application app);

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
	[DispId(16416)]
	void BeforeDataRecordsetDelete([In][MarshalAs(UnmanagedType.Interface)] DataRecordset DataRecordset);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8224)]
	void DataRecordsetChanged([In][MarshalAs(UnmanagedType.Interface)] DataRecordsetChangedEvent DataRecordsetChanged);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32800)]
	void DataRecordsetAdded([In][MarshalAs(UnmanagedType.Interface)] DataRecordset DataRecordset);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(805)]
	void ShapeLinkAdded([In][MarshalAs(UnmanagedType.Interface)] Shape Shape, [In] int DataRecordsetID, [In] int DataRowID);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(806)]
	void ShapeLinkDeleted([In][MarshalAs(UnmanagedType.Interface)] Shape Shape, [In] int DataRecordsetID, [In] int DataRowID);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(11)]
	void AfterRemoveHiddenInformation([In][MarshalAs(UnmanagedType.Interface)] Document doc);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(502)]
	void ContainerRelationshipAdded([In][MarshalAs(UnmanagedType.Interface)] RelatedShapePairEvent ShapePair);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(503)]
	void ContainerRelationshipDeleted([In][MarshalAs(UnmanagedType.Interface)] RelatedShapePairEvent ShapePair);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(504)]
	void CalloutRelationshipAdded([In][MarshalAs(UnmanagedType.Interface)] RelatedShapePairEvent ShapePair);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(505)]
	void CalloutRelationshipDeleted([In][MarshalAs(UnmanagedType.Interface)] RelatedShapePairEvent ShapePair);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(13)]
	void RuleSetValidated([In][MarshalAs(UnmanagedType.Interface)] ValidationRuleSet RuleSet);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(911)]
	bool QueryCancelReplaceShapes([In][MarshalAs(UnmanagedType.Interface)] ReplaceShapesEvent replaceShapes);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(912)]
	void ReplaceShapesCanceled([In][MarshalAs(UnmanagedType.Interface)] ReplaceShapesEvent replaceShapes);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(913)]
	void BeforeReplaceShapes([In][MarshalAs(UnmanagedType.Interface)] ReplaceShapesEvent replaceShapes);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(914)]
	void AfterReplaceShapes([In][MarshalAs(UnmanagedType.Interface)] Selection sel);
}
