using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;
using Aspose;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xe8730a664ff488a4;

[DefaultMember("Item")]
[JavaDelete("Using java zip instead.")]
internal class xef4b7685c2495ff2 : IDisposable, IEnumerable
{
	private bool _xebb0a1fa72b779dc;

	private int _x8b7fce8aacc6841a;

	private bool _x0e26a7f9519d1daf;

	private x0bf508c6214e694f _x0bf508c6214e694f;

	public static readonly Encoding x24500e9782c41ba0 = Encoding.GetEncoding("IBM437");

	private x8859214cc4c1cfab _xec3a126a0abb0cbf;

	private xb2ddbff67fa53c13 _xb2ddbff67fa53c13;

	private xdaccc4e215530d18 _x6a403654e6eff91d;

	private x3021244279b7a80c _x12b00c407ac22ed0;

	private TextWriter _x44102a7f72bfea16;

	private bool _xd072ad4e04a4b5a1;

	private Stream _xb9a61312065e93e4;

	private Stream _x6ca6eb9a64d8c1fc;

	private bool _x0e75cd3866dbb930;

	private ArrayList _x8d54381b90e4e4be;

	private bool _x4c8357e8f994ea6a;

	private string _xc15bd84e01929885;

	private string _x937e050c63ea1527;

	internal string _xa4bc2af2b58881c8;

	private bool _x7e86c2f18f82bb31 = true;

	private bool _xd55b6f5e7aaffd65;

	private x07366e3d6c48f6c6 _xce7d657046e9409a;

	private long _x65ba13a854a4213e;

	private bool _x6d56bb4f9166f4bf;

	private string _xf4cbc48f2b9d24ea;

	private bool _x8438cfc2d3232fce;

	private bool _xc4eb04529e195c67;

	private string _x753d527f977f58ee;

	private bool _xc2906194e8646892 = true;

	private object x8b9ab1471acb7ac8 = new object();

	private bool _xf24acc83b64952af;

	private bool _xc43789532026e0d8;

	private xea98c2211cc2e8a1 _x5d327c9569dc4f54;

	private bool _x99f8a974f1c21380;

	private bool _x11dc948e89bcec36;

	private long _xe0a94e4535ae92fa = -1L;

	private x09c3256ccc14f142 _x4f36598217f645a0;

	internal bool _x1cc53e92d902f0a4;

	private Encoding _x569440e5ccedf43e = Encoding.GetEncoding("IBM437");

	private int _x648114bcf1499890 = 8192;

	internal xd53f386d6d162abf _xa4993e9106eb60b0;

	private long _x19e2f5150b43cef5 = -99L;

	public bool xebb0a1fa72b779dc
	{
		get
		{
			return _xebb0a1fa72b779dc;
		}
		set
		{
			_xebb0a1fa72b779dc = value;
		}
	}

	public int x648114bcf1499890
	{
		get
		{
			return _x648114bcf1499890;
		}
		set
		{
			_x648114bcf1499890 = value;
		}
	}

	public int x8b7fce8aacc6841a
	{
		get
		{
			return _x8b7fce8aacc6841a;
		}
		set
		{
			_x8b7fce8aacc6841a = value;
		}
	}

	public bool x0e26a7f9519d1daf
	{
		get
		{
			return _x0e26a7f9519d1daf;
		}
		set
		{
			_x0e26a7f9519d1daf = value;
		}
	}

	public x07366e3d6c48f6c6 xce7d657046e9409a
	{
		get
		{
			return _xce7d657046e9409a;
		}
		set
		{
			_xce7d657046e9409a = value;
		}
	}

	public string x759aa16c2016a289
	{
		get
		{
			return _xc15bd84e01929885;
		}
		set
		{
			_xc15bd84e01929885 = value;
		}
	}

	public x0bf508c6214e694f x0bf508c6214e694f
	{
		get
		{
			return _x0bf508c6214e694f;
		}
		set
		{
			_x0bf508c6214e694f = value;
		}
	}

	public string x937e050c63ea1527
	{
		get
		{
			return _x937e050c63ea1527;
		}
		set
		{
			_x937e050c63ea1527 = value;
			_x8438cfc2d3232fce = true;
		}
	}

	public bool x31e3d7775ac697d2
	{
		get
		{
			return _x7e86c2f18f82bb31;
		}
		set
		{
			_x7e86c2f18f82bb31 = value;
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
		}
	}

	internal bool x0ede19c87c5fb089 => _x44102a7f72bfea16 != null;

	public bool xd072ad4e04a4b5a1
	{
		get
		{
			return _xd072ad4e04a4b5a1;
		}
		set
		{
			_xd072ad4e04a4b5a1 = value;
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
			_x569440e5ccedf43e = (value ? Encoding.GetEncoding("UTF-8") : x24500e9782c41ba0);
		}
	}

	public xd53f386d6d162abf x08c7ffea8799a127
	{
		get
		{
			return _xa4993e9106eb60b0;
		}
		set
		{
			_xa4993e9106eb60b0 = value;
		}
	}

	public x09c3256ccc14f142 x7683750c9f5c037f
	{
		get
		{
			if (_x8d54381b90e4e4be.Count > 65534)
			{
				return x09c3256ccc14f142.xbbad6bbe73c6b1dc;
			}
			if (!_xc4eb04529e195c67 || _x8438cfc2d3232fce)
			{
				return x09c3256ccc14f142.xb5bc32a1af287221;
			}
			foreach (x990d54f34b2b5118 item in _x8d54381b90e4e4be)
			{
				if (item.x7683750c9f5c037f == x09c3256ccc14f142.xbbad6bbe73c6b1dc)
				{
					return x09c3256ccc14f142.xbbad6bbe73c6b1dc;
				}
			}
			return x09c3256ccc14f142.x12642456c7bf0815;
		}
	}

	public x09c3256ccc14f142 xff7630c349464a76 => _x4f36598217f645a0;

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

	public TextWriter x44102a7f72bfea16
	{
		get
		{
			return _x44102a7f72bfea16;
		}
		set
		{
			_x44102a7f72bfea16 = value;
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
			_x4c8357e8f994ea6a = value;
		}
	}

	public string x753d527f977f58ee
	{
		get
		{
			return _x753d527f977f58ee;
		}
		set
		{
			_x753d527f977f58ee = value;
			if (value == null || Directory.Exists(value))
			{
				return;
			}
			throw new FileNotFoundException($"That directory ({value}) does not exist.");
		}
	}

	public string xa4bc2af2b58881c8
	{
		set
		{
			_xa4bc2af2b58881c8 = value;
			if (_xa4bc2af2b58881c8 == null)
			{
				x5d327c9569dc4f54 = xea98c2211cc2e8a1.x4d0b9d4447ba7566;
			}
			else if (x5d327c9569dc4f54 == xea98c2211cc2e8a1.x4d0b9d4447ba7566)
			{
				x5d327c9569dc4f54 = xea98c2211cc2e8a1.x94fedbf94759d5f4;
			}
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

	public xea98c2211cc2e8a1 x5d327c9569dc4f54
	{
		get
		{
			return _x5d327c9569dc4f54;
		}
		set
		{
			if (value == xea98c2211cc2e8a1.xf9120e21ea3ee2d1)
			{
				throw new InvalidOperationException("You may not set Encryption to that value.");
			}
			_x5d327c9569dc4f54 = value;
		}
	}

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

	public static Version x221aa7ebaed9e996 => Assembly.GetExecutingAssembly().GetName().Version;

	internal Stream x53cce0b6abbd65ad
	{
		get
		{
			if (_xb9a61312065e93e4 == null && _xc15bd84e01929885 != null)
			{
				try
				{
					_xb9a61312065e93e4 = File.OpenRead(_xc15bd84e01929885);
					_xc2906194e8646892 = true;
				}
				catch (IOException innerException)
				{
					throw new xc5e345d2a919c94b("Error opening the file", innerException);
				}
			}
			return _xb9a61312065e93e4;
		}
	}

	public x990d54f34b2b5118 xe6d4b1b411ed94b5
	{
		get
		{
			return (x990d54f34b2b5118)_x8d54381b90e4e4be[xdcd21dec40332493];
		}
		set
		{
			if (value != null)
			{
				throw new xc5e345d2a919c94b("You may not set this to a non-null ZipEntry value.", new ArgumentException("this[int]"));
			}
			x9fb64bf7f753c678((x990d54f34b2b5118)_x8d54381b90e4e4be[xdcd21dec40332493]);
		}
	}

	public x990d54f34b2b5118 xe6d4b1b411ed94b5
	{
		get
		{
			foreach (x990d54f34b2b5118 item in _x8d54381b90e4e4be)
			{
				if (xd072ad4e04a4b5a1)
				{
					if (item.xa39af5a82860a9a3 == xafe2f3653ee64ebc)
					{
						return item;
					}
					if (xafe2f3653ee64ebc.Replace("\\", "/") == item.xa39af5a82860a9a3)
					{
						return item;
					}
					if (item.xa39af5a82860a9a3.Replace("\\", "/") == xafe2f3653ee64ebc)
					{
						return item;
					}
					if (item.xa39af5a82860a9a3.EndsWith("/"))
					{
						string text = item.xa39af5a82860a9a3.Trim("/".ToCharArray());
						if (text == xafe2f3653ee64ebc)
						{
							return item;
						}
						if (xafe2f3653ee64ebc.Replace("\\", "/") == text)
						{
							return item;
						}
						if (text.Replace("\\", "/") == xafe2f3653ee64ebc)
						{
							return item;
						}
					}
					continue;
				}
				if (x0d299f323d241756.x90637a473b1ceaaa(item.xa39af5a82860a9a3, xafe2f3653ee64ebc))
				{
					return item;
				}
				if (x0d299f323d241756.x90637a473b1ceaaa(xafe2f3653ee64ebc.Replace("\\", "/"), item.xa39af5a82860a9a3))
				{
					return item;
				}
				if (x0d299f323d241756.x90637a473b1ceaaa(item.xa39af5a82860a9a3.Replace("\\", "/"), xafe2f3653ee64ebc))
				{
					return item;
				}
				if (item.xa39af5a82860a9a3.EndsWith("/"))
				{
					string text2 = item.xa39af5a82860a9a3.Trim("/".ToCharArray());
					if (x0d299f323d241756.x90637a473b1ceaaa(text2, xafe2f3653ee64ebc))
					{
						return item;
					}
					if (x0d299f323d241756.x90637a473b1ceaaa(xafe2f3653ee64ebc.Replace("\\", "/"), text2))
					{
						return item;
					}
					if (x0d299f323d241756.x90637a473b1ceaaa(text2.Replace("\\", "/"), xafe2f3653ee64ebc))
					{
						return item;
					}
				}
			}
			return null;
		}
		set
		{
			if (value != null)
			{
				throw new ArgumentException("You may not set this to a non-null ZipEntry value.");
			}
			x9fb64bf7f753c678(xafe2f3653ee64ebc);
		}
	}

	public ArrayList x1b31e7fa3c687c32
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			foreach (x990d54f34b2b5118 item in _x8d54381b90e4e4be)
			{
				arrayList.Add(item.xa39af5a82860a9a3);
			}
			return arrayList;
		}
	}

	public ArrayList x53943b75dcdfb4ba => _x8d54381b90e4e4be;

	public int xd44988f225497f3a => _x8d54381b90e4e4be.Count;

	private Stream x25b763a23176450f
	{
		get
		{
			if (_x6ca6eb9a64d8c1fc == null && _xc15bd84e01929885 != null)
			{
				if (x753d527f977f58ee == ".")
				{
					_xf4cbc48f2b9d24ea = x977b5605864b2047.x216f7e66fa44cf71();
				}
				else if (x753d527f977f58ee != null)
				{
					_xf4cbc48f2b9d24ea = Path.Combine(x753d527f977f58ee, x977b5605864b2047.x216f7e66fa44cf71());
				}
				else
				{
					string directoryName = Path.GetDirectoryName(_xc15bd84e01929885);
					_xf4cbc48f2b9d24ea = Path.Combine(directoryName, x977b5605864b2047.x216f7e66fa44cf71());
				}
				_x6ca6eb9a64d8c1fc = new FileStream(_xf4cbc48f2b9d24ea, FileMode.CreateNew);
			}
			return _x6ca6eb9a64d8c1fc;
		}
		set
		{
			if (value != null)
			{
				throw new xc5e345d2a919c94b("Whoa!", new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oogijaoidbfjabmjoadkabkkjlaljailipoleagmnkmmopdnpoknjobobkiobppopogpkonpkneadnlamncbmijbnnacfnhcdiocbmfdnhmdimdegmkecmbfohifmlpfamggelngblehcglhflcinjjifkajlkhjijojoffk", 2064221867)), "value"));
			}
			_x6ca6eb9a64d8c1fc = null;
		}
	}

	private string x7d7b99da208c34de
	{
		get
		{
			if (_xc15bd84e01929885 == null)
			{
				return "(stream)";
			}
			return _xc15bd84e01929885;
		}
	}

	private long x521bcb9045add5a5
	{
		get
		{
			if (_x19e2f5150b43cef5 == -99)
			{
				if (_xc2906194e8646892)
				{
					FileInfo fileInfo = new FileInfo(_xc15bd84e01929885);
					_x19e2f5150b43cef5 = fileInfo.Length;
				}
				else
				{
					_x19e2f5150b43cef5 = -1L;
				}
			}
			return _x19e2f5150b43cef5;
		}
	}

	internal long x0cced477dfc63bfd => x53cce0b6abbd65ad.Position - _x65ba13a854a4213e;

	public event EventHandler xb2dd73e958fd0aad;

	public event EventHandler x4dd5eca2ff04651e;

	public event EventHandler x13eca3064073eb76;

	public event EventHandler x15e31e322a1755a5;

	public event EventHandler x5c6b3834a3ae2756;

	public override string ToString()
	{
		return $"ZipFile/{x759aa16c2016a289}";
	}

	internal void x51d89fc17a291894()
	{
		_x8438cfc2d3232fce = true;
	}

	internal void x74f5a1ef3906e23c()
	{
		if (!_x99f8a974f1c21380)
		{
			return;
		}
		xef4b7685c2495ff2 xef4b7685c2495ff3 = new xef4b7685c2495ff2();
		xef4b7685c2495ff3._xc15bd84e01929885 = _xc15bd84e01929885;
		xef4b7685c2495ff3.xbfe2d4ca3e43b779 = xbfe2d4ca3e43b779;
		x9f6a941ab884bab8(xef4b7685c2495ff3);
		foreach (x990d54f34b2b5118 item in (IEnumerable)xef4b7685c2495ff3)
		{
			foreach (x990d54f34b2b5118 item2 in (IEnumerable)this)
			{
				if (item.xa39af5a82860a9a3 == item2.xa39af5a82860a9a3)
				{
					item2.xd242614c0fae8b2e(item);
				}
			}
		}
		_x99f8a974f1c21380 = false;
	}

	public xef4b7685c2495ff2(string fileName)
	{
		try
		{
			_x272f714b8cfa09ed(fileName, null);
		}
		catch (Exception innerException)
		{
			throw new xc5e345d2a919c94b($"{fileName} is not a valid zip file", innerException);
		}
	}

	public xef4b7685c2495ff2(string fileName, Encoding encoding)
	{
		try
		{
			_x272f714b8cfa09ed(fileName, null);
			xbfe2d4ca3e43b779 = encoding;
		}
		catch (Exception innerException)
		{
			throw new xc5e345d2a919c94b($"{fileName} is not a valid zip file", innerException);
		}
	}

	public xef4b7685c2495ff2()
	{
		_x272f714b8cfa09ed(null, null);
	}

	public xef4b7685c2495ff2(Encoding encoding)
	{
		_x272f714b8cfa09ed(null, null);
		xbfe2d4ca3e43b779 = encoding;
	}

	public xef4b7685c2495ff2(string fileName, TextWriter statusMessageWriter)
	{
		try
		{
			_x272f714b8cfa09ed(fileName, statusMessageWriter);
		}
		catch (Exception innerException)
		{
			throw new xc5e345d2a919c94b($"{fileName} is not a valid zip file", innerException);
		}
	}

	public xef4b7685c2495ff2(string fileName, TextWriter statusMessageWriter, Encoding encoding)
	{
		try
		{
			_x272f714b8cfa09ed(fileName, statusMessageWriter);
			xbfe2d4ca3e43b779 = encoding;
		}
		catch (Exception innerException)
		{
			throw new xc5e345d2a919c94b($"{fileName} is not a valid zip file", innerException);
		}
	}

	public void x20aee281977480cf(string xafe2f3653ee64ebc)
	{
		try
		{
			_x272f714b8cfa09ed(xafe2f3653ee64ebc, null);
		}
		catch (Exception innerException)
		{
			throw new xc5e345d2a919c94b($"{xafe2f3653ee64ebc} is not a valid zip file", innerException);
		}
	}

	private void _x272f714b8cfa09ed(string xa8068803bce540d2, TextWriter x36a868b32d278eb7)
	{
		_xc15bd84e01929885 = xa8068803bce540d2;
		_x44102a7f72bfea16 = x36a868b32d278eb7;
		_x8438cfc2d3232fce = true;
		x0bf508c6214e694f = x0bf508c6214e694f.xb9715d2f06b63cf0;
		_x8d54381b90e4e4be = new ArrayList();
		if (File.Exists(_xc15bd84e01929885))
		{
			if (xebb0a1fa72b779dc)
			{
				xa5f0fc26f0a1f84f(this);
			}
			else
			{
				x9f6a941ab884bab8(this);
			}
			_x6d56bb4f9166f4bf = true;
		}
	}

	public void x9fb64bf7f753c678(x990d54f34b2b5118 xa85f9dbcec37a9e8)
	{
		if (!_x8d54381b90e4e4be.Contains(xa85f9dbcec37a9e8))
		{
			throw new ArgumentException("The entry you specified does not exist in the zip archive.");
		}
		_x8d54381b90e4e4be.Remove(xa85f9dbcec37a9e8);
		_x8438cfc2d3232fce = true;
	}

	public void x9fb64bf7f753c678(string xafe2f3653ee64ebc)
	{
		string xafe2f3653ee64ebc2 = x990d54f34b2b5118.x0af2fa0746b15844(xafe2f3653ee64ebc, null);
		x990d54f34b2b5118 x990d54f34b2b5119 = this.get_xe6d4b1b411ed94b5(xafe2f3653ee64ebc2);
		if (x990d54f34b2b5119 == null)
		{
			throw new ArgumentException("The entry you specified was not found in the zip archive.");
		}
		x9fb64bf7f753c678(x990d54f34b2b5119);
	}

	~xef4b7685c2495ff2()
	{
		Dispose(disposeManagedResources: false);
	}

	public void Dispose()
	{
		Dispose(disposeManagedResources: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposeManagedResources)
	{
		if (_x0e75cd3866dbb930)
		{
			return;
		}
		if (disposeManagedResources)
		{
			if (_xc2906194e8646892 && _xb9a61312065e93e4 != null)
			{
				_xb9a61312065e93e4.Close();
				_xb9a61312065e93e4 = null;
			}
			if (_xf4cbc48f2b9d24ea != null && _xc15bd84e01929885 != null && _x6ca6eb9a64d8c1fc != null)
			{
				_x6ca6eb9a64d8c1fc.Close();
				_x6ca6eb9a64d8c1fc = null;
			}
		}
		_x0e75cd3866dbb930 = true;
	}

	public x990d54f34b2b5118 x5921718e79c67372(string x2a9097a387d5add8)
	{
		return x5921718e79c67372(x2a9097a387d5add8, null);
	}

	public x990d54f34b2b5118 x5921718e79c67372(string x2a9097a387d5add8, string x3dc2b3acae462066)
	{
		if (File.Exists(x2a9097a387d5add8))
		{
			return x73012fc1567819ef(x2a9097a387d5add8, x3dc2b3acae462066);
		}
		if (Directory.Exists(x2a9097a387d5add8))
		{
			return x7b1bc92f90619cac(x2a9097a387d5add8, x3dc2b3acae462066);
		}
		throw new FileNotFoundException($"That file or directory ({x2a9097a387d5add8}) does not exist!");
	}

	public x990d54f34b2b5118 x73012fc1567819ef(string xafe2f3653ee64ebc)
	{
		return x73012fc1567819ef(xafe2f3653ee64ebc, null);
	}

	public x990d54f34b2b5118 x73012fc1567819ef(string xafe2f3653ee64ebc, string x3dc2b3acae462066)
	{
		string x208b8f1045d9bc0a = x990d54f34b2b5118.x0af2fa0746b15844(xafe2f3653ee64ebc, x3dc2b3acae462066);
		x990d54f34b2b5118 x990d54f34b2b5119 = x990d54f34b2b5118.xebcf83b00134300b(xafe2f3653ee64ebc, x208b8f1045d9bc0a);
		x990d54f34b2b5119.x4c8357e8f994ea6a = x4c8357e8f994ea6a;
		x990d54f34b2b5119.xec3a126a0abb0cbf = xec3a126a0abb0cbf;
		x990d54f34b2b5119.xb2ddbff67fa53c13 = xb2ddbff67fa53c13;
		x990d54f34b2b5119.x6a403654e6eff91d = x6a403654e6eff91d;
		x990d54f34b2b5119.x12b00c407ac22ed0 = x12b00c407ac22ed0;
		x990d54f34b2b5119.xbfe2d4ca3e43b779 = xbfe2d4ca3e43b779;
		x990d54f34b2b5119._xe2a6c1b66e699ef3 = this;
		x990d54f34b2b5119.x5d327c9569dc4f54 = x5d327c9569dc4f54;
		x990d54f34b2b5119.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
		x990d54f34b2b5119.x31e3d7775ac697d2 = _x7e86c2f18f82bb31;
		x990d54f34b2b5119.xf14036286e5de933 = _xd55b6f5e7aaffd65;
		if (x0ede19c87c5fb089)
		{
			x44102a7f72bfea16.WriteLine("adding {0}...", xafe2f3653ee64ebc);
		}
		x9cca910530869d4c(x990d54f34b2b5119);
		_x8d54381b90e4e4be.Add(x990d54f34b2b5119);
		x4a99bef71891200a(x990d54f34b2b5119);
		_x8438cfc2d3232fce = true;
		return x990d54f34b2b5119;
	}

	public void x823649a36c78a0ba(ArrayList xfe29a860dd604966)
	{
		foreach (object item in xfe29a860dd604966)
		{
			if (item is x990d54f34b2b5118)
			{
				x9fb64bf7f753c678((x990d54f34b2b5118)item);
			}
			else if (item is string)
			{
				x9fb64bf7f753c678((string)item);
			}
		}
	}

	public void xe8cb594241a5a3a7(ArrayList xec232eb93dd022a7)
	{
		xe8cb594241a5a3a7(xec232eb93dd022a7, null);
	}

	public void x0d19a3571f4e5e18(ArrayList xec232eb93dd022a7)
	{
		x0d19a3571f4e5e18(xec232eb93dd022a7, null);
	}

	public void xe8cb594241a5a3a7(ArrayList xec232eb93dd022a7, string x3dc2b3acae462066)
	{
		xe8cb594241a5a3a7(xec232eb93dd022a7, xc200864bc55137ea: false, x3dc2b3acae462066);
	}

	public void xe8cb594241a5a3a7(ArrayList xec232eb93dd022a7, bool xc200864bc55137ea, string x3dc2b3acae462066)
	{
		xdf2b7bedfa9b30d1();
		if (xc200864bc55137ea)
		{
			foreach (string item in xec232eb93dd022a7)
			{
				if (x3dc2b3acae462066 != null)
				{
					string x3dc2b3acae462067 = x977b5605864b2047.xf9660872e16d9b18(Path.Combine(x3dc2b3acae462066, Path.GetDirectoryName(item)));
					x73012fc1567819ef(item, x3dc2b3acae462067);
				}
				else
				{
					x73012fc1567819ef(item, null);
				}
			}
		}
		else
		{
			foreach (string item2 in xec232eb93dd022a7)
			{
				x73012fc1567819ef(item2, x3dc2b3acae462066);
			}
		}
		x2015294c9e902f6a();
	}

	public void x0d19a3571f4e5e18(ArrayList xec232eb93dd022a7, string x3dc2b3acae462066)
	{
		xdf2b7bedfa9b30d1();
		foreach (string item in xec232eb93dd022a7)
		{
			x28987ba977bfeff0(item, x3dc2b3acae462066);
		}
		x2015294c9e902f6a();
	}

	public x990d54f34b2b5118 x28987ba977bfeff0(string xafe2f3653ee64ebc)
	{
		return x28987ba977bfeff0(xafe2f3653ee64ebc, null);
	}

	public x990d54f34b2b5118 x28987ba977bfeff0(string xafe2f3653ee64ebc, string x3dc2b3acae462066)
	{
		string xafe2f3653ee64ebc2 = x990d54f34b2b5118.x0af2fa0746b15844(xafe2f3653ee64ebc, x3dc2b3acae462066);
		if (this.get_xe6d4b1b411ed94b5(xafe2f3653ee64ebc2) != null)
		{
			x9fb64bf7f753c678(xafe2f3653ee64ebc2);
		}
		return x73012fc1567819ef(xafe2f3653ee64ebc, x3dc2b3acae462066);
	}

	public x990d54f34b2b5118 x01af018b39cf54da(string x3552faf698c930ac)
	{
		return x01af018b39cf54da(x3552faf698c930ac, null);
	}

	public x990d54f34b2b5118 x01af018b39cf54da(string x3552faf698c930ac, string x3dc2b3acae462066)
	{
		return x390dc73308f9d6a4(x3552faf698c930ac, x3dc2b3acae462066, x229eb9e812ff9ad5.xe1af750cea391606);
	}

	public void x27d866bcffceaec5(string x7446840b0e07b9b0)
	{
		x27d866bcffceaec5(x7446840b0e07b9b0, null);
	}

	public void x27d866bcffceaec5(string x7446840b0e07b9b0, string x3dc2b3acae462066)
	{
		if (File.Exists(x7446840b0e07b9b0))
		{
			x28987ba977bfeff0(x7446840b0e07b9b0, x3dc2b3acae462066);
			return;
		}
		if (Directory.Exists(x7446840b0e07b9b0))
		{
			x01af018b39cf54da(x7446840b0e07b9b0, x3dc2b3acae462066);
			return;
		}
		throw new FileNotFoundException($"That file or directory ({x7446840b0e07b9b0}) does not exist!");
	}

	[Obsolete("Please use method AddEntry(string, string, System.IO.Stream))")]
	public x990d54f34b2b5118 xe39b1a33529690bf(string xafe2f3653ee64ebc, string x3dc2b3acae462066, Stream xcf18e5243f8d5fd3)
	{
		return xd7d75c376e5ae843(xafe2f3653ee64ebc, x3dc2b3acae462066, xcf18e5243f8d5fd3);
	}

	[Obsolete("Please use method AddEntry(string, string, System.IO.Stream))")]
	public x990d54f34b2b5118 x914d5b90c64cbaa5(string xafe2f3653ee64ebc, string x3dc2b3acae462066, Stream xcf18e5243f8d5fd3)
	{
		return xd7d75c376e5ae843(xafe2f3653ee64ebc, x3dc2b3acae462066, xcf18e5243f8d5fd3);
	}

	public x990d54f34b2b5118 xd7d75c376e5ae843(string xafe2f3653ee64ebc, string x3dc2b3acae462066, string xd1d55a56253db2df)
	{
		return xd7d75c376e5ae843(xafe2f3653ee64ebc, x3dc2b3acae462066, xd1d55a56253db2df, Encoding.Default);
	}

	public x990d54f34b2b5118 xd7d75c376e5ae843(string xafe2f3653ee64ebc, string x3dc2b3acae462066, string xd1d55a56253db2df, Encoding xff3edc9aa5f0523b)
	{
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream, xff3edc9aa5f0523b);
		streamWriter.Write(xd1d55a56253db2df);
		streamWriter.Flush();
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return xd7d75c376e5ae843(xafe2f3653ee64ebc, x3dc2b3acae462066, memoryStream);
	}

	public x990d54f34b2b5118 xd7d75c376e5ae843(string xafe2f3653ee64ebc, string x3dc2b3acae462066, Stream xcf18e5243f8d5fd3)
	{
		string x208b8f1045d9bc0a = x990d54f34b2b5118.x0af2fa0746b15844(xafe2f3653ee64ebc, x3dc2b3acae462066);
		x990d54f34b2b5118 x990d54f34b2b5119 = x990d54f34b2b5118.xebcf83b00134300b(xafe2f3653ee64ebc, x208b8f1045d9bc0a, xc11f3de674812865: true, xcf18e5243f8d5fd3);
		x990d54f34b2b5119.x4c8357e8f994ea6a = x4c8357e8f994ea6a;
		x990d54f34b2b5119.xec3a126a0abb0cbf = xec3a126a0abb0cbf;
		x990d54f34b2b5119.xb2ddbff67fa53c13 = xb2ddbff67fa53c13;
		x990d54f34b2b5119.x6a403654e6eff91d = x6a403654e6eff91d;
		x990d54f34b2b5119.x12b00c407ac22ed0 = x12b00c407ac22ed0;
		x990d54f34b2b5119.xbfe2d4ca3e43b779 = xbfe2d4ca3e43b779;
		x990d54f34b2b5119._xe2a6c1b66e699ef3 = this;
		x990d54f34b2b5119.x5d327c9569dc4f54 = x5d327c9569dc4f54;
		x990d54f34b2b5119.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
		x990d54f34b2b5119.x31e3d7775ac697d2 = _x7e86c2f18f82bb31;
		x990d54f34b2b5119.xf14036286e5de933 = _xd55b6f5e7aaffd65;
		if (x0ede19c87c5fb089)
		{
			x44102a7f72bfea16.WriteLine("adding {0}...", xafe2f3653ee64ebc);
		}
		x9cca910530869d4c(x990d54f34b2b5119);
		_x8d54381b90e4e4be.Add(x990d54f34b2b5119);
		x4a99bef71891200a(x990d54f34b2b5119);
		_x8438cfc2d3232fce = true;
		return x990d54f34b2b5119;
	}

	[Obsolete("Please use method AddEntry(string, String, string))")]
	public x990d54f34b2b5118 x9eb73f8bceecd6bb(string xafe2f3653ee64ebc, string x3dc2b3acae462066, string xd1d55a56253db2df)
	{
		return xd7d75c376e5ae843(xafe2f3653ee64ebc, x3dc2b3acae462066, xd1d55a56253db2df, Encoding.Default);
	}

	public x990d54f34b2b5118 xb4c266de7e8e0c11(string xafe2f3653ee64ebc, string x3dc2b3acae462066, string xd1d55a56253db2df)
	{
		return xb4c266de7e8e0c11(xafe2f3653ee64ebc, x3dc2b3acae462066, xd1d55a56253db2df, Encoding.Default);
	}

	public x990d54f34b2b5118 xb4c266de7e8e0c11(string xafe2f3653ee64ebc, string x3dc2b3acae462066, string xd1d55a56253db2df, Encoding xff3edc9aa5f0523b)
	{
		string xafe2f3653ee64ebc2 = x990d54f34b2b5118.x0af2fa0746b15844(xafe2f3653ee64ebc, x3dc2b3acae462066);
		if (this.get_xe6d4b1b411ed94b5(xafe2f3653ee64ebc2) != null)
		{
			x9fb64bf7f753c678(xafe2f3653ee64ebc2);
		}
		return xd7d75c376e5ae843(xafe2f3653ee64ebc, x3dc2b3acae462066, xd1d55a56253db2df, xff3edc9aa5f0523b);
	}

	public x990d54f34b2b5118 xb4c266de7e8e0c11(string xafe2f3653ee64ebc, string x3dc2b3acae462066, Stream xcf18e5243f8d5fd3)
	{
		string xafe2f3653ee64ebc2 = x990d54f34b2b5118.x0af2fa0746b15844(xafe2f3653ee64ebc, x3dc2b3acae462066);
		if (this.get_xe6d4b1b411ed94b5(xafe2f3653ee64ebc2) != null)
		{
			x9fb64bf7f753c678(xafe2f3653ee64ebc2);
		}
		return xd7d75c376e5ae843(xafe2f3653ee64ebc, x3dc2b3acae462066, xcf18e5243f8d5fd3);
	}

	[Obsolete("Please use method UpdateEntry()")]
	public x990d54f34b2b5118 xf2423c271bba5fa0(string xafe2f3653ee64ebc, string x3dc2b3acae462066, Stream xcf18e5243f8d5fd3)
	{
		return xb4c266de7e8e0c11(xafe2f3653ee64ebc, x3dc2b3acae462066, xcf18e5243f8d5fd3);
	}

	public x990d54f34b2b5118 xd7d75c376e5ae843(string xafe2f3653ee64ebc, string x3dc2b3acae462066, byte[] xb167ee3c39316a92)
	{
		if (xb167ee3c39316a92 == null)
		{
			throw new ArgumentException("bad argument", "byteContent");
		}
		MemoryStream xcf18e5243f8d5fd = new MemoryStream(xb167ee3c39316a92);
		return xd7d75c376e5ae843(xafe2f3653ee64ebc, x3dc2b3acae462066, xcf18e5243f8d5fd);
	}

	public x990d54f34b2b5118 xb4c266de7e8e0c11(string xafe2f3653ee64ebc, string x3dc2b3acae462066, byte[] xb167ee3c39316a92)
	{
		string xafe2f3653ee64ebc2 = x990d54f34b2b5118.x0af2fa0746b15844(xafe2f3653ee64ebc, x3dc2b3acae462066);
		if (this.get_xe6d4b1b411ed94b5(xafe2f3653ee64ebc2) != null)
		{
			x9fb64bf7f753c678(xafe2f3653ee64ebc2);
		}
		return xd7d75c376e5ae843(xafe2f3653ee64ebc, x3dc2b3acae462066, xb167ee3c39316a92);
	}

	private void x9cca910530869d4c(x990d54f34b2b5118 x339e849f2e1fb850)
	{
		foreach (x990d54f34b2b5118 item in _x8d54381b90e4e4be)
		{
			if (x977b5605864b2047.x849264acdd8a9902(x339e849f2e1fb850.xa39af5a82860a9a3) == item.xa39af5a82860a9a3)
			{
				throw new ArgumentException($"The entry '{x339e849f2e1fb850.xa39af5a82860a9a3}' already exists in the zip archive.");
			}
		}
	}

	public x990d54f34b2b5118 x7b1bc92f90619cac(string x3552faf698c930ac)
	{
		return x7b1bc92f90619cac(x3552faf698c930ac, null);
	}

	public x990d54f34b2b5118 x7b1bc92f90619cac(string x3552faf698c930ac, string x3dc2b3acae462066)
	{
		return x390dc73308f9d6a4(x3552faf698c930ac, x3dc2b3acae462066, x229eb9e812ff9ad5.xc3cfa600943a8c42);
	}

	public x990d54f34b2b5118 x014cfb4c4ad5fda3(string xb55fda20f0c3c1fe)
	{
		x990d54f34b2b5118 x990d54f34b2b5119 = x990d54f34b2b5118.xebcf83b00134300b(xb55fda20f0c3c1fe, xb55fda20f0c3c1fe);
		x990d54f34b2b5119.xa1404b84036ecc66();
		x990d54f34b2b5119._xaf77e81a71d6921f = x58bf66883d9e6d5a.xb8a774e0111d0fbe;
		x990d54f34b2b5119._xe2a6c1b66e699ef3 = this;
		x9cca910530869d4c(x990d54f34b2b5119);
		_x8d54381b90e4e4be.Add(x990d54f34b2b5119);
		x4a99bef71891200a(x990d54f34b2b5119);
		_x8438cfc2d3232fce = true;
		return x990d54f34b2b5119;
	}

	private x990d54f34b2b5118 x390dc73308f9d6a4(string x3552faf698c930ac, string xc01c2c674843ccdf, x229eb9e812ff9ad5 xab8fe3cd8c5556fb)
	{
		if (xc01c2c674843ccdf == null)
		{
			xc01c2c674843ccdf = "";
		}
		return x390dc73308f9d6a4(x3552faf698c930ac, xc01c2c674843ccdf, xab8fe3cd8c5556fb, 0);
	}

	private x990d54f34b2b5118 x390dc73308f9d6a4(string x3552faf698c930ac, string xc01c2c674843ccdf, x229eb9e812ff9ad5 xab8fe3cd8c5556fb, int x66bbd7ed8c65740d)
	{
		if (x0ede19c87c5fb089)
		{
			x44102a7f72bfea16.WriteLine("{0} {1}...", (xab8fe3cd8c5556fb == x229eb9e812ff9ad5.xc3cfa600943a8c42) ? "adding" : "Adding or updating", x3552faf698c930ac);
		}
		if (x66bbd7ed8c65740d == 0)
		{
			xdf2b7bedfa9b30d1();
		}
		string text = xc01c2c674843ccdf;
		x990d54f34b2b5118 x990d54f34b2b5119 = null;
		if (x66bbd7ed8c65740d > 0)
		{
			int num = x3552faf698c930ac.Length;
			for (int num2 = x66bbd7ed8c65740d; num2 > 0; num2--)
			{
				num = x3552faf698c930ac.LastIndexOfAny("/\\".ToCharArray(), num - 1, num - 1);
			}
			text = x3552faf698c930ac.Substring(num + 1);
			text = Path.Combine(xc01c2c674843ccdf, text);
		}
		if (x66bbd7ed8c65740d > 0 || xc01c2c674843ccdf != "")
		{
			x990d54f34b2b5119 = x990d54f34b2b5118.xebcf83b00134300b(x3552faf698c930ac, text);
			x990d54f34b2b5119.xbfe2d4ca3e43b779 = xbfe2d4ca3e43b779;
			x990d54f34b2b5119.xa1404b84036ecc66();
			x990d54f34b2b5119._xe2a6c1b66e699ef3 = this;
			x990d54f34b2b5118 x990d54f34b2b5120 = this.get_xe6d4b1b411ed94b5(x990d54f34b2b5119.xa39af5a82860a9a3);
			if (x990d54f34b2b5120 == null)
			{
				_x8d54381b90e4e4be.Add(x990d54f34b2b5119);
				_x8438cfc2d3232fce = true;
			}
			text = x990d54f34b2b5119.xa39af5a82860a9a3;
		}
		string[] files = Directory.GetFiles(x3552faf698c930ac);
		string[] array = files;
		foreach (string xafe2f3653ee64ebc in array)
		{
			if (xab8fe3cd8c5556fb == x229eb9e812ff9ad5.xc3cfa600943a8c42)
			{
				x73012fc1567819ef(xafe2f3653ee64ebc, text);
			}
			else
			{
				x28987ba977bfeff0(xafe2f3653ee64ebc, text);
			}
		}
		string[] directories = Directory.GetDirectories(x3552faf698c930ac);
		string[] array2 = directories;
		foreach (string x3552faf698c930ac2 in array2)
		{
			x390dc73308f9d6a4(x3552faf698c930ac2, xc01c2c674843ccdf, xab8fe3cd8c5556fb, x66bbd7ed8c65740d + 1);
		}
		if (x66bbd7ed8c65740d == 0)
		{
			x2015294c9e902f6a();
		}
		return x990d54f34b2b5119;
	}

	public static bool x2b3aa5eb4daf890d(string xa8068803bce540d2)
	{
		ArrayList x74133ad33ffdf;
		return x2b3aa5eb4daf890d(xa8068803bce540d2, xc51eae60e7116bd1: false, out x74133ad33ffdf);
	}

	public static bool x2b3aa5eb4daf890d(string xa8068803bce540d2, bool xc51eae60e7116bd1, out ArrayList x74133ad33ffdf023)
	{
		ArrayList arrayList = new ArrayList();
		xef4b7685c2495ff2 xef4b7685c2495ff3 = null;
		xef4b7685c2495ff2 xef4b7685c2495ff4 = null;
		bool flag = true;
		try
		{
			xef4b7685c2495ff3 = new xef4b7685c2495ff2();
			xef4b7685c2495ff3.xebb0a1fa72b779dc = true;
			xef4b7685c2495ff3.x20aee281977480cf(xa8068803bce540d2);
			xef4b7685c2495ff4 = x06b0e25aa6ad68a9(xa8068803bce540d2);
			foreach (x990d54f34b2b5118 item in (IEnumerable)xef4b7685c2495ff3)
			{
				foreach (x990d54f34b2b5118 item2 in (IEnumerable)xef4b7685c2495ff4)
				{
					if (item.xa39af5a82860a9a3 == item2.xa39af5a82860a9a3)
					{
						if (item._x7e322ff037b992c9 != item2._x7e322ff037b992c9)
						{
							flag = false;
							arrayList.Add(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nbkapmabjbibdnobglfcaancjpddaaldhpbeioieippeeogfgonfljegbolgdochcjjhbmaibnhifnoihmfjhnmjjmdkdnkkplblgkilklplhlgmbmnmalenmllnejcoikjoliaplkhpmjophjfapjmaihdbcjkblibcliicjipcdjgdodndldeeaelefecfkijfkiagndhgdeogoffhedmhgddikhkikbbjibijbdpjbbgkobnkdgeldgllhbcmmbjmhdannahnpaondffomplo", 2066483618)), item.xa39af5a82860a9a3, item._x7e322ff037b992c9, item2._x7e322ff037b992c9));
						}
						if (item._x9a0049934ff5530a != item2._x9a0049934ff5530a)
						{
							flag = false;
							arrayList.Add(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cgaiebhiofoiibfjlpljfedkodkkfeblmdilncplndgmjcnmlcenaokngccoicjohnpohpgpacoplbfalbmakbdbkakbfbbccbicbapcnpfdjomdmpdekalecpbfkkifhkpfmkggblnggpehgplhjkcipkjikmajakhjckojgofkgimkeidlnjklnhbmkiimpmpmpmgndinniieodklojhcplhjpplaaigha", 555712487)), item.xa39af5a82860a9a3, item._x9a0049934ff5530a, item2._x9a0049934ff5530a));
						}
						if (item._xc49fe6a8d63d6783 != item2._xc49fe6a8d63d6783)
						{
							flag = false;
							arrayList.Add(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jcdolnjofcbppnhpcmopmagafanamaebdalbepbceajcappccpgdhkndnoeepoleojcfanjfgoaginhgboogmnfhmnmhlndilmkignbjdnijcmpjolgkkknknlellmlldlcmlgjmigannghnchonhlfohlmokgdpahkplibabgiadgpahkgbhenbfeecoflcodcdlejdajaeajheeeoejeffegmfkddgmdkgaibhjcih", 978838190)), item.xa39af5a82860a9a3, item._xc49fe6a8d63d6783, item2._xc49fe6a8d63d6783));
						}
						if (item.x93f6dc9bc169b40a != item2.x93f6dc9bc169b40a)
						{
							flag = false;
							arrayList.Add(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kogcmjncgoedaklddicenmjegmafnmhfemofflfgfmmgbldhdlkhigbiokiialpipfgjphnjikekdklkdkclckjlcjamnjhmkjomnifnajmnmidoigkonhbpjiipkhppohgaahnajcebgclblcccadjcfhadfhhdicodocfejemeccdfigkfiabggaigpbpgppfhmanhbfeibflifacjkajjfcakopgkeeoknoel", 806299247)), item.xa39af5a82860a9a3, item.x93f6dc9bc169b40a, item2.x93f6dc9bc169b40a));
						}
						if (item.x4267aa67a0bb35b8 != item2.x4267aa67a0bb35b8)
						{
							flag = false;
							arrayList.Add(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jdcjloijfdakpogkcnnkmbflfbmlmbdmdbkmeabnebinaapncagohlmonpdpppkpokbaomiakppaiogbflnbblecmjlcjjcdojjddkaeioheiooeljffbkmfmldgfjkglnbhlhihjhphcjgichniphejemljemckihjknhalijhlbholhlfmagmm", 2075103678)), item.xa39af5a82860a9a3, item.x4267aa67a0bb35b8, item2.x4267aa67a0bb35b8));
						}
						break;
					}
				}
			}
			xef4b7685c2495ff4.Dispose();
			xef4b7685c2495ff4 = null;
			if (!flag && xc51eae60e7116bd1)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(xa8068803bce540d2);
				fileNameWithoutExtension = $"{fileNameWithoutExtension}_fixed.zip";
				xef4b7685c2495ff3.x0acd3c2012ea2ee8(fileNameWithoutExtension);
			}
		}
		finally
		{
			xef4b7685c2495ff3?.Dispose();
			xef4b7685c2495ff4?.Dispose();
		}
		x74133ad33ffdf023 = arrayList;
		return flag;
	}

	public static void x506d98708c61779e(string xa8068803bce540d2)
	{
		using xef4b7685c2495ff2 xef4b7685c2495ff3 = new xef4b7685c2495ff2();
		xef4b7685c2495ff3.xebb0a1fa72b779dc = true;
		xef4b7685c2495ff3.x20aee281977480cf(xa8068803bce540d2);
		xef4b7685c2495ff3.x0acd3c2012ea2ee8(xa8068803bce540d2);
	}

	internal bool x3d39c7856be9a966(x990d54f34b2b5118 xa85f9dbcec37a9e8, long x2c753a2e97e475c8, long x0967b3fb9ec238c0)
	{
		if (this.xb2dd73e958fd0aad != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				x3c933dd351cac3e2 x3c933dd351cac3e3 = x3c933dd351cac3e2.x810c3600b79742ed(x7d7b99da208c34de, xa85f9dbcec37a9e8, x2c753a2e97e475c8, x0967b3fb9ec238c0);
				this.xb2dd73e958fd0aad(this, x3c933dd351cac3e3);
				if (x3c933dd351cac3e3.xd674415062c2b55f)
				{
					_xf24acc83b64952af = true;
				}
			}
		}
		return _xf24acc83b64952af;
	}

	private void x6c1d876931225026(int x3bd62873fafa6252, x990d54f34b2b5118 xa85f9dbcec37a9e8, bool x6b161b1ae41c1651)
	{
		if (this.xb2dd73e958fd0aad == null)
		{
			return;
		}
		lock (x8b9ab1471acb7ac8)
		{
			x3c933dd351cac3e2 x3c933dd351cac3e3 = new x3c933dd351cac3e2(x7d7b99da208c34de, x6b161b1ae41c1651, _x8d54381b90e4e4be.Count, x3bd62873fafa6252, xa85f9dbcec37a9e8);
			this.xb2dd73e958fd0aad(this, x3c933dd351cac3e3);
			if (x3c933dd351cac3e3.xd674415062c2b55f)
			{
				_xf24acc83b64952af = true;
			}
		}
	}

	private void x601246dcfeb81172(xebcb692fc67da2dc x4de75ceeb62d50ba)
	{
		if (this.xb2dd73e958fd0aad == null)
		{
			return;
		}
		lock (x8b9ab1471acb7ac8)
		{
			x3c933dd351cac3e2 x3c933dd351cac3e3 = new x3c933dd351cac3e2(x7d7b99da208c34de, x4de75ceeb62d50ba);
			this.xb2dd73e958fd0aad(this, x3c933dd351cac3e3);
			if (x3c933dd351cac3e3.xd674415062c2b55f)
			{
				_xf24acc83b64952af = true;
			}
		}
	}

	private void x3d76d3bd598aa0e2()
	{
		if (this.xb2dd73e958fd0aad != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				x3c933dd351cac3e2 e = x3c933dd351cac3e2.x33ea497bc266278e(x7d7b99da208c34de);
				this.xb2dd73e958fd0aad(this, e);
			}
		}
	}

	private void x4d4097a1420ad701()
	{
		if (this.xb2dd73e958fd0aad != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				x3c933dd351cac3e2 e = x3c933dd351cac3e2.x8720d4da1213e1b9(x7d7b99da208c34de);
				this.xb2dd73e958fd0aad(this, e);
			}
		}
	}

	private void x71dba75f2ca61dad()
	{
		if (this.x4dd5eca2ff04651e != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				x73bda272ab42064e e = x73bda272ab42064e.x33ea497bc266278e(x7d7b99da208c34de);
				this.x4dd5eca2ff04651e(this, e);
			}
		}
	}

	private void x2815e8295da7002e()
	{
		if (this.x4dd5eca2ff04651e != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				x73bda272ab42064e e = x73bda272ab42064e.x8720d4da1213e1b9(x7d7b99da208c34de);
				this.x4dd5eca2ff04651e(this, e);
			}
		}
	}

	internal void xe49b76645b9cc6d4(x990d54f34b2b5118 xa85f9dbcec37a9e8)
	{
		if (this.x4dd5eca2ff04651e != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				x73bda272ab42064e e = x73bda272ab42064e.x810c3600b79742ed(x7d7b99da208c34de, xa85f9dbcec37a9e8, x53cce0b6abbd65ad.Position, x521bcb9045add5a5);
				this.x4dd5eca2ff04651e(this, e);
			}
		}
	}

	internal void xc7a7b7e4ce2ebb52(bool x6b161b1ae41c1651, x990d54f34b2b5118 xa85f9dbcec37a9e8)
	{
		if (this.x4dd5eca2ff04651e != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				x73bda272ab42064e e = (x6b161b1ae41c1651 ? x73bda272ab42064e.x0364c07ad4dcfe0c(x7d7b99da208c34de, _x8d54381b90e4e4be.Count) : x73bda272ab42064e.x851fcfc17df82b1b(x7d7b99da208c34de, xa85f9dbcec37a9e8, _x8d54381b90e4e4be.Count));
				this.x4dd5eca2ff04651e(this, e);
			}
		}
	}

	private void x0ac6f86e19407f92(int x3bd62873fafa6252, bool x6b161b1ae41c1651, x990d54f34b2b5118 xb40575d88ee3be24, string xe125219852864557)
	{
		if (this.x13eca3064073eb76 == null)
		{
			return;
		}
		lock (x8b9ab1471acb7ac8)
		{
			xa868b79ba8321134 xa868b79ba8321135 = new xa868b79ba8321134(x7d7b99da208c34de, x6b161b1ae41c1651, _x8d54381b90e4e4be.Count, x3bd62873fafa6252, xb40575d88ee3be24, xe125219852864557);
			this.x13eca3064073eb76(this, xa868b79ba8321135);
			if (xa868b79ba8321135.xd674415062c2b55f)
			{
				_xc43789532026e0d8 = true;
			}
		}
	}

	internal bool xa9f57747a0117270(x990d54f34b2b5118 xa85f9dbcec37a9e8, long xa289f275e6a0e493, long x985b78aab437c0a4)
	{
		if (this.x13eca3064073eb76 != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				xa868b79ba8321134 xa868b79ba8321135 = xa868b79ba8321134.x810c3600b79742ed(x7d7b99da208c34de, xa85f9dbcec37a9e8, xa289f275e6a0e493, x985b78aab437c0a4);
				this.x13eca3064073eb76(this, xa868b79ba8321135);
				if (xa868b79ba8321135.xd674415062c2b55f)
				{
					_xc43789532026e0d8 = true;
				}
			}
		}
		return _xc43789532026e0d8;
	}

	internal bool x0f32cc2a7f373e11(x990d54f34b2b5118 xa85f9dbcec37a9e8, string xe125219852864557, bool x6b161b1ae41c1651)
	{
		if (this.x13eca3064073eb76 != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				xa868b79ba8321134 xa868b79ba8321135 = (x6b161b1ae41c1651 ? xa868b79ba8321134.x1ccdcfc50fc8094b(x7d7b99da208c34de, xa85f9dbcec37a9e8, xe125219852864557) : xa868b79ba8321134.xef226bd78eb54e44(x7d7b99da208c34de, xa85f9dbcec37a9e8, xe125219852864557));
				this.x13eca3064073eb76(this, xa868b79ba8321135);
				if (xa868b79ba8321135.xd674415062c2b55f)
				{
					_xc43789532026e0d8 = true;
				}
			}
		}
		return _xc43789532026e0d8;
	}

	internal bool xeac40bb76c9d449c(x990d54f34b2b5118 xa85f9dbcec37a9e8, string xe125219852864557)
	{
		if (this.x13eca3064073eb76 != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				xa868b79ba8321134 xa868b79ba8321135 = xa868b79ba8321134.x797b2b19a35518a2(x7d7b99da208c34de, xa85f9dbcec37a9e8, xe125219852864557);
				this.x13eca3064073eb76(this, xa868b79ba8321135);
				if (xa868b79ba8321135.xd674415062c2b55f)
				{
					_xc43789532026e0d8 = true;
				}
			}
		}
		return _xc43789532026e0d8;
	}

	private void x2bcde0e3a8bf69c0(string xe125219852864557)
	{
		if (this.x13eca3064073eb76 != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				xa868b79ba8321134 e = xa868b79ba8321134.x9fd800ad20179936(x7d7b99da208c34de, xe125219852864557);
				this.x13eca3064073eb76(this, e);
			}
		}
	}

	private void x725df40c629339f9(string xe125219852864557)
	{
		if (this.x13eca3064073eb76 != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				xa868b79ba8321134 e = xa868b79ba8321134.x0427e5a99767f7ae(x7d7b99da208c34de, xe125219852864557);
				this.x13eca3064073eb76(this, e);
			}
		}
	}

	private void xdf2b7bedfa9b30d1()
	{
		if (this.x15e31e322a1755a5 != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				xd5bee79cf4d63c22 e = xd5bee79cf4d63c22.x33ea497bc266278e(x7d7b99da208c34de);
				this.x15e31e322a1755a5(this, e);
			}
		}
	}

	private void x2015294c9e902f6a()
	{
		if (this.x15e31e322a1755a5 != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				xd5bee79cf4d63c22 e = xd5bee79cf4d63c22.x8720d4da1213e1b9(x7d7b99da208c34de);
				this.x15e31e322a1755a5(this, e);
			}
		}
	}

	internal void x4a99bef71891200a(x990d54f34b2b5118 xa85f9dbcec37a9e8)
	{
		if (this.x15e31e322a1755a5 != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				xd5bee79cf4d63c22 e = xd5bee79cf4d63c22.x6b35c7c7a764a7df(x7d7b99da208c34de, xa85f9dbcec37a9e8, _x8d54381b90e4e4be.Count);
				this.x15e31e322a1755a5(this, e);
			}
		}
	}

	internal bool x3cc81d04188e90c3(x990d54f34b2b5118 xa85f9dbcec37a9e8, Exception x6c8f5b3694a8d059)
	{
		if (this.x5c6b3834a3ae2756 != null)
		{
			lock (x8b9ab1471acb7ac8)
			{
				xcded98fcf8e0940d xcded98fcf8e0940d2 = xcded98fcf8e0940d.xa4a1db013281eb43(x759aa16c2016a289, xa85f9dbcec37a9e8, x6c8f5b3694a8d059);
				this.x5c6b3834a3ae2756(this, xcded98fcf8e0940d2);
				if (xcded98fcf8e0940d2.xd674415062c2b55f)
				{
					_xf24acc83b64952af = true;
				}
			}
		}
		return _xf24acc83b64952af;
	}

	public void xae7b3e3fe94c1b55(string xe125219852864557)
	{
		_xc202c904d294ffc5(xe125219852864557, x8ba22b8b2b1de5aa: true);
	}

	[Obsolete("Please use property ExtractExistingFile to specify overwrite behavior)")]
	public void xae7b3e3fe94c1b55(string xe125219852864557, bool xace9b24ed47b9f83)
	{
		xec3a126a0abb0cbf = (xace9b24ed47b9f83 ? x8859214cc4c1cfab.xf4b7fc58735e7b0b : x8859214cc4c1cfab.x643d287ae28d7eef);
		_xc202c904d294ffc5(xe125219852864557, x8ba22b8b2b1de5aa: true);
	}

	public void xae7b3e3fe94c1b55(string xe125219852864557, x8859214cc4c1cfab x72e58d297dd6036f)
	{
		xec3a126a0abb0cbf = x72e58d297dd6036f;
		_xc202c904d294ffc5(xe125219852864557, x8ba22b8b2b1de5aa: true);
	}

	private void _xc202c904d294ffc5(string xe125219852864557, bool x8ba22b8b2b1de5aa)
	{
		bool flag = x0ede19c87c5fb089;
		_x1cc53e92d902f0a4 = true;
		try
		{
			x725df40c629339f9(xe125219852864557);
			int num = 0;
			foreach (x990d54f34b2b5118 item in _x8d54381b90e4e4be)
			{
				if (flag)
				{
					x44102a7f72bfea16.WriteLine("\n{1,-22} {2,-8} {3,4}   {4,-8}  {0}", "Name", "Modified", "Size", "Ratio", "Packed");
					x44102a7f72bfea16.WriteLine(new string('-', 72));
					flag = false;
				}
				if (x0ede19c87c5fb089)
				{
					x44102a7f72bfea16.WriteLine("{1,-22} {2,-8} {3,4:F0}%   {4,-8} {0}", item.xa39af5a82860a9a3, item.xf3d2608616d7641a.ToString("yyyy-MM-dd HH:mm:ss"), item.xc49fe6a8d63d6783, item.xe474cb2a9795d184, item.x9a0049934ff5530a);
					if (item.x937e050c63ea1527 != null && item.x937e050c63ea1527.Length > 0)
					{
						x44102a7f72bfea16.WriteLine("  Comment: {0}", item.x937e050c63ea1527);
					}
				}
				item.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
				x0ac6f86e19407f92(num, x6b161b1ae41c1651: true, item, xe125219852864557);
				if (x8ba22b8b2b1de5aa)
				{
					item.xec3a126a0abb0cbf = xec3a126a0abb0cbf;
				}
				item.xf098323036d9ec26(xe125219852864557);
				num++;
				x0ac6f86e19407f92(num, x6b161b1ae41c1651: false, item, xe125219852864557);
				if (_xc43789532026e0d8)
				{
					break;
				}
			}
			foreach (x990d54f34b2b5118 item2 in _x8d54381b90e4e4be)
			{
				if (item2.x4d1990cadac28b9b || item2.xa39af5a82860a9a3.EndsWith("/"))
				{
					string xd9c131b42e8fc = (item2.xa39af5a82860a9a3.StartsWith("/") ? Path.Combine(xe125219852864557, item2.xa39af5a82860a9a3.Substring(1)) : Path.Combine(xe125219852864557, item2.xa39af5a82860a9a3));
					item2._x68a68a69ffbcc657(xd9c131b42e8fc, xf0e19df7b6a7c8a4: false);
				}
			}
			x2bcde0e3a8bf69c0(xe125219852864557);
		}
		finally
		{
			_x1cc53e92d902f0a4 = false;
		}
	}

	[Obsolete("Please use method ZipEntry.Extract()")]
	public void xf098323036d9ec26(string xafe2f3653ee64ebc)
	{
		x990d54f34b2b5118 x990d54f34b2b5119 = this.get_xe6d4b1b411ed94b5(xafe2f3653ee64ebc);
		if (xec3a126a0abb0cbf != 0)
		{
			x990d54f34b2b5119.xec3a126a0abb0cbf = xec3a126a0abb0cbf;
		}
		x990d54f34b2b5119.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
		x990d54f34b2b5119.xf098323036d9ec26();
	}

	[Obsolete("Please use method ZipEntry.Extract(string)")]
	public void xf098323036d9ec26(string x5aab96eff9e479ec, string x3552faf698c930ac)
	{
		x990d54f34b2b5118 x990d54f34b2b5119 = this.get_xe6d4b1b411ed94b5(x5aab96eff9e479ec);
		if (xec3a126a0abb0cbf != 0)
		{
			x990d54f34b2b5119.xec3a126a0abb0cbf = xec3a126a0abb0cbf;
		}
		x990d54f34b2b5119.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
		x990d54f34b2b5119.xf098323036d9ec26(x3552faf698c930ac);
	}

	[Obsolete("Please use method ZipEntry.Extract(ExtractExistingFileAction)")]
	public void xf098323036d9ec26(string x5aab96eff9e479ec, bool xace9b24ed47b9f83)
	{
		x990d54f34b2b5118 x990d54f34b2b5119 = this.get_xe6d4b1b411ed94b5(x5aab96eff9e479ec);
		x990d54f34b2b5119.xec3a126a0abb0cbf = (xace9b24ed47b9f83 ? x8859214cc4c1cfab.xf4b7fc58735e7b0b : x8859214cc4c1cfab.x643d287ae28d7eef);
		x990d54f34b2b5119.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
		x990d54f34b2b5119.xf098323036d9ec26(Directory.GetCurrentDirectory());
	}

	[Obsolete("Please use method ZipEntry.Extract(ExtractExistingFileAction)")]
	public void xf098323036d9ec26(string x5aab96eff9e479ec, x8859214cc4c1cfab x72e58d297dd6036f)
	{
		x990d54f34b2b5118 x990d54f34b2b5119 = this.get_xe6d4b1b411ed94b5(x5aab96eff9e479ec);
		x990d54f34b2b5119.xec3a126a0abb0cbf = x72e58d297dd6036f;
		x990d54f34b2b5119.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
		x990d54f34b2b5119.xf098323036d9ec26(Directory.GetCurrentDirectory());
	}

	[Obsolete("Please use method ZipEntry.Extract(String,ExtractExistingFileAction)")]
	public void xf098323036d9ec26(string x5aab96eff9e479ec, string x3552faf698c930ac, bool xace9b24ed47b9f83)
	{
		x990d54f34b2b5118 x990d54f34b2b5119 = this.get_xe6d4b1b411ed94b5(x5aab96eff9e479ec);
		x990d54f34b2b5119.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
		x990d54f34b2b5119.xec3a126a0abb0cbf = (xace9b24ed47b9f83 ? x8859214cc4c1cfab.xf4b7fc58735e7b0b : x8859214cc4c1cfab.x643d287ae28d7eef);
		x990d54f34b2b5119.xf098323036d9ec26(x3552faf698c930ac);
	}

	[Obsolete("Please use method ZipEntry.Extract(string, ExtractExistingFileAction)")]
	public void xf098323036d9ec26(string x5aab96eff9e479ec, string x3552faf698c930ac, x8859214cc4c1cfab x72e58d297dd6036f)
	{
		x990d54f34b2b5118 x990d54f34b2b5119 = this.get_xe6d4b1b411ed94b5(x5aab96eff9e479ec);
		x990d54f34b2b5119.xec3a126a0abb0cbf = x72e58d297dd6036f;
		x990d54f34b2b5119.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
		x990d54f34b2b5119.xf098323036d9ec26(x3552faf698c930ac);
	}

	[Obsolete("Please use method ZipEntry.Extract(Stream)")]
	public void xf098323036d9ec26(string x5aab96eff9e479ec, Stream xf823f0edaa261f3b)
	{
		if (xf823f0edaa261f3b == null || !xf823f0edaa261f3b.CanWrite)
		{
			throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oipajkgbdlnbalecoklcalcdjfjdljaelkheekoepjfflimfkidgijkgpebh", 981995339)), new ArgumentException("The OutputStream must be a writable stream.", "outputStream"));
		}
		if (x5aab96eff9e479ec == null || x5aab96eff9e479ec.Length == 0)
		{
			throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nhapijhpckoppjfanjmapjdbiekbkibckjicdjpcoigdkhndjheehileodcf", 1338372154)), new ArgumentException("The file name must be neither null nor empty.", "entryName"));
		}
		x990d54f34b2b5118 x990d54f34b2b5119 = this.get_xe6d4b1b411ed94b5(x5aab96eff9e479ec);
		x990d54f34b2b5119.xa4bc2af2b58881c8 = _xa4bc2af2b58881c8;
		x990d54f34b2b5119.xf098323036d9ec26(xf823f0edaa261f3b);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(string xafe2f3653ee64ebc)
	{
		return x06b0e25aa6ad68a9(xafe2f3653ee64ebc, null, x24500e9782c41ba0);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(string xafe2f3653ee64ebc, EventHandler xaa5395229058f5c6)
	{
		return x06b0e25aa6ad68a9(xafe2f3653ee64ebc, null, x24500e9782c41ba0, xaa5395229058f5c6);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(string xafe2f3653ee64ebc, TextWriter x36a868b32d278eb7)
	{
		return x06b0e25aa6ad68a9(xafe2f3653ee64ebc, x36a868b32d278eb7, x24500e9782c41ba0);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(string xafe2f3653ee64ebc, TextWriter x36a868b32d278eb7, EventHandler xaa5395229058f5c6)
	{
		return x06b0e25aa6ad68a9(xafe2f3653ee64ebc, x36a868b32d278eb7, x24500e9782c41ba0, xaa5395229058f5c6);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(string xafe2f3653ee64ebc, Encoding xff3edc9aa5f0523b)
	{
		return x06b0e25aa6ad68a9(xafe2f3653ee64ebc, null, xff3edc9aa5f0523b);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(string xafe2f3653ee64ebc, Encoding xff3edc9aa5f0523b, EventHandler xaa5395229058f5c6)
	{
		return x06b0e25aa6ad68a9(xafe2f3653ee64ebc, null, xff3edc9aa5f0523b, xaa5395229058f5c6);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(string xafe2f3653ee64ebc, TextWriter x36a868b32d278eb7, Encoding xff3edc9aa5f0523b)
	{
		return x06b0e25aa6ad68a9(xafe2f3653ee64ebc, x36a868b32d278eb7, xff3edc9aa5f0523b, null);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(string xafe2f3653ee64ebc, TextWriter x36a868b32d278eb7, Encoding xff3edc9aa5f0523b, EventHandler xaa5395229058f5c6)
	{
		xef4b7685c2495ff2 xef4b7685c2495ff3 = new xef4b7685c2495ff2();
		xef4b7685c2495ff3.xbfe2d4ca3e43b779 = xff3edc9aa5f0523b;
		xef4b7685c2495ff3._x44102a7f72bfea16 = x36a868b32d278eb7;
		xef4b7685c2495ff3._xc15bd84e01929885 = xafe2f3653ee64ebc;
		if (xaa5395229058f5c6 != null)
		{
			xef4b7685c2495ff3.x4dd5eca2ff04651e = xaa5395229058f5c6;
		}
		if (xef4b7685c2495ff3.x0ede19c87c5fb089)
		{
			xef4b7685c2495ff3._x44102a7f72bfea16.WriteLine("reading from {0}...", xafe2f3653ee64ebc);
		}
		try
		{
			x9f6a941ab884bab8(xef4b7685c2495ff3);
			xef4b7685c2495ff3._x6d56bb4f9166f4bf = true;
			return xef4b7685c2495ff3;
		}
		catch (Exception innerException)
		{
			throw new xc5e345d2a919c94b($"{xafe2f3653ee64ebc} could not be read", innerException);
		}
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(Stream xb4b4757248084bd0)
	{
		return x06b0e25aa6ad68a9(xb4b4757248084bd0, null, x24500e9782c41ba0);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(Stream xb4b4757248084bd0, EventHandler xaa5395229058f5c6)
	{
		return x06b0e25aa6ad68a9(xb4b4757248084bd0, null, x24500e9782c41ba0, xaa5395229058f5c6);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(Stream xb4b4757248084bd0, TextWriter x36a868b32d278eb7)
	{
		return x06b0e25aa6ad68a9(xb4b4757248084bd0, x36a868b32d278eb7, x24500e9782c41ba0);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(Stream xb4b4757248084bd0, TextWriter x36a868b32d278eb7, EventHandler xaa5395229058f5c6)
	{
		return x06b0e25aa6ad68a9(xb4b4757248084bd0, x36a868b32d278eb7, x24500e9782c41ba0, xaa5395229058f5c6);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(Stream xb4b4757248084bd0, Encoding xff3edc9aa5f0523b)
	{
		return x06b0e25aa6ad68a9(xb4b4757248084bd0, null, xff3edc9aa5f0523b);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(Stream xb4b4757248084bd0, Encoding xff3edc9aa5f0523b, EventHandler xaa5395229058f5c6)
	{
		return x06b0e25aa6ad68a9(xb4b4757248084bd0, null, xff3edc9aa5f0523b, xaa5395229058f5c6);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(Stream xb4b4757248084bd0, TextWriter x36a868b32d278eb7, Encoding xff3edc9aa5f0523b)
	{
		return x06b0e25aa6ad68a9(xb4b4757248084bd0, x36a868b32d278eb7, xff3edc9aa5f0523b, null);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(Stream xb4b4757248084bd0, TextWriter x36a868b32d278eb7, Encoding xff3edc9aa5f0523b, EventHandler xaa5395229058f5c6)
	{
		if (xb4b4757248084bd0 == null)
		{
			throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jpodebgeobnelbefjblflbcgemigdbahdahhmpnhmpeidmli", 1966030518)), new ArgumentException("The stream must be non-null", "zipStream"));
		}
		xef4b7685c2495ff2 xef4b7685c2495ff3 = new xef4b7685c2495ff2();
		xef4b7685c2495ff3._x569440e5ccedf43e = xff3edc9aa5f0523b;
		if (xaa5395229058f5c6 != null)
		{
			xef4b7685c2495ff3.x4dd5eca2ff04651e = (EventHandler)Delegate.Combine(xef4b7685c2495ff3.x4dd5eca2ff04651e, xaa5395229058f5c6);
		}
		xef4b7685c2495ff3._x44102a7f72bfea16 = x36a868b32d278eb7;
		xef4b7685c2495ff3._xb9a61312065e93e4 = xb4b4757248084bd0;
		xef4b7685c2495ff3._xc2906194e8646892 = false;
		if (xef4b7685c2495ff3.x0ede19c87c5fb089)
		{
			xef4b7685c2495ff3._x44102a7f72bfea16.WriteLine("reading from stream...");
		}
		x9f6a941ab884bab8(xef4b7685c2495ff3);
		return xef4b7685c2495ff3;
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(byte[] x5cafa8d49ea71ea1)
	{
		return x06b0e25aa6ad68a9(x5cafa8d49ea71ea1, null, x24500e9782c41ba0);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(byte[] x5cafa8d49ea71ea1, TextWriter x36a868b32d278eb7)
	{
		return x06b0e25aa6ad68a9(x5cafa8d49ea71ea1, x36a868b32d278eb7, x24500e9782c41ba0);
	}

	public static xef4b7685c2495ff2 x06b0e25aa6ad68a9(byte[] x5cafa8d49ea71ea1, TextWriter x36a868b32d278eb7, Encoding xff3edc9aa5f0523b)
	{
		xef4b7685c2495ff2 xef4b7685c2495ff3 = new xef4b7685c2495ff2();
		xef4b7685c2495ff3._x44102a7f72bfea16 = x36a868b32d278eb7;
		xef4b7685c2495ff3._x569440e5ccedf43e = xff3edc9aa5f0523b;
		xef4b7685c2495ff3._xb9a61312065e93e4 = new MemoryStream(x5cafa8d49ea71ea1);
		xef4b7685c2495ff3._xc2906194e8646892 = true;
		if (xef4b7685c2495ff3.x0ede19c87c5fb089)
		{
			xef4b7685c2495ff3._x44102a7f72bfea16.WriteLine("reading from byte[]...");
		}
		x9f6a941ab884bab8(xef4b7685c2495ff3);
		return xef4b7685c2495ff3;
	}

	private static void x9f6a941ab884bab8(xef4b7685c2495ff2 x2fe8f0c48ba61aee)
	{
		Stream stream = x2fe8f0c48ba61aee.x53cce0b6abbd65ad;
		try
		{
			if (!stream.CanSeek)
			{
				xa5f0fc26f0a1f84f(x2fe8f0c48ba61aee);
				return;
			}
			x2fe8f0c48ba61aee.x71dba75f2ca61dad();
			x2fe8f0c48ba61aee._x65ba13a854a4213e = stream.Position;
			uint num = xafad334affdebd0b(stream);
			if (num == 101010256)
			{
				return;
			}
			int num2 = 0;
			bool flag = false;
			long num3 = stream.Length - 64;
			long num4 = Math.Max(stream.Length - 16384, 10L);
			do
			{
				stream.Seek(num3, SeekOrigin.Begin);
				long num5 = x977b5605864b2047.xdf477cba9c46e9dc(stream, 101010256);
				if (num5 != -1)
				{
					flag = true;
					continue;
				}
				num2++;
				num3 -= 32 * (num2 + 1) * num2;
				if (num3 < 0)
				{
					num3 = 0L;
				}
			}
			while (!flag && num3 > num4);
			if (flag)
			{
				x2fe8f0c48ba61aee._xe0a94e4535ae92fa = stream.Position - 4;
				byte[] array = new byte[16];
				x2fe8f0c48ba61aee.x53cce0b6abbd65ad.Read(array, 0, array.Length);
				int num6 = 12;
				uint num7 = (uint)(array[num6++] + array[num6++] * 256 + array[num6++] * 256 * 256 + array[num6++] * 256 * 256 * 256);
				if (num7 == uint.MaxValue)
				{
					xda2c82689973f2de(x2fe8f0c48ba61aee);
				}
				else
				{
					x2fe8f0c48ba61aee.xd0c948b79c880a6b(num7);
				}
				x7716fc67b6df3585(x2fe8f0c48ba61aee);
			}
			else
			{
				stream.Seek(x2fe8f0c48ba61aee._x65ba13a854a4213e, SeekOrigin.Begin);
				xa5f0fc26f0a1f84f(x2fe8f0c48ba61aee);
			}
		}
		catch
		{
			if (x2fe8f0c48ba61aee._xc2906194e8646892 && x2fe8f0c48ba61aee._xb9a61312065e93e4 != null)
			{
				x2fe8f0c48ba61aee._xb9a61312065e93e4.Close();
				x2fe8f0c48ba61aee._xb9a61312065e93e4 = null;
			}
			throw;
		}
		x2fe8f0c48ba61aee._x8438cfc2d3232fce = false;
	}

	private static void xda2c82689973f2de(xef4b7685c2495ff2 x2fe8f0c48ba61aee)
	{
		Stream stream = x2fe8f0c48ba61aee.x53cce0b6abbd65ad;
		byte[] array = new byte[16];
		stream.Seek(-40L, SeekOrigin.Current);
		stream.Read(array, 0, 16);
		long x13d4cb8d1bd = BitConverter.ToInt64(array, 8);
		x2fe8f0c48ba61aee.xd0c948b79c880a6b(x13d4cb8d1bd);
		uint num = (uint)x977b5605864b2047.xe5d393f0d1706f47(stream);
		if (num != 101075792)
		{
			throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("odojldfkchmkohdlciklffbmfhimfhpmlggnndnnkdeopelopfcpifjpifaajbhahboafcfbiambhcdcdekcdebdmphdmepdpdgekdneodefoclfodcgmdjggdahgchhonnhdoeiiolincdjnckjpnakgohkbapkonflacnljmdmnlkmgacngajndaaompgohpnojpeppolpfkcaiojaooaboohbjjobanfcmlmcamdddkkdojbehiiejkpeangfbknfpjegihlghkchhljhclaillhilloikkfjdgmjbkdkblkkkfblhkildkplekgmhjnmpjenbjlnejcoajjopdapmehpbjopbjfaeemakedbfgkbcebceiic", 1766956574)), num, stream.Position));
		}
		stream.Read(array, 0, 8);
		long num2 = BitConverter.ToInt64(array, 0);
		array = new byte[num2];
		stream.Read(array, 0, array.Length);
		x13d4cb8d1bd = BitConverter.ToInt64(array, 36);
		x2fe8f0c48ba61aee.xd0c948b79c880a6b(x13d4cb8d1bd);
	}

	private static uint xafad334affdebd0b(Stream xe4115acdf4fbfccc)
	{
		return (uint)x977b5605864b2047.xe5d393f0d1706f47(xe4115acdf4fbfccc);
	}

	private static void x7716fc67b6df3585(xef4b7685c2495ff2 x2fe8f0c48ba61aee)
	{
		x990d54f34b2b5118 x990d54f34b2b5119;
		while ((x990d54f34b2b5119 = x990d54f34b2b5118.x64da0b7f32fdd92e(x2fe8f0c48ba61aee)) != null)
		{
			x990d54f34b2b5119.xb6e3214af5a3f380();
			x2fe8f0c48ba61aee.xc7a7b7e4ce2ebb52(x6b161b1ae41c1651: true, null);
			if (x2fe8f0c48ba61aee.x0ede19c87c5fb089)
			{
				x2fe8f0c48ba61aee.x44102a7f72bfea16.WriteLine("entry {0}", x990d54f34b2b5119.xa39af5a82860a9a3);
			}
			x2fe8f0c48ba61aee._x8d54381b90e4e4be.Add(x990d54f34b2b5119);
		}
		if (x2fe8f0c48ba61aee._xe0a94e4535ae92fa > 0)
		{
			x2fe8f0c48ba61aee.xd0c948b79c880a6b(x2fe8f0c48ba61aee._xe0a94e4535ae92fa);
		}
		xe313817858c5c5e8(x2fe8f0c48ba61aee);
		if (x2fe8f0c48ba61aee.x0ede19c87c5fb089 && x2fe8f0c48ba61aee.x937e050c63ea1527 != null && x2fe8f0c48ba61aee.x937e050c63ea1527.Length > 0)
		{
			x2fe8f0c48ba61aee.x44102a7f72bfea16.WriteLine("Zip file Comment: {0}", x2fe8f0c48ba61aee.x937e050c63ea1527);
		}
		if (x2fe8f0c48ba61aee.x0ede19c87c5fb089)
		{
			x2fe8f0c48ba61aee.x44102a7f72bfea16.WriteLine("read in {0} entries.", x2fe8f0c48ba61aee._x8d54381b90e4e4be.Count);
		}
		x2fe8f0c48ba61aee.x2815e8295da7002e();
	}

	private static void xa5f0fc26f0a1f84f(xef4b7685c2495ff2 x2fe8f0c48ba61aee)
	{
		x2fe8f0c48ba61aee.x71dba75f2ca61dad();
		x2fe8f0c48ba61aee._x8d54381b90e4e4be = new ArrayList();
		if (x2fe8f0c48ba61aee.x0ede19c87c5fb089)
		{
			if (x2fe8f0c48ba61aee.x759aa16c2016a289 == null)
			{
				x2fe8f0c48ba61aee.x44102a7f72bfea16.WriteLine("Reading zip from stream...");
			}
			else
			{
				x2fe8f0c48ba61aee.x44102a7f72bfea16.WriteLine("Reading zip {0}...", x2fe8f0c48ba61aee.x759aa16c2016a289);
			}
		}
		bool x62584df2cb5d40dd = true;
		x990d54f34b2b5118 x990d54f34b2b5119;
		while ((x990d54f34b2b5119 = x990d54f34b2b5118.x06b0e25aa6ad68a9(x2fe8f0c48ba61aee, x62584df2cb5d40dd)) != null)
		{
			if (x2fe8f0c48ba61aee.x0ede19c87c5fb089)
			{
				x2fe8f0c48ba61aee.x44102a7f72bfea16.WriteLine("  {0}", x990d54f34b2b5119.xa39af5a82860a9a3);
			}
			x2fe8f0c48ba61aee._x8d54381b90e4e4be.Add(x990d54f34b2b5119);
			x62584df2cb5d40dd = false;
		}
		x990d54f34b2b5118 x990d54f34b2b5120;
		while ((x990d54f34b2b5120 = x990d54f34b2b5118.x64da0b7f32fdd92e(x2fe8f0c48ba61aee)) != null)
		{
			foreach (x990d54f34b2b5118 item in x2fe8f0c48ba61aee._x8d54381b90e4e4be)
			{
				if (item.xa39af5a82860a9a3 == x990d54f34b2b5120.xa39af5a82860a9a3)
				{
					item._x937e050c63ea1527 = x990d54f34b2b5120.x937e050c63ea1527;
					if (x990d54f34b2b5120.x996e6a5ca4407167)
					{
						item.xa1404b84036ecc66();
					}
					break;
				}
			}
		}
		if (x2fe8f0c48ba61aee._xe0a94e4535ae92fa > 0)
		{
			x2fe8f0c48ba61aee.xd0c948b79c880a6b(x2fe8f0c48ba61aee._xe0a94e4535ae92fa);
		}
		xe313817858c5c5e8(x2fe8f0c48ba61aee);
		if (x2fe8f0c48ba61aee.x0ede19c87c5fb089 && x2fe8f0c48ba61aee.x937e050c63ea1527 != null && x2fe8f0c48ba61aee.x937e050c63ea1527.Length > 0)
		{
			x2fe8f0c48ba61aee.x44102a7f72bfea16.WriteLine("Zip file Comment: {0}", x2fe8f0c48ba61aee.x937e050c63ea1527);
		}
		x2fe8f0c48ba61aee.x2815e8295da7002e();
	}

	private static void xe313817858c5c5e8(xef4b7685c2495ff2 x2fe8f0c48ba61aee)
	{
		Stream stream = x2fe8f0c48ba61aee.x53cce0b6abbd65ad;
		int num = x977b5605864b2047.x4e38ee4c0a37efb1(stream);
		byte[] array;
		if ((long)num == 101075792)
		{
			array = new byte[52];
			stream.Read(array, 0, array.Length);
			long num2 = BitConverter.ToInt64(array, 0);
			if (num2 < 44)
			{
				throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cgmkohdlohklhdbmifimchpmcignmgnnlfeooglomhcpegjpmbaacghaegoadbfbegmbffdcpekchabdodidkcpdocgebbnemaeffpkffbcgedjgkdahndhhidohecfimcminncjopjjacbkgcikgbpkbbglpbnlhbemhblmlbcnnmin", 561490976)));
			}
			array = new byte[num2 - 44];
			stream.Read(array, 0, array.Length);
			num = x977b5605864b2047.x4e38ee4c0a37efb1(stream);
			if ((long)num != 117853008)
			{
				throw new xc5e345d2a919c94b("Inconsistent metadata in the ZIP64 Central Directory.");
			}
			array = new byte[16];
			stream.Read(array, 0, array.Length);
			num = x977b5605864b2047.x4e38ee4c0a37efb1(stream);
		}
		if ((long)num != 101010256)
		{
			stream.Seek(-4L, SeekOrigin.Current);
			throw new x369b23f4e2c41640(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hofgeomglbehhclhlcciopiiobajobhjebojgoekdolkipcliaklbabmbaimcmomamfnommnbldoankomobpmoipfkppfpgaionadoebholbhncchojcfoadpnhdpmodhifemimemndfoikffjbgalignipgpmghihnhmgeikkliklcjdgjjalakmkhknkokakflikmlkjdmnjkmjjbnieinffpnkjgokjnoneepdflpogcalejaniab", 576939463)), num, stream.Position));
		}
		array = new byte[16];
		x2fe8f0c48ba61aee.x53cce0b6abbd65ad.Read(array, 0, array.Length);
		xfa7d2691c107d57f(x2fe8f0c48ba61aee);
	}

	private static void xfa7d2691c107d57f(xef4b7685c2495ff2 x2fe8f0c48ba61aee)
	{
		byte[] array = new byte[2];
		x2fe8f0c48ba61aee.x53cce0b6abbd65ad.Read(array, 0, array.Length);
		short num = (short)(array[0] + array[1] * 256);
		if (num > 0)
		{
			array = new byte[num];
			x2fe8f0c48ba61aee.x53cce0b6abbd65ad.Read(array, 0, array.Length);
			string @string = x24500e9782c41ba0.GetString(array, 0, array.Length);
			byte[] bytes = x24500e9782c41ba0.GetBytes(@string);
			if (x86795c14ba4751fb(array, bytes))
			{
				x2fe8f0c48ba61aee.x937e050c63ea1527 = @string;
				return;
			}
			Encoding encoding = ((x2fe8f0c48ba61aee._x569440e5ccedf43e.CodePage == 437) ? Encoding.UTF8 : x2fe8f0c48ba61aee._x569440e5ccedf43e);
			x2fe8f0c48ba61aee.x937e050c63ea1527 = encoding.GetString(array, 0, array.Length);
		}
	}

	private static bool x86795c14ba4751fb(byte[] x19218ffab70283ef, byte[] xe7ebe10fa44d8d49)
	{
		if (x19218ffab70283ef.Length != xe7ebe10fa44d8d49.Length)
		{
			return false;
		}
		for (int i = 0; i < x19218ffab70283ef.Length; i++)
		{
			if (x19218ffab70283ef[i] != xe7ebe10fa44d8d49[i])
			{
				return false;
			}
		}
		return true;
	}

	internal void xd0c948b79c880a6b(long x13d4cb8d1bd20347)
	{
		x53cce0b6abbd65ad.Seek(x13d4cb8d1bd20347 + _x65ba13a854a4213e, SeekOrigin.Begin);
	}

	public static bool x9f530bfd6a906d7d(string xafe2f3653ee64ebc)
	{
		return x9f530bfd6a906d7d(xafe2f3653ee64ebc, x99685c07a12ce155: false);
	}

	public static bool x9f530bfd6a906d7d(string xafe2f3653ee64ebc, bool x99685c07a12ce155)
	{
		bool result = false;
		try
		{
			if (!File.Exists(xafe2f3653ee64ebc))
			{
				return false;
			}
			using FileStream xcf18e5243f8d5fd = File.Open(xafe2f3653ee64ebc, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			result = x9f530bfd6a906d7d(xcf18e5243f8d5fd, x99685c07a12ce155);
		}
		catch
		{
		}
		return result;
	}

	public static bool x9f530bfd6a906d7d(Stream xcf18e5243f8d5fd3, bool x99685c07a12ce155)
	{
		bool result = false;
		try
		{
			if (!xcf18e5243f8d5fd3.CanRead)
			{
				return false;
			}
			Stream @null = Stream.Null;
			using (xef4b7685c2495ff2 xef4b7685c2495ff3 = x06b0e25aa6ad68a9(xcf18e5243f8d5fd3, null, Encoding.GetEncoding("IBM437")))
			{
				if (x99685c07a12ce155)
				{
					foreach (x990d54f34b2b5118 item in (IEnumerable)xef4b7685c2495ff3)
					{
						if (!item.x4d1990cadac28b9b)
						{
							item.xf098323036d9ec26(@null);
						}
					}
				}
			}
			result = true;
		}
		catch
		{
		}
		return result;
	}

	public void x0acd3c2012ea2ee8()
	{
		try
		{
			bool flag = false;
			_xf24acc83b64952af = false;
			x3d76d3bd598aa0e2();
			if (x25b763a23176450f == null)
			{
				throw new xcb4fb578c1324851("You haven't specified where to save the zip.");
			}
			if (_xc15bd84e01929885 != null && _xc15bd84e01929885.EndsWith(".exe"))
			{
				throw new xcb4fb578c1324851("You specified an EXE for a plain zip file.");
			}
			if (!_x8438cfc2d3232fce)
			{
				return;
			}
			if (x0ede19c87c5fb089)
			{
				x44102a7f72bfea16.WriteLine("saving....");
			}
			if (_x8d54381b90e4e4be.Count >= 65535 && _xa4993e9106eb60b0 == xd53f386d6d162abf.xb9715d2f06b63cf0)
			{
				throw new xc5e345d2a919c94b("The number of entries is 65535 or greater. Consider setting the UseZip64WhenSaving property on the ZipFile instance.");
			}
			int num = 0;
			foreach (x990d54f34b2b5118 item in _x8d54381b90e4e4be)
			{
				x6c1d876931225026(num, item, x6b161b1ae41c1651: true);
				item.x6210059f049f0d48(x25b763a23176450f);
				if (!_xf24acc83b64952af)
				{
					item._xe2a6c1b66e699ef3 = this;
					num++;
					x6c1d876931225026(num, item, x6b161b1ae41c1651: false);
					if (!_xf24acc83b64952af)
					{
						if (item.x998805a6e2868a2b)
						{
							flag |= item.xff7630c349464a76 == x09c3256ccc14f142.xbbad6bbe73c6b1dc;
						}
						continue;
					}
					break;
				}
				break;
			}
			if (_xf24acc83b64952af)
			{
				return;
			}
			x18a7f0e16dff41bb(x25b763a23176450f);
			x601246dcfeb81172(xebcb692fc67da2dc.xea49f9cdefc70274);
			_xc4eb04529e195c67 = true;
			_x8438cfc2d3232fce = false;
			flag |= _x11dc948e89bcec36;
			_x4f36598217f645a0 = (flag ? x09c3256ccc14f142.xbbad6bbe73c6b1dc : x09c3256ccc14f142.x12642456c7bf0815);
			if (_xf4cbc48f2b9d24ea != null && _xc15bd84e01929885 != null)
			{
				x25b763a23176450f.Close();
				x25b763a23176450f = null;
				if (_xf24acc83b64952af)
				{
					return;
				}
				if (_x6d56bb4f9166f4bf && _xb9a61312065e93e4 != null)
				{
					_xb9a61312065e93e4.Close();
					_xb9a61312065e93e4 = null;
				}
				if (_x6d56bb4f9166f4bf)
				{
					File.Delete(_xc15bd84e01929885);
					x601246dcfeb81172(xebcb692fc67da2dc.x387313e5c98a0db1);
					File.Move(_xf4cbc48f2b9d24ea, _xc15bd84e01929885);
					x601246dcfeb81172(xebcb692fc67da2dc.x973a3a8717f69883);
				}
				else
				{
					File.Move(_xf4cbc48f2b9d24ea, _xc15bd84e01929885);
				}
				_x6d56bb4f9166f4bf = true;
			}
			x4d4097a1420ad701();
			_x99f8a974f1c21380 = true;
		}
		finally
		{
			xb86117f51fb2d7fd();
		}
	}

	private void x47398a396a8b9cda()
	{
		try
		{
			if (File.Exists(_xf4cbc48f2b9d24ea))
			{
				File.Delete(_xf4cbc48f2b9d24ea);
			}
		}
		catch (Exception ex)
		{
			if (x0ede19c87c5fb089)
			{
				x44102a7f72bfea16.WriteLine("ZipFile::Save: could not delete temp file: {0}.", ex.Message);
			}
		}
	}

	private void xb86117f51fb2d7fd()
	{
		if (_xf4cbc48f2b9d24ea == null || _xc15bd84e01929885 == null)
		{
			return;
		}
		if (_x6ca6eb9a64d8c1fc != null)
		{
			try
			{
				_x6ca6eb9a64d8c1fc.Close();
			}
			catch
			{
			}
			try
			{
				_x6ca6eb9a64d8c1fc.Close();
			}
			catch
			{
			}
		}
		_x6ca6eb9a64d8c1fc = null;
		x47398a396a8b9cda();
		_xf4cbc48f2b9d24ea = null;
	}

	public void x0acd3c2012ea2ee8(string xafe2f3653ee64ebc)
	{
		if (_xc15bd84e01929885 == null)
		{
			_x6ca6eb9a64d8c1fc = null;
		}
		_xc15bd84e01929885 = xafe2f3653ee64ebc;
		if (Directory.Exists(_xc15bd84e01929885))
		{
			throw new xc5e345d2a919c94b(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pjndlleellleehcffjjfhlagnlhgnkogikfhglmhokdiokkiclbj", 1208892765)), new ArgumentException("That name specifies an existing directory. Please specify a filename.", "fileName"));
		}
		_x8438cfc2d3232fce = true;
		_x6d56bb4f9166f4bf = File.Exists(_xc15bd84e01929885);
		x0acd3c2012ea2ee8();
	}

	public void x0acd3c2012ea2ee8(Stream xf823f0edaa261f3b)
	{
		if (!xf823f0edaa261f3b.CanWrite)
		{
			throw new ArgumentException("The outputStream must be a writable stream.");
		}
		_xc15bd84e01929885 = null;
		_x6ca6eb9a64d8c1fc = new x853ddd714d7aaa13(xf823f0edaa261f3b);
		_x8438cfc2d3232fce = true;
		_x6d56bb4f9166f4bf = false;
		x0acd3c2012ea2ee8();
	}

	private void x18a7f0e16dff41bb(Stream xe4115acdf4fbfccc)
	{
		x853ddd714d7aaa13 x853ddd714d7aaa14 = xe4115acdf4fbfccc as x853ddd714d7aaa13;
		long num = x853ddd714d7aaa14?.x1c86f1bc0157a1b8 ?? xe4115acdf4fbfccc.Position;
		foreach (x990d54f34b2b5118 item in _x8d54381b90e4e4be)
		{
			if (item.x998805a6e2868a2b)
			{
				item.xb78171f966a8ffb4(xe4115acdf4fbfccc);
			}
		}
		long num2 = x853ddd714d7aaa14?.x1c86f1bc0157a1b8 ?? xe4115acdf4fbfccc.Position;
		long num3 = num2 - num;
		_x11dc948e89bcec36 = _xa4993e9106eb60b0 == xd53f386d6d162abf.xd4d82c4665f71358 || xa7f28ab92c37668b() >= 65535 || num3 > uint.MaxValue || num > uint.MaxValue;
		if (_x11dc948e89bcec36)
		{
			if (_xa4993e9106eb60b0 == xd53f386d6d162abf.xb9715d2f06b63cf0)
			{
				throw new xc5e345d2a919c94b("The archive requires a ZIP64 Central Directory. Consider setting the UseZip64WhenSaving property.");
			}
			x258332327e4f115c(xe4115acdf4fbfccc, num, num2);
		}
		x3870fa9f22825662(xe4115acdf4fbfccc, num, num2);
	}

	private int xa7f28ab92c37668b()
	{
		int num = 0;
		foreach (x990d54f34b2b5118 item in _x8d54381b90e4e4be)
		{
			if (item.x998805a6e2868a2b)
			{
				num++;
			}
		}
		return num;
	}

	private void x258332327e4f115c(Stream xe4115acdf4fbfccc, long xbf6054a490d29fff, long xd4a71fa76dd8d243)
	{
		byte[] array = new byte[76];
		int num = 0;
		byte[] bytes = BitConverter.GetBytes(101075792u);
		Array.Copy(bytes, 0, array, num, 4);
		num += 4;
		long value = 44L;
		Array.Copy(BitConverter.GetBytes(value), 0, array, num, 8);
		num += 8;
		array[num++] = 45;
		array[num++] = 0;
		array[num++] = 45;
		array[num++] = 0;
		for (int i = 0; i < 8; i++)
		{
			array[num++] = 0;
		}
		long value2 = xa7f28ab92c37668b();
		Array.Copy(BitConverter.GetBytes(value2), 0, array, num, 8);
		num += 8;
		Array.Copy(BitConverter.GetBytes(value2), 0, array, num, 8);
		num += 8;
		long value3 = xd4a71fa76dd8d243 - xbf6054a490d29fff;
		Array.Copy(BitConverter.GetBytes(value3), 0, array, num, 8);
		num += 8;
		Array.Copy(BitConverter.GetBytes(xbf6054a490d29fff), 0, array, num, 8);
		num += 8;
		bytes = BitConverter.GetBytes(117853008u);
		Array.Copy(bytes, 0, array, num, 4);
		num += 4;
		array[num++] = 0;
		array[num++] = 0;
		array[num++] = 0;
		array[num++] = 0;
		Array.Copy(BitConverter.GetBytes(xd4a71fa76dd8d243), 0, array, num, 8);
		num += 8;
		array[num++] = 1;
		array[num++] = 0;
		array[num++] = 0;
		array[num++] = 0;
		xe4115acdf4fbfccc.Write(array, 0, num);
	}

	private void x3870fa9f22825662(Stream xe4115acdf4fbfccc, long xbf6054a490d29fff, long xd4a71fa76dd8d243)
	{
		int num = 0;
		int num2 = 24;
		byte[] array = null;
		short num3 = 0;
		if (x937e050c63ea1527 != null && x937e050c63ea1527.Length != 0)
		{
			array = xbfe2d4ca3e43b779.GetBytes(x937e050c63ea1527);
			num3 = (short)array.Length;
		}
		num2 += num3;
		byte[] array2 = new byte[num2];
		int num4 = 0;
		byte[] bytes = BitConverter.GetBytes(101010256u);
		Array.Copy(bytes, 0, array2, num4, 4);
		num4 += 4;
		array2[num4++] = 0;
		array2[num4++] = 0;
		array2[num4++] = 0;
		array2[num4++] = 0;
		if (xa7f28ab92c37668b() >= 65535 || _xa4993e9106eb60b0 == xd53f386d6d162abf.xd4d82c4665f71358)
		{
			for (num = 0; num < 4; num++)
			{
				array2[num4++] = byte.MaxValue;
			}
		}
		else
		{
			int num5 = xa7f28ab92c37668b();
			array2[num4++] = (byte)((uint)num5 & 0xFFu);
			array2[num4++] = (byte)((num5 & 0xFF00) >> 8);
			array2[num4++] = (byte)((uint)num5 & 0xFFu);
			array2[num4++] = (byte)((num5 & 0xFF00) >> 8);
		}
		long num6 = xd4a71fa76dd8d243 - xbf6054a490d29fff;
		if (num6 >= uint.MaxValue || xbf6054a490d29fff >= uint.MaxValue)
		{
			for (num = 0; num < 8; num++)
			{
				array2[num4++] = byte.MaxValue;
			}
		}
		else
		{
			array2[num4++] = (byte)(num6 & 0xFF);
			array2[num4++] = (byte)((num6 & 0xFF00) >> 8);
			array2[num4++] = (byte)((num6 & 0xFF0000) >> 16);
			array2[num4++] = (byte)((num6 & 0xFF000000u) >> 24);
			array2[num4++] = (byte)(xbf6054a490d29fff & 0xFF);
			array2[num4++] = (byte)((xbf6054a490d29fff & 0xFF00) >> 8);
			array2[num4++] = (byte)((xbf6054a490d29fff & 0xFF0000) >> 16);
			array2[num4++] = (byte)((xbf6054a490d29fff & 0xFF000000u) >> 24);
		}
		if (x937e050c63ea1527 == null || x937e050c63ea1527.Length == 0)
		{
			array2[num4++] = 0;
			array2[num4++] = 0;
		}
		else
		{
			if (num3 + num4 + 2 > array2.Length)
			{
				num3 = (short)(array2.Length - num4 - 2);
			}
			array2[num4++] = (byte)((uint)num3 & 0xFFu);
			array2[num4++] = (byte)((num3 & 0xFF00) >> 8);
			if (num3 != 0)
			{
				for (num = 0; num < num3 && num4 + num < array2.Length; num++)
				{
					array2[num4 + num] = array[num];
				}
				num4 += num;
			}
		}
		xe4115acdf4fbfccc.Write(array2, 0, num4);
	}

	private IEnumerator x05b0b83b5e6c5de6()
	{
		return _x8d54381b90e4e4be.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x05b0b83b5e6c5de6
		return this.x05b0b83b5e6c5de6();
	}

	public IEnumerator x25f002ca1885153a()
	{
		return _x8d54381b90e4e4be.GetEnumerator();
	}
}
