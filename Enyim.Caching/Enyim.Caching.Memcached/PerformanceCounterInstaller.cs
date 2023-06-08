using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;

namespace Enyim.Caching.Memcached;

[RunInstaller(true)]
public class PerformanceCounterInstaller : System.Diagnostics.PerformanceCounterInstaller
{
	public PerformanceCounterInstaller()
	{
		base.CategoryName = "Enyim.Caching.Memcached";
		base.CategoryType = PerformanceCounterCategoryType.MultiInstance;
		base.UninstallAction = UninstallAction.Remove;
		base.Counters.AddRange(DefaultPerformanceMonitor.OpMonitor.CreateCounters("Get"));
		base.Counters.AddRange(DefaultPerformanceMonitor.OpMonitor.CreateCounters("Set"));
		base.Counters.AddRange(DefaultPerformanceMonitor.OpMonitor.CreateCounters("Add"));
		base.Counters.AddRange(DefaultPerformanceMonitor.OpMonitor.CreateCounters("Replace"));
		base.Counters.AddRange(DefaultPerformanceMonitor.OpMonitor.CreateCounters("Delete"));
		base.Counters.AddRange(DefaultPerformanceMonitor.OpMonitor.CreateCounters("Increment"));
		base.Counters.AddRange(DefaultPerformanceMonitor.OpMonitor.CreateCounters("Decrement"));
		base.Counters.AddRange(DefaultPerformanceMonitor.OpMonitor.CreateCounters("Append"));
		base.Counters.AddRange(DefaultPerformanceMonitor.OpMonitor.CreateCounters("Prepend"));
	}
}
