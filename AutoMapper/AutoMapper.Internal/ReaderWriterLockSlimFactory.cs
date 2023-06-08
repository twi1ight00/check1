using System;

namespace AutoMapper.Internal;

public class ReaderWriterLockSlimFactory : IReaderWriterLockSlimFactory
{
	public class NoOpReaderWriterLock : IReaderWriterLockSlim, IDisposable
	{
		public void Dispose()
		{
		}

		public void EnterWriteLock()
		{
		}

		public void ExitWriteLock()
		{
		}

		public void EnterUpgradeableReadLock()
		{
		}

		public void ExitUpgradeableReadLock()
		{
		}

		public void EnterReadLock()
		{
		}

		public void ExitReadLock()
		{
		}
	}

	public IReaderWriterLockSlim Create()
	{
		return new NoOpReaderWriterLock();
	}
}
