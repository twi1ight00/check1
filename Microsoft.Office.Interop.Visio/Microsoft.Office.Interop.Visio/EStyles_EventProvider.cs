using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EStyles_EventProvider : EStyles_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			5, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_StyleAdded(EStyles_StyleAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EStyles_SinkHelper eStyles_SinkHelper = new EStyles_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eStyles_SinkHelper, out pdwCookie);
			eStyles_SinkHelper.m_dwCookie = pdwCookie;
			eStyles_SinkHelper.m_StyleAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eStyles_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleAdded(EStyles_StyleAddedEventHandler P_0)
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
				EStyles_SinkHelper eStyles_SinkHelper = (EStyles_SinkHelper)m_aEventSinkHelpers[num];
				if (eStyles_SinkHelper.m_StyleAddedDelegate != null && ((eStyles_SinkHelper.m_StyleAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eStyles_SinkHelper.m_dwCookie);
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

	public void add_StyleChanged(EStyles_StyleChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EStyles_SinkHelper eStyles_SinkHelper = new EStyles_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eStyles_SinkHelper, out pdwCookie);
			eStyles_SinkHelper.m_dwCookie = pdwCookie;
			eStyles_SinkHelper.m_StyleChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eStyles_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleChanged(EStyles_StyleChangedEventHandler P_0)
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
				EStyles_SinkHelper eStyles_SinkHelper = (EStyles_SinkHelper)m_aEventSinkHelpers[num];
				if (eStyles_SinkHelper.m_StyleChangedDelegate != null && ((eStyles_SinkHelper.m_StyleChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eStyles_SinkHelper.m_dwCookie);
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

	public void add_BeforeStyleDelete(EStyles_BeforeStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EStyles_SinkHelper eStyles_SinkHelper = new EStyles_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eStyles_SinkHelper, out pdwCookie);
			eStyles_SinkHelper.m_dwCookie = pdwCookie;
			eStyles_SinkHelper.m_BeforeStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eStyles_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeStyleDelete(EStyles_BeforeStyleDeleteEventHandler P_0)
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
				EStyles_SinkHelper eStyles_SinkHelper = (EStyles_SinkHelper)m_aEventSinkHelpers[num];
				if (eStyles_SinkHelper.m_BeforeStyleDeleteDelegate != null && ((eStyles_SinkHelper.m_BeforeStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eStyles_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelStyleDelete(EStyles_QueryCancelStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EStyles_SinkHelper eStyles_SinkHelper = new EStyles_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eStyles_SinkHelper, out pdwCookie);
			eStyles_SinkHelper.m_dwCookie = pdwCookie;
			eStyles_SinkHelper.m_QueryCancelStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eStyles_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelStyleDelete(EStyles_QueryCancelStyleDeleteEventHandler P_0)
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
				EStyles_SinkHelper eStyles_SinkHelper = (EStyles_SinkHelper)m_aEventSinkHelpers[num];
				if (eStyles_SinkHelper.m_QueryCancelStyleDeleteDelegate != null && ((eStyles_SinkHelper.m_QueryCancelStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eStyles_SinkHelper.m_dwCookie);
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

	public void add_StyleDeleteCanceled(EStyles_StyleDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EStyles_SinkHelper eStyles_SinkHelper = new EStyles_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eStyles_SinkHelper, out pdwCookie);
			eStyles_SinkHelper.m_dwCookie = pdwCookie;
			eStyles_SinkHelper.m_StyleDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eStyles_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleDeleteCanceled(EStyles_StyleDeleteCanceledEventHandler P_0)
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
				EStyles_SinkHelper eStyles_SinkHelper = (EStyles_SinkHelper)m_aEventSinkHelpers[num];
				if (eStyles_SinkHelper.m_StyleDeleteCanceledDelegate != null && ((eStyles_SinkHelper.m_StyleDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eStyles_SinkHelper.m_dwCookie);
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

	public EStyles_EventProvider(object P_0)
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
					EStyles_SinkHelper eStyles_SinkHelper = (EStyles_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eStyles_SinkHelper.m_dwCookie);
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
