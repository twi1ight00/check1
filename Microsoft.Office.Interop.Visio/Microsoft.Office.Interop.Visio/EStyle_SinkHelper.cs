using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class EStyle_SinkHelper : EStyle
{
	public EStyle_StyleChangedEventHandler m_StyleChangedDelegate;

	public EStyle_BeforeStyleDeleteEventHandler m_BeforeStyleDeleteDelegate;

	public EStyle_QueryCancelStyleDeleteEventHandler m_QueryCancelStyleDeleteDelegate;

	public EStyle_StyleDeleteCanceledEventHandler m_StyleDeleteCanceledDelegate;

	public int m_dwCookie;

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

	internal EStyle_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_StyleChangedDelegate = null;
		m_BeforeStyleDeleteDelegate = null;
		m_QueryCancelStyleDeleteDelegate = null;
		m_StyleDeleteCanceledDelegate = null;
	}
}
