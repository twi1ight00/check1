using System;
using System.Threading;

namespace Oracle.DataAccess.Client;

internal class MiniDumpInfo
{
	internal int threadId;

	internal IntPtr pExPtrs;

	internal ManualResetEvent evt;

	internal MiniDumpInfo()
	{
		evt = new ManualResetEvent(initialState: false);
	}
}
