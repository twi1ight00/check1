using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
[DebuggerNonUserCode]
internal sealed class _0002_2000
{
	private static ResourceManager m__0002;

	private static CultureInfo m__0003;

	internal _0002_2000()
	{
	}

	internal static ResourceManager _0002()
	{
		if (object.ReferenceEquals(_0002_2000.m__0002, null))
		{
			ResourceManager resourceManager = new ResourceManager(_0005_2000._0002(1402786067), typeof(_0002_2000).Assembly);
			_0002_2000.m__0002 = resourceManager;
		}
		return _0002_2000.m__0002;
	}

	internal static CultureInfo _0002()
	{
		return _0002_2000.m__0003;
	}

	internal static void _0002(CultureInfo _0002)
	{
		_0002_2000.m__0003 = _0002;
	}

	internal static Bitmap _0002()
	{
		object @object = _0002_2000._0002().GetObject(_0005_2000._0002(1402786060), _0002_2000.m__0003);
		return (Bitmap)@object;
	}

	internal static Bitmap _0003()
	{
		object @object = _0002_2000._0002().GetObject(_0005_2000._0002(1402786175), _0002_2000.m__0003);
		return (Bitmap)@object;
	}

	internal static Bitmap _0005()
	{
		object @object = _0002_2000._0002().GetObject(_0005_2000._0002(1402786158), _0002_2000.m__0003);
		return (Bitmap)@object;
	}

	internal static Bitmap _0008()
	{
		object @object = _0002_2000._0002().GetObject(_0005_2000._0002(1402786141), _0002_2000.m__0003);
		return (Bitmap)@object;
	}

	internal static Bitmap _0006()
	{
		object @object = _0002_2000._0002().GetObject(_0005_2000._0002(1402786123), _0002_2000.m__0003);
		return (Bitmap)@object;
	}

	internal static Bitmap _000E()
	{
		object @object = _0002_2000._0002().GetObject(_0005_2000._0002(1402785977), _0002_2000.m__0003);
		return (Bitmap)@object;
	}
}
internal sealed class _0003_2000
{
	public static string _0002 = global::_0005_2000._0002(1402786554);

	public static string _0002(string _0002)
	{
		string empty = string.Empty;
		try
		{
			byte[] bytes = Encoding.Default.GetBytes(_0002);
			for (int i = 0; i < bytes.Length; i++)
			{
				if (i % 2 == 1)
				{
					bytes[i] = (byte)(bytes[i] - 2);
				}
				else
				{
					bytes[i] = (byte)((uint)(bytes[i] - 3) ^ 0x49u);
				}
			}
			return Convert.ToBase64String(bytes);
		}
		catch
		{
			return _0002;
		}
	}

	public static string _0003(string _0002)
	{
		string empty = string.Empty;
		try
		{
			byte[] array = Convert.FromBase64String(_0002);
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 1)
				{
					array[i] = (byte)(array[i] + 2);
				}
				else
				{
					array[i] = (byte)((array[i] ^ 0x49) + 3);
				}
			}
			return Encoding.Default.GetString(array);
		}
		catch
		{
			return _0002;
		}
	}

	public static string _0005(string _0002)
	{
		string empty = string.Empty;
		try
		{
			byte[] bytes = Encoding.Default.GetBytes(_0002);
			return Convert.ToBase64String(bytes);
		}
		catch
		{
			return _0002;
		}
	}

	public static string _0008(string _0002)
	{
		string empty = string.Empty;
		try
		{
			byte[] bytes = Convert.FromBase64String(_0002);
			return Encoding.Default.GetString(bytes);
		}
		catch
		{
			return _0002;
		}
	}

	public static string _0006(string _0002)
	{
		string empty = string.Empty;
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(_0002);
			return Convert.ToBase64String(bytes);
		}
		catch
		{
			return _0002;
		}
	}

	public static string _000E(string _0002)
	{
		string empty = string.Empty;
		try
		{
			byte[] bytes = Convert.FromBase64String(_0002);
			return Encoding.UTF8.GetString(bytes);
		}
		catch
		{
			return _0002;
		}
	}

	public static string _000F(string _0002)
	{
		try
		{
			int num = _0002.LastIndexOf(global::_0005_2000._0002(1402782116));
			return _0002.Substring(num, _0002.Length - num);
		}
		catch
		{
			return string.Empty;
		}
	}

	public static string _0002(string _0002, string _0003, string _0005)
	{
		int num = 0;
		string result = string.Empty;
		string text = _0005 + _0002 + _0005;
		string text2 = _0005 + _0003 + global::_0005_2000._0002(1402769483);
		num = text.IndexOf(text2);
		if (num > -1)
		{
			string text3 = text.Substring(num + text2.Length, text.Length - num - text2.Length);
			num = text3.IndexOf(_0005);
			if (num > -1)
			{
				result = text3.Substring(0, num);
			}
		}
		return result;
	}

	public static string _0002_2000(string _0002)
	{
		string text = _0002.ToLower();
		string text2 = global::_0005_2000._0002(1402786536);
		string text3 = global::_0005_2000._0002(1402786373);
		string[] array = text2.Split('|');
		string[] array2 = text3.Split('|');
		string[] array3 = array;
		foreach (string text4 in array3)
		{
			if (_0002.Contains(global::_0005_2000._0002(1402765371) + text4) || _0002.Contains(text4 + global::_0005_2000._0002(1402765371)))
			{
				text = text.Replace(text4, global::_0005_2000._0002(1402765371));
			}
		}
		string[] array4 = array2;
		foreach (string text5 in array4)
		{
			if (_0002.Contains(text5))
			{
				text = text.Replace(text5, string.Empty);
			}
		}
		return text;
	}

	public static string _0003_2000(string _0002)
	{
		MD5 mD = new MD5CryptoServiceProvider();
		byte[] bytes = Encoding.Default.GetBytes(_0002);
		byte[] array = mD.ComputeHash(bytes);
		mD.Clear();
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			text += array[i].ToString(global::_0005_2000._0002(1402789289)).PadLeft(2, '0');
		}
		return text;
	}

	private static byte[] _0002(string _0002)
	{
		byte[] array = new byte[_0002.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Convert.ToByte(_0002.Substring(i * 2, 2), 16);
		}
		return array;
	}

	private static string _0002(byte[] _0002)
	{
		string text = string.Empty;
		if (_0002 != null)
		{
			for (int i = 0; i < _0002.Length; i++)
			{
				text += _0002[i].ToString(global::_0005_2000._0002(1402789265));
			}
		}
		return text;
	}

	internal static string _0005_2000(string _0002)
	{
		string text = string.Empty;
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(_0002);
			text = Convert.ToBase64String(bytes);
			text = global::_0003_2000._0002(Encoding.UTF8.GetBytes(text));
		}
		catch
		{
		}
		return text;
	}

	internal static string _0008_2000(string _0002)
	{
		string result = string.Empty;
		try
		{
			byte[] bytes = global::_0003_2000._0002(_0002);
			byte[] bytes2 = Convert.FromBase64String(Encoding.UTF8.GetString(bytes));
			result = Encoding.UTF8.GetString(bytes2);
		}
		catch
		{
		}
		return result;
	}

	internal static string _0006_2000(string _0002)
	{
		string empty = string.Empty;
		try
		{
			byte[] bytes = Encoding.Default.GetBytes(_0002);
			empty = Convert.ToBase64String(bytes);
			empty = empty.Replace('+', '_');
			empty = empty.Replace('/', '-');
			return empty.Replace('=', '.');
		}
		catch
		{
			return _0002;
		}
	}

	internal static string _000E_2000(string _0002)
	{
		string result = string.Empty;
		string text = _0002.ToLower();
		if (text.IndexOf(global::_0005_2000._0002(1402789272)) == 0 && text.IndexOf(global::_0005_2000._0002(1402789254)) > 7)
		{
			result = _0002.Substring(7, text.IndexOf(global::_0005_2000._0002(1402789254)) - 7);
		}
		else if (text.IndexOf(global::_0005_2000._0002(1402789367)) == 0 && text.IndexOf(global::_0005_2000._0002(1402789346)) > 6)
		{
			result = _0002.Substring(6, text.IndexOf(global::_0005_2000._0002(1402789346)) - 6);
		}
		else if (text.IndexOf(global::_0005_2000._0002(1402789328)) == 0 && text.IndexOf(global::_0005_2000._0002(1402789342)) > 7)
		{
			result = _0002.Substring(7, text.IndexOf(global::_0005_2000._0002(1402789342)) - 7);
		}
		return result;
	}
}
internal static class _0005_2000
{
	private sealed class _000F_2002_2001_2005_2004_2006_2000_200A_2005_2005_2008_2003_2007_200B_2001
	{
		private Stream m__0002;

		private byte[] m__0003;

		public _000F_2002_2001_2005_2004_2006_2000_200A_2005_2005_2008_2003_2007_200B_2001(Stream _0002)
		{
			this.m__0002 = _0002;
			this.m__0003 = new byte[4];
		}

		public Stream _0002()
		{
			return this.m__0002;
		}

		public short _0002()
		{
			_0002(2);
			return (short)(this.m__0003[0] | (this.m__0003[1] << 8));
		}

		public int _0002()
		{
			_0002(4);
			return this.m__0003[0] | (this.m__0003[1] << 8) | (this.m__0003[2] << 16) | (this.m__0003[3] << 24);
		}

		private void _0002()
		{
			throw new EndOfStreamException();
		}

		private void _0002(int _0002)
		{
			int num = 0;
			int num2 = 0;
			if (_0002 == 1)
			{
				num2 = this.m__0002.ReadByte();
				if (num2 == -1)
				{
					this._0002();
				}
				this.m__0003[0] = (byte)num2;
				return;
			}
			do
			{
				num2 = this.m__0002.Read(this.m__0003, num, _0002 - num);
				if (num2 == 0)
				{
					this._0002();
				}
				num += num2;
			}
			while (num < _0002);
		}

		public void _0003()
		{
			Stream stream = this.m__0002;
			this.m__0002 = null;
			stream?.Close();
			this.m__0003 = null;
		}

		public byte[] _0002(int _0002)
		{
			if (_0002 < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			byte[] array = new byte[_0002];
			int num = 0;
			do
			{
				int num2 = this.m__0002.Read(array, num, _0002);
				if (num2 == 0)
				{
					break;
				}
				num += num2;
				_0002 -= num2;
			}
			while (_0002 > 0);
			if (num != array.Length)
			{
				byte[] array2 = new byte[num];
				Buffer.BlockCopy(array, 0, array2, 0, num);
				array = array2;
			}
			return array;
		}
	}

	[DefaultMember("Item")]
	internal sealed class _000E_2004_2003_2000_2007_2003_2007_2007_200A_200B_2005_2006_2008_200A_200B_2003_2009_200A_200A_2007_2002_2005
	{
		private struct _0002
		{
			public int _0002;

			public string _0003;
		}

		private _0002[] m__0002;

		private int _0003;

		public _000E_2004_2003_2000_2007_2003_2007_2007_200A_200B_2005_2006_2008_200A_200B_2003_2009_200A_200A_2007_2002_2005()
		{
			this.m__0002 = new _0002[16];
		}

		public _000E_2004_2003_2000_2007_2003_2007_2007_200A_200B_2005_2006_2008_200A_200B_2003_2009_200A_200A_2007_2002_2005(int _0002)
		{
			int num = 16;
			_0002 <<= 1;
			while (num < _0002 && num > 0)
			{
				num <<= 1;
			}
			if (num < 0)
			{
				num = 16;
			}
			this.m__0002 = new _0002[num];
		}

		public int _0002()
		{
			return _0003;
		}

		private void _0002()
		{
			_0002[] array = this.m__0002;
			int num = array.Length;
			int num2 = num * 2;
			if (num2 <= 0)
			{
				return;
			}
			_0002[] array2 = new _0002[num2];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				string text = array[i]._0003;
				if (text == null)
				{
					continue;
				}
				int num4 = array[i]._0002;
				int num5 = num4 & (num2 - 1);
				while (array2[num5]._0003 != null)
				{
					num5++;
					if (num5 >= num2)
					{
						num5 = 0;
					}
				}
				array2[num5]._0003 = text;
				array2[num5]._0002 = num4;
				num3++;
			}
			this.m__0002 = array2;
			_0003 = num3;
		}

		public string _0002(int _0002)
		{
			_0002[] array = this.m__0002;
			int num = array.Length;
			int num2 = _0002 & (num - 1);
			string result = null;
			while (true)
			{
				if (array[num2]._0002 == _0002)
				{
					result = array[num2]._0003;
					break;
				}
				if (array[num2]._0003 == null)
				{
					break;
				}
				num2++;
				if (num2 >= num)
				{
					num2 = 0;
				}
			}
			return result;
		}

		public void _0002(int _0002, string _0003)
		{
			_0002[] array = this.m__0002;
			int num = array.Length;
			int num2 = num >> 1;
			int num3 = _0002 & (num - 1);
			bool flag;
			while (true)
			{
				int num4 = array[num3]._0002;
				flag = array[num3]._0003 == null;
				if (num4 == _0002 || flag)
				{
					break;
				}
				num3++;
				if (num3 >= num)
				{
					num3 = 0;
				}
			}
			array[num3]._0003 = _0003;
			if (flag)
			{
				array[num3]._0002 = _0002;
				this._0003++;
				if (this._0003 > num2)
				{
					this._0002();
				}
			}
		}
	}

	private enum _0006_2006_2006_2008_2005_2005_2004_2006_200A_2008_200A_2006_2009_200A_2001_2007_200A_2006_2004_2002_2000_2002_2005_2007_2005_2008_2002_2005_2007
	{

	}

	private static _0006_2006_2006_2008_2005_2005_2004_2006_200A_2008_200A_2006_2009_200A_2001_2007_200A_2006_2004_2002_2000_2002_2005_2007_2005_2008_2002_2005_2007 _0003_2000;

	private static byte[] _000E;

	private static short _0008;

	private static int _0002_2000;

	private static int _000F;

	private static _000E_2004_2003_2000_2007_2003_2007_2007_200A_200B_2005_2006_2008_200A_200B_2003_2009_200A_200A_2007_2002_2005 m__0002;

	private static int _0006;

	private static byte[] _0005;

	private static _000F_2002_2001_2005_2004_2006_2000_200A_2005_2005_2008_2003_2007_200B_2001 _0003;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static _0005_2000()
	{
		int num = -1398918204;
		int num2 = -937621068 + num;
		_0005_2000.m__0002 = new _000E_2004_2003_2000_2007_2003_2007_2007_200A_200B_2005_2006_2008_200A_200B_2003_2009_200A_200A_2007_2002_2005((559509992 - num) ^ num2);
		int num3 = 1;
		StackTrace stackTrace = new StackTrace(num3, fNeedFileInfo: false);
		num3--;
		StackFrame frame = stackTrace.GetFrame(num3);
		int num4 = ~(-(~(-(-(~(~(-(~(num + 1449554680 - num2))))))))) ^ ~(-(~(-(-(~(-(~(~(-(~((1184682790 - num) ^ num2)))))))))));
		MethodBase methodBase = frame?.GetMethod();
		if (frame != null)
		{
			num4 ^= ~(-(-(~(-(~(-(~(~(-(~(num + -873689404 + num2)))))))))));
		}
		Type type = methodBase?.DeclaringType;
		if (type == typeof(RuntimeMethodHandle))
		{
			num4 ^= (-668660325 ^ num ^ num2) + num3;
			_0003_2000 |= (_0006_2006_2006_2008_2005_2005_2004_2006_200A_2008_200A_2006_2009_200A_2001_2007_200A_2006_2004_2002_2000_2002_2005_2007_2005_2008_2002_2005_2007)4;
		}
		else if (type == null)
		{
			num4 ^= ~(-(-(~(-(~(~(-(-(~(~(559472774 - num - num2)))))))))));
			_0003_2000 |= (_0006_2006_2006_2008_2005_2005_2004_2006_200A_2008_200A_2006_2009_200A_2001_2007_200A_2006_2004_2002_2000_2002_2005_2007_2005_2008_2002_2005_2007)1;
		}
		else if (type.Assembly != typeof(_0005_2000).Assembly)
		{
			num4 ^= (-1292690483 + num) ^ num2;
			_0003_2000 = (_0006_2006_2006_2008_2005_2005_2004_2006_200A_2008_200A_2006_2009_200A_2001_2007_200A_2006_2004_2002_2000_2002_2005_2007_2005_2008_2002_2005_2007)2 | _0003_2000;
		}
		else
		{
			num4 ^= ~(-(-(~(~(-(~(-(~((-668668843 ^ num) - num2))))))))) - num3;
			_0003_2000 = (_0006_2006_2006_2008_2005_2005_2004_2006_200A_2008_200A_2006_2009_200A_2001_2007_200A_2006_2004_2002_2000_2002_2005_2007_2005_2008_2002_2005_2007)16 | _0003_2000;
		}
		_0002_2000 = num4 + _0002_2000;
	}

	private static void _0002(byte[] _0002, int _0003, byte[] _0005)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 128;
		int num4 = _0005.Length;
		while (num < num4)
		{
			if ((num3 <<= 1) == 256)
			{
				num3 = 1;
				num2 = _0002[_0003++];
			}
			if ((num2 & num3) != 0)
			{
				int num5 = (_0002[_0003] >> 2) + 3;
				int num6 = ((_0002[_0003] << 8) | _0002[_0003 + 1]) & 0x3FF;
				_0003 += 2;
				int num7 = num - num6;
				if (num7 < 0)
				{
					break;
				}
				while (--num5 >= 0 && num < num4)
				{
					_0005[num++] = _0005[num7++];
				}
			}
			else
			{
				_0005[num++] = _0002[_0003++];
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string _0002(int _0002)
	{
		int num = 2085194210;
		int num2 = 396745491 - num;
		lock (_0005_2000.m__0002)
		{
			byte[] array;
			int num10;
			string text;
			while (true)
			{
				text = _0005_2000.m__0002._0002(_0002);
				if (text != null)
				{
					return text;
				}
				int num6;
				if (_0003 == null)
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					Assembly callingAssembly = Assembly.GetCallingAssembly();
					_0006 |= (num + 519780817) ^ num2;
					StringBuilder stringBuilder = new StringBuilder();
					int num3 = (-118864070 ^ num) + num2;
					stringBuilder.Append((char)num3).Append((char)(num3 >> 16));
					num3 = (933690139 - num) ^ num2;
					stringBuilder.Append((char)num3).Append((char)(num3 >> 16));
					num3 = 140526833 + num + num2;
					stringBuilder.Append((char)(num3 >> 16)).Append((char)num3);
					num3 = -955189037 ^ num ^ num2;
					stringBuilder.Append((char)num3).Append((char)(num3 >> 16));
					num3 = 933952276 - num - num2;
					stringBuilder.Append((char)num3).Append((char)(num3 >> 16));
					Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(stringBuilder.ToString());
					int num4 = 1;
					StackTrace stackTrace = new StackTrace(num4, fNeedFileInfo: false);
					_0006 ^= (-418004587 ^ num ^ num2) | num4;
					num4--;
					StackFrame frame = stackTrace.GetFrame(num4);
					MethodBase methodBase = frame?.GetMethod();
					_0006 ^= num4 + (num + 521324495 - num2);
					Type type = methodBase?.DeclaringType;
					if (frame == null)
					{
						_0006 ^= (396923748 - num) ^ num2;
					}
					bool flag = type == typeof(RuntimeMethodHandle);
					_0006 ^= num + 521324527 - num2;
					if (!flag)
					{
						flag = type == null;
						if (flag)
						{
							_0006 ^= -521105084 - num + num2;
						}
					}
					if (flag == (stackTrace != null))
					{
						_0006 ^= 32;
					}
					_0006 ^= ((-417995915 ^ num) - num2) | (num4 + 1);
					_0003 = new _000F_2002_2001_2005_2004_2006_2000_200A_2005_2005_2008_2003_2007_200B_2001(manifestResourceStream);
					short num5 = (short)(_0003._0002() ^ (short)(~(-(-(~(~(-(~(-(~((396754354 - num) ^ num2)))))))))));
					if (num5 == 0)
					{
						_0008 = (short)(_0003._0002() ^ (short)(~(-(-(~(~(-(~(-(-(~(~((0x18ED9ADA ^ num) + num2)))))))))))));
					}
					else
					{
						_0005 = _0003._0002(num5);
					}
					callingAssembly = executingAssembly;
					AssemblyName assemblyName;
					try
					{
						assemblyName = callingAssembly.GetName();
					}
					catch
					{
						assemblyName = new AssemblyName(callingAssembly.FullName);
					}
					_000E = assemblyName.GetPublicKeyToken();
					if (_000E != null && _000E.Length == 0)
					{
						_000E = null;
					}
					num6 = _0002_2000;
					_0002_2000 = 0;
					long num7 = _0006_2000._0002();
					num6 ^= (int)num7;
					num6 ^= 606172302 - num - num2;
					num6 ^= -(~(-(~(-(~(~(-(~((-2058274279 ^ num) + num2)))))))));
					_0006 = (_0006 & ((283981861 - num) ^ num2)) ^ ((0x18EA40B1 ^ num) + num2);
					_000F = num6;
					if (((uint)_0003_2000 & (uint)(-(~(-(~(~(-(-(~(~(-(~((-521324381 - num) ^ num2))))))))))))) == 0)
					{
						_0006 = (0x18EDD36B ^ num) + num2;
					}
				}
				else
				{
					num6 = _000F;
				}
				if (_0006 == ((num + 521367721) ^ num2))
				{
					return new string(new char[3]
					{
						(char)(396745579 - num - num2),
						'0',
						(char)(0xE715D88Bu ^ (uint)num ^ (uint)num2)
					});
				}
				int num8 = _0002 ^ (-433347029 - num + num2) ^ num6;
				num8 ^= num + 1734038849 - num2;
				_0003._0002().Position = num8;
				if (_0005 != null)
				{
					array = _0005;
				}
				else
				{
					short num9 = ((_0008 != -1) ? _0008 : ((short)(_0003._0002() ^ ((num ^ 0x18EA5697) + num2) ^ num8)));
					if (num9 == 0)
					{
						array = null;
					}
					else
					{
						array = _0003._0002(num9);
						for (int i = 0; i != array.Length; i++)
						{
							array[i] ^= (byte)(_000F >> ((3 & i) << 3));
						}
					}
				}
				num10 = _0003._0002() ^ num8 ^ -(~(-(~(-(~(~(-(~(-2018671211 - num - num2))))))))) ^ num6;
				if (num10 != (num ^ 0x18EA272F) + num2)
				{
					break;
				}
				byte[] array2 = _0003._0002(4);
				_0002 = (-1738900884 + num) ^ num2 ^ num6;
				_0002 = (array2[2] | (array2[3] << 16) | (array2[0] << 8) | (array2[1] << 24)) ^ -_0002;
			}
			bool flag2 = (num10 & ((-655743187 ^ num) + num2)) != 0;
			bool flag3 = (num10 & ((933616403 - num) ^ num2)) != 0;
			bool flag4 = (num10 & ((-1729485011 ^ num) + num2)) != 0;
			num10 &= 789759822 + num - num2;
			byte[] array3 = _0008_2000._0002(array, _0003._0002(num10));
			if (_000E != null != (_0006 != -519716553 - num + num2))
			{
				for (int j = 0; j < num10; j++)
				{
					byte b = _000E[7 & j];
					b = (byte)((b << 3) | (b >> 5));
					array3[j] = (byte)(array3[j] ^ b);
				}
			}
			int num11 = _0006 - 12;
			byte[] array4;
			int num12;
			if (!flag3)
			{
				array4 = array3;
				num12 = num10;
			}
			else
			{
				num12 = array3[2] | (array3[0] << 16) | (array3[3] << 8) | (array3[1] << 24);
				array4 = new byte[num12];
				_0005_2000._0002(array3, 4, array4);
			}
			if (flag2 && num11 == 522932169 + num - num2)
			{
				char[] array5 = new char[num12];
				for (int k = 0; k < num12; k++)
				{
					array5[k] = (char)array4[k];
				}
				text = new string(array5);
			}
			else
			{
				text = Encoding.Unicode.GetString(array4, 0, array4.Length);
			}
			num11 += (num ^ -417998676 ^ num2) + (num11 & 3) << 5;
			if (num11 != 522936297 + num - num2)
			{
				int num13 = (num10 + _0002) ^ ((num ^ 0x18F870A5) + num2) ^ (num11 & (396746784 - num - num2));
				StringBuilder stringBuilder = new StringBuilder();
				int num3 = (0x18EA26C5 ^ num) + num2;
				stringBuilder.Append((char)(byte)num3);
				text = num13.ToString(stringBuilder.ToString());
			}
			if (!flag4)
			{
				text = string.Intern(text);
				_0005_2000.m__0002._0002(_0002, text);
				if (_0005_2000.m__0002._0002() == 521325227 + num - num2)
				{
					_0003._0003();
					_0003 = null;
					_0005 = (_000E = null);
				}
			}
			return text;
		}
	}
}
internal static class _0006_2000
{
	private sealed class _0008_2000_2002_2007_2007_2008_2001_2003_200A_2000_2004_2003_2006_200A_200B_2003_2005_2008_2004_2003_2008_200B_2004_2007
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0003(_0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0003(_000E_2003_2005_2006_200B_2008_2003_2006_2000_2007_200A_2002_2008_2008_200A_200A_200B_200A_2007_2004_2003_2002_2004_2001_2007_2000_2006_2008_2001._0002(), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0002(_0006_2000._0002(typeof(_0008_2000_2002_2007_2007_2008_2001_2003_200A_2000_2004_2003_2006_200A_200B_2003_2005_2008_2004_2003_2008_200B_2004_2007)), _0005_200B_2009_2003_2003_2005_2000_200A_2003_2005_200A_2007_2007_2001_2009_2006_2002_2003_2004_2003_2003_2001_2008_2003_2006_2005_2007_2005_2005_2009._0002())), _0006_2000._0002(typeof(_000F_2009_2005_2005_200B_2007_200A_2001_2002_2008_2006_2001_2002_2007_2006_2001_2000_2007_200B)));
		}
	}

	private sealed class _0002_2000_2003_2000_2006_2008_2000_2005_2008_2004_2000_2001_2003_2000
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0005(_0006_2000._0002(typeof(_0002_2000_2003_2000_2006_2008_2000_2005_2008_2004_2000_2001_2003_2000)), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0002(_0006_2000._0002(typeof(_0005_2001_2002_2002_2004_200B_2009_2006_2006_2007_2008_2004_200B_2008_2003)), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0003(_0006_2000._0002(typeof(_0005_200B_2009_2003_2003_2005_2000_200A_2003_2005_200A_2007_2007_2001_2009_2006_2002_2003_2004_2003_2003_2001_2008_2003_2006_2005_2007_2005_2005_2009)), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0005(_0006_2000._0002(typeof(_000E_2003_2005_2006_200B_2008_2003_2006_2000_2007_200A_2002_2008_2008_200A_200A_200B_200A_2007_2004_2003_2002_2004_2001_2007_2000_2006_2008_2001)), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0002(_0006_2000._0002(typeof(_0008_2000_2002_2007_2007_2008_2001_2003_200A_2000_2004_2003_2006_200A_200B_2003_2005_2008_2004_2003_2008_200B_2004_2007)), _0006_2000._0002(typeof(_000F_2009_2005_2005_200B_2007_200A_2001_2002_2008_2006_2001_2002_2007_2006_2001_2000_2007_200B)))))));
		}
	}

	private sealed class _0005_2001_2002_2002_2004_200B_2009_2006_2006_2007_2008_2004_200B_2008_2003
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0005(_0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0003(_0006_2000._0002(typeof(_0005_200B_2009_2003_2003_2005_2000_200A_2003_2005_200A_2007_2007_2001_2009_2006_2002_2003_2004_2003_2003_2001_2008_2003_2006_2005_2007_2005_2005_2009)), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0005(_0006_2000._0002(typeof(_0005_2001_2002_2002_2004_200B_2009_2006_2006_2007_2008_2004_200B_2008_2003)), _0006_2000._0002(typeof(_0008_2000_2002_2007_2007_2008_2001_2003_200A_2000_2004_2003_2006_200A_200B_2003_2005_2008_2004_2003_2008_200B_2004_2007)))), _000F_2009_2005_2005_200B_2007_200A_2001_2002_2008_2006_2001_2002_2007_2006_2001_2000_2007_200B._0002());
		}
	}

	private sealed class _000E_2003_2005_2006_200B_2008_2003_2006_2000_2007_200A_2002_2008_2008_200A_200A_200B_200A_2007_2004_2003_2002_2004_2001_2007_2000_2006_2008_2001
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0005(_0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0002(_0005_200B_2009_2003_2003_2005_2000_200A_2003_2005_200A_2007_2007_2001_2009_2006_2002_2003_2004_2003_2003_2001_2008_2003_2006_2005_2007_2005_2005_2009._0002() ^ ~(-(-(~(~(-(-(~(~(-(~-527758448)))))))))), _0006_2000._0002(typeof(_0002_2000_2003_2000_2006_2008_2000_2005_2008_2004_2000_2001_2003_2000))), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0003(_0006_2000._0002(typeof(_0005_2001_2002_2002_2004_200B_2009_2006_2006_2007_2008_2004_200B_2008_2003)) ^ _0006_2000._0002(typeof(_000F_2009_2005_2005_200B_2007_200A_2001_2002_2008_2006_2001_2002_2007_2006_2001_2000_2007_200B)), -(~(-(~(-(~(-(~(~(-(~1313802915))))))))))));
		}
	}

	private static class _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008
	{
		internal static int _0002(int _0002, int _0003)
		{
			return _0002 ^ (_0003 - -(~(-(~(-(~(~(-(~1783714697)))))))));
		}

		internal static int _0003(int _0002, int _0003)
		{
			return (_0002 - ~(-(-(~(~(-(~(-(-(~(~1751109493))))))))))) ^ (_0003 + -(~(~(-(~(-(~(-(~-77454431)))))))));
		}

		internal static int _0005(int _0002, int _0003)
		{
			return _0002 ^ ((_0003 - -(~(-(~(~(-(-(~(~(-(~-1725343411))))))))))) ^ (_0002 - _0003));
		}
	}

	private sealed class _0003_2007_2009_2002_2007_2009_2006_2001_2005_2004_2008_2005_2005_2008_2006_2002_2003
	{
		private int m__0002;

		private int _0003;

		internal _0003_2007_2009_2002_2007_2009_2006_2001_2005_2004_2008_2005_2005_2008_2006_2002_2003()
		{
			_0002(0L);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal long _0002()
		{
			if (Assembly.GetCallingAssembly() != typeof(_0003_2007_2009_2002_2007_2009_2006_2001_2005_2004_2008_2005_2005_2008_2006_2002_2003).Assembly)
			{
				return 2918384L;
			}
			if (!_0006_2000._0002())
			{
				return 2918384L;
			}
			int[] array = new int[4];
			array[3] = -(~(~(-(-(~(-(~(~-1972979745))))))));
			array[1] = ~(-(~(-(-(~(~(-(~1350012107))))))));
			array[2] = -(~(~(-(-(~(-(~(~-1974012949))))))));
			array[0] = -(~(-(~(-(~(~(-(~-1015743461))))))));
			int num = this.m__0002;
			int num2 = _0003;
			int num3 = ~(-(-(~(-(~(-(~(~(-(~1640531527))))))))));
			int num4 = -(~(~(-(~(-(-(~(~(-(~957401310))))))))));
			for (int i = 0; i != 32; i++)
			{
				num2 -= (((num << 4) ^ (num >> 5)) + num) ^ (num4 + array[(num4 >> 11) & 3]);
				num4 -= num3;
				num -= (((num2 << 4) ^ (num2 >> 5)) + num2) ^ (num4 + array[num4 & 3]);
			}
			for (int j = 0; j != 4; j++)
			{
				array[j] = 0;
			}
			ulong num5 = (ulong)((long)num2 << 32);
			return (long)(num5 | (uint)num);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _0002(long _0002)
		{
			if (Assembly.GetCallingAssembly() == typeof(_0003_2007_2009_2002_2007_2009_2006_2001_2005_2004_2008_2005_2005_2008_2006_2002_2003).Assembly && _0006_2000._0002())
			{
				int[] array = new int[4];
				array[1] = ~(-(-(~(~(-(-(~(-(~(~1350012110))))))))));
				array[0] = ~(-(-(~(~(-(~(-(~-1015743465))))))));
				array[2] = ~(-(-(~(-(~(-(~(~(-(~-1974012950))))))))));
				array[3] = -(~(~(-(-(~(~(-(~(-(~-1972979748))))))))));
				int num = -(~(~(-(~(-(~(-(~1640531524))))))));
				int num2 = (int)_0002;
				int num3 = (int)(_0002 >> 32);
				int num4 = 0;
				for (int i = 0; i != 32; i++)
				{
					num2 += (((num3 << 4) ^ (num3 >> 5)) + num3) ^ (num4 + array[num4 & 3]);
					num4 += num;
					num3 += (((num2 << 4) ^ (num2 >> 5)) + num2) ^ (num4 + array[(num4 >> 11) & 3]);
				}
				for (int j = 0; j != 4; j++)
				{
					array[j] = 0;
				}
				this.m__0002 = num2;
				_0003 = num3;
			}
		}
	}

	private sealed class _000F_2009_2005_2005_200B_2007_200A_2001_2002_2008_2006_2001_2002_2007_2006_2001_2000_2007_200B
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0002(_0006_2000._0002(typeof(_000F_2009_2005_2005_200B_2007_200A_2001_2002_2008_2006_2001_2002_2007_2006_2001_2000_2007_200B)), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0005(_0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0003(_0006_2000._0002(typeof(_0008_2000_2002_2007_2007_2008_2001_2003_200A_2000_2004_2003_2006_200A_200B_2003_2005_2008_2004_2003_2008_200B_2004_2007)), _0006_2000._0002(typeof(_0005_2001_2002_2002_2004_200B_2009_2006_2006_2007_2008_2004_200B_2008_2003))), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0005(_0006_2000._0002(typeof(_000E_2003_2005_2006_200B_2008_2003_2006_2000_2007_200A_2002_2008_2008_200A_200A_200B_200A_2007_2004_2003_2002_2004_2001_2007_2000_2006_2008_2001)) ^ ~(-(~(-(-(~(-(~(~(-(~-2039527458)))))))))), _0008_2000_2002_2007_2007_2008_2001_2003_200A_2000_2004_2003_2006_200A_200B_2003_2005_2008_2004_2003_2008_200B_2004_2007._0002())));
		}
	}

	private sealed class _0005_200B_2009_2003_2003_2005_2000_200A_2003_2005_200A_2007_2007_2001_2009_2006_2002_2003_2004_2003_2003_2001_2008_2003_2006_2005_2007_2005_2005_2009
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0002(_0006_2000._0002(typeof(_000E_2003_2005_2006_200B_2008_2003_2006_2000_2007_200A_2002_2008_2008_200A_200A_200B_200A_2007_2004_2003_2002_2004_2001_2007_2000_2006_2008_2001)), _0006_2000._0002(typeof(_0002_2000_2003_2000_2006_2008_2000_2005_2008_2004_2000_2001_2003_2000)) ^ _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0003(_0006_2000._0002(typeof(_0005_200B_2009_2003_2003_2005_2000_200A_2003_2005_200A_2007_2007_2001_2009_2006_2002_2003_2004_2003_2003_2001_2008_2003_2006_2005_2007_2005_2005_2009)), _0006_2004_2001_2002_2005_2006_2000_2007_2008_2000_2009_2007_2000_2006_2004_2005_2005_2008._0005(_0006_2000._0002(typeof(_000F_2009_2005_2005_200B_2007_200A_2001_2002_2008_2006_2001_2002_2007_2006_2001_2000_2007_200B)), _0002_2000_2003_2000_2006_2008_2000_2005_2008_2004_2000_2001_2003_2000._0002())));
		}
	}

	private static _0003_2007_2009_2002_2007_2009_2006_2001_2005_2004_2008_2005_2005_2008_2006_2002_2003 m__0002 = new _0003_2007_2009_2002_2007_2009_2006_2001_2005_2004_2008_2005_2005_2008_2006_2002_2003();

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static long _0002()
	{
		if (Assembly.GetCallingAssembly() != typeof(_0006_2000).Assembly || !_0002())
		{
			return 0L;
		}
		lock (_0006_2000.m__0002)
		{
			long num = _0006_2000.m__0002._0002();
			if (num == 0)
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				List<byte> list = new List<byte>();
				AssemblyName assemblyName;
				try
				{
					assemblyName = executingAssembly.GetName();
				}
				catch
				{
					assemblyName = new AssemblyName(executingAssembly.FullName);
				}
				byte[] array = assemblyName.GetPublicKeyToken();
				if (array != null && array.Length == 0)
				{
					array = null;
				}
				if (array != null)
				{
					list.AddRange(array);
				}
				list.AddRange(Encoding.Unicode.GetBytes(assemblyName.Name));
				int num2 = _0002(typeof(_0006_2000));
				int num3 = _0005_2001_2002_2002_2004_200B_2009_2006_2006_2007_2008_2004_200B_2008_2003._0002();
				list.Add((byte)(num2 >> 24));
				list.Add((byte)(num3 >> 16));
				list.Add((byte)(num2 >> 8));
				list.Add((byte)num3);
				list.Add((byte)(num2 >> 16));
				list.Add((byte)(num3 >> 8));
				list.Add((byte)num2);
				list.Add((byte)(num3 >> 24));
				int count = list.Count;
				ulong num4 = 0uL;
				for (int i = 0; i != count; i++)
				{
					num4 += list[i];
					num4 += num4 << 20;
					num4 ^= num4 >> 12;
					list[i] = 0;
				}
				num4 += num4 << 6;
				num4 ^= num4 >> 22;
				num4 += num4 << 30;
				num = (long)num4;
				num ^= -7557166597216486260L;
				_0006_2000.m__0002._0002(num);
			}
			return num;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0002()
	{
		if (!_0003())
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0003()
	{
		StackTrace stackTrace = new StackTrace();
		Type type = (stackTrace.GetFrame(3)?.GetMethod())?.DeclaringType;
		if (type == typeof(RuntimeMethodHandle))
		{
			return false;
		}
		if (type == null)
		{
			return false;
		}
		if (type.Assembly != typeof(_0006_2000).Assembly)
		{
			return false;
		}
		return true;
	}

	private static int _0002(Type _0002)
	{
		return _0002.MetadataToken;
	}
}
internal static class _0008_2000
{
	public static byte[] _0002(byte[] _0002, byte[] _0003)
	{
		byte b = _0002[1];
		int num = _0003.Length;
		byte b2 = (byte)((num + 11) ^ (b + 7));
		uint num2 = (uint)((_0002[0] | (_0002[2] << 8)) + (b2 << 3));
		ushort num3 = 0;
		for (int i = 0; i < num; i++)
		{
			if ((i & 1) == 0)
			{
				num2 = num2 * 214013 + 2531011;
				num3 = (ushort)(num2 >> 16);
			}
			byte b3 = (byte)num3;
			num3 = (ushort)(num3 >> 8);
			byte b4 = _0003[i];
			_0003[i] = (byte)(b4 ^ b ^ (b2 + 3) ^ b3);
			b2 = b4;
		}
		return _0003;
	}
}
