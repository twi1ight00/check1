using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class EMaster_SinkHelper : EMaster
{
	public EMaster_MasterChangedEventHandler m_MasterChangedDelegate;

	public EMaster_BeforeMasterDeleteEventHandler m_BeforeMasterDeleteDelegate;

	public EMaster_ShapeAddedEventHandler m_ShapeAddedDelegate;

	public EMaster_BeforeSelectionDeleteEventHandler m_BeforeSelectionDeleteDelegate;

	public EMaster_ShapeChangedEventHandler m_ShapeChangedDelegate;

	public EMaster_SelectionAddedEventHandler m_SelectionAddedDelegate;

	public EMaster_BeforeShapeDeleteEventHandler m_BeforeShapeDeleteDelegate;

	public EMaster_TextChangedEventHandler m_TextChangedDelegate;

	public EMaster_CellChangedEventHandler m_CellChangedDelegate;

	public EMaster_FormulaChangedEventHandler m_FormulaChangedDelegate;

	public EMaster_ConnectionsAddedEventHandler m_ConnectionsAddedDelegate;

	public EMaster_ConnectionsDeletedEventHandler m_ConnectionsDeletedDelegate;

	public EMaster_QueryCancelMasterDeleteEventHandler m_QueryCancelMasterDeleteDelegate;

	public EMaster_MasterDeleteCanceledEventHandler m_MasterDeleteCanceledDelegate;

	public EMaster_ShapeParentChangedEventHandler m_ShapeParentChangedDelegate;

	public EMaster_BeforeShapeTextEditEventHandler m_BeforeShapeTextEditDelegate;

	public EMaster_ShapeExitedTextEditEventHandler m_ShapeExitedTextEditDelegate;

	public EMaster_QueryCancelSelectionDeleteEventHandler m_QueryCancelSelectionDeleteDelegate;

	public EMaster_SelectionDeleteCanceledEventHandler m_SelectionDeleteCanceledDelegate;

	public EMaster_QueryCancelUngroupEventHandler m_QueryCancelUngroupDelegate;

	public EMaster_UngroupCanceledEventHandler m_UngroupCanceledDelegate;

	public EMaster_QueryCancelConvertToGroupEventHandler m_QueryCancelConvertToGroupDelegate;

	public EMaster_ConvertToGroupCanceledEventHandler m_ConvertToGroupCanceledDelegate;

	public EMaster_QueryCancelGroupEventHandler m_QueryCancelGroupDelegate;

	public EMaster_GroupCanceledEventHandler m_GroupCanceledDelegate;

	public EMaster_ShapeDataGraphicChangedEventHandler m_ShapeDataGraphicChangedDelegate;

	public int m_dwCookie;

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

	internal EMaster_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_MasterChangedDelegate = null;
		m_BeforeMasterDeleteDelegate = null;
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
		m_QueryCancelMasterDeleteDelegate = null;
		m_MasterDeleteCanceledDelegate = null;
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
	}
}
