using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Microsoft.Office.Interop.Visio;

internal sealed class EApplication_EventProvider : EApplication_Event, IDisposable
{
	private IConnectionPointContainer m_ConnectionPointContainer;

	private ArrayList m_aEventSinkHelpers;

	private IConnectionPoint m_ConnectionPoint;

	private void Init()
	{
		IConnectionPoint ppCP = null;
		Guid riid = new Guid(new byte[16]
		{
			0, 11, 13, 0, 0, 0, 0, 0, 192, 0,
			0, 0, 0, 0, 0, 70
		});
		m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
		m_ConnectionPoint = ppCP;
		m_aEventSinkHelpers = new ArrayList();
	}

	public void add_PageDeleteCanceled(EApplication_PageDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_PageDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageDeleteCanceled(EApplication_PageDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_PageDeleteCanceledDelegate != null && ((eApplication_SinkHelper.m_PageDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeParentChanged(EApplication_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ShapeParentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeParentChanged(EApplication_ShapeParentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ShapeParentChangedDelegate != null && ((eApplication_SinkHelper.m_ShapeParentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeShapeTextEdit(EApplication_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeShapeTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeTextEdit(EApplication_BeforeShapeTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeShapeTextEditDelegate != null && ((eApplication_SinkHelper.m_BeforeShapeTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeExitedTextEdit(EApplication_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ShapeExitedTextEditDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeExitedTextEdit(EApplication_ShapeExitedTextEditEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ShapeExitedTextEditDelegate != null && ((eApplication_SinkHelper.m_ShapeExitedTextEditDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelSelectionDelete(EApplication_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSelectionDelete(EApplication_QueryCancelSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelSelectionDeleteDelegate != null && ((eApplication_SinkHelper.m_QueryCancelSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_SelectionDeleteCanceled(EApplication_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_SelectionDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionDeleteCanceled(EApplication_SelectionDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_SelectionDeleteCanceledDelegate != null && ((eApplication_SinkHelper.m_SelectionDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelUngroup(EApplication_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelUngroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelUngroup(EApplication_QueryCancelUngroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelUngroupDelegate != null && ((eApplication_SinkHelper.m_QueryCancelUngroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_UngroupCanceled(EApplication_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_UngroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_UngroupCanceled(EApplication_UngroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_UngroupCanceledDelegate != null && ((eApplication_SinkHelper.m_UngroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelConvertToGroup(EApplication_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelConvertToGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelConvertToGroup(EApplication_QueryCancelConvertToGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelConvertToGroupDelegate != null && ((eApplication_SinkHelper.m_QueryCancelConvertToGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ConvertToGroupCanceled(EApplication_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ConvertToGroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConvertToGroupCanceled(EApplication_ConvertToGroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ConvertToGroupCanceledDelegate != null && ((eApplication_SinkHelper.m_ConvertToGroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelSuspend(EApplication_QueryCancelSuspendEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelSuspendDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSuspend(EApplication_QueryCancelSuspendEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelSuspendDelegate != null && ((eApplication_SinkHelper.m_QueryCancelSuspendDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_SuspendCanceled(EApplication_SuspendCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_SuspendCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SuspendCanceled(EApplication_SuspendCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_SuspendCanceledDelegate != null && ((eApplication_SinkHelper.m_SuspendCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeSuspend(EApplication_BeforeSuspendEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeSuspendDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSuspend(EApplication_BeforeSuspendEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeSuspendDelegate != null && ((eApplication_SinkHelper.m_BeforeSuspendDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_AfterResume(EApplication_AfterResumeEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_AfterResumeDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterResume(EApplication_AfterResumeEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_AfterResumeDelegate != null && ((eApplication_SinkHelper.m_AfterResumeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_OnKeystrokeMessageForAddon(EApplication_OnKeystrokeMessageForAddonEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_OnKeystrokeMessageForAddonDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_OnKeystrokeMessageForAddon(EApplication_OnKeystrokeMessageForAddonEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_OnKeystrokeMessageForAddonDelegate != null && ((eApplication_SinkHelper.m_OnKeystrokeMessageForAddonDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MouseDown(EApplication_MouseDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_MouseDownDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MouseDown(EApplication_MouseDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_MouseDownDelegate != null && ((eApplication_SinkHelper.m_MouseDownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MouseMove(EApplication_MouseMoveEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_MouseMoveDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MouseMove(EApplication_MouseMoveEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_MouseMoveDelegate != null && ((eApplication_SinkHelper.m_MouseMoveDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MouseUp(EApplication_MouseUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_MouseUpDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MouseUp(EApplication_MouseUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_MouseUpDelegate != null && ((eApplication_SinkHelper.m_MouseUpDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_KeyDown(EApplication_KeyDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_KeyDownDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_KeyDown(EApplication_KeyDownEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_KeyDownDelegate != null && ((eApplication_SinkHelper.m_KeyDownDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_KeyPress(EApplication_KeyPressEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_KeyPressDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_KeyPress(EApplication_KeyPressEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_KeyPressDelegate != null && ((eApplication_SinkHelper.m_KeyPressDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_KeyUp(EApplication_KeyUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_KeyUpDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_KeyUp(EApplication_KeyUpEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_KeyUpDelegate != null && ((eApplication_SinkHelper.m_KeyUpDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelSuspendEvents(EApplication_QueryCancelSuspendEventsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelSuspendEventsDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelSuspendEvents(EApplication_QueryCancelSuspendEventsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelSuspendEventsDelegate != null && ((eApplication_SinkHelper.m_QueryCancelSuspendEventsDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_SuspendEventsCanceled(EApplication_SuspendEventsCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_SuspendEventsCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SuspendEventsCanceled(EApplication_SuspendEventsCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_SuspendEventsCanceledDelegate != null && ((eApplication_SinkHelper.m_SuspendEventsCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeSuspendEvents(EApplication_BeforeSuspendEventsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeSuspendEventsDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSuspendEvents(EApplication_BeforeSuspendEventsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeSuspendEventsDelegate != null && ((eApplication_SinkHelper.m_BeforeSuspendEventsDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_AfterResumeEvents(EApplication_AfterResumeEventsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_AfterResumeEventsDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterResumeEvents(EApplication_AfterResumeEventsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_AfterResumeEventsDelegate != null && ((eApplication_SinkHelper.m_AfterResumeEventsDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelGroup(EApplication_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelGroupDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelGroup(EApplication_QueryCancelGroupEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelGroupDelegate != null && ((eApplication_SinkHelper.m_QueryCancelGroupDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_GroupCanceled(EApplication_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_GroupCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_GroupCanceled(EApplication_GroupCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_GroupCanceledDelegate != null && ((eApplication_SinkHelper.m_GroupCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeDataGraphicChanged(EApplication_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ShapeDataGraphicChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeDataGraphicChanged(EApplication_ShapeDataGraphicChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ShapeDataGraphicChangedDelegate != null && ((eApplication_SinkHelper.m_ShapeDataGraphicChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeDataRecordsetDelete(EApplication_BeforeDataRecordsetDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeDataRecordsetDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDataRecordsetDelete(EApplication_BeforeDataRecordsetDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeDataRecordsetDeleteDelegate != null && ((eApplication_SinkHelper.m_BeforeDataRecordsetDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_DataRecordsetChanged(EApplication_DataRecordsetChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_DataRecordsetChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DataRecordsetChanged(EApplication_DataRecordsetChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_DataRecordsetChangedDelegate != null && ((eApplication_SinkHelper.m_DataRecordsetChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_DataRecordsetAdded(EApplication_DataRecordsetAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_DataRecordsetAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DataRecordsetAdded(EApplication_DataRecordsetAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_DataRecordsetAddedDelegate != null && ((eApplication_SinkHelper.m_DataRecordsetAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeLinkAdded(EApplication_ShapeLinkAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ShapeLinkAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkAdded(EApplication_ShapeLinkAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ShapeLinkAddedDelegate != null && ((eApplication_SinkHelper.m_ShapeLinkAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeLinkDeleted(EApplication_ShapeLinkDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ShapeLinkDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeLinkDeleted(EApplication_ShapeLinkDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ShapeLinkDeletedDelegate != null && ((eApplication_SinkHelper.m_ShapeLinkDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_AfterRemoveHiddenInformation(EApplication_AfterRemoveHiddenInformationEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_AfterRemoveHiddenInformationDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterRemoveHiddenInformation(EApplication_AfterRemoveHiddenInformationEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_AfterRemoveHiddenInformationDelegate != null && ((eApplication_SinkHelper.m_AfterRemoveHiddenInformationDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ContainerRelationshipAdded(EApplication_ContainerRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ContainerRelationshipAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ContainerRelationshipAdded(EApplication_ContainerRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ContainerRelationshipAddedDelegate != null && ((eApplication_SinkHelper.m_ContainerRelationshipAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ContainerRelationshipDeleted(EApplication_ContainerRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ContainerRelationshipDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ContainerRelationshipDeleted(EApplication_ContainerRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ContainerRelationshipDeletedDelegate != null && ((eApplication_SinkHelper.m_ContainerRelationshipDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_CalloutRelationshipAdded(EApplication_CalloutRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_CalloutRelationshipAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CalloutRelationshipAdded(EApplication_CalloutRelationshipAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_CalloutRelationshipAddedDelegate != null && ((eApplication_SinkHelper.m_CalloutRelationshipAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_CalloutRelationshipDeleted(EApplication_CalloutRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_CalloutRelationshipDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CalloutRelationshipDeleted(EApplication_CalloutRelationshipDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_CalloutRelationshipDeletedDelegate != null && ((eApplication_SinkHelper.m_CalloutRelationshipDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_RuleSetValidated(EApplication_RuleSetValidatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_RuleSetValidatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_RuleSetValidated(EApplication_RuleSetValidatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_RuleSetValidatedDelegate != null && ((eApplication_SinkHelper.m_RuleSetValidatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelReplaceShapes(EApplication_QueryCancelReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelReplaceShapes(EApplication_QueryCancelReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelReplaceShapesDelegate != null && ((eApplication_SinkHelper.m_QueryCancelReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ReplaceShapesCanceled(EApplication_ReplaceShapesCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ReplaceShapesCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ReplaceShapesCanceled(EApplication_ReplaceShapesCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ReplaceShapesCanceledDelegate != null && ((eApplication_SinkHelper.m_ReplaceShapesCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeReplaceShapes(EApplication_BeforeReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeReplaceShapes(EApplication_BeforeReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeReplaceShapesDelegate != null && ((eApplication_SinkHelper.m_BeforeReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_AfterReplaceShapes(EApplication_AfterReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_AfterReplaceShapesDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterReplaceShapes(EApplication_AfterReplaceShapesEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_AfterReplaceShapesDelegate != null && ((eApplication_SinkHelper.m_AfterReplaceShapesDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_AppActivated(EApplication_AppActivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_AppActivatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AppActivated(EApplication_AppActivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_AppActivatedDelegate != null && ((eApplication_SinkHelper.m_AppActivatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_AppDeactivated(EApplication_AppDeactivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_AppDeactivatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AppDeactivated(EApplication_AppDeactivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_AppDeactivatedDelegate != null && ((eApplication_SinkHelper.m_AppDeactivatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_AppObjActivated(EApplication_AppObjActivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_AppObjActivatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AppObjActivated(EApplication_AppObjActivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_AppObjActivatedDelegate != null && ((eApplication_SinkHelper.m_AppObjActivatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_AppObjDeactivated(EApplication_AppObjDeactivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_AppObjDeactivatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AppObjDeactivated(EApplication_AppObjDeactivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_AppObjDeactivatedDelegate != null && ((eApplication_SinkHelper.m_AppObjDeactivatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeQuit(EApplication_BeforeQuitEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeQuitDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeQuit(EApplication_BeforeQuitEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeQuitDelegate != null && ((eApplication_SinkHelper.m_BeforeQuitDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeModal(EApplication_BeforeModalEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeModalDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeModal(EApplication_BeforeModalEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeModalDelegate != null && ((eApplication_SinkHelper.m_BeforeModalDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_AfterModal(EApplication_AfterModalEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_AfterModalDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_AfterModal(EApplication_AfterModalEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_AfterModalDelegate != null && ((eApplication_SinkHelper.m_AfterModalDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_WindowOpened(EApplication_WindowOpenedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_WindowOpenedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowOpened(EApplication_WindowOpenedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_WindowOpenedDelegate != null && ((eApplication_SinkHelper.m_WindowOpenedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_SelectionChanged(EApplication_SelectionChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_SelectionChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionChanged(EApplication_SelectionChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_SelectionChangedDelegate != null && ((eApplication_SinkHelper.m_SelectionChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeWindowClosed(EApplication_BeforeWindowClosedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeWindowClosedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeWindowClosed(EApplication_BeforeWindowClosedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeWindowClosedDelegate != null && ((eApplication_SinkHelper.m_BeforeWindowClosedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_WindowActivated(EApplication_WindowActivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_WindowActivatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowActivated(EApplication_WindowActivatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_WindowActivatedDelegate != null && ((eApplication_SinkHelper.m_WindowActivatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeWindowSelDelete(EApplication_BeforeWindowSelDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeWindowSelDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeWindowSelDelete(EApplication_BeforeWindowSelDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeWindowSelDeleteDelegate != null && ((eApplication_SinkHelper.m_BeforeWindowSelDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeWindowPageTurn(EApplication_BeforeWindowPageTurnEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeWindowPageTurnDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeWindowPageTurn(EApplication_BeforeWindowPageTurnEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeWindowPageTurnDelegate != null && ((eApplication_SinkHelper.m_BeforeWindowPageTurnDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_WindowTurnedToPage(EApplication_WindowTurnedToPageEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_WindowTurnedToPageDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowTurnedToPage(EApplication_WindowTurnedToPageEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_WindowTurnedToPageDelegate != null && ((eApplication_SinkHelper.m_WindowTurnedToPageDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_DocumentOpened(EApplication_DocumentOpenedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_DocumentOpenedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentOpened(EApplication_DocumentOpenedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_DocumentOpenedDelegate != null && ((eApplication_SinkHelper.m_DocumentOpenedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_DocumentCreated(EApplication_DocumentCreatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_DocumentCreatedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentCreated(EApplication_DocumentCreatedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_DocumentCreatedDelegate != null && ((eApplication_SinkHelper.m_DocumentCreatedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_DocumentSaved(EApplication_DocumentSavedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_DocumentSavedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentSaved(EApplication_DocumentSavedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_DocumentSavedDelegate != null && ((eApplication_SinkHelper.m_DocumentSavedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_DocumentSavedAs(EApplication_DocumentSavedAsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_DocumentSavedAsDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentSavedAs(EApplication_DocumentSavedAsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_DocumentSavedAsDelegate != null && ((eApplication_SinkHelper.m_DocumentSavedAsDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_DocumentChanged(EApplication_DocumentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_DocumentChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentChanged(EApplication_DocumentChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_DocumentChangedDelegate != null && ((eApplication_SinkHelper.m_DocumentChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeDocumentClose(EApplication_BeforeDocumentCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeDocumentCloseDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDocumentClose(EApplication_BeforeDocumentCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeDocumentCloseDelegate != null && ((eApplication_SinkHelper.m_BeforeDocumentCloseDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_StyleAdded(EApplication_StyleAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_StyleAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleAdded(EApplication_StyleAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_StyleAddedDelegate != null && ((eApplication_SinkHelper.m_StyleAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_StyleChanged(EApplication_StyleChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_StyleChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleChanged(EApplication_StyleChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_StyleChangedDelegate != null && ((eApplication_SinkHelper.m_StyleChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeStyleDelete(EApplication_BeforeStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeStyleDelete(EApplication_BeforeStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeStyleDeleteDelegate != null && ((eApplication_SinkHelper.m_BeforeStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MasterAdded(EApplication_MasterAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_MasterAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterAdded(EApplication_MasterAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_MasterAddedDelegate != null && ((eApplication_SinkHelper.m_MasterAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MasterChanged(EApplication_MasterChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_MasterChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterChanged(EApplication_MasterChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_MasterChangedDelegate != null && ((eApplication_SinkHelper.m_MasterChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeMasterDelete(EApplication_BeforeMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeMasterDelete(EApplication_BeforeMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeMasterDeleteDelegate != null && ((eApplication_SinkHelper.m_BeforeMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_PageAdded(EApplication_PageAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_PageAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageAdded(EApplication_PageAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_PageAddedDelegate != null && ((eApplication_SinkHelper.m_PageAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_PageChanged(EApplication_PageChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_PageChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_PageChanged(EApplication_PageChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_PageChangedDelegate != null && ((eApplication_SinkHelper.m_PageChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforePageDelete(EApplication_BeforePageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforePageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforePageDelete(EApplication_BeforePageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforePageDeleteDelegate != null && ((eApplication_SinkHelper.m_BeforePageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeAdded(EApplication_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ShapeAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeAdded(EApplication_ShapeAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ShapeAddedDelegate != null && ((eApplication_SinkHelper.m_ShapeAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeSelectionDelete(EApplication_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeSelectionDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeSelectionDelete(EApplication_BeforeSelectionDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeSelectionDeleteDelegate != null && ((eApplication_SinkHelper.m_BeforeSelectionDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ShapeChanged(EApplication_ShapeChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ShapeChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ShapeChanged(EApplication_ShapeChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ShapeChangedDelegate != null && ((eApplication_SinkHelper.m_ShapeChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_SelectionAdded(EApplication_SelectionAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_SelectionAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_SelectionAdded(EApplication_SelectionAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_SelectionAddedDelegate != null && ((eApplication_SinkHelper.m_SelectionAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeShapeDelete(EApplication_BeforeShapeDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeShapeDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeShapeDelete(EApplication_BeforeShapeDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeShapeDeleteDelegate != null && ((eApplication_SinkHelper.m_BeforeShapeDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_TextChanged(EApplication_TextChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_TextChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_TextChanged(EApplication_TextChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_TextChangedDelegate != null && ((eApplication_SinkHelper.m_TextChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_CellChanged(EApplication_CellChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_CellChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_CellChanged(EApplication_CellChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_CellChangedDelegate != null && ((eApplication_SinkHelper.m_CellChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MarkerEvent(EApplication_MarkerEventEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_MarkerEventDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MarkerEvent(EApplication_MarkerEventEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_MarkerEventDelegate != null && ((eApplication_SinkHelper.m_MarkerEventDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_NoEventsPending(EApplication_NoEventsPendingEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_NoEventsPendingDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_NoEventsPending(EApplication_NoEventsPendingEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_NoEventsPendingDelegate != null && ((eApplication_SinkHelper.m_NoEventsPendingDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_VisioIsIdle(EApplication_VisioIsIdleEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_VisioIsIdleDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_VisioIsIdle(EApplication_VisioIsIdleEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_VisioIsIdleDelegate != null && ((eApplication_SinkHelper.m_VisioIsIdleDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MustFlushScopeBeginning(EApplication_MustFlushScopeBeginningEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_MustFlushScopeBeginningDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MustFlushScopeBeginning(EApplication_MustFlushScopeBeginningEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_MustFlushScopeBeginningDelegate != null && ((eApplication_SinkHelper.m_MustFlushScopeBeginningDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MustFlushScopeEnded(EApplication_MustFlushScopeEndedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_MustFlushScopeEndedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MustFlushScopeEnded(EApplication_MustFlushScopeEndedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_MustFlushScopeEndedDelegate != null && ((eApplication_SinkHelper.m_MustFlushScopeEndedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_RunModeEntered(EApplication_RunModeEnteredEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_RunModeEnteredDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_RunModeEntered(EApplication_RunModeEnteredEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_RunModeEnteredDelegate != null && ((eApplication_SinkHelper.m_RunModeEnteredDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_DesignModeEntered(EApplication_DesignModeEnteredEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_DesignModeEnteredDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DesignModeEntered(EApplication_DesignModeEnteredEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_DesignModeEnteredDelegate != null && ((eApplication_SinkHelper.m_DesignModeEnteredDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeDocumentSave(EApplication_BeforeDocumentSaveEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeDocumentSaveDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDocumentSave(EApplication_BeforeDocumentSaveEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeDocumentSaveDelegate != null && ((eApplication_SinkHelper.m_BeforeDocumentSaveDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_BeforeDocumentSaveAs(EApplication_BeforeDocumentSaveAsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_BeforeDocumentSaveAsDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_BeforeDocumentSaveAs(EApplication_BeforeDocumentSaveAsEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_BeforeDocumentSaveAsDelegate != null && ((eApplication_SinkHelper.m_BeforeDocumentSaveAsDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_FormulaChanged(EApplication_FormulaChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_FormulaChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_FormulaChanged(EApplication_FormulaChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_FormulaChangedDelegate != null && ((eApplication_SinkHelper.m_FormulaChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ConnectionsAdded(EApplication_ConnectionsAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ConnectionsAddedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsAdded(EApplication_ConnectionsAddedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ConnectionsAddedDelegate != null && ((eApplication_SinkHelper.m_ConnectionsAddedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ConnectionsDeleted(EApplication_ConnectionsDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ConnectionsDeletedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ConnectionsDeleted(EApplication_ConnectionsDeletedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ConnectionsDeletedDelegate != null && ((eApplication_SinkHelper.m_ConnectionsDeletedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_EnterScope(EApplication_EnterScopeEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_EnterScopeDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_EnterScope(EApplication_EnterScopeEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_EnterScopeDelegate != null && ((eApplication_SinkHelper.m_EnterScopeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ExitScope(EApplication_ExitScopeEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ExitScopeDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ExitScope(EApplication_ExitScopeEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ExitScopeDelegate != null && ((eApplication_SinkHelper.m_ExitScopeDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelQuit(EApplication_QueryCancelQuitEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelQuitDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelQuit(EApplication_QueryCancelQuitEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelQuitDelegate != null && ((eApplication_SinkHelper.m_QueryCancelQuitDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QuitCanceled(EApplication_QuitCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QuitCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QuitCanceled(EApplication_QuitCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QuitCanceledDelegate != null && ((eApplication_SinkHelper.m_QuitCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_WindowChanged(EApplication_WindowChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_WindowChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowChanged(EApplication_WindowChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_WindowChangedDelegate != null && ((eApplication_SinkHelper.m_WindowChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_ViewChanged(EApplication_ViewChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_ViewChangedDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_ViewChanged(EApplication_ViewChangedEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_ViewChangedDelegate != null && ((eApplication_SinkHelper.m_ViewChangedDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelWindowClose(EApplication_QueryCancelWindowCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelWindowCloseDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelWindowClose(EApplication_QueryCancelWindowCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelWindowCloseDelegate != null && ((eApplication_SinkHelper.m_QueryCancelWindowCloseDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_WindowCloseCanceled(EApplication_WindowCloseCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_WindowCloseCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_WindowCloseCanceled(EApplication_WindowCloseCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_WindowCloseCanceledDelegate != null && ((eApplication_SinkHelper.m_WindowCloseCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelDocumentClose(EApplication_QueryCancelDocumentCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelDocumentCloseDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelDocumentClose(EApplication_QueryCancelDocumentCloseEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelDocumentCloseDelegate != null && ((eApplication_SinkHelper.m_QueryCancelDocumentCloseDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_DocumentCloseCanceled(EApplication_DocumentCloseCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_DocumentCloseCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_DocumentCloseCanceled(EApplication_DocumentCloseCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_DocumentCloseCanceledDelegate != null && ((eApplication_SinkHelper.m_DocumentCloseCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelStyleDelete(EApplication_QueryCancelStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelStyleDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelStyleDelete(EApplication_QueryCancelStyleDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelStyleDeleteDelegate != null && ((eApplication_SinkHelper.m_QueryCancelStyleDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_StyleDeleteCanceled(EApplication_StyleDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_StyleDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_StyleDeleteCanceled(EApplication_StyleDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_StyleDeleteCanceledDelegate != null && ((eApplication_SinkHelper.m_StyleDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelMasterDelete(EApplication_QueryCancelMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelMasterDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelMasterDelete(EApplication_QueryCancelMasterDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelMasterDeleteDelegate != null && ((eApplication_SinkHelper.m_QueryCancelMasterDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_MasterDeleteCanceled(EApplication_MasterDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_MasterDeleteCanceledDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_MasterDeleteCanceled(EApplication_MasterDeleteCanceledEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_MasterDeleteCanceledDelegate != null && ((eApplication_SinkHelper.m_MasterDeleteCanceledDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void add_QueryCancelPageDelete(EApplication_QueryCancelPageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_ConnectionPoint == null)
			{
				Init();
			}
			EApplication_SinkHelper eApplication_SinkHelper = new EApplication_SinkHelper();
			int pdwCookie = 0;
			m_ConnectionPoint.Advise(eApplication_SinkHelper, out pdwCookie);
			eApplication_SinkHelper.m_dwCookie = pdwCookie;
			eApplication_SinkHelper.m_QueryCancelPageDeleteDelegate = P_0;
			m_aEventSinkHelpers.Add(eApplication_SinkHelper);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public void remove_QueryCancelPageDelete(EApplication_QueryCancelPageDeleteEventHandler P_0)
	{
		Monitor.Enter(this);
		try
		{
			if (m_aEventSinkHelpers == null)
			{
				return;
			}
			int count = m_aEventSinkHelpers.Count;
			int num = 0;
			if (0 >= count)
			{
				return;
			}
			do
			{
				EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
				if (eApplication_SinkHelper.m_QueryCancelPageDeleteDelegate != null && ((eApplication_SinkHelper.m_QueryCancelPageDeleteDelegate.Equals(P_0) ? 1u : 0u) & 0xFFu) != 0)
				{
					m_aEventSinkHelpers.RemoveAt(num);
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(m_ConnectionPoint);
						m_ConnectionPoint = null;
						m_aEventSinkHelpers = null;
					}
					break;
				}
				num++;
			}
			while (num < count);
		}
		finally
		{
			Monitor.Exit(this);
		}
	}

	public EApplication_EventProvider(object P_0)
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
					EApplication_SinkHelper eApplication_SinkHelper = (EApplication_SinkHelper)m_aEventSinkHelpers[num];
					m_ConnectionPoint.Unadvise(eApplication_SinkHelper.m_dwCookie);
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
