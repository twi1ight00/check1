using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Aspose;
using x13f1efc79617a47b;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class x990d54f34b2b5118
{
	private x8859214cc4c1cfab _xec3a126a0abb0cbf;

	private xb2ddbff67fa53c13 _xb2ddbff67fa53c13;

	private xdaccc4e215530d18 _x6a403654e6eff91d;

	private x3021244279b7a80c _x12b00c407ac22ed0;

	internal xed28787af62b195b _x845726eb9cff3810;

	internal DateTime _xf3d2608616d7641a;

	private DateTime _x6c80cf8f89bb22b5;

	private DateTime _x4ab867ea64e4b33f;

	private DateTime _xabb478a6899dcd45;

	private bool _x944b5cca78a375e0;

	private bool _x7e86c2f18f82bb31 = true;

	private bool _xd55b6f5e7aaffd65;

	private bool _x4d9ca6c385e8e4cd = true;

	private bool _x4c8357e8f994ea6a;

	internal string _x08d0fbfeee1603b1;

	private string _x5ccc000b8fc5503b;

	internal short _x2225527e56803a37;

	internal short _x2d3be316c1c6e811;

	internal short _x93f6dc9bc169b40a;

	internal string _x937e050c63ea1527;

	private bool _x4d1990cadac28b9b;

	private byte[] _xb221a693d5677af2;

	internal long _x9a0049934ff5530a;

	internal long _x09d464f2121ddee7;

	internal long _xc49fe6a8d63d6783;

	internal int _xc3309b8559936a71;

	private bool _x6964db67658cf88e;

	internal int _x5e4059a15fb5fca5;

	internal byte[] _xd7925bc5f938f029;

	private bool _x55f2a2fe7806c520;

	private bool _x01c9af277f1f564c;

	private bool _x6e12b59bb92f483d;

	private bool _x00feab56489b1a16;

	private static Encoding x34202fa0ef9be422 = Encoding.GetEncoding("IBM437");

	private Encoding _x569440e5ccedf43e = Encoding.GetEncoding("IBM437");

	private Encoding _x8311d99018a2b664;

	internal xef4b7685c2495ff2 _xe2a6c1b66e699ef3;

	internal long _xfad3df95ca108a86 = -1L;

	private byte[] _x04cffeb7c4db4cab;

	internal long _x7e322ff037b992c9;

	private long _x5348dad0c0de551e;

	internal int _xb69adf785c29907e;

	internal int _x72b7a211fbd3d75f;

	private bool _x60a12c8412239ce4;

	private uint _xc6ddcdd59292e6fb;

	internal string _xa4bc2af2b58881c8;

	internal x58bf66883d9e6d5a _xaf77e81a71d6921f;

	internal xea98c2211cc2e8a1 _x5d327c9569dc4f54;

	internal byte[] _x8109109d50a7c0cd;

	internal Stream _x3c23849cf83dda47;

	private Stream _xfa527d9626e5c265;

	private x7540eedf8f68f598 _x4b68a32d150ba5ec;

	private bool _xd3c9e810be4be9ac;

	private bool _x49fe32f14563e6a0;

	private bool _x682ce91e3cc65602;

	private x09c3256ccc14f142 _x1b01248c8c69aa12;

	private x09c3256ccc14f142 _x4f36598217f645a0;

	private bool _x1ede37fe2e573750;

	private x096547e09b6773c8 _x2e1983435b85b773;

	private static DateTime _x7b854fa04f4ba476 = new DateTime(1970, 1, 1, 0, 0, 0);

	private short _x345ff482eb7fd52e;

	private short _x8df788c027b02673;

	private int _xe6f4ba51aec00070;

	private short _x925f87827a4e97dd;

	private short _x6019d41161d394d8;

	private short _xafd07aeb1737aa2c;

	private int _x174d4f7cf3cee2ef;

	private static Regex _xbe492d663860b696 = new Regex("(?i)^(.+)\\.(mp3|png|docx|xlsx|pptx|jpg|zip)$");

	public DateTime xf3d2608616d7641a
	{
		get
		{
			return _xf3d2608616d7641a.ToLocalTime();
		}
		set
		{
			_xf3d2608616d7641a = value;
			_x6c80cf8f89bb22b5 = _xf3d2608616d7641a.ToUniversalTime();
			_x55f2a2fe7806c520 = true;
		}
	}

	private int x648114bcf1499890 => _xe2a6c1b66e699ef3.x648114bcf1499890;

	public DateTime x15e2702e23e71188 => _x6c80cf8f89bb22b5;

	public DateTime x2de6c4c2c8e13a92 => _x4ab867ea64e4b33f;

	public DateTime x3495c9728d107e27 => _xabb478a6899dcd45;

	public bool x31e3d7775ac697d2
	{
		get
		{
			return _x7e86c2f18f82bb31;
		}
		set
		{
			_x7e86c2f18f82bb31 = value;
			_x55f2a2fe7806c520 = true;
		}
	}

	public bool xf14036286e5de933
	{
		get
		{
			return _xd55b6f5e7aaffd65;
		}
		set
		{
			_xd55b6f5e7aaffd65 = value;
			_x55f2a2fe7806c520 = true;
		}
	}

	public x096547e09b6773c8 xd3ca88523c647e20 => _x2e1983435b85b773;

	public FileAttributes xf9ca4ea3f3bfac5b
	{
		get
		{
			return (FileAttributes)_xe6f4ba51aec00070;
		}
		set
		{
			_xe6f4ba51aec00070 = (int)value;
			_x345ff482eb7fd52e = 45;
			_x55f2a2fe7806c520 = true;
		}
	}

	public bool x4c8357e8f994ea6a
	{
		get
		{
			return _x4c8357e8f994ea6a;
		}
		set
		{
			if (value != _x4c8357e8f994ea6a)
			{
				_x4c8357e8f994ea6a = value;
				if (_x4c8357e8f994ea6a)
				{
					x93f6dc9bc169b40a = 0;
				}
			}
		}
	}

	internal string x08d0fbfeee1603b1 => _x08d0fbfeee1603b1;

	public string xa39af5a82860a9a3
	{
		get
		{
			return _x5ccc000b8fc5503b;
		}
		set
		{
			if (value == null || value.Length == 0)
			{
				throw new xc5e345d2a919c94b("The FileName must be non empty and non-null.");
			}
			string text = x0af2fa0746b15844(value, null);
			if (!(_x5ccc000b8fc5503b == text))
			{
				if (_xe2a6c1b66e699ef3.x1b31e7fa3c687c32.Contains(text))
				{
					throw new xc5e345d2a919c94b(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dbhjocojidfkfdmkdddlfdklonamncimnbpmdcgndbnnmbeobblojmbpbcjpdnppnbhanlnaoafbgambelccmakcpladiaiddmodfkfedomenodfmjkfonbgeoighopgcoghgonhkieijmlinncjbijjcnakdmhkjlokjmflchmlnldmnkkmglbnlkindgpnbkgojknomkepmjlpfjcafjjahkablehbniobnjfclimccjddajkdmibegdiemhpeohgfncnfohegpglgjgchbcjhpfainghilfoinffjlfmjfgdkbfkkhbbl", 1861457616)), _x5ccc000b8fc5503b, text));
				}
				_x5ccc000b8fc5503b = text;
				if (_xe2a6c1b66e699ef3 != null)
				{
					_xe2a6c1b66e699ef3.x51d89fc17a291894();
				}
				_x55f2a2fe7806c520 = true;
			}
		}
	}

	public Stream x90afdf76f999bad8
	{
		get
		{
			return _xfa527d9626e5c265;
		}
		set
		{
			if (_xaf77e81a71d6921f != x58bf66883d9e6d5a.xb8a774e0111d0fbe)
			{
				throw new xc5e345d2a919c94b("You must not set the input stream for this ZipEntry.");
			}
			_xd3c9e810be4be9ac = true;
			_xfa527d9626e5c265 = value;
		}
	}

	public bool x6805e10245a4d94b => _xd3c9e810be4be9ac;

	public x58bf66883d9e6d5a xaf77e81a71d6921f => _xaf77e81a71d6921f;

	public short x2225527e56803a37 => _x2225527e56803a37;

	public string x937e050c63ea1527
	{
		get
		{
			return _x937e050c63ea1527;
		}
		set
		{
			_x937e050c63ea1527 = value;
			_x55f2a2fe7806c520 = true;
		}
	}

	public x09c3256ccc14f142 x7683750c9f5c037f => _x1b01248c8c69aa12;

	public x09c3256ccc14f142 xff7630c349464a76 => _x4f36598217f645a0;

	public short x2d3be316c1c6e811 => _x2d3be316c1c6e811;

	public short x93f6dc9bc169b40a
	{
		get
		{
			return _x93f6dc9bc169b40a;
		}
		set
		{
			if (value != _x93f6dc9bc169b40a)
			{
				if (value != 0 && value != 8)
				{
					throw new InvalidOperationException("Unsupported compression method. Specify 8 or 0.");
				}
				if (_xaf77e81a71d6921f == x58bf66883d9e6d5a.xef4b7685c2495ff2 && _x6e12b59bb92f483d)
				{
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("acmklddlfeklcebmaeimcepmlofnlcnnnceodclonccpdcjpobaagngagboapbfbkbmbkbdcjbkcjabdebidbbpdeagehanedaefclkfmpbgbpignppgooghcpnheoeinjlijocjfojjejakgnhkmnokomflknmlondmcnkmdnbnbminnlpnghgoilnoolepbmlpmlcaaljajkabelhbofobnkfcnjmcgjddgjkdpebecjieljpefjgfajnfaeegohlgmichkhjhmhaikhhieioiahfjlhmjdddk", 971811805)));
				}
				_x93f6dc9bc169b40a = value;
				_x4c8357e8f994ea6a = _x93f6dc9bc169b40a == 0;
				_x01c9af277f1f564c = true;
			}
		}
	}

	public long x9a0049934ff5530a => _x9a0049934ff5530a;

	public long xc49fe6a8d63d6783 => _xc49fe6a8d63d6783;

	public double xe474cb2a9795d184
	{
		get
		{
			if (xc49fe6a8d63d6783 == 0)
			{
				return 0.0;
			}
			return 100.0 * (1.0 - 1.0 * (double)x9a0049934ff5530a / (1.0 * (double)xc49fe6a8d63d6783));
		}
	}

	public int x4267aa67a0bb35b8 => _x5e4059a15fb5fca5;

	public bool x4d1990cadac28b9b => _x4d1990cadac28b9b;

	public bool xe9881a3551b0697b => x5d327c9569dc4f54 != xea98c2211cc2e8a1.x4d0b9d4447ba7566;

	public xea98c2211cc2e8a1 x5d327c9569dc4f54
	{
		get
		{
			return _x5d327c9569dc4f54;
		}
		set
		{
			if (value != _x5d327c9569dc4f54)
			{
				if (value == xea98c2211cc2e8a1.xf9120e21ea3ee2d1)
				{
					throw new InvalidOperationException("You may not set Encryption to that value.");
				}
				if (_xaf77e81a71d6921f == x58bf66883d9e6d5a.xef4b7685c2495ff2 && _x6e12b59bb92f483d)
				{
					throw new InvalidOperationException("You cannot change the encryption method on encrypted entries read from archives.");
				}
				_x5d327c9569dc4f54 = value;
				_x01c9af277f1f564c = true;
			}
		}
	}

	public string xa4bc2af2b58881c8
	{
		set
		{
			_xa4bc2af2b58881c8 = value;
			if (_xa4bc2af2b58881c8 == null)
			{
				_x5d327c9569dc4f54 = xea98c2211cc2e8a1.x4d0b9d4447ba7566;
				return;
			}
			if (_xaf77e81a71d6921f == x58bf66883d9e6d5a.xef4b7685c2495ff2 && !_x6e12b59bb92f483d)
			{
				_x01c9af277f1f564c = true;
			}
			if (x5d327c9569dc4f54 == xea98c2211cc2e8a1.x4d0b9d4447ba7566)
			{
				_x5d327c9569dc4f54 = xea98c2211cc2e8a1.x94fedbf94759d5f4;
			}
		}
	}

	[Obsolete("Please use property ExtractExistingFile")]
	public bool x34cf459722ddd016
	{
		get
		{
			return xec3a126a0abb0cbf == x8859214cc4c1cfab.xf4b7fc58735e7b0b;
		}
		set
		{
			xec3a126a0abb0cbf = (value ? x8859214cc4c1cfab.xf4b7fc58735e7b0b : x8859214cc4c1cfab.x643d287ae28d7eef);
		}
	}

	public x8859214cc4c1cfab xec3a126a0abb0cbf
	{
		get
		{
			return _xec3a126a0abb0cbf;
		}
		set
		{
			_xec3a126a0abb0cbf = value;
		}
	}

	public xb2ddbff67fa53c13 xb2ddbff67fa53c13
	{
		get
		{
			return _xb2ddbff67fa53c13;
		}
		set
		{
			_xb2ddbff67fa53c13 = value;
		}
	}

	public bool x998805a6e2868a2b => !_x00feab56489b1a16;

	public xdaccc4e215530d18 x6a403654e6eff91d
	{
		get
		{
			return _x6a403654e6eff91d;
		}
		set
		{
			_x6a403654e6eff91d = value;
		}
	}

	public x3021244279b7a80c x12b00c407ac22ed0
	{
		get
		{
			return _x12b00c407ac22ed0;
		}
		set
		{
			_x12b00c407ac22ed0 = value;
		}
	}

	public bool xf3bb583435b3ad15
	{
		get
		{
			return _x569440e5ccedf43e == Encoding.GetEncoding("UTF-8");
		}
		set
		{
			_x569440e5ccedf43e = (value ? Encoding.GetEncoding("UTF-8") : xef4b7685c2495ff2.x24500e9782c41ba0);
		}
	}

	public Encoding xbfe2d4ca3e43b779
	{
		get
		{
			return _x569440e5ccedf43e;
		}
		set
		{
			_x569440e5ccedf43e = value;
		}
	}

	public Encoding x0e86491345e4da18 => _x8311d99018a2b664;

	public bool x1ede37fe2e573750
	{
		get
		{
			return _x1ede37fe2e573750;
		}
		set
		{
			_x1ede37fe2e573750 = value;
		}
	}

	internal int x1aa43c710cd072fa
	{
		get
		{
			if ((_x2d3be316c1c6e811 & 1) != 1)
			{
				return 0;
			}
			if (x5d327c9569dc4f54 == xea98c2211cc2e8a1.x94fedbf94759d5f4)
			{
				return 12;
			}
			throw new xc5e345d2a919c94b("internal error");
		}
	}

	internal long xac0e037603b38c89
	{
		get
		{
			if (_xfad3df95ca108a86 == -1)
			{
				x577f7571757e04cb();
			}
			return _xfad3df95ca108a86;
		}
	}

	private int xb69adf785c29907e
	{
		get
		{
			if (_xb69adf785c29907e == 0)
			{
				x577f7571757e04cb();
			}
			return _xb69adf785c29907e;
		}
	}

	internal bool x996e6a5ca4407167
	{
		get
		{
			if (_x8df788c027b02673 == 0)
			{
				return (_xe6f4ba51aec00070 & 0x10) == 16;
			}
			return false;
		}
	}

	internal Stream x4b75fd1546e838a4
	{
		get
		{
			if (_x3c23849cf83dda47 == null && _xe2a6c1b66e699ef3 != null)
			{
				_xe2a6c1b66e699ef3.x74f5a1ef3906e23c();
				_x3c23849cf83dda47 = _xe2a6c1b66e699ef3.x53cce0b6abbd65ad;
			}
			return _x3c23849cf83dda47;
		}
	}

	private string x32e41a75f68d3df0 => _xc6ddcdd59292e6fb switch
	{
		0u => "--", 
		26113u => "DES", 
		26114u => "RC2", 
		26115u => "3DES-168", 
		26121u => "3DES-112", 
		26126u => "PKWare AES128", 
		26127u => "PKWare AES192", 
		26128u => "PKWare AES256", 
		26370u => "RC2", 
		26400u => "Blowfish", 
		26401u => "Twofish", 
		26625u => "RC4", 
		_ => $"Unknown (0x{_xc6ddcdd59292e6fb:X4})", 
	};

	private string xe6241184a93826d6 => _x93f6dc9bc169b40a switch
	{
		0 => "Store", 
		1 => "Shrink", 
		8 => "DEFLATE", 
		9 => "Deflate64", 
		14 => "LZMA", 
		19 => "LZ77", 
		98 => "PPMd", 
		_ => $"Unknown (0x{_x93f6dc9bc169b40a:X4})", 
	};

	public void x9717213af9ca96dc(DateTime x008fedb04fddac08, DateTime x88f1a4167dc8159a, DateTime xc6712b355bbb406e)
	{
		_x944b5cca78a375e0 = true;
		_xabb478a6899dcd45 = x008fedb04fddac08.ToUniversalTime();
		_x4ab867ea64e4b33f = x88f1a4167dc8159a.ToUniversalTime();
		_x6c80cf8f89bb22b5 = xc6712b355bbb406e.ToUniversalTime();
		_xf3d2608616d7641a = _x6c80cf8f89bb22b5;
		_x7e86c2f18f82bb31 = true;
		_x55f2a2fe7806c520 = true;
	}

	[Obsolete("Please use method SetEntryTimes(DateTime,DateTime,DateTime)")]
	public void x1d0af102d8429b88(DateTime x008fedb04fddac08, DateTime x88f1a4167dc8159a, DateTime xc6712b355bbb406e)
	{
		x9717213af9ca96dc(x008fedb04fddac08, x88f1a4167dc8159a, xc6712b355bbb406e);
	}

	internal static string x0af2fa0746b15844(string xb41a802ca5fde63b, string x3dc2b3acae462066)
	{
		string x803a44738fba695a = ((x3dc2b3acae462066 == null) ? xb41a802ca5fde63b : ((x3dc2b3acae462066 != null && x3dc2b3acae462066.Length != 0) ? Path.Combine(x3dc2b3acae462066, Path.GetFileName(xb41a802ca5fde63b)) : Path.GetFileName(xb41a802ca5fde63b)));
		x803a44738fba695a = x977b5605864b2047.x849264acdd8a9902(x803a44738fba695a);
		x803a44738fba695a = x977b5605864b2047.xc820dec65d650cb5(x803a44738fba695a);
		while (x803a44738fba695a.StartsWith("/"))
		{
			x803a44738fba695a = x803a44738fba695a.Substring(1);
		}
		return x803a44738fba695a;
	}

	internal static x990d54f34b2b5118 xebcf83b00134300b(string xb41a802ca5fde63b, string x208b8f1045d9bc0a)
	{
		return xebcf83b00134300b(xb41a802ca5fde63b, x208b8f1045d9bc0a, xc11f3de674812865: false, null);
	}

	internal static x990d54f34b2b5118 xebcf83b00134300b(string xb41a802ca5fde63b, string x208b8f1045d9bc0a, bool xc11f3de674812865, Stream xcf18e5243f8d5fd3)
	{
		if (xb41a802ca5fde63b == null || xb41a802ca5fde63b.Length == 0)
		{
			throw new xc5e345d2a919c94b("The entry name must be non-null and non-empty.");
		}
		x990d54f34b2b5118 x990d54f34b2b5119 = new x990d54f34b2b5118();
		x990d54f34b2b5119._x345ff482eb7fd52e = 45;
		if (xc11f3de674812865)
		{
			x990d54f34b2b5119._xaf77e81a71d6921f = x58bf66883d9e6d5a.xb8a774e0111d0fbe;
			x990d54f34b2b5119._xfa527d9626e5c265 = xcf18e5243f8d5fd3;
			x990d54f34b2b5119._x6c80cf8f89bb22b5 = (x990d54f34b2b5119._x4ab867ea64e4b33f = (x990d54f34b2b5119._xabb478a6899dcd45 = DateTime.UtcNow));
		}
		else
		{
			x990d54f34b2b5119._xaf77e81a71d6921f = x58bf66883d9e6d5a.xd8c3135513b9115b;
			x990d54f34b2b5119._x6c80cf8f89bb22b5 = File.GetLastWriteTimeUtc(xb41a802ca5fde63b);
			x990d54f34b2b5119._xabb478a6899dcd45 = File.GetCreationTimeUtc(xb41a802ca5fde63b);
			x990d54f34b2b5119._x4ab867ea64e4b33f = File.GetLastAccessTimeUtc(xb41a802ca5fde63b);
			if (File.Exists(xb41a802ca5fde63b) || Directory.Exists(xb41a802ca5fde63b))
			{
				x990d54f34b2b5119._xe6f4ba51aec00070 = (int)File.GetAttributes(xb41a802ca5fde63b);
			}
			x990d54f34b2b5119._x944b5cca78a375e0 = true;
		}
		x990d54f34b2b5119._xf3d2608616d7641a = x990d54f34b2b5119._x6c80cf8f89bb22b5;
		x990d54f34b2b5119._x08d0fbfeee1603b1 = (xc11f3de674812865 ? xb41a802ca5fde63b : Path.GetFullPath(xb41a802ca5fde63b));
		x990d54f34b2b5119._x5ccc000b8fc5503b = x208b8f1045d9bc0a.Replace('\\', '/');
		return x990d54f34b2b5119;
	}

	internal void xa1404b84036ecc66()
	{
		_x4d1990cadac28b9b = true;
		if (!_x5ccc000b8fc5503b.EndsWith("/"))
		{
			_x5ccc000b8fc5503b += "/";
		}
	}

	public override string ToString()
	{
		return $"ZipEntry/{xa39af5a82860a9a3}";
	}

	private void x577f7571757e04cb()
	{
		long position = x4b75fd1546e838a4.Position;
		try
		{
			_xe2a6c1b66e699ef3.xd0c948b79c880a6b(_x7e322ff037b992c9);
		}
		catch (IOException innerException)
		{
			string message = $"Exception seeking  entry({xa39af5a82860a9a3}) offset(0x{_x7e322ff037b992c9:X8}) len(0x{x4b75fd1546e838a4.Length:X8})";
			throw new xcb4fb578c1324851(message, innerException);
		}
		byte[] array = new byte[30];
		x4b75fd1546e838a4.Read(array, 0, array.Length);
		short num = (short)(array[26] + array[27] * 256);
		short num2 = (short)(array[28] + array[29] * 256);
		x4b75fd1546e838a4.Seek(num + num2, SeekOrigin.Current);
		_xb69adf785c29907e = 30 + num2 + num + x1aa43c710cd072fa;
		_xfad3df95ca108a86 = _x7e322ff037b992c9 + _xb69adf785c29907e;
		x4b75fd1546e838a4.Seek(position, SeekOrigin.Begin);
	}

	internal void xb6e3214af5a3f380()
	{
		_xfad3df95ca108a86 = -1L;
		_xb69adf785c29907e = 0;
	}

	internal static x990d54f34b2b5118 x64da0b7f32fdd92e(xef4b7685c2495ff2 x2fe8f0c48ba61aee)
	{
		Stream x53cce0b6abbd65ad = x2fe8f0c48ba61aee.x53cce0b6abbd65ad;
		Encoding xff3edc9aa5f0523b = x2fe8f0c48ba61aee.xbfe2d4ca3e43b779;
		int num = x977b5605864b2047.x4e38ee4c0a37efb1(x53cce0b6abbd65ad);
		if (x095a1f4f865cc948(num))
		{
			x53cce0b6abbd65ad.Seek(-4L, SeekOrigin.Current);
			if ((long)num != 101010256 && (long)num != 101075792 && num != 67324752)
			{
				throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ilaiflhimooiipfjmpmjomdkepkkhpblcpilgpplelgmblnmgmengnlnpmcopmjomkapomhpenopekfakmmanmdbimkbmmbcihicghpceigdhgndgieeckleckcflfjflkagojhgjjognjfhnimhnjdiljkifjbjfiijndpjcegkhenkmielmillodcmfejmaganndhnphonicfombmokfdpkgkpdbbaagiamfpanfgbafnbifeckelcnecdjejdippdfahekeoekeffnplfdadgobkglpahndih", 1641906328)), num, x53cce0b6abbd65ad.Position));
			}
			return null;
		}
		int num2 = 46;
		byte[] array = new byte[42];
		int num3 = x53cce0b6abbd65ad.Read(array, 0, array.Length);
		if (num3 != array.Length)
		{
			return null;
		}
		int num4 = 0;
		x990d54f34b2b5118 x990d54f34b2b5119 = new x990d54f34b2b5118();
		x990d54f34b2b5119._xaf77e81a71d6921f = x58bf66883d9e6d5a.xef4b7685c2495ff2;
		x990d54f34b2b5119._x3c23849cf83dda47 = x53cce0b6abbd65ad;
		x990d54f34b2b5119._xe2a6c1b66e699ef3 = x2fe8f0c48ba61aee;
		x990d54f34b2b5119._x345ff482eb7fd52e = (short)(array[num4++] + array[num4++] * 256);
		x990d54f34b2b5119._x2225527e56803a37 = (short)(array[num4++] + array[num4++] * 256);
		x990d54f34b2b5119._x2d3be316c1c6e811 = (short)(array[num4++] + array[num4++] * 256);
		x990d54f34b2b5119._x93f6dc9bc169b40a = (short)(array[num4++] + array[num4++] * 256);
		x990d54f34b2b5119._xc3309b8559936a71 = array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256;
		x990d54f34b2b5119._xf3d2608616d7641a = x977b5605864b2047.x5def2075df47607e(x990d54f34b2b5119._xc3309b8559936a71);
		x990d54f34b2b5119._x2e1983435b85b773 |= x096547e09b6773c8.x58e6601812cd8f83;
		x990d54f34b2b5119._x5e4059a15fb5fca5 = array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256;
		x990d54f34b2b5119._x9a0049934ff5530a = (uint)(array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256);
		x990d54f34b2b5119._xc49fe6a8d63d6783 = (uint)(array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256);
		x990d54f34b2b5119._x925f87827a4e97dd = (short)(array[num4++] + array[num4++] * 256);
		x990d54f34b2b5119._x6019d41161d394d8 = (short)(array[num4++] + array[num4++] * 256);
		x990d54f34b2b5119._xafd07aeb1737aa2c = (short)(array[num4++] + array[num4++] * 256);
		num4 += 2;
		x990d54f34b2b5119._x8df788c027b02673 = (short)(array[num4++] + array[num4++] * 256);
		x990d54f34b2b5119._xe6f4ba51aec00070 = array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256;
		x990d54f34b2b5119._x7e322ff037b992c9 = (uint)(array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256);
		x990d54f34b2b5119.x1ede37fe2e573750 = (x990d54f34b2b5119._x8df788c027b02673 & 1) == 1;
		array = new byte[x990d54f34b2b5119._x925f87827a4e97dd];
		num3 = x53cce0b6abbd65ad.Read(array, 0, array.Length);
		num2 += num3;
		if ((x990d54f34b2b5119._x2d3be316c1c6e811 & 0x800) == 2048)
		{
			x990d54f34b2b5119._x08d0fbfeee1603b1 = x977b5605864b2047.x6a3fd4d8bc04438e(array);
		}
		else
		{
			x990d54f34b2b5119._x08d0fbfeee1603b1 = x977b5605864b2047.x0f110a4d541356e9(array, xff3edc9aa5f0523b);
		}
		x990d54f34b2b5119._x5ccc000b8fc5503b = x990d54f34b2b5119._x08d0fbfeee1603b1;
		if (x990d54f34b2b5119.x996e6a5ca4407167)
		{
			x990d54f34b2b5119.xa1404b84036ecc66();
		}
		if (x990d54f34b2b5119._x08d0fbfeee1603b1.EndsWith("/"))
		{
			x990d54f34b2b5119.xa1404b84036ecc66();
		}
		x990d54f34b2b5119._x09d464f2121ddee7 = x990d54f34b2b5119._x9a0049934ff5530a;
		if ((x990d54f34b2b5119._x2d3be316c1c6e811 & 1) == 1)
		{
			x990d54f34b2b5119._x5d327c9569dc4f54 = xea98c2211cc2e8a1.x94fedbf94759d5f4;
			x990d54f34b2b5119._x6e12b59bb92f483d = true;
		}
		if (x990d54f34b2b5119._x6019d41161d394d8 > 0)
		{
			x990d54f34b2b5119._x60a12c8412239ce4 = x990d54f34b2b5119._x9a0049934ff5530a == uint.MaxValue || x990d54f34b2b5119._xc49fe6a8d63d6783 == uint.MaxValue || x990d54f34b2b5119._x7e322ff037b992c9 == uint.MaxValue;
			num2 += x990d54f34b2b5119.xe8d1e1645b9870d1(x990d54f34b2b5119._x6019d41161d394d8);
			x990d54f34b2b5119._x09d464f2121ddee7 = x990d54f34b2b5119._x9a0049934ff5530a;
		}
		if (x990d54f34b2b5119._x5d327c9569dc4f54 == xea98c2211cc2e8a1.x94fedbf94759d5f4)
		{
			x990d54f34b2b5119._x09d464f2121ddee7 -= 12L;
		}
		if ((x990d54f34b2b5119._x2d3be316c1c6e811 & 8) == 8)
		{
			if (x990d54f34b2b5119._x60a12c8412239ce4)
			{
				x990d54f34b2b5119._x72b7a211fbd3d75f += 24;
			}
			else
			{
				x990d54f34b2b5119._x72b7a211fbd3d75f += 16;
			}
		}
		if (x990d54f34b2b5119._xafd07aeb1737aa2c > 0)
		{
			array = new byte[x990d54f34b2b5119._xafd07aeb1737aa2c];
			num3 = x53cce0b6abbd65ad.Read(array, 0, array.Length);
			num2 += num3;
			if ((x990d54f34b2b5119._x2d3be316c1c6e811 & 0x800) == 2048)
			{
				x990d54f34b2b5119._x937e050c63ea1527 = x977b5605864b2047.x6a3fd4d8bc04438e(array);
			}
			else
			{
				x990d54f34b2b5119._x937e050c63ea1527 = x977b5605864b2047.x0f110a4d541356e9(array, xff3edc9aa5f0523b);
			}
		}
		return x990d54f34b2b5119;
	}

	internal static bool x095a1f4f865cc948(int x8ebde9a98df80374)
	{
		return x8ebde9a98df80374 != 33639248;
	}

	public void xf098323036d9ec26()
	{
		x4a77f4b2eb397877(".", null, null);
	}

	[Obsolete("Please use method Extract(ExtractExistingFileAction)")]
	public void xf098323036d9ec26(bool x2c767f6e906b41f2)
	{
		x34cf459722ddd016 = x2c767f6e906b41f2;
		x4a77f4b2eb397877(".", null, null);
	}

	public void xf098323036d9ec26(x8859214cc4c1cfab x72e58d297dd6036f)
	{
		xec3a126a0abb0cbf = x72e58d297dd6036f;
		x4a77f4b2eb397877(".", null, null);
	}

	public void xf098323036d9ec26(Stream xcf18e5243f8d5fd3)
	{
		x4a77f4b2eb397877(null, xcf18e5243f8d5fd3, null);
	}

	public void xf098323036d9ec26(string x7ed33abfa74e926a)
	{
		x4a77f4b2eb397877(x7ed33abfa74e926a, null, null);
	}

	[Obsolete("Please use method Extract(String,ExtractExistingFileAction)")]
	public void xf098323036d9ec26(string x7ed33abfa74e926a, bool x2c767f6e906b41f2)
	{
		x34cf459722ddd016 = x2c767f6e906b41f2;
		x4a77f4b2eb397877(x7ed33abfa74e926a, null, null);
	}

	public void xf098323036d9ec26(string x7ed33abfa74e926a, x8859214cc4c1cfab x72e58d297dd6036f)
	{
		xec3a126a0abb0cbf = x72e58d297dd6036f;
		x4a77f4b2eb397877(x7ed33abfa74e926a, null, null);
	}

	public void x7a5a6b31c8cf1a61(string xe8e4b5871d71a79a)
	{
		x4a77f4b2eb397877(".", null, xe8e4b5871d71a79a);
	}

	public void x7a5a6b31c8cf1a61(string x7ed33abfa74e926a, string xe8e4b5871d71a79a)
	{
		x4a77f4b2eb397877(x7ed33abfa74e926a, null, xe8e4b5871d71a79a);
	}

	[Obsolete("Please use method ExtractWithPassword(ExtractExistingFileAction,String)")]
	public void x7a5a6b31c8cf1a61(bool x2c767f6e906b41f2, string xe8e4b5871d71a79a)
	{
		x34cf459722ddd016 = x2c767f6e906b41f2;
		x4a77f4b2eb397877(".", null, xe8e4b5871d71a79a);
	}

	public void x7a5a6b31c8cf1a61(x8859214cc4c1cfab x72e58d297dd6036f, string xe8e4b5871d71a79a)
	{
		xec3a126a0abb0cbf = x72e58d297dd6036f;
		x4a77f4b2eb397877(".", null, xe8e4b5871d71a79a);
	}

	[Obsolete("Please use method ExtractWithPassword(String,ExtractExistingFileAction,String)")]
	public void x7a5a6b31c8cf1a61(string x7ed33abfa74e926a, bool x2c767f6e906b41f2, string xe8e4b5871d71a79a)
	{
		x34cf459722ddd016 = x2c767f6e906b41f2;
		x4a77f4b2eb397877(x7ed33abfa74e926a, null, xe8e4b5871d71a79a);
	}

	public void x7a5a6b31c8cf1a61(string x7ed33abfa74e926a, x8859214cc4c1cfab x72e58d297dd6036f, string xe8e4b5871d71a79a)
	{
		xec3a126a0abb0cbf = x72e58d297dd6036f;
		x4a77f4b2eb397877(x7ed33abfa74e926a, null, xe8e4b5871d71a79a);
	}

	public void x7a5a6b31c8cf1a61(Stream xcf18e5243f8d5fd3, string xe8e4b5871d71a79a)
	{
		x4a77f4b2eb397877(null, xcf18e5243f8d5fd3, xe8e4b5871d71a79a);
	}

	public x18b5d2c1faea3df7 xa1180ac0ca3fb6c5()
	{
		return x7d8d153a00d4f499((_xa4bc2af2b58881c8 != null) ? _xa4bc2af2b58881c8 : _xe2a6c1b66e699ef3._xa4bc2af2b58881c8);
	}

	public x18b5d2c1faea3df7 xa1180ac0ca3fb6c5(string xe8e4b5871d71a79a)
	{
		return x7d8d153a00d4f499(xe8e4b5871d71a79a);
	}

	private x18b5d2c1faea3df7 x7d8d153a00d4f499(string xe8e4b5871d71a79a)
	{
		xf26e1b8bd950c52b();
		x8daa7e01a9556135();
		xd5aa7b201073242e(xe8e4b5871d71a79a);
		if (_xaf77e81a71d6921f != x58bf66883d9e6d5a.xef4b7685c2495ff2)
		{
			throw new xcb4fb578c1324851("You must call ZipFile.Save before calling OpenReader.");
		}
		Stream stream = x4b75fd1546e838a4;
		_xe2a6c1b66e699ef3.xd0c948b79c880a6b(xac0e037603b38c89);
		Stream stream2 = stream;
		if (x5d327c9569dc4f54 == xea98c2211cc2e8a1.x94fedbf94759d5f4)
		{
			stream2 = new xc65b5343382bdcf8(stream, _x845726eb9cff3810, x0c752eb8af884509.xcc381ffa3ede662f);
		}
		return new x18b5d2c1faea3df7((x93f6dc9bc169b40a == 8) ? new xdd609f761b3f07f0(stream2, x1f770018e5e12789.x706f07a5eea59a53, leaveOpen: true) : stream2, _xc49fe6a8d63d6783);
	}

	private void x3e6b71396bc9bdee(long xa289f275e6a0e493, long x985b78aab437c0a4)
	{
		_x49fe32f14563e6a0 = _xe2a6c1b66e699ef3.xa9f57747a0117270(this, xa289f275e6a0e493, x985b78aab437c0a4);
	}

	private void x7f883ecb982e5b94(string xe125219852864557)
	{
		if (!_xe2a6c1b66e699ef3._x1cc53e92d902f0a4)
		{
			_x49fe32f14563e6a0 = _xe2a6c1b66e699ef3.x0f32cc2a7f373e11(this, xe125219852864557, x6b161b1ae41c1651: true);
		}
	}

	private void x7bb50e6afa47c5ce(string xe125219852864557)
	{
		if (!_xe2a6c1b66e699ef3._x1cc53e92d902f0a4)
		{
			_xe2a6c1b66e699ef3.x0f32cc2a7f373e11(this, xe125219852864557, x6b161b1ae41c1651: false);
		}
	}

	private void xeac40bb76c9d449c(string xe125219852864557)
	{
		_x49fe32f14563e6a0 = _xe2a6c1b66e699ef3.xeac40bb76c9d449c(this, xe125219852864557);
	}

	private void x1342fe630ec86bca(long x2c753a2e97e475c8, long x0967b3fb9ec238c0)
	{
		_x49fe32f14563e6a0 = _xe2a6c1b66e699ef3.x3d39c7856be9a966(this, x2c753a2e97e475c8, x0967b3fb9ec238c0);
	}

	private static void x1fbe3031e4639505(string xafe2f3653ee64ebc)
	{
		if ((File.GetAttributes(xafe2f3653ee64ebc) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
		{
			File.SetAttributes(xafe2f3653ee64ebc, FileAttributes.Normal);
		}
		File.Delete(xafe2f3653ee64ebc);
	}

	private void x4a77f4b2eb397877(string x4abc0735d5951ac3, Stream x7f5d4a91157364b5, string xe8e4b5871d71a79a)
	{
		if (_xe2a6c1b66e699ef3 == null)
		{
			throw new xcb4fb578c1324851("This ZipEntry is an orphan.");
		}
		_xe2a6c1b66e699ef3.x74f5a1ef3906e23c();
		if (_xaf77e81a71d6921f != x58bf66883d9e6d5a.xef4b7685c2495ff2)
		{
			throw new xcb4fb578c1324851("You must call ZipFile.Save before calling any Extract method.");
		}
		x7f883ecb982e5b94(x4abc0735d5951ac3);
		_x49fe32f14563e6a0 = false;
		string xf6feaaa024df1fcd = null;
		Stream stream = null;
		bool flag = false;
		bool flag2 = false;
		try
		{
			xf26e1b8bd950c52b();
			x8daa7e01a9556135();
			if (x07e0fbb8c1ee8ba3(x4abc0735d5951ac3, x7f5d4a91157364b5, out xf6feaaa024df1fcd))
			{
				if (_xe2a6c1b66e699ef3.x0ede19c87c5fb089)
				{
					_xe2a6c1b66e699ef3.x44102a7f72bfea16.WriteLine("extract dir {0}...", xf6feaaa024df1fcd);
				}
				x7bb50e6afa47c5ce(x4abc0735d5951ac3);
				return;
			}
			string text = ((xe8e4b5871d71a79a != null) ? xe8e4b5871d71a79a : ((_xa4bc2af2b58881c8 != null) ? _xa4bc2af2b58881c8 : _xe2a6c1b66e699ef3._xa4bc2af2b58881c8));
			if (xe9881a3551b0697b)
			{
				if (text == null)
				{
					throw new x37721f08ca773e2b();
				}
				xd5aa7b201073242e(text);
			}
			if (xf6feaaa024df1fcd != null)
			{
				if (_xe2a6c1b66e699ef3.x0ede19c87c5fb089)
				{
					_xe2a6c1b66e699ef3.x44102a7f72bfea16.WriteLine("extract file {0}...", xf6feaaa024df1fcd);
				}
				if (!Directory.Exists(Path.GetDirectoryName(xf6feaaa024df1fcd)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(xf6feaaa024df1fcd));
				}
				else
				{
					flag2 = _xe2a6c1b66e699ef3._x1cc53e92d902f0a4;
				}
				if (File.Exists(xf6feaaa024df1fcd))
				{
					flag = true;
					int num = xa04e915bca0f15e6(x4abc0735d5951ac3, xf6feaaa024df1fcd);
					if (num == 2 || num == 1)
					{
						return;
					}
				}
				stream = new FileStream(xf6feaaa024df1fcd, FileMode.CreateNew);
			}
			else
			{
				if (_xe2a6c1b66e699ef3.x0ede19c87c5fb089)
				{
					_xe2a6c1b66e699ef3.x44102a7f72bfea16.WriteLine("extract entry {0} to stream...", xa39af5a82860a9a3);
				}
				stream = x7f5d4a91157364b5;
			}
			if (_x49fe32f14563e6a0)
			{
				return;
			}
			int num2 = _x3188c73c7f209072(stream);
			if (_x49fe32f14563e6a0)
			{
				return;
			}
			if (num2 != _x5e4059a15fb5fca5)
			{
				throw new x5d8566c1431b09dd("CRC error: the file being extracted appears to be corrupted. " + $"Expected 0x{_x5e4059a15fb5fca5:X8}, Actual 0x{num2:X8}");
			}
			if (xf6feaaa024df1fcd != null)
			{
				stream.Close();
				stream = null;
				_x68a68a69ffbcc657(xf6feaaa024df1fcd, xf0e19df7b6a7c8a4: true);
				if (flag2 && xa39af5a82860a9a3.IndexOf('/') != -1)
				{
					string directoryName = Path.GetDirectoryName(xa39af5a82860a9a3);
					if (_xe2a6c1b66e699ef3.get_xe6d4b1b411ed94b5(directoryName) == null)
					{
						_x68a68a69ffbcc657(Path.GetDirectoryName(xf6feaaa024df1fcd), xf0e19df7b6a7c8a4: false);
					}
				}
				if ((_x345ff482eb7fd52e & 0xFF00) == 2560 || (_x345ff482eb7fd52e & 0xFF00) == 0)
				{
					File.SetAttributes(xf6feaaa024df1fcd, (FileAttributes)_xe6f4ba51aec00070);
				}
			}
			x7bb50e6afa47c5ce(x4abc0735d5951ac3);
		}
		catch (Exception ex)
		{
			_x49fe32f14563e6a0 = true;
			if (!(ex is xc5e345d2a919c94b))
			{
				throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("plmfkndgeokgbobhpnihbophkigimmnimnejfnljanckmljkllaljmhl", 2136562812)), ex);
			}
			throw;
		}
		finally
		{
			if (_x49fe32f14563e6a0 && xf6feaaa024df1fcd != null)
			{
				stream?.Close();
				if (File.Exists(xf6feaaa024df1fcd) && (!flag || xec3a126a0abb0cbf == x8859214cc4c1cfab.xf4b7fc58735e7b0b))
				{
					File.Delete(xf6feaaa024df1fcd);
				}
			}
		}
	}

	private int xa04e915bca0f15e6(string x4abc0735d5951ac3, string x303a699153314a4e)
	{
		int num = 0;
		while (true)
		{
			switch (xec3a126a0abb0cbf)
			{
			case x8859214cc4c1cfab.xf4b7fc58735e7b0b:
				if (_xe2a6c1b66e699ef3.x0ede19c87c5fb089)
				{
					_xe2a6c1b66e699ef3.x44102a7f72bfea16.WriteLine("the file {0} exists; deleting it...", x303a699153314a4e);
				}
				x1fbe3031e4639505(x303a699153314a4e);
				return 0;
			case x8859214cc4c1cfab.x81626926c18a895c:
				if (_xe2a6c1b66e699ef3.x0ede19c87c5fb089)
				{
					_xe2a6c1b66e699ef3.x44102a7f72bfea16.WriteLine("the file {0} exists; not extracting entry...", xa39af5a82860a9a3);
				}
				x7bb50e6afa47c5ce(x4abc0735d5951ac3);
				return 1;
			case x8859214cc4c1cfab.xe44f493a0bae853e:
				if (num > 0)
				{
					throw new xc5e345d2a919c94b($"The file {x303a699153314a4e} already exists.");
				}
				xeac40bb76c9d449c(x4abc0735d5951ac3);
				if (_x49fe32f14563e6a0)
				{
					return 2;
				}
				break;
			default:
				throw new xc5e345d2a919c94b($"The file {x303a699153314a4e} already exists.");
			}
			num++;
		}
	}

	private void _xb1e1aa85cb7ab4a5(int xec5a42a91ad4fabd)
	{
		if (xec5a42a91ad4fabd == 0)
		{
			throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ijcbejjbejacnehcmjocmifdfimdfideodkekibfohiffdpfhhggnhngaiehlhlhphcidcjilhajnchjhhojhbfkkfmkdgdlnfklifbmiaimiepmbfgnmennmeeoleloldcpgejpdeaacdhaocoahoebfcmbdddcbckcdcbdbcidlcpdhbgennme", 1797984822)), xa39af5a82860a9a3));
		}
	}

	private int _x3188c73c7f209072(Stream x9c13656d94fc62d0)
	{
		Stream stream = x4b75fd1546e838a4;
		_xe2a6c1b66e699ef3.xd0c948b79c880a6b(xac0e037603b38c89);
		byte[] array = new byte[x648114bcf1499890];
		long num = ((x93f6dc9bc169b40a == 8) ? xc49fe6a8d63d6783 : _x09d464f2121ddee7);
		Stream stream2 = ((x5d327c9569dc4f54 != xea98c2211cc2e8a1.x94fedbf94759d5f4) ? stream : new xc65b5343382bdcf8(stream, _x845726eb9cff3810, x0c752eb8af884509.xcc381ffa3ede662f));
		Stream stream3 = ((x93f6dc9bc169b40a == 8) ? new xdd609f761b3f07f0(stream2, x1f770018e5e12789.x706f07a5eea59a53, leaveOpen: true) : stream2);
		long num2 = 0L;
		using x18b5d2c1faea3df7 x18b5d2c1faea3df8 = new x18b5d2c1faea3df7(stream3);
		while (num > 0)
		{
			int count = (int)((num > array.Length) ? array.Length : num);
			int num3 = x18b5d2c1faea3df8.Read(array, 0, count);
			_xb1e1aa85cb7ab4a5(num3);
			x9c13656d94fc62d0.Write(array, 0, num3);
			num -= num3;
			num2 += num3;
			x3e6b71396bc9bdee(num2, xc49fe6a8d63d6783);
			if (_x49fe32f14563e6a0)
			{
				break;
			}
		}
		return x18b5d2c1faea3df8.x4267aa67a0bb35b8;
	}

	internal void _x68a68a69ffbcc657(string xd9c131b42e8fc498, bool xf0e19df7b6a7c8a4)
	{
		if (_x944b5cca78a375e0)
		{
			if (xf0e19df7b6a7c8a4)
			{
				if (File.Exists(xd9c131b42e8fc498))
				{
					File.SetCreationTimeUtc(xd9c131b42e8fc498, _xabb478a6899dcd45);
					File.SetLastAccessTimeUtc(xd9c131b42e8fc498, _x4ab867ea64e4b33f);
					File.SetLastWriteTimeUtc(xd9c131b42e8fc498, _x6c80cf8f89bb22b5);
				}
			}
			else if (Directory.Exists(xd9c131b42e8fc498))
			{
				Directory.SetCreationTimeUtc(xd9c131b42e8fc498, _xabb478a6899dcd45);
				Directory.SetLastAccessTimeUtc(xd9c131b42e8fc498, _x4ab867ea64e4b33f);
				Directory.SetLastWriteTimeUtc(xd9c131b42e8fc498, _x6c80cf8f89bb22b5);
			}
		}
		else
		{
			DateTime lastWriteTime = x977b5605864b2047.x13fcad26fd69d759(xf3d2608616d7641a);
			if (xf0e19df7b6a7c8a4)
			{
				File.SetLastWriteTime(xd9c131b42e8fc498, lastWriteTime);
			}
			else
			{
				Directory.SetLastWriteTime(xd9c131b42e8fc498, lastWriteTime);
			}
		}
	}

	private void x8daa7e01a9556135()
	{
		if (x5d327c9569dc4f54 != xea98c2211cc2e8a1.x94fedbf94759d5f4 && x5d327c9569dc4f54 != 0)
		{
			if (_xc6ddcdd59292e6fb != 0)
			{
				throw new xc5e345d2a919c94b(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fdgnafnnkfeohfloffcphfjpaaaacehacfoalefbgembcddcbdkcpdbdcaidfoodhagencneadeflclfpccgdniglcahnnghhcohhmeinamiebdjoljjaabkgaikipokeaglianlmpdmnpkmlobnhoinakpnepgodonoloepmnlpbjcapmjajnabiihbgmobomfcgmmclmddlmkdplbehmieilpeklgfkgnfflegdllgflchofjhokainkhifkoickfjojmjojdknjkkliblhiilaeplphgmdjnmhdeniflnaicocijojfapnghpjhopmffaigmamgdbddkbgbbcogicbcpckggd", 960222706)), xa39af5a82860a9a3, x32e41a75f68d3df0));
			}
			throw new xc5e345d2a919c94b(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("aakilbbjfcijccpjacgkccnklmdlnallnbcmgbjmbbannpgnmpnnkafonmloalcpcnjpipaalphagpoakpfbojmbgpdcikkccpbdcjideopdpngeomnejnefdilfbmcglmjgkhahmmhhcmohemfidmmilldjilkjelbkelikdlpkbkglnjnlgfemijlmojcnajjnmjaoakhoejoofjfphimpkidagikafdbbdhiblhpbdhgcihncihedmgldehcefgjehgafhbhfmbofmgfgpbmgfcdhaekhhbbipfiiiapi", 1611172285)), xa39af5a82860a9a3, (int)x5d327c9569dc4f54));
		}
	}

	private void xf26e1b8bd950c52b()
	{
		if (x93f6dc9bc169b40a != 0 && x93f6dc9bc169b40a != 8)
		{
			throw new xc5e345d2a919c94b($"Entry {xa39af5a82860a9a3} uses an unsupported compression method (0x{x93f6dc9bc169b40a:X2}, {xe6241184a93826d6})");
		}
	}

	private void xd5aa7b201073242e(string xe8e4b5871d71a79a)
	{
		if (xe8e4b5871d71a79a != null && x5d327c9569dc4f54 == xea98c2211cc2e8a1.x94fedbf94759d5f4)
		{
			_xe2a6c1b66e699ef3.xd0c948b79c880a6b(xac0e037603b38c89 - 12);
			_x845726eb9cff3810 = xed28787af62b195b.x7b5a0a9e4db4ba74(xe8e4b5871d71a79a, this);
		}
	}

	private bool x07e0fbb8c1ee8ba3(string x1a760417e8062516, Stream x7f5d4a91157364b5, out string xf6feaaa024df1fcd)
	{
		if (x1a760417e8062516 != null)
		{
			string text = xa39af5a82860a9a3;
			if (text.StartsWith("/"))
			{
				text = xa39af5a82860a9a3.Substring(1);
			}
			if (_xe2a6c1b66e699ef3.x0e26a7f9519d1daf)
			{
				xf6feaaa024df1fcd = Path.Combine(x1a760417e8062516, (text.IndexOf('/') != -1) ? Path.GetFileName(text) : text);
			}
			else
			{
				xf6feaaa024df1fcd = Path.Combine(x1a760417e8062516, text);
			}
			if (x4d1990cadac28b9b || xa39af5a82860a9a3.EndsWith("/"))
			{
				if (!Directory.Exists(xf6feaaa024df1fcd))
				{
					Directory.CreateDirectory(xf6feaaa024df1fcd);
					_x68a68a69ffbcc657(xf6feaaa024df1fcd, xf0e19df7b6a7c8a4: false);
				}
				else if (xec3a126a0abb0cbf == x8859214cc4c1cfab.xf4b7fc58735e7b0b)
				{
					_x68a68a69ffbcc657(xf6feaaa024df1fcd, xf0e19df7b6a7c8a4: false);
				}
				return true;
			}
			return false;
		}
		if (x7f5d4a91157364b5 != null)
		{
			xf6feaaa024df1fcd = null;
			if (x4d1990cadac28b9b || xa39af5a82860a9a3.EndsWith("/"))
			{
				return true;
			}
			return false;
		}
		throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ddjpoeaaifhaffoadffbffmbopccaekcafbdjeideepdadgepcnendefepkf", 196999408)), new ArgumentException("Invalid input.", "outstream"));
	}

	private void x2e3bcd8c0f84b3f2()
	{
		_x174d4f7cf3cee2ef++;
		long position = x4b75fd1546e838a4.Position;
		_xe2a6c1b66e699ef3.xd0c948b79c880a6b(_x7e322ff037b992c9);
		byte[] array = new byte[30];
		x4b75fd1546e838a4.Read(array, 0, array.Length);
		int num = 26;
		short num2 = (short)(array[num++] + array[num++] * 256);
		short x6019d41161d394d = (short)(array[num++] + array[num++] * 256);
		x4b75fd1546e838a4.Seek(num2, SeekOrigin.Current);
		xe8d1e1645b9870d1(x6019d41161d394d);
		x4b75fd1546e838a4.Seek(position, SeekOrigin.Begin);
		_x174d4f7cf3cee2ef--;
	}

	private static bool x43325fdd19b94194(x990d54f34b2b5118 x68e0b8da2e9575d7, Encoding xc3a17f0e5ee913f8)
	{
		int num = 0;
		x68e0b8da2e9575d7._x7e322ff037b992c9 = x68e0b8da2e9575d7._xe2a6c1b66e699ef3.x0cced477dfc63bfd;
		int num2 = x977b5605864b2047.x4e38ee4c0a37efb1(x68e0b8da2e9575d7.x4b75fd1546e838a4);
		num += 4;
		if (xe617232e78452f7c(num2))
		{
			x68e0b8da2e9575d7.x4b75fd1546e838a4.Seek(-4L, SeekOrigin.Current);
			if (x095a1f4f865cc948(num2) && (long)num2 != 101010256)
			{
				throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dnacanhchapcdbgdhbndjodepalecbcfnajfbbagpmggmmngboehbplhkocikojilmajfohjonojonfkmnmkgodljjklhjbmfkimiipmhkgndmnndmeomhlommcppljpklaaolhaokoaolfbmlmbgldcgkkcofbddgidigpdnkgenknepfefgglfbicgofjgakahjehhndohlhfilimieddjbikjnhbkohikbhpkjhgllgnlogemkglmjbcngbjndcaoighoigoolbfpbcmpmddajbkalfbb", 1866342579)), num2, x68e0b8da2e9575d7.x4b75fd1546e838a4.Position));
			}
			return false;
		}
		byte[] array = new byte[26];
		int num3 = x68e0b8da2e9575d7.x4b75fd1546e838a4.Read(array, 0, array.Length);
		if (num3 != array.Length)
		{
			return false;
		}
		num += num3;
		int num4 = 0;
		x68e0b8da2e9575d7._x2225527e56803a37 = (short)(array[num4++] + array[num4++] * 256);
		x68e0b8da2e9575d7._x2d3be316c1c6e811 = (short)(array[num4++] + array[num4++] * 256);
		x68e0b8da2e9575d7._x93f6dc9bc169b40a = (short)(array[num4++] + array[num4++] * 256);
		x68e0b8da2e9575d7._xc3309b8559936a71 = array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256;
		x68e0b8da2e9575d7._xf3d2608616d7641a = x977b5605864b2047.x5def2075df47607e(x68e0b8da2e9575d7._xc3309b8559936a71);
		x68e0b8da2e9575d7._x2e1983435b85b773 |= x096547e09b6773c8.x58e6601812cd8f83;
		x68e0b8da2e9575d7._x5e4059a15fb5fca5 = array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256;
		x68e0b8da2e9575d7._x9a0049934ff5530a = (uint)(array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256);
		x68e0b8da2e9575d7._xc49fe6a8d63d6783 = (uint)(array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256);
		if ((int)x68e0b8da2e9575d7._x9a0049934ff5530a == -1 || (int)x68e0b8da2e9575d7._xc49fe6a8d63d6783 == -1)
		{
			x68e0b8da2e9575d7._x60a12c8412239ce4 = true;
		}
		short num5 = (short)(array[num4++] + array[num4++] * 256);
		short x6019d41161d394d = (short)(array[num4++] + array[num4++] * 256);
		array = new byte[num5];
		num3 = x68e0b8da2e9575d7.x4b75fd1546e838a4.Read(array, 0, array.Length);
		num += num3;
		x68e0b8da2e9575d7._x8311d99018a2b664 = (((x68e0b8da2e9575d7._x2d3be316c1c6e811 & 0x800) == 2048) ? Encoding.UTF8 : xc3a17f0e5ee913f8);
		x68e0b8da2e9575d7._x5ccc000b8fc5503b = x68e0b8da2e9575d7._x8311d99018a2b664.GetString(array, 0, array.Length);
		x68e0b8da2e9575d7._x08d0fbfeee1603b1 = x68e0b8da2e9575d7._x5ccc000b8fc5503b;
		if (x68e0b8da2e9575d7._x08d0fbfeee1603b1.EndsWith("/"))
		{
			x68e0b8da2e9575d7.xa1404b84036ecc66();
		}
		num += x68e0b8da2e9575d7.xe8d1e1645b9870d1(x6019d41161d394d);
		x68e0b8da2e9575d7._x72b7a211fbd3d75f = 0;
		if (!x68e0b8da2e9575d7._x08d0fbfeee1603b1.EndsWith("/") && (x68e0b8da2e9575d7._x2d3be316c1c6e811 & 8) == 8)
		{
			long position = x68e0b8da2e9575d7.x4b75fd1546e838a4.Position;
			bool flag = true;
			long num6 = 0L;
			int num7 = 0;
			while (flag)
			{
				num7++;
				x68e0b8da2e9575d7._xe2a6c1b66e699ef3.xe49b76645b9cc6d4(x68e0b8da2e9575d7);
				long num8 = x977b5605864b2047.xdf477cba9c46e9dc(x68e0b8da2e9575d7.x4b75fd1546e838a4, 134695760);
				if (num8 == -1)
				{
					return false;
				}
				num6 += num8;
				if (x68e0b8da2e9575d7._x60a12c8412239ce4)
				{
					array = new byte[20];
					num3 = x68e0b8da2e9575d7.x4b75fd1546e838a4.Read(array, 0, array.Length);
					if (num3 != 20)
					{
						return false;
					}
					num4 = 0;
					x68e0b8da2e9575d7._x5e4059a15fb5fca5 = array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256;
					x68e0b8da2e9575d7._x9a0049934ff5530a = BitConverter.ToInt64(array, num4);
					num4 += 8;
					x68e0b8da2e9575d7._xc49fe6a8d63d6783 = BitConverter.ToInt64(array, num4);
					num4 += 8;
					x68e0b8da2e9575d7._x72b7a211fbd3d75f += 24;
				}
				else
				{
					array = new byte[12];
					num3 = x68e0b8da2e9575d7.x4b75fd1546e838a4.Read(array, 0, array.Length);
					if (num3 != 12)
					{
						return false;
					}
					num4 = 0;
					x68e0b8da2e9575d7._x5e4059a15fb5fca5 = array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256;
					x68e0b8da2e9575d7._x9a0049934ff5530a = (uint)(array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256);
					x68e0b8da2e9575d7._xc49fe6a8d63d6783 = (uint)(array[num4++] + array[num4++] * 256 + array[num4++] * 256 * 256 + array[num4++] * 256 * 256 * 256);
					x68e0b8da2e9575d7._x72b7a211fbd3d75f += 16;
				}
				flag = num6 != x68e0b8da2e9575d7._x9a0049934ff5530a;
				if (flag)
				{
					x68e0b8da2e9575d7.x4b75fd1546e838a4.Seek(-12L, SeekOrigin.Current);
					num6 += 4;
				}
			}
			x68e0b8da2e9575d7.x4b75fd1546e838a4.Seek(position, SeekOrigin.Begin);
		}
		x68e0b8da2e9575d7._x09d464f2121ddee7 = x68e0b8da2e9575d7._x9a0049934ff5530a;
		if ((x68e0b8da2e9575d7._x2d3be316c1c6e811 & 1) == 1)
		{
			x68e0b8da2e9575d7._x8109109d50a7c0cd = new byte[12];
			num += x139a09abfe673a44(x68e0b8da2e9575d7._x3c23849cf83dda47, x68e0b8da2e9575d7._x8109109d50a7c0cd);
			x68e0b8da2e9575d7._x09d464f2121ddee7 -= 12L;
		}
		x68e0b8da2e9575d7._xb69adf785c29907e = num;
		x68e0b8da2e9575d7._x5348dad0c0de551e = x68e0b8da2e9575d7._xb69adf785c29907e + x68e0b8da2e9575d7._x09d464f2121ddee7 + x68e0b8da2e9575d7._x72b7a211fbd3d75f;
		return true;
	}

	internal static int x139a09abfe673a44(Stream xe4115acdf4fbfccc, byte[] x5cafa8d49ea71ea1)
	{
		int num = xe4115acdf4fbfccc.Read(x5cafa8d49ea71ea1, 0, 12);
		if (num != 12)
		{
			throw new xc5e345d2a919c94b($"Unexpected end of data at position 0x{xe4115acdf4fbfccc.Position:X8}");
		}
		return num;
	}

	private static bool xe617232e78452f7c(int x8ebde9a98df80374)
	{
		return x8ebde9a98df80374 != 67324752;
	}

	internal static x990d54f34b2b5118 x06b0e25aa6ad68a9(xef4b7685c2495ff2 x2fe8f0c48ba61aee, bool x62584df2cb5d40dd)
	{
		Stream x53cce0b6abbd65ad = x2fe8f0c48ba61aee.x53cce0b6abbd65ad;
		Encoding xc3a17f0e5ee913f = x2fe8f0c48ba61aee.xbfe2d4ca3e43b779;
		x990d54f34b2b5118 x990d54f34b2b5119 = new x990d54f34b2b5118();
		x990d54f34b2b5119._xaf77e81a71d6921f = x58bf66883d9e6d5a.xef4b7685c2495ff2;
		x990d54f34b2b5119._xe2a6c1b66e699ef3 = x2fe8f0c48ba61aee;
		x990d54f34b2b5119._x3c23849cf83dda47 = x53cce0b6abbd65ad;
		x2fe8f0c48ba61aee.xc7a7b7e4ce2ebb52(x6b161b1ae41c1651: true, null);
		if (x62584df2cb5d40dd)
		{
			x1ca4b5f6ba5d80c6(x53cce0b6abbd65ad);
		}
		if (!x43325fdd19b94194(x990d54f34b2b5119, xc3a17f0e5ee913f))
		{
			return null;
		}
		x990d54f34b2b5119._xfad3df95ca108a86 = x990d54f34b2b5119._xe2a6c1b66e699ef3.x0cced477dfc63bfd;
		x53cce0b6abbd65ad.Seek(x990d54f34b2b5119._x09d464f2121ddee7 + x990d54f34b2b5119._x72b7a211fbd3d75f, SeekOrigin.Current);
		x9d5765aa6e4276e3(x990d54f34b2b5119);
		x2fe8f0c48ba61aee.xe49b76645b9cc6d4(x990d54f34b2b5119);
		x2fe8f0c48ba61aee.xc7a7b7e4ce2ebb52(x6b161b1ae41c1651: false, x990d54f34b2b5119);
		return x990d54f34b2b5119;
	}

	internal static void x1ca4b5f6ba5d80c6(Stream xe4115acdf4fbfccc)
	{
		uint num = (uint)x977b5605864b2047.xe5d393f0d1706f47(xe4115acdf4fbfccc);
		if (num != 808471376)
		{
			xe4115acdf4fbfccc.Seek(-4L, SeekOrigin.Current);
		}
	}

	private static void x9d5765aa6e4276e3(x990d54f34b2b5118 xa85f9dbcec37a9e8)
	{
		Stream stream = xa85f9dbcec37a9e8.x4b75fd1546e838a4;
		uint num = (uint)x977b5605864b2047.xe5d393f0d1706f47(stream);
		if (num == xa85f9dbcec37a9e8._x5e4059a15fb5fca5)
		{
			int num2 = x977b5605864b2047.xe5d393f0d1706f47(stream);
			if (num2 == xa85f9dbcec37a9e8._x9a0049934ff5530a)
			{
				num2 = x977b5605864b2047.xe5d393f0d1706f47(stream);
				if (num2 != xa85f9dbcec37a9e8._xc49fe6a8d63d6783)
				{
					stream.Seek(-12L, SeekOrigin.Current);
				}
			}
			else
			{
				stream.Seek(-8L, SeekOrigin.Current);
			}
		}
		else
		{
			stream.Seek(-4L, SeekOrigin.Current);
		}
	}

	internal int xe8d1e1645b9870d1(short x6019d41161d394d8)
	{
		int num = 0;
		Stream stream = x4b75fd1546e838a4;
		if (x6019d41161d394d8 > 0)
		{
			byte[] array = (_xd7925bc5f938f029 = new byte[x6019d41161d394d8]);
			num = stream.Read(array, 0, array.Length);
			long xb3241da99b235fd = stream.Position - num;
			int num2 = 0;
			while (num2 < array.Length)
			{
				int num3 = num2;
				ushort num4 = (ushort)(array[num2] + array[num2 + 1] * 256);
				short num5 = (short)(array[num2 + 2] + array[num2 + 3] * 256);
				num2 += 4;
				switch (num4)
				{
				case 10:
					num2 = x7af922aa16e668f0(array, num2, num5, xb3241da99b235fd);
					break;
				case 21589:
					num2 = x829b131c9f78ceb7(array, num2, num5, xb3241da99b235fd);
					break;
				case 22613:
					num2 = xdbec246499b4680d(array, num2, num5, xb3241da99b235fd);
					break;
				case 1:
					num2 = x89d48a64850f7937(array, num2, num5, xb3241da99b235fd);
					break;
				case 23:
					num2 = x494b370c25fab934(array, num2);
					break;
				}
				num2 = num3 + num5 + 4;
			}
		}
		return num;
	}

	private int x494b370c25fab934(byte[] x4ae5537db27c5fe4, int x1148d0e8cc982c04)
	{
		x1148d0e8cc982c04 += 2;
		_xc6ddcdd59292e6fb = (ushort)(x4ae5537db27c5fe4[x1148d0e8cc982c04] + x4ae5537db27c5fe4[x1148d0e8cc982c04 + 1] * 256);
		x1148d0e8cc982c04 += 2;
		_x5d327c9569dc4f54 = xea98c2211cc2e8a1.xf9120e21ea3ee2d1;
		return x1148d0e8cc982c04;
	}

	private int x89d48a64850f7937(byte[] x4ae5537db27c5fe4, int x1148d0e8cc982c04, short xd407167a86d34054, long xb3241da99b235fd1)
	{
		_x60a12c8412239ce4 = true;
		if (xd407167a86d34054 > 28)
		{
			throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dlnhaleignliipcjkojjdpakpohkbpokeofllomljodmhnkmnnbnaoinjipnkmgoemnoenepollpnmcaamjaomabglhbogobdhfcihmcnlddnlkdpgbeghiebjpekggfalnfjfegnelgajchgjjhgjaibehiihoiegfjigmjledkgekkpcblbhilbiplkhgmfhnmbgennblnagcoagjojfapnfhpcfoplafajemajfdbcakbpebcleicmepcpdgdhendjdeemdleidcfhoifeppfjdhgjdogmoehcplhnadidojifoajjcij", 289373587)), xd407167a86d34054, xb3241da99b235fd1));
		}
		int num = xd407167a86d34054;
		if (_xc49fe6a8d63d6783 == uint.MaxValue)
		{
			if (num < 8)
			{
				throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dkncakedkmlddocekojehoafknhfmnofcnfgiimgjmdhdmkhdnbinliijhpimlgjcmnjcmeknglkekclajjlejamhhhmchomlffnnjmnnkdogkkobkbpniipjeppmigaminafiebjilbohcchdjcmdadgghdmhodogfehhmechdfchkfbhbgbgigmgpgjgghifnhefeinalindcjafjjofakgehkhaoklpeljdmljedmcpjmpdbnldinmdpnpcgohdnojcepmclpiccahniaeopajchbjcobmneccolcnpcddnjdfnaejbie", 55979395)), xb3241da99b235fd1));
			}
			_xc49fe6a8d63d6783 = BitConverter.ToInt64(x4ae5537db27c5fe4, x1148d0e8cc982c04);
			x1148d0e8cc982c04 += 8;
			num -= 8;
		}
		if (_x9a0049934ff5530a == uint.MaxValue)
		{
			if (num < 8)
			{
				throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dnbeaniekppedbhfkbofhbfgkamgmadhcakhilaijphidpoidagjnomjjkdkmokkcpblcpilnjplengmamnmemenhklnckcolijonmapnnhpgnopbnfanlmajhdbmlkbmlbcflicjlpcokgdhgndmgeeeilenkcfikjfikaghkhghjogckfhpjmhoidikikidebjdhijgipjejgkmhnkndelbdllpgcmphjmicanfhhnbhonchfofgmongdppfkpcgbaofianapakbgbpfnbpfeccblcibcdddjdjaaelahepeoe", 1118912947)), xb3241da99b235fd1));
			}
			_x9a0049934ff5530a = BitConverter.ToInt64(x4ae5537db27c5fe4, x1148d0e8cc982c04);
			x1148d0e8cc982c04 += 8;
			num -= 8;
		}
		if (_x7e322ff037b992c9 == uint.MaxValue)
		{
			if (num < 8)
			{
				throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pckbmcbcgficpgpcghgddhndggeeigleofcfebjfffagpehgpfogjefhfamhiedioekioebjjphjadpjmbgkacnkdaelopklhobmjcjmjdancdhnnconjbfofnloibdpibkpbbbafbiakapadmfbimmbpodcppkcdacdfpidfaaehpgebaoenoeffklfbncgfojgcoahmohhlnohhofijjminidjlmkjlnbkeiikbnpknmglomnlbmemjmlmllcnoljnklaojghoghoollfpllmpogdaehkapibbfgibhgpblkgc", 2141461007)), xb3241da99b235fd1));
			}
			_x7e322ff037b992c9 = BitConverter.ToInt64(x4ae5537db27c5fe4, x1148d0e8cc982c04);
			x1148d0e8cc982c04 += 8;
			num -= 8;
		}
		return x1148d0e8cc982c04;
	}

	private int xdbec246499b4680d(byte[] x4ae5537db27c5fe4, int x1148d0e8cc982c04, short xd407167a86d34054, long xb3241da99b235fd1)
	{
		if (xd407167a86d34054 != 12 && xd407167a86d34054 != 8)
		{
			throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jnijgnpjiahkobokcbflccmlhbdmjakmeabncbinaapnmpfoflmogpdpapkpaacakoiajppamogbkpnbcoeckjlcpjcdekjdjoaejoheljoeckffnlmfgjdgmnkgfibhjhihmlphcmgicmningejdjljflckkkjkalalijhlekolikfmffmmikdnagknmebooiioojpohjgpcjnpoheakdlanhcbnhjbghackhhcpgocicfdggmdghdepbkemgbfigifjgpfmfggegnggfehjflhffcieajibbajgfhjgfojjafkpamkkcdlaaklcabmgeim", 282237113)), xd407167a86d34054, xb3241da99b235fd1));
		}
		int num = BitConverter.ToInt32(x4ae5537db27c5fe4, x1148d0e8cc982c04);
		_x6c80cf8f89bb22b5 = _x7b854fa04f4ba476.AddSeconds(num);
		x1148d0e8cc982c04 += 4;
		num = BitConverter.ToInt32(x4ae5537db27c5fe4, x1148d0e8cc982c04);
		_x4ab867ea64e4b33f = _x7b854fa04f4ba476.AddSeconds(num);
		x1148d0e8cc982c04 += 4;
		_xabb478a6899dcd45 = DateTime.UtcNow;
		_x944b5cca78a375e0 = true;
		_x2e1983435b85b773 |= x096547e09b6773c8.x4f7d04e593852188;
		return x1148d0e8cc982c04;
	}

	private int x829b131c9f78ceb7(byte[] x4ae5537db27c5fe4, int x1148d0e8cc982c04, short xd407167a86d34054, long xb3241da99b235fd1)
	{
		if (xd407167a86d34054 != 13 && xd407167a86d34054 != 9 && xd407167a86d34054 != 5)
		{
			throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mnagjnhglapgbcghfbnhfceikblimacjhajjfbakdahkppnkileljplldpcmdakmnoanmphnpoonnpfofomonjdpckkphkbamoiamopaojgbfknbamecjjlcpncdiijdmhaeplhefmoefmffahmfcjdgcmkgllbhjkihpkphckgiaknimjejffljgickijjkjjaloihljjolhjfmbimmkidnkiknhdbojhiojipocigpnhnpjgeafclaigcbigjbbgacfghckfocdbfdbfmdbgdekakehfbfdfifefpfheggpengbeeheelhaecipoiimppibehjbeojepekkplkfbdllojlnoambdim", 1015570620)), xd407167a86d34054, xb3241da99b235fd1));
		}
		int num = xd407167a86d34054;
		if (xd407167a86d34054 == 13 || _x174d4f7cf3cee2ef > 1)
		{
			byte b = x4ae5537db27c5fe4[x1148d0e8cc982c04++];
			num--;
			if (((uint)b & (true ? 1u : 0u)) != 0 && num >= 4)
			{
				int num2 = BitConverter.ToInt32(x4ae5537db27c5fe4, x1148d0e8cc982c04);
				_x6c80cf8f89bb22b5 = _x7b854fa04f4ba476.AddSeconds(num2);
				x1148d0e8cc982c04 += 4;
				num -= 4;
			}
			if ((b & 2u) != 0 && num >= 4)
			{
				int num3 = BitConverter.ToInt32(x4ae5537db27c5fe4, x1148d0e8cc982c04);
				_x4ab867ea64e4b33f = _x7b854fa04f4ba476.AddSeconds(num3);
				x1148d0e8cc982c04 += 4;
				num -= 4;
			}
			else
			{
				_x4ab867ea64e4b33f = DateTime.UtcNow;
			}
			if ((b & 4u) != 0 && num >= 4)
			{
				int num4 = BitConverter.ToInt32(x4ae5537db27c5fe4, x1148d0e8cc982c04);
				_xabb478a6899dcd45 = _x7b854fa04f4ba476.AddSeconds(num4);
				x1148d0e8cc982c04 += 4;
				num -= 4;
			}
			else
			{
				_xabb478a6899dcd45 = DateTime.UtcNow;
			}
			_x2e1983435b85b773 |= x096547e09b6773c8.x40a5752567c3c6a6;
			_x944b5cca78a375e0 = true;
			_xd55b6f5e7aaffd65 = true;
		}
		else
		{
			x2e3bcd8c0f84b3f2();
		}
		return x1148d0e8cc982c04;
	}

	private int x7af922aa16e668f0(byte[] x4ae5537db27c5fe4, int x1148d0e8cc982c04, short xd407167a86d34054, long xb3241da99b235fd1)
	{
		if (xd407167a86d34054 != 32)
		{
			throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cpejpoljbcdkhdkklcblldiladplccgmnbnmlcenjblnfbcoomiopaapjahpjbopdafacbmafadbdbkblpacdlhcilocnlfdcandcaeeelkellbfgnifpkpffpggojngcjehfnlhlncilnjigiajblhjelojdkfknkmkhhdlimklklbmllimalpmllgnfgnnhkeohlloalcplkjphjaadfhagjoagjfbpimbdjdciikcbebdphidpipdidgefinebiefcilffhcgnhjgpgahchhhogohnbfikcmipgdjpgkjccbkicikdepkjbgllbnlpfem", 1545573586)), xd407167a86d34054, xb3241da99b235fd1));
		}
		x1148d0e8cc982c04 += 4;
		short num = (short)(x4ae5537db27c5fe4[x1148d0e8cc982c04] + x4ae5537db27c5fe4[x1148d0e8cc982c04 + 1] * 256);
		short num2 = (short)(x4ae5537db27c5fe4[x1148d0e8cc982c04 + 2] + x4ae5537db27c5fe4[x1148d0e8cc982c04 + 3] * 256);
		x1148d0e8cc982c04 += 4;
		if (num == 1 && num2 == 24)
		{
			long fileTime = BitConverter.ToInt64(x4ae5537db27c5fe4, x1148d0e8cc982c04);
			_x6c80cf8f89bb22b5 = DateTime.FromFileTimeUtc(fileTime);
			x1148d0e8cc982c04 += 8;
			fileTime = BitConverter.ToInt64(x4ae5537db27c5fe4, x1148d0e8cc982c04);
			_x4ab867ea64e4b33f = DateTime.FromFileTimeUtc(fileTime);
			x1148d0e8cc982c04 += 8;
			fileTime = BitConverter.ToInt64(x4ae5537db27c5fe4, x1148d0e8cc982c04);
			_xabb478a6899dcd45 = DateTime.FromFileTimeUtc(fileTime);
			x1148d0e8cc982c04 += 8;
			_x944b5cca78a375e0 = true;
			_x2e1983435b85b773 |= x096547e09b6773c8.x8a2adacc78a4bcc9;
			_x7e86c2f18f82bb31 = true;
		}
		return x1148d0e8cc982c04;
	}

	internal void xb78171f966a8ffb4(Stream xe4115acdf4fbfccc)
	{
		_x17008872e79f7ff4(xe4115acdf4fbfccc);
	}

	private void _x17008872e79f7ff4(Stream xe4115acdf4fbfccc)
	{
		byte[] array = new byte[4096];
		int num = 0;
		array[num++] = 80;
		array[num++] = 75;
		array[num++] = 1;
		array[num++] = 2;
		array[num++] = (byte)((uint)_x345ff482eb7fd52e & 0xFFu);
		array[num++] = (byte)((_x345ff482eb7fd52e & 0xFF00) >> 8);
		short num2 = (short)((_x4f36598217f645a0 == x09c3256ccc14f142.xbbad6bbe73c6b1dc) ? 45 : 20);
		array[num++] = (byte)((uint)num2 & 0xFFu);
		array[num++] = (byte)((num2 & 0xFF00) >> 8);
		short num3 = _x2d3be316c1c6e811;
		if (x4d1990cadac28b9b)
		{
			num3 = (short)(num3 & -9);
		}
		array[num++] = (byte)((uint)num3 & 0xFFu);
		array[num++] = (byte)((num3 & 0xFF00) >> 8);
		array[num++] = (byte)((uint)x93f6dc9bc169b40a & 0xFFu);
		array[num++] = (byte)((x93f6dc9bc169b40a & 0xFF00) >> 8);
		array[num++] = (byte)((uint)_xc3309b8559936a71 & 0xFFu);
		array[num++] = (byte)((_xc3309b8559936a71 & 0xFF00) >> 8);
		array[num++] = (byte)((_xc3309b8559936a71 & 0xFF0000) >> 16);
		array[num++] = (byte)((_xc3309b8559936a71 & 0xFF000000u) >> 24);
		array[num++] = (byte)((uint)_x5e4059a15fb5fca5 & 0xFFu);
		array[num++] = (byte)((_x5e4059a15fb5fca5 & 0xFF00) >> 8);
		array[num++] = (byte)((_x5e4059a15fb5fca5 & 0xFF0000) >> 16);
		array[num++] = (byte)((_x5e4059a15fb5fca5 & 0xFF000000u) >> 24);
		int num4 = 0;
		if (_x4f36598217f645a0 == x09c3256ccc14f142.xbbad6bbe73c6b1dc)
		{
			for (num4 = 0; num4 < 8; num4++)
			{
				array[num++] = byte.MaxValue;
			}
		}
		else
		{
			array[num++] = (byte)(_x9a0049934ff5530a & 0xFF);
			array[num++] = (byte)((_x9a0049934ff5530a & 0xFF00) >> 8);
			array[num++] = (byte)((_x9a0049934ff5530a & 0xFF0000) >> 16);
			array[num++] = (byte)((_x9a0049934ff5530a & 0xFF000000u) >> 24);
			array[num++] = (byte)(_xc49fe6a8d63d6783 & 0xFF);
			array[num++] = (byte)((_xc49fe6a8d63d6783 & 0xFF00) >> 8);
			array[num++] = (byte)((_xc49fe6a8d63d6783 & 0xFF0000) >> 16);
			array[num++] = (byte)((_xc49fe6a8d63d6783 & 0xFF000000u) >> 24);
		}
		byte[] array2 = _x5425aa97fd64b315();
		short num5 = (short)array2.Length;
		array[num++] = (byte)((uint)num5 & 0xFFu);
		array[num++] = (byte)((num5 & 0xFF00) >> 8);
		_x682ce91e3cc65602 = _x4f36598217f645a0 == x09c3256ccc14f142.xbbad6bbe73c6b1dc;
		_xd7925bc5f938f029 = xd070320637bdf7a0(x366528d166e6bf7c: true);
		short num6 = (short)((_xd7925bc5f938f029 != null) ? _xd7925bc5f938f029.Length : 0);
		array[num++] = (byte)((uint)num6 & 0xFFu);
		array[num++] = (byte)((num6 & 0xFF00) >> 8);
		int num7 = ((_xb221a693d5677af2 != null) ? _xb221a693d5677af2.Length : 0);
		if (num7 + num > array.Length)
		{
			num7 = array.Length - num;
		}
		array[num++] = (byte)((uint)num7 & 0xFFu);
		array[num++] = (byte)((num7 & 0xFF00) >> 8);
		array[num++] = 0;
		array[num++] = 0;
		array[num++] = (byte)(_x1ede37fe2e573750 ? 1u : 0u);
		array[num++] = 0;
		array[num++] = (byte)((uint)_xe6f4ba51aec00070 & 0xFFu);
		array[num++] = (byte)((_xe6f4ba51aec00070 & 0xFF00) >> 8);
		array[num++] = (byte)((_xe6f4ba51aec00070 & 0xFF0000) >> 16);
		array[num++] = (byte)((_xe6f4ba51aec00070 & 0xFF000000u) >> 24);
		if (_x4f36598217f645a0 == x09c3256ccc14f142.xbbad6bbe73c6b1dc)
		{
			for (num4 = 0; num4 < 4; num4++)
			{
				array[num++] = byte.MaxValue;
			}
		}
		else
		{
			array[num++] = (byte)(_x7e322ff037b992c9 & 0xFF);
			array[num++] = (byte)((_x7e322ff037b992c9 & 0xFF00) >> 8);
			array[num++] = (byte)((_x7e322ff037b992c9 & 0xFF0000) >> 16);
			array[num++] = (byte)((_x7e322ff037b992c9 & 0xFF000000u) >> 24);
		}
		for (num4 = 0; num4 < num5; num4++)
		{
			array[num + num4] = array2[num4];
		}
		num += num4;
		if (_xd7925bc5f938f029 != null)
		{
			for (num4 = 0; num4 < num6; num4++)
			{
				array[num + num4] = _xd7925bc5f938f029[num4];
			}
			num += num4;
		}
		if (num7 != 0)
		{
			for (num4 = 0; num4 < num7 && num + num4 < array.Length; num4++)
			{
				array[num + num4] = _xb221a693d5677af2[num4];
			}
			num += num4;
		}
		xe4115acdf4fbfccc.Write(array, 0, num);
	}

	private byte[] xd070320637bdf7a0(bool x366528d166e6bf7c)
	{
		ArrayList arrayList = new ArrayList();
		if (_xe2a6c1b66e699ef3._xa4993e9106eb60b0 != 0)
		{
			int num = 4 + (x366528d166e6bf7c ? 28 : 16);
			byte[] array = new byte[num];
			int num2 = 0;
			if (_x682ce91e3cc65602)
			{
				array[num2++] = 1;
				array[num2++] = 0;
			}
			else
			{
				array[num2++] = 153;
				array[num2++] = 153;
			}
			array[num2++] = (byte)(num - 4);
			array[num2++] = 0;
			Array.Copy(BitConverter.GetBytes(_xc49fe6a8d63d6783), 0, array, num2, 8);
			num2 += 8;
			Array.Copy(BitConverter.GetBytes(_x9a0049934ff5530a), 0, array, num2, 8);
			if (x366528d166e6bf7c)
			{
				num2 += 8;
				Array.Copy(BitConverter.GetBytes(_x7e322ff037b992c9), 0, array, num2, 8);
				num2 += 8;
				Array.Copy(BitConverter.GetBytes(0), 0, array, num2, 4);
			}
			arrayList.Add(array);
		}
		if (_x944b5cca78a375e0 && _x7e86c2f18f82bb31)
		{
			byte[] array = new byte[36];
			int num3 = 0;
			array[num3++] = 10;
			array[num3++] = 0;
			array[num3++] = 32;
			array[num3++] = 0;
			num3 += 4;
			array[num3++] = 1;
			array[num3++] = 0;
			array[num3++] = 24;
			array[num3++] = 0;
			long value = _x6c80cf8f89bb22b5.ToFileTime();
			Array.Copy(BitConverter.GetBytes(value), 0, array, num3, 8);
			num3 += 8;
			value = _x4ab867ea64e4b33f.ToFileTime();
			Array.Copy(BitConverter.GetBytes(value), 0, array, num3, 8);
			num3 += 8;
			value = _xabb478a6899dcd45.ToFileTime();
			Array.Copy(BitConverter.GetBytes(value), 0, array, num3, 8);
			num3 += 8;
			arrayList.Add(array);
		}
		if (_x944b5cca78a375e0 && _xd55b6f5e7aaffd65)
		{
			int num4 = 9;
			if (!x366528d166e6bf7c)
			{
				num4 += 8;
			}
			byte[] array = new byte[num4];
			int num5 = 0;
			array[num5++] = 85;
			array[num5++] = 84;
			array[num5++] = (byte)(num4 - 4);
			array[num5++] = 0;
			array[num5++] = 7;
			int value2 = (int)(_x6c80cf8f89bb22b5 - _x7b854fa04f4ba476).TotalSeconds;
			Array.Copy(BitConverter.GetBytes(value2), 0, array, num5, 4);
			num5 += 4;
			if (!x366528d166e6bf7c)
			{
				value2 = (int)(_x4ab867ea64e4b33f - _x7b854fa04f4ba476).TotalSeconds;
				Array.Copy(BitConverter.GetBytes(value2), 0, array, num5, 4);
				num5 += 4;
				value2 = (int)(_xabb478a6899dcd45 - _x7b854fa04f4ba476).TotalSeconds;
				Array.Copy(BitConverter.GetBytes(value2), 0, array, num5, 4);
				num5 += 4;
			}
			arrayList.Add(array);
		}
		byte[] array2 = null;
		if (arrayList.Count > 0)
		{
			int num6 = 0;
			int num7 = 0;
			for (int i = 0; i < arrayList.Count; i++)
			{
				num6 += ((byte[])arrayList[i]).Length;
			}
			array2 = new byte[num6];
			for (int i = 0; i < arrayList.Count; i++)
			{
				Array.Copy((byte[])arrayList[i], 0, array2, num7, ((byte[])arrayList[i]).Length);
				num7 += ((byte[])arrayList[i]).Length;
			}
		}
		return array2;
	}

	private Encoding x4818db903e3efea6()
	{
		_xb221a693d5677af2 = x34202fa0ef9be422.GetBytes(_x937e050c63ea1527);
		string @string = x34202fa0ef9be422.GetString(_xb221a693d5677af2, 0, _xb221a693d5677af2.Length);
		if (@string == _x937e050c63ea1527)
		{
			return x34202fa0ef9be422;
		}
		_xb221a693d5677af2 = _x569440e5ccedf43e.GetBytes(_x937e050c63ea1527);
		return _x569440e5ccedf43e;
	}

	private byte[] _x5425aa97fd64b315()
	{
		string text = xa39af5a82860a9a3.Replace("\\", "/");
		string text2;
		if (_x4d9ca6c385e8e4cd && xa39af5a82860a9a3.Length >= 3 && xa39af5a82860a9a3[1] == ':' && text[2] == '/')
		{
			text2 = text.Substring(3);
		}
		else if (xa39af5a82860a9a3.Length < 4 || text[0] != '/' || text[1] != '/')
		{
			text2 = ((xa39af5a82860a9a3.Length < 3 || text[0] != '.' || text[1] != '/') ? text : text.Substring(2));
		}
		else
		{
			int num = text.IndexOf('/', 2);
			if (num == -1)
			{
				throw new ArgumentException("The path for that entry appears to be badly formatted");
			}
			text2 = text.Substring(num + 1);
		}
		byte[] bytes = x34202fa0ef9be422.GetBytes(text2);
		string @string = x34202fa0ef9be422.GetString(bytes, 0, bytes.Length);
		_xb221a693d5677af2 = null;
		if (@string == text2)
		{
			if (_x937e050c63ea1527 == null || _x937e050c63ea1527.Length == 0)
			{
				_x8311d99018a2b664 = x34202fa0ef9be422;
				return bytes;
			}
			Encoding encoding = x4818db903e3efea6();
			if (encoding.CodePage == 437)
			{
				_x8311d99018a2b664 = x34202fa0ef9be422;
				return bytes;
			}
			_x8311d99018a2b664 = encoding;
			return encoding.GetBytes(text2);
		}
		bytes = _x569440e5ccedf43e.GetBytes(text2);
		if (_x937e050c63ea1527 != null && _x937e050c63ea1527.Length != 0)
		{
			_xb221a693d5677af2 = _x569440e5ccedf43e.GetBytes(_x937e050c63ea1527);
		}
		_x8311d99018a2b664 = _x569440e5ccedf43e;
		return bytes;
	}

	private bool xce6f9638ca67fa72()
	{
		if (_xc49fe6a8d63d6783 < 16)
		{
			return false;
		}
		if (_x93f6dc9bc169b40a == 0)
		{
			return false;
		}
		if (_xe2a6c1b66e699ef3.x0bf508c6214e694f == x0bf508c6214e694f.x4d0b9d4447ba7566)
		{
			return false;
		}
		if (_x9a0049934ff5530a < _xc49fe6a8d63d6783)
		{
			return false;
		}
		if (x4c8357e8f994ea6a)
		{
			return false;
		}
		if (_xaf77e81a71d6921f == x58bf66883d9e6d5a.xb8a774e0111d0fbe && !_xfa527d9626e5c265.CanSeek)
		{
			return false;
		}
		if (_x845726eb9cff3810 != null && x9a0049934ff5530a - 12 <= xc49fe6a8d63d6783)
		{
			return false;
		}
		if (x6a403654e6eff91d != null)
		{
			return x6a403654e6eff91d(_xc49fe6a8d63d6783, _x9a0049934ff5530a, xa39af5a82860a9a3);
		}
		return true;
	}

	private static bool xc096148ce2402992(string xb41a802ca5fde63b)
	{
		return !_xbe492d663860b696.IsMatch(xb41a802ca5fde63b);
	}

	private bool x6318619b1b0ba885()
	{
		if (_x08d0fbfeee1603b1 != null)
		{
			return xc096148ce2402992(_x08d0fbfeee1603b1);
		}
		if (_x5ccc000b8fc5503b != null)
		{
			return xc096148ce2402992(_x5ccc000b8fc5503b);
		}
		return true;
	}

	private void x40d3727c4b5737e3(int x14728c96c3cefe5e)
	{
		if (x14728c96c3cefe5e > 1)
		{
			_x93f6dc9bc169b40a = 0;
		}
		else if (x4d1990cadac28b9b)
		{
			_x93f6dc9bc169b40a = 0;
		}
		else
		{
			if (_xfad3df95ca108a86 != -1)
			{
				return;
			}
			if (_xaf77e81a71d6921f == x58bf66883d9e6d5a.xb8a774e0111d0fbe)
			{
				if (_xfa527d9626e5c265 != null && _xfa527d9626e5c265.CanSeek)
				{
					long length = _xfa527d9626e5c265.Length;
					if (length == 0)
					{
						_x93f6dc9bc169b40a = 0;
						return;
					}
				}
			}
			else
			{
				FileInfo fileInfo = new FileInfo(x08d0fbfeee1603b1);
				long length2 = fileInfo.Length;
				if (length2 == 0)
				{
					_x93f6dc9bc169b40a = 0;
					return;
				}
			}
			if (_x4c8357e8f994ea6a || _xe2a6c1b66e699ef3.x0bf508c6214e694f == x0bf508c6214e694f.x4d0b9d4447ba7566)
			{
				_x93f6dc9bc169b40a = 0;
			}
			else if (x12b00c407ac22ed0 != null)
			{
				_x93f6dc9bc169b40a = (short)(x12b00c407ac22ed0(x08d0fbfeee1603b1, _x5ccc000b8fc5503b) ? 8 : 0);
			}
			else
			{
				_x93f6dc9bc169b40a = (short)(x6318619b1b0ba885() ? 8 : 0);
			}
		}
	}

	private void x4a7d1611730784f2(Stream xe4115acdf4fbfccc, int x14728c96c3cefe5e)
	{
		int num = 0;
		_x7e322ff037b992c9 = (xe4115acdf4fbfccc as x853ddd714d7aaa13)?.x1c86f1bc0157a1b8 ?? xe4115acdf4fbfccc.Position;
		byte[] array = new byte[512];
		int num2 = 0;
		array[num2++] = 80;
		array[num2++] = 75;
		array[num2++] = 3;
		array[num2++] = 4;
		if (_xe2a6c1b66e699ef3._xa4993e9106eb60b0 == xd53f386d6d162abf.xb9715d2f06b63cf0 && (uint)_x7e322ff037b992c9 >= uint.MaxValue)
		{
			throw new xc5e345d2a919c94b("Offset within the zip archive exceeds 0xFFFFFFFF. Consider setting the UseZip64WhenSaving property on the ZipFile instance.");
		}
		_x682ce91e3cc65602 = _xe2a6c1b66e699ef3._xa4993e9106eb60b0 == xd53f386d6d162abf.xd4d82c4665f71358 || (_xe2a6c1b66e699ef3._xa4993e9106eb60b0 == xd53f386d6d162abf.x76d1b5ed1b8dde05 && !xe4115acdf4fbfccc.CanSeek);
		short num3 = (short)(_x682ce91e3cc65602 ? 45 : 20);
		array[num2++] = (byte)((uint)num3 & 0xFFu);
		array[num2++] = (byte)((num3 & 0xFF00) >> 8);
		byte[] array2 = _x5425aa97fd64b315();
		short num4 = (short)array2.Length;
		_x2d3be316c1c6e811 = (short)(xe9881a3551b0697b ? 1 : 0);
		if (x0e86491345e4da18.CodePage == Encoding.UTF8.CodePage)
		{
			_x2d3be316c1c6e811 = (short)((ushort)_x2d3be316c1c6e811 | 0x800);
		}
		if (!xe4115acdf4fbfccc.CanSeek)
		{
			_x2d3be316c1c6e811 = (short)((ushort)_x2d3be316c1c6e811 | 8);
		}
		short num5 = _x2d3be316c1c6e811;
		if (x4d1990cadac28b9b)
		{
			num5 = (short)(num5 & -9);
		}
		array[num2++] = (byte)((uint)num5 & 0xFFu);
		array[num2++] = (byte)((num5 & 0xFF00) >> 8);
		if (_xfad3df95ca108a86 == -1)
		{
			_xc49fe6a8d63d6783 = 0L;
			_x9a0049934ff5530a = 0L;
			_x5e4059a15fb5fca5 = 0;
			_x6964db67658cf88e = false;
		}
		x40d3727c4b5737e3(x14728c96c3cefe5e);
		array[num2++] = (byte)((uint)x93f6dc9bc169b40a & 0xFFu);
		array[num2++] = (byte)((x93f6dc9bc169b40a & 0xFF00) >> 8);
		_xc3309b8559936a71 = x977b5605864b2047.x35cf72c0c42c20e8(xf3d2608616d7641a);
		array[num2++] = (byte)((uint)_xc3309b8559936a71 & 0xFFu);
		array[num2++] = (byte)((_xc3309b8559936a71 & 0xFF00) >> 8);
		array[num2++] = (byte)((_xc3309b8559936a71 & 0xFF0000) >> 16);
		array[num2++] = (byte)((_xc3309b8559936a71 & 0xFF000000u) >> 24);
		array[num2++] = (byte)((uint)_x5e4059a15fb5fca5 & 0xFFu);
		array[num2++] = (byte)((_x5e4059a15fb5fca5 & 0xFF00) >> 8);
		array[num2++] = (byte)((_x5e4059a15fb5fca5 & 0xFF0000) >> 16);
		array[num2++] = (byte)((_x5e4059a15fb5fca5 & 0xFF000000u) >> 24);
		if (_x682ce91e3cc65602)
		{
			for (num = 0; num < 8; num++)
			{
				array[num2++] = byte.MaxValue;
			}
		}
		else
		{
			array[num2++] = (byte)(_x9a0049934ff5530a & 0xFF);
			array[num2++] = (byte)((_x9a0049934ff5530a & 0xFF00) >> 8);
			array[num2++] = (byte)((_x9a0049934ff5530a & 0xFF0000) >> 16);
			array[num2++] = (byte)((_x9a0049934ff5530a & 0xFF000000u) >> 24);
			array[num2++] = (byte)(_xc49fe6a8d63d6783 & 0xFF);
			array[num2++] = (byte)((_xc49fe6a8d63d6783 & 0xFF00) >> 8);
			array[num2++] = (byte)((_xc49fe6a8d63d6783 & 0xFF0000) >> 16);
			array[num2++] = (byte)((_xc49fe6a8d63d6783 & 0xFF000000u) >> 24);
		}
		array[num2++] = (byte)((uint)num4 & 0xFFu);
		array[num2++] = (byte)((num4 & 0xFF00) >> 8);
		_xd7925bc5f938f029 = xd070320637bdf7a0(x366528d166e6bf7c: false);
		short num6 = (short)((_xd7925bc5f938f029 != null) ? _xd7925bc5f938f029.Length : 0);
		array[num2++] = (byte)((uint)num6 & 0xFFu);
		array[num2++] = (byte)((num6 & 0xFF00) >> 8);
		for (num = 0; num < array2.Length && num2 + num < array.Length; num++)
		{
			array[num2 + num] = array2[num];
		}
		num2 += num;
		if (_xd7925bc5f938f029 != null)
		{
			for (num = 0; num < _xd7925bc5f938f029.Length; num++)
			{
				array[num2 + num] = _xd7925bc5f938f029[num];
			}
			num2 += num;
		}
		_xb69adf785c29907e = num2;
		xe4115acdf4fbfccc.Write(array, 0, num2);
		_x04cffeb7c4db4cab = new byte[num2];
		for (num = 0; num < num2; num++)
		{
			_x04cffeb7c4db4cab[num] = array[num];
		}
	}

	private int xf70eb969357470c5()
	{
		if (!_x6964db67658cf88e)
		{
			Stream stream;
			if (_xaf77e81a71d6921f == x58bf66883d9e6d5a.xb8a774e0111d0fbe)
			{
				x66c7fb6136ee8a22();
				stream = _xfa527d9626e5c265;
			}
			else
			{
				stream = File.Open(x08d0fbfeee1603b1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			}
			x41fcadcc0506e331 x41fcadcc0506e332 = new x41fcadcc0506e331();
			_x5e4059a15fb5fca5 = x41fcadcc0506e332.xe337ac19fd29a432(stream);
			if (_xfa527d9626e5c265 == null)
			{
				stream.Close();
			}
			_x6964db67658cf88e = true;
		}
		return _x5e4059a15fb5fca5;
	}

	private void x66c7fb6136ee8a22()
	{
		if (_xfa527d9626e5c265 == null)
		{
			throw new xc5e345d2a919c94b($"The input stream is null for entry '{xa39af5a82860a9a3}'.");
		}
		if (_x4b68a32d150ba5ec.x2d5c1249b31d3c86)
		{
			_xfa527d9626e5c265.Position = _x4b68a32d150ba5ec.xd2f68ee6f47e9dfb;
		}
		else if (_xfa527d9626e5c265.CanSeek)
		{
			_x4b68a32d150ba5ec = new x7540eedf8f68f598(_xfa527d9626e5c265.Position);
		}
		else if (x5d327c9569dc4f54 == xea98c2211cc2e8a1.x94fedbf94759d5f4)
		{
			throw new xc5e345d2a919c94b("It is not possible to use PKZIP encryption on a non-seekable stream");
		}
	}

	internal void xd242614c0fae8b2e(x990d54f34b2b5118 x337e217cb3ba0627)
	{
		_xfad3df95ca108a86 = x337e217cb3ba0627._xfad3df95ca108a86;
		x93f6dc9bc169b40a = x337e217cb3ba0627.x93f6dc9bc169b40a;
		_x09d464f2121ddee7 = x337e217cb3ba0627._x09d464f2121ddee7;
		_xc49fe6a8d63d6783 = x337e217cb3ba0627._xc49fe6a8d63d6783;
		_x2d3be316c1c6e811 = x337e217cb3ba0627._x2d3be316c1c6e811;
		_xaf77e81a71d6921f = x337e217cb3ba0627._xaf77e81a71d6921f;
		_xf3d2608616d7641a = x337e217cb3ba0627._xf3d2608616d7641a;
		_x6c80cf8f89bb22b5 = x337e217cb3ba0627._x6c80cf8f89bb22b5;
		_x4ab867ea64e4b33f = x337e217cb3ba0627._x4ab867ea64e4b33f;
		_xabb478a6899dcd45 = x337e217cb3ba0627._xabb478a6899dcd45;
		_x944b5cca78a375e0 = x337e217cb3ba0627._x944b5cca78a375e0;
		_xd55b6f5e7aaffd65 = x337e217cb3ba0627._xd55b6f5e7aaffd65;
		_x7e86c2f18f82bb31 = x337e217cb3ba0627._x7e86c2f18f82bb31;
	}

	private void _x35c619d38671e064(Stream xe4115acdf4fbfccc)
	{
		Stream stream = null;
		try
		{
			_xfad3df95ca108a86 = xe4115acdf4fbfccc.Position;
		}
		catch
		{
		}
		x18b5d2c1faea3df7 x18b5d2c1faea3df8;
		x853ddd714d7aaa13 x853ddd714d7aaa14;
		try
		{
			long x0967b3fb9ec238c = 0L;
			if (_xaf77e81a71d6921f == x58bf66883d9e6d5a.xb8a774e0111d0fbe)
			{
				x66c7fb6136ee8a22();
				stream = _xfa527d9626e5c265;
				try
				{
					x0967b3fb9ec238c = _xfa527d9626e5c265.Length;
				}
				catch (NotSupportedException)
				{
				}
			}
			else
			{
				FileShare share = FileShare.ReadWrite;
				FileInfo fileInfo = new FileInfo(x08d0fbfeee1603b1);
				x0967b3fb9ec238c = fileInfo.Length;
				stream = File.Open(x08d0fbfeee1603b1, FileMode.Open, FileAccess.Read, share);
			}
			x18b5d2c1faea3df8 = new x18b5d2c1faea3df7(stream);
			x853ddd714d7aaa14 = new x853ddd714d7aaa13(xe4115acdf4fbfccc);
			Stream stream2 = x853ddd714d7aaa14;
			if (x5d327c9569dc4f54 == xea98c2211cc2e8a1.x94fedbf94759d5f4)
			{
				stream2 = new xc65b5343382bdcf8(x853ddd714d7aaa14, _x845726eb9cff3810, x0c752eb8af884509.x246b032720dd4c0d);
			}
			bool flag = false;
			Stream stream3;
			if (x93f6dc9bc169b40a == 8 && _xe2a6c1b66e699ef3.x0bf508c6214e694f != 0)
			{
				xdd609f761b3f07f0 xdd609f761b3f07f = new xdd609f761b3f07f0(stream2, x1f770018e5e12789.x2688d9218ffd4d00, _xe2a6c1b66e699ef3.x0bf508c6214e694f, leaveOpen: true);
				if (_xe2a6c1b66e699ef3.x8b7fce8aacc6841a > 0)
				{
					xdd609f761b3f07f.x648114bcf1499890 = _xe2a6c1b66e699ef3.x8b7fce8aacc6841a;
				}
				xdd609f761b3f07f.xce7d657046e9409a = _xe2a6c1b66e699ef3.xce7d657046e9409a;
				flag = true;
				stream3 = xdd609f761b3f07f;
			}
			else
			{
				stream3 = stream2;
			}
			byte[] array = new byte[x648114bcf1499890];
			int count;
			while ((count = x977b5605864b2047.x5791cfd88e60d337(x18b5d2c1faea3df8, array, 0, array.Length, xa39af5a82860a9a3)) != 0)
			{
				stream3.Write(array, 0, count);
				x1342fe630ec86bca(x18b5d2c1faea3df8.x74f037c714389a81, x0967b3fb9ec238c);
				if (_x49fe32f14563e6a0)
				{
					break;
				}
			}
			if (flag)
			{
				stream3.Close();
			}
			stream2.Flush();
			stream2.Close();
			_x72b7a211fbd3d75f = 0;
		}
		finally
		{
			if (_xaf77e81a71d6921f != x58bf66883d9e6d5a.xb8a774e0111d0fbe)
			{
				stream?.Close();
			}
		}
		if (_x49fe32f14563e6a0)
		{
			return;
		}
		_xc49fe6a8d63d6783 = x18b5d2c1faea3df8.x74f037c714389a81;
		_x09d464f2121ddee7 = x853ddd714d7aaa14.x1c86f1bc0157a1b8;
		_x9a0049934ff5530a = _x09d464f2121ddee7;
		_x5e4059a15fb5fca5 = x18b5d2c1faea3df8.x4267aa67a0bb35b8;
		if (_xa4bc2af2b58881c8 != null && x5d327c9569dc4f54 == xea98c2211cc2e8a1.x94fedbf94759d5f4)
		{
			_x9a0049934ff5530a += 12L;
		}
		int num = 8;
		_x04cffeb7c4db4cab[num++] = (byte)((uint)x93f6dc9bc169b40a & 0xFFu);
		_x04cffeb7c4db4cab[num++] = (byte)((x93f6dc9bc169b40a & 0xFF00) >> 8);
		num = 14;
		_x04cffeb7c4db4cab[num++] = (byte)((uint)_x5e4059a15fb5fca5 & 0xFFu);
		_x04cffeb7c4db4cab[num++] = (byte)((_x5e4059a15fb5fca5 & 0xFF00) >> 8);
		_x04cffeb7c4db4cab[num++] = (byte)((_x5e4059a15fb5fca5 & 0xFF0000) >> 16);
		_x04cffeb7c4db4cab[num++] = (byte)((_x5e4059a15fb5fca5 & 0xFF000000u) >> 24);
		_x1b01248c8c69aa12 = ((_x9a0049934ff5530a >= uint.MaxValue || _xc49fe6a8d63d6783 >= uint.MaxValue || _x7e322ff037b992c9 >= uint.MaxValue) ? x09c3256ccc14f142.xbbad6bbe73c6b1dc : x09c3256ccc14f142.x12642456c7bf0815);
		if (_xe2a6c1b66e699ef3._xa4993e9106eb60b0 == xd53f386d6d162abf.xb9715d2f06b63cf0 && _x1b01248c8c69aa12 == x09c3256ccc14f142.xbbad6bbe73c6b1dc)
		{
			throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("megdfhndaheeahlepgcfpfjfkgaghghggfogcffhlamhhfdihfkicabjedijkepjmdgkfenkaeelaellpdcmpcjmkdanhdhngconccfolnlolcdpobkpmcbaebiainoajmfbfbnbfbecamkcmacdaajdnppdhahegpnecafflklfnocgnpjgfoaheohhboohnnfijomidjdjeokjfnbkpmikhipkbnglcmnlgnememlmfmcnkmjnplaopghocmookkfpclmpildafkkalgbbkfibkhpbdkgcpjncbkedejldmicekijeejafpdhfpiofohfgkimghidhjhkhlhbibhiihcpiihgjjgnjdgeklblknecligjlhfamjehmffomjffnmbmnhbdohdkofebppdipfepphcgacdnaeeebedlbgdccmcjccopcpchdocodicfegcmeibdfcckfbcbgdcighmogdbghpanholdipaliaacjkpijclpjjogkfpnkjpelmmllmocmmojmcoankjhnaooncofoeomocodpmmkpgnbaimiahmpanigb", 953366025)));
		}
		_x4f36598217f645a0 = ((_xe2a6c1b66e699ef3._xa4993e9106eb60b0 == xd53f386d6d162abf.xd4d82c4665f71358 || _x1b01248c8c69aa12 == x09c3256ccc14f142.xbbad6bbe73c6b1dc) ? x09c3256ccc14f142.xbbad6bbe73c6b1dc : x09c3256ccc14f142.x12642456c7bf0815);
		short num2 = (short)(_x04cffeb7c4db4cab[26] + _x04cffeb7c4db4cab[27] * 256);
		short num3 = (short)(_x04cffeb7c4db4cab[28] + _x04cffeb7c4db4cab[29] * 256);
		if (_x4f36598217f645a0 == x09c3256ccc14f142.xbbad6bbe73c6b1dc)
		{
			_x04cffeb7c4db4cab[4] = 45;
			_x04cffeb7c4db4cab[5] = 0;
			for (int i = 0; i < 8; i++)
			{
				_x04cffeb7c4db4cab[num++] = byte.MaxValue;
			}
			num = 30 + num2;
			_x04cffeb7c4db4cab[num++] = 1;
			_x04cffeb7c4db4cab[num++] = 0;
			num += 2;
			Array.Copy(BitConverter.GetBytes(_xc49fe6a8d63d6783), 0, _x04cffeb7c4db4cab, num, 8);
			num += 8;
			Array.Copy(BitConverter.GetBytes(_x9a0049934ff5530a), 0, _x04cffeb7c4db4cab, num, 8);
		}
		else
		{
			_x04cffeb7c4db4cab[4] = 20;
			_x04cffeb7c4db4cab[5] = 0;
			num = 18;
			_x04cffeb7c4db4cab[num++] = (byte)(_x9a0049934ff5530a & 0xFF);
			_x04cffeb7c4db4cab[num++] = (byte)((_x9a0049934ff5530a & 0xFF00) >> 8);
			_x04cffeb7c4db4cab[num++] = (byte)((_x9a0049934ff5530a & 0xFF0000) >> 16);
			_x04cffeb7c4db4cab[num++] = (byte)((_x9a0049934ff5530a & 0xFF000000u) >> 24);
			_x04cffeb7c4db4cab[num++] = (byte)(_xc49fe6a8d63d6783 & 0xFF);
			_x04cffeb7c4db4cab[num++] = (byte)((_xc49fe6a8d63d6783 & 0xFF00) >> 8);
			_x04cffeb7c4db4cab[num++] = (byte)((_xc49fe6a8d63d6783 & 0xFF0000) >> 16);
			_x04cffeb7c4db4cab[num++] = (byte)((_xc49fe6a8d63d6783 & 0xFF000000u) >> 24);
			if (num3 != 0)
			{
				num = 30 + num2;
				short num4 = (short)(_x04cffeb7c4db4cab[num + 2] + _x04cffeb7c4db4cab[num + 3] * 256);
				if (num4 == 16)
				{
					_x04cffeb7c4db4cab[num++] = 153;
					_x04cffeb7c4db4cab[num++] = 153;
				}
			}
		}
		if ((_x2d3be316c1c6e811 & 8) != 8)
		{
			xe4115acdf4fbfccc.Seek(_x7e322ff037b992c9, SeekOrigin.Begin);
			xe4115acdf4fbfccc.Write(_x04cffeb7c4db4cab, 0, _x04cffeb7c4db4cab.Length);
			if (xe4115acdf4fbfccc is x853ddd714d7aaa13 x853ddd714d7aaa15)
			{
				x853ddd714d7aaa15.xfaab97dd0218026f(_x04cffeb7c4db4cab.Length);
			}
			xe4115acdf4fbfccc.Seek(_x9a0049934ff5530a, SeekOrigin.Current);
			return;
		}
		byte[] array2 = new byte[16 + ((_x4f36598217f645a0 == x09c3256ccc14f142.xbbad6bbe73c6b1dc) ? 8 : 0)];
		num = 0;
		Array.Copy(BitConverter.GetBytes(134695760), 0, array2, num, 4);
		num += 4;
		Array.Copy(BitConverter.GetBytes(_x5e4059a15fb5fca5), 0, array2, num, 4);
		num += 4;
		if (_x4f36598217f645a0 == x09c3256ccc14f142.xbbad6bbe73c6b1dc)
		{
			Array.Copy(BitConverter.GetBytes(_x9a0049934ff5530a), 0, array2, num, 8);
			num += 8;
			Array.Copy(BitConverter.GetBytes(_xc49fe6a8d63d6783), 0, array2, num, 8);
			num += 8;
		}
		else
		{
			array2[num++] = (byte)(_x9a0049934ff5530a & 0xFF);
			array2[num++] = (byte)((_x9a0049934ff5530a & 0xFF00) >> 8);
			array2[num++] = (byte)((_x9a0049934ff5530a & 0xFF0000) >> 16);
			array2[num++] = (byte)((_x9a0049934ff5530a & 0xFF000000u) >> 24);
			array2[num++] = (byte)(_xc49fe6a8d63d6783 & 0xFF);
			array2[num++] = (byte)((_xc49fe6a8d63d6783 & 0xFF00) >> 8);
			array2[num++] = (byte)((_xc49fe6a8d63d6783 & 0xFF0000) >> 16);
			array2[num++] = (byte)((_xc49fe6a8d63d6783 & 0xFF000000u) >> 24);
		}
		xe4115acdf4fbfccc.Write(array2, 0, array2.Length);
		_x72b7a211fbd3d75f += array2.Length;
	}

	private void x3766776f0787957f(Exception xfbf34718e704c6bc)
	{
		_x49fe32f14563e6a0 = _xe2a6c1b66e699ef3.x3cc81d04188e90c3(this, xfbf34718e704c6bc);
	}

	internal void x6210059f049f0d48(Stream xe4115acdf4fbfccc)
	{
		bool flag = false;
		do
		{
			if (_xaf77e81a71d6921f == x58bf66883d9e6d5a.xef4b7685c2495ff2 && !_x01c9af277f1f564c)
			{
				x9a3296e478e0833c(xe4115acdf4fbfccc);
				break;
			}
			try
			{
				if (x4d1990cadac28b9b)
				{
					x4a7d1611730784f2(xe4115acdf4fbfccc, 1);
					_x1b01248c8c69aa12 = ((_x7e322ff037b992c9 >= uint.MaxValue) ? x09c3256ccc14f142.xbbad6bbe73c6b1dc : x09c3256ccc14f142.x12642456c7bf0815);
					_x4f36598217f645a0 = ((_xe2a6c1b66e699ef3._xa4993e9106eb60b0 == xd53f386d6d162abf.xd4d82c4665f71358 || _x1b01248c8c69aa12 == x09c3256ccc14f142.xbbad6bbe73c6b1dc) ? x09c3256ccc14f142.xbbad6bbe73c6b1dc : x09c3256ccc14f142.x12642456c7bf0815);
					break;
				}
				bool flag2 = true;
				int num = 0;
				do
				{
					num++;
					x4a7d1611730784f2(xe4115acdf4fbfccc, num);
					_x8d07cefc097d35e4(xe4115acdf4fbfccc);
					flag2 = num <= 1 && xe4115acdf4fbfccc.CanSeek && xce6f9638ca67fa72();
					if (flag2)
					{
						xe4115acdf4fbfccc.Seek(_x7e322ff037b992c9, SeekOrigin.Begin);
						xe4115acdf4fbfccc.SetLength(xe4115acdf4fbfccc.Position);
						if (xe4115acdf4fbfccc is x853ddd714d7aaa13 x853ddd714d7aaa14)
						{
							x853ddd714d7aaa14.xfaab97dd0218026f(_x5348dad0c0de551e);
						}
					}
				}
				while (flag2);
				_x00feab56489b1a16 = false;
				flag = true;
			}
			catch (Exception ex)
			{
				xb2ddbff67fa53c13 xb2ddbff67fa53c14 = xb2ddbff67fa53c13;
				int num2 = 0;
				while (true)
				{
					if (xb2ddbff67fa53c13 == xb2ddbff67fa53c13.x643d287ae28d7eef)
					{
						throw;
					}
					if (xb2ddbff67fa53c13 == xb2ddbff67fa53c13.xcc32d73386110a60 || xb2ddbff67fa53c13 == xb2ddbff67fa53c13.x83adb967f4a89cac)
					{
						if (!xe4115acdf4fbfccc.CanSeek)
						{
							throw;
						}
						long position = xe4115acdf4fbfccc.Position;
						xe4115acdf4fbfccc.Seek(_x7e322ff037b992c9, SeekOrigin.Begin);
						long position2 = xe4115acdf4fbfccc.Position;
						xe4115acdf4fbfccc.SetLength(xe4115acdf4fbfccc.Position);
						if (xe4115acdf4fbfccc is x853ddd714d7aaa13 x853ddd714d7aaa15)
						{
							x853ddd714d7aaa15.xfaab97dd0218026f(position - position2);
						}
						if (xb2ddbff67fa53c13 == xb2ddbff67fa53c13.xcc32d73386110a60)
						{
							if (_xe2a6c1b66e699ef3.x44102a7f72bfea16 != null)
							{
								_xe2a6c1b66e699ef3.x44102a7f72bfea16.WriteLine("Skipping file {0} (exception: {1})", x08d0fbfeee1603b1, ex.ToString());
							}
							_x00feab56489b1a16 = true;
							flag = true;
						}
						else
						{
							xb2ddbff67fa53c13 = xb2ddbff67fa53c14;
						}
						break;
					}
					if (num2 > 0)
					{
						throw;
					}
					if (xb2ddbff67fa53c13 == xb2ddbff67fa53c13.x52ef86a7f379fd91)
					{
						x3766776f0787957f(ex);
						if (_x49fe32f14563e6a0)
						{
							flag = true;
							break;
						}
					}
					num2++;
				}
			}
		}
		while (!flag);
	}

	private void _x8d07cefc097d35e4(Stream x7f5d4a91157364b5)
	{
		_xf47cd40e31ddb42c(x7f5d4a91157364b5);
		_x35c619d38671e064(x7f5d4a91157364b5);
		_x5348dad0c0de551e = _xb69adf785c29907e + _x09d464f2121ddee7 + _x72b7a211fbd3d75f;
	}

	private void _xf47cd40e31ddb42c(Stream x7f5d4a91157364b5)
	{
		if (_xa4bc2af2b58881c8 != null && x5d327c9569dc4f54 == xea98c2211cc2e8a1.x94fedbf94759d5f4)
		{
			_x845726eb9cff3810 = xed28787af62b195b.x24d00e2eda0373b8(_xa4bc2af2b58881c8);
			Random random = new Random();
			byte[] array = new byte[12];
			random.NextBytes(array);
			if ((_x2d3be316c1c6e811 & 8) == 8)
			{
				_xc3309b8559936a71 = x977b5605864b2047.x35cf72c0c42c20e8(xf3d2608616d7641a);
				array[11] = (byte)((uint)(_xc3309b8559936a71 >> 8) & 0xFFu);
			}
			else
			{
				xf70eb969357470c5();
				array[11] = (byte)((uint)(_x5e4059a15fb5fca5 >> 24) & 0xFFu);
			}
			byte[] array2 = _x845726eb9cff3810.x510fa7633d236c28(array, array.Length);
			x7f5d4a91157364b5.Write(array2, 0, array2.Length);
			_xb69adf785c29907e += array2.Length;
		}
	}

	private void x9a3296e478e0833c(Stream x7f5d4a91157364b5)
	{
		if (xb69adf785c29907e == 0)
		{
			throw new xcb4fb578c1324851(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ijbhelihelphnggiclnimkejfkljfkckdkjknkalifhlbkolhjfmnjmmdjdnnjknoibobfio", 306540886)));
		}
		x18b5d2c1faea3df7 xb97f633f = new x18b5d2c1faea3df7(x4b75fd1546e838a4);
		if (_x55f2a2fe7806c520 || (_x60a12c8412239ce4 && _xe2a6c1b66e699ef3.x08c7ffea8799a127 == xd53f386d6d162abf.xb9715d2f06b63cf0) || (!_x60a12c8412239ce4 && _xe2a6c1b66e699ef3.x08c7ffea8799a127 == xd53f386d6d162abf.xd4d82c4665f71358))
		{
			xc77b310379c20da0(x7f5d4a91157364b5, xb97f633f);
		}
		else
		{
			xe48153973b1a9931(x7f5d4a91157364b5, xb97f633f);
		}
		_x1b01248c8c69aa12 = ((_x9a0049934ff5530a >= uint.MaxValue || _xc49fe6a8d63d6783 >= uint.MaxValue || _x7e322ff037b992c9 >= uint.MaxValue) ? x09c3256ccc14f142.xbbad6bbe73c6b1dc : x09c3256ccc14f142.x12642456c7bf0815);
		_x4f36598217f645a0 = ((_xe2a6c1b66e699ef3._xa4993e9106eb60b0 == xd53f386d6d162abf.xd4d82c4665f71358 || _x1b01248c8c69aa12 == x09c3256ccc14f142.xbbad6bbe73c6b1dc) ? x09c3256ccc14f142.xbbad6bbe73c6b1dc : x09c3256ccc14f142.x12642456c7bf0815);
	}

	private void xc77b310379c20da0(Stream x7f5d4a91157364b5, x18b5d2c1faea3df7 xb97f633f56486004)
	{
		byte[] array = new byte[x648114bcf1499890];
		Stream stream = x4b75fd1546e838a4;
		long x7e322ff037b992c = _x7e322ff037b992c9;
		int num = xb69adf785c29907e;
		x4a7d1611730784f2(x7f5d4a91157364b5, 0);
		if (!xa39af5a82860a9a3.EndsWith("/"))
		{
			long num2 = x7e322ff037b992c + num;
			num2 -= x1aa43c710cd072fa;
			_xb69adf785c29907e += x1aa43c710cd072fa;
			_xe2a6c1b66e699ef3.xd0c948b79c880a6b(num2);
			long num3 = _x9a0049934ff5530a;
			while (num3 > 0)
			{
				int count = (int)((num3 > array.Length) ? array.Length : num3);
				int num4 = xb97f633f56486004.Read(array, 0, count);
				x7f5d4a91157364b5.Write(array, 0, num4);
				num3 -= num4;
				x1342fe630ec86bca(xb97f633f56486004.x74f037c714389a81, _x9a0049934ff5530a);
				if (_x49fe32f14563e6a0)
				{
					break;
				}
			}
			if ((_x2d3be316c1c6e811 & 8) == 8)
			{
				int num5 = 16;
				if (_x60a12c8412239ce4)
				{
					num5 += 8;
				}
				byte[] buffer = new byte[num5];
				stream.Read(buffer, 0, num5);
				if (_x60a12c8412239ce4 && _xe2a6c1b66e699ef3.x08c7ffea8799a127 == xd53f386d6d162abf.xb9715d2f06b63cf0)
				{
					x7f5d4a91157364b5.Write(buffer, 0, 8);
					if (_x9a0049934ff5530a > uint.MaxValue)
					{
						throw new InvalidOperationException("ZIP64 is required");
					}
					x7f5d4a91157364b5.Write(buffer, 8, 4);
					if (_xc49fe6a8d63d6783 > uint.MaxValue)
					{
						throw new InvalidOperationException("ZIP64 is required");
					}
					x7f5d4a91157364b5.Write(buffer, 16, 4);
					_x72b7a211fbd3d75f -= 8;
				}
				else if (!_x60a12c8412239ce4 && _xe2a6c1b66e699ef3.x08c7ffea8799a127 == xd53f386d6d162abf.xd4d82c4665f71358)
				{
					byte[] buffer2 = new byte[4];
					x7f5d4a91157364b5.Write(buffer, 0, 8);
					x7f5d4a91157364b5.Write(buffer, 8, 4);
					x7f5d4a91157364b5.Write(buffer2, 0, 4);
					x7f5d4a91157364b5.Write(buffer, 12, 4);
					x7f5d4a91157364b5.Write(buffer2, 0, 4);
					_x72b7a211fbd3d75f += 8;
				}
				else
				{
					x7f5d4a91157364b5.Write(buffer, 0, num5);
				}
			}
		}
		_x5348dad0c0de551e = _xb69adf785c29907e + _x09d464f2121ddee7 + _x72b7a211fbd3d75f;
	}

	private void xe48153973b1a9931(Stream x7f5d4a91157364b5, x18b5d2c1faea3df7 xb97f633f56486004)
	{
		byte[] array = new byte[x648114bcf1499890];
		_xe2a6c1b66e699ef3.xd0c948b79c880a6b(_x7e322ff037b992c9);
		if (_x5348dad0c0de551e == 0)
		{
			_x5348dad0c0de551e = _xb69adf785c29907e + _x09d464f2121ddee7 + _x72b7a211fbd3d75f;
		}
		_x7e322ff037b992c9 = (x7f5d4a91157364b5 as x853ddd714d7aaa13)?.x1c86f1bc0157a1b8 ?? x7f5d4a91157364b5.Position;
		long num = _x5348dad0c0de551e;
		while (num > 0)
		{
			int count = (int)((num > array.Length) ? array.Length : num);
			int num2 = xb97f633f56486004.Read(array, 0, count);
			x7f5d4a91157364b5.Write(array, 0, num2);
			num -= num2;
			x1342fe630ec86bca(xb97f633f56486004.x74f037c714389a81, _x5348dad0c0de551e);
			if (_x49fe32f14563e6a0)
			{
				break;
			}
		}
	}
}
