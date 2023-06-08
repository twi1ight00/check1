using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EDocument_EventProvider : EDocument_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			80, 7, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_DocumentOpened(EDocument_DocumentOpenedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_DocumentOpenedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentOpened(EDocument_DocumentOpenedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_DocumentOpenedDelegate != null && ((eDocument_SinkHelper.m_DocumentOpenedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_DocumentCreated(EDocument_DocumentCreatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_DocumentCreatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentCreated(EDocument_DocumentCreatedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_DocumentCreatedDelegate != null && ((eDocument_SinkHelper.m_DocumentCreatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_DocumentSaved(EDocument_DocumentSavedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_DocumentSavedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentSaved(EDocument_DocumentSavedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_DocumentSavedDelegate != null && ((eDocument_SinkHelper.m_DocumentSavedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_DocumentSavedAs(EDocument_DocumentSavedAsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_DocumentSavedAsDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentSavedAs(EDocument_DocumentSavedAsEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_DocumentSavedAsDelegate != null && ((eDocument_SinkHelper.m_DocumentSavedAsDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_DocumentChanged(EDocument_DocumentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_DocumentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentChanged(EDocument_DocumentChangedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_DocumentChangedDelegate != null && ((eDocument_SinkHelper.m_DocumentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_BeforeDocumentClose(EDocument_BeforeDocumentCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_BeforeDocumentCloseDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDocumentClose(EDocument_BeforeDocumentCloseEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_BeforeDocumentCloseDelegate != null && ((eDocument_SinkHelper.m_BeforeDocumentCloseDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_StyleAdded(EDocument_StyleAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_StyleAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleAdded(EDocument_StyleAddedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_StyleAddedDelegate != null && ((eDocument_SinkHelper.m_StyleAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_StyleChanged(EDocument_StyleChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_StyleChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleChanged(EDocument_StyleChangedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_StyleChangedDelegate != null && ((eDocument_SinkHelper.m_StyleChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_BeforeStyleDelete(EDocument_BeforeStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_BeforeStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeStyleDelete(EDocument_BeforeStyleDeleteEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_BeforeStyleDeleteDelegate != null && ((eDocument_SinkHelper.m_BeforeStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_MasterAdded(EDocument_MasterAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_MasterAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterAdded(EDocument_MasterAddedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_MasterAddedDelegate != null && ((eDocument_SinkHelper.m_MasterAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_MasterChanged(EDocument_MasterChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_MasterChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterChanged(EDocument_MasterChangedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_MasterChangedDelegate != null && ((eDocument_SinkHelper.m_MasterChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_BeforeMasterDelete(EDocument_BeforeMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_BeforeMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeMasterDelete(EDocument_BeforeMasterDeleteEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_BeforeMasterDeleteDelegate != null && ((eDocument_SinkHelper.m_BeforeMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_PageAdded(EDocument_PageAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_PageAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageAdded(EDocument_PageAddedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_PageAddedDelegate != null && ((eDocument_SinkHelper.m_PageAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_PageChanged(EDocument_PageChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_PageChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageChanged(EDocument_PageChangedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_PageChangedDelegate != null && ((eDocument_SinkHelper.m_PageChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_BeforePageDelete(EDocument_BeforePageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_BeforePageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforePageDelete(EDocument_BeforePageDeleteEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_BeforePageDeleteDelegate != null && ((eDocument_SinkHelper.m_BeforePageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_ShapeAdded(EDocument_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_ShapeAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeAdded(EDocument_ShapeAddedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_ShapeAddedDelegate != null && ((eDocument_SinkHelper.m_ShapeAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_BeforeSelectionDelete(EDocument_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_BeforeSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSelectionDelete(EDocument_BeforeSelectionDeleteEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_BeforeSelectionDeleteDelegate != null && ((eDocument_SinkHelper.m_BeforeSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_RunModeEntered(EDocument_RunModeEnteredEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_RunModeEnteredDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_RunModeEntered(EDocument_RunModeEnteredEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_RunModeEnteredDelegate != null && ((eDocument_SinkHelper.m_RunModeEnteredDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_DesignModeEntered(EDocument_DesignModeEnteredEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_DesignModeEnteredDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DesignModeEntered(EDocument_DesignModeEnteredEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_DesignModeEnteredDelegate != null && ((eDocument_SinkHelper.m_DesignModeEnteredDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_BeforeDocumentSave(EDocument_BeforeDocumentSaveEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_BeforeDocumentSaveDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDocumentSave(EDocument_BeforeDocumentSaveEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_BeforeDocumentSaveDelegate != null && ((eDocument_SinkHelper.m_BeforeDocumentSaveDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_BeforeDocumentSaveAs(EDocument_BeforeDocumentSaveAsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_BeforeDocumentSaveAsDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDocumentSaveAs(EDocument_BeforeDocumentSaveAsEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_BeforeDocumentSaveAsDelegate != null && ((eDocument_SinkHelper.m_BeforeDocumentSaveAsDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelDocumentClose(EDocument_QueryCancelDocumentCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_QueryCancelDocumentCloseDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelDocumentClose(EDocument_QueryCancelDocumentCloseEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_QueryCancelDocumentCloseDelegate != null && ((eDocument_SinkHelper.m_QueryCancelDocumentCloseDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_DocumentCloseCanceled(EDocument_DocumentCloseCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_DocumentCloseCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentCloseCanceled(EDocument_DocumentCloseCanceledEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_DocumentCloseCanceledDelegate != null && ((eDocument_SinkHelper.m_DocumentCloseCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelStyleDelete(EDocument_QueryCancelStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_QueryCancelStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelStyleDelete(EDocument_QueryCancelStyleDeleteEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_QueryCancelStyleDeleteDelegate != null && ((eDocument_SinkHelper.m_QueryCancelStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_StyleDeleteCanceled(EDocument_StyleDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_StyleDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleDeleteCanceled(EDocument_StyleDeleteCanceledEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_StyleDeleteCanceledDelegate != null && ((eDocument_SinkHelper.m_StyleDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelMasterDelete(EDocument_QueryCancelMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_QueryCancelMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelMasterDelete(EDocument_QueryCancelMasterDeleteEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_QueryCancelMasterDeleteDelegate != null && ((eDocument_SinkHelper.m_QueryCancelMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_MasterDeleteCanceled(EDocument_MasterDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_MasterDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterDeleteCanceled(EDocument_MasterDeleteCanceledEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_MasterDeleteCanceledDelegate != null && ((eDocument_SinkHelper.m_MasterDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelPageDelete(EDocument_QueryCancelPageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_QueryCancelPageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelPageDelete(EDocument_QueryCancelPageDeleteEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_QueryCancelPageDeleteDelegate != null && ((eDocument_SinkHelper.m_QueryCancelPageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_PageDeleteCanceled(EDocument_PageDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_PageDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageDeleteCanceled(EDocument_PageDeleteCanceledEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_PageDeleteCanceledDelegate != null && ((eDocument_SinkHelper.m_PageDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_ShapeParentChanged(EDocument_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_ShapeParentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeParentChanged(EDocument_ShapeParentChangedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_ShapeParentChangedDelegate != null && ((eDocument_SinkHelper.m_ShapeParentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeTextEdit(EDocument_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_BeforeShapeTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeTextEdit(EDocument_BeforeShapeTextEditEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_BeforeShapeTextEditDelegate != null && ((eDocument_SinkHelper.m_BeforeShapeTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_ShapeExitedTextEdit(EDocument_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_ShapeExitedTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeExitedTextEdit(EDocument_ShapeExitedTextEditEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_ShapeExitedTextEditDelegate != null && ((eDocument_SinkHelper.m_ShapeExitedTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelSelectionDelete(EDocument_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_QueryCancelSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSelectionDelete(EDocument_QueryCancelSelectionDeleteEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_QueryCancelSelectionDeleteDelegate != null && ((eDocument_SinkHelper.m_QueryCancelSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_SelectionDeleteCanceled(EDocument_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_SelectionDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionDeleteCanceled(EDocument_SelectionDeleteCanceledEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_SelectionDeleteCanceledDelegate != null && ((eDocument_SinkHelper.m_SelectionDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelUngroup(EDocument_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_QueryCancelUngroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelUngroup(EDocument_QueryCancelUngroupEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_QueryCancelUngroupDelegate != null && ((eDocument_SinkHelper.m_QueryCancelUngroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_UngroupCanceled(EDocument_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_UngroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_UngroupCanceled(EDocument_UngroupCanceledEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_UngroupCanceledDelegate != null && ((eDocument_SinkHelper.m_UngroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelConvertToGroup(EDocument_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_QueryCancelConvertToGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelConvertToGroup(EDocument_QueryCancelConvertToGroupEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_QueryCancelConvertToGroupDelegate != null && ((eDocument_SinkHelper.m_QueryCancelConvertToGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_ConvertToGroupCanceled(EDocument_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_ConvertToGroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConvertToGroupCanceled(EDocument_ConvertToGroupCanceledEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_ConvertToGroupCanceledDelegate != null && ((eDocument_SinkHelper.m_ConvertToGroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelGroup(EDocument_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_QueryCancelGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelGroup(EDocument_QueryCancelGroupEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_QueryCancelGroupDelegate != null && ((eDocument_SinkHelper.m_QueryCancelGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_GroupCanceled(EDocument_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_GroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_GroupCanceled(EDocument_GroupCanceledEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_GroupCanceledDelegate != null && ((eDocument_SinkHelper.m_GroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_ShapeDataGraphicChanged(EDocument_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_ShapeDataGraphicChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeDataGraphicChanged(EDocument_ShapeDataGraphicChangedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_ShapeDataGraphicChangedDelegate != null && ((eDocument_SinkHelper.m_ShapeDataGraphicChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_BeforeDataRecordsetDelete(EDocument_BeforeDataRecordsetDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_BeforeDataRecordsetDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDataRecordsetDelete(EDocument_BeforeDataRecordsetDeleteEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_BeforeDataRecordsetDeleteDelegate != null && ((eDocument_SinkHelper.m_BeforeDataRecordsetDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_DataRecordsetAdded(EDocument_DataRecordsetAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_DataRecordsetAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DataRecordsetAdded(EDocument_DataRecordsetAddedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_DataRecordsetAddedDelegate != null && ((eDocument_SinkHelper.m_DataRecordsetAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_AfterRemoveHiddenInformation(EDocument_AfterRemoveHiddenInformationEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_AfterRemoveHiddenInformationDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterRemoveHiddenInformation(EDocument_AfterRemoveHiddenInformationEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_AfterRemoveHiddenInformationDelegate != null && ((eDocument_SinkHelper.m_AfterRemoveHiddenInformationDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_RuleSetValidated(EDocument_RuleSetValidatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_RuleSetValidatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_RuleSetValidated(EDocument_RuleSetValidatedEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_RuleSetValidatedDelegate != null && ((eDocument_SinkHelper.m_RuleSetValidatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public void add_AfterDocumentMerge(EDocument_AfterDocumentMergeEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocument_SinkHelper eDocument_SinkHelper = new EDocument_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocument_SinkHelper, out pdwCookie);
			eDocument_SinkHelper.m_dwCookie = pdwCookie;
			eDocument_SinkHelper.m_AfterDocumentMergeDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocument_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterDocumentMerge(EDocument_AfterDocumentMergeEventHandler P_0)
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
				EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocument_SinkHelper.m_AfterDocumentMergeDelegate != null && ((eDocument_SinkHelper.m_AfterDocumentMergeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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

	public EDocument_EventProvider(object P_0)
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
					EDocument_SinkHelper eDocument_SinkHelper = (EDocument_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eDocument_SinkHelper.m_dwCookie);
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
