using System;
using System.Diagnostics;

namespace Enyim.Caching.Memcached;

public class DefaultPerformanceMonitor : IPerformanceMonitor, IDisposable
{
	internal static class Names
	{
		public const string Get = "Get";

		public const string Set = "Set";

		public const string Add = "Add";

		public const string Replace = "Replace";

		public const string Delete = "Delete";

		public const string Increment = "Increment";

		public const string Decrement = "Decrement";

		public const string Append = "Append";

		public const string Prepend = "Prepend";
	}

	internal class OpMonitor : IDisposable
	{
		private const string Total = " Total";

		private const string Hits = " Hits";

		private const string Misses = " Misses";

		private const string TotalPerSec = " Total/sec";

		private const string HitsPerSec = " Hits/sec";

		private const string MissesPerSec = " Misses/sec";

		private PerformanceCounter pcTotal;

		private PerformanceCounter pcHits;

		private PerformanceCounter pcMisses;

		private PerformanceCounter pcTotalPerSec;

		private PerformanceCounter pcHitsPerSec;

		private PerformanceCounter pcMissesPerSec;

		public OpMonitor(string instance, string category, string name)
		{
			pcTotal = new PerformanceCounter(category, name + " Total", instance, readOnly: false);
			pcHits = new PerformanceCounter(category, name + " Hits", instance, readOnly: false);
			pcMisses = new PerformanceCounter(category, name + " Misses", instance, readOnly: false);
			pcTotalPerSec = new PerformanceCounter(category, name + " Total/sec", instance, readOnly: false);
			pcHitsPerSec = new PerformanceCounter(category, name + " Hits/sec", instance, readOnly: false);
			pcMissesPerSec = new PerformanceCounter(category, name + " Misses/sec", instance, readOnly: false);
			pcHits.RawValue = 0L;
			pcHitsPerSec.RawValue = 0L;
			pcMisses.RawValue = 0L;
			pcMissesPerSec.RawValue = 0L;
			pcTotal.RawValue = 0L;
			pcTotalPerSec.RawValue = 0L;
		}

		~OpMonitor()
		{
			Dispose();
		}

		public void Increment(int amount, bool success)
		{
			pcTotal.IncrementBy(amount);
			pcTotalPerSec.IncrementBy(amount);
			if (success)
			{
				pcHits.IncrementBy(amount);
				pcHitsPerSec.IncrementBy(amount);
			}
			else
			{
				pcMisses.IncrementBy(amount);
				pcMissesPerSec.IncrementBy(amount);
			}
		}

		internal static CounterCreationData[] CreateCounters(string op)
		{
			return new CounterCreationData[6]
			{
				new CounterCreationData(op + " Total", "Total number of " + op + " operations during the client's lifetime", PerformanceCounterType.NumberOfItems64),
				new CounterCreationData(op + " Hits", "Total number of successful " + op + " operations during the client's lifetime", PerformanceCounterType.NumberOfItems64),
				new CounterCreationData(op + " Misses", "Total number of failed " + op + " operations during the client's lifetime", PerformanceCounterType.NumberOfItems64),
				new CounterCreationData(op + " Total/sec", "Number of " + op + " operations handled by the client per second.", PerformanceCounterType.RateOfCountsPerSecond64),
				new CounterCreationData(op + " Hits/sec", "Number of successful " + op + " operations handled by the client per second.", PerformanceCounterType.RateOfCountsPerSecond64),
				new CounterCreationData(op + " Misses/sec", "Number of failed " + op + " operations handled by the client per second.", PerformanceCounterType.RateOfCountsPerSecond64)
			};
		}

		public void Dispose()
		{
			((IDisposable)pcTotalPerSec).Dispose();
		}

		void IDisposable.Dispose()
		{
			GC.SuppressFinalize(this);
			if (pcHits != null)
			{
				pcHits.Dispose();
				pcHitsPerSec.Dispose();
				pcMisses.Dispose();
				pcMissesPerSec.Dispose();
				pcTotal.Dispose();
				pcTotalPerSec.Dispose();
				pcHits = null;
				pcHitsPerSec = null;
				pcMisses = null;
				pcMissesPerSec = null;
				pcTotal = null;
				pcTotalPerSec = null;
			}
		}
	}

	public const string CategoryName = "Enyim.Caching.Memcached";

	private OpMonitor pcGet;

	private OpMonitor pcSet;

	private OpMonitor pcAdd;

	private OpMonitor pcReplace;

	private OpMonitor pcDelete;

	private OpMonitor pcIncrement;

	private OpMonitor pcDecrement;

	private OpMonitor pcAppend;

	private OpMonitor pcPrepend;

	public DefaultPerformanceMonitor(string instance)
	{
		pcGet = new OpMonitor(instance, "Enyim.Caching.Memcached", "Get");
		pcSet = new OpMonitor(instance, "Enyim.Caching.Memcached", "Set");
		pcAdd = new OpMonitor(instance, "Enyim.Caching.Memcached", "Add");
		pcReplace = new OpMonitor(instance, "Enyim.Caching.Memcached", "Replace");
		pcDelete = new OpMonitor(instance, "Enyim.Caching.Memcached", "Delete");
		pcIncrement = new OpMonitor(instance, "Enyim.Caching.Memcached", "Increment");
		pcDecrement = new OpMonitor(instance, "Enyim.Caching.Memcached", "Decrement");
		pcAppend = new OpMonitor(instance, "Enyim.Caching.Memcached", "Append");
		pcPrepend = new OpMonitor(instance, "Enyim.Caching.Memcached", "Prepend");
	}

	~DefaultPerformanceMonitor()
	{
		Dispose();
	}

	public void Dispose()
	{
		((IDisposable)this).Dispose();
	}

	void IDisposable.Dispose()
	{
		GC.SuppressFinalize(this);
		if (pcGet != null)
		{
			pcGet.Dispose();
			pcSet.Dispose();
			pcAdd.Dispose();
			pcReplace.Dispose();
			pcDelete.Dispose();
			pcIncrement.Dispose();
			pcDecrement.Dispose();
			pcAppend.Dispose();
			pcPrepend.Dispose();
			pcGet = null;
			pcSet = null;
			pcAdd = null;
			pcReplace = null;
			pcDelete = null;
			pcIncrement = null;
			pcDecrement = null;
			pcAppend = null;
			pcPrepend = null;
		}
	}

	void IPerformanceMonitor.Get(int amount, bool success)
	{
		pcGet.Increment(amount, success);
	}

	void IPerformanceMonitor.Store(StoreMode mode, int amount, bool success)
	{
		switch (mode)
		{
		case StoreMode.Add:
			pcAdd.Increment(amount, success);
			break;
		case StoreMode.Replace:
			pcReplace.Increment(amount, success);
			break;
		case StoreMode.Set:
			pcSet.Increment(amount, success);
			break;
		}
	}

	void IPerformanceMonitor.Delete(int amount, bool success)
	{
		pcDelete.Increment(amount, success);
	}

	void IPerformanceMonitor.Mutate(MutationMode mode, int amount, bool success)
	{
		switch (mode)
		{
		case MutationMode.Increment:
			pcIncrement.Increment(amount, success);
			break;
		case MutationMode.Decrement:
			pcDecrement.Increment(amount, success);
			break;
		}
	}

	void IPerformanceMonitor.Concatenate(ConcatenationMode mode, int amount, bool success)
	{
		switch (mode)
		{
		case ConcatenationMode.Append:
			pcAppend.Increment(amount, success);
			break;
		case ConcatenationMode.Prepend:
			pcPrepend.Increment(amount, success);
			break;
		}
	}
}
