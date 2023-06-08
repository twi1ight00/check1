using System;

namespace Richfit.Garnet.Module.Attachment.AbbyyOCR;

/// <summary>
/// 引擎池管理器（延迟初始化的单例模式）
/// </summary>
public sealed class EnginPoolManager
{
	private class Nested
	{
		internal static readonly EnginPoolManager instance = new EnginPoolManager();
	}

	public EnginesPool Pool;

	public static EnginPoolManager Instance => Nested.instance;

	private EnginPoolManager()
	{
		int availableCoresNumber = Environment.ProcessorCount;
		int allowedCoresNumber = GetAllowedCoresNumber();
		int optimalNumberOfThreads = 0;
		Pool = new EnginesPool((allowedCoresNumber != 0) ? Math.Min(allowedCoresNumber, availableCoresNumber) : availableCoresNumber, FreConfig.GetDeveloperSN(), 300000);
		Pool.AutoRecycleUsageCount = 100;
	}

	~EnginPoolManager()
	{
		if (Pool != null)
		{
			Pool.Dispose();
			Pool = null;
		}
	}

	private int GetAllowedCoresNumber()
	{
		int cores = 0;
		EngineLoader engineLoader = new EngineLoader(FreConfig.GetDeveloperSN());
		try
		{
			cores = engineLoader.Engine.CurrentLicense?.AllowedCoresCount ?? 2;
		}
		catch (Exception exp)
		{
			throw exp;
		}
		finally
		{
			if (engineLoader != null)
			{
				engineLoader.Dispose();
				engineLoader = null;
			}
		}
		return cores;
	}
}
