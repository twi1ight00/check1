using System;
using System.IO;
using System.Reflection;
using System.Text;
using Aspose;
using x13f1efc79617a47b;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class xd9b65f15958fe264 : Stream
{
	internal enum xed4e6d4a5d08e817
	{
		x5aa326f374b3d0ef,
		xf86de1bd2f396938,
		x236cb0a4295bc034
	}

	protected internal x5a92807060bc6079 _x8cfbc105c29e356f;

	protected internal xed4e6d4a5d08e817 _x9f93aa7609d09c95 = xed4e6d4a5d08e817.x236cb0a4295bc034;

	protected internal x89a5712fad624df9 _xe4f0f2bc0db45668;

	protected internal x48d9147101a26c84 _xf0f8be00898c7ea9;

	protected internal x1f770018e5e12789 _x357ffcbc1f54653c;

	protected internal x0bf508c6214e694f _x66bbd7ed8c65740d;

	protected internal bool _x879e17d89d89eda8;

	protected internal byte[] _x0cf41e0b23a9f822;

	protected internal int _xb85b7645153fc718 = 8192;

	protected internal byte[] _x843f401021fb437e = new byte[1];

	protected internal Stream _xcf18e5243f8d5fd3;

	protected internal x07366e3d6c48f6c6 xce7d657046e9409a;

	private x41fcadcc0506e331 xa4660e7fe4e71d99;

	protected internal string _x2e1d6311f931bd7c;

	protected internal string _x4ab9f4c3986f4f51;

	protected internal DateTime _x4921482aa8ab2b54;

	protected internal int _x11a637a86a1dcdce;

	private bool x97afb851ee6f0235;

	internal int x5e4059a15fb5fca5
	{
		get
		{
			if (xa4660e7fe4e71d99 == null)
			{
				return 0;
			}
			return xa4660e7fe4e71d99.x882f8c1265bb8e85;
		}
	}

	protected internal bool _x9519345a4228ed90 => _x357ffcbc1f54653c == x1f770018e5e12789.x2688d9218ffd4d00;

	private x5a92807060bc6079 x8cfbc105c29e356f
	{
		get
		{
			if (_x8cfbc105c29e356f == null)
			{
				bool flag = _xf0f8be00898c7ea9 == x48d9147101a26c84.xee037a342a21cbfc;
				_x8cfbc105c29e356f = new x5a92807060bc6079();
				if (_x357ffcbc1f54653c == x1f770018e5e12789.x706f07a5eea59a53)
				{
					_x8cfbc105c29e356f.xd72440fa8c37fe6e(flag);
				}
				else
				{
					_x8cfbc105c29e356f.xce7d657046e9409a = xce7d657046e9409a;
					_x8cfbc105c29e356f.x518f0c74c252eddc(_x66bbd7ed8c65740d, flag);
				}
			}
			return _x8cfbc105c29e356f;
		}
	}

	private byte[] x0cf41e0b23a9f822
	{
		get
		{
			if (_x0cf41e0b23a9f822 == null)
			{
				_x0cf41e0b23a9f822 = new byte[_xb85b7645153fc718];
			}
			return _x0cf41e0b23a9f822;
		}
	}

	public override bool CanRead => _xcf18e5243f8d5fd3.CanRead;

	public override bool CanSeek => _xcf18e5243f8d5fd3.CanSeek;

	public override bool CanWrite => _xcf18e5243f8d5fd3.CanWrite;

	public override long Length => _xcf18e5243f8d5fd3.Length;

	public override long Position
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public xd9b65f15958fe264(Stream stream, x1f770018e5e12789 compressionMode, x0bf508c6214e694f level, x48d9147101a26c84 flavor, bool leaveOpen)
	{
		_xe4f0f2bc0db45668 = x89a5712fad624df9.x4d0b9d4447ba7566;
		_xcf18e5243f8d5fd3 = stream;
		_x879e17d89d89eda8 = leaveOpen;
		_x357ffcbc1f54653c = compressionMode;
		_xf0f8be00898c7ea9 = flavor;
		_x66bbd7ed8c65740d = level;
		if (flavor == x48d9147101a26c84.x8b7fb4cb1b65e3e5)
		{
			xa4660e7fe4e71d99 = new x41fcadcc0506e331();
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (xa4660e7fe4e71d99 != null)
		{
			xa4660e7fe4e71d99.x8ebfa48686a2fc0c(buffer, offset, count);
		}
		if (_x9f93aa7609d09c95 == xed4e6d4a5d08e817.x236cb0a4295bc034)
		{
			_x9f93aa7609d09c95 = xed4e6d4a5d08e817.x5aa326f374b3d0ef;
		}
		else if (_x9f93aa7609d09c95 != 0)
		{
			throw new xd449352d3501c52f(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dedfofkfigbgfgigdgpgfgghoanhceeikflioecjgfjjeeakmpgkkdokmdflhemlfddmpdkmkoanjbinjcpnccgoccnoecepgclpmbcaaoia", 91837184)));
		}
		if (count == 0)
		{
			return;
		}
		x8cfbc105c29e356f.x44c6db5b64538d67 = buffer;
		_x8cfbc105c29e356f.x564ec8a071685a21 = offset;
		_x8cfbc105c29e356f.x3401b50873ad59be = count;
		bool flag = false;
		do
		{
			_x8cfbc105c29e356f.x77ba06e5be4d4d72 = x0cf41e0b23a9f822;
			_x8cfbc105c29e356f.xb5375db3326c5e6d = 0;
			_x8cfbc105c29e356f.x3ce290765cb44316 = _x0cf41e0b23a9f822.Length;
			int num = (_x9519345a4228ed90 ? _x8cfbc105c29e356f.x575db3fedeadea6b(_xe4f0f2bc0db45668) : _x8cfbc105c29e356f.x4671919d08389f8e(_xe4f0f2bc0db45668));
			if (num != 0 && num != 1)
			{
				throw new xd449352d3501c52f((_x9519345a4228ed90 ? "de" : "in") + "flating: " + _x8cfbc105c29e356f.xd397bb1e465ce45e);
			}
			_xcf18e5243f8d5fd3.Write(_x0cf41e0b23a9f822, 0, _x0cf41e0b23a9f822.Length - _x8cfbc105c29e356f.x3ce290765cb44316);
			flag = _x8cfbc105c29e356f.x3401b50873ad59be == 0 && _x8cfbc105c29e356f.x3ce290765cb44316 != 0;
			if (_xf0f8be00898c7ea9 == x48d9147101a26c84.x8b7fb4cb1b65e3e5 && !_x9519345a4228ed90)
			{
				flag = _x8cfbc105c29e356f.x3401b50873ad59be == 8 && _x8cfbc105c29e356f.x3ce290765cb44316 != 0;
			}
		}
		while (!flag);
	}

	private void x0685081969507e13()
	{
		if (_x8cfbc105c29e356f == null)
		{
			return;
		}
		if (_x9f93aa7609d09c95 == xed4e6d4a5d08e817.x5aa326f374b3d0ef)
		{
			bool flag = false;
			do
			{
				_x8cfbc105c29e356f.x77ba06e5be4d4d72 = x0cf41e0b23a9f822;
				_x8cfbc105c29e356f.xb5375db3326c5e6d = 0;
				_x8cfbc105c29e356f.x3ce290765cb44316 = _x0cf41e0b23a9f822.Length;
				int num = (_x9519345a4228ed90 ? _x8cfbc105c29e356f.x575db3fedeadea6b(x89a5712fad624df9.x7ffaace5132efedd) : _x8cfbc105c29e356f.x4671919d08389f8e(x89a5712fad624df9.x7ffaace5132efedd));
				if (num != 1 && num != 0)
				{
					throw new xd449352d3501c52f((_x9519345a4228ed90 ? "de" : "in") + "flating: " + _x8cfbc105c29e356f.xd397bb1e465ce45e);
				}
				if (_x0cf41e0b23a9f822.Length - _x8cfbc105c29e356f.x3ce290765cb44316 > 0)
				{
					_xcf18e5243f8d5fd3.Write(_x0cf41e0b23a9f822, 0, _x0cf41e0b23a9f822.Length - _x8cfbc105c29e356f.x3ce290765cb44316);
				}
				flag = _x8cfbc105c29e356f.x3401b50873ad59be == 0 && _x8cfbc105c29e356f.x3ce290765cb44316 != 0;
				if (_xf0f8be00898c7ea9 == x48d9147101a26c84.x8b7fb4cb1b65e3e5 && !_x9519345a4228ed90)
				{
					flag = _x8cfbc105c29e356f.x3401b50873ad59be == 8 && _x8cfbc105c29e356f.x3ce290765cb44316 != 0;
				}
			}
			while (!flag);
			Flush();
			if (_xf0f8be00898c7ea9 == x48d9147101a26c84.x8b7fb4cb1b65e3e5)
			{
				if (!_x9519345a4228ed90)
				{
					throw new xd449352d3501c52f("Writing with decompression is not supported.");
				}
				int x882f8c1265bb8e = xa4660e7fe4e71d99.x882f8c1265bb8e85;
				_xcf18e5243f8d5fd3.Write(BitConverter.GetBytes(x882f8c1265bb8e), 0, 4);
				int value = (int)(xa4660e7fe4e71d99.x6d0b3ba2ab87aa92 & 0xFFFFFFFFu);
				_xcf18e5243f8d5fd3.Write(BitConverter.GetBytes(value), 0, 4);
			}
		}
		else
		{
			if (_x9f93aa7609d09c95 != xed4e6d4a5d08e817.xf86de1bd2f396938 || _xf0f8be00898c7ea9 != x48d9147101a26c84.x8b7fb4cb1b65e3e5)
			{
				return;
			}
			if (_x9519345a4228ed90)
			{
				throw new xd449352d3501c52f("Reading with compression is not supported.");
			}
			if (_x8cfbc105c29e356f.x8d79d7f35d1df930 != 0)
			{
				byte[] array = new byte[8];
				if (_x8cfbc105c29e356f.x3401b50873ad59be != 8)
				{
					throw new xd449352d3501c52f($"Protocol error. AvailableBytesIn={_x8cfbc105c29e356f.x3401b50873ad59be}, expected 8");
				}
				Array.Copy(_x8cfbc105c29e356f.x44c6db5b64538d67, _x8cfbc105c29e356f.x564ec8a071685a21, array, 0, array.Length);
				int num2 = BitConverter.ToInt32(array, 0);
				int x882f8c1265bb8e2 = xa4660e7fe4e71d99.x882f8c1265bb8e85;
				int num3 = BitConverter.ToInt32(array, 4);
				int num4 = (int)(_x8cfbc105c29e356f.x8d79d7f35d1df930 & 0xFFFFFFFFu);
				if (x882f8c1265bb8e2 != num2)
				{
					throw new xd449352d3501c52f(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bdocnefdnemdgadegckecdbfacifnapfjaggepmgkdehmdlhlobipajipbajlahjpaojmnekmcmkkcdlfcklfbbmoaimhbpmfnfnemmnjmdoppkoopbpmajpkaaadpgalpnaelebeambglccnljcinadflhdhpodakfefjmeokdfdnkfdobginigkmpgfmghdnnhbmeinlliohcjomjjbiakhihkckokphflbmmlkgdmhgkm", 164900335)), x882f8c1265bb8e2, num2));
				}
				if (num4 != num3)
				{
					throw new xd449352d3501c52f(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lekahgbbhgibacpbahgcdgncbhedjfldbbcehfjejfafiahfmcofmdfgicmgmcdhjpjhjebiheiicepicdgjlcnjedekcpkkboblgoilmbamlbhmjcomhcfnabmnibdobnjobcbpdnhpnbppgmfallmaendbjpkbjaccopicappclogdjpndhoeedoleekcfepjfhkagaphgjjoggjfh", 785517065)), num4, num3));
				}
			}
		}
	}

	private void xca09b6c2b5b18485()
	{
		if (x8cfbc105c29e356f != null)
		{
			if (_x9519345a4228ed90)
			{
				_x8cfbc105c29e356f.x33769736456c27fa();
			}
			else
			{
				_x8cfbc105c29e356f.x161b90df7b1ae725();
			}
			_x8cfbc105c29e356f = null;
		}
	}

	public override void Close()
	{
		if (_xcf18e5243f8d5fd3 == null)
		{
			return;
		}
		try
		{
			x0685081969507e13();
		}
		finally
		{
			xca09b6c2b5b18485();
			if (!_x879e17d89d89eda8)
			{
				_xcf18e5243f8d5fd3.Close();
			}
			_xcf18e5243f8d5fd3 = null;
		}
	}

	public override void Flush()
	{
		_xcf18e5243f8d5fd3.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		_xcf18e5243f8d5fd3.SetLength(value);
	}

	private string xcfde0eb604989490()
	{
		MemoryStream memoryStream = new MemoryStream();
		bool flag = false;
		do
		{
			int num = _xcf18e5243f8d5fd3.Read(_x843f401021fb437e, 0, 1);
			if (num != 1)
			{
				throw new xd449352d3501c52f("Unexpected EOF reading GZIP header.");
			}
			if (_x843f401021fb437e[0] == 0)
			{
				flag = true;
			}
			else
			{
				memoryStream.WriteByte(_x843f401021fb437e[0]);
			}
		}
		while (!flag);
		byte[] array = memoryStream.ToArray();
		return x007194a88446d25e.x995dd334075189ca.GetString(array, 0, array.Length);
	}

	private int _xe08a047274692099()
	{
		int num = 0;
		byte[] array = new byte[10];
		int num2 = _xcf18e5243f8d5fd3.Read(array, 0, array.Length);
		switch (num2)
		{
		case 0:
			return 0;
		default:
			throw new xd449352d3501c52f("Not a valid GZIP stream.");
		case 10:
		{
			if (array[0] != 31 || array[1] != 139 || array[2] != 8)
			{
				throw new xd449352d3501c52f(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pepplggalgnaecebielbifcceejcieadfbhdkfodeffenemenedflekfffbgoaig", 75955981)));
			}
			int num3 = BitConverter.ToInt32(array, 4);
			_x4921482aa8ab2b54 = x007194a88446d25e._x7b854fa04f4ba476.AddSeconds(num3);
			num += num2;
			if ((array[3] & 4) == 4)
			{
				num2 = _xcf18e5243f8d5fd3.Read(array, 0, 2);
				num += num2;
				short num4 = (short)(array[0] + array[1] * 256);
				byte[] array2 = new byte[num4];
				num2 = _xcf18e5243f8d5fd3.Read(array2, 0, array2.Length);
				if (num2 != num4)
				{
					throw new xd449352d3501c52f("Unexpected end-of-file reading GZIP header.");
				}
				num += num2;
			}
			if ((array[3] & 8) == 8)
			{
				_x2e1d6311f931bd7c = xcfde0eb604989490();
			}
			if ((array[3] & 0x10) == 16)
			{
				_x4ab9f4c3986f4f51 = xcfde0eb604989490();
			}
			if ((array[3] & 2) == 2)
			{
				Read(_x843f401021fb437e, 0, 1);
			}
			return num;
		}
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (_x9f93aa7609d09c95 == xed4e6d4a5d08e817.x236cb0a4295bc034)
		{
			if (!_xcf18e5243f8d5fd3.CanRead)
			{
				throw new xd449352d3501c52f("The stream is not readable.");
			}
			_x9f93aa7609d09c95 = xed4e6d4a5d08e817.xf86de1bd2f396938;
			x8cfbc105c29e356f.x3401b50873ad59be = 0;
			if (_xf0f8be00898c7ea9 == x48d9147101a26c84.x8b7fb4cb1b65e3e5)
			{
				_x11a637a86a1dcdce = _xe08a047274692099();
				if (_x11a637a86a1dcdce == 0)
				{
					return 0;
				}
			}
		}
		if (_x9f93aa7609d09c95 != xed4e6d4a5d08e817.xf86de1bd2f396938)
		{
			throw new xd449352d3501c52f(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fholajfmkjmmhjdnfjknhjboaeiopgpophgpihnpiheabdlapgcbbhjbmhackghcehocpbfddfmdlgdepfkehgbfjfiflfpfbfggfbng", 441564722)));
		}
		if (count == 0)
		{
			return 0;
		}
		if (x97afb851ee6f0235 && _x9519345a4228ed90)
		{
			return 0;
		}
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (offset < buffer.GetLowerBound(0))
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (offset + count > buffer.GetLength(0))
		{
			throw new ArgumentOutOfRangeException("count");
		}
		int num = 0;
		_x8cfbc105c29e356f.x77ba06e5be4d4d72 = buffer;
		_x8cfbc105c29e356f.xb5375db3326c5e6d = offset;
		_x8cfbc105c29e356f.x3ce290765cb44316 = count;
		_x8cfbc105c29e356f.x44c6db5b64538d67 = x0cf41e0b23a9f822;
		do
		{
			if (_x8cfbc105c29e356f.x3401b50873ad59be == 0 && !x97afb851ee6f0235)
			{
				_x8cfbc105c29e356f.x564ec8a071685a21 = 0;
				_x8cfbc105c29e356f.x3401b50873ad59be = _xcf18e5243f8d5fd3.Read(_x0cf41e0b23a9f822, 0, _x0cf41e0b23a9f822.Length);
				if (_x8cfbc105c29e356f.x3401b50873ad59be == 0)
				{
					x97afb851ee6f0235 = true;
				}
			}
			num = (_x9519345a4228ed90 ? _x8cfbc105c29e356f.x575db3fedeadea6b(_xe4f0f2bc0db45668) : _x8cfbc105c29e356f.x4671919d08389f8e(_xe4f0f2bc0db45668));
			if (x97afb851ee6f0235 && num == -5)
			{
				return 0;
			}
			if (num != 0 && num != 1)
			{
				throw new xd449352d3501c52f(string.Format("{0}flating:  rc={1}  msg={2}", _x9519345a4228ed90 ? "de" : "in", num, _x8cfbc105c29e356f.xd397bb1e465ce45e));
			}
		}
		while (((!x97afb851ee6f0235 && num != 1) || _x8cfbc105c29e356f.x3ce290765cb44316 != count) && _x8cfbc105c29e356f.x3ce290765cb44316 > 0 && !x97afb851ee6f0235 && num == 0);
		if (_x8cfbc105c29e356f.x3ce290765cb44316 > 0)
		{
			if (num == 0)
			{
				_ = _x8cfbc105c29e356f.x3401b50873ad59be;
			}
			if (x97afb851ee6f0235 && _x9519345a4228ed90)
			{
				num = _x8cfbc105c29e356f.x575db3fedeadea6b(x89a5712fad624df9.x7ffaace5132efedd);
				if (num != 0 && num != 1)
				{
					throw new xd449352d3501c52f($"Deflating:  rc={num}  msg={_x8cfbc105c29e356f.xd397bb1e465ce45e}");
				}
			}
		}
		num = count - _x8cfbc105c29e356f.x3ce290765cb44316;
		if (xa4660e7fe4e71d99 != null)
		{
			xa4660e7fe4e71d99.x8ebfa48686a2fc0c(buffer, offset, num);
		}
		return num;
	}

	public static byte[] x0e394068a594d384(string xe4115acdf4fbfccc, Type x43163d22e8cd5a71)
	{
		Encoding uTF = Encoding.UTF8;
		byte[] bytes = uTF.GetBytes(xe4115acdf4fbfccc);
		using MemoryStream memoryStream = new MemoryStream();
		Stream stream = (Stream)x43163d22e8cd5a71.InvokeMember("This IS Ignored", BindingFlags.CreateInstance, null, null, new object[3]
		{
			memoryStream,
			x1f770018e5e12789.x2688d9218ffd4d00,
			x0bf508c6214e694f.x3041627762436789
		});
		using (stream)
		{
			stream.Write(bytes, 0, bytes.Length);
		}
		return memoryStream.ToArray();
	}

	public static string x3389f8cbd9a4a6e2(byte[] x933b2a3444ec3bba, Type x43163d22e8cd5a71)
	{
		byte[] array = new byte[1024];
		Encoding uTF = Encoding.UTF8;
		using MemoryStream memoryStream2 = new MemoryStream();
		using MemoryStream memoryStream = new MemoryStream(x933b2a3444ec3bba);
		Stream stream = (Stream)x43163d22e8cd5a71.InvokeMember("This IS Ignored", BindingFlags.CreateInstance, null, null, new object[2]
		{
			memoryStream,
			x1f770018e5e12789.x706f07a5eea59a53
		});
		using (stream)
		{
			int count;
			while ((count = stream.Read(array, 0, array.Length)) != 0)
			{
				memoryStream2.Write(array, 0, count);
			}
		}
		memoryStream2.Seek(0L, SeekOrigin.Begin);
		StreamReader streamReader = new StreamReader(memoryStream2, uTF);
		return streamReader.ReadToEnd();
	}

	public static byte[] xe760fb5661ebe89a(byte[] xe7ebe10fa44d8d49, Type x43163d22e8cd5a71)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Stream stream = (Stream)x43163d22e8cd5a71.InvokeMember("This IS Ignored", BindingFlags.CreateInstance, null, null, new object[3]
		{
			memoryStream,
			x1f770018e5e12789.x2688d9218ffd4d00,
			x0bf508c6214e694f.x3041627762436789
		});
		using (stream)
		{
			stream.Write(xe7ebe10fa44d8d49, 0, xe7ebe10fa44d8d49.Length);
		}
		return memoryStream.ToArray();
	}

	public static byte[] xea29da571ea64fa4(byte[] x933b2a3444ec3bba, Type x43163d22e8cd5a71)
	{
		byte[] array = new byte[1024];
		using MemoryStream memoryStream2 = new MemoryStream();
		using MemoryStream memoryStream = new MemoryStream(x933b2a3444ec3bba);
		Stream stream = (Stream)x43163d22e8cd5a71.InvokeMember("This IS Ignored", BindingFlags.CreateInstance, null, null, new object[2]
		{
			memoryStream,
			x1f770018e5e12789.x706f07a5eea59a53
		});
		using (stream)
		{
			int count;
			while ((count = stream.Read(array, 0, array.Length)) != 0)
			{
				memoryStream2.Write(array, 0, count);
			}
		}
		return memoryStream2.ToArray();
	}
}
