using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EPages_EventProvider : EPages_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			9, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_PageAdded(EPages_PageAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_PageAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageAdded(EPages_PageAddedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_PageAddedDelegate != null && ((ePages_SinkHelper.m_PageAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_PageChanged(EPages_PageChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_PageChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageChanged(EPages_PageChangedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_PageChangedDelegate != null && ((ePages_SinkHelper.m_PageChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_BeforePageDelete(EPages_BeforePageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_BeforePageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforePageDelete(EPages_BeforePageDeleteEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_BeforePageDeleteDelegate != null && ((ePages_SinkHelper.m_BeforePageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ShapeAdded(EPages_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ShapeAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeAdded(EPages_ShapeAddedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ShapeAddedDelegate != null && ((ePages_SinkHelper.m_ShapeAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_BeforeSelectionDelete(EPages_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_BeforeSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSelectionDelete(EPages_BeforeSelectionDeleteEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_BeforeSelectionDeleteDelegate != null && ((ePages_SinkHelper.m_BeforeSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ShapeChanged(EPages_ShapeChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ShapeChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeChanged(EPages_ShapeChangedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ShapeChangedDelegate != null && ((ePages_SinkHelper.m_ShapeChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_SelectionAdded(EPages_SelectionAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_SelectionAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionAdded(EPages_SelectionAddedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_SelectionAddedDelegate != null && ((ePages_SinkHelper.m_SelectionAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeDelete(EPages_BeforeShapeDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_BeforeShapeDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeDelete(EPages_BeforeShapeDeleteEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_BeforeShapeDeleteDelegate != null && ((ePages_SinkHelper.m_BeforeShapeDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_TextChanged(EPages_TextChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_TextChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_TextChanged(EPages_TextChangedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_TextChangedDelegate != null && ((ePages_SinkHelper.m_TextChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_CellChanged(EPages_CellChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_CellChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CellChanged(EPages_CellChangedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_CellChangedDelegate != null && ((ePages_SinkHelper.m_CellChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_FormulaChanged(EPages_FormulaChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_FormulaChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_FormulaChanged(EPages_FormulaChangedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_FormulaChangedDelegate != null && ((ePages_SinkHelper.m_FormulaChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsAdded(EPages_ConnectionsAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ConnectionsAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsAdded(EPages_ConnectionsAddedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ConnectionsAddedDelegate != null && ((ePages_SinkHelper.m_ConnectionsAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ConnectionsDeleted(EPages_ConnectionsDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ConnectionsDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsDeleted(EPages_ConnectionsDeletedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ConnectionsDeletedDelegate != null && ((ePages_SinkHelper.m_ConnectionsDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelPageDelete(EPages_QueryCancelPageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_QueryCancelPageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelPageDelete(EPages_QueryCancelPageDeleteEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_QueryCancelPageDeleteDelegate != null && ((ePages_SinkHelper.m_QueryCancelPageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_PageDeleteCanceled(EPages_PageDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_PageDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageDeleteCanceled(EPages_PageDeleteCanceledEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_PageDeleteCanceledDelegate != null && ((ePages_SinkHelper.m_PageDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ShapeParentChanged(EPages_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ShapeParentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeParentChanged(EPages_ShapeParentChangedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ShapeParentChangedDelegate != null && ((ePages_SinkHelper.m_ShapeParentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_BeforeShapeTextEdit(EPages_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_BeforeShapeTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeTextEdit(EPages_BeforeShapeTextEditEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_BeforeShapeTextEditDelegate != null && ((ePages_SinkHelper.m_BeforeShapeTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ShapeExitedTextEdit(EPages_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ShapeExitedTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeExitedTextEdit(EPages_ShapeExitedTextEditEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ShapeExitedTextEditDelegate != null && ((ePages_SinkHelper.m_ShapeExitedTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelSelectionDelete(EPages_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_QueryCancelSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSelectionDelete(EPages_QueryCancelSelectionDeleteEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_QueryCancelSelectionDeleteDelegate != null && ((ePages_SinkHelper.m_QueryCancelSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_SelectionDeleteCanceled(EPages_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_SelectionDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionDeleteCanceled(EPages_SelectionDeleteCanceledEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_SelectionDeleteCanceledDelegate != null && ((ePages_SinkHelper.m_SelectionDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelUngroup(EPages_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_QueryCancelUngroupDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelUngroup(EPages_QueryCancelUngroupEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_QueryCancelUngroupDelegate != null && ((ePages_SinkHelper.m_QueryCancelUngroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_UngroupCanceled(EPages_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_UngroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_UngroupCanceled(EPages_UngroupCanceledEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_UngroupCanceledDelegate != null && ((ePages_SinkHelper.m_UngroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelConvertToGroup(EPages_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_QueryCancelConvertToGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelConvertToGroup(EPages_QueryCancelConvertToGroupEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_QueryCancelConvertToGroupDelegate != null && ((ePages_SinkHelper.m_QueryCancelConvertToGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ConvertToGroupCanceled(EPages_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ConvertToGroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConvertToGroupCanceled(EPages_ConvertToGroupCanceledEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ConvertToGroupCanceledDelegate != null && ((ePages_SinkHelper.m_ConvertToGroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelGroup(EPages_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_QueryCancelGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelGroup(EPages_QueryCancelGroupEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_QueryCancelGroupDelegate != null && ((ePages_SinkHelper.m_QueryCancelGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_GroupCanceled(EPages_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_GroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_GroupCanceled(EPages_GroupCanceledEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_GroupCanceledDelegate != null && ((ePages_SinkHelper.m_GroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ShapeDataGraphicChanged(EPages_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ShapeDataGraphicChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeDataGraphicChanged(EPages_ShapeDataGraphicChangedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ShapeDataGraphicChangedDelegate != null && ((ePages_SinkHelper.m_ShapeDataGraphicChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ShapeLinkAdded(EPages_ShapeLinkAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ShapeLinkAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkAdded(EPages_ShapeLinkAddedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ShapeLinkAddedDelegate != null && ((ePages_SinkHelper.m_ShapeLinkAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ShapeLinkDeleted(EPages_ShapeLinkDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ShapeLinkDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkDeleted(EPages_ShapeLinkDeletedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ShapeLinkDeletedDelegate != null && ((ePages_SinkHelper.m_ShapeLinkDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ContainerRelationshipAdded(EPages_ContainerRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ContainerRelationshipAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ContainerRelationshipAdded(EPages_ContainerRelationshipAddedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ContainerRelationshipAddedDelegate != null && ((ePages_SinkHelper.m_ContainerRelationshipAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ContainerRelationshipDeleted(EPages_ContainerRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ContainerRelationshipDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ContainerRelationshipDeleted(EPages_ContainerRelationshipDeletedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ContainerRelationshipDeletedDelegate != null && ((ePages_SinkHelper.m_ContainerRelationshipDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_CalloutRelationshipAdded(EPages_CalloutRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_CalloutRelationshipAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CalloutRelationshipAdded(EPages_CalloutRelationshipAddedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_CalloutRelationshipAddedDelegate != null && ((ePages_SinkHelper.m_CalloutRelationshipAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_CalloutRelationshipDeleted(EPages_CalloutRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_CalloutRelationshipDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CalloutRelationshipDeleted(EPages_CalloutRelationshipDeletedEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_CalloutRelationshipDeletedDelegate != null && ((ePages_SinkHelper.m_CalloutRelationshipDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_QueryCancelReplaceShapes(EPages_QueryCancelReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_QueryCancelReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelReplaceShapes(EPages_QueryCancelReplaceShapesEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_QueryCancelReplaceShapesDelegate != null && ((ePages_SinkHelper.m_QueryCancelReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_ReplaceShapesCanceled(EPages_ReplaceShapesCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_ReplaceShapesCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ReplaceShapesCanceled(EPages_ReplaceShapesCanceledEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_ReplaceShapesCanceledDelegate != null && ((ePages_SinkHelper.m_ReplaceShapesCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_BeforeReplaceShapes(EPages_BeforeReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_BeforeReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeReplaceShapes(EPages_BeforeReplaceShapesEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_BeforeReplaceShapesDelegate != null && ((ePages_SinkHelper.m_BeforeReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public void add_AfterReplaceShapes(EPages_AfterReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EPages_SinkHelper ePages_SinkHelper = new EPages_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(ePages_SinkHelper, out pdwCookie);
			ePages_SinkHelper.m_dwCookie = pdwCookie;
			ePages_SinkHelper.m_AfterReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(ePages_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterReplaceShapes(EPages_AfterReplaceShapesEventHandler P_0)
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
				EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
				if (ePages_SinkHelper.m_AfterReplaceShapesDelegate != null && ((ePages_SinkHelper.m_AfterReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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

	public EPages_EventProvider(object P_0)
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
					EPages_SinkHelper ePages_SinkHelper = (EPages_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(ePages_SinkHelper.m_dwCookie);
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
