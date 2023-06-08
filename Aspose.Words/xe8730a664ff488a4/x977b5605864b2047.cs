using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Aspose;
using x13f1efc79617a47b;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class x977b5605864b2047
{
	private static Encoding x34202fa0ef9be422 = Encoding.GetEncoding("IBM437");

	private static Encoding x480b3dd2898c4c19 = Encoding.GetEncoding("UTF-8");

	private static Random _x4b1d3bcdb370a2c3 = new Random();

	private x977b5605864b2047()
	{
	}

	internal static string xf9660872e16d9b18(string xe125219852864557)
	{
		if (xe125219852864557.StartsWith(".\\"))
		{
			xe125219852864557 = xe125219852864557.Substring(2);
		}
		xe125219852864557 = xe125219852864557.Replace("\\.\\", "\\");
		Regex regex = new Regex("^(.*\\\\)?([^\\\\\\.]+\\\\\\.\\.\\\\)(.+)$");
		xe125219852864557 = regex.Replace(xe125219852864557, "$1$3");
		return xe125219852864557;
	}

	internal static string xc820dec65d650cb5(string xe125219852864557)
	{
		if (xe125219852864557.StartsWith("./"))
		{
			xe125219852864557 = xe125219852864557.Substring(2);
		}
		xe125219852864557 = xe125219852864557.Replace("/./", "/");
		Regex regex = new Regex("^(.*/)b?([^/\\\\.]+/\\\\.\\\\./)(.+)$");
		xe125219852864557 = regex.Replace(xe125219852864557, "$1$3");
		return xe125219852864557;
	}

	public static string x849264acdd8a9902(string x803a44738fba695a)
	{
		if (x803a44738fba695a == null || x803a44738fba695a.Length == 0)
		{
			return x803a44738fba695a;
		}
		if (x803a44738fba695a.Length < 2)
		{
			return x803a44738fba695a.Replace('\\', '/');
		}
		return ((x803a44738fba695a[1] == ':' && x803a44738fba695a[2] == '\\') ? x803a44738fba695a.Substring(3) : x803a44738fba695a).Replace('\\', '/');
	}

	internal static byte[] xfa83398499680a50(string xbcea506a33cf9111, Encoding xff3edc9aa5f0523b)
	{
		return xff3edc9aa5f0523b.GetBytes(xbcea506a33cf9111);
	}

	internal static byte[] xfa83398499680a50(string xbcea506a33cf9111)
	{
		return xfa83398499680a50(xbcea506a33cf9111, x34202fa0ef9be422);
	}

	internal static string x6a3fd4d8bc04438e(byte[] x1ef26dbdd5d13d24)
	{
		return x0f110a4d541356e9(x1ef26dbdd5d13d24, x480b3dd2898c4c19);
	}

	internal static string x0f110a4d541356e9(byte[] x1ef26dbdd5d13d24, Encoding xff3edc9aa5f0523b)
	{
		return xff3edc9aa5f0523b.GetString(x1ef26dbdd5d13d24, 0, x1ef26dbdd5d13d24.Length);
	}

	internal static int x4e38ee4c0a37efb1(Stream xe4115acdf4fbfccc)
	{
		int result = 0;
		try
		{
			result = _xb10147ab100900f5(xe4115acdf4fbfccc, "nul");
		}
		catch (x369b23f4e2c41640)
		{
		}
		return result;
	}

	internal static int xe5d393f0d1706f47(Stream xe4115acdf4fbfccc)
	{
		return _xb10147ab100900f5(xe4115acdf4fbfccc, "Could not read block - no data!  (position 0x{0:X8})");
	}

	private static int _xb10147ab100900f5(Stream xe4115acdf4fbfccc, string x1f25abf5fb75e795)
	{
		byte[] array = new byte[4];
		int num = xe4115acdf4fbfccc.Read(array, 0, array.Length);
		if (num != array.Length)
		{
			throw new x369b23f4e2c41640(string.Format(x1f25abf5fb75e795, xe4115acdf4fbfccc.Position));
		}
		return ((array[3] * 256 + array[2]) * 256 + array[1]) * 256 + array[0];
	}

	protected internal static long xdf477cba9c46e9dc(Stream xcf18e5243f8d5fd3, int x1d111594f9519727)
	{
		long position = xcf18e5243f8d5fd3.Position;
		int num = 65536;
		byte[] array = new byte[4]
		{
			(byte)(x1d111594f9519727 >> 24),
			(byte)((x1d111594f9519727 & 0xFF0000) >> 16),
			(byte)((x1d111594f9519727 & 0xFF00) >> 8),
			(byte)((uint)x1d111594f9519727 & 0xFFu)
		};
		byte[] array2 = new byte[num];
		bool flag = false;
		do
		{
			int num2 = xcf18e5243f8d5fd3.Read(array2, 0, array2.Length);
			if (num2 == 0)
			{
				break;
			}
			for (int i = 0; i < num2; i++)
			{
				if (array2[i] == array[3])
				{
					long position2 = xcf18e5243f8d5fd3.Position;
					xcf18e5243f8d5fd3.Seek(i - num2, SeekOrigin.Current);
					int num3 = x4e38ee4c0a37efb1(xcf18e5243f8d5fd3);
					flag = num3 == x1d111594f9519727;
					if (flag)
					{
						break;
					}
					xcf18e5243f8d5fd3.Seek(position2, SeekOrigin.Begin);
				}
			}
		}
		while (!flag);
		if (!flag)
		{
			xcf18e5243f8d5fd3.Seek(position, SeekOrigin.Begin);
			return -1L;
		}
		return xcf18e5243f8d5fd3.Position - position - 4;
	}

	internal static DateTime x13fcad26fd69d759(DateTime x0ebe150470f7718d)
	{
		return x0ebe150470f7718d;
	}

	internal static DateTime xc47206052e8bcd79(DateTime x0ebe150470f7718d)
	{
		return x0ebe150470f7718d;
	}

	internal static DateTime x5def2075df47607e(int x6b1b2dd4ad38e1f5)
	{
		if (x6b1b2dd4ad38e1f5 == 65535 || x6b1b2dd4ad38e1f5 == 0)
		{
			return new DateTime(1995, 1, 1, 0, 0, 0, 0);
		}
		short num = (short)(x6b1b2dd4ad38e1f5 & 0xFFFF);
		short num2 = (short)((x6b1b2dd4ad38e1f5 & 0xFFFF0000u) >> 16);
		int i = 1980 + ((num2 & 0xFE00) >> 9);
		int j = (num2 & 0x1E0) >> 5;
		int k = num2 & 0x1F;
		int num3 = (num & 0xF800) >> 11;
		int l = (num & 0x7E0) >> 5;
		int m = (num & 0x1F) * 2;
		if (m >= 60)
		{
			l++;
			m = 0;
		}
		if (l >= 60)
		{
			num3++;
			l = 0;
		}
		if (num3 >= 24)
		{
			k++;
			num3 = 0;
		}
		DateTime result = DateTime.Now;
		bool flag = false;
		try
		{
			result = new DateTime(i, j, k, num3, l, m, 0);
			flag = true;
		}
		catch (ArgumentOutOfRangeException)
		{
			if (i == 1980 && j == 0 && k == 0)
			{
				try
				{
					result = new DateTime(1980, 1, 1, num3, l, m, 0);
					flag = true;
				}
				catch (ArgumentOutOfRangeException)
				{
					try
					{
						result = new DateTime(1980, 1, 1, 0, 0, 0, 0);
						flag = true;
						goto end_IL_00f1;
					}
					catch (ArgumentOutOfRangeException)
					{
						goto end_IL_00f1;
					}
					end_IL_00f1:;
				}
			}
			else
			{
				try
				{
					for (; i < 1980; i++)
					{
					}
					while (i > 2030)
					{
						i--;
					}
					for (; j < 1; j++)
					{
					}
					while (j > 12)
					{
						j--;
					}
					for (; k < 1; k++)
					{
					}
					while (k > 28)
					{
						k--;
					}
					for (; l < 0; l++)
					{
					}
					while (l > 59)
					{
						l--;
					}
					for (; m < 0; m++)
					{
					}
					while (m > 59)
					{
						m--;
					}
					result = new DateTime(i, j, k, num3, l, m, 0);
					flag = true;
				}
				catch (ArgumentOutOfRangeException)
				{
				}
			}
		}
		if (!flag)
		{
			string arg = $"y({i}) m({j}) d({k}) h({num3}) m({l}) s({m})";
			throw new xc5e345d2a919c94b(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("anmcmoddmokdfkbegoieaopeapgfonnffkegholgjnchknjhpmaihihikmoianfjanmjimdkjlkkjmblchililplklgmjgnmklenlklnfkconfjoelapakhpekopbffaejmaejdbejkbkibcaficpdpceegdejndgeeeajlejdcf", 52571278)), arg));
		}
		return result;
	}

	internal static int x35cf72c0c42c20e8(DateTime x0ebe150470f7718d)
	{
		x0ebe150470f7718d = x0ebe150470f7718d.ToLocalTime();
		x0ebe150470f7718d = xc47206052e8bcd79(x0ebe150470f7718d);
		ushort num = (ushort)(((uint)x0ebe150470f7718d.Day & 0x1Fu) | ((uint)(x0ebe150470f7718d.Month << 5) & 0x1E0u) | ((uint)(x0ebe150470f7718d.Year - 1980 << 9) & 0xFE00u));
		ushort num2 = (ushort)(((uint)(x0ebe150470f7718d.Second / 2) & 0x1Fu) | ((uint)(x0ebe150470f7718d.Minute << 5) & 0x7E0u) | ((uint)(x0ebe150470f7718d.Hour << 11) & 0xF800u));
		return (num << 16) | num2;
	}

	public static string x216f7e66fa44cf71()
	{
		string text;
		do
		{
			text = "DotNetZip-" + x48638be161a3ceab(8, 97) + ".tmp";
		}
		while (File.Exists(text));
		return text;
	}

	private static string x48638be161a3ceab(int x961016a387451f05, int xf7845a6fecd5afc3)
	{
		bool flag = xf7845a6fecd5afc3 == 0;
		string text = "";
		char[] array = new char[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			if (flag)
			{
				xf7845a6fecd5afc3 = ((_x4b1d3bcdb370a2c3.Next(2) == 0) ? 65 : 97);
			}
			array[i] = x50a3cf615505d248(xf7845a6fecd5afc3);
		}
		return new string(array);
	}

	private static char x50a3cf615505d248(int xf7845a6fecd5afc3)
	{
		return (char)(_x4b1d3bcdb370a2c3.Next(26) + xf7845a6fecd5afc3);
	}

	internal static int x5791cfd88e60d337(Stream xe4115acdf4fbfccc, byte[] x5cafa8d49ea71ea1, int x374ea4fe62468d0f, int x10f4d88af727adbc, string xa39af5a82860a9a3)
	{
		int result = 0;
		bool flag = false;
		int num = 0;
		do
		{
			try
			{
				result = xe4115acdf4fbfccc.Read(x5cafa8d49ea71ea1, x374ea4fe62468d0f, x10f4d88af727adbc);
				flag = true;
			}
			catch (IOException ex)
			{
				SecurityPermission securityPermission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
				if (securityPermission.IsUnrestricted())
				{
					uint num2 = _x43cccc3611f00c2c(ex);
					if (num2 != 2147942433u)
					{
						throw new IOException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gihobkoolkfpikmpgkdaikkabfbbakibajpbjigcjincceedfildficefijelhafddhfliofndfghimg", 1854924611)), xa39af5a82860a9a3), ex);
					}
					num++;
					if (num > 10)
					{
						throw new IOException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("emohpnfijomigodjeokjgobkpiikonpkomglhmnlhmemailmdmcndmjndmaojlhobhoojmfplhmpfmdabhkacgbbakibalpbjfgcfkncjjedgjldakcepijeljafeehfbfofgjfggjmgjedhpekhkgbiheiijipijcgjhgnjjgekehlkcgclmgjlhbamfchmbcomoafnnfmnnedojfkoefbpieipbeppmega", 1357676161)), xa39af5a82860a9a3, x374ea4fe62468d0f), ex);
					}
					Thread.Sleep(250 + num * 550);
					continue;
				}
				throw;
			}
		}
		while (!flag);
		return result;
	}

	private static uint _x43cccc3611f00c2c(Exception x385baec29b54d56d)
	{
		return (uint)Marshal.GetHRForException(x385baec29b54d56d);
	}
}
