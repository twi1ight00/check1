using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace Oracle.DataAccess.Client;

internal class CPCtx
{
	private Hashtable m_htInstToCp;

	public Counter m_counter;

	public IntPtr m_semCPCtxAvaNumOfCons;

	public RLBCtx m_rlbCtx;

	internal Random m_random;

	public int m_iteration;

	public int totalAvaliableConnections;

	public Timer m_timer;

	public bool m_cpCtxSkipDecrement;

	public int m_dispMiss;

	private static int MAX_MISS_COUNT = 2000;

	private static int GRAV_FACTOR = 6;

	public int m_consFromAppToClear;

	public Hashtable m_htTxnIdToIntance;

	public Hashtable htInstToCp
	{
		get
		{
			return m_htInstToCp;
		}
		set
		{
			m_htInstToCp = value;
		}
	}

	public CPCtx(int maxPoolSize, RLBCtx rlbCtx, int poolRegulator)
	{
		m_htInstToCp = Hashtable.Synchronized(new Hashtable());
		m_counter = new Counter(bOwnedByCPCtx: true);
		m_rlbCtx = rlbCtx;
		m_random = new Random();
		m_htTxnIdToIntance = Hashtable.Synchronized(new Hashtable());
		m_cpCtxSkipDecrement = true;
		m_timer = new Timer(RegulateNumOfConsThreadFunc, null, poolRegulator * 1000, poolRegulator * 1000);
		try
		{
			m_semCPCtxAvaNumOfCons = OpsCon.CreateSemaphore(IntPtr.Zero, 0, maxPoolSize, "");
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

	~CPCtx()
	{
		try
		{
			if (m_semCPCtxAvaNumOfCons != IntPtr.Zero)
			{
				try
				{
					OpsCon.CloseHandle(m_semCPCtxAvaNumOfCons);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
				m_semCPCtxAvaNumOfCons = IntPtr.Zero;
			}
		}
		catch
		{
		}
		if (m_timer != null)
		{
			m_timer.Dispose();
			m_timer = null;
		}
	}

	public void RegulateNumOfConsThreadFunc(object state)
	{
		if (m_htInstToCp == null || m_htInstToCp.Count <= 0)
		{
			return;
		}
		lock (m_htInstToCp.SyncRoot)
		{
			if (m_htInstToCp.Count <= 0)
			{
				return;
			}
			ConnectionPool connectionPool = null;
			int num = m_random.Next(1, htInstToCp.Count + 1);
			int num2 = 0;
			IDictionaryEnumerator enumerator = m_htInstToCp.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num2++;
				if (num2 == num)
				{
					break;
				}
			}
			connectionPool = (ConnectionPool)enumerator.Value;
			connectionPool.RegulateNumOfCons(state);
		}
	}

	public int GetConnection(OpoConCtx opoConCtx)
	{
		DateTime now = DateTime.Now;
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		string key = (string)ConnectionDispenser.m_htTnsToSvc[opoConCtx.opoConRefCtx.dataSource];
		RLBCtx rLBCtx = (RLBCtx)ConnectionDispenser.m_htSvcToRLB[key];
		try
		{
			bool flag4 = false;
			if (opoConCtx.gridRLB == 1 && opoConCtx.pool != null && rLBCtx != null && rLBCtx.RLBMetricsList != null && rLBCtx.RLBMetricsList.Count > 0)
			{
				lock (rLBCtx)
				{
					if (rLBCtx.RLBMetricsList != null && rLBCtx.RLBMetricsList.Count > 0)
					{
						int i = 0;
						bool flag5 = false;
						if (rLBCtx.bNeedNormalization)
						{
							CPCtx cpCtx = (CPCtx)rLBCtx.htConToInst[opoConCtx.conString];
							rLBCtx.NormalizeCounters(rLBCtx, cpCtx);
							if (rLBCtx.RLBMetricsList.Count >= 2)
							{
								int num2 = 0;
								float num3 = 0f;
								int count = rLBCtx.RLBMetricsList.Count;
								float[] array = new float[count];
								ConnectionPool[] array2 = new ConnectionPool[count];
								lock (rLBCtx.htConToInst.SyncRoot)
								{
									IDictionaryEnumerator enumerator = rLBCtx.htConToInst.GetEnumerator();
									while (enumerator.MoveNext())
									{
										cpCtx = (CPCtx)enumerator.Value;
										lock (cpCtx.htInstToCp.SyncRoot)
										{
											IDictionaryEnumerator enumerator2 = cpCtx.htInstToCp.GetEnumerator();
											while (enumerator2.MoveNext())
											{
												if (num2 < count)
												{
													array2[num2] = (ConnectionPool)enumerator2.Value;
													num3 += array2[num2].m_attemptedRequests;
													array[num2] = array2[num2].m_attemptedRequests;
													num2++;
												}
											}
										}
									}
								}
							}
						}
						while (!flag5)
						{
							int num4 = int.MaxValue;
							for (i = 0; i < rLBCtx.RLBMetricsList.Count; i++)
							{
								if (((RLBMetrics)rLBCtx.RLBMetricsList[i]).CurDistribFreq == 0)
								{
									flag5 = true;
									break;
								}
								if (i < rLBCtx.RLBMetricsList.Count)
								{
									num4 = Math.Min(num4, ((RLBMetrics)rLBCtx.RLBMetricsList[i]).CurDistribFreq);
								}
							}
							if (!flag5)
							{
								for (i = 0; i < rLBCtx.RLBMetricsList.Count; i++)
								{
									((RLBMetrics)rLBCtx.RLBMetricsList[i]).CurDistribFreq -= num4;
								}
							}
						}
						_ = DateTime.Now;
						bool flag6 = true;
						bool[] array3 = new bool[rLBCtx.RLBMetricsList.Count];
						do
						{
							if (i >= rLBCtx.RLBMetricsList.Count)
							{
								i = m_random.Next(0, rLBCtx.RLBMetricsList.Count);
							}
							opoConCtx.pool = (ConnectionPool)htInstToCp[((RLBMetrics)rLBCtx.RLBMetricsList[i]).InstanceName];
							if (opoConCtx.pool != null && opoConCtx.pool.m_counter.potentialTotal != 0)
							{
								TimeSpan timeSpan = opoConCtx.timeOut - (DateTime.Now - now);
								if (timeSpan.TotalSeconds > 0.0)
								{
									m_counter.UpdateThreadWaitCount(opoConCtx.pool, 1);
									num = OpsCon.WaitForSingleObject(m_semCPCtxAvaNumOfCons, (int)timeSpan.TotalSeconds * 1000);
									m_counter.UpdateThreadWaitCount(opoConCtx.pool, -1);
								}
								else
								{
									num = -1;
								}
								if (num != 0)
								{
									return ErrRes.CON_TIMEOUT_EXCEEDED;
								}
								num = opoConCtx.pool.GetConnection(opoConCtx);
								if (num == 0)
								{
									opoConCtx.pool.m_attemptedRequests += 1f;
									int j;
									for (j = 0; j < rLBCtx.RLBMetricsList.Count && !(((RLBMetrics)rLBCtx.RLBMetricsList[j]).InstanceName == opoConCtx.opoConRefCtx.instanceName); j++)
									{
									}
									ConnectionPool connectionPool = null;
									StringBuilder stringBuilder = null;
									if ((OraTrace.m_TraceLevel & 0x20) == 32)
									{
										int num5 = 0;
										stringBuilder = new StringBuilder();
										stringBuilder.Append(" (GRID) (RLB) (DISP) (inst=");
										stringBuilder.Append(opoConCtx.opoConRefCtx.instanceName);
										stringBuilder.Append(") ");
										for (num5 = 0; num5 < rLBCtx.RLBMetricsList.Count; num5++)
										{
											stringBuilder.Append("(");
											stringBuilder.Append(((RLBMetrics)rLBCtx.RLBMetricsList[num5]).InstanceName);
											connectionPool = (ConnectionPool)htInstToCp[((RLBMetrics)rLBCtx.RLBMetricsList[num5]).InstanceName];
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
											stringBuilder.Append(((RLBMetrics)rLBCtx.RLBMetricsList[num5]).CurDistribFreq);
											stringBuilder.Append("/");
											stringBuilder.Append(((RLBMetrics)rLBCtx.RLBMetricsList[num5]).MaxDistribFreq);
											stringBuilder.Append(") ");
										}
										stringBuilder.Append(") ");
									}
									if (j < rLBCtx.RLBMetricsList.Count)
									{
										if (((RLBMetrics)rLBCtx.RLBMetricsList[j]).CurDistribFreq != 0)
										{
											connectionPool = (ConnectionPool)htInstToCp[((RLBMetrics)rLBCtx.RLBMetricsList[j]).InstanceName];
											connectionPool.m_cpCtx.m_dispMiss++;
											connectionPool.UpdatePotentialTotalCount(connectionPool.m_clonedCtx.poolIncSize);
											ThreadPool.QueueUserWorkItem(connectionPool.PopulatePool, connectionPool.m_clonedCtx.poolIncSize);
											string value = null;
											float num6 = float.MinValue;
											ConnectionPool connectionPool2 = null;
											if (connectionPool.m_cpCtx.m_dispMiss >= MAX_MISS_COUNT)
											{
												connectionPool.m_cpCtx.m_dispMiss = 0;
												int total = connectionPool.m_cpCtx.m_counter.total;
												if (total > 0)
												{
													for (int k = 0; k < rLBCtx.RLBMetricsList.Count; k++)
													{
														string instanceName = ((RLBMetrics)rLBCtx.RLBMetricsList[k]).InstanceName;
														int num7 = (int)((RLBMetrics)rLBCtx.RLBMetricsList[k]).Percentage;
														ConnectionPool connectionPool3 = connectionPool.m_cpCtx.htInstToCp[instanceName] as ConnectionPool;
														int num8 = -1;
														if (connectionPool3 != null)
														{
															num8 = connectionPool3.m_counter.total * 100 / total;
															float num9 = num8 - num7;
															if (num9 > num6)
															{
																value = instanceName;
																num6 = num9;
																connectionPool2 = connectionPool3;
															}
														}
													}
													if (connectionPool2 != null)
													{
														int total2 = connectionPool2.m_cpCtx.m_counter.total;
														if (total2 > 0)
														{
															int num10 = (int)(num6 / (float)(GRAV_FACTOR * 100) * (float)total2);
															if (num10 >= 1)
															{
																lock (connectionPool2)
																{
																	connectionPool2.m_rlbGravCounter += num10;
																}
																ThreadPool.QueueUserWorkItem(connectionPool2.RegulateNumOfConsThreadFunc, num10);
																connectionPool2.UpdatePotentialTotalCount(num10);
																ThreadPool.QueueUserWorkItem(connectionPool.PopulatePool, num10);
																if ((OraTrace.m_TraceLevel & 0x20) == 32)
																{
																	stringBuilder.Append("(GRAV) (");
																	stringBuilder.Append(value);
																	stringBuilder.Append(" = ");
																	stringBuilder.Append(num10);
																	stringBuilder.Append(" cons gravitating due to misses)");
																}
															}
														}
													}
												}
											}
										}
										if ((OraTrace.m_TraceLevel & 0x20) == 32)
										{
											stringBuilder.Append("\n");
											OraTrace.Trace(32u, stringBuilder.ToString());
										}
										((RLBMetrics)rLBCtx.RLBMetricsList[j]).CurDistribFreq += ((RLBMetrics)rLBCtx.RLBMetricsList[j]).MaxDistribFreq;
										if (((RLBMetrics)rLBCtx.RLBMetricsList[j]).CurDistribFreq >= 1073741822)
										{
											((RLBMetrics)rLBCtx.RLBMetricsList[j]).CurDistribFreq = 1073741822;
										}
									}
									else
									{
										stringBuilder.Append("\n");
										OraTrace.Trace(32u, stringBuilder.ToString());
									}
									return num;
								}
								int PreviousCount = 0;
								OpsCon.ReleaseSemaphore(m_semCPCtxAvaNumOfCons, 1, ref PreviousCount);
							}
							if (flag6 && i != 0)
							{
								i = rLBCtx.RLBMetricsList.Count - 1;
								flag6 = false;
								continue;
							}
							array3[i] = true;
							int num11 = int.MaxValue;
							int num12 = rLBCtx.RLBMetricsList.Count;
							for (int l = 0; l < rLBCtx.RLBMetricsList.Count; l++)
							{
								if (!array3[l])
								{
									if (((RLBMetrics)rLBCtx.RLBMetricsList[l]).CurDistribFreq == 0)
									{
										num12 = l;
										break;
									}
									if (((RLBMetrics)rLBCtx.RLBMetricsList[l]).CurDistribFreq < num11)
									{
										num12 = l;
									}
								}
							}
							i = num12;
						}
						while (!(DateTime.Now - now >= opoConCtx.timeOut));
						return ErrRes.CON_TIMEOUT_EXCEEDED;
					}
					flag4 = true;
				}
			}
			else
			{
				flag4 = true;
			}
			if (flag4)
			{
				if (!flag3)
				{
					Monitor.Enter(htInstToCp.SyncRoot);
					flag3 = true;
				}
				if (htInstToCp.Count == 0 && opoConCtx.pool == null)
				{
					num = ConnectionDispenser.CreateConnectionPool(ref opoConCtx);
					if (num != 0)
					{
						return num;
					}
				}
				while (true)
				{
					if (opoConCtx.pool == null)
					{
						int num13 = Interlocked.Increment(ref m_iteration) % htInstToCp.Count;
						if (m_iteration > 1073741823)
						{
							m_iteration = 0;
						}
						int num14 = 0;
						if (htInstToCp.Count > 0)
						{
							IDictionaryEnumerator enumerator3 = htInstToCp.GetEnumerator();
							while (enumerator3.MoveNext() && num14 != num13)
							{
								num14++;
							}
							opoConCtx.pool = (ConnectionPool)enumerator3.Value;
						}
						else
						{
							opoConCtx.pool = null;
						}
					}
					if (flag3)
					{
						Monitor.Exit(htInstToCp.SyncRoot);
						flag3 = false;
					}
					if (opoConCtx.pool != null)
					{
						m_counter.UpdateThreadWaitCount(opoConCtx.pool, 1);
						num = OpsCon.WaitForSingleObject(m_semCPCtxAvaNumOfCons, (int)opoConCtx.timeOut.TotalSeconds * 1000);
						m_counter.UpdateThreadWaitCount(opoConCtx.pool, -1);
						if (num != 0)
						{
							return ErrRes.CON_TIMEOUT_EXCEEDED;
						}
						num = opoConCtx.pool.GetConnection(opoConCtx);
						if (num == 0)
						{
							if ((OraTrace.m_PerformanceCounters & PerfCounterLevel.SoftConnectsPerSecond) == PerfCounterLevel.SoftConnectsPerSecond)
							{
								OraclePerfCounterCollection.SoftConnectsPerSecond.Increment();
							}
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.Trace(32u, " (GRID) (NON-RLB) (DISP) (" + opoConCtx.opoConRefCtx.instanceName + ")\n");
							}
							if (opoConCtx.m_txnid != null && opoConCtx.pool != null && opoConCtx.pool.m_cpCtx.m_htTxnIdToIntance[opoConCtx.m_txnid] == null)
							{
								opoConCtx.pool.m_cpCtx.m_htTxnIdToIntance[opoConCtx.m_txnid] = opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName;
							}
							if (opoConCtx.affinityInstanceName != null && opoConCtx.affinityInstanceName != opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName)
							{
								OraTrace.Trace(2u, " (POOL) (AFFINITY) (Dispensed con for " + opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName + " instead of " + opoConCtx.affinityInstanceName + " [" + opoConCtx.instanceConCount + "])\n");
								ConnectionPool connectionPool4 = (ConnectionPool)htInstToCp[opoConCtx.affinityInstanceName];
								StringBuilder stringBuilder2 = new StringBuilder();
								if (connectionPool4 != null)
								{
									stringBuilder2.Append(" (POOL) (AFFINITY) (inst=");
									stringBuilder2.Append(opoConCtx.affinityInstanceName);
									stringBuilder2.Append(": tot=");
									stringBuilder2.Append(connectionPool4.m_counter.total);
									stringBuilder2.Append("; used=");
									stringBuilder2.Append(connectionPool4.m_counter.total - connectionPool4.m_connections.Count);
									stringBuilder2.Append("; idle=");
									stringBuilder2.Append(connectionPool4.m_connections.Count);
									stringBuilder2.Append(")");
								}
								OraTrace.Trace(2u, stringBuilder2.ToString());
								connectionPool4 = (ConnectionPool)htInstToCp[opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName];
								StringBuilder stringBuilder3 = new StringBuilder();
								if (connectionPool4 != null)
								{
									stringBuilder3.Append(" (POOL) (AFFINITY) (inst=");
									stringBuilder3.Append(opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName);
									stringBuilder3.Append(": tot=");
									stringBuilder3.Append(connectionPool4.m_counter.total);
									stringBuilder3.Append("; used=");
									stringBuilder3.Append(connectionPool4.m_counter.total - connectionPool4.m_connections.Count);
									stringBuilder3.Append("; idle=");
									stringBuilder3.Append(connectionPool4.m_connections.Count);
									stringBuilder3.Append(")");
								}
								OraTrace.Trace(2u, stringBuilder3.ToString());
							}
							else
							{
								if (opoConCtx.affinityInstanceName != null)
								{
									OraTrace.Trace(2u, " (POOL) (AFFINITY) (Dispensed con for " + opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName + " appropriately, which honors affinity.\n");
								}
								else
								{
									OraTrace.Trace(2u, " (POOL) (AFFINITY) (Dispensed con for " + opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName + "; no affinity specified\n");
								}
								ConnectionPool connectionPool5 = (ConnectionPool)htInstToCp[opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName];
								StringBuilder stringBuilder4 = new StringBuilder();
								if (connectionPool5 != null)
								{
									stringBuilder4.Append(" (POOL) (AFFINITY) (inst=");
									stringBuilder4.Append(opoConCtx.pool.m_clonedCtx.opoConRefCtx.instanceName);
									stringBuilder4.Append(": tot=");
									stringBuilder4.Append(connectionPool5.m_counter.total);
									stringBuilder4.Append("; used=");
									stringBuilder4.Append(connectionPool5.m_counter.total - connectionPool5.m_connections.Count);
									stringBuilder4.Append("; idle=");
									stringBuilder4.Append(connectionPool5.m_connections.Count);
									stringBuilder4.Append(")");
								}
								OraTrace.Trace(2u, stringBuilder4.ToString());
							}
							return num;
						}
						int PreviousCount2 = 0;
						OpsCon.ReleaseSemaphore(m_semCPCtxAvaNumOfCons, 1, ref PreviousCount2);
					}
					if (DateTime.Now - now >= opoConCtx.timeOut)
					{
						break;
					}
					opoConCtx.pool = null;
				}
				return ErrRes.CON_TIMEOUT_EXCEEDED;
			}
			return 0;
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(ConnectionDispenser.m_htSvcToRLB.SyncRoot);
			}
			if (flag2)
			{
				Monitor.Exit(rLBCtx.htConToInst.SyncRoot);
			}
			if (flag3)
			{
				Monitor.Exit(htInstToCp.SyncRoot);
			}
		}
	}
}
