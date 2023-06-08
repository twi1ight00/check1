using System.Collections;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x793a0d37961cea91
{
	private const int xeababaadceb43553 = -1;

	private const int x61c4b7098101dbe4 = 13;

	private const int x3cef9cc82a7b313d = 10;

	private readonly Stream xa49cef274042e702;

	private x03f56b37a0050a82 x2b9c3f93d8888ad2 = new x03f56b37a0050a82();

	private readonly x03f56b37a0050a82 x4050c831a4485009 = new x03f56b37a0050a82();

	private readonly Stack x8af704b35c726a6e = new Stack();

	private int x17ff70856aa8e4ef = 1;

	private int x465ab30676a15e8d;

	private bool x08c23e44bf594fc0;

	internal virtual x03f56b37a0050a82 xd420ac3415caa02b => x2b9c3f93d8888ad2;

	protected x793a0d37961cea91(Stream stream)
	{
		xa49cef274042e702 = stream;
	}

	internal virtual void xd3d72812bb7aaf65()
	{
		x9a136b4afb8a57d8();
		if (x2b9c3f93d8888ad2.x23bf7b5d9dee25de)
		{
			switch (x2b9c3f93d8888ad2.x1dafd189c5465293())
			{
			case "\\uc":
				x17ff70856aa8e4ef = x2b9c3f93d8888ad2.xd6f9e3c5ae6509d7();
				break;
			case "\\u":
				x2a17cb3d6e02e1e6();
				break;
			}
		}
	}

	private void x2a17cb3d6e02e1e6()
	{
		if (x17ff70856aa8e4ef > 0)
		{
			x03f56b37a0050a82 x03f56b37a0050a83 = x2b9c3f93d8888ad2;
			x2b9c3f93d8888ad2 = x4050c831a4485009;
			xf62059aab8fa29ac();
			while (x465ab30676a15e8d > 0)
			{
				x9a136b4afb8a57d8();
			}
			x178eb896e6002c92();
			x2b9c3f93d8888ad2 = x03f56b37a0050a83;
		}
	}

	private void x9a136b4afb8a57d8()
	{
		while (true)
		{
			switch (x672ed37ee25c078c())
			{
			case 10:
			case 13:
				break;
			case 92:
				xf3cdd9ee6890977d();
				return;
			case 123:
				x4c2279581c5c5449();
				return;
			case 125:
				x927b2bb4647b72ca();
				return;
			case -1:
				x2b9c3f93d8888ad2.x74f5a1ef3906e23c(xe47a4d4f9d1aa906.xeababaadceb43553);
				x178eb896e6002c92();
				return;
			default:
				x46f11e4223000bd4();
				x7aafdccb9090cad4();
				return;
			}
		}
	}

	private void xf3cdd9ee6890977d()
	{
		int num = x672ed37ee25c078c();
		switch (num)
		{
		case 39:
			x46f11e4223000bd4();
			x46f11e4223000bd4();
			x7aafdccb9090cad4();
			break;
		case 42:
		case 45:
		case 58:
		case 92:
		case 95:
		case 123:
		case 124:
		case 125:
		case 126:
			xe4e9666ab0f5b26c(num);
			break;
		case 10:
		case 13:
			x2b9c3f93d8888ad2.xdbac92cad578ee39("\\par");
			x2d7e9db43bcb3623();
			break;
		case -1:
			x2b9c3f93d8888ad2.x74f5a1ef3906e23c(xe47a4d4f9d1aa906.xeababaadceb43553);
			x178eb896e6002c92();
			break;
		default:
			x88d1ce95a1b4106d(num);
			break;
		}
	}

	private void x4c2279581c5c5449()
	{
		if (x08c23e44bf594fc0)
		{
			x178eb896e6002c92();
			x46f11e4223000bd4();
		}
		else
		{
			x2b9c3f93d8888ad2.x74f5a1ef3906e23c(xe47a4d4f9d1aa906.x612a143b812c1686);
			x8af704b35c726a6e.Push(x17ff70856aa8e4ef);
		}
	}

	private void x927b2bb4647b72ca()
	{
		if (x08c23e44bf594fc0)
		{
			x178eb896e6002c92();
			x46f11e4223000bd4();
			return;
		}
		x2b9c3f93d8888ad2.x74f5a1ef3906e23c(xe47a4d4f9d1aa906.x479f6421165579eb);
		if (x8af704b35c726a6e.Count > 0)
		{
			x17ff70856aa8e4ef = (int)x8af704b35c726a6e.Pop();
		}
	}

	private void xe4e9666ab0f5b26c(int xe7ebe10fa44d8d49)
	{
		x2b9c3f93d8888ad2.x74f5a1ef3906e23c(xe47a4d4f9d1aa906.xbb3b746e67ad7684);
		x2b9c3f93d8888ad2.xc351d479ff7ee789(92);
		x2b9c3f93d8888ad2.xc351d479ff7ee789(xe7ebe10fa44d8d49);
		x2d7e9db43bcb3623();
	}

	private void x88d1ce95a1b4106d(int xe7ebe10fa44d8d49)
	{
		x2b9c3f93d8888ad2.x74f5a1ef3906e23c(xe47a4d4f9d1aa906.xbb3b746e67ad7684);
		x2b9c3f93d8888ad2.xc351d479ff7ee789(92);
		while (x0d299f323d241756.x4083ed3571df5d9e(xe7ebe10fa44d8d49))
		{
			x2b9c3f93d8888ad2.xc351d479ff7ee789(xe7ebe10fa44d8d49);
			xe7ebe10fa44d8d49 = x672ed37ee25c078c();
		}
		int x1be93eed8950d = x2b9c3f93d8888ad2.x1be93eed8950d961;
		if (xe7ebe10fa44d8d49 == 45)
		{
			x2b9c3f93d8888ad2.xc351d479ff7ee789(xe7ebe10fa44d8d49);
			xe7ebe10fa44d8d49 = x672ed37ee25c078c();
		}
		while (true)
		{
			if (!x0d299f323d241756.xf95996ff451b85fa(xe7ebe10fa44d8d49))
			{
				switch (xe7ebe10fa44d8d49)
				{
				case 46:
					goto IL_005e;
				default:
					x46f11e4223000bd4();
					break;
				case -1:
					break;
				}
				break;
			}
			goto IL_005e;
			IL_005e:
			x2b9c3f93d8888ad2.xc351d479ff7ee789(xe7ebe10fa44d8d49);
			xe7ebe10fa44d8d49 = x672ed37ee25c078c();
		}
		x2b9c3f93d8888ad2.x12576604d05c627a = x2b9c3f93d8888ad2.x1be93eed8950d961 - x1be93eed8950d;
		xb418fc96d173df19();
		if (x2b9c3f93d8888ad2.x1dafd189c5465293() == "\\bin")
		{
			x5af8ae5739917e3d();
		}
		x2d7e9db43bcb3623();
	}

	private void xb418fc96d173df19()
	{
		int num = x672ed37ee25c078c();
		if (num != 32 && num != -1)
		{
			x46f11e4223000bd4();
		}
	}

	private void x5af8ae5739917e3d()
	{
		int num = x2b9c3f93d8888ad2.xd6f9e3c5ae6509d7();
		x2b9c3f93d8888ad2.xd181aea83ad73c96 = new byte[num];
		xa49cef274042e702.Read(x2b9c3f93d8888ad2.xd181aea83ad73c96, 0, num);
	}

	private void x7aafdccb9090cad4()
	{
		x2b9c3f93d8888ad2.x74f5a1ef3906e23c(xe47a4d4f9d1aa906.x08c5d9f4b0653c8d);
		while (!x08c23e44bf594fc0 || x465ab30676a15e8d > 0)
		{
			int num = x672ed37ee25c078c();
			switch (num)
			{
			case 92:
				switch (x672ed37ee25c078c())
				{
				case 39:
				{
					int num2 = x0d299f323d241756.xe3ec68422266caf1((char)x672ed37ee25c078c());
					int num3 = x0d299f323d241756.xe3ec68422266caf1((char)x672ed37ee25c078c());
					int xe7ebe10fa44d8d = (num2 << 4) | num3;
					x2b9c3f93d8888ad2.xc351d479ff7ee789(xe7ebe10fa44d8d);
					x2d7e9db43bcb3623();
					break;
				}
				case -1:
					x178eb896e6002c92();
					return;
				default:
					x46f11e4223000bd4();
					x46f11e4223000bd4();
					return;
				}
				break;
			case 123:
			case 125:
				x46f11e4223000bd4();
				return;
			case -1:
				x178eb896e6002c92();
				return;
			default:
				x2b9c3f93d8888ad2.xc351d479ff7ee789(num);
				x2d7e9db43bcb3623();
				break;
			case 10:
			case 13:
				break;
			}
		}
	}

	private void xf62059aab8fa29ac()
	{
		x465ab30676a15e8d = x17ff70856aa8e4ef;
		x08c23e44bf594fc0 = true;
	}

	private void x178eb896e6002c92()
	{
		x465ab30676a15e8d = 0;
		x08c23e44bf594fc0 = false;
	}

	private void x2d7e9db43bcb3623()
	{
		x465ab30676a15e8d--;
	}

	private int x672ed37ee25c078c()
	{
		return xa49cef274042e702.ReadByte();
	}

	private void x46f11e4223000bd4()
	{
		xa49cef274042e702.Position -= 1;
	}
}
