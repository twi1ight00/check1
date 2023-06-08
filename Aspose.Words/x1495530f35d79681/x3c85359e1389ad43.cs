using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;
using xfbd1009a0cbb9842;

namespace x1495530f35d79681;

internal class x3c85359e1389ad43 : xc1dcd6189d01216e
{
	internal byte[] x303ddb1b000492b0;

	private readonly StringBuilder xaf71375b4dffdc5c = new StringBuilder();

	private readonly Stack xd48deb218af504df = new Stack();

	private int xe269097803cc9c0e;

	private x58bf2a36f9adf9a9 x1b8d68194b6218f8;

	private Paragraph x19416ebd6f65d811;

	private IWarningCallback xa056586c1f99e199;

	private WarningSource x006c2eca1459fa26;

	internal virtual bool x57b319ed721a743d
	{
		get
		{
			throw new InvalidOperationException("Abstract implementation is called.");
		}
	}

	internal StringBuilder xc6e279ea85863f66 => xaf71375b4dffdc5c;

	internal Stack xa7799d48a3e6b897 => xd48deb218af504df;

	internal int xbd89d3a43f3ef7f9
	{
		get
		{
			return xe269097803cc9c0e;
		}
		set
		{
			xe269097803cc9c0e = value;
		}
	}

	internal x58bf2a36f9adf9a9 x58bf2a36f9adf9a9
	{
		get
		{
			return x1b8d68194b6218f8;
		}
		set
		{
			x1b8d68194b6218f8 = value;
		}
	}

	internal int x44a84e85bafd5806 => x15e971129fd80714.x43fcc3f62534530b(xab627fb39c3bfcd8(base.xd2f68ee6f47e9dfb, x4e53f306e5437b97.xa7fcf6694214daba));

	internal int xeeed7b3df57c138f => x15e971129fd80714.x43fcc3f62534530b(xab627fb39c3bfcd8(base.xd2f68ee6f47e9dfb, x4e53f306e5437b97.x45e95ef12ed10838));

	internal new bool xc3be6b142c6aca84 => xb2be52a3d2802fc5(base.xd2f68ee6f47e9dfb);

	internal Paragraph x413affb5b90b6470
	{
		get
		{
			return x19416ebd6f65d811;
		}
		set
		{
			x19416ebd6f65d811 = value;
		}
	}

	internal x3c85359e1389ad43(Stream stream)
		: this(stream, null, WarningSource.Nrx)
	{
	}

	internal x3c85359e1389ad43(Stream stream, IWarningCallback warningCallback, WarningSource warningSource)
		: base(stream)
	{
		xa056586c1f99e199 = warningCallback;
		x006c2eca1459fa26 = warningSource;
	}

	internal x3c85359e1389ad43(string xml, Hashtable namespaces)
		: this(xml, namespaces, null, WarningSource.Nrx)
	{
	}

	internal x3c85359e1389ad43(string xml, Hashtable namespaces, IWarningCallback warningCallback, WarningSource warningSource)
		: base(xml, namespaces)
	{
		xa056586c1f99e199 = warningCallback;
		x006c2eca1459fa26 = warningSource;
	}

	public override void IgnoreElement()
	{
		string xc2358fbac7da3d = $"Import of element '{base.xa66385d80d4d296f}' is not supported in {WarningInfo.xc0178e023f7702e3(x006c2eca1459fa26)} format by Aspose.Words.";
		xbd5e5733680bbfc8(WarningType.MinorFormattingLossCategory, x006c2eca1459fa26, xc2358fbac7da3d);
	}

	internal void xbd5e5733680bbfc8(WarningType x9f91de645a9fe01a, WarningSource x697d2859ebdde9ec, string xc2358fbac7da3d45)
	{
		base.IgnoreElement();
		xbbf9a1ead81dd3a1(x9f91de645a9fe01a, x697d2859ebdde9ec, xc2358fbac7da3d45);
	}

	internal void xcd9275cfaac59c99()
	{
		base.IgnoreElement();
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, WarningSource x697d2859ebdde9ec, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, x697d2859ebdde9ec, xc2358fbac7da3d45));
		}
	}

	internal string xf3ea3ee1c9ee5265()
	{
		return xd68abcd61e368af9("id", null);
	}

	internal string xbbfc54380705e01e()
	{
		return xd68abcd61e368af9("val", null);
	}

	internal int xb8ac33c25776194c()
	{
		string text = xbbfc54380705e01e();
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return xca004f56614e2431.x59884ab46dd0d856(text);
		}
		return 0;
	}

	internal bool xe04906126da94dd1()
	{
		string xbcea506a33cf = xbbfc54380705e01e();
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
		{
			return xb2be52a3d2802fc5(xbcea506a33cf);
		}
		return true;
	}

	internal x9b28b1f7f0cc963f x73d42b465084186e()
	{
		string xbcea506a33cf = xbbfc54380705e01e();
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
		{
			return x9b28b1f7f0cc963f.x1e5f5c3e4c508bf0(xb2be52a3d2802fc5(xbcea506a33cf));
		}
		return x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
	}

	internal bool xe90b56390d1b0697(bool xc6e85c82d0d89508)
	{
		switch (x2a1ea9d24e62bf84())
		{
		case "true":
		case "t":
			return true;
		case "false":
		case "f":
			return false;
		default:
			return xc6e85c82d0d89508;
		}
	}

	internal char x50a0aa193f9f43f8(xeedad81aaed42a76 x789564759d365819)
	{
		char result = '\uf0ff';
		string text = "Symbol";
		while (x1ac1960adc8c4c39())
		{
			switch (base.xa66385d80d4d296f)
			{
			case "font":
				text = base.xd2f68ee6f47e9dfb;
				break;
			case "char":
				result = (char)xc1b08afa36bf580c.x5c612ff105e66e13(base.xd2f68ee6f47e9dfb);
				break;
			}
		}
		x789564759d365819.x51cf23ce6e71b84c = text;
		x789564759d365819.xd08cbc518cf39317 = text;
		return result;
	}

	internal Border x204e881194ee5797()
	{
		return x83c908954dcf1ab1(x4a70132c541c3e73: true);
	}

	internal Border xd5dc54a8d91c4443()
	{
		return x83c908954dcf1ab1(x4a70132c541c3e73: false);
	}

	private Border x83c908954dcf1ab1(bool x4a70132c541c3e73)
	{
		Border border = new Border();
		bool flag = false;
		bool flag2 = false;
		while (x1ac1960adc8c4c39())
		{
			switch (base.xa66385d80d4d296f)
			{
			case "val":
				border.LineStyle = ReadLineStyle();
				flag = base.xd2f68ee6f47e9dfb == "none";
				break;
			case "sz":
				border.xab266ea415f07c09 = base.xbba6773b8ce56a01;
				break;
			case "space":
				border.x1f2d5df87a5c4f81 = base.xbba6773b8ce56a01;
				break;
			case "color":
				border.x63b1a7c31a962459 = xc1b08afa36bf580c.x5e71f16a78faf353(base.xd2f68ee6f47e9dfb);
				break;
			case "shadow":
				border.Shadow = xc3be6b142c6aca84;
				break;
			case "frame":
				border.x227665e444fb500a = xc3be6b142c6aca84;
				break;
			case "themeColor":
				border.x19119439284aead2 = base.xd2f68ee6f47e9dfb;
				break;
			case "themeShade":
				border.x545df332a972f97f = base.xd2f68ee6f47e9dfb;
				break;
			case "themeTint":
				border.xc7a5a1bef7198132 = base.xd2f68ee6f47e9dfb;
				break;
			case "bdrwidth":
				flag2 = base.xbba6773b8ce56a01 == 0;
				break;
			}
		}
		if (x4a70132c541c3e73 && flag && !flag2)
		{
			return null;
		}
		return border;
	}

	internal Shading x8e2bd36fcdee9a28()
	{
		Shading shading = new Shading();
		while (x1ac1960adc8c4c39())
		{
			switch (base.xa66385d80d4d296f)
			{
			case "val":
				shading.Texture = x72a0c846678ecaf9.x1d3745571808912d(base.xd2f68ee6f47e9dfb);
				break;
			case "color":
				shading.xc290f60df004e384 = xc1b08afa36bf580c.x5e71f16a78faf353(base.xd2f68ee6f47e9dfb);
				break;
			case "fill":
				shading.x0e18178ac4b2272f = xc1b08afa36bf580c.x5e71f16a78faf353(base.xd2f68ee6f47e9dfb);
				break;
			case "themeColor":
				shading.x19119439284aead2 = base.xd2f68ee6f47e9dfb;
				break;
			case "themeShade":
				shading.x545df332a972f97f = base.xd2f68ee6f47e9dfb;
				break;
			case "themeTint":
				shading.xc7a5a1bef7198132 = base.xd2f68ee6f47e9dfb;
				break;
			case "themeFill":
				shading.xdb84466ee4f5c751 = base.xd2f68ee6f47e9dfb;
				break;
			case "themeFillShade":
				shading.x3799d35904b4df9e = base.xd2f68ee6f47e9dfb;
				break;
			case "themeFillTint":
				shading.x32bc86f72d097c5d = base.xd2f68ee6f47e9dfb;
				break;
			}
		}
		return shading;
	}

	internal int xcd17950d1ac4bef2()
	{
		return xe210c2db3704ad78().x7680505e84ce0354;
	}

	internal PreferredWidth xe210c2db3704ad78()
	{
		int num = 0;
		PreferredWidthType preferredWidthType = PreferredWidthType.Auto;
		bool flag = false;
		while (x1ac1960adc8c4c39())
		{
			switch (base.xa66385d80d4d296f)
			{
			case "w":
				flag = xb9677deb3281ce2d(base.xd2f68ee6f47e9dfb);
				num = xf2f856bffb5c6cf3(base.xd2f68ee6f47e9dfb);
				break;
			case "type":
				preferredWidthType = x72a0c846678ecaf9.xa0f6fd8a38cb6638(base.xd2f68ee6f47e9dfb);
				break;
			}
		}
		if (preferredWidthType == PreferredWidthType.Percent && flag)
		{
			num *= 50;
		}
		return PreferredWidth.x6b44e3efc21fd5b4(preferredWidthType, num);
	}

	internal int xb3053d30ad14f198()
	{
		return x15e971129fd80714.x43fcc3f62534530b(xab627fb39c3bfcd8(xbbfc54380705e01e(), x4e53f306e5437b97.xa7fcf6694214daba));
	}

	internal int x714de9655a456160()
	{
		return x15e971129fd80714.x43fcc3f62534530b(xab627fb39c3bfcd8(xbbfc54380705e01e(), x4e53f306e5437b97.x45e95ef12ed10838));
	}

	internal float xab627fb39c3bfcd8(string xbcea506a33cf9111, x4e53f306e5437b97 x89067660e4a624fa)
	{
		float result = 0f;
		if (xbcea506a33cf9111 != string.Empty)
		{
			int num = xbcea506a33cf9111.Length - 1;
			while (num >= 0 && (xbcea506a33cf9111[num] < '0' || xbcea506a33cf9111[num] > '9'))
			{
				num--;
			}
			double num2 = xca004f56614e2431.xf5ece46c5d72e3b9(xbcea506a33cf9111.Substring(0, num + 1));
			x4e53f306e5437b97 x642eac0a1466d67b = x21d02e261b563269(xbcea506a33cf9111.Substring(num + 1, xbcea506a33cf9111.Length - num - 1), x89067660e4a624fa);
			if (!double.IsNaN(num2))
			{
				result = (float)xca52d8cae345cabc(num2, x642eac0a1466d67b, x89067660e4a624fa);
			}
		}
		return result;
	}

	internal int xf2f856bffb5c6cf3(string x37cf7043760b312e)
	{
		if (xb9677deb3281ce2d(x37cf7043760b312e))
		{
			return x15e971129fd80714.x43fcc3f62534530b(xca004f56614e2431.xec25d08a2af152f0(x37cf7043760b312e.Substring(0, x37cf7043760b312e.Length - 1)));
		}
		return xca004f56614e2431.x59884ab46dd0d856(x37cf7043760b312e);
	}

	protected virtual LineStyle ReadLineStyle()
	{
		return LineStyle.None;
	}

	private static bool xb9677deb3281ce2d(string x37cf7043760b312e)
	{
		if (x37cf7043760b312e.Length >= 1)
		{
			return x37cf7043760b312e[x37cf7043760b312e.Length - 1] == '%';
		}
		return false;
	}

	private static double xca52d8cae345cabc(double x389f579bb09d94ed, x4e53f306e5437b97 x642eac0a1466d67b, x4e53f306e5437b97 x89067660e4a624fa)
	{
		double num = x389f579bb09d94ed;
		if (x642eac0a1466d67b != x89067660e4a624fa)
		{
			switch (x642eac0a1466d67b)
			{
			case x4e53f306e5437b97.x12a36b56521f3632:
				num = x4574ea26106f0edb.x9adffc4de2e5ac97(x389f579bb09d94ed);
				break;
			case x4e53f306e5437b97.xfdb2b0e853227a8e:
				num = x4574ea26106f0edb.x5612f4c9f83f95d3(x389f579bb09d94ed);
				break;
			case x4e53f306e5437b97.x9a0c4af681302747:
				num = x4574ea26106f0edb.x7ee6ab51d3d84831(x389f579bb09d94ed);
				break;
			case x4e53f306e5437b97.x384ccec3164499ea:
				num *= 12.0;
				break;
			default:
				throw new InvalidOperationException("Unknown universal measure.");
			case x4e53f306e5437b97.x865739e9b580d3cf:
				break;
			}
			num *= (double)xe39c34ae47f820a0(x89067660e4a624fa);
		}
		return num;
	}

	private static float xe39c34ae47f820a0(x4e53f306e5437b97 x1c40252c1b8530fe)
	{
		return x1c40252c1b8530fe switch
		{
			x4e53f306e5437b97.xa7fcf6694214daba => 2f, 
			x4e53f306e5437b97.x45e95ef12ed10838 => 20f, 
			_ => 1f, 
		};
	}

	private static x4e53f306e5437b97 x21d02e261b563269(string x1c40252c1b8530fe, x4e53f306e5437b97 x89067660e4a624fa)
	{
		switch (x1c40252c1b8530fe)
		{
		case "in":
			return x4e53f306e5437b97.x12a36b56521f3632;
		case "pt":
			return x4e53f306e5437b97.x865739e9b580d3cf;
		case "mm":
			return x4e53f306e5437b97.xfdb2b0e853227a8e;
		case "cm":
			return x4e53f306e5437b97.x9a0c4af681302747;
		case "pc":
		case "pi":
			return x4e53f306e5437b97.x384ccec3164499ea;
		case "":
			return x89067660e4a624fa;
		default:
			throw new ArgumentOutOfRangeException($"Unknown universal measure {x1c40252c1b8530fe}");
		}
	}

	internal bool xb2be52a3d2802fc5(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "on":
		case "1":
		case "true":
		case "t":
			return true;
		case "off":
		case "0":
		case "false":
		case "f":
			return false;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pmnbfoecpnlcpncdnnjdcoaegnhefioeinffammfimdgomkgllbhdhihglphmlgimlnihgejfkljpkckofjkcgalhkhldkolbifmfjmmcjdnnhknpjbodjiofipoeegpkdnpiheaiilaficbaijbehackghckhocghfdegmdkcde", 270343546)));
		}
	}
}
