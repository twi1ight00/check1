using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EShape_EventProvider : EShape_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			11, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_CellChanged(EShape_CellChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_CellChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CellChanged(EShape_CellChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_CellChangedDelegate != null && ((eShape_SinkHelper.m_CellChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeAdded(EShape_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_ShapeAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeAdded(EShape_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_ShapeAddedDelegate != null && ((eShape_SinkHelper.m_ShapeAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeSelectionDelete(EShape_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_BeforeSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSelectionDelete(EShape_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_BeforeSelectionDeleteDelegate != null && ((eShape_SinkHelper.m_BeforeSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeChanged(EShape_ShapeChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_ShapeChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeChanged(EShape_ShapeChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_ShapeChangedDelegate != null && ((eShape_SinkHelper.m_ShapeChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_SelectionAdded(EShape_SelectionAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_SelectionAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionAdded(EShape_SelectionAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_SelectionAddedDelegate != null && ((eShape_SinkHelper.m_SelectionAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeShapeDelete(EShape_BeforeShapeDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_BeforeShapeDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeDelete(EShape_BeforeShapeDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_BeforeShapeDeleteDelegate != null && ((eShape_SinkHelper.m_BeforeShapeDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_TextChanged(EShape_TextChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_TextChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_TextChanged(EShape_TextChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_TextChangedDelegate != null && ((eShape_SinkHelper.m_TextChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_FormulaChanged(EShape_FormulaChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_FormulaChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_FormulaChanged(EShape_FormulaChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_FormulaChangedDelegate != null && ((eShape_SinkHelper.m_FormulaChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeParentChanged(EShape_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_ShapeParentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeParentChanged(EShape_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_ShapeParentChangedDelegate != null && ((eShape_SinkHelper.m_ShapeParentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeShapeTextEdit(EShape_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_BeforeShapeTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeTextEdit(EShape_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_BeforeShapeTextEditDelegate != null && ((eShape_SinkHelper.m_BeforeShapeTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeExitedTextEdit(EShape_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_ShapeExitedTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeExitedTextEdit(EShape_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_ShapeExitedTextEditDelegate != null && ((eShape_SinkHelper.m_ShapeExitedTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelSelectionDelete(EShape_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_QueryCancelSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSelectionDelete(EShape_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_QueryCancelSelectionDeleteDelegate != null && ((eShape_SinkHelper.m_QueryCancelSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_SelectionDeleteCanceled(EShape_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_SelectionDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionDeleteCanceled(EShape_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_SelectionDeleteCanceledDelegate != null && ((eShape_SinkHelper.m_SelectionDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelUngroup(EShape_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_QueryCancelUngroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelUngroup(EShape_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_QueryCancelUngroupDelegate != null && ((eShape_SinkHelper.m_QueryCancelUngroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_UngroupCanceled(EShape_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_UngroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_UngroupCanceled(EShape_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_UngroupCanceledDelegate != null && ((eShape_SinkHelper.m_UngroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelConvertToGroup(EShape_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_QueryCancelConvertToGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelConvertToGroup(EShape_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_QueryCancelConvertToGroupDelegate != null && ((eShape_SinkHelper.m_QueryCancelConvertToGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ConvertToGroupCanceled(EShape_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_ConvertToGroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConvertToGroupCanceled(EShape_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_ConvertToGroupCanceledDelegate != null && ((eShape_SinkHelper.m_ConvertToGroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelGroup(EShape_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_QueryCancelGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelGroup(EShape_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_QueryCancelGroupDelegate != null && ((eShape_SinkHelper.m_QueryCancelGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_GroupCanceled(EShape_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_GroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_GroupCanceled(EShape_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_GroupCanceledDelegate != null && ((eShape_SinkHelper.m_GroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeDataGraphicChanged(EShape_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_ShapeDataGraphicChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeDataGraphicChanged(EShape_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_ShapeDataGraphicChangedDelegate != null && ((eShape_SinkHelper.m_ShapeDataGraphicChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeLinkAdded(EShape_ShapeLinkAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_ShapeLinkAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkAdded(EShape_ShapeLinkAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_ShapeLinkAddedDelegate != null && ((eShape_SinkHelper.m_ShapeLinkAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeLinkDeleted(EShape_ShapeLinkDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EShape_SinkHelper eShape_SinkHelper = new EShape_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eShape_SinkHelper, out pdwCookie);
			eShape_SinkHelper.m_dwCookie = pdwCookie;
			eShape_SinkHelper.m_ShapeLinkDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eShape_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkDeleted(EShape_ShapeLinkDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
				if (eShape_SinkHelper.m_ShapeLinkDeletedDelegate != null && ((eShape_SinkHelper.m_ShapeLinkDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public EShape_EventProvider(object P_0)
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
					EShape_SinkHelper eShape_SinkHelper = (EShape_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eShape_SinkHelper.m_dwCookie);
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
