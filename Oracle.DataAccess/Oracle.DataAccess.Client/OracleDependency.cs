using System;
using System.Collections;
using System.Data;
using System.Net;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

public class OracleDependency
{
	internal static IntPtr s_opsErrCtx;

	internal static IntPtr s_opsEnvCtx;

	internal static string s_machineAddress;

	internal static Hashtable s_depTable;

	internal static SubscrListenerInfo s_Listener;

	internal static OnChangeCallback s_onChangeOpsCallback;

	internal OpoSubscrCtx m_opoSubscrCtx;

	internal bool m_bIsRegistered;

	internal string m_guid;

	internal string m_invalidationStr;

	internal string m_dataSource;

	internal string m_userName;

	internal bool m_bHasChanges;

	internal bool m_bIsEnabled;

	internal bool m_bQueryBasedNTFN;

	internal ArrayList m_queryIDList;

	internal ArrayList m_regList;

	internal bool m_bIsNotifiedOnce;

	internal bool m_bIsPersistent;

	internal long m_timeout;

	internal OracleRowidInfo m_OracleRowidInfo;

	public static int Port
	{
		get
		{
			return s_Listener.port;
		}
		set
		{
			if (value < -1)
			{
				throw new ArgumentOutOfRangeException("Port");
			}
			lock (s_Listener)
			{
				if (!s_Listener.bListenerStart)
				{
					try
					{
						OpsSubscr.SetPort(s_opsEnvCtx, s_opsErrCtx, (uint)value);
						s_Listener.port = value;
						return;
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						throw;
					}
				}
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.NTFN_LISTENER_ALREADY_STARTED));
			}
		}
	}

	public string DataSource => m_dataSource;

	public bool HasChanges
	{
		get
		{
			bool bHasChanges = m_bHasChanges;
			m_bHasChanges = false;
			return bHasChanges;
		}
	}

	public string Id => m_guid;

	private string InvalidationString => m_invalidationStr;

	public bool IsEnabled => m_bIsEnabled;

	public bool QueryBasedNotification
	{
		get
		{
			return m_bQueryBasedNTFN;
		}
		set
		{
			if (m_bQueryBasedNTFN != value)
			{
				m_bQueryBasedNTFN = value;
			}
		}
	}

	public OracleRowidInfo RowidInfo
	{
		get
		{
			return m_OracleRowidInfo;
		}
		set
		{
			m_OracleRowidInfo = value;
		}
	}

	public ArrayList RegisteredResources => (ArrayList)m_regList.Clone();

	public ArrayList RegisteredQueryIDs => (ArrayList)m_queryIDList.Clone();

	public string UserName => m_userName;

	public event OnChangeEventHandler OnChange;

	static OracleDependency()
	{
		s_opsEnvCtx = CreateDependencyEnv();
		s_machineAddress = GetMachineAddress();
		s_depTable = Hashtable.Synchronized(new Hashtable());
		s_Listener = new SubscrListenerInfo();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
		if (s_Listener.port != -1)
		{
			Port = s_Listener.port;
		}
	}

	public OracleDependency()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDependency()\n");
		}
		Initialize(OracleNotificationRequest.s_bDefIsNotifiedOnce, OracleNotificationRequest.s_DefRegTimeout, OracleNotificationRequest.s_bDefIsPersistent);
		s_depTable.Add(m_guid, this);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDependency()\n");
		}
	}

	public OracleDependency(OracleCommand cmd)
		: this(cmd, OracleNotificationRequest.s_bDefIsNotifiedOnce, OracleNotificationRequest.s_DefRegTimeout, OracleNotificationRequest.s_bDefIsPersistent)
	{
	}

	public OracleDependency(OracleCommand cmd, bool isNotifiedOnce, long timeout, bool isPersistent)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDependency()\n");
		}
		if (cmd == null)
		{
			throw new ArgumentNullException("cmd");
		}
		if (timeout < 0 || timeout > uint.MaxValue)
		{
			throw new ArgumentOutOfRangeException("timeout");
		}
		if (cmd.Notification != null)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.NTFN_CMD_ALREADY_EXIST));
		}
		Initialize(isNotifiedOnce, timeout, isPersistent);
		OracleNotificationRequest oracleNotificationRequest = (cmd.m_NTFNReq = new OracleNotificationRequest(OracleNotificationRequest.s_ChangedNotificationName, m_invalidationStr, isNotifiedOnce, timeout, isPersistent, m_opoSubscrCtx));
		s_depTable.Add(m_guid, this);
		if (OracleNotificationRequest.s_idTable[oracleNotificationRequest.Id] == null)
		{
			OracleNotificationRequest.s_idTable.Add(oracleNotificationRequest.Id, m_guid);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDependency()\n");
		}
	}

	public static OracleDependency GetOracleDependency(string guid)
	{
		if (guid == null)
		{
			throw new ArgumentNullException("guid");
		}
		return (OracleDependency)s_depTable[guid];
	}

	public void AddCommandDependency(OracleCommand cmd)
	{
		if (cmd == null)
		{
			throw new ArgumentNullException("cmd");
		}
		if (cmd.Notification != null && OracleNotificationRequest.s_idTable[cmd.Notification.Id] != null)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.NTFN_CMD_ALREADY_EXIST));
		}
		cmd.m_NTFNReq = new OracleNotificationRequest(OracleNotificationRequest.s_ChangedNotificationName, m_invalidationStr, m_bIsNotifiedOnce, m_timeout, m_bIsPersistent, m_opoSubscrCtx);
		if (s_depTable[m_guid] == null)
		{
			s_depTable.Add(m_guid, this);
		}
		if (OracleNotificationRequest.s_idTable[cmd.m_NTFNReq.Id] == null)
		{
			OracleNotificationRequest.s_idTable.Add(cmd.m_NTFNReq.Id, m_guid);
		}
	}

	public void RemoveRegistration(OracleConnection conn)
	{
		if (!m_bIsRegistered)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.NTFN_REG_NOTVALID));
		}
		if (conn.State != ConnectionState.Open)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		int num = 0;
		try
		{
			num = OpsSubscr.UnRegister(conn.m_opoConCtx.opsConCtx, conn.m_opoConCtx.opsErrCtx, m_opoSubscrCtx.opsSubscrCtx);
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
				OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
			}
			m_bIsRegistered = false;
			m_bIsEnabled = false;
		}
		try
		{
			if (s_depTable[m_guid] != null)
			{
				s_depTable.Remove(m_guid);
			}
		}
		catch
		{
		}
		try
		{
			if (OracleNotificationRequest.s_idTable[m_invalidationStr] != null)
			{
				OracleNotificationRequest.s_idTable.Remove(m_invalidationStr);
			}
		}
		catch
		{
		}
	}

	internal static IntPtr CreateDependencyEnv()
	{
		int num = 0;
		IntPtr opsEnvCtx = IntPtr.Zero;
		IntPtr opsErrCtx = IntPtr.Zero;
		try
		{
			OpsSubscr.AllocGlobalCtx(out opsEnvCtx, out opsErrCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		s_onChangeOpsCallback = OnChangeOpsCallback_fn;
		try
		{
			num = OpsChgNTFN.RegisterNotificationCallback(s_onChangeOpsCallback);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				new OracleException(num, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(num));
			}
		}
		s_opsErrCtx = opsErrCtx;
		return opsEnvCtx;
	}

	internal static string GetMachineAddress()
	{
		IPHostEntry iPHostEntry = Dns.Resolve(Dns.GetHostName());
		IPAddress iPAddress = iPHostEntry.AddressList[0];
		return iPAddress.ToString();
	}

	internal static OracleDependency GetOracleDependencyFromNTFNId(string id)
	{
		string text = null;
		text = (string)OracleNotificationRequest.s_idTable[id];
		if (text != null)
		{
			return (OracleDependency)s_depTable[text];
		}
		return null;
	}

	internal static void OnChangeOpsCallback_fn(string id, IntPtr opsErrCtx, IntPtr opsChgNTFNDesc, NotiVal notiVal)
	{
		int num = 0;
		OracleDependency oracleDependencyFromNTFNId = GetOracleDependencyFromNTFNId(id);
		if (oracleDependencyFromNTFNId == null)
		{
			return;
		}
		if (oracleDependencyFromNTFNId.m_bIsNotifiedOnce)
		{
			oracleDependencyFromNTFNId.m_bIsEnabled = false;
			oracleDependencyFromNTFNId.m_bIsRegistered = false;
			try
			{
				s_depTable.Remove(oracleDependencyFromNTFNId.m_guid);
			}
			catch
			{
			}
			try
			{
				OracleNotificationRequest.s_idTable.Remove(id);
			}
			catch
			{
			}
		}
		if (oracleDependencyFromNTFNId.OnChange == null)
		{
			if (notiVal.source == OracleNotificationSource.Object || notiVal.source == OracleNotificationSource.Data)
			{
				oracleDependencyFromNTFNId.m_bHasChanges = true;
			}
			return;
		}
		OracleNotificationEventArgs oracleNotificationEventArgs = new OracleNotificationEventArgs();
		oracleNotificationEventArgs.m_type = notiVal.type;
		oracleNotificationEventArgs.m_source = notiVal.source;
		if (notiVal.source == OracleNotificationSource.Database || notiVal.source == OracleNotificationSource.Subscription)
		{
			if (notiVal.source == OracleNotificationSource.Subscription && notiVal.info == OracleNotificationInfo.End)
			{
				oracleDependencyFromNTFNId.m_bIsEnabled = false;
				oracleDependencyFromNTFNId.m_bIsRegistered = false;
				try
				{
					s_depTable.Remove(oracleDependencyFromNTFNId.m_guid);
				}
				catch
				{
				}
				try
				{
					OracleNotificationRequest.s_idTable.Remove(id);
				}
				catch
				{
				}
			}
			oracleNotificationEventArgs.m_info = notiVal.info;
			oracleDependencyFromNTFNId.FiredEvent(oracleNotificationEventArgs);
			return;
		}
		oracleDependencyFromNTFNId.m_bHasChanges = true;
		if (notiVal.type == OracleNotificationType.Query)
		{
			ArrayList arrayList = new ArrayList();
			int num2 = 0;
			for (int i = 0; i < notiVal.numQueries; i++)
			{
				long query_id = 0L;
				IntPtr query_desc = IntPtr.Zero;
				try
				{
					num = OpsChgNTFN.GetQueryIds(s_opsEnvCtx, opsErrCtx, opsChgNTFNDesc, i, ref query_desc, ref query_id, ref notiVal.numTables);
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
						throw new OracleException(num, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(num));
					}
				}
				NotiTblVal[] array = new NotiTblVal[notiVal.numTables];
				GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
				IntPtr notiTblDescs = gCHandle.AddrOfPinnedObject();
				IntPtr tableNames = IntPtr.Zero;
				try
				{
					num = OpsChgNTFN.GetTableInfos(s_opsEnvCtx, opsErrCtx, notiVal.numTables, notiVal.type, query_desc, notiTblDescs, out tableNames);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
					throw;
				}
				finally
				{
					if (gCHandle.IsAllocated)
					{
						gCHandle.Free();
					}
					if (num != 0)
					{
						throw new OracleException(num, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(num));
					}
				}
				IntPtr intPtr = tableNames;
				NotiTblRef notiTblRef = new NotiTblRef();
				for (int j = 0; j < notiVal.numTables; j++)
				{
					Marshal.PtrToStructure(intPtr, (object)notiTblRef);
					arrayList.Add(notiTblRef.tableName);
					intPtr = (IntPtr)((int)intPtr + Marshal.SizeOf((object)notiTblRef));
				}
				try
				{
					OpsChgNTFN.FreeNotiTblRefs(ref tableNames, notiVal.numTables);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
				}
				for (int k = 0; k < notiVal.numTables; k++)
				{
					if (array[k].numRows == 0)
					{
						if ((array[k].info & OracleNotificationInfo.Drop) == OracleNotificationInfo.Drop)
						{
							oracleNotificationEventArgs.m_source = OracleNotificationSource.Object;
							oracleNotificationEventArgs.AddRowDetail(arrayList[num2].ToString(), OracleNotificationInfo.Drop, null, query_id);
						}
						if ((array[k].info & OracleNotificationInfo.Alter) == OracleNotificationInfo.Alter)
						{
							oracleNotificationEventArgs.m_source = OracleNotificationSource.Object;
							oracleNotificationEventArgs.AddRowDetail(arrayList[num2].ToString(), OracleNotificationInfo.Alter, null, query_id);
						}
						if ((array[k].info & OracleNotificationInfo.Update) == OracleNotificationInfo.Update)
						{
							oracleNotificationEventArgs.AddRowDetail(arrayList[num2].ToString(), OracleNotificationInfo.Update, null, query_id);
						}
						if ((array[k].info & OracleNotificationInfo.Insert) == OracleNotificationInfo.Insert)
						{
							oracleNotificationEventArgs.AddRowDetail(arrayList[num2].ToString(), OracleNotificationInfo.Insert, null, query_id);
						}
						if ((array[k].info & OracleNotificationInfo.Delete) == OracleNotificationInfo.Delete)
						{
							oracleNotificationEventArgs.AddRowDetail(arrayList[num2].ToString(), OracleNotificationInfo.Delete, null, query_id);
						}
					}
					else
					{
						if ((array[k].info & OracleNotificationInfo.Drop) == OracleNotificationInfo.Drop)
						{
							oracleNotificationEventArgs.m_source = OracleNotificationSource.Object;
							oracleNotificationEventArgs.AddRowDetail(arrayList[num2].ToString(), OracleNotificationInfo.Drop, null, query_id);
						}
						if ((array[k].info & OracleNotificationInfo.Alter) == OracleNotificationInfo.Alter)
						{
							oracleNotificationEventArgs.m_source = OracleNotificationSource.Object;
							oracleNotificationEventArgs.AddRowDetail(arrayList[num2].ToString(), OracleNotificationInfo.Alter, null, query_id);
						}
						NotiRowVal[] array2 = new NotiRowVal[array[k].numRows];
						GCHandle gCHandle2 = GCHandle.Alloc(array2, GCHandleType.Pinned);
						IntPtr notiRowDescs = gCHandle2.AddrOfPinnedObject();
						IntPtr rowids = IntPtr.Zero;
						try
						{
							num = OpsChgNTFN.GetRowInfos(s_opsEnvCtx, opsErrCtx, array[k].numRows, array[k].pOpsTableChangeDesc, notiRowDescs, out rowids);
						}
						catch (Exception ex4)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex4);
							}
							throw;
						}
						finally
						{
							if (gCHandle2.IsAllocated)
							{
								gCHandle2.Free();
							}
							if (num != 0)
							{
								throw new OracleException(num, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(num));
							}
						}
						NotiRowRef notiRowRef = new NotiRowRef();
						IntPtr intPtr2 = rowids;
						for (int l = 0; l < array[k].numRows; l++)
						{
							Marshal.PtrToStructure(intPtr2, (object)notiRowRef);
							oracleNotificationEventArgs.AddRowDetail(arrayList[num2].ToString(), array2[l].info, notiRowRef.rowid, query_id);
							intPtr2 = (IntPtr)((int)intPtr2 + Marshal.SizeOf((object)notiRowRef));
						}
						try
						{
							OpsChgNTFN.FreeNotiRowRefs(ref rowids, array[k].numRows);
						}
						catch (Exception ex5)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex5);
							}
						}
					}
					num2++;
				}
			}
			oracleNotificationEventArgs.m_resources = (string[])arrayList.ToArray(typeof(string));
			arrayList.Clear();
			arrayList = null;
		}
		else
		{
			NotiTblVal[] array3 = new NotiTblVal[notiVal.numTables];
			GCHandle gCHandle3 = GCHandle.Alloc(array3, GCHandleType.Pinned);
			IntPtr notiTblDescs2 = gCHandle3.AddrOfPinnedObject();
			IntPtr tableNames2 = IntPtr.Zero;
			try
			{
				num = OpsChgNTFN.GetTableInfos(s_opsEnvCtx, opsErrCtx, notiVal.numTables, notiVal.type, opsChgNTFNDesc, notiTblDescs2, out tableNames2);
			}
			catch (Exception ex6)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex6);
				}
				throw;
			}
			finally
			{
				if (gCHandle3.IsAllocated)
				{
					gCHandle3.Free();
				}
				if (num != 0)
				{
					throw new OracleException(num, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(num));
				}
			}
			oracleNotificationEventArgs.m_resources = new string[notiVal.numTables];
			IntPtr intPtr3 = tableNames2;
			NotiTblRef notiTblRef2 = new NotiTblRef();
			for (int m = 0; m < notiVal.numTables; m++)
			{
				Marshal.PtrToStructure(intPtr3, (object)notiTblRef2);
				oracleNotificationEventArgs.m_resources[m] = notiTblRef2.tableName;
				intPtr3 = (IntPtr)((int)intPtr3 + Marshal.SizeOf((object)notiTblRef2));
			}
			try
			{
				OpsChgNTFN.FreeNotiTblRefs(ref tableNames2, notiVal.numTables);
			}
			catch (Exception ex7)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex7);
				}
			}
			for (int n = 0; n < notiVal.numTables; n++)
			{
				if (array3[n].numRows == 0)
				{
					if ((array3[n].info & OracleNotificationInfo.Drop) == OracleNotificationInfo.Drop)
					{
						oracleNotificationEventArgs.m_source = OracleNotificationSource.Object;
						oracleNotificationEventArgs.AddRowDetail(oracleNotificationEventArgs.m_resources[n], OracleNotificationInfo.Drop, null, 0L);
					}
					if ((array3[n].info & OracleNotificationInfo.Alter) == OracleNotificationInfo.Alter)
					{
						oracleNotificationEventArgs.m_source = OracleNotificationSource.Object;
						oracleNotificationEventArgs.AddRowDetail(oracleNotificationEventArgs.m_resources[n], OracleNotificationInfo.Alter, null, 0L);
					}
					if ((array3[n].info & OracleNotificationInfo.Update) == OracleNotificationInfo.Update)
					{
						oracleNotificationEventArgs.AddRowDetail(oracleNotificationEventArgs.m_resources[n], OracleNotificationInfo.Update, null, 0L);
					}
					if ((array3[n].info & OracleNotificationInfo.Insert) == OracleNotificationInfo.Insert)
					{
						oracleNotificationEventArgs.AddRowDetail(oracleNotificationEventArgs.m_resources[n], OracleNotificationInfo.Insert, null, 0L);
					}
					if ((array3[n].info & OracleNotificationInfo.Delete) == OracleNotificationInfo.Delete)
					{
						oracleNotificationEventArgs.AddRowDetail(oracleNotificationEventArgs.m_resources[n], OracleNotificationInfo.Delete, null, 0L);
					}
					continue;
				}
				if ((array3[n].info & OracleNotificationInfo.Drop) == OracleNotificationInfo.Drop)
				{
					oracleNotificationEventArgs.m_source = OracleNotificationSource.Object;
					oracleNotificationEventArgs.AddRowDetail(oracleNotificationEventArgs.m_resources[n], OracleNotificationInfo.Drop, null, 0L);
				}
				if ((array3[n].info & OracleNotificationInfo.Alter) == OracleNotificationInfo.Alter)
				{
					oracleNotificationEventArgs.m_source = OracleNotificationSource.Object;
					oracleNotificationEventArgs.AddRowDetail(oracleNotificationEventArgs.m_resources[n], OracleNotificationInfo.Alter, null, 0L);
				}
				NotiRowVal[] array4 = new NotiRowVal[array3[n].numRows];
				GCHandle gCHandle4 = GCHandle.Alloc(array4, GCHandleType.Pinned);
				IntPtr notiRowDescs2 = gCHandle4.AddrOfPinnedObject();
				IntPtr rowids2 = IntPtr.Zero;
				try
				{
					num = OpsChgNTFN.GetRowInfos(s_opsEnvCtx, opsErrCtx, array3[n].numRows, array3[n].pOpsTableChangeDesc, notiRowDescs2, out rowids2);
				}
				catch (Exception ex8)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex8);
					}
					throw;
				}
				finally
				{
					if (gCHandle4.IsAllocated)
					{
						gCHandle4.Free();
					}
					if (num != 0)
					{
						throw new OracleException(num, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(num));
					}
				}
				NotiRowRef notiRowRef2 = new NotiRowRef();
				IntPtr intPtr4 = rowids2;
				for (int num3 = 0; num3 < array3[n].numRows; num3++)
				{
					Marshal.PtrToStructure(intPtr4, (object)notiRowRef2);
					oracleNotificationEventArgs.AddRowDetail(oracleNotificationEventArgs.m_resources[n], array4[num3].info, notiRowRef2.rowid, 0L);
					intPtr4 = (IntPtr)((int)intPtr4 + Marshal.SizeOf((object)notiRowRef2));
				}
				try
				{
					OpsChgNTFN.FreeNotiRowRefs(ref rowids2, array3[n].numRows);
				}
				catch (Exception ex9)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex9);
					}
				}
			}
		}
		if (oracleNotificationEventArgs.m_details.Rows.Count > 0)
		{
			oracleNotificationEventArgs.m_info = (OracleNotificationInfo)oracleNotificationEventArgs.m_details.Rows[0][1];
		}
		else
		{
			oracleNotificationEventArgs.m_info = OracleNotificationInfo.Error;
		}
		oracleDependencyFromNTFNId.FiredEvent(oracleNotificationEventArgs);
	}

	internal void Initialize(bool isNotifiedOnce, long timeout, bool isPersistent)
	{
		m_guid = Guid.NewGuid().ToString();
		m_bIsRegistered = false;
		m_invalidationStr = "<MachineAddress>tcp://" + s_machineAddress + "</MachineAddress><key>" + m_guid + "</key>";
		m_dataSource = "";
		m_userName = "";
		m_bHasChanges = false;
		m_bIsEnabled = false;
		m_bQueryBasedNTFN = true;
		m_OracleRowidInfo = OracleRowidInfo.Default;
		m_queryIDList = new ArrayList();
		m_regList = new ArrayList();
		m_opoSubscrCtx = new OpoSubscrCtx();
		try
		{
			OpsSubscr.AllocCtx(s_opsEnvCtx, out m_opoSubscrCtx.opsErrCtx, out m_opoSubscrCtx.opsSubscrCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		m_bIsNotifiedOnce = isNotifiedOnce;
		m_bIsPersistent = isPersistent;
		m_timeout = timeout;
	}

	internal int GetPort()
	{
		uint port = 0u;
		try
		{
			OpsSubscr.GetPort(s_opsEnvCtx, s_opsErrCtx, out port);
			return (int)port;
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
	}

	internal void SetRegisterInfo(string username, string dataSource, bool IsNotifiedOnce, bool IsPersistent, long timeout)
	{
		lock (s_Listener)
		{
			if (!s_Listener.bListenerStart)
			{
				s_Listener.port = GetPort();
				s_Listener.bListenerStart = true;
			}
		}
		if (!m_bIsRegistered)
		{
			m_userName = username;
			m_dataSource = dataSource;
			m_bIsRegistered = true;
			m_bIsNotifiedOnce = IsNotifiedOnce;
			m_bIsPersistent = IsPersistent;
			m_timeout = timeout;
			m_regList.Clear();
			m_queryIDList.Clear();
		}
	}

	public void FiredEvent(OracleNotificationEventArgs e)
	{
		if (this.OnChange != null)
		{
			try
			{
				this.OnChange(this, e);
			}
			catch
			{
			}
		}
	}
}
