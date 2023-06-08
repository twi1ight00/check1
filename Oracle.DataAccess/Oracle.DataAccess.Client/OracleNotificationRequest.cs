using System;
using System.Collections;

namespace Oracle.DataAccess.Client;

public class OracleNotificationRequest
{
	internal static Hashtable s_idTable;

	internal static bool s_bDefIsNotifiedOnce;

	internal static int s_DefRegTimeout;

	internal static bool s_bDefIsPersistent;

	internal static string s_ChangedNotificationName;

	internal OpoSubscrCtx m_opoSubscrCtx;

	internal string m_id;

	internal string m_service;

	internal bool m_bIsNotifiedOnce;

	internal bool m_bIsPersistent;

	internal long m_timeout;

	internal bool m_bGroupingNotificationEnabled;

	internal OracleAQNotificationGroupingType m_groupingType;

	internal int m_groupingInterval;

	internal string Id => m_id;

	public bool IsNotifiedOnce
	{
		get
		{
			return m_bIsNotifiedOnce;
		}
		set
		{
			m_bIsNotifiedOnce = value;
		}
	}

	public bool IsPersistent
	{
		get
		{
			return m_bIsPersistent;
		}
		set
		{
			m_bIsPersistent = value;
		}
	}

	private string Service => m_service;

	public bool GroupingNotificationEnabled
	{
		get
		{
			return m_bGroupingNotificationEnabled;
		}
		set
		{
			m_bGroupingNotificationEnabled = value;
		}
	}

	public OracleAQNotificationGroupingType GroupingType
	{
		get
		{
			return m_groupingType;
		}
		set
		{
			m_groupingType = value;
		}
	}

	public int GroupingInterval
	{
		get
		{
			return m_groupingInterval;
		}
		set
		{
			m_groupingInterval = value;
		}
	}

	public long Timeout
	{
		get
		{
			return m_timeout;
		}
		set
		{
			if (value < 0 || value > uint.MaxValue)
			{
				throw new ArgumentOutOfRangeException("Timeout");
			}
			m_timeout = value;
		}
	}

	static OracleNotificationRequest()
	{
		s_idTable = Hashtable.Synchronized(new Hashtable());
		s_bDefIsNotifiedOnce = true;
		s_DefRegTimeout = 50000;
		s_bDefIsPersistent = false;
		s_ChangedNotificationName = "OracleDatabaseChangedNotificationService";
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleNotificationRequest(string service, string id, bool isNotifiedOnce, long timeout, bool isPersistent, OpoSubscrCtx opoSubscrCtx)
	{
		m_service = service;
		m_id = id;
		m_bIsNotifiedOnce = isNotifiedOnce;
		m_bIsPersistent = isPersistent;
		m_timeout = timeout;
		m_opoSubscrCtx = opoSubscrCtx;
	}

	internal OracleNotificationRequest(bool isNotifiedOnce, long timeout, bool isPersistent, bool groupingNotificationEnabled, OracleAQNotificationGroupingType groupingType, int groupingInterval)
	{
		m_bIsNotifiedOnce = isNotifiedOnce;
		m_timeout = timeout;
		m_bIsPersistent = isPersistent;
		m_bGroupingNotificationEnabled = groupingNotificationEnabled;
		m_groupingType = groupingType;
		m_groupingInterval = groupingInterval;
	}

	internal static IntPtr PopulateChgNTFNSubscrCtx(OracleCommand cmd, bool isRowidReq, out OracleDependency dep)
	{
		IntPtr result = IntPtr.Zero;
		OracleConnection connection = cmd.Connection;
		OracleNotificationRequest notification = cmd.Notification;
		int num = 0;
		dep = null;
		if (cmd.m_NTFNAutoEnlist && notification != null)
		{
			if (!connection.IsDBVer10gR2OrHigher)
			{
				throw new OracleException(ErrRes.NTFN_CHGNTFN_DBVERSION, connection.DataSource, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.NTFN_CHGNTFN_DBVERSION));
			}
			if ((dep = OracleDependency.GetOracleDependencyFromNTFNId(notification.m_id)) == null)
			{
				throw new OracleException(ErrRes.NTFN_DEP_NOTEXIST, connection.DataSource, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.NTFN_DEP_NOTEXIST));
			}
			result = notification.m_opoSubscrCtx.opsSubscrCtx;
			if (!dep.m_bIsRegistered)
			{
				if (dep.m_OracleRowidInfo == OracleRowidInfo.Include)
				{
					isRowidReq = true;
				}
				else if (dep.m_OracleRowidInfo == OracleRowidInfo.Exclude)
				{
					isRowidReq = false;
				}
				try
				{
					num = OpsSubscr.SetChgNTFN(OracleDependency.s_opsEnvCtx, notification.m_opoSubscrCtx.opsSubscrCtx, notification.m_opoSubscrCtx.opsErrCtx, notification.m_id, notification.m_bIsPersistent ? 1 : 0, notification.m_bIsNotifiedOnce ? 1 : 0, isRowidReq ? 1 : 0, (uint)notification.m_timeout);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				finally
				{
					if (num != 0)
					{
						throw new OracleException(num, connection.DataSource, string.Empty, OpoErrResManager.GetErrorMesg(num));
					}
				}
			}
			else if (dep.m_dataSource != connection.DataSource || dep.m_userName != connection.m_opoConCtx.opoConRefCtx.userID)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
			}
		}
		return result;
	}
}
