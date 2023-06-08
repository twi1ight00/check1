using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class EDocuments_SinkHelper : EDocuments
{
	public EDocuments_AfterReplaceShapesEventHandler m_AfterReplaceShapesDelegate;

	public EDocuments_AfterDocumentMergeEventHandler m_AfterDocumentMergeDelegate;

	public EDocuments_DocumentOpenedEventHandler m_DocumentOpenedDelegate;

	public EDocuments_DocumentCreatedEventHandler m_DocumentCreatedDelegate;

	public EDocuments_DocumentSavedEventHandler m_DocumentSavedDelegate;

	public EDocuments_DocumentSavedAsEventHandler m_DocumentSavedAsDelegate;

	public EDocuments_DocumentChangedEventHandler m_DocumentChangedDelegate;

	public EDocuments_BeforeDocumentCloseEventHandler m_BeforeDocumentCloseDelegate;

	public EDocuments_StyleAddedEventHandler m_StyleAddedDelegate;

	public EDocuments_StyleChangedEventHandler m_StyleChangedDelegate;

	public EDocuments_BeforeStyleDeleteEventHandler m_BeforeStyleDeleteDelegate;

	public EDocuments_MasterAddedEventHandler m_MasterAddedDelegate;

	public EDocuments_MasterChangedEventHandler m_MasterChangedDelegate;

	public EDocuments_BeforeMasterDeleteEventHandler m_BeforeMasterDeleteDelegate;

	public EDocuments_PageAddedEventHandler m_PageAddedDelegate;

	public EDocuments_PageChangedEventHandler m_PageChangedDelegate;

	public EDocuments_BeforePageDeleteEventHandler m_BeforePageDeleteDelegate;

	public EDocuments_ShapeAddedEventHandler m_ShapeAddedDelegate;

	public EDocuments_BeforeSelectionDeleteEventHandler m_BeforeSelectionDeleteDelegate;

	public EDocuments_ShapeChangedEventHandler m_ShapeChangedDelegate;

	public EDocuments_SelectionAddedEventHandler m_SelectionAddedDelegate;

	public EDocuments_BeforeShapeDeleteEventHandler m_BeforeShapeDeleteDelegate;

	public EDocuments_TextChangedEventHandler m_TextChangedDelegate;

	public EDocuments_CellChangedEventHandler m_CellChangedDelegate;

	public EDocuments_RunModeEnteredEventHandler m_RunModeEnteredDelegate;

	public EDocuments_DesignModeEnteredEventHandler m_DesignModeEnteredDelegate;

	public EDocuments_BeforeDocumentSaveEventHandler m_BeforeDocumentSaveDelegate;

	public EDocuments_BeforeDocumentSaveAsEventHandler m_BeforeDocumentSaveAsDelegate;

	public EDocuments_FormulaChangedEventHandler m_FormulaChangedDelegate;

	public EDocuments_ConnectionsAddedEventHandler m_ConnectionsAddedDelegate;

	public EDocuments_ConnectionsDeletedEventHandler m_ConnectionsDeletedDelegate;

	public EDocuments_QueryCancelDocumentCloseEventHandler m_QueryCancelDocumentCloseDelegate;

	public EDocuments_DocumentCloseCanceledEventHandler m_DocumentCloseCanceledDelegate;

	public EDocuments_QueryCancelStyleDeleteEventHandler m_QueryCancelStyleDeleteDelegate;

	public EDocuments_StyleDeleteCanceledEventHandler m_StyleDeleteCanceledDelegate;

	public EDocuments_QueryCancelMasterDeleteEventHandler m_QueryCancelMasterDeleteDelegate;

	public EDocuments_MasterDeleteCanceledEventHandler m_MasterDeleteCanceledDelegate;

	public EDocuments_QueryCancelPageDeleteEventHandler m_QueryCancelPageDeleteDelegate;

	public EDocuments_PageDeleteCanceledEventHandler m_PageDeleteCanceledDelegate;

	public EDocuments_ShapeParentChangedEventHandler m_ShapeParentChangedDelegate;

	public EDocuments_BeforeShapeTextEditEventHandler m_BeforeShapeTextEditDelegate;

	public EDocuments_ShapeExitedTextEditEventHandler m_ShapeExitedTextEditDelegate;

	public EDocuments_QueryCancelSelectionDeleteEventHandler m_QueryCancelSelectionDeleteDelegate;

	public EDocuments_SelectionDeleteCanceledEventHandler m_SelectionDeleteCanceledDelegate;

	public EDocuments_QueryCancelUngroupEventHandler m_QueryCancelUngroupDelegate;

	public EDocuments_UngroupCanceledEventHandler m_UngroupCanceledDelegate;

	public EDocuments_QueryCancelConvertToGroupEventHandler m_QueryCancelConvertToGroupDelegate;

	public EDocuments_ConvertToGroupCanceledEventHandler m_ConvertToGroupCanceledDelegate;

	public EDocuments_QueryCancelGroupEventHandler m_QueryCancelGroupDelegate;

	public EDocuments_GroupCanceledEventHandler m_GroupCanceledDelegate;

	public EDocuments_ShapeDataGraphicChangedEventHandler m_ShapeDataGraphicChangedDelegate;

	public EDocuments_BeforeDataRecordsetDeleteEventHandler m_BeforeDataRecordsetDeleteDelegate;

	public EDocuments_DataRecordsetChangedEventHandler m_DataRecordsetChangedDelegate;

	public EDocuments_DataRecordsetAddedEventHandler m_DataRecordsetAddedDelegate;

	public EDocuments_ShapeLinkAddedEventHandler m_ShapeLinkAddedDelegate;

	public EDocuments_ShapeLinkDeletedEventHandler m_ShapeLinkDeletedDelegate;

	public EDocuments_AfterRemoveHiddenInformationEventHandler m_AfterRemoveHiddenInformationDelegate;

	public EDocuments_ContainerRelationshipAddedEventHandler m_ContainerRelationshipAddedDelegate;

	public EDocuments_ContainerRelationshipDeletedEventHandler m_ContainerRelationshipDeletedDelegate;

	public EDocuments_CalloutRelationshipAddedEventHandler m_CalloutRelationshipAddedDelegate;

	public EDocuments_CalloutRelationshipDeletedEventHandler m_CalloutRelationshipDeletedDelegate;

	public EDocuments_RuleSetValidatedEventHandler m_RuleSetValidatedDelegate;

	public EDocuments_QueryCancelReplaceShapesEventHandler m_QueryCancelReplaceShapesDelegate;

	public EDocuments_ReplaceShapesCanceledEventHandler m_ReplaceShapesCanceledDelegate;

	public EDocuments_BeforeReplaceShapesEventHandler m_BeforeReplaceShapesDelegate;

	public int m_dwCookie;

	public void AfterReplaceShapes(Selection P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AfterReplaceShapesDelegate != null)
		{
			m_AfterReplaceShapesDelegate(P_0);
		}
	}

	public void AfterDocumentMerge(CoauthMergeEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AfterDocumentMergeDelegate != null)
		{
			m_AfterDocumentMergeDelegate(P_0);
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

	internal EDocuments_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_AfterReplaceShapesDelegate = null;
		m_AfterDocumentMergeDelegate = null;
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
		m_RunModeEnteredDelegate = null;
		m_DesignModeEnteredDelegate = null;
		m_BeforeDocumentSaveDelegate = null;
		m_BeforeDocumentSaveAsDelegate = null;
		m_FormulaChangedDelegate = null;
		m_ConnectionsAddedDelegate = null;
		m_ConnectionsDeletedDelegate = null;
		m_QueryCancelDocumentCloseDelegate = null;
		m_DocumentCloseCanceledDelegate = null;
		m_QueryCancelStyleDeleteDelegate = null;
		m_StyleDeleteCanceledDelegate = null;
		m_QueryCancelMasterDeleteDelegate = null;
		m_MasterDeleteCanceledDelegate = null;
		m_QueryCancelPageDeleteDelegate = null;
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
	}
}
