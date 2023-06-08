using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Oracle.DataAccess.Client;

internal class ConnectionDispenser
{
	internal static Hashtable m_ConnectionPools;

	internal static Hashtable m_pspePrimaryResources;

	internal static Hashtable m_htTnsToSvc;

	internal static Hashtable m_htSvcToRLB;

	internal static int m_totalNumberOfConnectionPools;

	internal static Random m_random;

	internal static Hashtable m_htHAOpoConCtx;

	internal static Hashtable m_htRLBOpoConCtx;

	internal static int m_iteration;

	internal static OraHACallbackFuncPtr m_HACallback;

	internal static OraRLBCallbackFuncPtr m_RLBCallback;

	internal static bool m_bIsGlobalOCIEnvExists;

	internal static string s_pattern;

	internal static RLBMetricsComparer s_metricsComparer;

	internal static int REQ_ATTEMPTS_FOR_GRAV_PER_INSTANCE;

	internal static object s_lockObj;

	internal static object s_haEventObj;

	static ConnectionDispenser()
	{
		s_pattern = "service\\s*=\\s*(?<svc>.*?)\\s*{\\s*(\\s*{\\s*instance\\s*=\\s*(?<inst>.*?)\\s+percent\\s*=\\s*(?<perc>.*?)\\s+flag\\s*=\\s*(?<flag>.*?)\\s*}\\s*)*\\s*}\\s*timestamp\\s*=\\s*(?<ts>.*?)\\s*\\Z";
		s_metricsComparer = new RLBMetricsComparer();
		REQ_ATTEMPTS_FOR_GRAV_PER_INSTANCE = 1000;
		s_lockObj = new object();
		s_haEventObj = new object();
		m_random = new Random(DateTime.Today.Millisecond);
		m_htHAOpoConCtx = Hashtable.Synchronized(new Hashtable());
		m_htRLBOpoConCtx = Hashtable.Synchronized(new Hashtable());
		m_HACallback = OnHACallback;
		m_RLBCallback = OnRLBCallback;
		m_pspePrimaryResources = Hashtable.Synchronized(new Hashtable());
	}

	public unsafe static int Enlist(OpoConCtx opoConCtx)
	{
		int num = 0;
		try
		{
			num = OpsCon.Enlist(opoConCtx.opsConCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			opoConCtx.exceptMsg = ex.ToString();
		}
		finally
		{
			if (num != 0)
			{
				OpoConValCtx* pOpoConValCtx = null;
				try
				{
					OpsCon.Close(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
				{
					OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
				}
				try
				{
					if (opoConCtx.m_fetchArrayPooler != null)
					{
						opoConCtx.m_fetchArrayPooler.Dispose();
						opoConCtx.m_fetchArrayPooler = null;
					}
					OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref pOpoConValCtx, opoConCtx.opoConRefCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
				}
			}
		}
		return num;
	}

	public unsafe static int Open(OpoConCtx opoConCtx)
	{
		int num = 0;
		if (opoConCtx.pOpoConValCtx->Pooling == 0)
		{
			try
			{
				num = OpsCon.Open(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, ref opoConCtx.opoConRefCtx);
				if (num == 0 && (OraTrace.m_PerformanceCounters & PerfCounterLevel.HardConnectsPerSecond) == PerfCounterLevel.HardConnectsPerSecond)
				{
					OraclePerfCounterCollection.HardConnectsPerSecond.Increment();
				}
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				num = ErrRes.INT_ERR;
				opoConCtx.exceptMsg = ex.ToString();
			}
			if (num != 0)
			{
				return num;
			}
			opoConCtx.creationTime = DateTime.Now;
			if (opoConCtx.pOpoConValCtx->Enlist == 1 && opoConCtx.pOpoConValCtx->InMtsTxn == 0 && (opoConCtx.opoConRefCtx.proxyUserId == null || opoConCtx.opoConRefCtx.proxyUserId.Length == 0))
			{
				num = Enlist(opoConCtx);
			}
			if (opoConCtx.metaPool == 1)
			{
				if (opoConCtx.m_bSelfTuning)
				{
					opoConCtx.m_conPooler = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON);
					opoConCtx.m_udtDescPoolerByName = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON);
				}
				else
				{
					opoConCtx.m_conPooler = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_OFF);
					opoConCtx.m_udtDescPoolerByName = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_OFF);
				}
			}
			if (opoConCtx.m_bSelfTuning)
			{
				opoConCtx.m_udtDescPoolerByTDO = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON);
			}
			else
			{
				opoConCtx.m_udtDescPoolerByTDO = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_OFF);
			}
			if (num == 0)
			{
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfNonPooledConnections) == PerfCounterLevel.NumberOfNonPooledConnections)
				{
					OraclePerfCounterCollection.NumberOfNonPooledConnections.Increment();
				}
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnections) == PerfCounterLevel.NumberOfActiveConnections)
				{
					OraclePerfCounterCollection.NumberOfActiveConnections.Increment();
				}
			}
			return num;
		}
		bool bConObtained = false;
		num = GetConnectionPool(ref opoConCtx, ref bConObtained);
		if (num != 0)
		{
			return num;
		}
		if (opoConCtx.pool != null && !bConObtained)
		{
			int num2 = opoConCtx.AuthenticateUser();
			if (num2 != 0 || opoConCtx.opoConRefCtx.newPassword != "")
			{
				num = OpsCon.Open(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, ref opoConCtx.opoConRefCtx);
				if (num == 0)
				{
					if (opoConCtx.opoConRefCtx.newPassword != "")
					{
						opoConCtx.opoConRefCtx.password = opoConCtx.opoConRefCtx.newPassword;
						opoConCtx.opoConRefCtx.newPassword = "";
					}
					lock (opoConCtx.pool.m_passwordSyncObj)
					{
						opoConCtx.pool.ResetPasswords(opoConCtx.opoConRefCtx.password, opoConCtx.opoConRefCtx.proxyPassword);
						opoConCtx.pool.ClearPool(bInvalidOnly: false, bRefresh: false);
					}
					OpsCon.Close(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
				}
				else
				{
					OracleException.HandleError(num2, null, IntPtr.Zero, null);
				}
			}
		}
		if (opoConCtx.pool.m_cpCtx != null && !bConObtained)
		{
			num = opoConCtx.pool.m_cpCtx.GetConnection(opoConCtx);
			if (num != 0)
			{
				return num;
			}
		}
		else if (opoConCtx.pool != null && !bConObtained)
		{
			num = opoConCtx.pool.GetConnection(opoConCtx);
			if (num != 0)
			{
				return num;
			}
		}
		if (opoConCtx.m_bSelfTuning && opoConCtx.pool != null)
		{
			int stmtCacheSize = opoConCtx.pOpoConValCtx->StmtCacheSize;
			if (opoConCtx.pool.m_scsRecommendations <= OraTrace.MaxStatementCacheSize)
			{
				if (opoConCtx.pool.m_scsRecommendations >= opoConCtx.pOpoConValCtx->StmtCacheSize || opoConCtx.pool.m_scsRecommendations <= (int)((float)opoConCtx.pOpoConValCtx->StmtCacheSize * 0.9f))
				{
					opoConCtx.pOpoConValCtx->StmtCacheSize = opoConCtx.pool.m_scsRecommendations;
				}
			}
			else if (opoConCtx.pOpoConValCtx->StmtCacheSize > OraTrace.MaxStatementCacheSize)
			{
				opoConCtx.pOpoConValCtx->StmtCacheSize = OraTrace.MaxStatementCacheSize;
			}
			if (stmtCacheSize != opoConCtx.pOpoConValCtx->StmtCacheSize)
			{
				try
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(64u, " (TUNING) ConnectionDispenser::Open(): Setting stmt cache size for connection (Pool Id: " + opoConCtx.pool.m_poolId + ") to " + opoConCtx.pOpoConValCtx->StmtCacheSize.ToString() + " \n");
					}
					num = OpsCon.SetStatementCacheSize(opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx);
					if (opoConCtx.m_conPooler != null)
					{
						opoConCtx.m_conPooler.ModifyConPoolerSize(opoConCtx.pOpoConValCtx->StmtCacheSize);
					}
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(64u, "(ERROR) ConnectionPool::ConnectionDispenser(): Open (Pool Id: " + opoConCtx.pool.m_poolId + "); Exception: " + ex2.ToString() + " \n");
					}
				}
			}
		}
		if (num == 0 && opoConCtx.pOpoConValCtx->SessionBegin == 1)
		{
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.SoftConnectsPerSecond) == PerfCounterLevel.SoftConnectsPerSecond)
			{
				OraclePerfCounterCollection.SoftConnectsPerSecond.Increment();
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfPooledConnections) == PerfCounterLevel.NumberOfPooledConnections)
			{
				OraclePerfCounterCollection.NumberOfPooledConnections.Increment();
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnections) == PerfCounterLevel.NumberOfActiveConnections)
			{
				OraclePerfCounterCollection.NumberOfActiveConnections.Increment();
			}
		}
		return num;
	}

	public unsafe static int Close(ref OpoConCtx opoConCtx, bool isContextConnection)
	{
		int result = 0;
		if (opoConCtx.pOpoConValCtx->Pooling == 0)
		{
			if (opoConCtx.m_fetchArrayPooler != null)
			{
				opoConCtx.m_fetchArrayPooler.Dispose();
			}
			if (TxnType.LocalTxnForSysTxn == opoConCtx.m_txnType && opoConCtx.m_promotableTxnManager != null && !string.IsNullOrEmpty(opoConCtx.m_promotableTxnManager.m_localTxnIdentifier))
			{
				m_pspePrimaryResources.Add(opoConCtx.m_promotableTxnManager.m_localTxnIdentifier, opoConCtx);
				opoConCtx = null;
			}
			else
			{
				try
				{
					result = OpsCon.Close(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond && !isContextConnection)
				{
					OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
				}
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfNonPooledConnections) == PerfCounterLevel.NumberOfNonPooledConnections && !isContextConnection)
				{
					OraclePerfCounterCollection.NumberOfNonPooledConnections.Decrement();
				}
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnections) == PerfCounterLevel.NumberOfActiveConnections && !isContextConnection)
				{
					OraclePerfCounterCollection.NumberOfActiveConnections.Decrement();
				}
				opoConCtx.m_conPooler = null;
				opoConCtx.m_udtDescPoolerByName = null;
				opoConCtx.m_udtDescPoolerByTDO = null;
				opoConCtx.m_systemTransaction = null;
				opoConCtx.m_txnType = TxnType.None;
				opoConCtx.m_promotableTxnManager = null;
			}
		}
		else if (opoConCtx.pool != null)
		{
			if (OracleTuningAgent.bHighMemoryAlertFlag && opoConCtx.m_fetchArrayPooler != null)
			{
				opoConCtx.m_fetchArrayPooler.ReSizeFetchArrayPooler(1);
			}
			if (!opoConCtx.pool.m_bSynchronizeStack)
			{
				result = ((opoConCtx.pOpoConValCtx->InMtsTxn != 1) ? opoConCtx.pool.PutConnection(ref opoConCtx, bDoNotAllocValCtx: false, bCheckStatus: true, bCheckLifeTime: true, 0) : opoConCtx.pool.PutConnection(ref opoConCtx, bDoNotAllocValCtx: false, bCheckStatus: true, bCheckLifeTime: true, 1));
			}
			else
			{
				lock (opoConCtx.pool.m_connections)
				{
					result = ((opoConCtx.pOpoConValCtx->InMtsTxn != 1) ? opoConCtx.pool.PutConnection(ref opoConCtx, bDoNotAllocValCtx: false, bCheckStatus: true, bCheckLifeTime: true, 0) : opoConCtx.pool.PutConnection(ref opoConCtx, bDoNotAllocValCtx: false, bCheckStatus: true, bCheckLifeTime: true, 1));
				}
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.SoftDisconnectsPerSecond) == PerfCounterLevel.SoftDisconnectsPerSecond)
			{
				OraclePerfCounterCollection.SoftDisconnectsPerSecond.Increment();
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfPooledConnections) == PerfCounterLevel.NumberOfPooledConnections)
			{
				OraclePerfCounterCollection.NumberOfPooledConnections.Decrement();
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnections) == PerfCounterLevel.NumberOfActiveConnections)
			{
				OraclePerfCounterCollection.NumberOfActiveConnections.Decrement();
			}
		}
		else
		{
			Dispose(ref opoConCtx);
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfPooledConnections) == PerfCounterLevel.NumberOfPooledConnections)
			{
				OraclePerfCounterCollection.NumberOfPooledConnections.Decrement();
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnections) == PerfCounterLevel.NumberOfActiveConnections)
			{
				OraclePerfCounterCollection.NumberOfActiveConnections.Decrement();
			}
		}
		return result;
	}

	public unsafe static int Dispose(ref OpoConCtx opoConCtx)
	{
		bool flag = opoConCtx.opsConCtx == IntPtr.Zero;
		try
		{
			if (opoConCtx.m_fetchArrayPooler != null)
			{
				opoConCtx.m_fetchArrayPooler.Dispose();
				opoConCtx.m_fetchArrayPooler = null;
			}
			OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		if (!flag && (OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
		{
			OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
		}
		opoConCtx.opsConCtx = IntPtr.Zero;
		opoConCtx.opsErrCtx = IntPtr.Zero;
		opoConCtx.pOpoConValCtx = null;
		opoConCtx.opoConRefCtx = null;
		opoConCtx.pooledConCtx = null;
		opoConCtx.m_conPooler = null;
		opoConCtx.m_udtDescPoolerByName = null;
		opoConCtx.m_udtDescPoolerByTDO = null;
		opoConCtx.m_systemTransaction = null;
		opoConCtx.m_txnType = TxnType.None;
		return 0;
	}

	public static int GetConnectionPool(ref OpoConCtx opoConCtx, ref bool bConObtained)
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		RLBCtx rLBCtx = null;
		CPCtx cPCtx = null;
		opoConCtx.pool = null;
		try
		{
			if (opoConCtx.bGridRac)
			{
				string text = null;
				if (m_htTnsToSvc == null && m_htSvcToRLB == null)
				{
					lock (s_lockObj)
					{
						if (m_htTnsToSvc == null)
						{
							m_htTnsToSvc = Hashtable.Synchronized(new Hashtable());
						}
						if (m_htSvcToRLB == null)
						{
							m_htSvcToRLB = Hashtable.Synchronized(new Hashtable());
						}
					}
				}
				text = (string)m_htTnsToSvc[opoConCtx.opoConRefCtx.dataSource];
				if (text == null)
				{
					lock (m_htTnsToSvc.SyncRoot)
					{
						if (m_htTnsToSvc[opoConCtx.opoConRefCtx.dataSource] == null)
						{
							num = CreateConnectionPool(ref opoConCtx);
							if (num != 0)
							{
								return num;
							}
							bConObtained = true;
							text = opoConCtx.opoConRefCtx.serviceName;
							m_htTnsToSvc[opoConCtx.opoConRefCtx.dataSource] = text;
						}
						else
						{
							text = (string)m_htTnsToSvc[opoConCtx.opoConRefCtx.dataSource];
						}
					}
				}
				rLBCtx = (RLBCtx)m_htSvcToRLB[text];
				if (rLBCtx == null)
				{
					lock (m_htSvcToRLB.SyncRoot)
					{
						if ((RLBCtx)m_htSvcToRLB[text] == null)
						{
							num = CreateConnectionPool(ref opoConCtx);
							if (num != 0)
							{
								return num;
							}
							bConObtained = true;
						}
						rLBCtx = (RLBCtx)m_htSvcToRLB[text];
					}
				}
				cPCtx = (CPCtx)rLBCtx.htConToInst[opoConCtx.conString];
				if (cPCtx == null)
				{
					lock (rLBCtx)
					{
						lock (rLBCtx.htConToInst.SyncRoot)
						{
							if (rLBCtx.htConToInst[opoConCtx.conString] == null)
							{
								num = CreateConnectionPool(ref opoConCtx);
								if (num != 0)
								{
									return num;
								}
								bConObtained = true;
							}
							cPCtx = (CPCtx)rLBCtx.htConToInst[opoConCtx.conString];
						}
					}
				}
				if (opoConCtx.pool == null)
				{
					if (opoConCtx.m_systemTransaction != null && opoConCtx.bGridRac)
					{
						if (opoConCtx.m_txnid == null)
						{
							opoConCtx.m_txnid = opoConCtx.m_systemTransaction.TransactionInformation.LocalIdentifier;
						}
						opoConCtx.affinityInstanceName = (string)cPCtx.m_htTxnIdToIntance[opoConCtx.m_txnid];
						if (opoConCtx.affinityInstanceName != null)
						{
							opoConCtx.pool = (ConnectionPool)cPCtx.htInstToCp[opoConCtx.affinityInstanceName];
							opoConCtx.instanceConCount = opoConCtx.pool.m_connections.Count;
							return 0;
						}
					}
					else
					{
						opoConCtx.m_txnid = null;
					}
					if (opoConCtx.gridRLB == 1 && rLBCtx.RLBMetricsList != null && rLBCtx.RLBMetricsList.Count > 0)
					{
						lock (rLBCtx)
						{
							if (rLBCtx.RLBMetricsList != null && rLBCtx.RLBMetricsList.Count > 0)
							{
								int i = 0;
								bool flag4 = false;
								while (!flag4)
								{
									int num2 = int.MaxValue;
									for (i = 0; i < rLBCtx.RLBMetricsList.Count; i++)
									{
										if (((RLBMetrics)rLBCtx.RLBMetricsList[i]).CurDistribFreq == 0)
										{
											flag4 = true;
											break;
										}
										num2 = Math.Min(num2, ((RLBMetrics)rLBCtx.RLBMetricsList[i]).CurDistribFreq);
									}
									if (!flag4)
									{
										for (i = 0; i < rLBCtx.RLBMetricsList.Count; i++)
										{
											((RLBMetrics)rLBCtx.RLBMetricsList[i]).CurDistribFreq -= num2;
										}
									}
								}
								opoConCtx.pool = (ConnectionPool)cPCtx.htInstToCp[((RLBMetrics)rLBCtx.RLBMetricsList[i]).InstanceName];
								if (opoConCtx.pool == null)
								{
									lock (cPCtx.htInstToCp.SyncRoot)
									{
										if (cPCtx.htInstToCp[((RLBMetrics)rLBCtx.RLBMetricsList[i]).InstanceName] == null)
										{
											opoConCtx.opoConRefCtx.serviceName = rLBCtx.ServiceName;
											opoConCtx.opoConRefCtx.instanceName = ((RLBMetrics)rLBCtx.RLBMetricsList[i]).InstanceName;
											opoConCtx.pool = new ConnectionPool(opoConCtx, cPCtx);
											cPCtx.htInstToCp[((RLBMetrics)rLBCtx.RLBMetricsList[i]).InstanceName] = opoConCtx.pool;
											opoConCtx.pool.UpdatePotentialTotalCount(opoConCtx.pool.m_clonedCtx.poolIncSize);
											ThreadPool.QueueUserWorkItem(opoConCtx.pool.PopulatePool, opoConCtx.pool.m_clonedCtx.poolIncSize);
										}
										else
										{
											opoConCtx.pool = (ConnectionPool)cPCtx.htInstToCp[((RLBMetrics)rLBCtx.RLBMetricsList[i]).InstanceName];
										}
									}
								}
								if (bConObtained && (OraTrace.m_TraceLevel & 0x20) == 32)
								{
									int num3 = 0;
									StringBuilder stringBuilder = new StringBuilder();
									stringBuilder.Append(" (GRID) (RLB) (DISP) (inst=");
									stringBuilder.Append(opoConCtx.opoConRefCtx.instanceName);
									stringBuilder.Append(") ");
									ConnectionPool connectionPool = null;
									for (num3 = 0; num3 < rLBCtx.RLBMetricsList.Count; num3++)
									{
										stringBuilder.Append("(");
										stringBuilder.Append(((RLBMetrics)rLBCtx.RLBMetricsList[num3]).InstanceName);
										connectionPool = (ConnectionPool)cPCtx.htInstToCp[((RLBMetrics)rLBCtx.RLBMetricsList[num3]).InstanceName];
										if (connectionPool != null)
										{
											stringBuilder.Append(": used=");
											stringBuilder.Append(connectionPool.m_counter.total - connectionPool.m_connections.Count);
											stringBuilder.Append("; idle=");
											stringBuilder.Append(connectionPool.m_connections.Count);
											stringBuilder.Append("; tot=");
											stringBuilder.Append(connectionPool.m_counter.total);
										}
										else
										{
											stringBuilder.Append(": N/A");
										}
										stringBuilder.Append("; counter=");
										stringBuilder.Append(((RLBMetrics)rLBCtx.RLBMetricsList[num3]).CurDistribFreq);
										stringBuilder.Append("/");
										stringBuilder.Append(((RLBMetrics)rLBCtx.RLBMetricsList[num3]).MaxDistribFreq);
										stringBuilder.Append(") ");
									}
									stringBuilder.Append(")\n");
									OraTrace.Trace(32u, stringBuilder.ToString());
								}
								if (opoConCtx.pool != null)
								{
									return num;
								}
							}
						}
					}
					if (opoConCtx.pool != null)
					{
						if (!flag3)
						{
							Monitor.Enter(cPCtx.htInstToCp.SyncRoot);
							flag3 = true;
						}
						cPCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] = opoConCtx.pool;
					}
					else
					{
						if (!flag3)
						{
							Monitor.Enter(cPCtx.htInstToCp.SyncRoot);
							flag3 = true;
						}
						if (cPCtx.htInstToCp.Count == 0)
						{
							if (opoConCtx.pool == null)
							{
								num = CreateConnectionPool(ref opoConCtx);
								if (num != 0)
								{
									return num;
								}
							}
							bConObtained = true;
							return num;
						}
						int num4 = Interlocked.Increment(ref m_iteration) % cPCtx.htInstToCp.Count;
						if (m_iteration > 1073741823)
						{
							m_iteration = 0;
						}
						int num5 = 0;
						IDictionaryEnumerator enumerator = cPCtx.htInstToCp.GetEnumerator();
						while (enumerator.MoveNext() && num5 != num4)
						{
							num5++;
						}
						opoConCtx.pool = (ConnectionPool)enumerator.Value;
					}
				}
				return num;
			}
			if (m_ConnectionPools == null)
			{
				lock (s_lockObj)
				{
					if (m_ConnectionPools == null)
					{
						num = CreateConnectionPool(ref opoConCtx);
						if (num != 0)
						{
							return num;
						}
						bConObtained = true;
						Hashtable hashtable = Hashtable.Synchronized(new Hashtable());
						hashtable[opoConCtx.conString] = opoConCtx.pool;
						m_ConnectionPools = hashtable;
					}
				}
			}
			else
			{
				opoConCtx.pool = (ConnectionPool)m_ConnectionPools[opoConCtx.conString];
			}
			if (opoConCtx.pool == null)
			{
				lock (s_lockObj)
				{
					opoConCtx.pool = (ConnectionPool)m_ConnectionPools[opoConCtx.conString];
					if (opoConCtx.pool == null)
					{
						num = CreateConnectionPool(ref opoConCtx);
						if (num == 0)
						{
							bConObtained = true;
							m_ConnectionPools[opoConCtx.conString] = opoConCtx.pool;
						}
					}
				}
			}
			return num;
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(m_htSvcToRLB.SyncRoot);
			}
			if (flag2)
			{
				Monitor.Exit(rLBCtx.htConToInst.SyncRoot);
			}
			if (flag3)
			{
				Monitor.Exit(cPCtx.htInstToCp.SyncRoot);
			}
		}
	}

	public unsafe static int CreateConnectionPool(ref OpoConCtx opoConCtx)
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		try
		{
			num = OpsCon.Open(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, ref opoConCtx.opoConRefCtx);
			if (num == 0 && (OraTrace.m_PerformanceCounters & PerfCounterLevel.HardConnectsPerSecond) == PerfCounterLevel.HardConnectsPerSecond)
			{
				OraclePerfCounterCollection.HardConnectsPerSecond.Increment();
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			opoConCtx.exceptMsg = ex.ToString();
		}
		if (num != 0)
		{
			return num;
		}
		if ((opoConCtx.opoConRefCtx.proxyUserId != null && opoConCtx.opoConRefCtx.proxyUserId.Length > 0) || opoConCtx.pOpoConValCtx->OSAuthent == 2)
		{
			try
			{
				num = OpsCon.OpenProxyAuthUserSession(opoConCtx.opsConCtx, opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				num = ErrRes.INT_ERR;
				opoConCtx.exceptMsg = ex2.ToString();
			}
			finally
			{
				if (num != 0)
				{
					OpoConValCtx* pOpoConValCtx = null;
					try
					{
						OpsCon.Close(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
					}
					catch (Exception ex3)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex3);
						}
					}
					if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
					{
						OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
					}
					try
					{
						if (opoConCtx.m_fetchArrayPooler != null)
						{
							opoConCtx.m_fetchArrayPooler.Dispose();
							opoConCtx.m_fetchArrayPooler = null;
						}
						OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref pOpoConValCtx, opoConCtx.opoConRefCtx);
					}
					catch (Exception ex4)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex4);
						}
					}
				}
			}
			if (num != 0)
			{
				return num;
			}
		}
		if ((num = RegisterCallbacks(opoConCtx)) != 0)
		{
			OpoConValCtx* pOpoConValCtx2 = null;
			try
			{
				OpsCon.Close(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
			}
			catch (Exception ex5)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex5);
				}
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
			{
				OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
			}
			try
			{
				if (opoConCtx.m_fetchArrayPooler != null)
				{
					opoConCtx.m_fetchArrayPooler.Dispose();
					opoConCtx.m_fetchArrayPooler = null;
				}
				OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref pOpoConValCtx2, opoConCtx.opoConRefCtx);
			}
			catch (Exception ex6)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex6);
				}
			}
			return num;
		}
		opoConCtx.creationTime = DateTime.Now;
		opoConCtx.pool = null;
		RLBCtx rLBCtx = null;
		CPCtx cPCtx = null;
		if (opoConCtx.bGridRac)
		{
			rLBCtx = (RLBCtx)m_htSvcToRLB[opoConCtx.opoConRefCtx.serviceName];
			if (rLBCtx == null)
			{
				lock (m_htSvcToRLB.SyncRoot)
				{
					if (m_htSvcToRLB[opoConCtx.opoConRefCtx.serviceName] == null)
					{
						rLBCtx = new RLBCtx(opoConCtx.opoConRefCtx.serviceName);
						m_htSvcToRLB[opoConCtx.opoConRefCtx.serviceName] = rLBCtx;
					}
				}
			}
			else
			{
				cPCtx = (CPCtx)rLBCtx.htConToInst[opoConCtx.conString];
				if (cPCtx != null && cPCtx.htInstToCp != null)
				{
					opoConCtx.pool = (ConnectionPool)cPCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName];
					if (opoConCtx.pool != null && opoConCtx.pool.m_clonedCtx.opoConRefCtx.dbName == null)
					{
						opoConCtx.pool.m_clonedCtx.opoConRefCtx.dbName = opoConCtx.opoConRefCtx.dbName;
						opoConCtx.pool.m_clonedCtx.opoConRefCtx.hostName = opoConCtx.opoConRefCtx.hostName;
						opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName = opoConCtx.opoConRefCtx.instanceName;
						opoConCtx.pool.m_clonedCtx.opoConRefCtx.dbDomainName = opoConCtx.opoConRefCtx.dbDomainName;
					}
				}
			}
			cPCtx = (CPCtx)rLBCtx.htConToInst[opoConCtx.conString];
			if (cPCtx == null)
			{
				lock (rLBCtx.htConToInst.SyncRoot)
				{
					if (rLBCtx.htConToInst[opoConCtx.conString] == null)
					{
						try
						{
							cPCtx = new CPCtx(opoConCtx.maxPoolSize, rLBCtx, opoConCtx.poolRegulator);
							flag = true;
						}
						catch
						{
							num = -1;
						}
						if (opoConCtx.m_systemTransaction != null)
						{
							opoConCtx.m_txnid = opoConCtx.m_systemTransaction.TransactionInformation.LocalIdentifier;
							cPCtx.m_htTxnIdToIntance[opoConCtx.m_txnid] = opoConCtx.opoConRefCtx.instanceName;
						}
						if (num != -1)
						{
							rLBCtx.htConToInst[opoConCtx.conString] = cPCtx;
						}
					}
				}
			}
			if (num != -1)
			{
				opoConCtx.pool = (ConnectionPool)cPCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName];
			}
			if (opoConCtx.pool == null && num != -1)
			{
				lock (cPCtx.htInstToCp.SyncRoot)
				{
					if (cPCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] == null)
					{
						try
						{
							opoConCtx.pool = new ConnectionPool(opoConCtx, cPCtx);
							flag2 = true;
						}
						catch
						{
							num = -1;
						}
						if (num != -1)
						{
							cPCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] = opoConCtx.pool;
						}
					}
				}
			}
			if (num != 0)
			{
				OpoConValCtx* pOpoConValCtx3 = null;
				try
				{
					OpsCon.Close(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
				}
				catch (Exception ex7)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex7);
					}
				}
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
				{
					OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
				}
				try
				{
					if (opoConCtx.m_fetchArrayPooler != null)
					{
						opoConCtx.m_fetchArrayPooler.Dispose();
						opoConCtx.m_fetchArrayPooler = null;
					}
					OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref pOpoConValCtx3, opoConCtx.opoConRefCtx);
				}
				catch (Exception ex8)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex8);
					}
				}
				return num;
			}
			m_totalNumberOfConnectionPools++;
			OraTrace.Trace(2u, " (POOL) (AFFINITY) (Dispensed con for " + opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName + "; no affinity specified\n");
			if (OraTrace.m_TraceLevel != 0)
			{
				if (flag)
				{
					OraTrace.Trace(2u, " (POOL)  New CPCtx created (CPCtx id: " + cPCtx.GetHashCode() + ") for: [Attributes=\"" + opoConCtx.poolName + "\"] [Database=" + opoConCtx.opoConRefCtx.dbName + ";Service=" + opoConCtx.opoConRefCtx.serviceName + ";Host=" + opoConCtx.opoConRefCtx.hostName + "] (Inst CP id: " + opoConCtx.pool.GetHashCode() + ")\n");
				}
				if (flag2)
				{
					OraTrace.Trace(2u, " (POOL)  New CP created (CP id: " + opoConCtx.pool.GetHashCode() + "; CPCtx id: " + cPCtx.GetHashCode() + ") for: [Instance=" + opoConCtx.opoConRefCtx.instanceName + "]\n");
					OraTrace.Trace(2u, " (POOL)  Num of Inst CPs in (CPCtx id: " + cPCtx.GetHashCode() + ") : " + cPCtx.htInstToCp.Count + "\n");
				}
			}
		}
		else
		{
			try
			{
				opoConCtx.pool = new ConnectionPool(opoConCtx, null);
			}
			catch (Exception ex9)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex9);
				}
				num = ErrRes.INT_ERR;
				opoConCtx.exceptMsg = ex9.ToString();
			}
			finally
			{
				if (num != 0)
				{
					OpoConValCtx* pOpoConValCtx4 = null;
					try
					{
						OpsCon.Close(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
					}
					catch (Exception ex10)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex10);
						}
					}
					if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
					{
						OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
					}
					try
					{
						if (opoConCtx.m_fetchArrayPooler != null)
						{
							opoConCtx.m_fetchArrayPooler.Dispose();
							opoConCtx.m_fetchArrayPooler = null;
						}
						OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref pOpoConValCtx4, opoConCtx.opoConRefCtx);
					}
					catch (Exception ex11)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex11);
						}
					}
				}
			}
			if (num != 0)
			{
				return num;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(2u, " (POOL)  New connection pool created for: \"" + opoConCtx.poolName + "\" (id: " + opoConCtx.conString.GetHashCode() + ")\n");
				int num2 = ((m_ConnectionPools == null) ? 1 : m_ConnectionPools.Count);
				OraTrace.Trace(2u, " (POOL)  Total number of connection pools: " + num2 + "\n");
			}
		}
		opoConCtx.pool.UpdateTotalCount(1, bForPotential: true);
		int num3 = 1;
		if (opoConCtx.bGridRac)
		{
			if (opoConCtx.minPoolSize > opoConCtx.pool.m_cpCtx.m_counter.potentialTotal)
			{
				num3 = opoConCtx.minPoolSize - opoConCtx.pool.m_cpCtx.m_counter.potentialTotal;
			}
		}
		else
		{
			num3 = opoConCtx.minPoolSize - opoConCtx.pool.m_counter.potentialTotal;
		}
		if (num3 > 0)
		{
			opoConCtx.pool.UpdatePotentialTotalCount(num3);
			ThreadPool.QueueUserWorkItem(opoConCtx.pool.PopulatePool, num3);
		}
		if (opoConCtx.metaPool == 1)
		{
			if (opoConCtx.m_bSelfTuning)
			{
				opoConCtx.m_conPooler = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON);
				opoConCtx.m_udtDescPoolerByName = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON);
			}
			else
			{
				opoConCtx.m_conPooler = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_OFF);
				opoConCtx.m_udtDescPoolerByName = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_OFF);
			}
		}
		if (opoConCtx.m_bSelfTuning)
		{
			opoConCtx.m_udtDescPoolerByTDO = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON);
		}
		else
		{
			opoConCtx.m_udtDescPoolerByTDO = new ConPooler(ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_OFF);
		}
		return num;
	}

	public unsafe static int CopyPooledConCtx(ref OpoConValCtx* dst, OpoConValCtx* src)
	{
		int num = 0;
		try
		{
			if (dst == null)
			{
				num = OpsCon.AllocValCtx(ref dst);
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
		}
		if (num != 0)
		{
			return num;
		}
		dst->InMtsTxn = src->InMtsTxn;
		dst->OSAuthent = src->OSAuthent;
		dst->Pooling = src->Pooling;
		dst->ServerAttach = src->ServerAttach;
		dst->SessionBegin = src->SessionBegin;
		dst->TxnHndAllocated = src->TxnHndAllocated;
		dst->SetIntAndExtName = src->SetIntAndExtName;
		dst->DBAPrivilege = src->DBAPrivilege;
		dst->registerHA = src->registerHA;
		dst->registerRLB = src->registerRLB;
		dst->bTAFEnabled = src->bTAFEnabled;
		dst->StmtCachePurge = src->StmtCachePurge;
		dst->StmtCacheSize = src->StmtCacheSize;
		dst->PSPE = src->PSPE;
		dst->MajorVersion = src->MajorVersion;
		dst->MinorVersion = src->MinorVersion;
		dst->PatchSetVersion = src->PatchSetVersion;
		dst->DbNtfPort = src->DbNtfPort;
		dst->ConSignature = src->ConSignature;
		dst->bIsTimesTen = src->bIsTimesTen;
		return num;
	}

	public unsafe static int RegisterCallbacks(OpoConCtx opoConCtx)
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		if (!opoConCtx.bGridRac)
		{
			return 0;
		}
		string serverVersion = opoConCtx.opoConRefCtx.serverVersion;
		int num2 = serverVersion.IndexOf('.');
		int num3 = int.Parse(serverVersion.Substring(0, num2));
		if (num3 <= 10)
		{
			if (num3 != 10)
			{
				return 0;
			}
			int num4 = serverVersion.IndexOf('.', num2 + 1);
			int num5 = int.Parse(serverVersion.Substring(num2 + 1, num4 - (num2 + 1)));
			if (num5 < 2)
			{
				return 0;
			}
		}
		if (!m_bIsGlobalOCIEnvExists)
		{
			lock (s_lockObj)
			{
				if (!m_bIsGlobalOCIEnvExists)
				{
					try
					{
						num = OpsCon.InitSubscrEnv(m_HACallback, m_RLBCallback);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						num = ErrRes.INT_ERR;
						opoConCtx.exceptMsg = ex.ToString();
					}
					if (num == 0)
					{
						m_bIsGlobalOCIEnvExists = true;
					}
				}
			}
		}
		if (!m_bIsGlobalOCIEnvExists)
		{
			return num;
		}
		if (opoConCtx.gridCR == 1 && m_htHAOpoConCtx[opoConCtx.opoConRefCtx.dbName] == null)
		{
			flag = true;
		}
		if (opoConCtx.gridRLB == 1 && m_htRLBOpoConCtx[opoConCtx.opoConRefCtx.serviceName] == null)
		{
			flag2 = true;
		}
		if (flag || flag2)
		{
			opoConCtx.pOpoConValCtx->registerHA = 0;
			opoConCtx.pOpoConValCtx->registerRLB = 0;
			OpoConCtx opoConCtx2 = (OpoConCtx)opoConCtx.Clone();
			if (flag)
			{
				opoConCtx2.pOpoConValCtx->registerHA = 1;
			}
			if (flag2)
			{
				opoConCtx2.pOpoConValCtx->registerRLB = 1;
			}
			opoConCtx2.pOpoConValCtx->Enlist = 0;
			opoConCtx2.pOpoConValCtx->SetIntAndExtName = 0;
			opoConCtx2.pOpoConValCtx->Pooling = 0;
			try
			{
				num = OpsCon.RegisterCallbacks(ref opoConCtx2.opsConCtx, ref opoConCtx2.opsErrCtx, opoConCtx2.pOpoConValCtx, ref opoConCtx2.opoConRefCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				num = ErrRes.INT_ERR;
				opoConCtx.exceptMsg = ex2.ToString();
			}
			opoConCtx2.opoConRefCtx.dbName = opoConCtx.opoConRefCtx.dbName;
			opoConCtx2.opoConRefCtx.serviceName = opoConCtx.opoConRefCtx.serviceName;
			if (num == 0)
			{
				CallbackHashCtx callbackHashCtx = null;
				if (opoConCtx2.pOpoConValCtx->HASubscrHnd != IntPtr.Zero || opoConCtx2.pOpoConValCtx->RLBSubscrHnd != IntPtr.Zero)
				{
					callbackHashCtx = new CallbackHashCtx(opoConCtx2);
				}
				if (flag && opoConCtx2.pOpoConValCtx->HASubscrHnd == IntPtr.Zero)
				{
					opoConCtx.pOpoConValCtx->SessionBegin = opoConCtx2.pOpoConValCtx->reRegHAFailed;
					return 0;
				}
				opoConCtx2.pOpoConValCtx->reRegHAFailed = 0;
				if (flag2 && opoConCtx2.pOpoConValCtx->RLBSubscrHnd == IntPtr.Zero)
				{
					opoConCtx.pOpoConValCtx->SessionBegin = opoConCtx2.pOpoConValCtx->reRegRLBFailed;
					return 0;
				}
				opoConCtx2.pOpoConValCtx->reRegRLBFailed = 0;
				if (flag)
				{
					m_htHAOpoConCtx[opoConCtx.opoConRefCtx.dbName] = callbackHashCtx;
				}
				if (flag2)
				{
					m_htRLBOpoConCtx[opoConCtx.opoConRefCtx.serviceName] = callbackHashCtx;
				}
				if (flag && flag2)
				{
					callbackHashCtx.m_shared = true;
				}
			}
		}
		return num;
	}

	public unsafe static void ReRegisterCallbacks(object state)
	{
		int num = 0;
		try
		{
			IDictionaryEnumerator enumerator = m_htHAOpoConCtx.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Value == null)
				{
					continue;
				}
				OpoConCtx opoConCtxReg = ((CallbackHashCtx)enumerator.Value).m_opoConCtxReg;
				opoConCtxReg.pOpoConValCtx->registerHA = 1;
				if (((CallbackHashCtx)enumerator.Value).m_shared)
				{
					opoConCtxReg.pOpoConValCtx->registerRLB = 1;
				}
				else
				{
					opoConCtxReg.pOpoConValCtx->registerRLB = 0;
				}
				try
				{
					num = OpsCon.ReRegisterCallbacks(ref opoConCtxReg.opsConCtx, ref opoConCtxReg.opsErrCtx, opoConCtxReg.pOpoConValCtx, ref opoConCtxReg.opoConRefCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num = ErrRes.INT_ERR;
				}
				if (num != 0)
				{
					continue;
				}
				if (opoConCtxReg.pOpoConValCtx->HASubscrHnd == IntPtr.Zero)
				{
					opoConCtxReg.pOpoConValCtx->reRegHAFailed = 1;
				}
				else
				{
					opoConCtxReg.pOpoConValCtx->reRegHAFailed = 0;
				}
				if (opoConCtxReg.pOpoConValCtx->registerRLB == 1)
				{
					if (opoConCtxReg.pOpoConValCtx->RLBSubscrHnd == IntPtr.Zero)
					{
						opoConCtxReg.pOpoConValCtx->reRegRLBFailed = 1;
					}
					else
					{
						opoConCtxReg.pOpoConValCtx->reRegRLBFailed = 0;
					}
				}
			}
		}
		catch
		{
		}
		try
		{
			IDictionaryEnumerator enumerator2 = m_htRLBOpoConCtx.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				if (enumerator2.Value == null)
				{
					continue;
				}
				OpoConCtx opoConCtxReg2 = ((CallbackHashCtx)enumerator2.Value).m_opoConCtxReg;
				opoConCtxReg2.pOpoConValCtx->registerHA = 0;
				if (((CallbackHashCtx)enumerator2.Value).m_shared)
				{
					continue;
				}
				opoConCtxReg2.pOpoConValCtx->registerRLB = 1;
				try
				{
					num = OpsCon.ReRegisterCallbacks(ref opoConCtxReg2.opsConCtx, ref opoConCtxReg2.opsErrCtx, opoConCtxReg2.pOpoConValCtx, ref opoConCtxReg2.opoConRefCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
					num = ErrRes.INT_ERR;
				}
				if (num == 0)
				{
					if (opoConCtxReg2.pOpoConValCtx->RLBSubscrHnd == IntPtr.Zero)
					{
						opoConCtxReg2.pOpoConValCtx->reRegRLBFailed = 1;
					}
					else
					{
						opoConCtxReg2.pOpoConValCtx->reRegRLBFailed = 0;
					}
				}
			}
		}
		catch
		{
		}
	}

	public static int OnHACallback(OpoHACtx opoHACtx)
	{
		if (opoHACtx != null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(16u, string.Concat(" (HA)    Event=", opoHACtx.eventType, ";Database=", opoHACtx.dbName, ";Service=", opoHACtx.serviceName, ";Instance=", opoHACtx.instName, ";Host=", opoHACtx.hostName, "\n"));
			}
			Thread thread = new Thread(opoHACtx.Process);
			thread.Start();
		}
		return 0;
	}

	public static void HACallbackProcessing(object state)
	{
		int num = 0;
		ArrayList arrayList = new ArrayList(16);
		ConnectionPool connectionPool = null;
		OpoHACtx opoHACtx = (OpoHACtx)state;
		OracleHAEventArgs parameter = new OracleHAEventArgs(opoHACtx);
		Thread thread = new Thread(OracleConnection.OnHAEvent);
		thread.Start(parameter);
		try
		{
			lock (s_haEventObj)
			{
				object syncRoot = default(object);
				RLBCtx obj = default(RLBCtx);
				if (opoHACtx.eventType == HAEventType.ServiceDown)
				{
					RLBCtx rLBCtx = null;
					bool lockTaken = false;
					try
					{
						Monitor.Enter(syncRoot = m_htSvcToRLB.SyncRoot, ref lockTaken);
						rLBCtx = (RLBCtx)m_htSvcToRLB[opoHACtx.serviceName];
						if (rLBCtx != null)
						{
							m_htSvcToRLB.Remove(opoHACtx.serviceName);
						}
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(syncRoot);
						}
					}
					CPCtx[] array = null;
					int num2 = 0;
					if (rLBCtx != null)
					{
						lock (rLBCtx.htConToInst.SyncRoot)
						{
							IDictionaryEnumerator enumerator = rLBCtx.htConToInst.GetEnumerator();
							array = new CPCtx[rLBCtx.htConToInst.Count];
							while (enumerator.MoveNext())
							{
								array[num2] = (CPCtx)enumerator.Value;
								array[num2].m_timer.Dispose();
								num2++;
							}
						}
					}
					if (array != null)
					{
						for (num2 = 0; num2 < array.Length; num2++)
						{
							lock (array[num2].htInstToCp.SyncRoot)
							{
								IDictionaryEnumerator enumerator2 = array[num2].htInstToCp.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									connectionPool = (ConnectionPool)enumerator2.Value;
									connectionPool.m_clonedCtx.lifeTime = new TimeSpan(1L);
									connectionPool.m_clonedCtx.minPoolSize = 0;
									connectionPool.m_clonedCtx.poolDecSize = connectionPool.m_clonedCtx.maxPoolSize;
									arrayList.Insert(num++, connectionPool);
								}
							}
						}
					}
				}
				else if (opoHACtx.eventType == HAEventType.ServiceMemberDown)
				{
					RLBCtx rLBCtx2 = (RLBCtx)m_htSvcToRLB[opoHACtx.serviceName];
					if (rLBCtx2 != null)
					{
						bool lockTaken2 = false;
						try
						{
							Monitor.Enter(obj = rLBCtx2, ref lockTaken2);
							rLBCtx2.RLBMetricsList = null;
						}
						finally
						{
							if (lockTaken2)
							{
								Monitor.Exit(obj);
							}
						}
						CPCtx[] array2 = null;
						int num3 = 0;
						lock (rLBCtx2.htConToInst.SyncRoot)
						{
							IDictionaryEnumerator enumerator3 = rLBCtx2.htConToInst.GetEnumerator();
							array2 = new CPCtx[rLBCtx2.htConToInst.Count];
							while (enumerator3.MoveNext())
							{
								array2[num3] = (CPCtx)enumerator3.Value;
								num3++;
							}
						}
						if (array2 != null)
						{
							for (num3 = 0; num3 < array2.Length; num3++)
							{
								connectionPool = (ConnectionPool)array2[num3].htInstToCp[opoHACtx.instName];
								if (connectionPool == null)
								{
									continue;
								}
								lock (array2[num3].htInstToCp.SyncRoot)
								{
									connectionPool = (ConnectionPool)array2[num3].htInstToCp[opoHACtx.instName];
									if (connectionPool != null)
									{
										array2[num3].htInstToCp.Remove(opoHACtx.instName);
									}
								}
								if (connectionPool != null)
								{
									connectionPool.m_clonedCtx.lifeTime = new TimeSpan(1L);
									connectionPool.m_clonedCtx.minPoolSize = 0;
									connectionPool.m_clonedCtx.poolDecSize = connectionPool.m_clonedCtx.maxPoolSize;
									arrayList.Insert(num++, connectionPool);
								}
							}
						}
					}
				}
				else if (opoHACtx.eventType == HAEventType.NodeDown)
				{
					RLBCtx[] array3 = null;
					bool[] array4 = null;
					int num4 = 0;
					CPCtx[] array5 = null;
					int num5 = 0;
					lock (m_htSvcToRLB.SyncRoot)
					{
						IDictionaryEnumerator enumerator4 = m_htSvcToRLB.GetEnumerator();
						array3 = new RLBCtx[m_htSvcToRLB.Count];
						array4 = new bool[m_htSvcToRLB.Count];
						while (enumerator4.MoveNext())
						{
							array4[num4] = false;
							array3[num4] = (RLBCtx)enumerator4.Value;
							num4++;
						}
					}
					if (array3 != null)
					{
						for (num4 = 0; num4 < array3.Length; num4++)
						{
							lock (array3[num4].htConToInst.SyncRoot)
							{
								IDictionaryEnumerator enumerator5 = array3[num4].htConToInst.GetEnumerator();
								array5 = new CPCtx[array3[num4].htConToInst.Count];
								num5 = 0;
								while (enumerator5.MoveNext())
								{
									array5[num5] = (CPCtx)enumerator5.Value;
									num5++;
								}
							}
							if (array5 == null)
							{
								continue;
							}
							for (num5 = 0; num5 < array5.Length; num5++)
							{
								lock (array5[num5].htInstToCp.SyncRoot)
								{
									ArrayList arrayList2 = new ArrayList();
									IDictionaryEnumerator enumerator6 = array5[num5].htInstToCp.GetEnumerator();
									while (enumerator6.MoveNext())
									{
										connectionPool = (ConnectionPool)enumerator6.Value;
										if (connectionPool.m_clonedCtx.opoConRefCtx.hostName == opoHACtx.hostName)
										{
											arrayList2.Add(enumerator6.Key);
											connectionPool.m_clonedCtx.lifeTime = new TimeSpan(1L);
											connectionPool.m_clonedCtx.minPoolSize = 0;
											connectionPool.m_clonedCtx.poolDecSize = connectionPool.m_clonedCtx.maxPoolSize;
											arrayList.Insert(num++, connectionPool);
										}
									}
									if (arrayList2.Count > 0)
									{
										for (int i = 0; i < arrayList2.Count; i++)
										{
											array5[num5].htInstToCp.Remove(arrayList2[i]);
										}
									}
								}
								if (array5[num5].m_rlbCtx != null)
								{
									lock (array5[num5].m_rlbCtx)
									{
										array5[num5].m_rlbCtx.RLBMetricsList = null;
									}
								}
							}
						}
					}
				}
				else if (opoHACtx.eventType == HAEventType.DatabaseDown)
				{
					RLBCtx[] array6 = null;
					bool[] array7 = null;
					int num6 = 0;
					CPCtx[] array8 = null;
					int num7 = 0;
					bool lockTaken3 = false;
					try
					{
						Monitor.Enter(syncRoot = m_htSvcToRLB.SyncRoot, ref lockTaken3);
						IDictionaryEnumerator enumerator7 = m_htSvcToRLB.GetEnumerator();
						array6 = new RLBCtx[m_htSvcToRLB.Count];
						array7 = new bool[m_htSvcToRLB.Count];
						while (enumerator7.MoveNext())
						{
							array7[num6] = false;
							array6[num6] = (RLBCtx)enumerator7.Value;
							num6++;
						}
					}
					finally
					{
						if (lockTaken3)
						{
							Monitor.Exit(syncRoot);
						}
					}
					if (array6 != null)
					{
						for (num6 = 0; num6 < array6.Length; num6++)
						{
							bool lockTaken4 = false;
							try
							{
								Monitor.Enter(syncRoot = array6[num6].htConToInst.SyncRoot, ref lockTaken4);
								IDictionaryEnumerator enumerator8 = array6[num6].htConToInst.GetEnumerator();
								array8 = new CPCtx[array6[num6].htConToInst.Count];
								num7 = 0;
								while (enumerator8.MoveNext())
								{
									array8[num7] = (CPCtx)enumerator8.Value;
									num7++;
								}
							}
							finally
							{
								if (lockTaken4)
								{
									Monitor.Exit(syncRoot);
								}
							}
							if (array8 == null)
							{
								continue;
							}
							for (num7 = 0; num7 < array8.Length; num7++)
							{
								bool lockTaken5 = false;
								try
								{
									Monitor.Enter(syncRoot = array8[num7].htInstToCp.SyncRoot, ref lockTaken5);
									ArrayList arrayList3 = new ArrayList();
									IDictionaryEnumerator enumerator9 = array8[num7].htInstToCp.GetEnumerator();
									while (enumerator9.MoveNext())
									{
										connectionPool = (ConnectionPool)enumerator9.Value;
										if (connectionPool.m_clonedCtx.opoConRefCtx.dbName == opoHACtx.dbName)
										{
											arrayList3.Add(enumerator9.Key);
											connectionPool.m_clonedCtx.lifeTime = new TimeSpan(1L);
											connectionPool.m_clonedCtx.minPoolSize = 0;
											connectionPool.m_clonedCtx.poolDecSize = connectionPool.m_clonedCtx.maxPoolSize;
											arrayList.Insert(num++, connectionPool);
										}
									}
									if (arrayList3.Count > 0)
									{
										for (int j = 0; j < arrayList3.Count; j++)
										{
											array8[num7].htInstToCp.Remove(arrayList3[j]);
										}
									}
								}
								finally
								{
									if (lockTaken5)
									{
										Monitor.Exit(syncRoot);
									}
								}
								if (array8[num7].m_rlbCtx == null)
								{
									continue;
								}
								bool lockTaken6 = false;
								try
								{
									Monitor.Enter(obj = array8[num7].m_rlbCtx, ref lockTaken6);
									array8[num7].m_rlbCtx.RLBMetricsList = null;
								}
								finally
								{
									if (lockTaken6)
									{
										Monitor.Exit(obj);
									}
								}
							}
						}
					}
				}
			}
			if (arrayList != null)
			{
				for (num = 0; num < arrayList.Count && arrayList[num] != null; num++)
				{
					((ConnectionPool)arrayList[num]).RegulateNumOfCons(-1);
				}
			}
		}
		catch
		{
		}
	}

	public static int OnRLBCallback(OpoRLBCtx opoRLBCtx)
	{
		int result = 0;
		string service;
		CaptureCollection instColl;
		CaptureCollection percColl;
		CaptureCollection flagColl;
		string timestamp;
		RLBMsgStatus rLBMsgStatus = ParseRLBMessage(opoRLBCtx.metrics, out service, out instColl, out percColl, out flagColl, out timestamp);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(32u, " (RLB)   Message Received=" + opoRLBCtx.metrics + "\n");
			OraTrace.Trace(32u, string.Concat(" (RLB)   Message Status=", rLBMsgStatus, "\n"));
		}
		lock (m_htSvcToRLB.SyncRoot)
		{
			RLBCtx rLBCtx = null;
			if (service != null)
			{
				rLBCtx = (RLBCtx)m_htSvcToRLB[service];
			}
			else
			{
				OraTrace.Trace(32u, " (RLB)   Message Not Processed=" + opoRLBCtx.metrics + "\n");
			}
			if (rLBCtx != null && rLBMsgStatus == RLBMsgStatus.GOOD && string.Compare(timestamp, rLBCtx.timeStamp) > 0)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(32u, " (RLB)   Service=" + service + ";Timestamp=" + timestamp + "\n");
					for (int i = 0; i < instColl.Count; i++)
					{
						OraTrace.Trace(32u, " (RLB)   Instance=" + instColl[i].Value.ToLower() + ";Percentage=" + percColl[i].Value + ";Flag=" + flagColl[i].Value + "\n");
					}
				}
				rLBCtx.timeStamp = timestamp;
				ArrayList arrayList = new ArrayList();
				double num = 0.0;
				double num2 = 0.0;
				double val = 0.0;
				for (int j = 0; j < instColl.Count; j++)
				{
					RLBMetricsFlag metricsEnum = GetMetricsEnum(flagColl[j].Value);
					double num3 = Convert.ToDouble(percColl[j].Value);
					arrayList.Add(new RLBMetrics(instColl[j].Value.ToLower(), num3, (num3 == 0.0) ? 1073741822 : ((int)(1000.0 / num3)), metricsEnum));
					val = Math.Max(val, num3);
					num += num3;
					if (instColl.Count > 2)
					{
						num2 += Math.Pow(num3 - (double)(100 / instColl.Count), 2.0);
					}
				}
				if (!(num < 105.0) || !(num > 95.0) || !(rLBCtx.ServiceName == service))
				{
					lock (rLBCtx)
					{
						rLBCtx.RLBMetricsList = null;
					}
				}
				else
				{
					arrayList.Sort(s_metricsComparer);
					if (rLBCtx.RLBMetricsList != null && arrayList.Count < rLBCtx.RLBMetricsList.Count)
					{
						for (int k = 0; k < rLBCtx.RLBMetricsList.Count; k++)
						{
							bool flag = false;
							for (int l = 0; l < arrayList.Count; l++)
							{
								if (((RLBMetrics)arrayList[l]).InstanceName == ((RLBMetrics)rLBCtx.RLBMetricsList[k]).InstanceName)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								OraTrace.Trace(32u, " (GRID) (RLB) (GRAV) (gravitation due to change in # of entries in RLB msg");
								RLBGravitate(rLBCtx.ServiceName, ((RLBMetrics)rLBCtx.RLBMetricsList[k]).InstanceName);
							}
						}
					}
					if (rLBCtx.RLBMetricsList != null)
					{
						lock (rLBCtx)
						{
							rLBCtx.RLBMetricsList = arrayList;
						}
					}
					else
					{
						rLBCtx.RLBMetricsList = arrayList;
					}
					rLBCtx.bNeedNormalization = true;
				}
			}
		}
		return result;
	}

	public static void RLBGravitate(string ServiceName)
	{
		if (m_htSvcToRLB[ServiceName] == null)
		{
			return;
		}
		int num = 0;
		RLBCtx rLBCtx = (RLBCtx)m_htSvcToRLB[ServiceName];
		lock (rLBCtx.htConToInst.SyncRoot)
		{
			IDictionaryEnumerator enumerator = rLBCtx.htConToInst.GetEnumerator();
			while (enumerator.MoveNext())
			{
				CPCtx cPCtx = (CPCtx)enumerator.Value;
				num += (int)(0.15f * (float)cPCtx.m_counter.total);
				RLBGravitate(ServiceName, incrementPool: true, num);
			}
		}
	}

	public static void RLBGravitate(string ServiceName, string InstanceName)
	{
		int num = 0;
		int num2 = 0;
		ConnectionPool connectionPool = null;
		RLBCtx rLBCtx = (RLBCtx)m_htSvcToRLB[ServiceName];
		if (rLBCtx == null)
		{
			return;
		}
		lock (rLBCtx.htConToInst.SyncRoot)
		{
			IDictionaryEnumerator enumerator = rLBCtx.htConToInst.GetEnumerator();
			while (enumerator.MoveNext())
			{
				CPCtx cPCtx = (CPCtx)enumerator.Value;
				connectionPool = (ConnectionPool)cPCtx.htInstToCp[InstanceName];
				if (connectionPool == null)
				{
					continue;
				}
				num = (int)(0.25f * (float)connectionPool.m_cpCtx.m_counter.total);
				if (num > 0)
				{
					lock (connectionPool)
					{
						connectionPool.m_rlbGravCounter += num;
					}
					num2 = connectionPool.RegulateNumOfCons(num);
					connectionPool.UpdatePotentialTotalCount(num2);
					ThreadPool.QueueUserWorkItem(connectionPool.PopulatePool, num2);
					if ((OraTrace.m_TraceLevel & 0x20) == 32)
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append(" (GRID) (RLB) (GRAV) (inst=");
						stringBuilder.Append(InstanceName);
						stringBuilder.Append(") (rebalancing ");
						stringBuilder.Append(num2);
						stringBuilder.Append(" connections)\n");
						OraTrace.Trace(32u, stringBuilder.ToString());
					}
				}
			}
		}
	}

	public static void RLBGravitate(string ServiceName, bool incrementPool, int decrSize)
	{
		if (decrSize == 0)
		{
			return;
		}
		int num = 0;
		RLBCtx rLBCtx = (RLBCtx)m_htSvcToRLB[ServiceName];
		if (rLBCtx == null)
		{
			return;
		}
		lock (rLBCtx)
		{
			if (rLBCtx.RLBMetricsList == null || rLBCtx.RLBMetricsList.Count <= 0)
			{
				return;
			}
			lock (rLBCtx.htConToInst.SyncRoot)
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				RLBMetrics rLBMetrics = null;
				int[] array = new int[rLBCtx.RLBMetricsList.Count];
				int[] array2 = new int[rLBCtx.RLBMetricsList.Count];
				ConnectionPool[] array3 = new ConnectionPool[rLBCtx.RLBMetricsList.Count];
				int[] array4 = new int[rLBCtx.RLBMetricsList.Count];
				IDictionaryEnumerator enumerator = rLBCtx.htConToInst.GetEnumerator();
				int num6 = 0;
				while (enumerator.MoveNext())
				{
					ConnectionPool connectionPool = null;
					num2 = 0;
					num3 = 0;
					num5 = 0;
					CPCtx cPCtx = (CPCtx)enumerator.Value;
					lock (cPCtx.htInstToCp.SyncRoot)
					{
						IDictionaryEnumerator enumerator2 = cPCtx.htInstToCp.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							connectionPool = (ConnectionPool)enumerator2.Value;
							for (num6 = 0; num6 < rLBCtx.RLBMetricsList.Count && !(((RLBMetrics)rLBCtx.RLBMetricsList[num6]).InstanceName == connectionPool.m_clonedCtx.opoConRefCtx.instanceName); num6++)
							{
							}
							if (num6 < rLBCtx.RLBMetricsList.Count)
							{
								array3[num6] = connectionPool;
								array2[num6] = Math.Min(connectionPool.m_connections.Count, connectionPool.m_counter.total - connectionPool.m_clonedCtx.minPoolSize);
								num2 += array2[num6];
								num3 += ((RLBMetrics)rLBCtx.RLBMetricsList[num6]).MaxDistribFreq;
								array4[num6] = array3[num6].m_connections.Count;
								num5 += array4[num6];
								num6++;
								continue;
							}
							return;
						}
						int num7 = 0;
						int num8 = 0;
						num4 = 0;
						for (num6 = 0; num6 < rLBCtx.RLBMetricsList.Count; num6++)
						{
							rLBMetrics = (RLBMetrics)rLBCtx.RLBMetricsList[num6];
							if (rLBMetrics.Flag == RLBMetricsFlag.BLOCKED || rLBMetrics.Flag == RLBMetricsFlag.VIOLATING)
							{
								num7 += array2[num6];
								num8++;
							}
						}
						if (num7 >= decrSize)
						{
							int num9 = 0;
							for (num6 = 0; num6 < rLBCtx.RLBMetricsList.Count; num6++)
							{
								array[num6] = 0;
								if (rLBMetrics.Flag == RLBMetricsFlag.BLOCKED || rLBMetrics.Flag == RLBMetricsFlag.VIOLATING)
								{
									num9++;
								}
							}
							for (num6 = 0; num6 < rLBCtx.RLBMetricsList.Count; num6++)
							{
								rLBMetrics = (RLBMetrics)rLBCtx.RLBMetricsList[num6];
								if (rLBMetrics.Flag == RLBMetricsFlag.BLOCKED || rLBMetrics.Flag == RLBMetricsFlag.VIOLATING)
								{
									if (array2[num6] <= array3[num6].m_clonedCtx.poolIncSize)
									{
										array[num6] = 0;
									}
									else
									{
										array[num6] = Math.Min(array2[num6], num7 / num9);
									}
								}
							}
							for (num6 = 0; num6 < rLBCtx.RLBMetricsList.Count; num6++)
							{
								if (array3[num6] != null && array[num6] > 0)
								{
									array3[num6].RegulateNumOfCons(array[num6]);
									num4 += array2[num6];
								}
							}
						}
						else
						{
							for (num6 = 0; num6 < rLBCtx.RLBMetricsList.Count; num6++)
							{
								array[num6] = 0;
								rLBMetrics = (RLBMetrics)rLBCtx.RLBMetricsList[num6];
								if (rLBMetrics.Flag == RLBMetricsFlag.BLOCKED || rLBMetrics.Flag == RLBMetricsFlag.VIOLATING)
								{
									array[num6] = array2[num6];
									num4 += array2[num6];
								}
							}
							for (num6 = 0; num6 < rLBCtx.RLBMetricsList.Count; num6++)
							{
								rLBMetrics = (RLBMetrics)rLBCtx.RLBMetricsList[num6];
								if (rLBMetrics.Flag != RLBMetricsFlag.BLOCKED && rLBMetrics.Flag != RLBMetricsFlag.VIOLATING)
								{
									if (array3[num6] == null)
									{
										array[num6] = 0;
									}
									else if (array2[num6] <= array3[num6].m_clonedCtx.poolIncSize)
									{
										array[num6] = 0;
									}
									else if (Math.Abs((double)(array4[num6] * 100 / num5) - rLBMetrics.Percentage) <= 5.0)
									{
										array[num6] = 0;
									}
									else
									{
										array[num6] = (int)Math.Min(decrSize - num4, (double)(decrSize * rLBMetrics.MaxDistribFreq) / (double)num3);
									}
								}
							}
							for (num6 = 0; num6 < rLBCtx.RLBMetricsList.Count; num6++)
							{
								if (array3[num6] != null && array[num6] > 0)
								{
									num += array3[num6].RegulateNumOfCons(array[num6]);
									num4 += array[num6];
								}
							}
						}
					}
					if (num > 0)
					{
						if (incrementPool)
						{
							connectionPool.UpdatePotentialTotalCount(num);
							connectionPool.PopulatePool(num);
						}
						if ((OraTrace.m_TraceLevel & 0x20) == 32)
						{
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.Append(" (GRID) (RLB) (GRAV) (svc=");
							stringBuilder.Append(ServiceName);
							stringBuilder.Append(") (rebalanced ");
							stringBuilder.Append(num);
							stringBuilder.Append(" connections)\n");
							OraTrace.Trace(32u, stringBuilder.ToString());
						}
					}
				}
			}
		}
	}

	private static RLBMsgStatus ParseRLBMessage(string message, out string service, out CaptureCollection instColl, out CaptureCollection percColl, out CaptureCollection flagColl, out string timestamp)
	{
		RLBMsgStatus result = RLBMsgStatus.GOOD;
		if (message != null && message.Length != 0)
		{
			Regex regex = new Regex(s_pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			Match match = regex.Match(message);
			service = match.Groups["svc"].Value.ToLower();
			instColl = match.Groups["inst"].Captures;
			percColl = match.Groups["perc"].Captures;
			flagColl = match.Groups["flag"].Captures;
			timestamp = match.Groups["ts"].Value;
			if (instColl.Count == 0 || percColl.Count == 0 || flagColl.Count == 0 || match.Groups["svc"].Captures.Count == 0)
			{
				result = RLBMsgStatus.BAD_FORMAT;
			}
			else if (instColl.Count != percColl.Count || percColl.Count != flagColl.Count)
			{
				result = RLBMsgStatus.MISSING_PAIR;
			}
			else if (service != null && service.Length == 0)
			{
				result = RLBMsgStatus.MISSING_SVC;
			}
			else if (timestamp != null && timestamp.Length == 0)
			{
				timestamp = "Unknown";
			}
		}
		else
		{
			result = RLBMsgStatus.EMPTY;
			service = null;
			instColl = null;
			percColl = null;
			flagColl = null;
			timestamp = null;
		}
		return result;
	}

	internal static RLBMetricsFlag GetMetricsEnum(string s)
	{
		string[] names = Enum.GetNames(typeof(RLBMetricsFlag));
		RLBMetricsFlag result = RLBMetricsFlag.UNKNOWN;
		for (int i = 0; i < names.Length; i++)
		{
			if (string.Compare(s, names[i]) == 0)
			{
				result = (RLBMetricsFlag)i;
			}
		}
		return result;
	}

	public static void ClearPool(OpoConCtx opoConCtx, bool bInvalidOnly, bool bRefresh)
	{
		if (opoConCtx.bGridRac)
		{
			RLBCtx rLBCtx = null;
			CPCtx cPCtx = null;
			string key = (string)m_htTnsToSvc[opoConCtx.dataSrc];
			rLBCtx = (RLBCtx)m_htSvcToRLB[key];
			cPCtx = (CPCtx)rLBCtx.htConToInst[opoConCtx.conString];
			lock (cPCtx.htInstToCp.SyncRoot)
			{
				IDictionaryEnumerator enumerator = cPCtx.htInstToCp.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ConnectionPool connectionPool = (ConnectionPool)enumerator.Value;
					connectionPool.ClearPool(bInvalidOnly, bRefresh);
				}
				return;
			}
		}
		opoConCtx.pool.ClearPool(bInvalidOnly, bRefresh);
	}

	public static void ClearAllPools()
	{
		if (m_htSvcToRLB != null && 0 < m_htSvcToRLB.Count)
		{
			lock (m_htSvcToRLB.SyncRoot)
			{
				IDictionaryEnumerator enumerator = m_htSvcToRLB.GetEnumerator();
				while (enumerator.MoveNext())
				{
					RLBCtx rLBCtx = (RLBCtx)enumerator.Value;
					lock (rLBCtx.htConToInst.SyncRoot)
					{
						IDictionaryEnumerator enumerator2 = rLBCtx.htConToInst.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							CPCtx cPCtx = (CPCtx)enumerator2.Value;
							lock (cPCtx.htInstToCp.SyncRoot)
							{
								IDictionaryEnumerator enumerator3 = cPCtx.htInstToCp.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									ConnectionPool connectionPool = (ConnectionPool)enumerator3.Value;
									connectionPool.ClearPool(bInvalidOnly: false, bRefresh: false);
								}
							}
						}
					}
				}
			}
		}
		if (m_ConnectionPools != null && m_ConnectionPools.Count > 0)
		{
			IDictionaryEnumerator enumerator4 = m_ConnectionPools.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				((ConnectionPool)enumerator4.Value)?.ClearPool(bInvalidOnly: false, bRefresh: false);
			}
		}
	}
}
