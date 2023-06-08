using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EDataRecordsets_EventProvider : EDataRecordsets_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			16, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_DataRecordsetAdded(EDataRecordsets_DataRecordsetAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDataRecordsets_SinkHelper eDataRecordsets_SinkHelper = new EDataRecordsets_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDataRecordsets_SinkHelper, out pdwCookie);
			eDataRecordsets_SinkHelper.m_dwCookie = pdwCookie;
			eDataRecordsets_SinkHelper.m_DataRecordsetAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDataRecordsets_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DataRecordsetAdded(EDataRecordsets_DataRecordsetAddedEventHandler P_0)
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
				EDataRecordsets_SinkHelper eDataRecordsets_SinkHelper = (EDataRecordsets_SinkHelper)m_aEventSinkHelpers[num];
				if (eDataRecordsets_SinkHelper.m_DataRecordsetAddedDelegate != null && ((eDataRecordsets_SinkHelper.m_DataRecordsetAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDataRecordsets_SinkHelper.m_dwCookie);
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

	public void add_BeforeDataRecordsetDelete(EDataRecordsets_BeforeDataRecordsetDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDataRecordsets_SinkHelper eDataRecordsets_SinkHelper = new EDataRecordsets_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDataRecordsets_SinkHelper, out pdwCookie);
			eDataRecordsets_SinkHelper.m_dwCookie = pdwCookie;
			eDataRecordsets_SinkHelper.m_BeforeDataRecordsetDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDataRecordsets_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDataRecordsetDelete(EDataRecordsets_BeforeDataRecordsetDeleteEventHandler P_0)
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
				EDataRecordsets_SinkHelper eDataRecordsets_SinkHelper = (EDataRecordsets_SinkHelper)m_aEventSinkHelpers[num];
				if (eDataRecordsets_SinkHelper.m_BeforeDataRecordsetDeleteDelegate != null && ((eDataRecordsets_SinkHelper.m_BeforeDataRecordsetDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDataRecordsets_SinkHelper.m_dwCookie);
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

	public void add_DataRecordsetChanged(EDataRecordsets_DataRecordsetChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDataRecordsets_SinkHelper eDataRecordsets_SinkHelper = new EDataRecordsets_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDataRecordsets_SinkHelper, out pdwCookie);
			eDataRecordsets_SinkHelper.m_dwCookie = pdwCookie;
			eDataRecordsets_SinkHelper.m_DataRecordsetChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDataRecordsets_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DataRecordsetChanged(EDataRecordsets_DataRecordsetChangedEventHandler P_0)
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
				EDataRecordsets_SinkHelper eDataRecordsets_SinkHelper = (EDataRecordsets_SinkHelper)m_aEventSinkHelpers[num];
				if (eDataRecordsets_SinkHelper.m_DataRecordsetChangedDelegate != null && ((eDataRecordsets_SinkHelper.m_DataRecordsetChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDataRecordsets_SinkHelper.m_dwCookie);
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

	public EDataRecordsets_EventProvider(object P_0)
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
					EDataRecordsets_SinkHelper eDataRecordsets_SinkHelper = (EDataRecordsets_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eDataRecordsets_SinkHelper.m_dwCookie);
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
