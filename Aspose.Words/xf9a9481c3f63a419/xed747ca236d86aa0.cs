using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using System.Threading;
using Aspose;
using Microsoft.Win32;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xed747ca236d86aa0
{
	private static readonly CultureInfo x09289c3c6fe3567f = Thread.CurrentThread.CurrentCulture;

	private static readonly CultureInfo xa8d8dcd59d16d0a9 = new CultureInfo("en-nz");

	private xed747ca236d86aa0()
	{
	}

	public static Stream xe1cd764b6fb0d6f6(string xec527ffb2b43765c)
	{
		Assembly callingAssembly = Assembly.GetCallingAssembly();
		Stream manifestResourceStream = callingAssembly.GetManifestResourceStream(xec527ffb2b43765c);
		if (manifestResourceStream == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dbecoclcidcdfdjdddaefdheonnebcffbcmfdcdggbkgpmahobihoaphjbgicbnifbejpaljnpbkmpikelpkilgljaolllemfammmkcnaljn", 1879712720)), xec527ffb2b43765c));
		}
		return manifestResourceStream;
	}

	public static Stream xb93ba02d7ec640e0(string x585da4d9795fa783)
	{
		if (x0d4d45882065c63e.xe06270bc72b12369(x585da4d9795fa783))
		{
			WebRequest webRequest = WebRequest.Create(x585da4d9795fa783);
			WebResponse response = webRequest.GetResponse();
			MemoryStream memoryStream = new MemoryStream();
			using (Stream x23cda4cfdf81f2cf = response.GetResponseStream())
			{
				x0d299f323d241756.x3ad8e53785c39acd(x23cda4cfdf81f2cf, memoryStream);
			}
			memoryStream.Position = 0L;
			return memoryStream;
		}
		return File.OpenRead(x585da4d9795fa783);
	}

	public static x3bb20242a64c30a9 xf40b599afa14f524()
	{
		PlatformID platform = Environment.OSVersion.Platform;
		if (platform == PlatformID.Win32NT || platform == PlatformID.Win32S || platform == PlatformID.Win32Windows || platform == PlatformID.WinCE)
		{
			return x3bb20242a64c30a9.x8a2adacc78a4bcc9;
		}
		int platform2 = (int)Environment.OSVersion.Platform;
		if (platform2 != 4 && platform2 != 6 && platform2 != 128)
		{
			return x3bb20242a64c30a9.x720fa05edddb7fd4;
		}
		return x3bb20242a64c30a9.x40a5752567c3c6a6;
	}

	public static bool xdf550180001d5cd4()
	{
		OperatingSystem oSVersion = Environment.OSVersion;
		Version version = oSVersion.Version;
		if (oSVersion.Platform == PlatformID.Win32NT)
		{
			if (version.Major == 6)
			{
				return version.Minor > 0;
			}
			if (version.Major > 6)
			{
				return true;
			}
		}
		return false;
	}

	public static void x82611b255d9983ac(IDictionary xec232eb93dd022a7)
	{
		try
		{
			string text = x0f5d18019ab06bc5();
			if (!x0d299f323d241756.x5959bccb67bbf051(text))
			{
				return;
			}
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts", writable: false);
			if (registryKey == null)
			{
				return;
			}
			string[] valueNames = registryKey.GetValueNames();
			string[] array = valueNames;
			foreach (string name in array)
			{
				try
				{
					string text2 = (string)registryKey.GetValue(name);
					if (!Path.IsPathRooted(text2))
					{
						text2 = Path.Combine(text, text2);
					}
					xec232eb93dd022a7[text2] = text2;
				}
				catch (ArgumentException)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static string x0f5d18019ab06bc5()
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

	public static int x3185864e257a5f60()
	{
		return Environment.TickCount;
	}

	public static void xcb651329dbd67ff0(string xb37daae42e1995c9)
	{
		CultureInfo cultureInfo = new CultureInfo(xb37daae42e1995c9);
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
	}

	public static string xe8201cb97474aaaf()
	{
		return Thread.CurrentThread.CurrentCulture.Name;
	}

	public static void xf4dc0c63b869aa1f()
	{
		Thread.CurrentThread.CurrentCulture = xa8d8dcd59d16d0a9;
		Thread.CurrentThread.CurrentUICulture = xa8d8dcd59d16d0a9;
	}

	public static void x8605e9eabe2cc62e()
	{
		Thread.CurrentThread.CurrentCulture = x09289c3c6fe3567f;
		Thread.CurrentThread.CurrentUICulture = x09289c3c6fe3567f;
	}
}
