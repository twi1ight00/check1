using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class EApplication_SinkHelper : EApplication
{
	public EApplication_PageDeleteCanceledEventHandler m_PageDeleteCanceledDelegate;

	public EApplication_ShapeParentChangedEventHandler m_ShapeParentChangedDelegate;

	public EApplication_BeforeShapeTextEditEventHandler m_BeforeShapeTextEditDelegate;

	public EApplication_ShapeExitedTextEditEventHandler m_ShapeExitedTextEditDelegate;

	public EApplication_QueryCancelSelectionDeleteEventHandler m_QueryCancelSelectionDeleteDelegate;

	public EApplication_SelectionDeleteCanceledEventHandler m_SelectionDeleteCanceledDelegate;

	public EApplication_QueryCancelUngroupEventHandler m_QueryCancelUngroupDelegate;

	public EApplication_UngroupCanceledEventHandler m_UngroupCanceledDelegate;

	public EApplication_QueryCancelConvertToGroupEventHandler m_QueryCancelConvertToGroupDelegate;

	public EApplication_ConvertToGroupCanceledEventHandler m_ConvertToGroupCanceledDelegate;

	public EApplication_QueryCancelSuspendEventHandler m_QueryCancelSuspendDelegate;

	public EApplication_SuspendCanceledEventHandler m_SuspendCanceledDelegate;

	public EApplication_BeforeSuspendEventHandler m_BeforeSuspendDelegate;

	public EApplication_AfterResumeEventHandler m_AfterResumeDelegate;

	public EApplication_OnKeystrokeMessageForAddonEventHandler m_OnKeystrokeMessageForAddonDelegate;

	public EApplication_MouseDownEventHandler m_MouseDownDelegate;

	public EApplication_MouseMoveEventHandler m_MouseMoveDelegate;

	public EApplication_MouseUpEventHandler m_MouseUpDelegate;

	public EApplication_KeyDownEventHandler m_KeyDownDelegate;

	public EApplication_KeyPressEventHandler m_KeyPressDelegate;

	public EApplication_KeyUpEventHandler m_KeyUpDelegate;

	public EApplication_QueryCancelSuspendEventsEventHandler m_QueryCancelSuspendEventsDelegate;

	public EApplication_SuspendEventsCanceledEventHandler m_SuspendEventsCanceledDelegate;

	public EApplication_BeforeSuspendEventsEventHandler m_BeforeSuspendEventsDelegate;

	public EApplication_AfterResumeEventsEventHandler m_AfterResumeEventsDelegate;

	public EApplication_QueryCancelGroupEventHandler m_QueryCancelGroupDelegate;

	public EApplication_GroupCanceledEventHandler m_GroupCanceledDelegate;

	public EApplication_ShapeDataGraphicChangedEventHandler m_ShapeDataGraphicChangedDelegate;

	public EApplication_BeforeDataRecordsetDeleteEventHandler m_BeforeDataRecordsetDeleteDelegate;

	public EApplication_DataRecordsetChangedEventHandler m_DataRecordsetChangedDelegate;

	public EApplication_DataRecordsetAddedEventHandler m_DataRecordsetAddedDelegate;

	public EApplication_ShapeLinkAddedEventHandler m_ShapeLinkAddedDelegate;

	public EApplication_ShapeLinkDeletedEventHandler m_ShapeLinkDeletedDelegate;

	public EApplication_AfterRemoveHiddenInformationEventHandler m_AfterRemoveHiddenInformationDelegate;

	public EApplication_ContainerRelationshipAddedEventHandler m_ContainerRelationshipAddedDelegate;

	public EApplication_ContainerRelationshipDeletedEventHandler m_ContainerRelationshipDeletedDelegate;

	public EApplication_CalloutRelationshipAddedEventHandler m_CalloutRelationshipAddedDelegate;

	public EApplication_CalloutRelationshipDeletedEventHandler m_CalloutRelationshipDeletedDelegate;

	public EApplication_RuleSetValidatedEventHandler m_RuleSetValidatedDelegate;

	public EApplication_QueryCancelReplaceShapesEventHandler m_QueryCancelReplaceShapesDelegate;

	public EApplication_ReplaceShapesCanceledEventHandler m_ReplaceShapesCanceledDelegate;

	public EApplication_BeforeReplaceShapesEventHandler m_BeforeReplaceShapesDelegate;

	public EApplication_AfterReplaceShapesEventHandler m_AfterReplaceShapesDelegate;

	public EApplication_AppActivatedEventHandler m_AppActivatedDelegate;

	public EApplication_AppDeactivatedEventHandler m_AppDeactivatedDelegate;

	public EApplication_AppObjActivatedEventHandler m_AppObjActivatedDelegate;

	public EApplication_AppObjDeactivatedEventHandler m_AppObjDeactivatedDelegate;

	public EApplication_BeforeQuitEventHandler m_BeforeQuitDelegate;

	public EApplication_BeforeModalEventHandler m_BeforeModalDelegate;

	public EApplication_AfterModalEventHandler m_AfterModalDelegate;

	public EApplication_WindowOpenedEventHandler m_WindowOpenedDelegate;

	public EApplication_SelectionChangedEventHandler m_SelectionChangedDelegate;

	public EApplication_BeforeWindowClosedEventHandler m_BeforeWindowClosedDelegate;

	public EApplication_WindowActivatedEventHandler m_WindowActivatedDelegate;

	public EApplication_BeforeWindowSelDeleteEventHandler m_BeforeWindowSelDeleteDelegate;

	public EApplication_BeforeWindowPageTurnEventHandler m_BeforeWindowPageTurnDelegate;

	public EApplication_WindowTurnedToPageEventHandler m_WindowTurnedToPageDelegate;

	public EApplication_DocumentOpenedEventHandler m_DocumentOpenedDelegate;

	public EApplication_DocumentCreatedEventHandler m_DocumentCreatedDelegate;

	public EApplication_DocumentSavedEventHandler m_DocumentSavedDelegate;

	public EApplication_DocumentSavedAsEventHandler m_DocumentSavedAsDelegate;

	public EApplication_DocumentChangedEventHandler m_DocumentChangedDelegate;

	public EApplication_BeforeDocumentCloseEventHandler m_BeforeDocumentCloseDelegate;

	public EApplication_StyleAddedEventHandler m_StyleAddedDelegate;

	public EApplication_StyleChangedEventHandler m_StyleChangedDelegate;

	public EApplication_BeforeStyleDeleteEventHandler m_BeforeStyleDeleteDelegate;

	public EApplication_MasterAddedEventHandler m_MasterAddedDelegate;

	public EApplication_MasterChangedEventHandler m_MasterChangedDelegate;

	public EApplication_BeforeMasterDeleteEventHandler m_BeforeMasterDeleteDelegate;

	public EApplication_PageAddedEventHandler m_PageAddedDelegate;

	public EApplication_PageChangedEventHandler m_PageChangedDelegate;

	public EApplication_BeforePageDeleteEventHandler m_BeforePageDeleteDelegate;

	public EApplication_ShapeAddedEventHandler m_ShapeAddedDelegate;

	public EApplication_BeforeSelectionDeleteEventHandler m_BeforeSelectionDeleteDelegate;

	public EApplication_ShapeChangedEventHandler m_ShapeChangedDelegate;

	public EApplication_SelectionAddedEventHandler m_SelectionAddedDelegate;

	public EApplication_BeforeShapeDeleteEventHandler m_BeforeShapeDeleteDelegate;

	public EApplication_TextChangedEventHandler m_TextChangedDelegate;

	public EApplication_CellChangedEventHandler m_CellChangedDelegate;

	public EApplication_MarkerEventEventHandler m_MarkerEventDelegate;

	public EApplication_NoEventsPendingEventHandler m_NoEventsPendingDelegate;

	public EApplication_VisioIsIdleEventHandler m_VisioIsIdleDelegate;

	public EApplication_MustFlushScopeBeginningEventHandler m_MustFlushScopeBeginningDelegate;

	public EApplication_MustFlushScopeEndedEventHandler m_MustFlushScopeEndedDelegate;

	public EApplication_RunModeEnteredEventHandler m_RunModeEnteredDelegate;

	public EApplication_DesignModeEnteredEventHandler m_DesignModeEnteredDelegate;

	public EApplication_BeforeDocumentSaveEventHandler m_BeforeDocumentSaveDelegate;

	public EApplication_BeforeDocumentSaveAsEventHandler m_BeforeDocumentSaveAsDelegate;

	public EApplication_FormulaChangedEventHandler m_FormulaChangedDelegate;

	public EApplication_ConnectionsAddedEventHandler m_ConnectionsAddedDelegate;

	public EApplication_ConnectionsDeletedEventHandler m_ConnectionsDeletedDelegate;

	public EApplication_EnterScopeEventHandler m_EnterScopeDelegate;

	public EApplication_ExitScopeEventHandler m_ExitScopeDelegate;

	public EApplication_QueryCancelQuitEventHandler m_QueryCancelQuitDelegate;

	public EApplication_QuitCanceledEventHandler m_QuitCanceledDelegate;

	public EApplication_WindowChangedEventHandler m_WindowChangedDelegate;

	public EApplication_ViewChangedEventHandler m_ViewChangedDelegate;

	public EApplication_QueryCancelWindowCloseEventHandler m_QueryCancelWindowCloseDelegate;

	public EApplication_WindowCloseCanceledEventHandler m_WindowCloseCanceledDelegate;

	public EApplication_QueryCancelDocumentCloseEventHandler m_QueryCancelDocumentCloseDelegate;

	public EApplication_DocumentCloseCanceledEventHandler m_DocumentCloseCanceledDelegate;

	public EApplication_QueryCancelStyleDeleteEventHandler m_QueryCancelStyleDeleteDelegate;

	public EApplication_StyleDeleteCanceledEventHandler m_StyleDeleteCanceledDelegate;

	public EApplication_QueryCancelMasterDeleteEventHandler m_QueryCancelMasterDeleteDelegate;

	public EApplication_MasterDeleteCanceledEventHandler m_MasterDeleteCanceledDelegate;

	public EApplication_QueryCancelPageDeleteEventHandler m_QueryCancelPageDeleteDelegate;

	public int m_dwCookie;

	public void PageDeleteCanceled(Page P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PageDeleteCanceledDelegate != null)
		{
			m_PageDeleteCanceledDelegate(P_0);
		}
	}

	public void ShapeParentChanged(Shape P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ShapeParentChangedDelegate != null)
		{
			m_ShapeParentChangedDelegate(P_0);
		}
	}

	public void BeforeShapeTextEdit(Shape P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeShapeTextEditDelegate != null)
		{
			m_BeforeShapeTextEditDelegate(P_0);
		}
	}

	public void ShapeExitedTextEdit(Shape P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ShapeExitedTextEditDelegate != null)
		{
			m_ShapeExitedTextEditDelegate(P_0);
		}
	}

	public bool QueryCancelSelectionDelete(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelSelectionDeleteDelegate != null)
		{
			return m_QueryCancelSelectionDeleteDelegate(P_0);
		}
		return false;
	}

	public void SelectionDeleteCanceled(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_SelectionDeleteCanceledDelegate != null)
		{
			m_SelectionDeleteCanceledDelegate(P_0);
		}
	}

	public bool QueryCancelUngroup(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelUngroupDelegate != null)
		{
			return m_QueryCancelUngroupDelegate(P_0);
		}
		return false;
	}

	public void UngroupCanceled(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_UngroupCanceledDelegate != null)
		{
			m_UngroupCanceledDelegate(P_0);
		}
	}

	public bool QueryCancelConvertToGroup(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelConvertToGroupDelegate != null)
		{
			return m_QueryCancelConvertToGroupDelegate(P_0);
		}
		return false;
	}

	public void ConvertToGroupCanceled(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ConvertToGroupCanceledDelegate != null)
		{
			m_ConvertToGroupCanceledDelegate(P_0);
		}
	}

	public bool QueryCancelSuspend(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelSuspendDelegate != null)
		{
			return m_QueryCancelSuspendDelegate(P_0);
		}
		return false;
	}

	public void SuspendCanceled(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_SuspendCanceledDelegate != null)
		{
			m_SuspendCanceledDelegate(P_0);
		}
	}

	public void BeforeSuspend(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeSuspendDelegate != null)
		{
			m_BeforeSuspendDelegate(P_0);
		}
	}

	public void AfterResume(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AfterResumeDelegate != null)
		{
			m_AfterResumeDelegate(P_0);
		}
	}

	public bool OnKeystrokeMessageForAddon(MSGWrap P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_OnKeystrokeMessageForAddonDelegate != null)
		{
			return m_OnKeystrokeMessageForAddonDelegate(P_0);
		}
		return false;
	}

	public void MouseDown(int P_0, int P_1, double P_2, double P_3, ref bool P_4)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MouseDownDelegate != null)
		{
			m_MouseDownDelegate(P_0, P_1, P_2, P_3, ref P_4);
		}
	}

	public void MouseMove(int P_0, int P_1, double P_2, double P_3, ref bool P_4)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MouseMoveDelegate != null)
		{
			m_MouseMoveDelegate(P_0, P_1, P_2, P_3, ref P_4);
		}
	}

	public void MouseUp(int P_0, int P_1, double P_2, double P_3, ref bool P_4)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MouseUpDelegate != null)
		{
			m_MouseUpDelegate(P_0, P_1, P_2, P_3, ref P_4);
		}
	}

	public void KeyDown(int P_0, int P_1, ref bool P_2)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_KeyDownDelegate != null)
		{
			m_KeyDownDelegate(P_0, P_1, ref P_2);
		}
	}

	public void KeyPress(int P_0, ref bool P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_KeyPressDelegate != null)
		{
			m_KeyPressDelegate(P_0, ref P_1);
		}
	}

	public void KeyUp(int P_0, int P_1, ref bool P_2)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_KeyUpDelegate != null)
		{
			m_KeyUpDelegate(P_0, P_1, ref P_2);
		}
	}

	public bool QueryCancelSuspendEvents(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelSuspendEventsDelegate != null)
		{
			return m_QueryCancelSuspendEventsDelegate(P_0);
		}
		return false;
	}

	public void SuspendEventsCanceled(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_SuspendEventsCanceledDelegate != null)
		{
			m_SuspendEventsCanceledDelegate(P_0);
		}
	}

	public void BeforeSuspendEvents(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeSuspendEventsDelegate != null)
		{
			m_BeforeSuspendEventsDelegate(P_0);
		}
	}

	public void AfterResumeEvents(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AfterResumeEventsDelegate != null)
		{
			m_AfterResumeEventsDelegate(P_0);
		}
	}

	public bool QueryCancelGroup(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelGroupDelegate != null)
		{
			return m_QueryCancelGroupDelegate(P_0);
		}
		return false;
	}

	public void GroupCanceled(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_GroupCanceledDelegate != null)
		{
			m_GroupCanceledDelegate(P_0);
		}
	}

	public void ShapeDataGraphicChanged(Shape P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ShapeDataGraphicChangedDelegate != null)
		{
			m_ShapeDataGraphicChangedDelegate(P_0);
		}
	}

	public void BeforeDataRecordsetDelete(DataRecordset P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeDataRecordsetDeleteDelegate != null)
		{
			m_BeforeDataRecordsetDeleteDelegate(P_0);
		}
	}

	public void DataRecordsetChanged(DataRecordsetChangedEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DataRecordsetChangedDelegate != null)
		{
			m_DataRecordsetChangedDelegate(P_0);
		}
	}

	public void DataRecordsetAdded(DataRecordset P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DataRecordsetAddedDelegate != null)
		{
			m_DataRecordsetAddedDelegate(P_0);
		}
	}

	public void ShapeLinkAdded(Shape P_0, int P_1, int P_2)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ShapeLinkAddedDelegate != null)
		{
			m_ShapeLinkAddedDelegate(P_0, P_1, P_2);
		}
	}

	public void ShapeLinkDeleted(Shape P_0, int P_1, int P_2)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ShapeLinkDeletedDelegate != null)
		{
			m_ShapeLinkDeletedDelegate(P_0, P_1, P_2);
		}
	}

	public void AfterRemoveHiddenInformation(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AfterRemoveHiddenInformationDelegate != null)
		{
			m_AfterRemoveHiddenInformationDelegate(P_0);
		}
	}

	public void ContainerRelationshipAdded(RelatedShapePairEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ContainerRelationshipAddedDelegate != null)
		{
			m_ContainerRelationshipAddedDelegate(P_0);
		}
	}

	public void ContainerRelationshipDeleted(RelatedShapePairEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ContainerRelationshipDeletedDelegate != null)
		{
			m_ContainerRelationshipDeletedDelegate(P_0);
		}
	}

	public void CalloutRelationshipAdded(RelatedShapePairEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CalloutRelationshipAddedDelegate != null)
		{
			m_CalloutRelationshipAddedDelegate(P_0);
		}
	}

	public void CalloutRelationshipDeleted(RelatedShapePairEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CalloutRelationshipDeletedDelegate != null)
		{
			m_CalloutRelationshipDeletedDelegate(P_0);
		}
	}

	public void RuleSetValidated(ValidationRuleSet P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_RuleSetValidatedDelegate != null)
		{
			m_RuleSetValidatedDelegate(P_0);
		}
	}

	public bool QueryCancelReplaceShapes(ReplaceShapesEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelReplaceShapesDelegate != null)
		{
			return m_QueryCancelReplaceShapesDelegate(P_0);
		}
		return false;
	}

	public void ReplaceShapesCanceled(ReplaceShapesEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ReplaceShapesCanceledDelegate != null)
		{
			m_ReplaceShapesCanceledDelegate(P_0);
		}
	}

	public void BeforeReplaceShapes(ReplaceShapesEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeReplaceShapesDelegate != null)
		{
			m_BeforeReplaceShapesDelegate(P_0);
		}
	}

	public void AfterReplaceShapes(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AfterReplaceShapesDelegate != null)
		{
			m_AfterReplaceShapesDelegate(P_0);
		}
	}

	public void AppActivated(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AppActivatedDelegate != null)
		{
			m_AppActivatedDelegate(P_0);
		}
	}

	public void AppDeactivated(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AppDeactivatedDelegate != null)
		{
			m_AppDeactivatedDelegate(P_0);
		}
	}

	public void AppObjActivated(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AppObjActivatedDelegate != null)
		{
			m_AppObjActivatedDelegate(P_0);
		}
	}

	public void AppObjDeactivated(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AppObjDeactivatedDelegate != null)
		{
			m_AppObjDeactivatedDelegate(P_0);
		}
	}

	public void BeforeQuit(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeQuitDelegate != null)
		{
			m_BeforeQuitDelegate(P_0);
		}
	}

	public void BeforeModal(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeModalDelegate != null)
		{
			m_BeforeModalDelegate(P_0);
		}
	}

	public void AfterModal(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AfterModalDelegate != null)
		{
			m_AfterModalDelegate(P_0);
		}
	}

	public void WindowOpened(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_WindowOpenedDelegate != null)
		{
			m_WindowOpenedDelegate(P_0);
		}
	}

	public void SelectionChanged(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_SelectionChangedDelegate != null)
		{
			m_SelectionChangedDelegate(P_0);
		}
	}

	public void BeforeWindowClosed(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeWindowClosedDelegate != null)
		{
			m_BeforeWindowClosedDelegate(P_0);
		}
	}

	public void WindowActivated(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_WindowActivatedDelegate != null)
		{
			m_WindowActivatedDelegate(P_0);
		}
	}

	public void BeforeWindowSelDelete(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeWindowSelDeleteDelegate != null)
		{
			m_BeforeWindowSelDeleteDelegate(P_0);
		}
	}

	public void BeforeWindowPageTurn(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeWindowPageTurnDelegate != null)
		{
			m_BeforeWindowPageTurnDelegate(P_0);
		}
	}

	public void WindowTurnedToPage(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_WindowTurnedToPageDelegate != null)
		{
			m_WindowTurnedToPageDelegate(P_0);
		}
	}

	public void DocumentOpened(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DocumentOpenedDelegate != null)
		{
			m_DocumentOpenedDelegate(P_0);
		}
	}

	public void DocumentCreated(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DocumentCreatedDelegate != null)
		{
			m_DocumentCreatedDelegate(P_0);
		}
	}

	public void DocumentSaved(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DocumentSavedDelegate != null)
		{
			m_DocumentSavedDelegate(P_0);
		}
	}

	public void DocumentSavedAs(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DocumentSavedAsDelegate != null)
		{
			m_DocumentSavedAsDelegate(P_0);
		}
	}

	public void DocumentChanged(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DocumentChangedDelegate != null)
		{
			m_DocumentChangedDelegate(P_0);
		}
	}

	public void BeforeDocumentClose(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeDocumentCloseDelegate != null)
		{
			m_BeforeDocumentCloseDelegate(P_0);
		}
	}

	public void StyleAdded(Style P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_StyleAddedDelegate != null)
		{
			m_StyleAddedDelegate(P_0);
		}
	}

	public void StyleChanged(Style P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_StyleChangedDelegate != null)
		{
			m_StyleChangedDelegate(P_0);
		}
	}

	public void BeforeStyleDelete(Style P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeStyleDeleteDelegate != null)
		{
			m_BeforeStyleDeleteDelegate(P_0);
		}
	}

	public void MasterAdded(Master P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MasterAddedDelegate != null)
		{
			m_MasterAddedDelegate(P_0);
		}
	}

	public void MasterChanged(Master P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MasterChangedDelegate != null)
		{
			m_MasterChangedDelegate(P_0);
		}
	}

	public void BeforeMasterDelete(Master P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeMasterDeleteDelegate != null)
		{
			m_BeforeMasterDeleteDelegate(P_0);
		}
	}

	public void PageAdded(Page P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PageAddedDelegate != null)
		{
			m_PageAddedDelegate(P_0);
		}
	}

	public void PageChanged(Page P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PageChangedDelegate != null)
		{
			m_PageChangedDelegate(P_0);
		}
	}

	public void BeforePageDelete(Page P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforePageDeleteDelegate != null)
		{
			m_BeforePageDeleteDelegate(P_0);
		}
	}

	public void ShapeAdded(Shape P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ShapeAddedDelegate != null)
		{
			m_ShapeAddedDelegate(P_0);
		}
	}

	public void BeforeSelectionDelete(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeSelectionDeleteDelegate != null)
		{
			m_BeforeSelectionDeleteDelegate(P_0);
		}
	}

	public void ShapeChanged(Shape P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ShapeChangedDelegate != null)
		{
			m_ShapeChangedDelegate(P_0);
		}
	}

	public void SelectionAdded(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_SelectionAddedDelegate != null)
		{
			m_SelectionAddedDelegate(P_0);
		}
	}

	public void BeforeShapeDelete(Shape P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeShapeDeleteDelegate != null)
		{
			m_BeforeShapeDeleteDelegate(P_0);
		}
	}

	public void TextChanged(Shape P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_TextChangedDelegate != null)
		{
			m_TextChangedDelegate(P_0);
		}
	}

	public void CellChanged(Cell P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CellChangedDelegate != null)
		{
			m_CellChangedDelegate(P_0);
		}
	}

	public void MarkerEvent(Application P_0, int P_1, string P_2)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MarkerEventDelegate != null)
		{
			m_MarkerEventDelegate(P_0, P_1, P_2);
		}
	}

	public void NoEventsPending(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_NoEventsPendingDelegate != null)
		{
			m_NoEventsPendingDelegate(P_0);
		}
	}

	public void VisioIsIdle(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_VisioIsIdleDelegate != null)
		{
			m_VisioIsIdleDelegate(P_0);
		}
	}

	public void MustFlushScopeBeginning(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MustFlushScopeBeginningDelegate != null)
		{
			m_MustFlushScopeBeginningDelegate(P_0);
		}
	}

	public void MustFlushScopeEnded(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MustFlushScopeEndedDelegate != null)
		{
			m_MustFlushScopeEndedDelegate(P_0);
		}
	}

	public void RunModeEntered(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_RunModeEnteredDelegate != null)
		{
			m_RunModeEnteredDelegate(P_0);
		}
	}

	public void DesignModeEntered(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DesignModeEnteredDelegate != null)
		{
			m_DesignModeEnteredDelegate(P_0);
		}
	}

	public void BeforeDocumentSave(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeDocumentSaveDelegate != null)
		{
			m_BeforeDocumentSaveDelegate(P_0);
		}
	}

	public void BeforeDocumentSaveAs(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeDocumentSaveAsDelegate != null)
		{
			m_BeforeDocumentSaveAsDelegate(P_0);
		}
	}

	public void FormulaChanged(Cell P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_FormulaChangedDelegate != null)
		{
			m_FormulaChangedDelegate(P_0);
		}
	}

	public void ConnectionsAdded(Connects P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ConnectionsAddedDelegate != null)
		{
			m_ConnectionsAddedDelegate(P_0);
		}
	}

	public void ConnectionsDeleted(Connects P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ConnectionsDeletedDelegate != null)
		{
			m_ConnectionsDeletedDelegate(P_0);
		}
	}

	public void EnterScope(Application P_0, int P_1, string P_2)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_EnterScopeDelegate != null)
		{
			m_EnterScopeDelegate(P_0, P_1, P_2);
		}
	}

	public void ExitScope(Application P_0, int P_1, string P_2, bool P_3)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ExitScopeDelegate != null)
		{
			m_ExitScopeDelegate(P_0, P_1, P_2, P_3);
		}
	}

	public bool QueryCancelQuit(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelQuitDelegate != null)
		{
			return m_QueryCancelQuitDelegate(P_0);
		}
		return false;
	}

	public void QuitCanceled(Application P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QuitCanceledDelegate != null)
		{
			m_QuitCanceledDelegate(P_0);
		}
	}

	public void WindowChanged(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_WindowChangedDelegate != null)
		{
			m_WindowChangedDelegate(P_0);
		}
	}

	public void ViewChanged(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ViewChangedDelegate != null)
		{
			m_ViewChangedDelegate(P_0);
		}
	}

	public bool QueryCancelWindowClose(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelWindowCloseDelegate != null)
		{
			return m_QueryCancelWindowCloseDelegate(P_0);
		}
		return false;
	}

	public void WindowCloseCanceled(Window P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_WindowCloseCanceledDelegate != null)
		{
			m_WindowCloseCanceledDelegate(P_0);
		}
	}

	public bool QueryCancelDocumentClose(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelDocumentCloseDelegate != null)
		{
			return m_QueryCancelDocumentCloseDelegate(P_0);
		}
		return false;
	}

	public void DocumentCloseCanceled(Document P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DocumentCloseCanceledDelegate != null)
		{
			m_DocumentCloseCanceledDelegate(P_0);
		}
	}

	public bool QueryCancelStyleDelete(Style P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelStyleDeleteDelegate != null)
		{
			return m_QueryCancelStyleDeleteDelegate(P_0);
		}
		return false;
	}

	public void StyleDeleteCanceled(Style P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_StyleDeleteCanceledDelegate != null)
		{
			m_StyleDeleteCanceledDelegate(P_0);
		}
	}

	public bool QueryCancelMasterDelete(Master P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelMasterDeleteDelegate != null)
		{
			return m_QueryCancelMasterDeleteDelegate(P_0);
		}
		return false;
	}

	public void MasterDeleteCanceled(Master P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MasterDeleteCanceledDelegate != null)
		{
			m_MasterDeleteCanceledDelegate(P_0);
		}
	}

	public bool QueryCancelPageDelete(Page P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_QueryCancelPageDeleteDelegate != null)
		{
			return m_QueryCancelPageDeleteDelegate(P_0);
		}
		return false;
	}

	internal EApplication_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_PageDeleteCanceledDelegate = null;
		m_ShapeParentChangedDelegate = null;
		m_BeforeShapeTextEditDelegate = null;
		m_ShapeExitedTextEditDelegate = null;
		m_QueryCancelSelectionDeleteDelegate = null;
		m_SelectionDeleteCanceledDelegate = null;
		m_QueryCancelUngroupDelegate = null;
		m_UngroupCanceledDelegate = null;
		m_QueryCancelConvertToGroupDelegate = null;
		m_ConvertToGroupCanceledDelegate = null;
		m_QueryCancelSuspendDelegate = null;
		m_SuspendCanceledDelegate = null;
		m_BeforeSuspendDelegate = null;
		m_AfterResumeDelegate = null;
		m_OnKeystrokeMessageForAddonDelegate = null;
		m_MouseDownDelegate = null;
		m_MouseMoveDelegate = null;
		m_MouseUpDelegate = null;
		m_KeyDownDelegate = null;
		m_KeyPressDelegate = null;
		m_KeyUpDelegate = null;
		m_QueryCancelSuspendEventsDelegate = null;
		m_SuspendEventsCanceledDelegate = null;
		m_BeforeSuspendEventsDelegate = null;
		m_AfterResumeEventsDelegate = null;
		m_QueryCancelGroupDelegate = null;
		m_GroupCanceledDelegate = null;
		m_ShapeDataGraphicChangedDelegate = null;
		m_BeforeDataRecordsetDeleteDelegate = null;
		m_DataRecordsetChangedDelegate = null;
		m_DataRecordsetAddedDelegate = null;
		m_ShapeLinkAddedDelegate = null;
		m_ShapeLinkDeletedDelegate = null;
		m_AfterRemoveHiddenInformationDelegate = null;
		m_ContainerRelationshipAddedDelegate = null;
		m_ContainerRelationshipDeletedDelegate = null;
		m_CalloutRelationshipAddedDelegate = null;
		m_CalloutRelationshipDeletedDelegate = null;
		m_RuleSetValidatedDelegate = null;
		m_QueryCancelReplaceShapesDelegate = null;
		m_ReplaceShapesCanceledDelegate = null;
		m_BeforeReplaceShapesDelegate = null;
		m_AfterReplaceShapesDelegate = null;
		m_AppActivatedDelegate = null;
		m_AppDeactivatedDelegate = null;
		m_AppObjActivatedDelegate = null;
		m_AppObjDeactivatedDelegate = null;
		m_BeforeQuitDelegate = null;
		m_BeforeModalDelegate = null;
		m_AfterModalDelegate = null;
		m_WindowOpenedDelegate = null;
		m_SelectionChangedDelegate = null;
		m_BeforeWindowClosedDelegate = null;
		m_WindowActivatedDelegate = null;
		m_BeforeWindowSelDeleteDelegate = null;
		m_BeforeWindowPageTurnDelegate = null;
		m_WindowTurnedToPageDelegate = null;
		m_DocumentOpenedDelegate = null;
		m_DocumentCreatedDelegate = null;
		m_DocumentSavedDelegate = null;
		m_DocumentSavedAsDelegate = null;
		m_DocumentChangedDelegate = null;
		m_BeforeDocumentCloseDelegate = null;
		m_StyleAddedDelegate = null;
		m_StyleChangedDelegate = null;
		m_BeforeStyleDeleteDelegate = null;
		m_MasterAddedDelegate = null;
		m_MasterChangedDelegate = null;
		m_BeforeMasterDeleteDelegate = null;
		m_PageAddedDelegate = null;
		m_PageChangedDelegate = null;
		m_BeforePageDeleteDelegate = null;
		m_ShapeAddedDelegate = null;
		m_BeforeSelectionDeleteDelegate = null;
		m_ShapeChangedDelegate = null;
		m_SelectionAddedDelegate = null;
		m_BeforeShapeDeleteDelegate = null;
		m_TextChangedDelegate = null;
		m_CellChangedDelegate = null;
		m_MarkerEventDelegate = null;
		m_NoEventsPendingDelegate = null;
		m_VisioIsIdleDelegate = null;
		m_MustFlushScopeBeginningDelegate = null;
		m_MustFlushScopeEndedDelegate = null;
		m_RunModeEnteredDelegate = null;
		m_DesignModeEnteredDelegate = null;
		m_BeforeDocumentSaveDelegate = null;
		m_BeforeDocumentSaveAsDelegate = null;
		m_FormulaChangedDelegate = null;
		m_ConnectionsAddedDelegate = null;
		m_ConnectionsDeletedDelegate = null;
		m_EnterScopeDelegate = null;
		m_ExitScopeDelegate = null;
		m_QueryCancelQuitDelegate = null;
		m_QuitCanceledDelegate = null;
		m_WindowChangedDelegate = null;
		m_ViewChangedDelegate = null;
		m_QueryCancelWindowCloseDelegate = null;
		m_WindowCloseCanceledDelegate = null;
		m_QueryCancelDocumentCloseDelegate = null;
		m_DocumentCloseCanceledDelegate = null;
		m_QueryCancelStyleDeleteDelegate = null;
		m_StyleDeleteCanceledDelegate = null;
		m_QueryCancelMasterDeleteDelegate = null;
		m_MasterDeleteCanceledDelegate = null;
		m_QueryCancelPageDeleteDelegate = null;
	}
}
