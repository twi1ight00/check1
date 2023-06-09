using System;
using Quartz.Spi;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// <see cref="T:Quartz.Impl.AdoJobStore.JobStoreTX" /> is meant to be used in a standalone environment.
/// Both commit and rollback will be handled by this class.
/// </summary>
/// <author><a href="mailto:jeff@binaryfeed.org">Jeffrey Wescott</a></author>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class JobStoreTX : JobStoreSupport
{
	/// <summary>
	/// Called by the QuartzScheduler before the <see cref="T:Quartz.Spi.IJobStore" /> is
	/// used, in order to give the it a chance to Initialize.
	/// </summary>
	/// <param name="loadHelper"></param>
	/// <param name="signaler"></param>
	public override void Initialize(ITypeLoadHelper loadHelper, ISchedulerSignaler signaler)
	{
		base.Initialize(loadHelper, signaler);
		base.Log.Info("JobStoreTX initialized.");
	}

	/// <summary>
	/// For <see cref="T:Quartz.Impl.AdoJobStore.JobStoreTX" />, the non-managed TX connection is just 
	/// the normal connection because it is not CMT.
	/// </summary> 
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.GetConnection" />
	protected override ConnectionAndTransactionHolder GetNonManagedTXConnection()
	{
		return GetConnection();
	}

	/// <summary>
	/// Execute the given callback having optionally aquired the given lock.
	/// For <see cref="T:Quartz.Impl.AdoJobStore.JobStoreTX" />, because it manages its own transactions
	/// and only has the one datasource, this is the same behavior as 
	/// <see cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ExecuteInNonManagedTXLock(System.String,System.Action{Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder})" />.
	/// </summary>
	/// <param name="lockName">
	/// The name of the lock to aquire, for example "TRIGGER_ACCESS". 
	/// If null, then no lock is aquired, but the lockCallback is still
	/// executed in a transaction.
	/// </param>
	/// <param name="txCallback">Callback to execute.</param>
	/// <returns></returns>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.ExecuteInNonManagedTXLock(System.String,System.Action{Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder})" />
	/// <sssseealso crsef="JobStoreCMT.ExecuteInLock(string, ITransactionCallback)" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.GetNonManagedTXConnection" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.JobStoreSupport.GetConnection" />
	protected override object ExecuteInLock(string lockName, Func<ConnectionAndTransactionHolder, object> txCallback)
	{
		return ExecuteInNonManagedTXLock(lockName, txCallback);
	}
}
