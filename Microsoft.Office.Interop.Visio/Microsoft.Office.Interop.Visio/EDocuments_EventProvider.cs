using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EDocuments_EventProvider : EDocuments_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			3, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_AfterReplaceShapes(EDocuments_AfterReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_AfterReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterReplaceShapes(EDocuments_AfterReplaceShapesEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_AfterReplaceShapesDelegate != null && ((eDocuments_SinkHelper.m_AfterReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_AfterDocumentMerge(EDocuments_AfterDocumentMergeEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_AfterDocumentMergeDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterDocumentMerge(EDocuments_AfterDocumentMergeEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_AfterDocumentMergeDelegate != null && ((eDocuments_SinkHelper.m_AfterDocumentMergeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_DocumentOpened(EDocuments_DocumentOpenedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_DocumentOpenedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentOpened(EDocuments_DocumentOpenedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_DocumentOpenedDelegate != null && ((eDocuments_SinkHelper.m_DocumentOpenedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_DocumentCreated(EDocuments_DocumentCreatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_DocumentCreatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentCreated(EDocuments_DocumentCreatedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_DocumentCreatedDelegate != null && ((eDocuments_SinkHelper.m_DocumentCreatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_DocumentSaved(EDocuments_DocumentSavedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_DocumentSavedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentSaved(EDocuments_DocumentSavedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_DocumentSavedDelegate != null && ((eDocuments_SinkHelper.m_DocumentSavedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_DocumentSavedAs(EDocuments_DocumentSavedAsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_DocumentSavedAsDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentSavedAs(EDocuments_DocumentSavedAsEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_DocumentSavedAsDelegate != null && ((eDocuments_SinkHelper.m_DocumentSavedAsDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_DocumentChanged(EDocuments_DocumentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_DocumentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentChanged(EDocuments_DocumentChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_DocumentChangedDelegate != null && ((eDocuments_SinkHelper.m_DocumentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeDocumentClose(EDocuments_BeforeDocumentCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeDocumentCloseDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDocumentClose(EDocuments_BeforeDocumentCloseEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeDocumentCloseDelegate != null && ((eDocuments_SinkHelper.m_BeforeDocumentCloseDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_StyleAdded(EDocuments_StyleAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_StyleAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleAdded(EDocuments_StyleAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_StyleAddedDelegate != null && ((eDocuments_SinkHelper.m_StyleAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_StyleChanged(EDocuments_StyleChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_StyleChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleChanged(EDocuments_StyleChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_StyleChangedDelegate != null && ((eDocuments_SinkHelper.m_StyleChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeStyleDelete(EDocuments_BeforeStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeStyleDelete(EDocuments_BeforeStyleDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeStyleDeleteDelegate != null && ((eDocuments_SinkHelper.m_BeforeStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_MasterAdded(EDocuments_MasterAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_MasterAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterAdded(EDocuments_MasterAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_MasterAddedDelegate != null && ((eDocuments_SinkHelper.m_MasterAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_MasterChanged(EDocuments_MasterChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_MasterChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterChanged(EDocuments_MasterChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_MasterChangedDelegate != null && ((eDocuments_SinkHelper.m_MasterChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeMasterDelete(EDocuments_BeforeMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeMasterDelete(EDocuments_BeforeMasterDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeMasterDeleteDelegate != null && ((eDocuments_SinkHelper.m_BeforeMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_PageAdded(EDocuments_PageAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_PageAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageAdded(EDocuments_PageAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_PageAddedDelegate != null && ((eDocuments_SinkHelper.m_PageAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_PageChanged(EDocuments_PageChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_PageChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageChanged(EDocuments_PageChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_PageChangedDelegate != null && ((eDocuments_SinkHelper.m_PageChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforePageDelete(EDocuments_BeforePageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforePageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforePageDelete(EDocuments_BeforePageDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforePageDeleteDelegate != null && ((eDocuments_SinkHelper.m_BeforePageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ShapeAdded(EDocuments_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ShapeAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeAdded(EDocuments_ShapeAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ShapeAddedDelegate != null && ((eDocuments_SinkHelper.m_ShapeAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeSelectionDelete(EDocuments_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSelectionDelete(EDocuments_BeforeSelectionDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeSelectionDeleteDelegate != null && ((eDocuments_SinkHelper.m_BeforeSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ShapeChanged(EDocuments_ShapeChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ShapeChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeChanged(EDocuments_ShapeChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ShapeChangedDelegate != null && ((eDocuments_SinkHelper.m_ShapeChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_SelectionAdded(EDocuments_SelectionAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_SelectionAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionAdded(EDocuments_SelectionAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_SelectionAddedDelegate != null && ((eDocuments_SinkHelper.m_SelectionAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeDelete(EDocuments_BeforeShapeDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeShapeDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeDelete(EDocuments_BeforeShapeDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeShapeDeleteDelegate != null && ((eDocuments_SinkHelper.m_BeforeShapeDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_TextChanged(EDocuments_TextChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_TextChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_TextChanged(EDocuments_TextChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_TextChangedDelegate != null && ((eDocuments_SinkHelper.m_TextChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_CellChanged(EDocuments_CellChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_CellChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CellChanged(EDocuments_CellChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_CellChangedDelegate != null && ((eDocuments_SinkHelper.m_CellChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_RunModeEntered(EDocuments_RunModeEnteredEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_RunModeEnteredDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_RunModeEntered(EDocuments_RunModeEnteredEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_RunModeEnteredDelegate != null && ((eDocuments_SinkHelper.m_RunModeEnteredDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_DesignModeEntered(EDocuments_DesignModeEnteredEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_DesignModeEnteredDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DesignModeEntered(EDocuments_DesignModeEnteredEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_DesignModeEnteredDelegate != null && ((eDocuments_SinkHelper.m_DesignModeEnteredDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeDocumentSave(EDocuments_BeforeDocumentSaveEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeDocumentSaveDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDocumentSave(EDocuments_BeforeDocumentSaveEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeDocumentSaveDelegate != null && ((eDocuments_SinkHelper.m_BeforeDocumentSaveDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeDocumentSaveAs(EDocuments_BeforeDocumentSaveAsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeDocumentSaveAsDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDocumentSaveAs(EDocuments_BeforeDocumentSaveAsEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeDocumentSaveAsDelegate != null && ((eDocuments_SinkHelper.m_BeforeDocumentSaveAsDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_FormulaChanged(EDocuments_FormulaChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_FormulaChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_FormulaChanged(EDocuments_FormulaChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_FormulaChangedDelegate != null && ((eDocuments_SinkHelper.m_FormulaChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsAdded(EDocuments_ConnectionsAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ConnectionsAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsAdded(EDocuments_ConnectionsAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ConnectionsAddedDelegate != null && ((eDocuments_SinkHelper.m_ConnectionsAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsDeleted(EDocuments_ConnectionsDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ConnectionsDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsDeleted(EDocuments_ConnectionsDeletedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ConnectionsDeletedDelegate != null && ((eDocuments_SinkHelper.m_ConnectionsDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelDocumentClose(EDocuments_QueryCancelDocumentCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_QueryCancelDocumentCloseDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelDocumentClose(EDocuments_QueryCancelDocumentCloseEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_QueryCancelDocumentCloseDelegate != null && ((eDocuments_SinkHelper.m_QueryCancelDocumentCloseDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_DocumentCloseCanceled(EDocuments_DocumentCloseCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_DocumentCloseCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentCloseCanceled(EDocuments_DocumentCloseCanceledEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_DocumentCloseCanceledDelegate != null && ((eDocuments_SinkHelper.m_DocumentCloseCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelStyleDelete(EDocuments_QueryCancelStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_QueryCancelStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelStyleDelete(EDocuments_QueryCancelStyleDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_QueryCancelStyleDeleteDelegate != null && ((eDocuments_SinkHelper.m_QueryCancelStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_StyleDeleteCanceled(EDocuments_StyleDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_StyleDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleDeleteCanceled(EDocuments_StyleDeleteCanceledEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_StyleDeleteCanceledDelegate != null && ((eDocuments_SinkHelper.m_StyleDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelMasterDelete(EDocuments_QueryCancelMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_QueryCancelMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelMasterDelete(EDocuments_QueryCancelMasterDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_QueryCancelMasterDeleteDelegate != null && ((eDocuments_SinkHelper.m_QueryCancelMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_MasterDeleteCanceled(EDocuments_MasterDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_MasterDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterDeleteCanceled(EDocuments_MasterDeleteCanceledEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_MasterDeleteCanceledDelegate != null && ((eDocuments_SinkHelper.m_MasterDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelPageDelete(EDocuments_QueryCancelPageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_QueryCancelPageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelPageDelete(EDocuments_QueryCancelPageDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_QueryCancelPageDeleteDelegate != null && ((eDocuments_SinkHelper.m_QueryCancelPageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_PageDeleteCanceled(EDocuments_PageDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_PageDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageDeleteCanceled(EDocuments_PageDeleteCanceledEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_PageDeleteCanceledDelegate != null && ((eDocuments_SinkHelper.m_PageDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ShapeParentChanged(EDocuments_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ShapeParentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeParentChanged(EDocuments_ShapeParentChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ShapeParentChangedDelegate != null && ((eDocuments_SinkHelper.m_ShapeParentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeTextEdit(EDocuments_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeShapeTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeTextEdit(EDocuments_BeforeShapeTextEditEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeShapeTextEditDelegate != null && ((eDocuments_SinkHelper.m_BeforeShapeTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ShapeExitedTextEdit(EDocuments_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ShapeExitedTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeExitedTextEdit(EDocuments_ShapeExitedTextEditEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ShapeExitedTextEditDelegate != null && ((eDocuments_SinkHelper.m_ShapeExitedTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelSelectionDelete(EDocuments_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_QueryCancelSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSelectionDelete(EDocuments_QueryCancelSelectionDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_QueryCancelSelectionDeleteDelegate != null && ((eDocuments_SinkHelper.m_QueryCancelSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_SelectionDeleteCanceled(EDocuments_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_SelectionDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionDeleteCanceled(EDocuments_SelectionDeleteCanceledEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_SelectionDeleteCanceledDelegate != null && ((eDocuments_SinkHelper.m_SelectionDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelUngroup(EDocuments_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_QueryCancelUngroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelUngroup(EDocuments_QueryCancelUngroupEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_QueryCancelUngroupDelegate != null && ((eDocuments_SinkHelper.m_QueryCancelUngroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_UngroupCanceled(EDocuments_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_UngroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_UngroupCanceled(EDocuments_UngroupCanceledEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_UngroupCanceledDelegate != null && ((eDocuments_SinkHelper.m_UngroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelConvertToGroup(EDocuments_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_QueryCancelConvertToGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelConvertToGroup(EDocuments_QueryCancelConvertToGroupEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_QueryCancelConvertToGroupDelegate != null && ((eDocuments_SinkHelper.m_QueryCancelConvertToGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ConvertToGroupCanceled(EDocuments_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ConvertToGroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConvertToGroupCanceled(EDocuments_ConvertToGroupCanceledEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ConvertToGroupCanceledDelegate != null && ((eDocuments_SinkHelper.m_ConvertToGroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelGroup(EDocuments_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_QueryCancelGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelGroup(EDocuments_QueryCancelGroupEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_QueryCancelGroupDelegate != null && ((eDocuments_SinkHelper.m_QueryCancelGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_GroupCanceled(EDocuments_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_GroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_GroupCanceled(EDocuments_GroupCanceledEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_GroupCanceledDelegate != null && ((eDocuments_SinkHelper.m_GroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ShapeDataGraphicChanged(EDocuments_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ShapeDataGraphicChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeDataGraphicChanged(EDocuments_ShapeDataGraphicChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ShapeDataGraphicChangedDelegate != null && ((eDocuments_SinkHelper.m_ShapeDataGraphicChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeDataRecordsetDelete(EDocuments_BeforeDataRecordsetDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeDataRecordsetDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDataRecordsetDelete(EDocuments_BeforeDataRecordsetDeleteEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeDataRecordsetDeleteDelegate != null && ((eDocuments_SinkHelper.m_BeforeDataRecordsetDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_DataRecordsetChanged(EDocuments_DataRecordsetChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_DataRecordsetChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DataRecordsetChanged(EDocuments_DataRecordsetChangedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_DataRecordsetChangedDelegate != null && ((eDocuments_SinkHelper.m_DataRecordsetChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_DataRecordsetAdded(EDocuments_DataRecordsetAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_DataRecordsetAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DataRecordsetAdded(EDocuments_DataRecordsetAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_DataRecordsetAddedDelegate != null && ((eDocuments_SinkHelper.m_DataRecordsetAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ShapeLinkAdded(EDocuments_ShapeLinkAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ShapeLinkAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkAdded(EDocuments_ShapeLinkAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ShapeLinkAddedDelegate != null && ((eDocuments_SinkHelper.m_ShapeLinkAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ShapeLinkDeleted(EDocuments_ShapeLinkDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ShapeLinkDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkDeleted(EDocuments_ShapeLinkDeletedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ShapeLinkDeletedDelegate != null && ((eDocuments_SinkHelper.m_ShapeLinkDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_AfterRemoveHiddenInformation(EDocuments_AfterRemoveHiddenInformationEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_AfterRemoveHiddenInformationDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterRemoveHiddenInformation(EDocuments_AfterRemoveHiddenInformationEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_AfterRemoveHiddenInformationDelegate != null && ((eDocuments_SinkHelper.m_AfterRemoveHiddenInformationDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ContainerRelationshipAdded(EDocuments_ContainerRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ContainerRelationshipAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ContainerRelationshipAdded(EDocuments_ContainerRelationshipAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ContainerRelationshipAddedDelegate != null && ((eDocuments_SinkHelper.m_ContainerRelationshipAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ContainerRelationshipDeleted(EDocuments_ContainerRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ContainerRelationshipDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ContainerRelationshipDeleted(EDocuments_ContainerRelationshipDeletedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ContainerRelationshipDeletedDelegate != null && ((eDocuments_SinkHelper.m_ContainerRelationshipDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_CalloutRelationshipAdded(EDocuments_CalloutRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_CalloutRelationshipAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CalloutRelationshipAdded(EDocuments_CalloutRelationshipAddedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_CalloutRelationshipAddedDelegate != null && ((eDocuments_SinkHelper.m_CalloutRelationshipAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_CalloutRelationshipDeleted(EDocuments_CalloutRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_CalloutRelationshipDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CalloutRelationshipDeleted(EDocuments_CalloutRelationshipDeletedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_CalloutRelationshipDeletedDelegate != null && ((eDocuments_SinkHelper.m_CalloutRelationshipDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_RuleSetValidated(EDocuments_RuleSetValidatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_RuleSetValidatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_RuleSetValidated(EDocuments_RuleSetValidatedEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_RuleSetValidatedDelegate != null && ((eDocuments_SinkHelper.m_RuleSetValidatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelReplaceShapes(EDocuments_QueryCancelReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_QueryCancelReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelReplaceShapes(EDocuments_QueryCancelReplaceShapesEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_QueryCancelReplaceShapesDelegate != null && ((eDocuments_SinkHelper.m_QueryCancelReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_ReplaceShapesCanceled(EDocuments_ReplaceShapesCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_ReplaceShapesCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ReplaceShapesCanceled(EDocuments_ReplaceShapesCanceledEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_ReplaceShapesCanceledDelegate != null && ((eDocuments_SinkHelper.m_ReplaceShapesCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public void add_BeforeReplaceShapes(EDocuments_BeforeReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EDocuments_SinkHelper eDocuments_SinkHelper = new EDocuments_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eDocuments_SinkHelper, out pdwCookie);
			eDocuments_SinkHelper.m_dwCookie = pdwCookie;
			eDocuments_SinkHelper.m_BeforeReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(eDocuments_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeReplaceShapes(EDocuments_BeforeReplaceShapesEventHandler P_0)
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
				EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
				if (eDocuments_SinkHelper.m_BeforeReplaceShapesDelegate != null && ((eDocuments_SinkHelper.m_BeforeReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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

	public EDocuments_EventProvider(object P_0)
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
					EDocuments_SinkHelper eDocuments_SinkHelper = (EDocuments_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eDocuments_SinkHelper.m_dwCookie);
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
