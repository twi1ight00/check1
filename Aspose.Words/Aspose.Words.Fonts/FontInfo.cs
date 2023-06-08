using System;
using System.Collections;
using x4b4f8b01ec4cb4b2;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Fonts;

public class FontInfo
{
	internal const int xd619e6bfccf7d727 = 10;

	internal const int x2b890db50aa4418a = 24;

	private FontPitch xdfe596e25697f541;

	private bool x3704a8705bbfe8cb = true;

	private FontFamily x82015ababcafd290;

	private int x8757d6e73d955cca;

	private int x5f46f211b314b809;

	private byte[] x127d5e9b8a618cbf;

	private byte[] xbd982a6f309e0b35;

	private string xc61ff88f1f98652d = "";

	private string x9bb92a035769093b = "";

	private x1bc48e7da74ec434 x3533d3fe4cfcefdc;

	public FontPitch Pitch
	{
		get
		{
			return xdfe596e25697f541;
		}
		set
		{
			xdfe596e25697f541 = value;
		}
	}

	public bool IsTrueType
	{
		get
		{
			return x3704a8705bbfe8cb;
		}
		set
		{
			x3704a8705bbfe8cb = value;
		}
	}

	public FontFamily Family
	{
		get
		{
			return x82015ababcafd290;
		}
		set
		{
			x82015ababcafd290 = value;
		}
	}

	internal int x64e2a404bc6b1659
	{
		get
		{
			return x8757d6e73d955cca;
		}
		set
		{
			x8757d6e73d955cca = value;
		}
	}

	public int Charset
	{
		get
		{
			return x5f46f211b314b809;
		}
		set
		{
			x5f46f211b314b809 = value;
		}
	}

	public byte[] Panose
	{
		get
		{
			return x127d5e9b8a618cbf;
		}
		set
		{
			if (value != null && value.Length != 10)
			{
				throw new ArgumentException("Incorrect array length.");
			}
			x127d5e9b8a618cbf = value;
		}
	}

	internal byte[] x9df4cc3a14431dcc
	{
		get
		{
			return xbd982a6f309e0b35;
		}
		set
		{
			if (value != null && value.Length != 24)
			{
				throw new ArgumentException("Incorrect array length.");
			}
			xbd982a6f309e0b35 = value;
		}
	}

	public string Name => xc61ff88f1f98652d;

	public string AltName
	{
		get
		{
			return x9bb92a035769093b;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			x9bb92a035769093b = value;
		}
	}

	internal FontInfo()
	{
	}

	internal FontInfo(string name)
	{
		x54f99ef1e934e59c(name);
	}

	internal void x54f99ef1e934e59c(string xc15bd84e01929885)
	{
		if (xc15bd84e01929885 == null)
		{
			throw new ArgumentNullException("name");
		}
		xc61ff88f1f98652d = xc15bd84e01929885;
	}

	internal FontInfo x8b61531c8ea35b85()
	{
		FontInfo fontInfo = (FontInfo)MemberwiseClone();
		if (x3533d3fe4cfcefdc != null)
		{
			fontInfo.x3533d3fe4cfcefdc = x3533d3fe4cfcefdc.x8b61531c8ea35b85();
		}
		return fontInfo;
	}

	internal void xd5da23b762ce52a2(FontInfo x21bb7453c754fdb1)
	{
		xd2c42e928d0ada98(x21bb7453c754fdb1);
		if (x21bb7453c754fdb1.x3533d3fe4cfcefdc != null)
		{
			if (x3533d3fe4cfcefdc == null)
			{
				x3533d3fe4cfcefdc = new x1bc48e7da74ec434();
			}
			x3533d3fe4cfcefdc.xd5da23b762ce52a2(x21bb7453c754fdb1.x3533d3fe4cfcefdc);
		}
	}

	internal x393d198b88cf5ed5[] xf24d2f6e3cbd9dd5(EmbeddedFontFormat x5786461d089b10a0)
	{
		if (x3533d3fe4cfcefdc != null)
		{
			return x3533d3fe4cfcefdc.x6a81c6e12edbe4cb(x5786461d089b10a0);
		}
		return null;
	}

	public byte[] GetEmbeddedFont(EmbeddedFontFormat format, EmbeddedFontStyle style)
	{
		if (x3533d3fe4cfcefdc == null)
		{
			return null;
		}
		return x3533d3fe4cfcefdc.x38758cbbee49e4cb(format, style)?.x6b73aa01aa019d3a;
	}

	internal void x88b4954c294baf8f(byte[] x0db5e88527e18b81, EmbeddedFontFormat x39960861338bf735, EmbeddedFontStyle x768946a353232575, bool xa41bb3cedcce769d)
	{
		if (x3533d3fe4cfcefdc == null)
		{
			x3533d3fe4cfcefdc = new x1bc48e7da74ec434();
		}
		x3533d3fe4cfcefdc.xd6b6ed77479ef68c(new x393d198b88cf5ed5(x0db5e88527e18b81, x39960861338bf735, x768946a353232575, xa41bb3cedcce769d));
	}

	internal ArrayList xad8f5d5549eb487c()
	{
		ArrayList arrayList = new ArrayList();
		string[] array = x9bb92a035769093b.Split(',');
		foreach (string text in array)
		{
			string text2 = text.Trim(' ');
			if (x0d299f323d241756.x5959bccb67bbf051(text2))
			{
				arrayList.Add(text2);
			}
		}
		return arrayList;
	}

	private void xd2c42e928d0ada98(FontInfo x21bb7453c754fdb1)
	{
		if (xdfe596e25697f541 == FontPitch.Default)
		{
			xdfe596e25697f541 = x21bb7453c754fdb1.xdfe596e25697f541;
		}
		if (x9bb92a035769093b == "")
		{
			x9bb92a035769093b = x21bb7453c754fdb1.x9bb92a035769093b;
		}
		if (x82015ababcafd290 == FontFamily.Auto)
		{
			x82015ababcafd290 = x21bb7453c754fdb1.x82015ababcafd290;
		}
		if (x8757d6e73d955cca == 0)
		{
			x8757d6e73d955cca = x21bb7453c754fdb1.x8757d6e73d955cca;
		}
		if (x3704a8705bbfe8cb)
		{
			x3704a8705bbfe8cb = x21bb7453c754fdb1.x3704a8705bbfe8cb;
		}
		if (x5f46f211b314b809 == 0)
		{
			x5f46f211b314b809 = x21bb7453c754fdb1.x5f46f211b314b809;
		}
		if (x127d5e9b8a618cbf == null)
		{
			x127d5e9b8a618cbf = x21bb7453c754fdb1.x127d5e9b8a618cbf;
		}
		if (xbd982a6f309e0b35 == null)
		{
			xbd982a6f309e0b35 = x21bb7453c754fdb1.xbd982a6f309e0b35;
		}
	}
}
