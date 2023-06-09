namespace Quartz.Spi;

/// <summary>
/// Allows different strategies for scheduling threads. The <see cref="M:Quartz.Spi.IThreadExecutor.Initialize" />
/// method is required to be called before the first call to
/// <see cref="M:Quartz.Spi.IThreadExecutor.Execute(Quartz.QuartzThread)" />. The Thread containing the work to be performed is
/// passed to execute and the work is scheduled by the underlying implementation.
///             </summary>
/// <author>matt.accola</author> 
public interface IThreadExecutor
{
	/// <summary>
	/// Submit a task for execution.
	/// </summary>
	/// <param name="thread">Thread to execute.</param>
	void Execute(QuartzThread thread);

	/// <summary>
	/// Initialize any state prior to calling <see cref="M:Quartz.Spi.IThreadExecutor.Execute(Quartz.QuartzThread)" />.
	/// </summary>
	void Initialize();
}
