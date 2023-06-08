using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
[SuppressUnmanagedCodeSecurity]
internal class OpoErrCtx
{
	[MarshalAs(UnmanagedType.LPWStr)]
	public string m_message;

	public int m_errNumber;

	public int m_status;

	public int m_arrayBindIndex;

	internal OpoErrCtx()
	{
	}
}
