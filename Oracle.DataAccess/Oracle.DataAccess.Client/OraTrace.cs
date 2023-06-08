using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;

namespace Oracle.DataAccess.Client;

internal class OraTrace
{
	internal const int DEFAULT_STMT_CACHE_SIZE = 0;

	internal const uint LEVEL_NONE = 0u;

	internal const uint LEVEL_ENTRY = 1u;

	internal const uint LEVEL_EXIT = 1u;

	internal const uint LEVEL_SQL = 1u;

	internal const uint LEVEL_CONPOOL = 2u;

	internal const uint LEVEL_MTS = 4u;

	internal const uint LEVEL_MINIDUMP = 8u;

	internal const uint LEVEL_GRID_CR = 16u;

	internal const uint LEVEL_GRID_RLB = 32u;

	internal const uint LEVEL_TUNING = 64u;

	internal static bool m_RegistryRead;

	internal static string m_oraOpsDllPath = string.Empty;

	internal static uint m_TraceLevel = 0u;

	internal static uint m_TraceOption = 0u;

	internal static uint m_udtCacheSize = 4096u;

	internal static int m_StmtCacheSize = 0;

	internal static uint m_checkConStatus = 1u;

	internal static uint m_dynamicEnlist = 0u;

	internal static int m_FetchSize = 131072;

	internal static int m_ociEvents = 0;

	internal static int m_stmtCacheWithUdts = 1;

	internal static int m_PSPE = 1;

	internal static int m_MetadataPooling = 1;

	internal static int m_DBNotificationPort = -1;

	internal static PerfCounterLevel m_PerformanceCounters;

	internal static int m_threadPoolMaxSize = -1;

	internal static int m_DBNotificationRegInterval = 0;

	internal static int m_demandOrclPermission = 0;

	internal static string m_traceFileName = "";

	internal static int m_CPThreadPrioritization = 1;

	internal static int m_InitialLOBFetchSize = -1;

	internal static int m_InitialLONGFetchSize = -1;

	internal static bool m_selfTuning = true;

	internal static int m_maxStatementCacheSize = 100;

	private static object m_maxStatementCacheSizeLock = new object();

	internal static string m_appEdition = "";

	internal static string m_MetaDataXml = null;

	internal static int m_RevertBUErrHandling = 0;

	internal static int m_fetchArrayPooling = 1;

	internal static bool m_configSectionRead;

	internal static object m_regReadSync = new object();

	internal static int MaxStatementCacheSize => m_maxStatementCacheSize;

	internal OraTrace()
	{
	}

	internal static void SetMaxStatementCacheSize(int newMaxStatementCacheSize)
	{
		if (newMaxStatementCacheSize >= m_maxStatementCacheSize)
		{
			return;
		}
		lock (m_maxStatementCacheSizeLock)
		{
			if (newMaxStatementCacheSize < m_maxStatementCacheSize)
			{
				if (m_TraceLevel != 0)
				{
					Trace(64u, " (TUNING) OraTrace::SetMaxStatementCacheSize(): Max Statement Cache Size changed from " + m_maxStatementCacheSize + " to " + newMaxStatementCacheSize + "\n");
				}
				m_maxStatementCacheSize = newMaxStatementCacheSize;
			}
		}
	}

	internal static void Trace(uint TraceLevel, params string[] args)
	{
		if ((TraceLevel & m_TraceLevel) == TraceLevel)
		{
			try
			{
				OpsTrace.Trace(TraceLevel, args);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

	internal static void TraceExceptionInfo(Exception ex)
	{
		TraceExceptionInfo(ex, bCreateMiniDump: true);
	}

	[SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
	internal static void TraceExceptionInfo(Exception ex, bool bCreateMiniDump)
	{
		if (ex is ThreadAbortException)
		{
			bCreateMiniDump = false;
		}
		int lastErrorCode = 0;
		int num = 0;
		if (bCreateMiniDump)
		{
			try
			{
				OpsTrace.GetLastErrorCode(out lastErrorCode);
			}
			catch (Exception ex2)
			{
				Trace(1u, " (ERROR) GetLastErrorCode: " + ex2.GetType().ToString() + ": " + ex2.ToString() + "\n");
			}
			try
			{
				num = Marshal.GetExceptionCode();
			}
			catch (Exception ex3)
			{
				Trace(1u, " (ERROR) Marshal.GetExceptionCode: " + ex3.GetType().ToString() + ": " + ex3.ToString() + "\n");
			}
			MiniDumpInfo miniDumpInfo = new MiniDumpInfo();
			miniDumpInfo.threadId = AppDomain.GetCurrentThreadId();
			miniDumpInfo.pExPtrs = Marshal.GetExceptionPointers();
			ThreadPool.QueueUserWorkItem(CreateMiniDump, miniDumpInfo);
			miniDumpInfo.evt.WaitOne();
			Trace(1u, " (EXCPT) Lvl0: (Type=" + ex.GetType().ToString() + ") (Msg=" + ex.Message + ") (Win32Err=" + lastErrorCode + ") (Code=" + num.ToString("x") + ") (Stack=" + ex.StackTrace + ")\n");
		}
		else
		{
			Trace(1u, " (EXCPT) Lvl0: (Type=" + ex.GetType().ToString() + ") (Msg=" + ex.Message + ") (Stack=" + ex.StackTrace + ")\n");
		}
		Exception innerException = ex.InnerException;
		int num2 = 1;
		while (innerException != null && num2 <= 9)
		{
			if (bCreateMiniDump)
			{
				Trace(1u, " (EXCPT) Lvl" + num2 + ": (Type=" + ex.GetType().ToString() + ") (Msg=" + ex.Message + ") (Win32Err=" + lastErrorCode + ") (Code=" + num.ToString("x") + ") (Stack=" + ex.StackTrace + ")\n");
			}
			else
			{
				Trace(1u, " (EXCPT) Lvl" + num2 + ": (Type=" + ex.GetType().ToString() + ") (Msg=" + ex.Message + ") (Stack=" + ex.StackTrace + ")\n");
			}
			innerException = innerException.InnerException;
			num2++;
		}
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	internal static void CreateMiniDump(object state)
	{
		MiniDumpInfo miniDumpInfo = (MiniDumpInfo)state;
		try
		{
			OpsTrace.CreateMiniDump(miniDumpInfo.threadId, miniDumpInfo.pExPtrs);
		}
		catch (Exception ex)
		{
			Trace(1u, " (ERROR) CreateMiniDump: " + ex.GetType().ToString() + ": " + ex.Message + "\n");
		}
		miniDumpInfo.evt.Set();
	}
}
