using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential)]
internal class OpoSubscrCtx : IDisposable
{
	internal IntPtr opsSubscrCtx;

	internal IntPtr opsErrCtx;

	public OpoSubscrCtx()
	{
		opsSubscrCtx = IntPtr.Zero;
		opsErrCtx = IntPtr.Zero;
	}

	~OpoSubscrCtx()
	{
		Dispose(disposing: false);
	}

	protected virtual void Dispose(bool disposing)
	{
		try
		{
			OpsSubscr.FreeCtx(OracleDependency.s_opsEnvCtx, out opsErrCtx, out opsSubscrCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}
}
