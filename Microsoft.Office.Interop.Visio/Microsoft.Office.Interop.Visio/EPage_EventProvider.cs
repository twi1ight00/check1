using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EPage_EventProvider : EPage_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			10, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_PageChanged(EPage_PageChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_PageChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageChanged(EPage_PageChangedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_PageChangedDelegate != null && ((ePage_SinkHelper.m_PageChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_BeforePageDelete(EPage_BeforePageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_BeforePageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforePageDelete(EPage_BeforePageDeleteEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_BeforePageDeleteDelegate != null && ((ePage_SinkHelper.m_BeforePageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ShapeAdded(EPage_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ShapeAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeAdded(EPage_ShapeAddedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ShapeAddedDelegate != null && ((ePage_SinkHelper.m_ShapeAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_BeforeSelectionDelete(EPage_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_BeforeSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSelectionDelete(EPage_BeforeSelectionDeleteEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_BeforeSelectionDeleteDelegate != null && ((ePage_SinkHelper.m_BeforeSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ShapeChanged(EPage_ShapeChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ShapeChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeChanged(EPage_ShapeChangedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ShapeChangedDelegate != null && ((ePage_SinkHelper.m_ShapeChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_SelectionAdded(EPage_SelectionAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_SelectionAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionAdded(EPage_SelectionAddedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_SelectionAddedDelegate != null && ((ePage_SinkHelper.m_SelectionAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeDelete(EPage_BeforeShapeDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_BeforeShapeDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeDelete(EPage_BeforeShapeDeleteEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_BeforeShapeDeleteDelegate != null && ((ePage_SinkHelper.m_BeforeShapeDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_TextChanged(EPage_TextChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_TextChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_TextChanged(EPage_TextChangedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_TextChangedDelegate != null && ((ePage_SinkHelper.m_TextChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_CellChanged(EPage_CellChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_CellChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CellChanged(EPage_CellChangedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_CellChangedDelegate != null && ((ePage_SinkHelper.m_CellChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_FormulaChanged(EPage_FormulaChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_FormulaChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_FormulaChanged(EPage_FormulaChangedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_FormulaChangedDelegate != null && ((ePage_SinkHelper.m_FormulaChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsAdded(EPage_ConnectionsAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ConnectionsAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsAdded(EPage_ConnectionsAddedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ConnectionsAddedDelegate != null && ((ePage_SinkHelper.m_ConnectionsAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsDeleted(EPage_ConnectionsDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ConnectionsDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsDeleted(EPage_ConnectionsDeletedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ConnectionsDeletedDelegate != null && ((ePage_SinkHelper.m_ConnectionsDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelPageDelete(EPage_QueryCancelPageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_QueryCancelPageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelPageDelete(EPage_QueryCancelPageDeleteEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_QueryCancelPageDeleteDelegate != null && ((ePage_SinkHelper.m_QueryCancelPageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_PageDeleteCanceled(EPage_PageDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_PageDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageDeleteCanceled(EPage_PageDeleteCanceledEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_PageDeleteCanceledDelegate != null && ((ePage_SinkHelper.m_PageDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ShapeParentChanged(EPage_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ShapeParentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeParentChanged(EPage_ShapeParentChangedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ShapeParentChangedDelegate != null && ((ePage_SinkHelper.m_ShapeParentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeTextEdit(EPage_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_BeforeShapeTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeTextEdit(EPage_BeforeShapeTextEditEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_BeforeShapeTextEditDelegate != null && ((ePage_SinkHelper.m_BeforeShapeTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ShapeExitedTextEdit(EPage_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ShapeExitedTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeExitedTextEdit(EPage_ShapeExitedTextEditEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ShapeExitedTextEditDelegate != null && ((ePage_SinkHelper.m_ShapeExitedTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelSelectionDelete(EPage_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_QueryCancelSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSelectionDelete(EPage_QueryCancelSelectionDeleteEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_QueryCancelSelectionDeleteDelegate != null && ((ePage_SinkHelper.m_QueryCancelSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_SelectionDeleteCanceled(EPage_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_SelectionDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionDeleteCanceled(EPage_SelectionDeleteCanceledEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_SelectionDeleteCanceledDelegate != null && ((ePage_SinkHelper.m_SelectionDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelUngroup(EPage_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_QueryCancelUngroupDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelUngroup(EPage_QueryCancelUngroupEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_QueryCancelUngroupDelegate != null && ((ePage_SinkHelper.m_QueryCancelUngroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_UngroupCanceled(EPage_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_UngroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_UngroupCanceled(EPage_UngroupCanceledEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_UngroupCanceledDelegate != null && ((ePage_SinkHelper.m_UngroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelConvertToGroup(EPage_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_QueryCancelConvertToGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelConvertToGroup(EPage_QueryCancelConvertToGroupEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_QueryCancelConvertToGroupDelegate != null && ((ePage_SinkHelper.m_QueryCancelConvertToGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ConvertToGroupCanceled(EPage_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ConvertToGroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConvertToGroupCanceled(EPage_ConvertToGroupCanceledEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ConvertToGroupCanceledDelegate != null && ((ePage_SinkHelper.m_ConvertToGroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelGroup(EPage_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_QueryCancelGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelGroup(EPage_QueryCancelGroupEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_QueryCancelGroupDelegate != null && ((ePage_SinkHelper.m_QueryCancelGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_GroupCanceled(EPage_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_GroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_GroupCanceled(EPage_GroupCanceledEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_GroupCanceledDelegate != null && ((ePage_SinkHelper.m_GroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ShapeDataGraphicChanged(EPage_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ShapeDataGraphicChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeDataGraphicChanged(EPage_ShapeDataGraphicChangedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ShapeDataGraphicChangedDelegate != null && ((ePage_SinkHelper.m_ShapeDataGraphicChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ShapeLinkAdded(EPage_ShapeLinkAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ShapeLinkAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkAdded(EPage_ShapeLinkAddedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ShapeLinkAddedDelegate != null && ((ePage_SinkHelper.m_ShapeLinkAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ShapeLinkDeleted(EPage_ShapeLinkDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ShapeLinkDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkDeleted(EPage_ShapeLinkDeletedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ShapeLinkDeletedDelegate != null && ((ePage_SinkHelper.m_ShapeLinkDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ContainerRelationshipAdded(EPage_ContainerRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ContainerRelationshipAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ContainerRelationshipAdded(EPage_ContainerRelationshipAddedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ContainerRelationshipAddedDelegate != null && ((ePage_SinkHelper.m_ContainerRelationshipAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ContainerRelationshipDeleted(EPage_ContainerRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ContainerRelationshipDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ContainerRelationshipDeleted(EPage_ContainerRelationshipDeletedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ContainerRelationshipDeletedDelegate != null && ((ePage_SinkHelper.m_ContainerRelationshipDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_CalloutRelationshipAdded(EPage_CalloutRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_CalloutRelationshipAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CalloutRelationshipAdded(EPage_CalloutRelationshipAddedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_CalloutRelationshipAddedDelegate != null && ((ePage_SinkHelper.m_CalloutRelationshipAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_CalloutRelationshipDeleted(EPage_CalloutRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_CalloutRelationshipDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CalloutRelationshipDeleted(EPage_CalloutRelationshipDeletedEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_CalloutRelationshipDeletedDelegate != null && ((ePage_SinkHelper.m_CalloutRelationshipDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelReplaceShapes(EPage_QueryCancelReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_QueryCancelReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelReplaceShapes(EPage_QueryCancelReplaceShapesEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_QueryCancelReplaceShapesDelegate != null && ((ePage_SinkHelper.m_QueryCancelReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_ReplaceShapesCanceled(EPage_ReplaceShapesCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_ReplaceShapesCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ReplaceShapesCanceled(EPage_ReplaceShapesCanceledEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_ReplaceShapesCanceledDelegate != null && ((ePage_SinkHelper.m_ReplaceShapesCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_BeforeReplaceShapes(EPage_BeforeReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_BeforeReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeReplaceShapes(EPage_BeforeReplaceShapesEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_BeforeReplaceShapesDelegate != null && ((ePage_SinkHelper.m_BeforeReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public void add_AfterReplaceShapes(EPage_AfterReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPage_SinkHelper ePage_SinkHelper = new EPage_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePage_SinkHelper, out pdwCookie);
			ePage_SinkHelper.m_dwCookie = pdwCookie;
			ePage_SinkHelper.m_AfterReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(ePage_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterReplaceShapes(EPage_AfterReplaceShapesEventHandler P_0)
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
				EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
				if (ePage_SinkHelper.m_AfterReplaceShapesDelegate != null && ((ePage_SinkHelper.m_AfterReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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

	public EPage_EventProvider(object P_0)
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
					EPage_SinkHelper ePage_SinkHelper = (EPage_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(ePage_SinkHelper.m_dwCookie);
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
