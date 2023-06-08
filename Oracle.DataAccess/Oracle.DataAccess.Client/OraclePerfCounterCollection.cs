using System;
using System.Diagnostics;
using System.Security.Permissions;

namespace Oracle.DataAccess.Client;

internal sealed class OraclePerfCounterCollection
{
	private const string m_categoryName = "Oracle Data Provider for .NET";

	private static string m_categoryHelp;

	internal static readonly OraclePerfCounter HardConnectsPerSecond;

	internal static readonly OraclePerfCounter HardDisconnectsPerSecond;

	internal static readonly OraclePerfCounter SoftConnectsPerSecond;

	internal static readonly OraclePerfCounter SoftDisconnectsPerSecond;

	internal static readonly OraclePerfCounter NumberOfActiveConnectionPools;

	internal static readonly OraclePerfCounter NumberOfActiveConnections;

	internal static readonly OraclePerfCounter NumberOfFreeConnections;

	internal static readonly OraclePerfCounter NumberOfInactiveConnectionPools;

	internal static readonly OraclePerfCounter NumberOfNonPooledConnections;

	internal static readonly OraclePerfCounter NumberOfPooledConnections;

	internal static readonly OraclePerfCounter NumberOfReclaimedConnections;

	internal static readonly OraclePerfCounter NumberOfStasisConnections;

	private static void CleanUp()
	{
		HardConnectsPerSecond.Dispose();
		HardDisconnectsPerSecond.Dispose();
		SoftConnectsPerSecond.Dispose();
		SoftDisconnectsPerSecond.Dispose();
		NumberOfActiveConnectionPools.Dispose();
		NumberOfActiveConnections.Dispose();
		NumberOfFreeConnections.Dispose();
		NumberOfInactiveConnectionPools.Dispose();
		NumberOfNonPooledConnections.Dispose();
		NumberOfPooledConnections.Dispose();
		NumberOfReclaimedConnections.Dispose();
		NumberOfStasisConnections.Dispose();
	}

	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	static OraclePerfCounterCollection()
	{
		string text = string.Empty;
		try
		{
			if (AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				AppDomain.CurrentDomain.ProcessExit += DomainUnloadOrProcessExit;
			}
			else
			{
				AppDomain.CurrentDomain.DomainUnload += DomainUnloadOrProcessExit;
			}
			text = AppDomain.CurrentDomain.FriendlyName + " [" + Process.GetCurrentProcess().Id + ", " + AppDomain.CurrentDomain.Id + "]";
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) OraclePerfCounterCollection::OraclePerfCounterCollection() - " + ex.Message + "\n");
			}
		}
		text = text.Replace('/', '_');
		try
		{
			m_categoryHelp = OpoErrResManager.GetErrorMesg(-2801);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) OraclePerfCounterCollection::OraclePerfCounterCollection() categoryHelp - " + ex2.Message + "\n");
			}
		}
		HardConnectsPerSecond = new OraclePerfCounter("Oracle Data Provider for .NET", "HardConnectsPerSecond", OpoErrResManager.GetErrorMesg(-2802), PerformanceCounterType.RateOfCountsPerSecond64, text);
		HardDisconnectsPerSecond = new OraclePerfCounter("Oracle Data Provider for .NET", "HardDisconnectsPerSecond", OpoErrResManager.GetErrorMesg(-2803), PerformanceCounterType.RateOfCountsPerSecond64, text);
		SoftConnectsPerSecond = new OraclePerfCounter("Oracle Data Provider for .NET", "SoftConnectsPerSecond", OpoErrResManager.GetErrorMesg(-2804), PerformanceCounterType.RateOfCountsPerSecond64, text);
		SoftDisconnectsPerSecond = new OraclePerfCounter("Oracle Data Provider for .NET", "SoftDisconnectsPerSecond", OpoErrResManager.GetErrorMesg(-2805), PerformanceCounterType.RateOfCountsPerSecond64, text);
		NumberOfActiveConnectionPools = new OraclePerfCounter("Oracle Data Provider for .NET", "NumberOfActiveConnectionPools", OpoErrResManager.GetErrorMesg(-2806), PerformanceCounterType.NumberOfItems64, text);
		NumberOfActiveConnections = new OraclePerfCounter("Oracle Data Provider for .NET", "NumberOfActiveConnections", OpoErrResManager.GetErrorMesg(-2807), PerformanceCounterType.NumberOfItems64, text);
		NumberOfFreeConnections = new OraclePerfCounter("Oracle Data Provider for .NET", "NumberOfFreeConnections", OpoErrResManager.GetErrorMesg(-2808), PerformanceCounterType.NumberOfItems64, text);
		NumberOfInactiveConnectionPools = new OraclePerfCounter("Oracle Data Provider for .NET", "NumberOfInactiveConnectionPools", OpoErrResManager.GetErrorMesg(-2809), PerformanceCounterType.NumberOfItems64, text);
		NumberOfNonPooledConnections = new OraclePerfCounter("Oracle Data Provider for .NET", "NumberOfNonPooledConnections", OpoErrResManager.GetErrorMesg(-2810), PerformanceCounterType.NumberOfItems64, text);
		NumberOfPooledConnections = new OraclePerfCounter("Oracle Data Provider for .NET", "NumberOfPooledConnections", OpoErrResManager.GetErrorMesg(-2811), PerformanceCounterType.NumberOfItems64, text);
		NumberOfReclaimedConnections = new OraclePerfCounter("Oracle Data Provider for .NET", "NumberOfReclaimedConnections", OpoErrResManager.GetErrorMesg(-2812), PerformanceCounterType.NumberOfItems64, text);
		NumberOfStasisConnections = new OraclePerfCounter("Oracle Data Provider for .NET", "NumberOfStasisConnections", OpoErrResManager.GetErrorMesg(-2813), PerformanceCounterType.NumberOfItems64, text);
	}

	private static void DomainUnloadOrProcessExit(object sender, EventArgs e)
	{
		CleanUp();
	}

	private static bool CreateCounters(string[] args)
	{
		DeleteCounters(args);
		try
		{
			CounterCreationDataCollection counterCreationDataCollection = new CounterCreationDataCollection();
			if (HardConnectsPerSecond.CreationData != null)
			{
				counterCreationDataCollection.Add(HardConnectsPerSecond.CreationData);
			}
			if (HardDisconnectsPerSecond.CreationData != null)
			{
				counterCreationDataCollection.Add(HardDisconnectsPerSecond.CreationData);
			}
			if (SoftConnectsPerSecond.CreationData != null)
			{
				counterCreationDataCollection.Add(SoftConnectsPerSecond.CreationData);
			}
			if (SoftDisconnectsPerSecond.CreationData != null)
			{
				counterCreationDataCollection.Add(SoftDisconnectsPerSecond.CreationData);
			}
			if (NumberOfActiveConnectionPools.CreationData != null)
			{
				counterCreationDataCollection.Add(NumberOfActiveConnectionPools.CreationData);
			}
			if (NumberOfActiveConnections.CreationData != null)
			{
				counterCreationDataCollection.Add(NumberOfActiveConnections.CreationData);
			}
			if (NumberOfFreeConnections.CreationData != null)
			{
				counterCreationDataCollection.Add(NumberOfFreeConnections.CreationData);
			}
			if (NumberOfInactiveConnectionPools.CreationData != null)
			{
				counterCreationDataCollection.Add(NumberOfInactiveConnectionPools.CreationData);
			}
			if (NumberOfNonPooledConnections.CreationData != null)
			{
				counterCreationDataCollection.Add(NumberOfNonPooledConnections.CreationData);
			}
			if (NumberOfPooledConnections.CreationData != null)
			{
				counterCreationDataCollection.Add(NumberOfPooledConnections.CreationData);
			}
			if (NumberOfReclaimedConnections.CreationData != null)
			{
				counterCreationDataCollection.Add(NumberOfReclaimedConnections.CreationData);
			}
			if (NumberOfStasisConnections.CreationData != null)
			{
				counterCreationDataCollection.Add(NumberOfStasisConnections.CreationData);
			}
			PerformanceCounterCategory.Create("Oracle Data Provider for .NET", m_categoryHelp, PerformanceCounterCategoryType.MultiInstance, counterCreationDataCollection);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool DeleteCounters(string[] args)
	{
		try
		{
			PerformanceCounterCategory.Delete("Oracle Data Provider for .NET");
			return true;
		}
		catch (InvalidOperationException)
		{
			return true;
		}
		catch
		{
			return false;
		}
	}
}
