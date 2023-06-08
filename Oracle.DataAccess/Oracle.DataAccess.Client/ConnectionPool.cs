using System;
using System.Collections;
using System.EnterpriseServices;
using System.Security.Principal;
using System.Threading;

namespace Oracle.DataAccess.Client;

internal class ConnectionPool
{
	internal const int DEFAULT_STMT_CACHE_SIZE_WITH_SELF_TUNING = 30;

	public const int WAIT_ABAONDONED = 128;

	public const int WAIT_OBJECT_0 = 0;

	public const int WAIT_TIMEOUT = 258;

	public const int WAIT_FAILED = -1;

	internal int m_agentKey = -1;

	internal int m_poolId = -1;

	internal int m_scsRecommendations = 30;

	internal int m_stmtSamplesLimit;

	public Stack m_connections;

	public ResourcePool m_mtsConnections;

	public OracleResourcePool m_oraResPool;

	public IntPtr m_semAvaNumOfCons;

	public Timer m_timer;

	public OpoConCtx m_clonedCtx;

	public Counter m_counter;

	private bool m_skipDecrement;

	public CPCtx m_cpCtx;

	public int m_rlbGravCounter;

	public float m_attemptedRequests;

	public bool m_bSynchronizeStack;

	public bool m_bClearPoolInProgress;

	public int m_consFromAppToClear;

	public bool m_bGridRac;

	public EncryptedPassword m_encryptedPwd;

	public EncryptedPassword m_encryptedPxyPwd;

	private bool m_inactive;

	private static object m_populationSyncObj = new object();

	public object m_passwordSyncObj = new object();

	public DateTime m_clearRequestTimeStamp;

	private WindowsIdentity m_identity;

	public ConnectionPool(OpoConCtx opoConCtx, CPCtx cpCtx)
		: this(opoConCtx, cpCtx, null)
	{
	}

	public unsafe ConnectionPool(OpoConCtx opoConCtx, CPCtx cpCtx, WindowsIdentity identity)
	{
		try
		{
			m_poolId = opoConCtx.conString.GetHashCode();
			if (opoConCtx.m_bSelfTuning)
			{
				m_stmtSamplesLimit = 1000;
				OracleTuningAgent.Register(opoConCtx.conString, opoConCtx.poolName, m_poolId, UpdateAgentRecommendations, IncrementStmtSamplesLimit, out m_agentKey);
				if (-1 == m_agentKey)
				{
					opoConCtx.m_bSelfTuning = false;
				}
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(64u, "(ERROR) ConnectionPool::ConnectionPool(): Pool " + opoConCtx.conString + "; Exception: " + ex.ToString() + " \n");
			}
		}
		m_scsRecommendations = opoConCtx.pOpoConValCtx->StmtCacheSize;
		m_connections = Stack.Synchronized(new Stack(opoConCtx.minPoolSize));
		m_cpCtx = cpCtx;
		if (Environment.OSVersion.Version.Major <= 4)
		{
			opoConCtx.pOpoConValCtx->Enlist = 0;
		}
		else
		{
			m_oraResPool = new OracleResourcePool(TransactionEnd);
			m_mtsConnections = new ResourcePool(TransactionEnd);
		}
		try
		{
			m_semAvaNumOfCons = OpsCon.CreateSemaphore(IntPtr.Zero, 0, opoConCtx.maxPoolSize, "");
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		m_identity = null;
		try
		{
			if (opoConCtx.pOpoConValCtx->OSAuthent == 1 || opoConCtx.pOpoConValCtx->OSAuthent == 2)
			{
				if (identity != null)
				{
					m_identity = identity;
				}
				else
				{
					m_identity = WindowsIdentity.GetCurrent();
				}
			}
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(2u, " (POOL) (ERROR) ConnectionPool::ConnectionPool(): Pool: " + opoConCtx.poolName + "; Exception: " + ex3.ToString() + " \n");
			}
		}
		m_clonedCtx = (OpoConCtx)opoConCtx.Clone();
		if (opoConCtx.opoConRefCtx.password != null && opoConCtx.opoConRefCtx.password != string.Empty)
		{
			m_encryptedPwd = new EncryptedPassword(opoConCtx.opoConRefCtx.password);
		}
		if (opoConCtx.opoConRefCtx.proxyPassword != null && opoConCtx.opoConRefCtx.proxyPassword != string.Empty)
		{
			m_encryptedPxyPwd = new EncryptedPassword(opoConCtx.opoConRefCtx.proxyPassword);
		}
		m_clonedCtx.opoConRefCtx.password = null;
		m_clonedCtx.opoConRefCtx.proxyPassword = null;
		m_bGridRac = m_clonedCtx.bGridRac;
		m_clonedCtx.pOpoConValCtx->Pooling = opoConCtx.pOpoConValCtx->Pooling;
		m_clonedCtx.pOpoConValCtx->DBAPrivilege = opoConCtx.pOpoConValCtx->DBAPrivilege;
		m_clonedCtx.pOpoConValCtx->SetIntAndExtName = opoConCtx.pOpoConValCtx->SetIntAndExtName;
		if (m_cpCtx == null)
		{
			m_timer = new Timer(RegulateNumOfConsThreadFunc, null, opoConCtx.poolRegulator * 1000, opoConCtx.poolRegulator * 1000);
		}
		m_counter = new Counter(bOwnedByCPCtx: false);
		m_skipDecrement = true;
		if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnectionPools) == PerfCounterLevel.NumberOfActiveConnectionPools)
		{
			OraclePerfCounterCollection.NumberOfActiveConnectionPools.Increment();
		}
	}

	~ConnectionPool()
	{
		Dispose();
	}

	public void ResetPasswords(string password, string proxyPassword)
	{
		if (m_encryptedPwd != null)
		{
			m_encryptedPwd.Dispose();
			m_encryptedPwd = null;
		}
		if (m_encryptedPxyPwd != null)
		{
			m_encryptedPxyPwd.Dispose();
			m_encryptedPxyPwd = null;
		}
		if (password != null && password != string.Empty)
		{
			m_encryptedPwd = new EncryptedPassword(password);
		}
		if (proxyPassword != null && proxyPassword != string.Empty)
		{
			m_encryptedPxyPwd = new EncryptedPassword(proxyPassword);
		}
	}

	private unsafe void Dispose()
	{
		try
		{
			if (m_agentKey != -1)
			{
				OracleTuningAgent.Unregister(m_agentKey);
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(64u, "(ERROR) ConnectionPool::Dispose(): Pool Id: " + m_poolId + "; Exception: " + ex.ToString() + " \n");
			}
		}
		try
		{
			if (m_semAvaNumOfCons != IntPtr.Zero)
			{
				try
				{
					OpsCon.CloseHandle(m_semAvaNumOfCons);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
				m_semAvaNumOfCons = IntPtr.Zero;
			}
			if (m_encryptedPwd != null)
			{
				try
				{
					m_encryptedPwd.Dispose();
				}
				finally
				{
					m_encryptedPwd = null;
				}
			}
			if (m_encryptedPxyPwd != null)
			{
				try
				{
					m_encryptedPxyPwd.Dispose();
				}
				finally
				{
					m_encryptedPxyPwd = null;
				}
			}
			if (m_clonedCtx != null && m_clonedCtx.pOpoConValCtx != null)
			{
				try
				{
					OpsCon.FreeValCtx(ref m_clonedCtx.pOpoConValCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
				}
			}
			int count = m_connections.Count;
			while (m_connections.Count > 0)
			{
				PooledConCtx pooledConCtx = null;
				if (m_cpCtx != null)
				{
					Interlocked.Decrement(ref m_cpCtx.totalAvaliableConnections);
				}
				if (m_bSynchronizeStack)
				{
					lock (m_connections.SyncRoot)
					{
						pooledConCtx = (PooledConCtx)m_connections.Pop();
					}
				}
				else
				{
					pooledConCtx = (PooledConCtx)m_connections.Pop();
				}
				pooledConCtx.m_conPooler = null;
				pooledConCtx.m_udtDescPoolerByName = null;
				pooledConCtx.m_udtDescPoolerByTDO = null;
				try
				{
					if (pooledConCtx.m_fetchArrayPooler != null)
					{
						pooledConCtx.m_fetchArrayPooler.Dispose();
						pooledConCtx.m_fetchArrayPooler = null;
					}
					OpsCon.Dispose(ref pooledConCtx.opsConCtx, ref pooledConCtx.opsErrCtx, ref pooledConCtx.pOpoConValCtx, pooledConCtx.opoConRefCtx);
				}
				catch (Exception ex4)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex4);
					}
				}
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
				{
					OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
				}
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfFreeConnections) == PerfCounterLevel.NumberOfFreeConnections)
			{
				OraclePerfCounterCollection.NumberOfFreeConnections.IncrementBy(-1 * count);
			}
		}
		catch
		{
		}
		if (m_inactive)
		{
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfInactiveConnectionPools) == PerfCounterLevel.NumberOfInactiveConnectionPools)
			{
				OraclePerfCounterCollection.NumberOfInactiveConnectionPools.Decrement();
			}
		}
		else if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnectionPools) == PerfCounterLevel.NumberOfActiveConnectionPools)
		{
			OraclePerfCounterCollection.NumberOfActiveConnectionPools.Decrement();
		}
		GC.SuppressFinalize(this);
	}

	public unsafe void PopulatePool(object state)
	{
		int num = 0;
		int num2 = (int)state;
		int num3 = 0;
		int num4 = 0;
		WindowsImpersonationContext windowsImpersonationContext = null;
		try
		{
			if (OraTrace.m_CPThreadPrioritization == 1)
			{
				Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
			}
		}
		catch
		{
			OraTrace.m_CPThreadPrioritization = 0;
		}
		try
		{
			if (m_identity != null)
			{
				try
				{
					if (WindowsIdentity.GetCurrent() != m_identity)
					{
						windowsImpersonationContext = m_identity.Impersonate();
					}
				}
				catch (Exception ex)
				{
					windowsImpersonationContext = null;
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(2u, " (POOL) (ERROR) ConnectionPool::PopulatePool(): Pool (id: " + m_clonedCtx.conString.GetHashCode() + "); Exception: " + ex.ToString() + " \n");
					}
					throw;
				}
			}
			ConnectionPool connectionPool = this;
			if ((m_bGridRac && m_cpCtx.m_counter.total < m_clonedCtx.maxPoolSize) || (!m_bGridRac && m_counter.total < m_clonedCtx.maxPoolSize))
			{
				for (int i = 0; i < num2; i++)
				{
					lock (m_populationSyncObj)
					{
						if (m_bGridRac)
						{
							if (m_cpCtx.m_counter.total < m_clonedCtx.maxPoolSize)
							{
								goto IL_0174;
							}
						}
						else if (m_counter.total < m_clonedCtx.maxPoolSize)
						{
							goto IL_0174;
						}
						goto end_IL_011e;
						IL_0174:
						try
						{
							OpoConCtx opoConCtx = (OpoConCtx)m_clonedCtx.Clone();
							lock (m_passwordSyncObj)
							{
								if (m_encryptedPwd != null)
								{
									opoConCtx.opoConRefCtx.password = m_encryptedPwd.Password;
								}
								else
								{
									opoConCtx.opoConRefCtx.password = "";
								}
								if (m_encryptedPxyPwd != null)
								{
									opoConCtx.opoConRefCtx.proxyPassword = m_encryptedPxyPwd.Password;
								}
								else
								{
									opoConCtx.opoConRefCtx.proxyPassword = "";
								}
							}
							if (opoConCtx.m_bSelfTuning)
							{
								opoConCtx.pOpoConValCtx->StmtCacheSize = m_scsRecommendations;
								if (opoConCtx.pOpoConValCtx->StmtCacheSize > OraTrace.MaxStatementCacheSize)
								{
									opoConCtx.pOpoConValCtx->StmtCacheSize = OraTrace.MaxStatementCacheSize;
								}
							}
							num = OpsCon.Open(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, ref opoConCtx.opoConRefCtx);
							opoConCtx.opoConRefCtx.password = null;
							opoConCtx.opoConRefCtx.proxyPassword = null;
							if (num == 0 && (OraTrace.m_PerformanceCounters & PerfCounterLevel.HardConnectsPerSecond) == PerfCounterLevel.HardConnectsPerSecond)
							{
								OraclePerfCounterCollection.HardConnectsPerSecond.Increment();
							}
							if (opoConCtx.metaPool == 1)
							{
								if (opoConCtx.m_bSelfTuning)
								{
									int maxElemsInPool = ((opoConCtx.pOpoConValCtx->StmtCacheSize > ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON) ? opoConCtx.pOpoConValCtx->StmtCacheSize : ConPooler.DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON);
									opoConCtx.m_conPooler = new ConPooler(maxElemsInPool);
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
							if (num == 0 && m_clonedCtx.opoConRefCtx.dbName == null)
							{
								m_clonedCtx.opoConRefCtx.dbName = opoConCtx.opoConRefCtx.dbName;
								m_clonedCtx.opoConRefCtx.hostName = opoConCtx.opoConRefCtx.hostName;
								m_clonedCtx.opoConRefCtx.serviceName = opoConCtx.opoConRefCtx.serviceName;
								m_clonedCtx.opoConRefCtx.dbDomainName = opoConCtx.opoConRefCtx.dbDomainName;
							}
							if (num == 0 && (num = ConnectionDispenser.RegisterCallbacks(opoConCtx)) != 0)
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
							if (num == 0)
							{
								goto IL_0517;
							}
							if (opoConCtx.validateCon == 1)
							{
								continue;
							}
							lock (m_bGridRac ? m_cpCtx.m_counter : m_counter)
							{
								if ((m_bGridRac && m_cpCtx.m_counter.threadWait <= m_cpCtx.totalAvaliableConnections) || (!m_bGridRac && m_counter.threadWait <= m_counter.totalAvailable))
								{
									continue;
								}
								goto IL_0517;
							}
							IL_0517:
							opoConCtx.creationTime = DateTime.Now;
							m_skipDecrement = true;
							if (m_cpCtx != null)
							{
								m_cpCtx.m_cpCtxSkipDecrement = true;
							}
							bool flag = false;
							if (opoConCtx.pOpoConValCtx->SessionBegin == 1)
							{
								flag = true;
							}
							int num5;
							if (m_bGridRac)
							{
								lock (m_cpCtx.htInstToCp.SyncRoot)
								{
									if (m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] == null)
									{
										opoConCtx.opoConRefCtx.password = m_encryptedPwd.Password;
										connectionPool = new ConnectionPool(opoConCtx, m_cpCtx, m_identity);
										opoConCtx.opoConRefCtx.password = null;
										m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] = connectionPool;
										if (OraTrace.m_TraceLevel != 0)
										{
											OraTrace.Trace(2u, " (POOL)  New CP created (CP id: " + connectionPool.GetHashCode() + "; CPCtx id: " + m_cpCtx.GetHashCode() + ") for: [Instance=" + opoConCtx.opoConRefCtx.instanceName + "]\n");
											OraTrace.Trace(2u, " (POOL)  Num of Inst CPs in (CPCtx id: " + m_cpCtx.GetHashCode() + ") : " + m_cpCtx.htInstToCp.Count + "\n");
										}
									}
									else
									{
										connectionPool = (ConnectionPool)m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName];
									}
								}
								if (m_bSynchronizeStack)
								{
									lock (m_connections)
									{
										num5 = connectionPool.PutConnection(ref opoConCtx, bDoNotAllocValCtx: true, bCheckStatus: false, bCheckLifeTime: true, 0);
									}
								}
								else
								{
									num5 = connectionPool.PutConnection(ref opoConCtx, bDoNotAllocValCtx: true, bCheckStatus: false, bCheckLifeTime: true, 0);
								}
							}
							else
							{
								connectionPool = this;
								if (m_bSynchronizeStack)
								{
									lock (m_connections)
									{
										num5 = PutConnection(ref opoConCtx, bDoNotAllocValCtx: true, bCheckStatus: false, bCheckLifeTime: false, 0);
									}
								}
								else
								{
									num5 = PutConnection(ref opoConCtx, bDoNotAllocValCtx: true, bCheckStatus: false, bCheckLifeTime: false, 0);
								}
							}
							if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.SoftDisconnectsPerSecond) == PerfCounterLevel.SoftDisconnectsPerSecond)
							{
								OraclePerfCounterCollection.SoftDisconnectsPerSecond.Increment();
							}
							if (flag && num == 0 && num5 == 0)
							{
								connectionPool.UpdateTotalCount(1, bForPotential: false);
								if (connectionPool == this)
								{
									num3++;
								}
								else
								{
									connectionPool.m_counter.UpdatePotentialTotalCount(1);
								}
								num4++;
							}
						}
						catch (Exception ex4)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex4);
							}
						}
						continue;
						end_IL_011e:;
					}
					break;
				}
			}
			if (m_bGridRac && num2 - num4 > 0)
			{
				m_cpCtx.m_counter.UpdatePotentialTotalCount(num4 - num2);
			}
			if (num2 - num3 > 0)
			{
				m_counter.UpdatePotentialTotalCount(num3 - num2);
			}
		}
		finally
		{
			if (windowsImpersonationContext != null)
			{
				try
				{
					windowsImpersonationContext.Undo();
				}
				catch (Exception ex5)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(2u, " (POOL) (ERROR) ConnectionPool::PopulatePool(): Pool (id: " + m_clonedCtx.conString.GetHashCode() + "); Exception: " + ex5.ToString() + " \n");
					}
				}
				windowsImpersonationContext = null;
			}
		}
	}

	public void UpdateTotalCount(int val, bool bForPotential)
	{
		if (m_clonedCtx.bGridRac)
		{
			m_cpCtx.m_counter.UpdateTotalCount(this, val, bForPotential);
		}
		m_counter.UpdateTotalCount(this, val, bForPotential);
	}

	public void UpdatePotentialTotalCount(int val)
	{
		if (m_clonedCtx.bGridRac)
		{
			m_cpCtx.m_counter.UpdatePotentialTotalCount(val);
		}
		m_counter.UpdatePotentialTotalCount(val);
	}

	public void UpdateThreadWaitCount(int val)
	{
		m_counter.UpdateThreadWaitCount(this, val);
	}

	public void RegulateNumOfConsThreadFunc(object state)
	{
		RegulateNumOfCons(state);
	}

	public void GetDisposalInfo(int totDecrCount, ref ConnectionPool[] conPool, ref int[] consToClose)
	{
		conPool = null;
		consToClose = null;
		int[] array = null;
		int num = 0;
		int num2 = int.MaxValue;
		if (m_cpCtx == null || m_cpCtx.htInstToCp == null || m_cpCtx.htInstToCp.Count <= 0)
		{
			return;
		}
		int count = m_cpCtx.htInstToCp.Count;
		int num3 = (num3 = m_cpCtx.m_random.Next(0, count));
		lock (m_cpCtx.htInstToCp)
		{
			IDictionaryEnumerator enumerator = m_cpCtx.htInstToCp.GetEnumerator();
			conPool = new ConnectionPool[count];
			array = new int[count];
			while (enumerator.MoveNext())
			{
				conPool[num3] = (ConnectionPool)enumerator.Value;
				array[num3] = conPool[num3].m_connections.Count;
				num += array[num3];
				if (array[num3] < num2)
				{
					num2 = array[num3];
				}
				num3 = ++num3 % count;
			}
		}
		if (num <= totDecrCount)
		{
			consToClose = array;
			return;
		}
		int num4 = 0;
		int num5 = 0;
		consToClose = new int[count];
		if (num2 * count > totDecrCount)
		{
			num2 = totDecrCount / count;
			for (num4 = 0; num4 < count; num4++)
			{
				consToClose[num4] = num2;
				array[num4] -= num2;
				num5 += num2;
			}
		}
		for (num4 = 0; num4 < count * totDecrCount; num4++)
		{
			num3 = num4 % count;
			if (array[num3] > 0)
			{
				consToClose[num3]++;
				array[num3]--;
				num5++;
				if (num5 >= totDecrCount)
				{
					break;
				}
			}
		}
	}

	public unsafe int RegulateNumOfCons(object state)
	{
		bool flag = false;
		int num = 0;
		bool flag2 = state == null;
		bool bGridRac = m_clonedCtx.bGridRac;
		bool flag3 = false;
		try
		{
			if (m_cpCtx != null)
			{
				Monitor.Enter(m_cpCtx);
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			bool flag4 = false;
			if (bGridRac)
			{
				num2 = m_cpCtx.totalAvaliableConnections;
				num3 = m_cpCtx.m_counter.total;
				num4 = m_cpCtx.m_counter.potentialTotal;
				num5 = m_clonedCtx.origMinPoolSize;
				flag4 = m_cpCtx.m_cpCtxSkipDecrement;
			}
			else
			{
				num2 = m_connections.Count;
				num3 = m_counter.total;
				num4 = m_counter.potentialTotal;
				num5 = m_clonedCtx.minPoolSize;
				flag4 = m_skipDecrement;
			}
			if (num2 > 0 && (num3 > num5 || m_rlbGravCounter > 0 || (state != null && (int)state == -1)) && (!flag4 || state != null))
			{
				int num6 = 0;
				if (state != null)
				{
					lock (this)
					{
						if ((int)state == -1)
						{
							num6 = m_clonedCtx.maxPoolSize;
							flag3 = true;
						}
						else if (m_rlbGravCounter <= 0)
						{
							num6 = Math.Min((int)state, num3 - num5);
						}
						else if (m_rlbGravCounter > 0)
						{
							num6 = m_rlbGravCounter;
							m_rlbGravCounter = 0;
						}
					}
				}
				else
				{
					num6 = ((num2 >= m_clonedCtx.poolDecSize) ? m_clonedCtx.poolDecSize : num2);
					if (num3 - num6 < num5)
					{
						num6 = num3 - num5;
					}
				}
				bool flag5 = m_cpCtx != null && m_cpCtx.m_rlbCtx.RLBMetricsList != null && m_cpCtx.m_rlbCtx.RLBMetricsList.Count != 0;
				if (bGridRac && flag2 && !flag5)
				{
					ConnectionPool[] conPool = null;
					int[] consToClose = null;
					GetDisposalInfo(num6, ref conPool, ref consToClose);
					if (conPool != null)
					{
						for (int i = 0; i < conPool.Length; i++)
						{
							conPool[i].RegulateNumOfCons(consToClose[i]);
							conPool[i] = null;
						}
					}
				}
				else if (!bGridRac || !flag2 || !flag5)
				{
					for (int j = 0; j < num6; j++)
					{
						PooledConCtx pooledConCtx = null;
						try
						{
							int num7 = 0;
							if (bGridRac && m_cpCtx != null)
							{
								num7 = OpsCon.WaitForSingleObject(m_cpCtx.m_semCPCtxAvaNumOfCons, (int)m_clonedCtx.timeOut.TotalSeconds * 1000 * 2);
							}
							int num8 = OpsCon.WaitForSingleObject(m_semAvaNumOfCons, 0);
							if (num8 == 0 && num7 == 0)
							{
								if (bGridRac && m_cpCtx != null)
								{
									Interlocked.Decrement(ref m_cpCtx.totalAvaliableConnections);
								}
								Interlocked.Decrement(ref m_counter.totalAvailable);
								if (m_bSynchronizeStack)
								{
									lock (m_connections.SyncRoot)
									{
										pooledConCtx = (PooledConCtx)m_connections.Pop();
									}
								}
								else
								{
									pooledConCtx = (PooledConCtx)m_connections.Pop();
								}
								if (pooledConCtx != null && (OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfFreeConnections) == PerfCounterLevel.NumberOfFreeConnections)
								{
									OraclePerfCounterCollection.NumberOfFreeConnections.Decrement();
								}
								if (pooledConCtx.pOpoConValCtx->bTAFEnabled == 1)
								{
									ConnectionPool connectionPool = this;
									string instanceName = pooledConCtx.opoConRefCtx.instanceName;
									OpsCon.GetAttributes(pooledConCtx.opsConCtx, pooledConCtx.opsErrCtx, pooledConCtx.opoConRefCtx);
									if (instanceName != pooledConCtx.opoConRefCtx.instanceName)
									{
										OraTrace.Trace(16u, " (FO)    Failed over from " + instanceName + " to " + pooledConCtx.opoConRefCtx.instanceName + "\n");
										flag = true;
										connectionPool = (ConnectionPool)m_cpCtx.htInstToCp[pooledConCtx.opoConRefCtx.instanceName];
										if (connectionPool == null)
										{
											lock (m_cpCtx.htInstToCp.SyncRoot)
											{
												if (m_cpCtx.htInstToCp[pooledConCtx.opoConRefCtx.instanceName] == null)
												{
													OpoConCtx opoConCtx = new OpoConCtx();
													opoConCtx.pooledConCtx = pooledConCtx;
													opoConCtx.opsConCtx = pooledConCtx.opsConCtx;
													opoConCtx.opsErrCtx = pooledConCtx.opsErrCtx;
													opoConCtx.pOpoConValCtx = pooledConCtx.pOpoConValCtx;
													opoConCtx.opoConRefCtx = pooledConCtx.opoConRefCtx;
													connectionPool = new ConnectionPool(opoConCtx, m_cpCtx, m_identity);
													m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] = connectionPool;
													if (OraTrace.m_TraceLevel != 0)
													{
														OraTrace.Trace(2u, " (POOL)  New CP created (CP id: " + connectionPool.GetHashCode() + "; CPCtx id: " + connectionPool.m_cpCtx.GetHashCode() + ") for: [Instance=" + opoConCtx.opoConRefCtx.instanceName + "]\n");
														OraTrace.Trace(2u, " (POOL)  Num of Inst CPs in (CPCtx id: " + connectionPool.m_cpCtx.GetHashCode() + ") : " + connectionPool.m_cpCtx.htInstToCp.Count + "\n");
													}
												}
											}
										}
										if (m_bSynchronizeStack)
										{
											lock (connectionPool.m_connections.SyncRoot)
											{
												connectionPool.m_connections.Push(pooledConCtx);
											}
										}
										else
										{
											connectionPool.m_connections.Push(pooledConCtx);
										}
										if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfFreeConnections) == PerfCounterLevel.NumberOfFreeConnections)
										{
											OraclePerfCounterCollection.NumberOfFreeConnections.Increment();
										}
										if (bGridRac && connectionPool.m_cpCtx != null)
										{
											Interlocked.Increment(ref connectionPool.m_cpCtx.totalAvaliableConnections);
										}
										Interlocked.Increment(ref connectionPool.m_counter.totalAvailable);
										connectionPool.ReleaseSemaphore();
										Interlocked.Decrement(ref m_counter.total);
										Interlocked.Increment(ref connectionPool.m_counter.total);
									}
									else
									{
										num++;
										UpdateTotalCount(-1, bForPotential: true);
									}
								}
								else
								{
									num++;
									UpdateTotalCount(-1, bForPotential: true);
								}
							}
							else if (bGridRac && m_cpCtx != null && num7 == 0)
							{
								int PreviousCount = 0;
								OpsCon.ReleaseSemaphore(m_cpCtx.m_semCPCtxAvaNumOfCons, 1, ref PreviousCount);
							}
							else if (num8 == 0)
							{
								int PreviousCount2 = 0;
								OpsCon.ReleaseSemaphore(m_semAvaNumOfCons, 1, ref PreviousCount2);
							}
						}
						catch (Exception ex)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex);
							}
						}
						if (pooledConCtx == null)
						{
							break;
						}
						if (flag)
						{
							continue;
						}
						try
						{
							if (flag3)
							{
								pooledConCtx.pOpoConValCtx->HABasedConClose = 1;
							}
							if (pooledConCtx.m_fetchArrayPooler != null)
							{
								pooledConCtx.m_fetchArrayPooler.Dispose();
								pooledConCtx.m_fetchArrayPooler = null;
							}
							OpsCon.Dispose(ref pooledConCtx.opsConCtx, ref pooledConCtx.opsErrCtx, ref pooledConCtx.pOpoConValCtx, pooledConCtx.opoConRefCtx);
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
						}
						finally
						{
							if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
							{
								OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
							}
							pooledConCtx.opsConCtx = IntPtr.Zero;
							pooledConCtx.opsErrCtx = IntPtr.Zero;
							pooledConCtx.pOpoConValCtx = null;
							pooledConCtx.m_conPooler = null;
							pooledConCtx.m_udtDescPoolerByName = null;
							pooledConCtx.m_udtDescPoolerByTDO = null;
						}
					}
				}
			}
			else if (num3 == 0 && num2 == 0 && num5 == 0 && num4 == 0 && flag2)
			{
				if (!bGridRac)
				{
					lock (ConnectionDispenser.s_lockObj)
					{
						if (m_counter.total == 0 && m_connections.Count == 0 && m_clonedCtx.minPoolSize == 0 && m_counter.potentialTotal == 0)
						{
							ConnectionPool connectionPool2 = (ConnectionPool)ConnectionDispenser.m_ConnectionPools[m_clonedCtx.conString];
							ConnectionDispenser.m_ConnectionPools.Remove(m_clonedCtx.conString);
							connectionPool2.Dispose();
							DeriveParamInfo.m_pooler.RemovePool(m_clonedCtx.conString);
							m_timer.Dispose();
						}
					}
				}
				else
				{
					lock (m_cpCtx.m_rlbCtx.htConToInst.SyncRoot)
					{
						if (m_cpCtx.m_counter.total == 0 && m_cpCtx.totalAvaliableConnections == 0 && m_clonedCtx.origMinPoolSize == 0 && m_cpCtx.m_counter.potentialTotal == 0)
						{
							m_cpCtx.m_rlbCtx.htConToInst.Remove(m_clonedCtx.conString);
						}
						DeriveParamInfo.m_pooler.RemovePool(m_clonedCtx.conString);
						m_cpCtx.m_timer.Dispose();
					}
				}
			}
			else if (num4 < num5)
			{
				int num9 = ((num4 + m_clonedCtx.poolIncSize <= m_clonedCtx.maxPoolSize) ? m_clonedCtx.poolIncSize : (m_clonedCtx.maxPoolSize - num4));
				if (num9 > 0)
				{
					ThreadPool.QueueUserWorkItem(PopulatePool, num9);
					UpdatePotentialTotalCount(num9);
				}
			}
		}
		catch
		{
		}
		finally
		{
			if (m_cpCtx != null)
			{
				Monitor.Exit(m_cpCtx);
			}
		}
		if (state == null)
		{
			m_skipDecrement = false;
		}
		if (m_cpCtx != null)
		{
			m_cpCtx.m_cpCtxSkipDecrement = false;
		}
		int num10 = (bGridRac ? m_cpCtx.m_counter.total : m_counter.total);
		int num11 = (bGridRac ? m_cpCtx.m_counter.totalAvailable : m_counter.totalAvailable);
		if (num10 == num11)
		{
			if (!m_inactive)
			{
				m_inactive = true;
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnectionPools) == PerfCounterLevel.NumberOfActiveConnectionPools)
				{
					OraclePerfCounterCollection.NumberOfActiveConnectionPools.Decrement();
				}
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfInactiveConnectionPools) == PerfCounterLevel.NumberOfInactiveConnectionPools)
				{
					OraclePerfCounterCollection.NumberOfInactiveConnectionPools.Increment();
				}
			}
		}
		else if (m_inactive)
		{
			m_inactive = false;
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnectionPools) == PerfCounterLevel.NumberOfActiveConnectionPools)
			{
				OraclePerfCounterCollection.NumberOfActiveConnectionPools.Increment();
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfInactiveConnectionPools) == PerfCounterLevel.NumberOfInactiveConnectionPools)
			{
				OraclePerfCounterCollection.NumberOfInactiveConnectionPools.Decrement();
			}
		}
		return num;
	}

	public unsafe int CheckLifeTimeAndStatus(ref OpoConCtx opoConCtx, int bDistTxnEnd, ref bool bClosed, int bFromPool, bool bCheckLifetimeOnly)
	{
		int result = 0;
		bool bGridRac = opoConCtx.bGridRac;
		bool flag = false;
		if (!bGridRac || bFromPool != 1)
		{
			int num = ((m_cpCtx == null) ? m_counter.total : m_cpCtx.m_counter.total);
			lock (this)
			{
				if (m_rlbGravCounter > 0)
				{
					m_rlbGravCounter--;
					flag = true;
				}
			}
			if ((bFromPool == 0 && opoConCtx.lifeTime > TimeSpan.Zero && num > opoConCtx.minPoolSize && opoConCtx.lifeTime < DateTime.Now.Subtract(opoConCtx.creationTime)) || (m_clonedCtx.lifeTime == new TimeSpan(1L) && m_clonedCtx.origLifeTime < DateTime.Now.Subtract(opoConCtx.creationTime)) || flag)
			{
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
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
				{
					OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
				}
				opoConCtx.pooledConCtx = null;
				opoConCtx.opsConCtx = IntPtr.Zero;
				opoConCtx.opsErrCtx = IntPtr.Zero;
				opoConCtx.m_conPooler = null;
				opoConCtx.m_udtDescPoolerByName = null;
				opoConCtx.m_udtDescPoolerByTDO = null;
				opoConCtx.m_systemTransaction = null;
				opoConCtx.m_txnType = TxnType.None;
				UpdateTotalCount(-1, bForPotential: true);
				bClosed = true;
				if (flag)
				{
					UpdatePotentialTotalCount(1);
					ThreadPool.QueueUserWorkItem(PopulatePool, 1);
				}
				return 0;
			}
		}
		if (bCheckLifetimeOnly)
		{
			bClosed = false;
			return 0;
		}
		try
		{
			if (bFromPool == 0 && (opoConCtx.pOpoConValCtx->InMtsTxn == 1 || (opoConCtx.opoConRefCtx.proxyUserId != null && opoConCtx.opoConRefCtx.proxyUserId.Length > 0) || opoConCtx.pOpoConValCtx->OSAuthent == 2))
			{
				OpsCon.CloseProxyAuthUserSession(opoConCtx.opsConCtx, opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
			}
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
		}
		int bAlive = 1;
		bool flag2 = false;
		try
		{
			if (bFromPool == 0 || opoConCtx.validateCon == 1)
			{
				bAlive = 0;
				OpsCon.CheckConStatus(opoConCtx.opsConCtx, opoConCtx.opsErrCtx, bDistTxnEnd, ref bAlive, bFromPool, opoConCtx.validateCon);
			}
		}
		catch (Exception ex3)
		{
			flag2 = true;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
		}
		if (bAlive == 0)
		{
			OpoConValCtx* pOpoConValCtx = null;
			if (bFromPool == 1)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					if (flag2)
					{
						OraTrace.Trace(1u, " (VALID) Exception in OpsCon.CheckConStatus\n");
					}
					else
					{
						OraTrace.Trace(1u, " (VALID) Dead connection\n");
					}
				}
				try
				{
					OpsCon.Close(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
				}
				catch (Exception ex4)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex4);
					}
				}
			}
			else
			{
				pOpoConValCtx = opoConCtx.pOpoConValCtx;
				opoConCtx.pOpoConValCtx = null;
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
			opoConCtx.pooledConCtx = null;
			opoConCtx.opsConCtx = IntPtr.Zero;
			opoConCtx.opsErrCtx = IntPtr.Zero;
			opoConCtx.m_conPooler = null;
			opoConCtx.m_udtDescPoolerByName = null;
			opoConCtx.m_udtDescPoolerByTDO = null;
			opoConCtx.m_systemTransaction = null;
			opoConCtx.m_txnType = TxnType.None;
			UpdateTotalCount(-1, bForPotential: true);
			bClosed = true;
		}
		else
		{
			bClosed = false;
		}
		return result;
	}

	private void GetEnlistedConnection(ref PooledConCtx pooledConCtx, OpoConCtx opoConCtx)
	{
		try
		{
			if (opoConCtx.m_txnType == TxnType.SystemTxn)
			{
				pooledConCtx = (PooledConCtx)m_oraResPool.GetResource(opoConCtx.m_systemTransaction.TransactionInformation.LocalIdentifier);
			}
			else if (opoConCtx.m_txnType == TxnType.COMPlus)
			{
				lock (m_mtsConnections)
				{
					pooledConCtx = (PooledConCtx)m_mtsConnections.GetResource();
				}
				if (pooledConCtx == null)
				{
					pooledConCtx = (PooledConCtx)m_oraResPool.GetResource(opoConCtx.m_systemTransaction.TransactionInformation.LocalIdentifier);
					if (pooledConCtx != null)
					{
						opoConCtx.m_txnType = TxnType.SystemTxn;
					}
				}
			}
			if (pooledConCtx != null && (OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfStasisConnections) == PerfCounterLevel.NumberOfStasisConnections)
			{
				OraclePerfCounterCollection.NumberOfStasisConnections.Decrement();
			}
		}
		catch
		{
		}
	}

	private void GetRegularConnection(ref PooledConCtx pooledConCtx)
	{
		try
		{
			if (m_bSynchronizeStack)
			{
				lock (m_connections.SyncRoot)
				{
					pooledConCtx = (PooledConCtx)m_connections.Pop();
				}
			}
			else
			{
				pooledConCtx = (PooledConCtx)m_connections.Pop();
			}
			if (pooledConCtx != null && (OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfFreeConnections) == PerfCounterLevel.NumberOfFreeConnections)
			{
				OraclePerfCounterCollection.NumberOfFreeConnections.Decrement();
			}
		}
		catch
		{
		}
	}

	public unsafe int CopyPooledToCon(ref OpoConCtx opoConCtx, ref PooledConCtx pooledConCtx)
	{
		int num = 0;
		int num2 = 0;
		int sessionBegin = 1;
		opoConCtx.pooledConCtx = pooledConCtx;
		if (opoConCtx.opsConCtx != IntPtr.Zero && opoConCtx.opsErrCtx != IntPtr.Zero)
		{
			OpoConValCtx* pOpoConValCtx = null;
			try
			{
				if (opoConCtx.m_fetchArrayPooler != null)
				{
					opoConCtx.m_fetchArrayPooler.Dispose();
					opoConCtx.m_fetchArrayPooler = null;
				}
				OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref pOpoConValCtx, null);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
			{
				OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
			}
		}
		opoConCtx.opsConCtx = pooledConCtx.opsConCtx;
		opoConCtx.opsErrCtx = pooledConCtx.opsErrCtx;
		opoConCtx.creationTime = pooledConCtx.creationTime;
		num = ConnectionDispenser.CopyPooledConCtx(ref opoConCtx.pOpoConValCtx, pooledConCtx.pOpoConValCtx);
		try
		{
			if (num == 0 && opoConCtx.pOpoConValCtx->SessionBegin == 1 && ((opoConCtx.opoConRefCtx.proxyUserId != null && opoConCtx.opoConRefCtx.proxyUserId.Length > 0) || opoConCtx.pOpoConValCtx->OSAuthent == 2))
			{
				try
				{
					num2 = OpsCon.OpenProxyAuthUserSession(opoConCtx.opsConCtx, opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
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
			}
		}
		finally
		{
			if (num2 != 0)
			{
				sessionBegin = opoConCtx.pOpoConValCtx->SessionBegin;
				opoConCtx.pOpoConValCtx->SessionBegin = 1;
				num = num2;
			}
			if (num != 0)
			{
				if (opoConCtx.pOpoConValCtx->Enlist == 1 && opoConCtx.m_systemTransaction != null && (opoConCtx.opoConRefCtx.proxyUserId == null || opoConCtx.opoConRefCtx.proxyUserId.Length == 0))
				{
					PushToResourcePool(opoConCtx, pooledConCtx);
					if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfStasisConnections) == PerfCounterLevel.NumberOfStasisConnections)
					{
						OraclePerfCounterCollection.NumberOfStasisConnections.Increment();
					}
				}
				else if (m_bSynchronizeStack)
				{
					lock (m_connections)
					{
						PutConnection(ref opoConCtx, bDoNotAllocValCtx: false, bCheckStatus: true, bCheckLifeTime: true, 0);
					}
				}
				else
				{
					PutConnection(ref opoConCtx, bDoNotAllocValCtx: false, bCheckStatus: true, bCheckLifeTime: true, 0);
				}
				opoConCtx.pooledConCtx = null;
				opoConCtx.opsConCtx = IntPtr.Zero;
				opoConCtx.opsErrCtx = IntPtr.Zero;
				opoConCtx.m_conPooler = null;
				opoConCtx.m_udtDescPoolerByName = null;
				opoConCtx.m_udtDescPoolerByTDO = null;
			}
		}
		opoConCtx.opoConRefCtx.serverVersion = pooledConCtx.opoConRefCtx.serverVersion;
		opoConCtx.opoConRefCtx.dataSource = pooledConCtx.opoConRefCtx.dataSource;
		opoConCtx.opoConRefCtx.dbName = pooledConCtx.opoConRefCtx.dbName;
		opoConCtx.opoConRefCtx.hostName = pooledConCtx.opoConRefCtx.hostName;
		opoConCtx.opoConRefCtx.serviceName = pooledConCtx.opoConRefCtx.serviceName;
		opoConCtx.opoConRefCtx.instanceName = pooledConCtx.opoConRefCtx.instanceName;
		opoConCtx.opoConRefCtx.dbDomainName = pooledConCtx.opoConRefCtx.dbDomainName;
		opoConCtx.opoConRefCtx.ttOpsConOpenErrMssg = pooledConCtx.opoConRefCtx.ttOpsConOpenErrMssg;
		opoConCtx.m_conPooler = pooledConCtx.m_conPooler;
		opoConCtx.m_udtDescPoolerByName = pooledConCtx.m_udtDescPoolerByName;
		opoConCtx.m_udtDescPoolerByTDO = pooledConCtx.m_udtDescPoolerByTDO;
		opoConCtx.m_promotableTxnManager = pooledConCtx.m_promotableTxnManager;
		opoConCtx.m_fetchArrayPooler = pooledConCtx.m_fetchArrayPooler;
		opoConCtx.m_statementData = pooledConCtx.m_statementData;
		opoConCtx.m_totalDataAvailable = pooledConCtx.m_totalDataAvailable;
		if (num2 != 0)
		{
			opoConCtx.pOpoConValCtx->SessionBegin = sessionBegin;
		}
		return num;
	}

	private void CreateMoreConnections()
	{
		int num = 0;
		num = ((m_cpCtx == null) ? m_counter.potentialTotal : m_cpCtx.m_counter.potentialTotal);
		int num2 = ((num + m_clonedCtx.poolIncSize <= m_clonedCtx.maxPoolSize) ? m_clonedCtx.poolIncSize : (m_clonedCtx.maxPoolSize - num));
		if (num2 > 0)
		{
			ThreadPool.QueueUserWorkItem(PopulatePool, num2);
			UpdatePotentialTotalCount(num2);
		}
	}

	private int WaitForRegularConnection(ref OpoConCtx opoConCtx, ref PooledConCtx pooledConCtx)
	{
		int num = 0;
		int PreviousCount = 0;
		UpdateThreadWaitCount(1);
		double num2 = ((!m_bGridRac) ? opoConCtx.timeOut.TotalSeconds : 0.0);
		try
		{
			num = OpsCon.WaitForSingleObject(m_semAvaNumOfCons, (int)num2 * 1000);
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
			UpdateThreadWaitCount(-1);
		}
		if (num == ErrRes.INT_ERR)
		{
			return num;
		}
		switch (num)
		{
		case 128:
		case 258:
			if (m_bGridRac)
			{
				Interlocked.Increment(ref m_cpCtx.totalAvaliableConnections);
			}
			else
			{
				Interlocked.Increment(ref m_counter.totalAvailable);
			}
			return ErrRes.CON_TIMEOUT_EXCEEDED;
		case 0:
			GetRegularConnection(ref pooledConCtx);
			if (pooledConCtx != null)
			{
				break;
			}
			num = ErrRes.CON_TIMEOUT_EXCEEDED;
			if (m_bGridRac)
			{
				Interlocked.Increment(ref m_cpCtx.totalAvaliableConnections);
			}
			else
			{
				Interlocked.Increment(ref m_counter.totalAvailable);
			}
			try
			{
				OpsCon.ReleaseSemaphore(m_semAvaNumOfCons, 1, ref PreviousCount);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
			}
			return num;
		}
		return 0;
	}

	public unsafe int GetConnection(OpoConCtx opoConCtx)
	{
		int num = 0;
		PooledConCtx pooledConCtx = null;
		bool flag = false;
		bool flag2 = false;
		DateTime now = DateTime.Now;
		try
		{
			if (opoConCtx.pOpoConValCtx->Enlist == 1 && opoConCtx.m_systemTransaction != null && (opoConCtx.opoConRefCtx.proxyUserId == null || opoConCtx.opoConRefCtx.proxyUserId.Length == 0))
			{
				flag2 = true;
			}
			int inMtsTxn;
			while (true)
			{
				flag = false;
				pooledConCtx = null;
				inMtsTxn = 0;
				if (flag2)
				{
					GetEnlistedConnection(ref pooledConCtx, opoConCtx);
					if (pooledConCtx != null)
					{
						inMtsTxn = 1;
						if (opoConCtx.bGridRac && m_cpCtx != null)
						{
							Interlocked.Increment(ref m_cpCtx.totalAvaliableConnections);
							Interlocked.Increment(ref m_counter.totalAvailable);
							int PreviousCount = 0;
							OpsCon.ReleaseSemaphore(m_cpCtx.m_semCPCtxAvaNumOfCons, 1, ref PreviousCount);
						}
					}
				}
				if (pooledConCtx == null)
				{
					num = WaitForRegularConnection(ref opoConCtx, ref pooledConCtx);
					if (num != 0)
					{
						return num;
					}
				}
				if (pooledConCtx != null)
				{
					num = CopyPooledToCon(ref opoConCtx, ref pooledConCtx);
					if (num != 0)
					{
						return num;
					}
				}
				if (opoConCtx.pOpoConValCtx->SessionBegin == 1 && opoConCtx.validateCon == 1)
				{
					CheckLifeTimeAndStatus(ref opoConCtx, 1, ref flag, 1, bCheckLifetimeOnly: false);
				}
				if (!flag)
				{
					break;
				}
				if (DateTime.Now - now >= opoConCtx.timeOut)
				{
					return ErrRes.CON_TIMEOUT_EXCEEDED;
				}
			}
			if (flag2)
			{
				opoConCtx.pOpoConValCtx->InMtsTxn = inMtsTxn;
			}
			if (opoConCtx.pOpoConValCtx->Enlist == 1 && opoConCtx.pOpoConValCtx->InMtsTxn == 0 && opoConCtx.pOpoConValCtx->SessionBegin == 1 && (opoConCtx.opoConRefCtx.proxyUserId == null || opoConCtx.opoConRefCtx.proxyUserId.Length == 0))
			{
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
						opoConCtx.pOpoConValCtx->InMtsTxn = 0;
						if (m_bSynchronizeStack)
						{
							lock (m_connections)
							{
								PutConnection(ref opoConCtx, bDoNotAllocValCtx: false, bCheckStatus: true, bCheckLifeTime: true, 0);
							}
						}
						else
						{
							PutConnection(ref opoConCtx, bDoNotAllocValCtx: false, bCheckStatus: true, bCheckLifeTime: true, 0);
						}
					}
				}
				if (num != 0)
				{
					return num;
				}
			}
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
		if (m_inactive)
		{
			m_inactive = false;
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfActiveConnectionPools) == PerfCounterLevel.NumberOfActiveConnectionPools)
			{
				OraclePerfCounterCollection.NumberOfActiveConnectionPools.Increment();
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfInactiveConnectionPools) == PerfCounterLevel.NumberOfInactiveConnectionPools)
			{
				OraclePerfCounterCollection.NumberOfInactiveConnectionPools.Decrement();
			}
		}
		return num;
	}

	public int ReleaseSemaphore()
	{
		int PreviousCount = 0;
		int PreviousCount2 = 0;
		try
		{
			OpsCon.ReleaseSemaphore(m_semAvaNumOfCons, 1, ref PreviousCount);
			if (m_cpCtx != null)
			{
				OpsCon.ReleaseSemaphore(m_cpCtx.m_semCPCtxAvaNumOfCons, 1, ref PreviousCount2);
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		return 0;
	}

	public unsafe int PutConnection(ref OpoConCtx opoConCtx, bool bDoNotAllocValCtx, bool bCheckStatus, bool bCheckLifeTime, int bDistTxnEnd)
	{
		bool bClosed = false;
		int num = 0;
		bool flag = false;
		ConnectionPool connectionPool = this;
		if (opoConCtx.pOpoConValCtx->StmtCacheSize > 0 && opoConCtx.pOpoConValCtx->StmtCachePurge == 1)
		{
			try
			{
				num = OpsCon.PurgeStatementCache(opoConCtx.opsConCtx, opoConCtx.opsErrCtx, opoConCtx.pOpoConValCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
		}
		if (((opoConCtx.pOpoConValCtx->InMtsTxn == 1 && opoConCtx.m_systemTransaction != null) || opoConCtx.m_promotableTxnManager != null) && (opoConCtx.opoConRefCtx.proxyUserId == null || opoConCtx.opoConRefCtx.proxyUserId.Length == 0))
		{
			if (opoConCtx.pooledConCtx != null)
			{
				opoConCtx.pooledConCtx.m_fetchArrayPooler = opoConCtx.m_fetchArrayPooler;
				opoConCtx.pooledConCtx.m_promotableTxnManager = opoConCtx.m_promotableTxnManager;
				opoConCtx.pooledConCtx.m_statementData = opoConCtx.m_statementData;
				opoConCtx.pooledConCtx.m_totalDataAvailable = opoConCtx.m_totalDataAvailable;
				PushToResourcePool(opoConCtx, opoConCtx.pooledConCtx);
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfStasisConnections) == PerfCounterLevel.NumberOfStasisConnections)
				{
					OraclePerfCounterCollection.NumberOfStasisConnections.Increment();
				}
				opoConCtx.pooledConCtx = null;
				opoConCtx.opsConCtx = IntPtr.Zero;
				opoConCtx.opsErrCtx = IntPtr.Zero;
				opoConCtx.m_conPooler = null;
				opoConCtx.m_udtDescPoolerByName = null;
				opoConCtx.m_udtDescPoolerByTDO = null;
			}
			else
			{
				PooledConCtx pooledConCtx = new PooledConCtx();
				pooledConCtx.opsConCtx = opoConCtx.opsConCtx;
				pooledConCtx.opsErrCtx = opoConCtx.opsErrCtx;
				pooledConCtx.conString = opoConCtx.conString;
				pooledConCtx.creationTime = opoConCtx.creationTime;
				if (bDoNotAllocValCtx)
				{
					pooledConCtx.pOpoConValCtx = opoConCtx.pOpoConValCtx;
					opoConCtx.pOpoConValCtx = null;
				}
				else
				{
					num = ConnectionDispenser.CopyPooledConCtx(ref pooledConCtx.pOpoConValCtx, opoConCtx.pOpoConValCtx);
					if (num != 0)
					{
						try
						{
							if (opoConCtx.m_fetchArrayPooler != null)
							{
								opoConCtx.m_fetchArrayPooler.Dispose();
								opoConCtx.m_fetchArrayPooler = null;
							}
							OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
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
						opoConCtx.pooledConCtx = null;
						opoConCtx.opsConCtx = IntPtr.Zero;
						opoConCtx.opsErrCtx = IntPtr.Zero;
						opoConCtx.m_conPooler = null;
						opoConCtx.m_udtDescPoolerByName = null;
						opoConCtx.m_udtDescPoolerByTDO = null;
						opoConCtx.m_systemTransaction = null;
						opoConCtx.m_txnType = TxnType.None;
						opoConCtx.m_promotableTxnManager = null;
						UpdateTotalCount(-1, bForPotential: true);
						return -1;
					}
				}
				pooledConCtx.opoConRefCtx = new OpoConRefCtx();
				pooledConCtx.opoConRefCtx.serverVersion = opoConCtx.opoConRefCtx.serverVersion;
				pooledConCtx.opoConRefCtx.dataSource = opoConCtx.opoConRefCtx.dataSource;
				pooledConCtx.opoConRefCtx.dbName = opoConCtx.opoConRefCtx.dbName;
				pooledConCtx.opoConRefCtx.hostName = opoConCtx.opoConRefCtx.hostName;
				pooledConCtx.opoConRefCtx.serviceName = opoConCtx.opoConRefCtx.serviceName;
				pooledConCtx.opoConRefCtx.instanceName = opoConCtx.opoConRefCtx.instanceName;
				pooledConCtx.opoConRefCtx.dbDomainName = opoConCtx.opoConRefCtx.dbDomainName;
				pooledConCtx.opoConRefCtx.ttOpsConOpenErrMssg = opoConCtx.opoConRefCtx.ttOpsConOpenErrMssg;
				pooledConCtx.m_conPooler = opoConCtx.m_conPooler;
				pooledConCtx.m_udtDescPoolerByName = opoConCtx.m_udtDescPoolerByName;
				pooledConCtx.m_udtDescPoolerByTDO = opoConCtx.m_udtDescPoolerByTDO;
				pooledConCtx.m_txnid = opoConCtx.m_txnid;
				pooledConCtx.m_promotableTxnManager = opoConCtx.m_promotableTxnManager;
				pooledConCtx.m_fetchArrayPooler = opoConCtx.m_fetchArrayPooler;
				pooledConCtx.m_statementData = opoConCtx.m_statementData;
				pooledConCtx.m_totalDataAvailable = opoConCtx.m_totalDataAvailable;
				PushToResourcePool(opoConCtx, pooledConCtx);
				if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfStasisConnections) == PerfCounterLevel.NumberOfStasisConnections)
				{
					OraclePerfCounterCollection.NumberOfStasisConnections.Increment();
				}
				opoConCtx.pooledConCtx = null;
				opoConCtx.opsConCtx = IntPtr.Zero;
				opoConCtx.opsErrCtx = IntPtr.Zero;
				opoConCtx.m_conPooler = null;
				opoConCtx.m_udtDescPoolerByName = null;
				opoConCtx.m_udtDescPoolerByTDO = null;
			}
			opoConCtx.pOpoConValCtx->InMtsTxn = 0;
			return num;
		}
		if (opoConCtx.pOpoConValCtx->InMtsTxn == 1 && !ContextUtil.IsInTransaction)
		{
			opoConCtx.opoConRefCtx.pITransaction = null;
			try
			{
				num = OpsCon.Enlist(opoConCtx.opsConCtx, opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				num = ErrRes.INT_ERR;
			}
			finally
			{
				if (num != 0)
				{
					try
					{
						if (opoConCtx.m_fetchArrayPooler != null)
						{
							opoConCtx.m_fetchArrayPooler.Dispose();
							opoConCtx.m_fetchArrayPooler = null;
						}
						OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
					}
					catch (Exception ex4)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex4);
						}
					}
					if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
					{
						OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
					}
					opoConCtx.pooledConCtx = null;
					opoConCtx.opsConCtx = IntPtr.Zero;
					opoConCtx.opsErrCtx = IntPtr.Zero;
					opoConCtx.m_conPooler = null;
					opoConCtx.m_udtDescPoolerByName = null;
					opoConCtx.m_udtDescPoolerByTDO = null;
					opoConCtx.m_systemTransaction = null;
					opoConCtx.m_txnType = TxnType.None;
					UpdateTotalCount(-1, bForPotential: true);
				}
			}
			if (num != 0)
			{
				return -1;
			}
		}
		if (bCheckStatus || bCheckLifeTime)
		{
			bool bCheckLifetimeOnly = bCheckLifeTime && !bCheckStatus;
			CheckLifeTimeAndStatus(ref opoConCtx, bDistTxnEnd, ref bClosed, 0, bCheckLifetimeOnly);
			if (bClosed)
			{
				return -1;
			}
		}
		if (m_bClearPoolInProgress && opoConCtx.creationTime < m_clearRequestTimeStamp)
		{
			try
			{
				if (opoConCtx.m_fetchArrayPooler != null)
				{
					opoConCtx.m_fetchArrayPooler.Dispose();
					opoConCtx.m_fetchArrayPooler = null;
				}
				OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
			}
			catch (Exception ex5)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex5);
				}
			}
			opoConCtx.pooledConCtx = null;
			opoConCtx.opsConCtx = IntPtr.Zero;
			opoConCtx.opsErrCtx = IntPtr.Zero;
			opoConCtx.m_conPooler = null;
			opoConCtx.m_udtDescPoolerByName = null;
			opoConCtx.m_udtDescPoolerByTDO = null;
			opoConCtx.m_systemTransaction = null;
			opoConCtx.m_txnType = TxnType.None;
			UpdateTotalCount(-1, bForPotential: true);
			if (m_bGridRac)
			{
				Interlocked.Decrement(ref m_cpCtx.m_consFromAppToClear);
				if (m_cpCtx.m_consFromAppToClear == 0)
				{
					m_bClearPoolInProgress = false;
				}
			}
			else
			{
				Interlocked.Decrement(ref m_consFromAppToClear);
				if (m_consFromAppToClear == 0)
				{
					m_bClearPoolInProgress = false;
				}
			}
		}
		else if (opoConCtx.pooledConCtx != null)
		{
			if (bDoNotAllocValCtx)
			{
				opoConCtx.pooledConCtx.pOpoConValCtx = opoConCtx.pOpoConValCtx;
				opoConCtx.pOpoConValCtx = null;
			}
			else
			{
				num = ConnectionDispenser.CopyPooledConCtx(ref opoConCtx.pooledConCtx.pOpoConValCtx, opoConCtx.pOpoConValCtx);
				if (num != 0)
				{
					try
					{
						if (opoConCtx.m_fetchArrayPooler != null)
						{
							opoConCtx.m_fetchArrayPooler.Dispose();
							opoConCtx.m_fetchArrayPooler = null;
						}
						OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
					}
					catch (Exception ex6)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex6);
						}
					}
					if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
					{
						OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
					}
					opoConCtx.pooledConCtx = null;
					opoConCtx.opsConCtx = IntPtr.Zero;
					opoConCtx.opsErrCtx = IntPtr.Zero;
					opoConCtx.m_conPooler = null;
					opoConCtx.m_udtDescPoolerByName = null;
					opoConCtx.m_udtDescPoolerByTDO = null;
					opoConCtx.m_systemTransaction = null;
					opoConCtx.m_txnType = TxnType.None;
					UpdateTotalCount(-1, bForPotential: true);
					return -1;
				}
			}
			if (opoConCtx.pooledConCtx.pOpoConValCtx->bTAFEnabled == 1)
			{
				string instanceName = opoConCtx.opoConRefCtx.instanceName;
				OpsCon.GetAttributes(opoConCtx.opsConCtx, opoConCtx.opsErrCtx, opoConCtx.opoConRefCtx);
				if (instanceName != opoConCtx.opoConRefCtx.instanceName)
				{
					OraTrace.Trace(16u, " (FO)    Failed over from " + instanceName + " to " + opoConCtx.opoConRefCtx.instanceName + "\n");
					flag = true;
					connectionPool = (ConnectionPool)m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName];
					if (connectionPool == null)
					{
						lock (m_cpCtx.htInstToCp.SyncRoot)
						{
							if (m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] == null)
							{
								connectionPool = new ConnectionPool(opoConCtx, m_cpCtx, m_identity);
								m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] = connectionPool;
								if (OraTrace.m_TraceLevel != 0)
								{
									OraTrace.Trace(2u, " (POOL)  New CP created (CP id: " + connectionPool.GetHashCode() + "; CPCtx id: " + connectionPool.m_cpCtx.GetHashCode() + ") for: [Instance=" + opoConCtx.opoConRefCtx.instanceName + "]\n");
									OraTrace.Trace(2u, " (POOL)  Num of Inst CPs in (CPCtx id: " + connectionPool.m_cpCtx.GetHashCode() + ") : " + connectionPool.m_cpCtx.htInstToCp.Count + "\n");
								}
							}
						}
					}
				}
			}
			opoConCtx.pooledConCtx.m_promotableTxnManager = opoConCtx.m_promotableTxnManager;
			opoConCtx.pooledConCtx.m_fetchArrayPooler = opoConCtx.m_fetchArrayPooler;
			opoConCtx.pooledConCtx.m_statementData = opoConCtx.m_statementData;
			opoConCtx.pooledConCtx.m_totalDataAvailable = opoConCtx.m_totalDataAvailable;
			if (m_bSynchronizeStack)
			{
				lock (connectionPool.m_connections.SyncRoot)
				{
					connectionPool.m_connections.Push(opoConCtx.pooledConCtx);
				}
			}
			else
			{
				connectionPool.m_connections.Push(opoConCtx.pooledConCtx);
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfFreeConnections) == PerfCounterLevel.NumberOfFreeConnections)
			{
				OraclePerfCounterCollection.NumberOfFreeConnections.Increment();
			}
			if (m_bGridRac && connectionPool.m_cpCtx != null)
			{
				Interlocked.Increment(ref connectionPool.m_cpCtx.totalAvaliableConnections);
			}
			Interlocked.Increment(ref connectionPool.m_counter.totalAvailable);
			connectionPool.ReleaseSemaphore();
			opoConCtx.pooledConCtx = null;
			opoConCtx.opsConCtx = IntPtr.Zero;
			opoConCtx.opsErrCtx = IntPtr.Zero;
			opoConCtx.m_conPooler = null;
			opoConCtx.m_udtDescPoolerByName = null;
			opoConCtx.m_udtDescPoolerByTDO = null;
			if (flag)
			{
				Interlocked.Decrement(ref m_counter.total);
				Interlocked.Increment(ref connectionPool.m_counter.total);
			}
		}
		else
		{
			PooledConCtx pooledConCtx2 = new PooledConCtx();
			pooledConCtx2.opsConCtx = opoConCtx.opsConCtx;
			pooledConCtx2.opsErrCtx = opoConCtx.opsErrCtx;
			pooledConCtx2.conString = opoConCtx.conString;
			pooledConCtx2.creationTime = opoConCtx.creationTime;
			if (bDoNotAllocValCtx)
			{
				pooledConCtx2.pOpoConValCtx = opoConCtx.pOpoConValCtx;
				opoConCtx.pOpoConValCtx = null;
			}
			else
			{
				num = ConnectionDispenser.CopyPooledConCtx(ref pooledConCtx2.pOpoConValCtx, opoConCtx.pOpoConValCtx);
				if (num != 0)
				{
					try
					{
						if (opoConCtx.m_fetchArrayPooler != null)
						{
							opoConCtx.m_fetchArrayPooler.Dispose();
							opoConCtx.m_fetchArrayPooler = null;
						}
						OpsCon.Dispose(ref opoConCtx.opsConCtx, ref opoConCtx.opsErrCtx, ref opoConCtx.pOpoConValCtx, opoConCtx.opoConRefCtx);
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
					opoConCtx.pooledConCtx = null;
					opoConCtx.opsConCtx = IntPtr.Zero;
					opoConCtx.opsErrCtx = IntPtr.Zero;
					opoConCtx.m_conPooler = null;
					opoConCtx.m_udtDescPoolerByName = null;
					opoConCtx.m_udtDescPoolerByTDO = null;
					opoConCtx.m_systemTransaction = null;
					opoConCtx.m_txnType = TxnType.None;
					UpdateTotalCount(-1, bForPotential: true);
					return -1;
				}
			}
			if (pooledConCtx2.pOpoConValCtx->bTAFEnabled == 1)
			{
				string instanceName2 = opoConCtx.opoConRefCtx.instanceName;
				OpsCon.GetAttributes(opoConCtx.opsConCtx, opoConCtx.opsErrCtx, opoConCtx.opoConRefCtx);
				if (instanceName2 != opoConCtx.opoConRefCtx.instanceName)
				{
					OraTrace.Trace(16u, " (FO)    Failed over from " + instanceName2 + " to " + opoConCtx.opoConRefCtx.instanceName + "\n");
					flag = true;
					connectionPool = (ConnectionPool)m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName];
					if (connectionPool == null)
					{
						lock (m_cpCtx.htInstToCp.SyncRoot)
						{
							if (m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] == null)
							{
								connectionPool = new ConnectionPool(opoConCtx, m_cpCtx, m_identity);
								m_cpCtx.htInstToCp[opoConCtx.opoConRefCtx.instanceName] = connectionPool;
								if (OraTrace.m_TraceLevel != 0)
								{
									OraTrace.Trace(2u, " (POOL)  New CP created (CP id: " + connectionPool.GetHashCode() + "; CPCtx id: " + connectionPool.m_cpCtx.GetHashCode() + ") for: [Instance=" + opoConCtx.opoConRefCtx.instanceName + "]\n");
									OraTrace.Trace(2u, " (POOL)  Num of Inst CPs in (CPCtx id: " + connectionPool.m_cpCtx.GetHashCode() + ") : " + connectionPool.m_cpCtx.htInstToCp.Count + "\n");
								}
							}
						}
					}
				}
			}
			pooledConCtx2.opoConRefCtx = new OpoConRefCtx();
			pooledConCtx2.opoConRefCtx.serverVersion = opoConCtx.opoConRefCtx.serverVersion;
			pooledConCtx2.opoConRefCtx.dataSource = opoConCtx.opoConRefCtx.dataSource;
			pooledConCtx2.opoConRefCtx.dbName = opoConCtx.opoConRefCtx.dbName;
			pooledConCtx2.opoConRefCtx.hostName = opoConCtx.opoConRefCtx.hostName;
			pooledConCtx2.opoConRefCtx.serviceName = opoConCtx.opoConRefCtx.serviceName;
			pooledConCtx2.opoConRefCtx.instanceName = opoConCtx.opoConRefCtx.instanceName;
			pooledConCtx2.opoConRefCtx.dbDomainName = opoConCtx.opoConRefCtx.dbDomainName;
			pooledConCtx2.opoConRefCtx.ttOpsConOpenErrMssg = opoConCtx.opoConRefCtx.ttOpsConOpenErrMssg;
			pooledConCtx2.m_conPooler = opoConCtx.m_conPooler;
			pooledConCtx2.m_udtDescPoolerByName = opoConCtx.m_udtDescPoolerByName;
			pooledConCtx2.m_udtDescPoolerByTDO = opoConCtx.m_udtDescPoolerByTDO;
			pooledConCtx2.m_txnid = opoConCtx.m_txnid;
			pooledConCtx2.m_promotableTxnManager = opoConCtx.m_promotableTxnManager;
			pooledConCtx2.m_fetchArrayPooler = opoConCtx.m_fetchArrayPooler;
			pooledConCtx2.m_statementData = opoConCtx.m_statementData;
			pooledConCtx2.m_totalDataAvailable = opoConCtx.m_totalDataAvailable;
			if (m_bSynchronizeStack)
			{
				lock (connectionPool.m_connections.SyncRoot)
				{
					connectionPool.m_connections.Push(pooledConCtx2);
				}
			}
			else
			{
				connectionPool.m_connections.Push(pooledConCtx2);
			}
			if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfFreeConnections) == PerfCounterLevel.NumberOfFreeConnections)
			{
				OraclePerfCounterCollection.NumberOfFreeConnections.Increment();
			}
			if (opoConCtx.bGridRac && connectionPool.m_cpCtx != null)
			{
				Interlocked.Increment(ref connectionPool.m_cpCtx.totalAvaliableConnections);
			}
			Interlocked.Increment(ref connectionPool.m_counter.totalAvailable);
			connectionPool.ReleaseSemaphore();
		}
		opoConCtx.opsConCtx = IntPtr.Zero;
		opoConCtx.opsErrCtx = IntPtr.Zero;
		opoConCtx.m_conPooler = null;
		opoConCtx.m_udtDescPoolerByName = null;
		opoConCtx.m_udtDescPoolerByTDO = null;
		opoConCtx.m_systemTransaction = null;
		opoConCtx.m_txnType = TxnType.None;
		if (flag)
		{
			Interlocked.Decrement(ref m_counter.total);
			Interlocked.Increment(ref connectionPool.m_counter.total);
		}
		return num;
	}

	public unsafe void TransactionEnd(object obj)
	{
		int num = 0;
		PooledConCtx pooledConCtx = (PooledConCtx)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(4u, " (MTS) ConnectionPool::TransactionEnd() txnid: (" + pooledConCtx.m_txnid + ")\n");
		}
		if (m_cpCtx != null)
		{
			m_cpCtx.m_htTxnIdToIntance.Remove(pooledConCtx.m_txnid);
		}
		pooledConCtx.m_txnid = null;
		if (pooledConCtx != null && (OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfStasisConnections) == PerfCounterLevel.NumberOfStasisConnections)
		{
			OraclePerfCounterCollection.NumberOfStasisConnections.Decrement();
		}
		if (pooledConCtx != null && pooledConCtx.m_promotableTxnManager != null)
		{
			if (pooledConCtx.m_promotableTxnManager.m_bLocalTxnPromoted)
			{
				try
				{
					OpsCon.DelistPromotedTxn(pooledConCtx.opsConCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
			string localTxnIdentifier = pooledConCtx.m_promotableTxnManager.m_localTxnIdentifier;
			if (!string.IsNullOrEmpty(localTxnIdentifier))
			{
				OracleConnection.m_pspePrimaryResourceEntry.Remove(localTxnIdentifier);
				pooledConCtx.m_promotableTxnManager = null;
			}
		}
		else
		{
			pooledConCtx.opoConRefCtx.pITransaction = null;
			try
			{
				num = OpsCon.Enlist(pooledConCtx.opsConCtx, pooledConCtx.pOpoConValCtx, pooledConCtx.opoConRefCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				num = ErrRes.INT_ERR;
			}
			finally
			{
				if (num != 0)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(4u, " (MTS)  ConnectionPool::TransactionEnd(): delistment failure txnid:" + pooledConCtx.m_txnid + "\n");
					}
					try
					{
						if (pooledConCtx.m_fetchArrayPooler != null)
						{
							pooledConCtx.m_fetchArrayPooler.Dispose();
							pooledConCtx.m_fetchArrayPooler = null;
						}
						OpsCon.Dispose(ref pooledConCtx.opsConCtx, ref pooledConCtx.opsErrCtx, ref pooledConCtx.pOpoConValCtx, pooledConCtx.opoConRefCtx);
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
					UpdateTotalCount(-1, bForPotential: true);
				}
			}
			if (num != 0)
			{
				return;
			}
		}
		OpoConCtx opoConCtx = new OpoConCtx();
		opoConCtx.pooledConCtx = pooledConCtx;
		opoConCtx.opsConCtx = pooledConCtx.opsConCtx;
		opoConCtx.opsErrCtx = pooledConCtx.opsErrCtx;
		opoConCtx.pOpoConValCtx = pooledConCtx.pOpoConValCtx;
		opoConCtx.opoConRefCtx = new OpoConRefCtx();
		opoConCtx.opoConRefCtx.serverVersion = pooledConCtx.opoConRefCtx.serverVersion;
		opoConCtx.opoConRefCtx.dataSource = pooledConCtx.opoConRefCtx.dataSource;
		opoConCtx.opoConRefCtx.dbName = pooledConCtx.opoConRefCtx.dbName;
		opoConCtx.opoConRefCtx.hostName = pooledConCtx.opoConRefCtx.hostName;
		opoConCtx.opoConRefCtx.serviceName = pooledConCtx.opoConRefCtx.serviceName;
		opoConCtx.opoConRefCtx.instanceName = pooledConCtx.opoConRefCtx.instanceName;
		opoConCtx.opoConRefCtx.dbDomainName = pooledConCtx.opoConRefCtx.dbDomainName;
		opoConCtx.opoConRefCtx.ttOpsConOpenErrMssg = pooledConCtx.opoConRefCtx.ttOpsConOpenErrMssg;
		opoConCtx.m_conPooler = pooledConCtx.m_conPooler;
		opoConCtx.m_udtDescPoolerByName = pooledConCtx.m_udtDescPoolerByName;
		opoConCtx.m_udtDescPoolerByTDO = pooledConCtx.m_udtDescPoolerByTDO;
		opoConCtx.m_txnid = pooledConCtx.m_txnid;
		opoConCtx.m_systemTransaction = null;
		opoConCtx.m_txnType = TxnType.None;
		opoConCtx.m_promotableTxnManager = null;
		opoConCtx.pooledConCtx.m_promotableTxnManager = null;
		opoConCtx.m_fetchArrayPooler = pooledConCtx.m_fetchArrayPooler;
		opoConCtx.m_statementData = pooledConCtx.m_statementData;
		opoConCtx.m_totalDataAvailable = pooledConCtx.m_totalDataAvailable;
		if (m_bSynchronizeStack)
		{
			lock (m_connections)
			{
				PutConnection(ref opoConCtx, bDoNotAllocValCtx: true, bCheckStatus: true, bCheckLifeTime: true, 1);
			}
		}
		else
		{
			PutConnection(ref opoConCtx, bDoNotAllocValCtx: true, bCheckStatus: true, bCheckLifeTime: true, 1);
		}
		opoConCtx = null;
	}

	public unsafe void ClearPool(bool bInvalidOnly, bool bRefresh)
	{
		int num = 0;
		int bAlive = 0;
		Stack stack = null;
		int PreviousCount = 0;
		Thread.Sleep(100);
		m_bSynchronizeStack = true;
		m_bClearPoolInProgress = true;
		try
		{
			lock (m_connections)
			{
				if (bInvalidOnly)
				{
					stack = Stack.Synchronized(new Stack());
				}
				else
				{
					m_clearRequestTimeStamp = DateTime.Now;
				}
				while (m_connections.Count > 0)
				{
					int num2 = 0;
					if (m_bGridRac && m_cpCtx != null)
					{
						try
						{
							num2 = OpsCon.WaitForSingleObject(m_cpCtx.m_semCPCtxAvaNumOfCons, 0);
						}
						catch (Exception ex)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex);
							}
							num2 = -1;
						}
						if (num2 != 0)
						{
							break;
						}
						Interlocked.Decrement(ref m_cpCtx.totalAvaliableConnections);
					}
					int num3 = 0;
					try
					{
						num3 = OpsCon.WaitForSingleObject(m_semAvaNumOfCons, 0);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
						num3 = -1;
					}
					if (num3 == 0)
					{
						Interlocked.Decrement(ref m_counter.totalAvailable);
						PooledConCtx pooledConCtx = (PooledConCtx)m_connections.Pop();
						if (pooledConCtx != null && (OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfFreeConnections) == PerfCounterLevel.NumberOfFreeConnections)
						{
							OraclePerfCounterCollection.NumberOfFreeConnections.Decrement();
						}
						try
						{
							if (bInvalidOnly)
							{
								OpsCon.CheckConStatus(pooledConCtx.opsConCtx, pooledConCtx.opsErrCtx, 0, ref bAlive, 1, 1);
							}
						}
						catch (Exception ex3)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex3);
							}
							bAlive = 0;
						}
						finally
						{
							if (bAlive == 0)
							{
								try
								{
									if (pooledConCtx.m_fetchArrayPooler != null)
									{
										pooledConCtx.m_fetchArrayPooler.Dispose();
										pooledConCtx.m_fetchArrayPooler = null;
									}
									OpsCon.Dispose(ref pooledConCtx.opsConCtx, ref pooledConCtx.opsErrCtx, ref pooledConCtx.pOpoConValCtx, pooledConCtx.opoConRefCtx);
								}
								catch (Exception ex4)
								{
									if (OraTrace.m_TraceLevel != 0)
									{
										OraTrace.TraceExceptionInfo(ex4);
									}
								}
								finally
								{
									if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.HardDisconnectsPerSecond) == PerfCounterLevel.HardDisconnectsPerSecond)
									{
										OraclePerfCounterCollection.HardDisconnectsPerSecond.Increment();
									}
									pooledConCtx.opsConCtx = IntPtr.Zero;
									pooledConCtx.opsErrCtx = IntPtr.Zero;
									pooledConCtx.pOpoConValCtx = null;
									pooledConCtx.m_conPooler = null;
									pooledConCtx.m_udtDescPoolerByName = null;
									pooledConCtx.m_udtDescPoolerByTDO = null;
									UpdateTotalCount(-1, bForPotential: true);
									num++;
								}
							}
							else
							{
								stack.Push(pooledConCtx);
							}
						}
						continue;
					}
					if (num2 != 0 || !m_bGridRac || m_cpCtx == null)
					{
						break;
					}
					try
					{
						OpsCon.ReleaseSemaphore(m_cpCtx.m_semCPCtxAvaNumOfCons, 1, ref PreviousCount);
					}
					catch (Exception ex5)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex5);
						}
					}
					Interlocked.Increment(ref m_cpCtx.totalAvaliableConnections);
					break;
				}
				if (stack != null && stack.Count > 0)
				{
					if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.NumberOfFreeConnections) == PerfCounterLevel.NumberOfFreeConnections)
					{
						OraclePerfCounterCollection.NumberOfFreeConnections.IncrementBy(stack.Count - m_connections.Count);
					}
					m_connections = stack;
					for (int i = 0; i < stack.Count; i++)
					{
						if (m_bGridRac && m_cpCtx != null)
						{
							Interlocked.Increment(ref m_cpCtx.totalAvaliableConnections);
						}
						Interlocked.Increment(ref m_counter.totalAvailable);
						ReleaseSemaphore();
					}
				}
				if (m_bGridRac)
				{
					Interlocked.Add(ref m_cpCtx.m_consFromAppToClear, m_cpCtx.m_counter.total);
				}
				else
				{
					Interlocked.Add(ref m_consFromAppToClear, m_counter.total);
				}
			}
		}
		finally
		{
			m_bSynchronizeStack = false;
		}
		lock (m_counter)
		{
			if (!bRefresh && m_counter.total < m_clonedCtx.minPoolSize)
			{
				num = m_clonedCtx.minPoolSize - m_counter.total;
				bRefresh = true;
			}
			else if (bRefresh && num + m_counter.total < m_clonedCtx.minPoolSize)
			{
				num = m_clonedCtx.minPoolSize - m_counter.total;
			}
		}
		if (bRefresh && num > 0)
		{
			ThreadPool.QueueUserWorkItem(PopulatePool, num);
			UpdatePotentialTotalCount(num);
		}
	}

	private void PushToResourcePool(OpoConCtx opoConCtx, PooledConCtx pooledConCtx)
	{
		pooledConCtx.m_txnid = opoConCtx.m_txnid;
		if (opoConCtx.m_txnType == TxnType.LocalTxnForSysTxn)
		{
			m_oraResPool.CacheResourceWithLocalTxn(opoConCtx.m_systemTransaction, pooledConCtx);
		}
		else if (opoConCtx.m_txnType == TxnType.SystemTxn)
		{
			m_oraResPool.PutResource(opoConCtx.m_systemTransaction, pooledConCtx);
		}
		else if (opoConCtx.m_txnType == TxnType.COMPlus)
		{
			try
			{
				if (ContextUtil.IsInTransaction)
				{
					lock (m_mtsConnections)
					{
						m_mtsConnections.PutResource(pooledConCtx);
					}
				}
				else
				{
					TransactionEnd(pooledConCtx);
				}
			}
			catch
			{
				TransactionEnd(pooledConCtx);
			}
		}
		opoConCtx.m_systemTransaction = null;
		opoConCtx.m_txnType = TxnType.None;
	}

	private void UpdateAgentRecommendations(OracleTuningAgent.RecommendationType recommendationType, object recommendation)
	{
		try
		{
			if (recommendationType == OracleTuningAgent.RecommendationType.SCS)
			{
				m_scsRecommendations = (int)recommendation;
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(64u, " (TUNING) ConnectionPool::UpdateAgentRecommendations(): SCS recommendations for pool with Id: " + m_poolId + "; Change to " + m_scsRecommendations.ToString() + " \n");
				}
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(64u, " (ERROR) ConnectionPool::UpdateAgentRecommendations(): Pool Id: " + m_poolId + "; Exception: " + ex.ToString() + " \n");
			}
		}
	}

	private void IncrementStmtSamplesLimit()
	{
		m_stmtSamplesLimit += 100;
	}
}
