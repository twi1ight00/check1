using System.Collections;
using System.IO;
using Aspose.Words;
using x28925c9b27b37a46;
using x7c4557e104065fc9;

namespace xce0136f05681c5e9;

internal class x1cfc9afea06d5324
{
	private xe2ff3c3cd396cfd9 x09b9574bb5661d62;

	private readonly int xa24e05a5d3a22fd5;

	private readonly ArrayList xcb24734d87e68ca7;

	private int x894f49ebaf6595d8;

	internal ArrayList x7e0bf1cc35062bd7 => xcb24734d87e68ca7;

	internal x1cfc9afea06d5324(int navigationMapLevel)
	{
		xa24e05a5d3a22fd5 = navigationMapLevel;
		xcb24734d87e68ca7 = new ArrayList();
	}

	internal void xd586e0c16bdae7fc(xe2ff3c3cd396cfd9 xd3ab7f9bf8d35273)
	{
		x09b9574bb5661d62 = xd3ab7f9bf8d35273;
	}

	internal void x84bc62e29f758549(bool x094308e428eb5b33, Paragraph x41baca1d6c0c2e8e, x1a78664fa10a3755 x9e5248b49f0df7e8)
	{
		if (xa24e05a5d3a22fd5 <= 0 || !x41baca1d6c0c2e8e.xc8d1bb1390d5266d)
		{
			return;
		}
		int x8301ab10c226b0c = x9e5248b49f0df7e8.x8301ab10c226b0c2;
		if (x8301ab10c226b0c < 1 || x8301ab10c226b0c > 9)
		{
			return;
		}
		int num = x8301ab10c226b0c - 1 + 1;
		if (num > xa24e05a5d3a22fd5)
		{
			return;
		}
		string text = x9f265cdf86e37e15.x633d57e35b6715a4(x41baca1d6c0c2e8e, x579197826ce035a3: true, x41baca1d6c0c2e8e, x230d76aa903b832a: true, x39abdfb3e1bf0b2a: true).Trim();
		if (text.Length == 0)
		{
			return;
		}
		x3b71b4b4a316ac7f x3b71b4b4a316ac7f = new x3b71b4b4a316ac7f();
		x3b71b4b4a316ac7f.xcd25f8502121b335 = "navPoint_" + ++x894f49ebaf6595d8;
		x3b71b4b4a316ac7f.x504f3d4040b356d7 = num;
		x3b71b4b4a316ac7f.xabbaab6f446c47aa = text;
		if (x094308e428eb5b33)
		{
			string text2 = (x41baca1d6c0c2e8e.xbc0119d7471ef12e ? x41baca1d6c0c2e8e.ListLabel.LabelString : null);
			if (text2 != null && text2 != "*")
			{
				x3b71b4b4a316ac7f.xabbaab6f446c47aa = $"{text2} {x3b71b4b4a316ac7f.xabbaab6f446c47aa}";
			}
		}
		if (x09b9574bb5661d62.xabe2ed7cd91ad78c != string.Empty)
		{
			x3b71b4b4a316ac7f.xf1597f82d8591ad4 = x09b9574bb5661d62.xabe2ed7cd91ad78c;
		}
		xcb24734d87e68ca7.Add(x3b71b4b4a316ac7f);
		x09b9574bb5661d62.xe1410f585439c7d4.xff520a0047c27122("id", x3b71b4b4a316ac7f.xcd25f8502121b335);
	}

	internal void x8617c5c184975779(string xafe2f3653ee64ebc)
	{
		if (xcb24734d87e68ca7.Count == 0 || ((x3b71b4b4a316ac7f)xcb24734d87e68ca7[xcb24734d87e68ca7.Count - 1]).xf1597f82d8591ad4 != xafe2f3653ee64ebc)
		{
			x3b71b4b4a316ac7f x3b71b4b4a316ac7f = new x3b71b4b4a316ac7f();
			x3b71b4b4a316ac7f.x504f3d4040b356d7 = 1;
			x3b71b4b4a316ac7f.xabbaab6f446c47aa = Path.GetFileNameWithoutExtension(xafe2f3653ee64ebc);
			x3b71b4b4a316ac7f.xf1597f82d8591ad4 = xafe2f3653ee64ebc;
			xcb24734d87e68ca7.Add(x3b71b4b4a316ac7f);
		}
	}
}
