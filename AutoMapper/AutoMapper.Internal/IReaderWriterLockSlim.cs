using System;

namespace AutoMapper.Internal;

public interface IReaderWriterLockSlim : IDisposable
{
	void EnterWriteLock();

	void ExitWriteLock();

	void EnterUpgradeableReadLock();

	void ExitUpgradeableReadLock();

	void EnterReadLock();

	void ExitReadLock();
}
