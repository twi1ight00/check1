using System;
using System.Collections;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;

namespace Oracle.DataAccess.Client;

[SecurityPermission(SecurityAction.Assert, ControlThread = true)]
internal class OracleTuningAgent
{
	private enum AgentState
	{
		INIT,
		WAIT,
		SCAN,
		REDUCE,
		OPTIMIZE,
		WATCH,
		REVERT
	}

	internal enum RecommendationType
	{
		SCS
	}

	private class AgentInput
	{
		internal int m_agentKey;

		internal int m_poolId;

		internal string m_poolConnectionString;

		internal UpdateRecommendations m_UpdateRecommendationsDeleg;

		internal IncrementStmtSamplesLimit m_incrementStmtSamplesDeleg;

		internal Hashtable m_collatedData;

		internal ArrayList m_listOfData = new ArrayList();

		internal int m_scs;

		internal int m_scsRecommended = 30;

		internal int m_noOfConnections;

		internal bool m_registered = true;

		internal bool m_scsTuningUptoFESDone;

		internal bool m_scsTuningUptoUniqStmtsDone;

		internal bool m_scsResetDone;

		internal int m_noOfSubmissions;
	}

	internal delegate void UpdateRecommendations(RecommendationType recommendationType, object recommendation);

	internal delegate void IncrementStmtSamplesLimit();

	internal const string ORA01000 = "ORA-01000";

	internal const float StatementCacheDecrementForOra01000 = 0.9f;

	internal const float IgnoreStatementCacheDecrementPercentage = 0.9f;

	internal const float MinPercentOfRAMForTuning = 0.3f;

	internal const float MinPercentOfRAMNeeded = 0.2f;

	internal const int m_privateBytesPerStmt = 51200;

	internal const int MaxSubmissionsToBeProcessed = 10;

	internal const int DefaultStmtSamplesLimit = 1000;

	internal const int StmtSampleIncrement = 100;

	private const int ScanInterval = 10000;

	private const int SuspendInterval = 10000;

	private const int MinExecutionsNeeded = 10;

	private const int NoOfInternallyExecutedStmts = 5;

	private const int MinSCSIncrement = 5;

	private const int MinBufferCnt = 2;

	private const double SCSBufferPercentage = 0.2;

	private const int WaitInterval = 5000;

	private const int WatchInterval = 10000;

	private const float HighMemPercentage = 0.7f;

	private const float VeryHighMemPercentage = 0.8f;

	internal static readonly long m_minRAMReqdForTuning;

	internal static readonly long m_minRAMNeeded;

	private static readonly bool m_isUsableMemInfoAvail;

	private static readonly long m_highMem;

	private static readonly long m_installedRAM;

	private static readonly long m_veryHighMem;

	private static long m_memoryConsumptionToReduce;

	internal static bool bHighMemoryAlertFlag;

	private static AgentState m_agentState;

	private static Thread m_tuningThread;

	private static bool m_allPoolsHaveUnregistered;

	private static int m_numberOfRegistrations;

	private static AgentInput m_selectedInput;

	private static int m_selectedInputIndex;

	private static int m_watchCycles;

	private static int m_scanCyclesToSkip;

	private static object m_registrationLock;

	private static ArrayList m_input;

	static OracleTuningAgent()
	{
		m_minRAMReqdForTuning = -1L;
		m_minRAMNeeded = -1L;
		m_isUsableMemInfoAvail = false;
		m_highMem = -1L;
		m_installedRAM = -1L;
		m_veryHighMem = -1L;
		m_memoryConsumptionToReduce = 0L;
		bHighMemoryAlertFlag = false;
		m_agentState = AgentState.INIT;
		m_tuningThread = null;
		m_allPoolsHaveUnregistered = false;
		m_numberOfRegistrations = 0;
		m_selectedInput = null;
		m_selectedInputIndex = -1;
		m_watchCycles = 1;
		m_scanCyclesToSkip = 1;
		m_registrationLock = new object();
		m_input = new ArrayList();
		try
		{
			long availUsableMem = -1L;
			long totalPhysMem = -1L;
			if (OpsCom.GetSystemMemoryInfo(ref availUsableMem, ref totalPhysMem) == 0)
			{
				m_isUsableMemInfoAvail = true;
				m_highMem = (long)(0.7f * (float)availUsableMem);
				m_veryHighMem = (long)(0.8f * (float)availUsableMem);
				m_installedRAM = totalPhysMem;
				m_minRAMReqdForTuning = (long)(0.3f * (float)m_installedRAM);
				m_minRAMNeeded = (long)(0.2f * (float)m_installedRAM);
			}
			else if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::OracleTuningAgent(): Virtual Memory Information not available \n");
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::OracleTuningAgent(): Exception : " + ex.ToString() + " \n");
			}
		}
	}

	internal static void Register(string connectionPoolString, string poolName, int poolId, UpdateRecommendations updateRecommendationsDeleg, IncrementStmtSamplesLimit incrementStmtSamplesDeleg, out int agentKey)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTuningAgent::Register()\n");
		}
		agentKey = -1;
		if (!m_isUsableMemInfoAvail)
		{
			return;
		}
		lock (m_registrationLock)
		{
			lock (m_input)
			{
				AgentInput agentInput = null;
				for (int i = 0; i < m_input.Count; i++)
				{
					if (m_input[i] is AgentInput agentInput2 && agentInput2.m_poolConnectionString == connectionPoolString)
					{
						if (!agentInput2.m_registered)
						{
							m_numberOfRegistrations++;
							agentInput2.m_registered = true;
						}
						agentInput2.m_UpdateRecommendationsDeleg = updateRecommendationsDeleg;
						agentInput2.m_incrementStmtSamplesDeleg = incrementStmtSamplesDeleg;
						agentInput = agentInput2;
					}
				}
				if (agentInput == null)
				{
					agentInput = new AgentInput();
					agentInput.m_poolConnectionString = connectionPoolString;
					agentInput.m_poolId = poolId;
					agentInput.m_UpdateRecommendationsDeleg = updateRecommendationsDeleg;
					agentInput.m_incrementStmtSamplesDeleg = incrementStmtSamplesDeleg;
					m_input.Add(agentInput);
					agentInput.m_agentKey = m_input.Count - 1;
					m_numberOfRegistrations++;
				}
				agentKey = agentInput.m_agentKey;
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(64u, " (TUNING) OracleTuningAgent::Register(): Registered pool \"" + poolName + "\" with pool Id " + poolId + "\n");
				}
			}
			if (m_numberOfRegistrations == 1)
			{
				m_allPoolsHaveUnregistered = false;
				if (m_tuningThread == null)
				{
					try
					{
						ThreadStart start = TuningFunction;
						m_tuningThread = new Thread(start);
						m_tuningThread.IsBackground = true;
						m_tuningThread.Start();
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(64u, " (TUNING) OracleTuningAgent::Register(): Tuning thread started.\n");
						}
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::Register(): Error in starting Tuning Thread : " + ex.ToString() + " \n");
						}
					}
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleTuningAgent::Register()\n");
		}
	}

	internal static void Unregister(int agentKey)
	{
		lock (m_registrationLock)
		{
			lock (m_input)
			{
				AgentInput agentInput = m_input[agentKey] as AgentInput;
				if (agentInput.m_registered)
				{
					m_numberOfRegistrations--;
					agentInput.m_registered = false;
				}
			}
			if (m_numberOfRegistrations == 0)
			{
				m_allPoolsHaveUnregistered = true;
			}
		}
	}

	internal static void TuningFunction()
	{
		while (true)
		{
			try
			{
				while (true)
				{
					if (m_allPoolsHaveUnregistered)
					{
						m_agentState = AgentState.INIT;
						Thread.Sleep(10000);
						continue;
					}
					switch (m_agentState)
					{
					case AgentState.INIT:
						DoInitialization();
						continue;
					case AgentState.WAIT:
						DoWait();
						continue;
					case AgentState.SCAN:
						DoScan();
						continue;
					case AgentState.OPTIMIZE:
						DoOptimize();
						continue;
					case AgentState.REDUCE:
						DoReduce();
						continue;
					case AgentState.WATCH:
						DoWatch();
						continue;
					case AgentState.REVERT:
						DoRevert();
						continue;
					}
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(64u, string.Concat(" (ERROR) OracleTuningAgent::TuningFunction(): Unrecognized agent state ", m_agentState, " \n"));
					}
				}
			}
			catch (ThreadAbortException ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::TuningFunction(): Error : " + ex.ToString() + " \n");
				}
				break;
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::TuningFunction(): Error : " + ex2.ToString() + " \n");
				}
				m_selectedInput = null;
				m_selectedInputIndex = -1;
				m_agentState = AgentState.SCAN;
			}
		}
	}

	private static void DoInitialization()
	{
		m_agentState = AgentState.WAIT;
	}

	private static void DoWait()
	{
		int num = 0;
		int num2 = 0;
		do
		{
			Thread.Sleep(5000);
			int count = m_input.Count;
			num = count - num2;
			num2 = count;
		}
		while (num <= 0);
		Thread.Sleep(5000);
		m_scanCyclesToSkip = 0;
		m_agentState = AgentState.SCAN;
	}

	private static void DoScan()
	{
		Thread.Sleep(10000 * m_scanCyclesToSkip);
		long currentVirtualMemorySize = GetCurrentVirtualMemorySize();
		long availPhysMem = -1L;
		if (OpsCom.GetAvailPhysMemory(ref availPhysMem) != 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::DoScan(): Available Physical Memory Information not found \n");
			}
		}
		else if (currentVirtualMemorySize < m_highMem && availPhysMem > m_minRAMReqdForTuning)
		{
			bHighMemoryAlertFlag = false;
			SelectPoolToOptimize();
			if (m_selectedInput == null)
			{
				Thread.Sleep(10000 * m_scanCyclesToSkip);
				m_scanCyclesToSkip = 1;
				m_agentState = AgentState.SCAN;
			}
			else
			{
				m_agentState = AgentState.OPTIMIZE;
			}
		}
		else if (currentVirtualMemorySize > m_veryHighMem || availPhysMem < m_minRAMNeeded)
		{
			if (currentVirtualMemorySize > m_veryHighMem)
			{
				m_memoryConsumptionToReduce = currentVirtualMemorySize - m_veryHighMem;
			}
			else
			{
				m_memoryConsumptionToReduce = 0L;
			}
			if (availPhysMem < m_minRAMNeeded && m_memoryConsumptionToReduce < m_minRAMNeeded - availPhysMem)
			{
				m_memoryConsumptionToReduce = m_minRAMNeeded - availPhysMem;
			}
			m_agentState = AgentState.REDUCE;
			if (!bHighMemoryAlertFlag)
			{
				ReleaseSamplesFromAllAgentInputs();
			}
			bHighMemoryAlertFlag = true;
		}
		else
		{
			if (!bHighMemoryAlertFlag)
			{
				ReleaseSamplesFromAllAgentInputs();
			}
			bHighMemoryAlertFlag = true;
			m_scanCyclesToSkip = 1;
			m_agentState = AgentState.SCAN;
		}
	}

	private static void DoOptimize()
	{
		m_selectedInput.m_collatedData = CollateData();
		DoOptimizeSCS();
	}

	private static void UpdateSCSTuningInfo(bool scsFESTuningDone, bool SCSUniqStmtDone)
	{
		AgentInput agentInput = m_input[m_selectedInput.m_agentKey] as AgentInput;
		agentInput.m_scsTuningUptoFESDone = scsFESTuningDone;
		agentInput.m_scsTuningUptoUniqStmtsDone = SCSUniqStmtDone;
	}

	private static void DoOptimizeSCS()
	{
		if (m_selectedInput.m_scs >= OraTrace.MaxStatementCacheSize)
		{
			if (m_selectedInput.m_scs > OraTrace.MaxStatementCacheSize && m_selectedInput.m_UpdateRecommendationsDeleg != null)
			{
				int maxStatementCacheSize = OraTrace.MaxStatementCacheSize;
				m_selectedInput.m_UpdateRecommendationsDeleg(RecommendationType.SCS, maxStatementCacheSize);
				m_selectedInput.m_scsRecommended = maxStatementCacheSize;
				SetRecommendedSCS(m_selectedInputIndex, maxStatementCacheSize);
			}
			UpdateSCSTuningInfo(scsFESTuningDone: true, SCSUniqStmtDone: true);
			m_scanCyclesToSkip = 1;
			m_agentState = AgentState.SCAN;
			return;
		}
		Hashtable collatedData = m_selectedInput.m_collatedData;
		if (collatedData != null)
		{
			if (!m_selectedInput.m_scsTuningUptoFESDone)
			{
				OptimizeSCSUptoFES(collatedData);
			}
			else
			{
				OptimizeSCSUptoUniqStmt(collatedData);
			}
		}
	}

	private static void OptimizeSCSUptoUniqStmt(Hashtable data)
	{
		int count = data.Count;
		count += 5;
		if (m_selectedInput.m_scs < count)
		{
			try
			{
				int num = (int)Math.Ceiling(0.1 * (double)(count - m_selectedInput.m_scs));
				if (num < 5)
				{
					num = 5;
				}
				int num2 = m_selectedInput.m_scs + num;
				if (num2 > count)
				{
					num2 = count;
				}
				if (m_selectedInput.m_UpdateRecommendationsDeleg != null)
				{
					if (num2 > OraTrace.MaxStatementCacheSize)
					{
						num2 = OraTrace.MaxStatementCacheSize;
					}
					m_selectedInput.m_UpdateRecommendationsDeleg(RecommendationType.SCS, num2);
					m_selectedInput.m_scsRecommended = num2;
					SetRecommendedSCS(m_selectedInputIndex, num2);
				}
				UpdateSCSTuningInfo(scsFESTuningDone: true, SCSUniqStmtDone: false);
				m_watchCycles = 6;
				m_agentState = AgentState.WAIT;
				return;
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::OptimizeSCSUptoUniqStmt(): ERROR: " + ex.ToString() + " \n");
				}
				return;
			}
		}
		if ((double)m_selectedInput.m_scs > 1.1 * (double)count)
		{
			int num3 = (int)Math.Ceiling((double)(m_selectedInput.m_scs - count) * 0.1);
			if (num3 > 0)
			{
				int num4 = m_selectedInput.m_scs - num3;
				if (m_selectedInput.m_UpdateRecommendationsDeleg != null)
				{
					if (num4 > OraTrace.MaxStatementCacheSize)
					{
						num4 = OraTrace.MaxStatementCacheSize;
					}
					m_selectedInput.m_UpdateRecommendationsDeleg(RecommendationType.SCS, num4);
					m_selectedInput.m_scsRecommended = num4;
					SetRecommendedSCS(m_selectedInputIndex, num4);
				}
				UpdateSCSTuningInfo(scsFESTuningDone: true, SCSUniqStmtDone: false);
			}
			else
			{
				UpdateSCSTuningInfo(scsFESTuningDone: true, SCSUniqStmtDone: true);
			}
			m_scanCyclesToSkip = 1;
			m_agentState = AgentState.SCAN;
		}
		else
		{
			UpdateSCSTuningInfo(scsFESTuningDone: true, SCSUniqStmtDone: true);
			m_scanCyclesToSkip = 1;
			m_agentState = AgentState.SCAN;
		}
	}

	private static void OptimizeSCSUptoFES(Hashtable data)
	{
		long num = 0L;
		foreach (StatementDetails value in data.Values)
		{
			num += value.m_executionsIfNotSelect;
		}
		double num2 = num / data.Count;
		int num3 = 0;
		foreach (StatementDetails value2 in data.Values)
		{
			if ((double)value2.m_executionsIfNotSelect >= num2)
			{
				num3++;
			}
		}
		int num4 = (int)(0.2 * (double)num3);
		num3 = ((num4 <= 2) ? (num3 + 7) : (num3 + (num4 + 5)));
		int num5 = data.Count + 5;
		if (m_selectedInput.m_scs < num3 && m_selectedInput.m_scs < num5)
		{
			try
			{
				int num6 = (int)Math.Ceiling(0.1 * (double)(num3 - m_selectedInput.m_scs));
				if (num6 < 5)
				{
					num6 = 5;
				}
				int num7 = m_selectedInput.m_scs + num6;
				if (num7 > num3)
				{
					num7 = num3;
				}
				if (num7 > num5)
				{
					num7 = num5;
				}
				if (m_selectedInput.m_UpdateRecommendationsDeleg != null)
				{
					if (num7 > OraTrace.MaxStatementCacheSize)
					{
						num7 = OraTrace.MaxStatementCacheSize;
					}
					m_selectedInput.m_UpdateRecommendationsDeleg(RecommendationType.SCS, num7);
					m_selectedInput.m_scsRecommended = num7;
					SetRecommendedSCS(m_selectedInputIndex, num7);
				}
				UpdateSCSTuningInfo(scsFESTuningDone: false, SCSUniqStmtDone: false);
				m_watchCycles = 6;
				m_agentState = AgentState.WATCH;
				return;
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::OptimizeSCSUptoFES(): ERROR: " + ex.ToString() + " \n");
				}
				return;
			}
		}
		UpdateSCSTuningInfo(scsFESTuningDone: true, SCSUniqStmtDone: false);
		m_scanCyclesToSkip = 1;
		m_agentState = AgentState.SCAN;
	}

	private static void DoReduce()
	{
		int num = (int)Math.Ceiling((double)m_memoryConsumptionToReduce / 51200.0);
		ArrayList poolIDsToReduce = GetPoolIDsToReduce();
		if (poolIDsToReduce.Count == 0)
		{
			m_scanCyclesToSkip = 3;
			m_agentState = AgentState.SCAN;
			return;
		}
		int num2 = 0;
		foreach (int item in poolIDsToReduce)
		{
			num2 += (m_input[item] as AgentInput).m_noOfConnections;
		}
		int num3 = (int)Math.Ceiling((double)num / (double)num2);
		foreach (int item2 in poolIDsToReduce)
		{
			AgentInput agentInput = m_input[item2] as AgentInput;
			int num4 = agentInput.m_scsRecommended - num3;
			if (num4 < 30)
			{
				num4 = 30;
			}
			agentInput.m_UpdateRecommendationsDeleg(RecommendationType.SCS, num4);
			agentInput.m_scsRecommended = num4;
		}
		m_memoryConsumptionToReduce = 0L;
		m_scanCyclesToSkip = 6;
		m_agentState = AgentState.SCAN;
	}

	private static void DoWatch()
	{
		if (m_watchCycles > 0)
		{
			Thread.Sleep(10000);
		}
		long currentVirtualMemorySize = GetCurrentVirtualMemorySize();
		long availPhysMem = -1L;
		if (OpsCom.GetAvailPhysMemory(ref availPhysMem) != 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::DoWatch(): Available Physical Memory Information not found. SCS Reverted \n");
			}
			m_agentState = AgentState.REVERT;
			m_watchCycles = 0;
		}
		else if (currentVirtualMemorySize > m_veryHighMem || availPhysMem < m_minRAMNeeded)
		{
			m_agentState = AgentState.REVERT;
			m_watchCycles = 0;
		}
		else if (--m_watchCycles > 0)
		{
			m_agentState = AgentState.WATCH;
		}
		else
		{
			m_agentState = AgentState.SCAN;
		}
	}

	private static void DoRevert()
	{
		try
		{
			if (m_selectedInput.m_UpdateRecommendationsDeleg != null && m_selectedInput.m_UpdateRecommendationsDeleg != null)
			{
				if (m_selectedInput.m_scs <= OraTrace.MaxStatementCacheSize)
				{
					m_selectedInput.m_UpdateRecommendationsDeleg(RecommendationType.SCS, m_selectedInput.m_scs);
					m_selectedInput.m_scsRecommended = m_selectedInput.m_scs;
					SetRecommendedSCS(m_selectedInputIndex, m_selectedInput.m_scs);
				}
				else
				{
					int maxStatementCacheSize = OraTrace.MaxStatementCacheSize;
					m_selectedInput.m_UpdateRecommendationsDeleg(RecommendationType.SCS, maxStatementCacheSize);
					m_selectedInput.m_scsRecommended = maxStatementCacheSize;
					SetRecommendedSCS(m_selectedInputIndex, maxStatementCacheSize);
				}
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(64u, " (ERROR) OracleTuningAgent::DoRevert(): ERROR: " + ex.ToString() + " \n");
			}
		}
		m_scanCyclesToSkip = 6;
		m_agentState = AgentState.SCAN;
	}

	private static void ResetAllTheTuningFlags()
	{
		for (int i = 0; i < m_input.Count; i++)
		{
			AgentInput agentInput = m_input[i] as AgentInput;
			agentInput.m_scsTuningUptoFESDone = false;
			agentInput.m_scsTuningUptoUniqStmtsDone = false;
		}
	}

	private static void ReleaseSamplesFromAllAgentInputs()
	{
		int count = m_input.Count;
		if (count == 0)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			AgentInput agentInput = m_input[i] as AgentInput;
			if (agentInput.m_listOfData.Count <= 0)
			{
				continue;
			}
			lock (agentInput)
			{
				if (agentInput.m_listOfData.Count > 0)
				{
					agentInput.m_listOfData = new ArrayList();
				}
			}
		}
	}

	private static void SetRecommendedSCS(int agentInputIndex, int scsRecommended)
	{
		AgentInput agentInput = m_input[agentInputIndex] as AgentInput;
		agentInput.m_scsRecommended = scsRecommended;
	}

	private static void SelectPoolToOptimize()
	{
		AgentInput agentInput = null;
		m_selectedInput = null;
		m_selectedInputIndex = -1;
		int count = m_input.Count;
		int selectedInputIndex = -1;
		if (count != 0)
		{
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				AgentInput agentInput2 = m_input[i] as AgentInput;
				if (agentInput2.m_registered)
				{
					int noOfSubmissions = agentInput2.m_noOfSubmissions;
					if (noOfSubmissions > num && agentInput2.m_listOfData.Count != 0 && !agentInput2.m_scsTuningUptoFESDone)
					{
						num = noOfSubmissions;
						agentInput = agentInput2;
						selectedInputIndex = i;
					}
				}
			}
			bool flag = false;
			if (agentInput == null)
			{
				num = 0;
				for (int j = 0; j < count; j++)
				{
					AgentInput agentInput3 = m_input[j] as AgentInput;
					if (!agentInput3.m_registered)
					{
						continue;
					}
					int noOfSubmissions2 = agentInput3.m_noOfSubmissions;
					if (noOfSubmissions2 > num && agentInput3.m_listOfData.Count != 0)
					{
						flag = true;
						if (!agentInput3.m_scsTuningUptoUniqStmtsDone)
						{
							num = noOfSubmissions2;
							agentInput = agentInput3;
							selectedInputIndex = j;
						}
					}
				}
			}
			if (flag && agentInput == null)
			{
				ResetAllTheTuningFlags();
				return;
			}
		}
		if (agentInput != null)
		{
			m_selectedInput = new AgentInput();
			m_selectedInput.m_agentKey = agentInput.m_agentKey;
			m_selectedInput.m_poolConnectionString = agentInput.m_poolConnectionString;
			m_selectedInput.m_poolId = agentInput.m_poolId;
			m_selectedInput.m_UpdateRecommendationsDeleg = agentInput.m_UpdateRecommendationsDeleg;
			m_selectedInput.m_incrementStmtSamplesDeleg = agentInput.m_incrementStmtSamplesDeleg;
			m_selectedInput.m_registered = agentInput.m_registered;
			m_selectedInput.m_scs = agentInput.m_scs;
			m_selectedInput.m_noOfConnections = agentInput.m_noOfConnections;
			m_selectedInput.m_scsTuningUptoFESDone = agentInput.m_scsTuningUptoFESDone;
			m_selectedInput.m_scsTuningUptoUniqStmtsDone = agentInput.m_scsTuningUptoUniqStmtsDone;
			lock (agentInput)
			{
				m_selectedInput.m_listOfData = agentInput.m_listOfData;
				agentInput.m_listOfData = new ArrayList();
				agentInput.m_noOfSubmissions = 0;
			}
			agentInput.m_scsResetDone = false;
			m_selectedInputIndex = selectedInputIndex;
		}
	}

	private static ArrayList GetPoolIDsToReduce()
	{
		int count = m_input.Count;
		ArrayList arrayList = new ArrayList();
		if (count != 0)
		{
			for (int i = 0; i < count; i++)
			{
				AgentInput agentInput = m_input[i] as AgentInput;
				if (agentInput.m_registered && agentInput.m_scsRecommended > 30)
				{
					arrayList.Add(i);
				}
			}
		}
		return arrayList;
	}

	internal static void AddData(int poolId, int numberOfConnections, int scs, Hashtable statementData)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTuningAgent::AddData()\n");
		}
		if (!(m_input[poolId] is AgentInput agentInput))
		{
			return;
		}
		lock (agentInput)
		{
			if (agentInput.m_listOfData.Count >= 10)
			{
				agentInput.m_listOfData.RemoveAt(0);
			}
			agentInput.m_listOfData.Add(statementData);
			agentInput.m_scs = scs;
			agentInput.m_noOfConnections = numberOfConnections;
			agentInput.m_noOfSubmissions++;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OracleTuningAgent::AddData()\n");
		}
	}

	private static Hashtable CollateData()
	{
		ArrayList listOfData = m_selectedInput.m_listOfData;
		Hashtable hashtable = new Hashtable();
		foreach (Hashtable item in listOfData)
		{
			foreach (DictionaryEntry item2 in item)
			{
				StatementDetails statementDetails = item2.Value as StatementDetails;
				if (!(hashtable[item2.Key] is StatementDetails statementDetails2))
				{
					hashtable[item2.Key] = statementDetails;
				}
				else if (statementDetails.m_executionsIfNotSelect != 0)
				{
					statementDetails2.m_executionsIfNotSelect += statementDetails.m_executionsIfNotSelect;
				}
			}
		}
		return hashtable;
	}

	private static long GetCurrentVirtualMemorySize()
	{
		Process currentProcess = Process.GetCurrentProcess();
		long num = currentProcess.VirtualMemorySize64;
		currentProcess.Dispose();
		if (num < 0 && num >= int.MinValue)
		{
			num = (uint)num;
		}
		return num;
	}
}
