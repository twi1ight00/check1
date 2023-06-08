using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EMaster_EventProvider : EMaster_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			8, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_MasterChanged(EMaster_MasterChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_MasterChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterChanged(EMaster_MasterChangedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_MasterChangedDelegate != null && ((eMaster_SinkHelper.m_MasterChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_BeforeMasterDelete(EMaster_BeforeMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_BeforeMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeMasterDelete(EMaster_BeforeMasterDeleteEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_BeforeMasterDeleteDelegate != null && ((eMaster_SinkHelper.m_BeforeMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_ShapeAdded(EMaster_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_ShapeAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeAdded(EMaster_ShapeAddedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_ShapeAddedDelegate != null && ((eMaster_SinkHelper.m_ShapeAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_BeforeSelectionDelete(EMaster_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_BeforeSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSelectionDelete(EMaster_BeforeSelectionDeleteEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_BeforeSelectionDeleteDelegate != null && ((eMaster_SinkHelper.m_BeforeSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_ShapeChanged(EMaster_ShapeChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_ShapeChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeChanged(EMaster_ShapeChangedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_ShapeChangedDelegate != null && ((eMaster_SinkHelper.m_ShapeChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_SelectionAdded(EMaster_SelectionAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_SelectionAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionAdded(EMaster_SelectionAddedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_SelectionAddedDelegate != null && ((eMaster_SinkHelper.m_SelectionAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeDelete(EMaster_BeforeShapeDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_BeforeShapeDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeDelete(EMaster_BeforeShapeDeleteEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_BeforeShapeDeleteDelegate != null && ((eMaster_SinkHelper.m_BeforeShapeDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_TextChanged(EMaster_TextChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_TextChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_TextChanged(EMaster_TextChangedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_TextChangedDelegate != null && ((eMaster_SinkHelper.m_TextChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_CellChanged(EMaster_CellChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_CellChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CellChanged(EMaster_CellChangedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_CellChangedDelegate != null && ((eMaster_SinkHelper.m_CellChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_FormulaChanged(EMaster_FormulaChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_FormulaChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_FormulaChanged(EMaster_FormulaChangedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_FormulaChangedDelegate != null && ((eMaster_SinkHelper.m_FormulaChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsAdded(EMaster_ConnectionsAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_ConnectionsAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsAdded(EMaster_ConnectionsAddedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_ConnectionsAddedDelegate != null && ((eMaster_SinkHelper.m_ConnectionsAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsDeleted(EMaster_ConnectionsDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_ConnectionsDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsDeleted(EMaster_ConnectionsDeletedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_ConnectionsDeletedDelegate != null && ((eMaster_SinkHelper.m_ConnectionsDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelMasterDelete(EMaster_QueryCancelMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_QueryCancelMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelMasterDelete(EMaster_QueryCancelMasterDeleteEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_QueryCancelMasterDeleteDelegate != null && ((eMaster_SinkHelper.m_QueryCancelMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_MasterDeleteCanceled(EMaster_MasterDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_MasterDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterDeleteCanceled(EMaster_MasterDeleteCanceledEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_MasterDeleteCanceledDelegate != null && ((eMaster_SinkHelper.m_MasterDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_ShapeParentChanged(EMaster_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_ShapeParentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeParentChanged(EMaster_ShapeParentChangedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_ShapeParentChangedDelegate != null && ((eMaster_SinkHelper.m_ShapeParentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeTextEdit(EMaster_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_BeforeShapeTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeTextEdit(EMaster_BeforeShapeTextEditEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_BeforeShapeTextEditDelegate != null && ((eMaster_SinkHelper.m_BeforeShapeTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_ShapeExitedTextEdit(EMaster_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_ShapeExitedTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeExitedTextEdit(EMaster_ShapeExitedTextEditEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_ShapeExitedTextEditDelegate != null && ((eMaster_SinkHelper.m_ShapeExitedTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelSelectionDelete(EMaster_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_QueryCancelSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSelectionDelete(EMaster_QueryCancelSelectionDeleteEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_QueryCancelSelectionDeleteDelegate != null && ((eMaster_SinkHelper.m_QueryCancelSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_SelectionDeleteCanceled(EMaster_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_SelectionDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionDeleteCanceled(EMaster_SelectionDeleteCanceledEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_SelectionDeleteCanceledDelegate != null && ((eMaster_SinkHelper.m_SelectionDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelUngroup(EMaster_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_QueryCancelUngroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelUngroup(EMaster_QueryCancelUngroupEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_QueryCancelUngroupDelegate != null && ((eMaster_SinkHelper.m_QueryCancelUngroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_UngroupCanceled(EMaster_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_UngroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_UngroupCanceled(EMaster_UngroupCanceledEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_UngroupCanceledDelegate != null && ((eMaster_SinkHelper.m_UngroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelConvertToGroup(EMaster_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_QueryCancelConvertToGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelConvertToGroup(EMaster_QueryCancelConvertToGroupEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_QueryCancelConvertToGroupDelegate != null && ((eMaster_SinkHelper.m_QueryCancelConvertToGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_ConvertToGroupCanceled(EMaster_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_ConvertToGroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConvertToGroupCanceled(EMaster_ConvertToGroupCanceledEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_ConvertToGroupCanceledDelegate != null && ((eMaster_SinkHelper.m_ConvertToGroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelGroup(EMaster_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_QueryCancelGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelGroup(EMaster_QueryCancelGroupEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_QueryCancelGroupDelegate != null && ((eMaster_SinkHelper.m_QueryCancelGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_GroupCanceled(EMaster_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_GroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_GroupCanceled(EMaster_GroupCanceledEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_GroupCanceledDelegate != null && ((eMaster_SinkHelper.m_GroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public void add_ShapeDataGraphicChanged(EMaster_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMaster_SinkHelper eMaster_SinkHelper = new EMaster_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMaster_SinkHelper, out pdwCookie);
			eMaster_SinkHelper.m_dwCookie = pdwCookie;
			eMaster_SinkHelper.m_ShapeDataGraphicChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMaster_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeDataGraphicChanged(EMaster_ShapeDataGraphicChangedEventHandler P_0)
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
				EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
				if (eMaster_SinkHelper.m_ShapeDataGraphicChangedDelegate != null && ((eMaster_SinkHelper.m_ShapeDataGraphicChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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

	public EMaster_EventProvider(object P_0)
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
					EMaster_SinkHelper eMaster_SinkHelper = (EMaster_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eMaster_SinkHelper.m_dwCookie);
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
