using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EWindow_EventProvider : EWindow_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			2, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_SelectionChanged(EWindow_SelectionChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_SelectionChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionChanged(EWindow_SelectionChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_SelectionChangedDelegate != null && ((eWindow_SinkHelper.m_SelectionChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeWindowClosed(EWindow_BeforeWindowClosedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_BeforeWindowClosedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeWindowClosed(EWindow_BeforeWindowClosedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_BeforeWindowClosedDelegate != null && ((eWindow_SinkHelper.m_BeforeWindowClosedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_WindowActivated(EWindow_WindowActivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_WindowActivatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowActivated(EWindow_WindowActivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_WindowActivatedDelegate != null && ((eWindow_SinkHelper.m_WindowActivatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeWindowSelDelete(EWindow_BeforeWindowSelDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_BeforeWindowSelDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeWindowSelDelete(EWindow_BeforeWindowSelDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_BeforeWindowSelDeleteDelegate != null && ((eWindow_SinkHelper.m_BeforeWindowSelDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeWindowPageTurn(EWindow_BeforeWindowPageTurnEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_BeforeWindowPageTurnDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeWindowPageTurn(EWindow_BeforeWindowPageTurnEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_BeforeWindowPageTurnDelegate != null && ((eWindow_SinkHelper.m_BeforeWindowPageTurnDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_WindowTurnedToPage(EWindow_WindowTurnedToPageEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_WindowTurnedToPageDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowTurnedToPage(EWindow_WindowTurnedToPageEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_WindowTurnedToPageDelegate != null && ((eWindow_SinkHelper.m_WindowTurnedToPageDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_WindowChanged(EWindow_WindowChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_WindowChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowChanged(EWindow_WindowChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_WindowChangedDelegate != null && ((eWindow_SinkHelper.m_WindowChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ViewChanged(EWindow_ViewChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_ViewChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ViewChanged(EWindow_ViewChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_ViewChangedDelegate != null && ((eWindow_SinkHelper.m_ViewChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelWindowClose(EWindow_QueryCancelWindowCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_QueryCancelWindowCloseDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelWindowClose(EWindow_QueryCancelWindowCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_QueryCancelWindowCloseDelegate != null && ((eWindow_SinkHelper.m_QueryCancelWindowCloseDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_WindowCloseCanceled(EWindow_WindowCloseCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_WindowCloseCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowCloseCanceled(EWindow_WindowCloseCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_WindowCloseCanceledDelegate != null && ((eWindow_SinkHelper.m_WindowCloseCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_OnKeystrokeMessageForAddon(EWindow_OnKeystrokeMessageForAddonEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_OnKeystrokeMessageForAddonDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_OnKeystrokeMessageForAddon(EWindow_OnKeystrokeMessageForAddonEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_OnKeystrokeMessageForAddonDelegate != null && ((eWindow_SinkHelper.m_OnKeystrokeMessageForAddonDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MouseDown(EWindow_MouseDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_MouseDownDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MouseDown(EWindow_MouseDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_MouseDownDelegate != null && ((eWindow_SinkHelper.m_MouseDownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MouseMove(EWindow_MouseMoveEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_MouseMoveDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MouseMove(EWindow_MouseMoveEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_MouseMoveDelegate != null && ((eWindow_SinkHelper.m_MouseMoveDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MouseUp(EWindow_MouseUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_MouseUpDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MouseUp(EWindow_MouseUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_MouseUpDelegate != null && ((eWindow_SinkHelper.m_MouseUpDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_KeyDown(EWindow_KeyDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_KeyDownDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_KeyDown(EWindow_KeyDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_KeyDownDelegate != null && ((eWindow_SinkHelper.m_KeyDownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_KeyPress(EWindow_KeyPressEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_KeyPressDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_KeyPress(EWindow_KeyPressEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_KeyPressDelegate != null && ((eWindow_SinkHelper.m_KeyPressDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_KeyUp(EWindow_KeyUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindow_SinkHelper eWindow_SinkHelper = new EWindow_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindow_SinkHelper, out pdwCookie);
			eWindow_SinkHelper.m_dwCookie = pdwCookie;
			eWindow_SinkHelper.m_KeyUpDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindow_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_KeyUp(EWindow_KeyUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindow_SinkHelper.m_KeyUpDelegate != null && ((eWindow_SinkHelper.m_KeyUpDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public EWindow_EventProvider(object P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_ConnectionPointContainer = (IConnectionPointContainer)P_0;
	}

	public void Finalize()
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 < count)
			{
				do
				{
					EWindow_SinkHelper eWindow_SinkHelper = (EWindow_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eWindow_SinkHelper.m_dwCookie);
					num++;
				}
				while (num < count);
			}
			Marshal.ReleaseComObject(m_ConnectionPoint);
		}
		catch (Exception)
		{
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void Dispose()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		Finalize();
		GC.SuppressFinalize(this);
	}
}
