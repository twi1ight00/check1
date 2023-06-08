using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

internal class CThreadPool
{
	[ComImport]
	[Guid("CB2F6723-AB3A-11D2-9C40-00C04FA30A3E")]
	internal class CorRuntimeHost
	{
	}

	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("84680D3A-B2C1-46e8-ACC2-DBC0A359159A")]
	internal interface IThreadPool
	{
		void RegisterWaitForSingleObject();

		void UnregisterWait();

		void QueueUserWorkItem();

		void CreateTimer();

		void ChangeTimer();

		void DeleteTimer();

		void BindIoCompletionCallback();

		void CallOrQueueUserWorkItem();

		void CorSetMaxThreads(uint MaxWorkerThreads, uint MaxIOCompletionThreads);

		void CorGetMaxThreads(out uint MaxWorkerThreads, out uint MaxIOCompletionThreads);

		void CorGetAvailableThreads(out uint AvailableWorkerThreads, out uint AvailableIOCompletionThreads);
	}

	private static IThreadPool threadPool = (IThreadPool)new CorRuntimeHost();

	internal static void SetMaxThreads(uint MaxWorkerThreads, uint MaxIOCompletionThreads)
	{
		threadPool.CorSetMaxThreads(MaxWorkerThreads, MaxIOCompletionThreads);
	}

	internal static void GetMaxThreads(out uint MaxWorkerThreads, out uint MaxIOCompletionThreads)
	{
		threadPool.CorGetMaxThreads(out MaxWorkerThreads, out MaxIOCompletionThreads);
	}
}
