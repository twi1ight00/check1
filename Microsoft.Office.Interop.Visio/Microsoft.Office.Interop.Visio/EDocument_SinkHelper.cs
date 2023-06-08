using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ClassInterface(ClassInterfaceType.None)]
[TypeLibType(TypeLibTypeFlags.FHidden)]
public sealed class EDocument_SinkHelper : EDocument
{
	public EDocument_DocumentOpenedEventHandler m_DocumentOpenedDelegate;

	public EDocument_DocumentCreatedEventHandler m_DocumentCreatedDelegate;

	public EDocument_DocumentSavedEventHandler m_DocumentSavedDelegate;

	public EDocument_DocumentSavedAsEventHandler m_DocumentSavedAsDelegate;

	public EDocument_DocumentChangedEventHandler m_DocumentChangedDelegate;

	public EDocument_BeforeDocumentCloseEventHandler m_BeforeDocumentCloseDelegate;

	public EDocument_StyleAddedEventHandler m_StyleAddedDelegate;

	public EDocument_StyleChangedEventHandler m_StyleChangedDelegate;

	public EDocument_BeforeStyleDeleteEventHandler m_BeforeStyleDeleteDelegate;

	public EDocument_MasterAddedEventHandler m_MasterAddedDelegate;

	public EDocument_MasterChangedEventHandler m_MasterChangedDelegate;

	public EDocument_BeforeMasterDeleteEventHandler m_BeforeMasterDeleteDelegate;

	public EDocument_PageAddedEventHandler m_PageAddedDelegate;

	public EDocument_PageChangedEventHandler m_PageChangedDelegate;

	public EDocument_BeforePageDeleteEventHandler m_BeforePageDeleteDelegate;

	public EDocument_ShapeAddedEventHandler m_ShapeAddedDelegate;

	public EDocument_BeforeSelectionDeleteEventHandler m_BeforeSelectionDeleteDelegate;

	public EDocument_RunModeEnteredEventHandler m_RunModeEnteredDelegate;

	public EDocument_DesignModeEnteredEventHandler m_DesignModeEnteredDelegate;

	public EDocument_BeforeDocumentSaveEventHandler m_BeforeDocumentSaveDelegate;

	public EDocument_BeforeDocumentSaveAsEventHandler m_BeforeDocumentSaveAsDelegate;

	public EDocument_QueryCancelDocumentCloseEventHandler m_QueryCancelDocumentCloseDelegate;

	public EDocument_DocumentCloseCanceledEventHandler m_DocumentCloseCanceledDelegate;

	public EDocument_QueryCancelStyleDeleteEventHandler m_QueryCancelStyleDeleteDelegate;

	public EDocument_StyleDeleteCanceledEventHandler m_StyleDeleteCanceledDelegate;

	public EDocument_QueryCancelMasterDeleteEventHandler m_QueryCancelMasterDeleteDelegate;

	public EDocument_MasterDeleteCanceledEventHandler m_MasterDeleteCanceledDelegate;

	public EDocument_QueryCancelPageDeleteEventHandler m_QueryCancelPageDeleteDelegate;

	public EDocument_PageDeleteCanceledEventHandler m_PageDeleteCanceledDelegate;

	public EDocument_ShapeParentChangedEventHandler m_ShapeParentChangedDelegate;

	public EDocument_BeforeShapeTextEditEventHandler m_BeforeShapeTextEditDelegate;

	public EDocument_ShapeExitedTextEditEventHandler m_ShapeExitedTextEditDelegate;

	public EDocument_QueryCancelSelectionDeleteEventHandler m_QueryCancelSelectionDeleteDelegate;

	public EDocument_SelectionDeleteCanceledEventHandler m_SelectionDeleteCanceledDelegate;

	public EDocument_QueryCancelUngroupEventHandler m_QueryCancelUngroupDelegate;

	public EDocument_UngroupCanceledEventHandler m_UngroupCanceledDelegate;

	public EDocument_QueryCancelConvertToGroupEventHandler m_QueryCancelConvertToGroupDelegate;

	public EDocument_ConvertToGroupCanceledEventHandler m_ConvertToGroupCanceledDelegate;

	public EDocument_QueryCancelGroupEventHandler m_QueryCancelGroupDelegate;

	public EDocument_GroupCanceledEventHandler m_GroupCanceledDelegate;

	public EDocument_ShapeDataGraphicChangedEventHandler m_ShapeDataGraphicChangedDelegate;

	public EDocument_BeforeDataRecordsetDeleteEventHandler m_BeforeDataRecordsetDeleteDelegate;

	public EDocument_DataRecordsetAddedEventHandler m_DataRecordsetAddedDelegate;

	public EDocument_AfterRemoveHiddenInformationEventHandler m_AfterRemoveHiddenInformationDelegate;

	public EDocument_RuleSetValidatedEventHandler m_RuleSetValidatedDelegate;

	public EDocument_AfterDocumentMergeEventHandler m_AfterDocumentMergeDelegate;

	public int m_dwCookie;

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

	public void DataRecordsetAdded(DataRecordset P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DataRecordsetAddedDelegate != null)
		{
			m_DataRecordsetAddedDelegate(P_0);
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

	public void RuleSetValidated(ValidationRuleSet P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_RuleSetValidatedDelegate != null)
		{
			m_RuleSetValidatedDelegate(P_0);
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

	internal EDocument_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
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
		m_RunModeEnteredDelegate = null;
		m_DesignModeEnteredDelegate = null;
		m_BeforeDocumentSaveDelegate = null;
		m_BeforeDocumentSaveAsDelegate = null;
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
		m_DataRecordsetAddedDelegate = null;
		m_AfterRemoveHiddenInformationDelegate = null;
		m_RuleSetValidatedDelegate = null;
		m_AfterDocumentMergeDelegate = null;
	}
}
