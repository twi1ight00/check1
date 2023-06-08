using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class EPages_SinkHelper : EPages
{
	public EPages_PageAddedEventHandler m_PageAddedDelegate;

	public EPages_PageChangedEventHandler m_PageChangedDelegate;

	public EPages_BeforePageDeleteEventHandler m_BeforePageDeleteDelegate;

	public EPages_ShapeAddedEventHandler m_ShapeAddedDelegate;

	public EPages_BeforeSelectionDeleteEventHandler m_BeforeSelectionDeleteDelegate;

	public EPages_ShapeChangedEventHandler m_ShapeChangedDelegate;

	public EPages_SelectionAddedEventHandler m_SelectionAddedDelegate;

	public EPages_BeforeShapeDeleteEventHandler m_BeforeShapeDeleteDelegate;

	public EPages_TextChangedEventHandler m_TextChangedDelegate;

	public EPages_CellChangedEventHandler m_CellChangedDelegate;

	public EPages_FormulaChangedEventHandler m_FormulaChangedDelegate;

	public EPages_ConnectionsAddedEventHandler m_ConnectionsAddedDelegate;

	public EPages_ConnectionsDeletedEventHandler m_ConnectionsDeletedDelegate;

	public EPages_QueryCancelPageDeleteEventHandler m_QueryCancelPageDeleteDelegate;

	public EPages_PageDeleteCanceledEventHandler m_PageDeleteCanceledDelegate;

	public EPages_ShapeParentChangedEventHandler m_ShapeParentChangedDelegate;

	public EPages_BeforeShapeTextEditEventHandler m_BeforeShapeTextEditDelegate;

	public EPages_ShapeExitedTextEditEventHandler m_ShapeExitedTextEditDelegate;

	public EPages_QueryCancelSelectionDeleteEventHandler m_QueryCancelSelectionDeleteDelegate;

	public EPages_SelectionDeleteCanceledEventHandler m_SelectionDeleteCanceledDelegate;

	public EPages_QueryCancelUngroupEventHandler m_QueryCancelUngroupDelegate;

	public EPages_UngroupCanceledEventHandler m_UngroupCanceledDelegate;

	public EPages_QueryCancelConvertToGroupEventHandler m_QueryCancelConvertToGroupDelegate;

	public EPages_ConvertToGroupCanceledEventHandler m_ConvertToGroupCanceledDelegate;

	public EPages_QueryCancelGroupEventHandler m_QueryCancelGroupDelegate;

	public EPages_GroupCanceledEventHandler m_GroupCanceledDelegate;

	public EPages_ShapeDataGraphicChangedEventHandler m_ShapeDataGraphicChangedDelegate;

	public EPages_ShapeLinkAddedEventHandler m_ShapeLinkAddedDelegate;

	public EPages_ShapeLinkDeletedEventHandler m_ShapeLinkDeletedDelegate;

	public EPages_ContainerRelationshipAddedEventHandler m_ContainerRelationshipAddedDelegate;

	public EPages_ContainerRelationshipDeletedEventHandler m_ContainerRelationshipDeletedDelegate;

	public EPages_CalloutRelationshipAddedEventHandler m_CalloutRelationshipAddedDelegate;

	public EPages_CalloutRelationshipDeletedEventHandler m_CalloutRelationshipDeletedDelegate;

	public EPages_QueryCancelReplaceShapesEventHandler m_QueryCancelReplaceShapesDelegate;

	public EPages_ReplaceShapesCanceledEventHandler m_ReplaceShapesCanceledDelegate;

	public EPages_BeforeReplaceShapesEventHandler m_BeforeReplaceShapesDelegate;

	public EPages_AfterReplaceShapesEventHandler m_AfterReplaceShapesDelegate;

	public int m_dwCookie;

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

	internal EPages_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
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
		m_FormulaChangedDelegate = null;
		m_ConnectionsAddedDelegate = null;
		m_ConnectionsDeletedDelegate = null;
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
		m_ShapeLinkAddedDelegate = null;
		m_ShapeLinkDeletedDelegate = null;
		m_ContainerRelationshipAddedDelegate = null;
		m_ContainerRelationshipDeletedDelegate = null;
		m_CalloutRelationshipAddedDelegate = null;
		m_CalloutRelationshipDeletedDelegate = null;
		m_QueryCancelReplaceShapesDelegate = null;
		m_ReplaceShapesCanceledDelegate = null;
		m_BeforeReplaceShapesDelegate = null;
		m_AfterReplaceShapesDelegate = null;
	}
}
