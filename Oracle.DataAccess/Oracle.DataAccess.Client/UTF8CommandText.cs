using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
[SuppressUnmanagedCodeSecurity]
internal class UTF8CommandText
{
	internal IntPtr m_utf8CmdText;

	internal bool m_parsed;

	internal bool m_addParam;

	internal static Pooler m_pooler = new Pooler(10, 200);

	public UTF8CommandText(IntPtr pUTF8CmdText)
	{
		m_utf8CmdText = pUTF8CmdText;
	}

	public UTF8CommandText()
	{
		m_addParam = true;
	}

	~UTF8CommandText()
	{
		if (!(m_utf8CmdText != IntPtr.Zero))
		{
			return;
		}
		try
		{
			Marshal.FreeCoTaskMem(m_utf8CmdText);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		m_utf8CmdText = IntPtr.Zero;
	}
}
