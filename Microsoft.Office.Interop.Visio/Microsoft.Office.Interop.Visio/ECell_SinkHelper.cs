using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ClassInterface(ClassInterfaceType.None)]
[TypeLibType(TypeLibTypeFlags.FHidden)]
public sealed class ECell_SinkHelper : ECell
{
	public ECell_CellChangedEventHandler m_CellChangedDelegate;

	public ECell_FormulaChangedEventHandler m_FormulaChangedDelegate;

	public int m_dwCookie;

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

	internal ECell_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_CellChangedDelegate = null;
		m_FormulaChangedDelegate = null;
	}
}
