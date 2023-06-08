using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using FREngine;

namespace Richfit.Garnet.Module.Attachment.AbbyyOCR;

public class EnginesPool : IDisposable
{
	private class EngineHolder : IDisposable
	{
		private IEngineLoader engineLoader;

		private IEngine engine;

		private Process process;

		private bool isEngineLocked;

		private int engineUsageCount;

		public EngineHolder(string projectId)
		{
			try
			{
				engineLoader = (OutprocLoader)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("110020D3-0000-1056-976E-008048D53AE3")));
				IHostProcessControl processControl = (IHostProcessControl)engineLoader;
				processControl.SetClientProcessId(Process.GetCurrentProcess().Id);
				process = Process.GetProcessById(processControl.ProcessId);
				engine = engineLoader.GetEngineObject(projectId);
			}
			catch (COMException exception)
			{
				uint hResult = (uint)exception.ErrorCode;
				if (hResult == 2147942405u)
				{
					throw new Exception("Launch permission for the work-process COM-object is not granted.\r\n                            Use DCOMCNFG to change security settings for the object. (" + exception.Message + ")");
				}
				throw;
			}
			isEngineLocked = false;
			engineUsageCount = 0;
		}

		public IEngine GetLockedEngine()
		{
			isEngineLocked = true;
			engineUsageCount++;
			return engine;
		}

		public void UnlockEngine()
		{
			isEngineLocked = false;
		}

		public bool IsEngineLocked()
		{
			return isEngineLocked;
		}

		public bool ContainsEngine(IEngine value)
		{
			return engine == value;
		}

		public int GetEngineUsageCount()
		{
			return engineUsageCount;
		}

		public void Dispose()
		{
			engine = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			if (engineLoader != null)
			{
				engineLoader.ExplicitlyUnload();
				engineLoader = null;
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			if (!process.WaitForExit(5000))
			{
				try
				{
					process.Kill();
				}
				catch (InvalidOperationException)
				{
				}
			}
			process.Dispose();
			process = null;
		}
	}

	private string projectId;

	private EngineHolder[] engineHolders;

	private object engineHolderLock;

	private int waitingTimeout;

	private Semaphore semaphore;

	private object usageCountLock;

	private int autoRecycleUsageCount;

	public int AutoRecycleUsageCount
	{
		get
		{
			lock (usageCountLock)
			{
				return autoRecycleUsageCount;
			}
		}
		set
		{
			lock (usageCountLock)
			{
				autoRecycleUsageCount = value;
			}
		}
	}

	public EnginesPool(int enginesCount, string developerSN, int waitingEngineTimeout)
	{
		projectId = developerSN;
		engineHolders = new EngineHolder[enginesCount];
		for (int i = 0; i < enginesCount; i++)
		{
			engineHolders[i] = new EngineHolder(projectId);
		}
		engineHolderLock = new object();
		waitingTimeout = waitingEngineTimeout;
		semaphore = new Semaphore(enginesCount, enginesCount);
		usageCountLock = new object();
		autoRecycleUsageCount = 0;
	}

	public IEngine GetEngine()
	{
		IEngine instance = null;
		if (semaphore.WaitOne(waitingTimeout, exitContext: false))
		{
			for (int i = 0; i < engineHolders.Length; i++)
			{
				lock (engineHolderLock)
				{
					if (!engineHolders[i].IsEngineLocked())
					{
						instance = engineHolders[i].GetLockedEngine();
						break;
					}
				}
			}
		}
		return instance;
	}

	public void ReleaseEngine(IEngine engine, bool isRecycleRequired)
	{
		for (int i = 0; i < engineHolders.Length; i++)
		{
			if (engineHolders[i].ContainsEngine(engine))
			{
				try
				{
					releaseEngine(i, isRecycleRequired);
					break;
				}
				finally
				{
					semaphore.Release();
				}
			}
		}
	}

	public void Dispose()
	{
		if (engineHolders != null)
		{
			for (int i = 0; i < engineHolders.Length; i++)
			{
				engineHolders[i].Dispose();
				engineHolders[i] = null;
			}
			engineHolders = null;
		}
	}

	private void releaseEngine(int engineIndex, bool isRecycleRequired)
	{
		lock (engineHolderLock)
		{
			bool isAutoRecycleRequired = AutoRecycleUsageCount != 0 && AutoRecycleUsageCount <= engineHolders[engineIndex].GetEngineUsageCount();
			engineHolders[engineIndex].UnlockEngine();
			if (isRecycleRequired || isAutoRecycleRequired)
			{
				engineHolders[engineIndex].Dispose();
				engineHolders[engineIndex] = new EngineHolder(projectId);
			}
		}
	}
}
