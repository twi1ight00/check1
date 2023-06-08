using System.IO;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;

namespace xaf73fad8cede26de;

internal class x924900eaa00682cf : x71c14a6ab21fb09c
{
	public x924900eaa00682cf(int jpegQuality, x54b98d0096d7251a warningCallback, x3959df40367ac8a3 warningSource)
		: base(jpegQuality, warningCallback, warningSource)
	{
	}

	internal override bool xfb5afe0c4cc0f96b(byte[] x43e181e083db6cdf)
	{
		return xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(x43e181e083db6cdf) switch
		{
			xfe2ff3c162b47c70.x796ab23ce57ee1e0 => xd65d61f5ffa3cd8f(x43e181e083db6cdf), 
			xfe2ff3c162b47c70.x6339cdb9e2b512c7 => x7e662dbae1231c07(x43e181e083db6cdf), 
			xfe2ff3c162b47c70.x15c106572f1e1fbf => x4f3df15b618c297e(x43e181e083db6cdf), 
			_ => false, 
		};
	}

	internal override bool x87f8d22ca4dc9041(xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		switch (x0182a6dae298f8a4)
		{
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
		case xfe2ff3c162b47c70.x15c106572f1e1fbf:
			return true;
		default:
			return false;
		}
	}

	internal static bool xd65d61f5ffa3cd8f(byte[] x43e181e083db6cdf)
	{
		using (MemoryStream memoryStream = new MemoryStream(x43e181e083db6cdf))
		{
			xa8866d7566da0aa2 xa8866d7566da0aa = new xa8866d7566da0aa2(memoryStream);
			xa8866d7566da0aa.xdb264d863790ee7b();
			ushort num = xa8866d7566da0aa.xdb264d863790ee7b();
			while ((num & 0xFFF0) != 65472 || num == 65476 || num == 65484)
			{
				switch (num)
				{
				case 65504:
				case 65505:
				case 65506:
				case 65517:
				case 65518:
					return true;
				}
				ushort num2 = xa8866d7566da0aa.xdb264d863790ee7b();
				memoryStream.Seek(num2 - 2, SeekOrigin.Current);
				num = xa8866d7566da0aa.xdb264d863790ee7b();
			}
		}
		return false;
	}

	internal static bool x7e662dbae1231c07(byte[] x43e181e083db6cdf)
	{
		using MemoryStream memoryStream = new MemoryStream(x43e181e083db6cdf);
		xa8866d7566da0aa2 xa8866d7566da0aa = new xa8866d7566da0aa2(memoryStream);
		memoryStream.Position = 8L;
		string text = "";
		string text2 = "";
		bool flag = true;
		while (memoryStream.Position <= memoryStream.Length - 8)
		{
			uint num = xa8866d7566da0aa.x2aa9a7ff4efa6ddf();
			string text3 = new string(xa8866d7566da0aa.x9a839f0ae94bc95f(4));
			if (flag)
			{
				text = text3;
				flag = false;
			}
			text2 = text3;
			if (memoryStream.Position + num + 4 > memoryStream.Length)
			{
				break;
			}
			memoryStream.Seek(num + 4, SeekOrigin.Current);
		}
		return text == "IHDR" && text2 == "IEND";
	}

	internal static bool x4f3df15b618c297e(byte[] x43e181e083db6cdf)
	{
		x1c047fe8b1465e42 x1c047fe8b1465e = new x1c047fe8b1465e42(x43e181e083db6cdf);
		return x1c047fe8b1465e.x1bf0af404c1b05e9;
	}
}
