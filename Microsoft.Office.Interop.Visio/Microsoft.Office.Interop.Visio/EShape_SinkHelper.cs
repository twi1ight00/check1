using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ClassInterface(ClassInterfaceType.None)]
[TypeLibType(TypeLibTypeFlags.FHidden)]
public sealed class EShape_SinkHelper : EShape
{
	public EShape_CellChangedEventHandler m_CellChangedDelegate;

	public EShape_ShapeAddedEventHandler m_ShapeAddedDelegate;

	public EShape_BeforeSelectionDeleteEventHandler m_BeforeSelectionDeleteDelegate;

	public EShape_ShapeChangedEventHandler m_ShapeChangedDelegate;

	public EShape_SelectionAddedEventHandler m_SelectionAddedDelegate;

	public EShape_BeforeShapeDeleteEventHandler m_BeforeShapeDeleteDelegate;

	public EShape_TextChangedEventHandler m_TextChangedDelegate;

	public EShape_FormulaChangedEventHandler m_FormulaChangedDelegate;

	public EShape_ShapeParentChangedEventHandler m_ShapeParentChangedDelegate;

	public EShape_BeforeShapeTextEditEventHandler m_BeforeShapeTextEditDelegate;

	public EShape_ShapeExitedTextEditEventHandler m_ShapeExitedTextEditDelegate;

	public EShape_QueryCancelSelectionDeleteEventHandler m_QueryCancelSelectionDeleteDelegate;

	public EShape_SelectionDeleteCanceledEventHandler m_SelectionDeleteCanceledDelegate;

	public EShape_QueryCancelUngroupEventHandler m_QueryCancelUngroupDelegate;

	public EShape_UngroupCanceledEventHandler m_UngroupCanceledDelegate;

	public EShape_QueryCancelConvertToGroupEventHandler m_QueryCancelConvertToGroupDelegate;

	public EShape_ConvertToGroupCanceledEventHandler m_ConvertToGroupCanceledDelegate;

	public EShape_QueryCancelGroupEventHandler m_QueryCancelGroupDelegate;

	public EShape_GroupCanceledEventHandler m_GroupCanceledDelegate;

	public EShape_ShapeDataGraphicChangedEventHandler m_ShapeDataGraphicChangedDelegate;

	public EShape_ShapeLinkAddedEventHandler m_ShapeLinkAddedDelegate;

	public EShape_ShapeLinkDeletedEventHandler m_ShapeLinkDeletedDelegate;

	public int m_dwCookie;

	public void CellChanged(Cell P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CellChangedDelegate != null)
		{
			m_CellChangedDelegate(P_0);
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

	public void FormulaChanged(Cell P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_FormulaChangedDelegate != null)
		{
			m_FormulaChangedDelegate(P_0);
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

	internal EShape_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_CellChangedDelegate = null;
		m_ShapeAddedDelegate = null;
		m_BeforeSelectionDeleteDelegate = null;
		m_ShapeChangedDelegate = null;
		m_SelectionAddedDelegate = null;
		m_BeforeShapeDeleteDelegate = null;
		m_TextChangedDelegate = null;
		m_FormulaChangedDelegate = null;
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
	}
}
