using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using System.Threading;
using Microsoft.Win32;
using ns218;
using ns221;

namespace ns234;

internal static class Class6166
{
	private static readonly CultureInfo cultureInfo_0 = Thread.CurrentThread.CurrentCulture;

	private static readonly CultureInfo cultureInfo_1 = new CultureInfo("en-nz");

	public static Stream smethod_0(string fullResourceName)
	{
		Assembly callingAssembly = Assembly.GetCallingAssembly();
		Stream manifestResourceStream = callingAssembly.GetManifestResourceStream(fullResourceName);
		if (manifestResourceStream == null)
		{
			throw new InvalidOperationException($"Cannot find resource '{fullResourceName}'.");
		}
		return manifestResourceStream;
	}

	public static Stream smethod_1(string href)
	{
		if (Class5973.smethod_6(href))
		{
			WebRequest webRequest = WebRequest.Create(href);
			WebResponse response = webRequest.GetResponse();
			MemoryStream memoryStream = new MemoryStream();
			using (Stream srcStream = response.GetResponseStream())
			{
				Class5964.smethod_9(srcStream, memoryStream);
			}
			memoryStream.Position = 0L;
			return memoryStream;
		}
		return File.OpenRead(href);
	}

	public static Enum742 smethod_2()
	{
		switch (Environment.OSVersion.Platform)
		{
		case PlatformID.Win32S:
		case PlatformID.Win32Windows:
		case PlatformID.Win32NT:
		case PlatformID.WinCE:
			return Enum742.const_0;
		default:
			return Enum742.const_1;
		case PlatformID.MacOSX:
			return Enum742.const_2;
		}
	}

	public static void smethod_3(IDictionary fileNames)
	{
		string text = smethod_4();
		if (!Class5964.smethod_20(text))
		{
			return;
		}
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts", writable: false);
			if (registryKey == null)
			{
				return;
			}
			string[] valueNames = registryKey.GetValueNames();
			string[] array = valueNames;
			foreach (string name in array)
			{
				string text2 = (string)registryKey.GetValue(name);
				if (!Path.IsPathRooted(text2))
				{
					text2 = Path.Combine(text, text2);
				}
				fileNames[text2] = text2;
			}
		}
		catch (SecurityException)
		{
		}
	}

	public static string smethod_4()
	{
		try
		{
			return Path.Combine(Environment.GetEnvironmentVariable("WINDIR"), "Fonts");
		}
		catch (SecurityException)
		{
			return string.Empty;
		}
	}

	public static int smethod_5()
	{
		return Environment.TickCount;
	}

	public static void smethod_6(string culture)
	{
		CultureInfo cultureInfo = new CultureInfo(culture);
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
	}

	public static string smethod_7()
	{
		return Thread.CurrentThread.CurrentCulture.Name;
	}

	public static void smethod_8()
	{
		Thread.CurrentThread.CurrentCulture = cultureInfo_1;
		Thread.CurrentThread.CurrentUICulture = cultureInfo_1;
	}

	public static void smethod_9()
	{
		Thread.CurrentThread.CurrentCulture = cultureInfo_0;
		Thread.CurrentThread.CurrentUICulture = cultureInfo_0;
	}

	public static string smethod_10(string path)
	{
		return File.ReadAllText(path);
	}
}
