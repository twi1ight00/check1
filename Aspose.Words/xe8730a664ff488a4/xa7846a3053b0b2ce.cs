using Aspose;
using x13f1efc79617a47b;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal sealed class xa7846a3053b0b2ce
{
	private const int x91e3eadf25e7a010 = 32;

	private const int x6943ad98821a12e0 = 8;

	private const int xc037f394127d0262 = 0;

	private const int x54663e5b215b5578 = 1;

	private const int xe2db8156e5d10074 = 2;

	private const int x6b4b611737464642 = 3;

	private const int x72be74070ce1e7e3 = 4;

	private const int xb4df1e77e2f1f0a2 = 5;

	private const int x426f9e548e8bd54e = 6;

	private const int x56de085244a88679 = 7;

	private const int xae7d23f391b61ae9 = 8;

	private const int x5544f235c6597126 = 9;

	private const int x0da2d8cecf32e04f = 10;

	private const int x3fcb017131455194 = 11;

	private const int x18a50ec04fea77d4 = 12;

	private const int x0a94a84af9b21075 = 13;

	internal int xa4aa8b4150b11435;

	internal x5a92807060bc6079 _x75d376891c19d365;

	internal int x1306445c04667cc7;

	internal long[] xa5423af59627a96b = new long[1];

	internal long xd5842df57f205543;

	internal int x8f2400368d1c57d3;

	private bool _x22e2f8f314a71840 = true;

	internal int xdfa97f94c19405c2;

	internal xbe9c370878285c10 xd2f7a26499207fdd;

	private static byte[] x1674fce447c82e79 = new byte[4] { 0, 0, 255, 255 };

	internal bool x7250d42d8d9e09ca
	{
		get
		{
			return _x22e2f8f314a71840;
		}
		set
		{
			_x22e2f8f314a71840 = value;
		}
	}

	public xa7846a3053b0b2ce()
	{
	}

	public xa7846a3053b0b2ce(bool expectRfc1950HeaderBytes)
	{
		_x22e2f8f314a71840 = expectRfc1950HeaderBytes;
	}

	internal int x74f5a1ef3906e23c()
	{
		_x75d376891c19d365.x4898fcfa8d5dd0b2 = (_x75d376891c19d365.x8d79d7f35d1df930 = 0L);
		_x75d376891c19d365.xd397bb1e465ce45e = null;
		xa4aa8b4150b11435 = ((!x7250d42d8d9e09ca) ? 7 : 0);
		xd2f7a26499207fdd.x74f5a1ef3906e23c(null);
		return 0;
	}

	internal int x9fd888e65466818c()
	{
		if (xd2f7a26499207fdd != null)
		{
			xd2f7a26499207fdd.xd2cd64b1e950d3dc();
		}
		xd2f7a26499207fdd = null;
		return 0;
	}

	internal int x20aee281977480cf(x5a92807060bc6079 x75d376891c19d365, int x9d007d79b26e5331)
	{
		_x75d376891c19d365 = x75d376891c19d365;
		_x75d376891c19d365.xd397bb1e465ce45e = null;
		xd2f7a26499207fdd = null;
		if (x9d007d79b26e5331 < 8 || x9d007d79b26e5331 > 15)
		{
			x9fd888e65466818c();
			throw new xd449352d3501c52f(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("noanjainjapncmfogbnofaephalpkpbacajahaabnkgbnpnbapecoplcgocdmkjd", 35901611)));
		}
		xdfa97f94c19405c2 = x9d007d79b26e5331;
		xd2f7a26499207fdd = new xbe9c370878285c10(x75d376891c19d365, x7250d42d8d9e09ca ? this : null, 1 << x9d007d79b26e5331);
		x74f5a1ef3906e23c();
		return 0;
	}

	internal int x4671919d08389f8e(x89a5712fad624df9 xb2c46b205870e7de)
	{
		int num = (int)xb2c46b205870e7de;
		if (_x75d376891c19d365.x44c6db5b64538d67 == null)
		{
			throw new xd449352d3501c52f("InputBuffer is null. ");
		}
		num = ((num == 4) ? (-5) : 0);
		int num2 = -5;
		while (true)
		{
			switch (xa4aa8b4150b11435)
			{
			case 0:
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				if (((x1306445c04667cc7 = _x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++]) & 0xF) != 8)
				{
					xa4aa8b4150b11435 = 13;
					_x75d376891c19d365.xd397bb1e465ce45e = $"unknown compression method (0x{x1306445c04667cc7:X2})";
					x8f2400368d1c57d3 = 5;
					break;
				}
				if ((x1306445c04667cc7 >> 4) + 8 > xdfa97f94c19405c2)
				{
					xa4aa8b4150b11435 = 13;
					_x75d376891c19d365.xd397bb1e465ce45e = $"invalid window size ({(x1306445c04667cc7 >> 4) + 8})";
					x8f2400368d1c57d3 = 5;
					break;
				}
				xa4aa8b4150b11435 = 1;
				goto case 1;
			case 1:
			{
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				int num3 = _x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++] & 0xFF;
				if (((x1306445c04667cc7 << 8) + num3) % 31 != 0)
				{
					xa4aa8b4150b11435 = 13;
					_x75d376891c19d365.xd397bb1e465ce45e = "incorrect header check";
					x8f2400368d1c57d3 = 5;
					break;
				}
				if ((num3 & 0x20) == 0)
				{
					xa4aa8b4150b11435 = 7;
					break;
				}
				xa4aa8b4150b11435 = 2;
				goto case 2;
			}
			case 2:
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				xd5842df57f205543 = ((_x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++] & 0xFF) << 24) & -16777216;
				xa4aa8b4150b11435 = 3;
				goto case 3;
			case 3:
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				xd5842df57f205543 += (long)((ulong)((_x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++] & 0xFF) << 16) & 0xFF0000uL);
				xa4aa8b4150b11435 = 4;
				goto case 4;
			case 4:
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				xd5842df57f205543 += (long)((ulong)((_x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++] & 0xFF) << 8) & 0xFF00uL);
				xa4aa8b4150b11435 = 5;
				goto case 5;
			case 5:
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				xd5842df57f205543 += (long)((ulong)_x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++] & 0xFFuL);
				_x75d376891c19d365._x7ab4a0dd1a2efc16 = xd5842df57f205543;
				xa4aa8b4150b11435 = 6;
				return 2;
			case 6:
				xa4aa8b4150b11435 = 13;
				_x75d376891c19d365.xd397bb1e465ce45e = "need dictionary";
				x8f2400368d1c57d3 = 0;
				return -2;
			case 7:
				num2 = xd2f7a26499207fdd.x5d3a1f6283012a22(num2);
				switch (num2)
				{
				case -3:
					xa4aa8b4150b11435 = 13;
					x8f2400368d1c57d3 = 0;
					goto end_IL_002f;
				case 0:
					num2 = num;
					break;
				}
				if (num2 != 1)
				{
					return num2;
				}
				num2 = num;
				xd2f7a26499207fdd.x74f5a1ef3906e23c(xa5423af59627a96b);
				if (!x7250d42d8d9e09ca)
				{
					xa4aa8b4150b11435 = 12;
					break;
				}
				xa4aa8b4150b11435 = 8;
				goto case 8;
			case 8:
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				xd5842df57f205543 = ((_x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++] & 0xFF) << 24) & -16777216;
				xa4aa8b4150b11435 = 9;
				goto case 9;
			case 9:
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				xd5842df57f205543 += (long)((ulong)((_x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++] & 0xFF) << 16) & 0xFF0000uL);
				xa4aa8b4150b11435 = 10;
				goto case 10;
			case 10:
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				xd5842df57f205543 += (long)((ulong)((_x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++] & 0xFF) << 8) & 0xFF00uL);
				xa4aa8b4150b11435 = 11;
				goto case 11;
			case 11:
				if (_x75d376891c19d365.x3401b50873ad59be == 0)
				{
					return num2;
				}
				num2 = num;
				_x75d376891c19d365.x3401b50873ad59be--;
				_x75d376891c19d365.x4898fcfa8d5dd0b2++;
				xd5842df57f205543 += (long)((ulong)_x75d376891c19d365.x44c6db5b64538d67[_x75d376891c19d365.x564ec8a071685a21++] & 0xFFuL);
				if ((int)xa5423af59627a96b[0] != (int)xd5842df57f205543)
				{
					xa4aa8b4150b11435 = 13;
					_x75d376891c19d365.xd397bb1e465ce45e = "incorrect data check";
					x8f2400368d1c57d3 = 5;
					break;
				}
				xa4aa8b4150b11435 = 12;
				goto case 12;
			case 12:
				return 1;
			case 13:
				throw new xd449352d3501c52f(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ldakhfhkhfokabflagmlofdmiekmifbngeinopondagodfnofaeppelpipba", 115580921)), _x75d376891c19d365.xd397bb1e465ce45e));
			default:
				{
					throw new xd449352d3501c52f("Stream error.");
				}
				end_IL_002f:
				break;
			}
		}
	}

	internal int xc2e30ed258f46b33(byte[] xaf81af0633c4820d)
	{
		int x10aaa7cdfa38f = 0;
		int num = xaf81af0633c4820d.Length;
		if (xa4aa8b4150b11435 != 6)
		{
			throw new xd449352d3501c52f("Stream error.");
		}
		if (xb23dc957c3e5bff6.x7ab4a0dd1a2efc16(1L, xaf81af0633c4820d, 0, xaf81af0633c4820d.Length) != _x75d376891c19d365._x7ab4a0dd1a2efc16)
		{
			return -3;
		}
		_x75d376891c19d365._x7ab4a0dd1a2efc16 = xb23dc957c3e5bff6.x7ab4a0dd1a2efc16(0L, null, 0, 0);
		if (num >= 1 << xdfa97f94c19405c2)
		{
			num = (1 << xdfa97f94c19405c2) - 1;
			x10aaa7cdfa38f = xaf81af0633c4820d.Length - num;
		}
		xd2f7a26499207fdd.xc2e30ed258f46b33(xaf81af0633c4820d, x10aaa7cdfa38f, num);
		xa4aa8b4150b11435 = 7;
		return 0;
	}

	internal int x6c1268b8fdc7ecbd()
	{
		if (xa4aa8b4150b11435 != 13)
		{
			xa4aa8b4150b11435 = 13;
			x8f2400368d1c57d3 = 0;
		}
		int num;
		if ((num = _x75d376891c19d365.x3401b50873ad59be) == 0)
		{
			return -5;
		}
		int num2 = _x75d376891c19d365.x564ec8a071685a21;
		int num3 = x8f2400368d1c57d3;
		while (num != 0 && num3 < 4)
		{
			num3 = ((_x75d376891c19d365.x44c6db5b64538d67[num2] != x1674fce447c82e79[num3]) ? ((_x75d376891c19d365.x44c6db5b64538d67[num2] == 0) ? (4 - num3) : 0) : (num3 + 1));
			num2++;
			num--;
		}
		_x75d376891c19d365.x4898fcfa8d5dd0b2 += num2 - _x75d376891c19d365.x564ec8a071685a21;
		_x75d376891c19d365.x564ec8a071685a21 = num2;
		_x75d376891c19d365.x3401b50873ad59be = num;
		x8f2400368d1c57d3 = num3;
		if (num3 != 4)
		{
			return -3;
		}
		long x4898fcfa8d5dd0b = _x75d376891c19d365.x4898fcfa8d5dd0b2;
		long x8d79d7f35d1df = _x75d376891c19d365.x8d79d7f35d1df930;
		x74f5a1ef3906e23c();
		_x75d376891c19d365.x4898fcfa8d5dd0b2 = x4898fcfa8d5dd0b;
		_x75d376891c19d365.x8d79d7f35d1df930 = x8d79d7f35d1df;
		xa4aa8b4150b11435 = 7;
		return 0;
	}

	internal int xb9d7575e60b25f5c(x5a92807060bc6079 x8cfbc105c29e356f)
	{
		return xd2f7a26499207fdd.xb9d7575e60b25f5c();
	}
}
