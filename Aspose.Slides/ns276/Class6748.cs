using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ns276;

internal class Class6748
{
	private static Encoding encoding_0 = Encoding.GetEncoding("IBM437");

	private static Encoding encoding_1 = Encoding.GetEncoding("UTF-8");

	private static Random random_0 = new Random();

	private Class6748()
	{
	}

	internal static string smethod_0(string path)
	{
		if (path.StartsWith(".\\"))
		{
			path = path.Substring(2);
		}
		path = path.Replace("\\.\\", "\\");
		Regex regex = new Regex("^(.*\\\\)?([^\\\\\\.]+\\\\\\.\\.\\\\)(.+)$");
		path = regex.Replace(path, "$1$3");
		return path;
	}

	internal static string smethod_1(string path)
	{
		if (path.StartsWith("./"))
		{
			path = path.Substring(2);
		}
		path = path.Replace("/./", "/");
		Regex regex = new Regex("^(.*/)b?([^/\\\\.]+/\\\\.\\\\./)(.+)$");
		path = regex.Replace(path, "$1$3");
		return path;
	}

	public static string smethod_2(string pathName)
	{
		if (pathName != null && pathName.Length != 0)
		{
			if (pathName.Length < 2)
			{
				return pathName.Replace('\\', '/');
			}
			return ((pathName[1] != ':' || pathName[2] != '\\') ? pathName : pathName.Substring(3)).Replace('\\', '/');
		}
		return pathName;
	}

	internal static byte[] smethod_3(string value, Encoding encoding)
	{
		return encoding.GetBytes(value);
	}

	internal static byte[] smethod_4(string value)
	{
		return smethod_3(value, encoding_0);
	}

	internal static string smethod_5(byte[] buf)
	{
		return smethod_6(buf, encoding_1);
	}

	internal static string smethod_6(byte[] buf, Encoding encoding)
	{
		return encoding.GetString(buf, 0, buf.Length);
	}

	internal static int smethod_7(Stream s)
	{
		int result = 0;
		try
		{
			result = smethod_9(s, "nul");
		}
		catch (Exception63)
		{
		}
		return result;
	}

	internal static int smethod_8(Stream s)
	{
		return smethod_9(s, "Could not read block - no data!  (position 0x{0:X8})");
	}

	private static int smethod_9(Stream s, string message)
	{
		byte[] array = new byte[4];
		int num = s.Read(array, 0, array.Length);
		if (num != array.Length)
		{
			throw new Exception63(string.Format(message, s.Position));
		}
		return ((array[3] * 256 + array[2]) * 256 + array[1]) * 256 + array[0];
	}

	protected internal static long smethod_10(Stream stream, int SignatureToFind)
	{
		long position = stream.Position;
		byte[] array = new byte[4]
		{
			(byte)(SignatureToFind >> 24),
			(byte)((SignatureToFind & 0xFF0000) >> 16),
			(byte)((SignatureToFind & 0xFF00) >> 8),
			(byte)((uint)SignatureToFind & 0xFFu)
		};
		byte[] array2 = new byte[65536];
		bool flag = false;
		do
		{
			int num = stream.Read(array2, 0, array2.Length);
			if (num == 0)
			{
				break;
			}
			for (int i = 0; i < num; i++)
			{
				if (array2[i] == array[3])
				{
					long position2 = stream.Position;
					stream.Seek(i - num, SeekOrigin.Current);
					int num2 = smethod_7(stream);
					if (flag = num2 == SignatureToFind)
					{
						break;
					}
					stream.Seek(position2, SeekOrigin.Begin);
				}
			}
		}
		while (!flag);
		if (!flag)
		{
			stream.Seek(position, SeekOrigin.Begin);
			return -1L;
		}
		return stream.Position - position - 4L;
	}

	internal static DateTime smethod_11(DateTime time)
	{
		return time;
	}

	internal static DateTime smethod_12(DateTime time)
	{
		return time;
	}

	internal static DateTime smethod_13(int packedDateTime)
	{
		if (packedDateTime != 65535 && packedDateTime != 0)
		{
			short num = (short)(packedDateTime & 0xFFFF);
			short num2 = (short)((packedDateTime & 0xFFFF0000L) >> 16);
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
							goto end_IL_00e9;
						}
						catch (ArgumentOutOfRangeException)
						{
							goto end_IL_00e9;
						}
						end_IL_00e9:;
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
				throw new Exception61($"Bad date/time format in the zip file. ({arg})");
			}
			return result;
		}
		return new DateTime(1995, 1, 1, 0, 0, 0, 0);
	}

	internal static int smethod_14(DateTime time)
	{
		time = time.ToLocalTime();
		time = smethod_12(time);
		ushort num = (ushort)(((uint)time.Day & 0x1Fu) | ((uint)(time.Month << 5) & 0x1E0u) | ((uint)(time.Year - 1980 << 9) & 0xFE00u));
		ushort num2 = (ushort)(((uint)(time.Second / 2) & 0x1Fu) | ((uint)(time.Minute << 5) & 0x7E0u) | ((uint)(time.Hour << 11) & 0xF800u));
		return (num << 16) | num2;
	}

	public static string smethod_15()
	{
		string text;
		do
		{
			text = "DotNetZip-" + smethod_16(8, 97) + ".tmp";
		}
		while (File.Exists(text));
		return text;
	}

	private static string smethod_16(int length, int delta)
	{
		bool flag = delta == 0;
		string empty = string.Empty;
		char[] array = new char[length];
		for (int i = 0; i < length; i++)
		{
			if (flag)
			{
				delta = ((random_0.Next(2) == 0) ? 65 : 97);
			}
			array[i] = smethod_17(delta);
		}
		return new string(array);
	}

	private static char smethod_17(int delta)
	{
		return (char)(random_0.Next(26) + delta);
	}

	internal static int smethod_18(Stream s, byte[] buffer, int offset, int count, string FileName)
	{
		int result = 0;
		bool flag = false;
		int num = 0;
		do
		{
			try
			{
				result = s.Read(buffer, offset, count);
				flag = true;
			}
			catch (IOException ex)
			{
				SecurityPermission securityPermission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
				if (securityPermission.IsUnrestricted())
				{
					uint num2 = smethod_19(ex);
					if (num2 != 2147942433u)
					{
						throw new IOException($"Cannot read file {FileName}", ex);
					}
					num++;
					if (num > 10)
					{
						throw new IOException($"Cannot read file {FileName}, at offset 0x{offset:X8} after 10 retries", ex);
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

	private static uint smethod_19(Exception ex1)
	{
		return (uint)Marshal.GetHRForException(ex1);
	}
}
