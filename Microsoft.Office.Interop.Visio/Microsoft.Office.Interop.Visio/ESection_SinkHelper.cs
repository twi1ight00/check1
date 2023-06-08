using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class ESection_SinkHelper : ESection
{
	public ESection_CellChangedEventHandler m_CellChangedDelegate;

	public ESection_FormulaChangedEventHandler m_FormulaChangedDelegate;

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

	internal ESection_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_CellChangedDelegate = null;
		m_FormulaChangedDelegate = null;
	}
}
