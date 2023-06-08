using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class EWindows_SinkHelper : EWindows
{
	public EWindows_WindowOpenedEventHandler m_WindowOpenedDelegate;

	public EWindows_SelectionChangedEventHandler m_SelectionChangedDelegate;

	public EWindows_BeforeWindowClosedEventHandler m_BeforeWindowClosedDelegate;

	public EWindows_WindowActivatedEventHandler m_WindowActivatedDelegate;

	public EWindows_BeforeWindowSelDeleteEventHandler m_BeforeWindowSelDeleteDelegate;

	public EWindows_BeforeWindowPageTurnEventHandler m_BeforeWindowPageTurnDelegate;

	public EWindows_WindowTurnedToPageEventHandler m_WindowTurnedToPageDelegate;

	public EWindows_WindowChangedEventHandler m_WindowChangedDelegate;

	public EWindows_ViewChangedEventHandler m_ViewChangedDelegate;

	public EWindows_QueryCancelWindowCloseEventHandler m_QueryCancelWindowCloseDelegate;

	public EWindows_WindowCloseCanceledEventHandler m_WindowCloseCanceledDelegate;

	public EWindows_OnKeystrokeMessageForAddonEventHandler m_OnKeystrokeMessageForAddonDelegate;

	public EWindows_MouseDownEventHandler m_MouseDownDelegate;

	public EWindows_MouseMoveEventHandler m_MouseMoveDelegate;

	public EWindows_MouseUpEventHandler m_MouseUpDelegate;

	public EWindows_KeyDownEventHandler m_KeyDownDelegate;

	public EWindows_KeyPressEventHandler m_KeyPressDelegate;

	public EWindows_KeyUpEventHandler m_KeyUpDelegate;

	public int m_dwCookie;

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

	internal EWindows_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_WindowOpenedDelegate = null;
		m_SelectionChangedDelegate = null;
		m_BeforeWindowClosedDelegate = null;
		m_WindowActivatedDelegate = null;
		m_BeforeWindowSelDeleteDelegate = null;
		m_BeforeWindowPageTurnDelegate = null;
		m_WindowTurnedToPageDelegate = null;
		m_WindowChangedDelegate = null;
		m_ViewChangedDelegate = null;
		m_QueryCancelWindowCloseDelegate = null;
		m_WindowCloseCanceledDelegate = null;
		m_OnKeystrokeMessageForAddonDelegate = null;
		m_MouseDownDelegate = null;
		m_MouseMoveDelegate = null;
		m_MouseUpDelegate = null;
		m_KeyDownDelegate = null;
		m_KeyPressDelegate = null;
		m_KeyUpDelegate = null;
	}
}
