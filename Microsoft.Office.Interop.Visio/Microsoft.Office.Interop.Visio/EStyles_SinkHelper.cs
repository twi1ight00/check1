using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ClassInterface(ClassInterfaceType.None)]
[TypeLibType(TypeLibTypeFlags.FHidden)]
public sealed class EStyles_SinkHelper : EStyles
{
	public EStyles_StyleAddedEventHandler m_StyleAddedDelegate;

	public EStyles_StyleChangedEventHandler m_StyleChangedDelegate;

	public EStyles_BeforeStyleDeleteEventHandler m_BeforeStyleDeleteDelegate;

	public EStyles_QueryCancelStyleDeleteEventHandler m_QueryCancelStyleDeleteDelegate;

	public EStyles_StyleDeleteCanceledEventHandler m_StyleDeleteCanceledDelegate;

	public int m_dwCookie;

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

	internal EStyles_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_StyleAddedDelegate = null;
		m_StyleChangedDelegate = null;
		m_BeforeStyleDeleteDelegate = null;
		m_QueryCancelStyleDeleteDelegate = null;
		m_StyleDeleteCanceledDelegate = null;
	}
}
