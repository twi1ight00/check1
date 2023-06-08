using System;
using System.Configuration;

internal class FreConfig
{
	public static string GetDllFolder()
	{
		string abbyy_path = ConfigurationManager.AppSettings["ABBYY_Path"];
		if (is64BitConfiguration())
		{
			return abbyy_path + "Bin64";
		}
		return abbyy_path + "Bin";
	}

	public static string GetDeveloperSN()
	{
		string SN = ConfigurationManager.AppSettings["ABBYY_SN"];
		return SN.Replace("-", "");
	}

	private static bool is64BitConfiguration()
	{
		return IntPtr.Size == 8;
	}
}
