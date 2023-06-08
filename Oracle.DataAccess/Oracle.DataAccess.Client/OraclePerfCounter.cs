using System;
using System.Diagnostics;
using System.Security.Permissions;

namespace Oracle.DataAccess.Client;

internal sealed class OraclePerfCounter : IDisposable
{
	private PerformanceCounter m_counter;

	private CounterCreationData m_counterCreationData;

	internal CounterCreationData CreationData => m_counterCreationData;

	internal long CurrentValue
	{
		get
		{
			if (m_counter == null)
			{
				return -1L;
			}
			return m_counter.RawValue;
		}
	}

	public void Dispose()
	{
		if (m_counter != null)
		{
			m_counter.RemoveInstance();
			m_counter.Dispose();
			m_counter = null;
		}
	}

	[PerformanceCounterPermission(SecurityAction.Assert, Unrestricted = true)]
	internal OraclePerfCounter(string categoryName, string counterName, string counterHelp, PerformanceCounterType countertype, string instanceName)
	{
		try
		{
			m_counter = new PerformanceCounter(categoryName, counterName, instanceName, readOnly: false);
		}
		catch (Exception ex)
		{
			m_counter = null;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) OraclePerfCounter::OraclePerfCounter() -" + ex.Message + "\n");
			}
		}
		try
		{
			m_counterCreationData = new CounterCreationData(counterName, counterHelp, countertype);
		}
		catch (Exception ex2)
		{
			m_counterCreationData = null;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) OraclePerfCounter::OraclePerfCounter() CreationData -" + ex2.Message + "\n");
			}
		}
	}

	internal long Increment()
	{
		try
		{
			return (m_counter != null) ? m_counter.Increment() : (-1);
		}
		catch
		{
			m_counter = null;
			return -1L;
		}
	}

	internal long Decrement()
	{
		try
		{
			return (m_counter != null) ? m_counter.Decrement() : (-1);
		}
		catch
		{
			m_counter = null;
			return -1L;
		}
	}

	internal long IncrementBy(int val)
	{
		try
		{
			return (m_counter != null) ? m_counter.IncrementBy(val) : (-1);
		}
		catch
		{
			m_counter = null;
			return -1L;
		}
	}
}
