using System;
using System.Threading;

namespace AutoMapper.Internal;

public class ReaderWriterLockSlimFactoryOverride : IReaderWriterLockSlimFactory
{
	private class ReaderWriterLockSlimProxy : IReaderWriterLockSlim, IDisposable
	{
		private readonly ReaderWriterLockSlim _readerWriterLockSlim;

		public ReaderWriterLockSlimProxy(ReaderWriterLockSlim readerWriterLockSlim)
		{
			_readerWriterLockSlim = readerWriterLockSlim;
		}

		public void Dispose()
		{
			_readerWriterLockSlim.Dispose();
		}

		public void EnterWriteLock()
		{
			_readerWriterLockSlim.EnterWriteLock();
		}

		public void ExitWriteLock()
		{
			_readerWriterLockSlim.ExitWriteLock();
		}

		public void EnterUpgradeableReadLock()
		{
			_readerWriterLockSlim.EnterUpgradeableReadLock();
		}

		public void ExitUpgradeableReadLock()
		{
			_readerWriterLockSlim.ExitUpgradeableReadLock();
		}

		public void EnterReadLock()
		{
			_readerWriterLockSlim.EnterReadLock();
		}

		public void ExitReadLock()
		{
			_readerWriterLockSlim.ExitReadLock();
		}
	}

	public IReaderWriterLockSlim Create()
	{
		return new ReaderWriterLockSlimProxy(new ReaderWriterLockSlim());
	}
}
