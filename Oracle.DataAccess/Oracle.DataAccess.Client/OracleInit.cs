using System;
using System.Reflection;
using System.Security.Permissions;
using System.Threading;

namespace Oracle.DataAccess.Client;

internal class OracleInit
{
	public static bool bSetDllDirectoryInvoked = false;

	private static OperatingSystem os = Environment.OSVersion;

	private static int m_nMajorVer = os.Version.Major;

	private static int m_nMinorVer = os.Version.Minor;

	private static object s_lockObj = new object();

	private static Timer m_timer;

	internal static string m_version;

	internal static string GetAssemblyVersion()
	{
		Assembly assembly = Assembly.GetAssembly(typeof(OracleConnection));
		string fullName = assembly.FullName;
		int num = fullName.IndexOf("Version=") + 8;
		int num2 = fullName.IndexOf(",", num);
		if (num2 > num && num > 0)
		{
			return fullName.Substring(num, num2 - num);
		}
		return null;
	}

	private static void TimerCallbackFunc(object state)
	{
	}

	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	public static void Initialize()
	{
		int num = -1;
		RegAndConfigRdr.ReadEntriesForRegistryAndConfig();
		if ((m_nMajorVer >= 5 && m_nMinorVer > 0) || m_nMajorVer >= 6)
		{
			lock (s_lockObj)
			{
				if (!bSetDllDirectoryInvoked)
				{
					string oraOpsDllPath = OraTrace.m_oraOpsDllPath;
					if (oraOpsDllPath != null && oraOpsDllPath != string.Empty)
					{
						try
						{
							string fileName = oraOpsDllPath + "\\oci.dll";
							num = OpsInit.GetFileAttributes(fileName);
							if (num == -1)
							{
								fileName = oraOpsDllPath + "\\..\\OCI.DLL";
								num = OpsInit.GetFileAttributes(fileName);
								if (num != -1)
								{
									OpsInit.LoadLibrary(fileName);
								}
							}
							num = OpsInit.SetDllDirectory(oraOpsDllPath);
						}
						catch
						{
						}
					}
				}
			}
		}
		m_version = GetAssemblyVersion();
		bSetDllDirectoryInvoked = true;
		try
		{
			num = OpsInit.CheckVersionCompatibility(m_version);
			if (num != 0)
			{
				throw new OracleException(num);
			}
		}
		catch
		{
			throw new OracleException(ErrRes.INIT_DLL_VERSION_MISMATCH);
		}
		OpsTrace.SyncInfo(OraTrace.m_traceFileName, OraTrace.m_checkConStatus, OraTrace.m_dynamicEnlist, OraTrace.m_FetchSize, OraTrace.m_ociEvents, (int)OraTrace.m_PerformanceCounters, OraTrace.m_PSPE, OraTrace.m_StmtCacheSize, OraTrace.m_StmtCacheSize, OraTrace.m_threadPoolMaxSize, OraTrace.m_TraceLevel, OraTrace.m_TraceOption, OraTrace.m_udtCacheSize, OraTrace.m_fetchArrayPooling);
		RegAndConfigRdr.TraceRegistryAndConfigValues();
		string text = " (%s) (ThreadPoolMaxSize : %s [Original: %s; Set: %s; Post-Set: %s])\n";
		string text2 = "";
		text2 = ((!RegAndConfigRdr.s_bFromConfigThreadPoolMaxSize) ? "REGISTRY" : "CONFIG");
		uint MaxWorkerThreads = 0u;
		uint MaxIOCompletionThreads = 0u;
		CThreadPool.GetMaxThreads(out MaxWorkerThreads, out MaxIOCompletionThreads);
		if (OraTrace.m_threadPoolMaxSize > 0 && OraTrace.m_threadPoolMaxSize != MaxWorkerThreads)
		{
			CThreadPool.SetMaxThreads((uint)OraTrace.m_threadPoolMaxSize, MaxIOCompletionThreads);
		}
		uint MaxWorkerThreads2 = 0u;
		CThreadPool.GetMaxThreads(out MaxWorkerThreads2, out MaxIOCompletionThreads);
		OraTrace.Trace(1u, text, text2, OraTrace.m_threadPoolMaxSize.ToString(), MaxWorkerThreads.ToString(), OraTrace.m_threadPoolMaxSize.ToString(), MaxWorkerThreads2.ToString());
		try
		{
			TimerCallback callback = TimerCallbackFunc;
			uint num2 = 147766294u;
			m_timer = new Timer(callback, null, num2, num2);
		}
		catch
		{
		}
	}
}
