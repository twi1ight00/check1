using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace Oracle.DataAccess.Client;

internal class OpoErrResManager
{
	private static ResourceManager s_rm = new ResourceManager("Oracle.DataAccess.src.Client.Resources.Exception", Assembly.GetExecutingAssembly());

	private OpoErrResManager()
	{
	}

	internal static ResourceManager Instance()
	{
		return s_rm;
	}

	internal static string GetErrorMesg(int errorcode, params string[] args)
	{
		string text = null;
		CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
		string @string = Instance().GetString(Convert.ToString(errorcode), currentCulture);
		text = ((@string == null) ? string.Empty : string.Format(@string, args));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ERROR) ODP error code=" + errorcode + "; ODP message=" + text + "\n");
		}
		return text;
	}
}
