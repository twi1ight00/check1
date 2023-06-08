using Quartz.Impl.AdoJobStore.Common;

namespace Quartz.Impl.AdoJobStore;

/// <summary> 
/// An interface for providing thread/resource locking in order to protect
/// resources from being altered by multiple threads at the same time.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface ISemaphore
{
	/// <summary>
	/// Whether this Semaphore implementation requires a database connection for
	/// its lock management operations.
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.ISemaphore.ObtainLock(Quartz.Impl.AdoJobStore.Common.DbMetadata,Quartz.Impl.AdoJobStore.ConnectionAndTransactionHolder,System.String)" />
	/// <seealso cref="M:Quartz.Impl.AdoJobStore.ISemaphore.ReleaseLock(System.String)" />
	bool RequiresConnection { get; }

	/// <summary> 
	/// Grants a lock on the identified resource to the calling thread (blocking
	/// until it is available).
	/// </summary>
	/// <returns> true if the lock was obtained.
	/// </returns>
	bool ObtainLock(DbMetadata metadata, ConnectionAndTransactionHolder conn, string lockName);

	/// <summary> Release the lock on the identified resource if it is held by the calling
	/// thread.
	/// </summary>
	void ReleaseLock(string lockName);
}
