using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EWindows_EventProvider : EWindows_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			1, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_WindowOpened(EWindows_WindowOpenedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_WindowOpenedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowOpened(EWindows_WindowOpenedEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_WindowOpenedDelegate != null && ((eWindows_SinkHelper.m_WindowOpenedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_SelectionChanged(EWindows_SelectionChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_SelectionChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionChanged(EWindows_SelectionChangedEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_SelectionChangedDelegate != null && ((eWindows_SinkHelper.m_SelectionChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_BeforeWindowClosed(EWindows_BeforeWindowClosedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_BeforeWindowClosedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeWindowClosed(EWindows_BeforeWindowClosedEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_BeforeWindowClosedDelegate != null && ((eWindows_SinkHelper.m_BeforeWindowClosedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_WindowActivated(EWindows_WindowActivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_WindowActivatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowActivated(EWindows_WindowActivatedEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_WindowActivatedDelegate != null && ((eWindows_SinkHelper.m_WindowActivatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_BeforeWindowSelDelete(EWindows_BeforeWindowSelDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_BeforeWindowSelDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeWindowSelDelete(EWindows_BeforeWindowSelDeleteEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_BeforeWindowSelDeleteDelegate != null && ((eWindows_SinkHelper.m_BeforeWindowSelDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_BeforeWindowPageTurn(EWindows_BeforeWindowPageTurnEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_BeforeWindowPageTurnDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeWindowPageTurn(EWindows_BeforeWindowPageTurnEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_BeforeWindowPageTurnDelegate != null && ((eWindows_SinkHelper.m_BeforeWindowPageTurnDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_WindowTurnedToPage(EWindows_WindowTurnedToPageEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_WindowTurnedToPageDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowTurnedToPage(EWindows_WindowTurnedToPageEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_WindowTurnedToPageDelegate != null && ((eWindows_SinkHelper.m_WindowTurnedToPageDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_WindowChanged(EWindows_WindowChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_WindowChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowChanged(EWindows_WindowChangedEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_WindowChangedDelegate != null && ((eWindows_SinkHelper.m_WindowChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_ViewChanged(EWindows_ViewChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_ViewChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ViewChanged(EWindows_ViewChangedEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_ViewChangedDelegate != null && ((eWindows_SinkHelper.m_ViewChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelWindowClose(EWindows_QueryCancelWindowCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_QueryCancelWindowCloseDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelWindowClose(EWindows_QueryCancelWindowCloseEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_QueryCancelWindowCloseDelegate != null && ((eWindows_SinkHelper.m_QueryCancelWindowCloseDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_WindowCloseCanceled(EWindows_WindowCloseCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_WindowCloseCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowCloseCanceled(EWindows_WindowCloseCanceledEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_WindowCloseCanceledDelegate != null && ((eWindows_SinkHelper.m_WindowCloseCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_OnKeystrokeMessageForAddon(EWindows_OnKeystrokeMessageForAddonEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_OnKeystrokeMessageForAddonDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_OnKeystrokeMessageForAddon(EWindows_OnKeystrokeMessageForAddonEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_OnKeystrokeMessageForAddonDelegate != null && ((eWindows_SinkHelper.m_OnKeystrokeMessageForAddonDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_MouseDown(EWindows_MouseDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_MouseDownDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MouseDown(EWindows_MouseDownEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_MouseDownDelegate != null && ((eWindows_SinkHelper.m_MouseDownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_MouseMove(EWindows_MouseMoveEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_MouseMoveDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MouseMove(EWindows_MouseMoveEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_MouseMoveDelegate != null && ((eWindows_SinkHelper.m_MouseMoveDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_MouseUp(EWindows_MouseUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_MouseUpDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MouseUp(EWindows_MouseUpEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_MouseUpDelegate != null && ((eWindows_SinkHelper.m_MouseUpDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_KeyDown(EWindows_KeyDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_KeyDownDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_KeyDown(EWindows_KeyDownEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_KeyDownDelegate != null && ((eWindows_SinkHelper.m_KeyDownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_KeyPress(EWindows_KeyPressEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_KeyPressDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_KeyPress(EWindows_KeyPressEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_KeyPressDelegate != null && ((eWindows_SinkHelper.m_KeyPressDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public void add_KeyUp(EWindows_KeyUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EWindows_SinkHelper eWindows_SinkHelper = new EWindows_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eWindows_SinkHelper, out pdwCookie);
			eWindows_SinkHelper.m_dwCookie = pdwCookie;
			eWindows_SinkHelper.m_KeyUpDelegate = P_0;
			m_aEventSinkHelpers.Add(eWindows_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_KeyUp(EWindows_KeyUpEventHandler P_0)
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
				EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
				if (eWindows_SinkHelper.m_KeyUpDelegate != null && ((eWindows_SinkHelper.m_KeyUpDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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

	public EWindows_EventProvider(object P_0)
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
					EWindows_SinkHelper eWindows_SinkHelper = (EWindows_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eWindows_SinkHelper.m_dwCookie);
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
