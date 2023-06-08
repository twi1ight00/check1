using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EMasters_EventProvider : EMasters_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			7, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_MasterAdded(EMasters_MasterAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_MasterAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterAdded(EMasters_MasterAddedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_MasterAddedDelegate != null && ((eMasters_SinkHelper.m_MasterAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_MasterChanged(EMasters_MasterChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_MasterChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterChanged(EMasters_MasterChangedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_MasterChangedDelegate != null && ((eMasters_SinkHelper.m_MasterChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_BeforeMasterDelete(EMasters_BeforeMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_BeforeMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeMasterDelete(EMasters_BeforeMasterDeleteEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_BeforeMasterDeleteDelegate != null && ((eMasters_SinkHelper.m_BeforeMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_ShapeAdded(EMasters_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_ShapeAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeAdded(EMasters_ShapeAddedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_ShapeAddedDelegate != null && ((eMasters_SinkHelper.m_ShapeAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_BeforeSelectionDelete(EMasters_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_BeforeSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSelectionDelete(EMasters_BeforeSelectionDeleteEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_BeforeSelectionDeleteDelegate != null && ((eMasters_SinkHelper.m_BeforeSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_ShapeChanged(EMasters_ShapeChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_ShapeChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeChanged(EMasters_ShapeChangedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_ShapeChangedDelegate != null && ((eMasters_SinkHelper.m_ShapeChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_SelectionAdded(EMasters_SelectionAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_SelectionAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionAdded(EMasters_SelectionAddedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_SelectionAddedDelegate != null && ((eMasters_SinkHelper.m_SelectionAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeDelete(EMasters_BeforeShapeDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_BeforeShapeDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeDelete(EMasters_BeforeShapeDeleteEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_BeforeShapeDeleteDelegate != null && ((eMasters_SinkHelper.m_BeforeShapeDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_TextChanged(EMasters_TextChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_TextChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_TextChanged(EMasters_TextChangedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_TextChangedDelegate != null && ((eMasters_SinkHelper.m_TextChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_CellChanged(EMasters_CellChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_CellChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CellChanged(EMasters_CellChangedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_CellChangedDelegate != null && ((eMasters_SinkHelper.m_CellChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_FormulaChanged(EMasters_FormulaChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_FormulaChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_FormulaChanged(EMasters_FormulaChangedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_FormulaChangedDelegate != null && ((eMasters_SinkHelper.m_FormulaChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsAdded(EMasters_ConnectionsAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_ConnectionsAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsAdded(EMasters_ConnectionsAddedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_ConnectionsAddedDelegate != null && ((eMasters_SinkHelper.m_ConnectionsAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsDeleted(EMasters_ConnectionsDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_ConnectionsDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsDeleted(EMasters_ConnectionsDeletedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_ConnectionsDeletedDelegate != null && ((eMasters_SinkHelper.m_ConnectionsDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelMasterDelete(EMasters_QueryCancelMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_QueryCancelMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelMasterDelete(EMasters_QueryCancelMasterDeleteEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_QueryCancelMasterDeleteDelegate != null && ((eMasters_SinkHelper.m_QueryCancelMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_MasterDeleteCanceled(EMasters_MasterDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_MasterDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterDeleteCanceled(EMasters_MasterDeleteCanceledEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_MasterDeleteCanceledDelegate != null && ((eMasters_SinkHelper.m_MasterDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_ShapeParentChanged(EMasters_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_ShapeParentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeParentChanged(EMasters_ShapeParentChangedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_ShapeParentChangedDelegate != null && ((eMasters_SinkHelper.m_ShapeParentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeTextEdit(EMasters_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_BeforeShapeTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeTextEdit(EMasters_BeforeShapeTextEditEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_BeforeShapeTextEditDelegate != null && ((eMasters_SinkHelper.m_BeforeShapeTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_ShapeExitedTextEdit(EMasters_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_ShapeExitedTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeExitedTextEdit(EMasters_ShapeExitedTextEditEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_ShapeExitedTextEditDelegate != null && ((eMasters_SinkHelper.m_ShapeExitedTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelSelectionDelete(EMasters_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_QueryCancelSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSelectionDelete(EMasters_QueryCancelSelectionDeleteEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_QueryCancelSelectionDeleteDelegate != null && ((eMasters_SinkHelper.m_QueryCancelSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_SelectionDeleteCanceled(EMasters_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_SelectionDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionDeleteCanceled(EMasters_SelectionDeleteCanceledEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_SelectionDeleteCanceledDelegate != null && ((eMasters_SinkHelper.m_SelectionDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelUngroup(EMasters_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_QueryCancelUngroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelUngroup(EMasters_QueryCancelUngroupEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_QueryCancelUngroupDelegate != null && ((eMasters_SinkHelper.m_QueryCancelUngroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_UngroupCanceled(EMasters_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_UngroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_UngroupCanceled(EMasters_UngroupCanceledEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_UngroupCanceledDelegate != null && ((eMasters_SinkHelper.m_UngroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelConvertToGroup(EMasters_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_QueryCancelConvertToGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelConvertToGroup(EMasters_QueryCancelConvertToGroupEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_QueryCancelConvertToGroupDelegate != null && ((eMasters_SinkHelper.m_QueryCancelConvertToGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_ConvertToGroupCanceled(EMasters_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_ConvertToGroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConvertToGroupCanceled(EMasters_ConvertToGroupCanceledEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_ConvertToGroupCanceledDelegate != null && ((eMasters_SinkHelper.m_ConvertToGroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelGroup(EMasters_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_QueryCancelGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelGroup(EMasters_QueryCancelGroupEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_QueryCancelGroupDelegate != null && ((eMasters_SinkHelper.m_QueryCancelGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_GroupCanceled(EMasters_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_GroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_GroupCanceled(EMasters_GroupCanceledEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_GroupCanceledDelegate != null && ((eMasters_SinkHelper.m_GroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public void add_ShapeDataGraphicChanged(EMasters_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EMasters_SinkHelper eMasters_SinkHelper = new EMasters_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eMasters_SinkHelper, out pdwCookie);
			eMasters_SinkHelper.m_dwCookie = pdwCookie;
			eMasters_SinkHelper.m_ShapeDataGraphicChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eMasters_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeDataGraphicChanged(EMasters_ShapeDataGraphicChangedEventHandler P_0)
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
				EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
				if (eMasters_SinkHelper.m_ShapeDataGraphicChangedDelegate != null && ((eMasters_SinkHelper.m_ShapeDataGraphicChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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

	public EMasters_EventProvider(object P_0)
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
					EMasters_SinkHelper eMasters_SinkHelper = (EMasters_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eMasters_SinkHelper.m_dwCookie);
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
