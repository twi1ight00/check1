using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EStyle_EventProvider : EStyle_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			6, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_StyleChanged(EStyle_StyleChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EStyle_SinkHelper eStyle_SinkHelper = new EStyle_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eStyle_SinkHelper, out pdwCookie);
			eStyle_SinkHelper.m_dwCookie = pdwCookie;
			eStyle_SinkHelper.m_StyleChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eStyle_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleChanged(EStyle_StyleChangedEventHandler P_0)
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
				EStyle_SinkHelper eStyle_SinkHelper = (EStyle_SinkHelper)m_aEventSinkHelpers[num];
				if (eStyle_SinkHelper.m_StyleChangedDelegate != null && ((eStyle_SinkHelper.m_StyleChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eStyle_SinkHelper.m_dwCookie);
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

	public void add_BeforeStyleDelete(EStyle_BeforeStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EStyle_SinkHelper eStyle_SinkHelper = new EStyle_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eStyle_SinkHelper, out pdwCookie);
			eStyle_SinkHelper.m_dwCookie = pdwCookie;
			eStyle_SinkHelper.m_BeforeStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eStyle_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeStyleDelete(EStyle_BeforeStyleDeleteEventHandler P_0)
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
				EStyle_SinkHelper eStyle_SinkHelper = (EStyle_SinkHelper)m_aEventSinkHelpers[num];
				if (eStyle_SinkHelper.m_BeforeStyleDeleteDelegate != null && ((eStyle_SinkHelper.m_BeforeStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eStyle_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelStyleDelete(EStyle_QueryCancelStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EStyle_SinkHelper eStyle_SinkHelper = new EStyle_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eStyle_SinkHelper, out pdwCookie);
			eStyle_SinkHelper.m_dwCookie = pdwCookie;
			eStyle_SinkHelper.m_QueryCancelStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eStyle_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelStyleDelete(EStyle_QueryCancelStyleDeleteEventHandler P_0)
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
				EStyle_SinkHelper eStyle_SinkHelper = (EStyle_SinkHelper)m_aEventSinkHelpers[num];
				if (eStyle_SinkHelper.m_QueryCancelStyleDeleteDelegate != null && ((eStyle_SinkHelper.m_QueryCancelStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eStyle_SinkHelper.m_dwCookie);
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

	public void add_StyleDeleteCanceled(EStyle_StyleDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EStyle_SinkHelper eStyle_SinkHelper = new EStyle_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eStyle_SinkHelper, out pdwCookie);
			eStyle_SinkHelper.m_dwCookie = pdwCookie;
			eStyle_SinkHelper.m_StyleDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eStyle_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleDeleteCanceled(EStyle_StyleDeleteCanceledEventHandler P_0)
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
				EStyle_SinkHelper eStyle_SinkHelper = (EStyle_SinkHelper)m_aEventSinkHelpers[num];
				if (eStyle_SinkHelper.m_StyleDeleteCanceledDelegate != null && ((eStyle_SinkHelper.m_StyleDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eStyle_SinkHelper.m_dwCookie);
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

	public EStyle_EventProvider(object P_0)
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
					EStyle_SinkHelper eStyle_SinkHelper = (EStyle_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eStyle_SinkHelper.m_dwCookie);
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
