using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words.Lists;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xd2754ae26d400653;
using xf9a9481c3f63a419;

namespace Aspose.Words;

[JavaGenericArguments("Iterable<Style>")]
public class StyleCollection : IEnumerable
{
	internal const int x43b2b706e9274155 = 15;

	internal const int xe0aaf2f328f76af9 = 14;

	internal const int xb26dfb879890faf8 = 156;

	internal const int xad424bd58f411928 = 267;

	internal const int x7fcec474d1038a5e = 4;

	internal const int x0554a12ee69092fa = 7;

	private DocumentBase x232be220f517f721;

	private xeedad81aaed42a76 x067ea144d8539d30 = new xeedad81aaed42a76();

	private x1a78664fa10a3755 x9fb31b512ec52022 = new x1a78664fa10a3755();

	private x09ce2c02826e31a6 x23435b520f97383d = new x09ce2c02826e31a6();

	private xd345c73dd1b16b74 x3097e66d61f8bec1 = new xd345c73dd1b16b74();

	private x09ce2c02826e31a6 x2fc747cf1de1e7a7 = new x09ce2c02826e31a6();

	private x90347bcd8deede01 x5e6674d07ce0c0e7 = new x90347bcd8deede01();

	private bool x733e69dbce48bdee;

	private bool x720c607f81e78572;

	private static Document xc4546740b2556359;

	private static readonly object x5eca7109b2d5a282 = new object();

	private static Document x83c429ebdaf8a692;

	private static readonly object x83250679ff7cc9ee = new object();

	public DocumentBase Document => x232be220f517f721;

	public int Count => x23435b520f97383d.xd44988f225497f3a;

	public Style this[string name] => xe931c242f6b9055f(name, x988fcf605f8efa7e: true);

	public Style this[StyleIdentifier sti] => xf21e14e2c9db279a(sti, x988fcf605f8efa7e: true);

	public Style this[int index] => (Style)x23435b520f97383d.x6d3720b962bd3112(index);

	internal int x1d457daa68e68b4f
	{
		get
		{
			if (x23435b520f97383d.xd44988f225497f3a <= 0)
			{
				return -1;
			}
			return x23435b520f97383d.xf15263674eb297bb(x23435b520f97383d.xd44988f225497f3a - 1);
		}
	}

	internal xeedad81aaed42a76 x27096df7ca0cfe2e => x067ea144d8539d30;

	internal bool x17edf608baa39956
	{
		get
		{
			return x733e69dbce48bdee;
		}
		set
		{
			x733e69dbce48bdee = value;
		}
	}

	internal bool x3dde3ba6a116b7ee
	{
		get
		{
			return x720c607f81e78572;
		}
		set
		{
			x720c607f81e78572 = value;
		}
	}

	internal x1a78664fa10a3755 xf4eb04b8b9073eeb => x9fb31b512ec52022;

	private static StyleCollection x56dcc613f7b2241b
	{
		get
		{
			if (xc4546740b2556359 == null)
			{
				lock (x5eca7109b2d5a282)
				{
					if (xc4546740b2556359 == null)
					{
						xc4546740b2556359 = x22d89d0b7a1dc9e6("Aspose.Words.Resources.AllStyles2003.docx");
					}
				}
			}
			return xc4546740b2556359.Styles;
		}
	}

	private static StyleCollection xdfc8ebb0aff5d999
	{
		get
		{
			if (x83c429ebdaf8a692 == null)
			{
				lock (x83250679ff7cc9ee)
				{
					if (x83c429ebdaf8a692 == null)
					{
						x83c429ebdaf8a692 = x22d89d0b7a1dc9e6("Aspose.Words.Resources.AllStyles2007.docx");
					}
				}
			}
			return x83c429ebdaf8a692.Styles;
		}
	}

	internal StyleCollection xc6b4c6fa9a60b0fc => x48416779f53c911f(x18445bcef0e65876());

	internal x90347bcd8deede01 x90347bcd8deede01 => x5e6674d07ce0c0e7;

	internal StyleCollection(DocumentBase doc)
	{
		x232be220f517f721 = doc;
	}

	internal static StyleCollection x48416779f53c911f(LoadFormat xdef7b99b7fc67519)
	{
		if (xdef7b99b7fc67519 != LoadFormat.Doc && xdef7b99b7fc67519 == LoadFormat.Docx)
		{
			return xdfc8ebb0aff5d999;
		}
		return x56dcc613f7b2241b;
	}

	[JavaThrows(false)]
	private static Document x22d89d0b7a1dc9e6(string xc877a145d7efe594)
	{
		try
		{
			using Stream stream = xed747ca236d86aa0.xe1cd764b6fb0d6f6(xc877a145d7efe594);
			Document document = new Document(stream);
			document.Styles.x160c33d5600b9bc8();
			return document;
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ekjaplabjmhbgmobemfcgmmcpgddilkdilbehkiehkpeaggfpjnfpkegaklgakchfkjhoeaiejhigjoifefjfjmjdjdkfjkkfibllhilgipladgmdhnmmhenghlnbhcobcjopfapjghpibopkffapfmabfdbbfkbnebckeiciepceegdnpmdmeeemdlehecfaejfdeagndhglcogkcfhaplh", 1442187617)), innerException);
		}
	}

	internal int xdc32dcfe6668100d()
	{
		int num = System.Math.Max(x1d457daa68e68b4f, 14) + 1;
		if (num >= 4095)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fhcngijnaiaokihokhoocdfpahmpohdaogkagcbbhhibpgpbmggckbncegedffldpfcehgjelaaflfhfjfoflffglemgbedhmekhgpaimdiiodpinofjodnjpcekjclkboblccjlkcamlbhmkcompbfnebmnkbdonbkoenap", 2079511073)));
		}
		return num;
	}

	public IEnumerator GetEnumerator()
	{
		return x3097e66d61f8bec1.GetValueList().GetEnumerator();
	}

	public Style Add(StyleType type, string name)
	{
		if (type == StyleType.Table)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ojlmjlcndmjnamaoolhoamoojgfpjkmpfldafkkaojbbokibmjpbefgcfkncpiednildejcekijeceafcjhfajofcjfgcimgihdhdikhldbi", 1835453275)), "type");
		}
		x0d299f323d241756.x48501aec8e48c869(name, "name");
		Style style = Style.xebcf83b00134300b(type, xdc32dcfe6668100d(), StyleIdentifier.User, name);
		if (type == StyleType.List)
		{
			List list = x67af7bcbfd57c02b.x28d01548f153fdbe(Document.Lists, ListTemplate.NumberDefault);
			list.x178ff6dcbf808c38.xc657ea789af2c1f0 = style.x8301ab10c226b0c2;
			style.x1a78664fa10a3755.x71c63f7e57f7ede5 = list.ListId;
		}
		xd6b6ed77479ef68c(style);
		return style;
	}

	internal void x52b190e626f65140(string xbd5a2e7a4ff749c9)
	{
		Style style = xe931c242f6b9055f(xbd5a2e7a4ff749c9, x988fcf605f8efa7e: false);
		if (style == null)
		{
			throw new ArgumentException("Style not found.");
		}
		if (xc6b4c6fa9a60b0fc.xe931c242f6b9055f(xbd5a2e7a4ff749c9, x988fcf605f8efa7e: false) != null)
		{
			throw new ArgumentException("The built-in style cannot be deleted.");
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Style style2 = (Style)enumerator.Current;
				if (style2.xe709b224f455b863 == style.x8301ab10c226b0c2)
				{
					xf859b3fec6497ede(style2, style);
					style2.xe709b224f455b863 = 4095;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		x255ed75560e42420(style, style.x8301ab10c226b0c2, -1);
		if (style.xcb78713836fcc98a && style.Document is Document)
		{
			((Document)style.Document).Revisions.x52b190e626f65140(style);
		}
		x23435b520f97383d.x52b190e626f65140(style.x8301ab10c226b0c2);
		x3097e66d61f8bec1.Remove(style.Name);
	}

	internal void x255ed75560e42420(Style x44ecfea61c937b8e, int xddd12ddd8b1e4a90, int xbffa3aa7ac8f0075)
	{
		switch (x44ecfea61c937b8e.Type)
		{
		case StyleType.Character:
			x16f4db437ef1e20e(x44ecfea61c937b8e, xddd12ddd8b1e4a90, xbffa3aa7ac8f0075);
			break;
		case StyleType.Paragraph:
			xf83a86dc031ca72e(xddd12ddd8b1e4a90, xbffa3aa7ac8f0075);
			break;
		case StyleType.List:
			x2e9d2ce4940ea79b(x44ecfea61c937b8e, xddd12ddd8b1e4a90, xbffa3aa7ac8f0075);
			break;
		case StyleType.Table:
			xea34bad2f1a88dac(x44ecfea61c937b8e, xddd12ddd8b1e4a90, xbffa3aa7ac8f0075);
			break;
		}
	}

	private void xea34bad2f1a88dac(Style x44ecfea61c937b8e, int xddd12ddd8b1e4a90, int xbffa3aa7ac8f0075)
	{
		foreach (Row childNode in Document.GetChildNodes(NodeType.Row, isDeep: true))
		{
			if (childNode.xedb0eb766e25e0c9.x8301ab10c226b0c2 == xddd12ddd8b1e4a90)
			{
				if (xbffa3aa7ac8f0075 == -1)
				{
					childNode.xedb0eb766e25e0c9.x52b190e626f65140(50);
				}
				else
				{
					((x09ce2c02826e31a6)childNode.xedb0eb766e25e0c9).set_xe6d4b1b411ed94b5(50, (object)x44ecfea61c937b8e);
				}
			}
		}
	}

	private void x2e9d2ce4940ea79b(Style x44ecfea61c937b8e, int xddd12ddd8b1e4a90, int xbffa3aa7ac8f0075)
	{
		foreach (Paragraph childNode in Document.GetChildNodes(NodeType.Paragraph, isDeep: true))
		{
			if (childNode.x1a78664fa10a3755.x71c63f7e57f7ede5 != 0 && childNode.ListFormat.List.Style.x8301ab10c226b0c2 == xddd12ddd8b1e4a90)
			{
				if (xbffa3aa7ac8f0075 == -1)
				{
					childNode.x1a78664fa10a3755.x52b190e626f65140(1120);
					childNode.x1a78664fa10a3755.x52b190e626f65140(1110);
				}
				else
				{
					((x09ce2c02826e31a6)childNode.x1a78664fa10a3755).set_xe6d4b1b411ed94b5(1120, (object)x44ecfea61c937b8e);
					((x09ce2c02826e31a6)childNode.x1a78664fa10a3755).set_xe6d4b1b411ed94b5(1110, (object)x44ecfea61c937b8e);
				}
			}
		}
	}

	private void xf83a86dc031ca72e(int xddd12ddd8b1e4a90, int xbffa3aa7ac8f0075)
	{
		foreach (Paragraph childNode in Document.GetChildNodes(NodeType.Paragraph, isDeep: true))
		{
			if (childNode.x1a78664fa10a3755.x8301ab10c226b0c2 == xddd12ddd8b1e4a90)
			{
				if (xbffa3aa7ac8f0075 == -1)
				{
					childNode.x1a78664fa10a3755.x52b190e626f65140(1000);
				}
				else
				{
					((x09ce2c02826e31a6)childNode.x1a78664fa10a3755).set_xe6d4b1b411ed94b5(1000, (object)xbffa3aa7ac8f0075);
				}
			}
		}
	}

	private void x16f4db437ef1e20e(Style x44ecfea61c937b8e, int xddd12ddd8b1e4a90, int xbffa3aa7ac8f0075)
	{
		foreach (Run childNode in Document.GetChildNodes(NodeType.Run, isDeep: true))
		{
			if (childNode.xeedad81aaed42a76.x8301ab10c226b0c2 == xddd12ddd8b1e4a90)
			{
				if (xbffa3aa7ac8f0075 == -1)
				{
					childNode.xeedad81aaed42a76.x52b190e626f65140(50);
				}
				else
				{
					((x09ce2c02826e31a6)childNode.xeedad81aaed42a76).set_xe6d4b1b411ed94b5(50, (object)x44ecfea61c937b8e);
				}
			}
		}
	}

	private static void xf859b3fec6497ede(Style x44ecfea61c937b8e, Style xe2a2d7eb453e0c18)
	{
		switch (xe2a2d7eb453e0c18.Type)
		{
		case StyleType.Character:
			x44ecfea61c937b8e.xeedad81aaed42a76 = x44ecfea61c937b8e.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
			break;
		case StyleType.Paragraph:
			x44ecfea61c937b8e.xeedad81aaed42a76 = x44ecfea61c937b8e.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
			x44ecfea61c937b8e.x1a78664fa10a3755 = x44ecfea61c937b8e.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x2be08ba736aa04f0);
			break;
		case StyleType.Table:
		{
			TableStyle tableStyle = (TableStyle)x44ecfea61c937b8e;
			tableStyle.x511a581657d77f2b = tableStyle.xaa572f7df92ef004();
			tableStyle.xf8cef531dae89ea3 = tableStyle.x0974156b728aa5fc();
			tableStyle.xedb0eb766e25e0c9 = tableStyle.x43aa3065eb22eea2();
			x44ecfea61c937b8e.xeedad81aaed42a76 = x44ecfea61c937b8e.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
			x44ecfea61c937b8e.x1a78664fa10a3755 = x44ecfea61c937b8e.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x2be08ba736aa04f0);
			break;
		}
		default:
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lnhibpoifofjfpmjkodkmnkkhnblfoildnplpmgmiinminengnlnincoimjoolapghhphmopjmfanlmapkdbfhkb", 321685382)));
		case StyleType.List:
			break;
		}
	}

	internal void xd6b6ed77479ef68c(Style x44ecfea61c937b8e)
	{
		if (x44ecfea61c937b8e == null)
		{
			throw new ArgumentNullException("style");
		}
		if (x44ecfea61c937b8e.Styles != null)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gpefebmfgbdggakgmpahelhhcpohkpfinpminodjgokjgobkipikmjpklngllnnlpnempnlmlncnbnjnknaoeihofnoonmfplhmpjldadmkabmbbdmibelpbokgcilncdgeddkldmkcegkjedkafjjhfejofckfgejmghjdhdjkhcebioiiicipijdgjjinjhiekjilkjhclpgjlkhamcdhm", 805000355)));
		}
		if (x3097e66d61f8bec1.Contains(x44ecfea61c937b8e.Name))
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("laefgclfadcgncjglcahnchhgnnhebfiebmibbdjkmjjiabkemhkebpkcbglebnleaemkpkmclbnbpinbppnmogohonoipepdplpcocakjjainabejhbeoobcofceomcenddkmkdcibegniefmpenmgfolnfdhegemlgflchpkjhhgaihlhickoilkfjakmjifdkdkkkdjblmjilbjpljegmhinmpiencjlncicolhjolhapnihpbdopdhfadimabhdbihkbghbcchickcpc", 1274041288)));
		}
		if (x44ecfea61c937b8e.BuiltIn && x2fc747cf1de1e7a7.x263d579af1d0d43f((int)x44ecfea61c937b8e.StyleIdentifier))
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dcpbodgciencfeeddeldfeceooiemcafmchfjcofcoegacmgmnchmckhkcbimciimbpicbgjkmmjjaekjalkeaclppilabamlahmkpnmclenaplnmkcompjokpapmphpmoopcofakjmaoodbnnkbfobcgniclipcmngdnmndlmeecnlemhcfcmjfklagilhgologbmfhdlmhnkdinkkigkbjalijlfpjjjgkbknkekelejllnicmnijmpjandehnfionfjfodimokidpiikpeibamdia", 341712608)));
		}
		x23435b520f97383d.xd6b6ed77479ef68c(x44ecfea61c937b8e.x8301ab10c226b0c2, x44ecfea61c937b8e);
		x3097e66d61f8bec1.Add(x44ecfea61c937b8e.Name, x44ecfea61c937b8e);
		if (x44ecfea61c937b8e.BuiltIn)
		{
			x2fc747cf1de1e7a7.xd6b6ed77479ef68c((int)x44ecfea61c937b8e.StyleIdentifier, x44ecfea61c937b8e);
		}
		x44ecfea61c937b8e.x17151e7d3bf9d07d(this);
	}

	internal void xe757cf2edd1c4b6a(Style x0f5cfbc079a382b1, string x2082e8e39a65c1b2, string x9038bd15f8cd74c7)
	{
		x3097e66d61f8bec1.Remove(x2082e8e39a65c1b2);
		if (!x3097e66d61f8bec1.Contains(x9038bd15f8cd74c7))
		{
			x3097e66d61f8bec1.Add(x9038bd15f8cd74c7, x0f5cfbc079a382b1);
		}
		else
		{
			x3097e66d61f8bec1[x9038bd15f8cd74c7] = x0f5cfbc079a382b1;
		}
	}

	internal void xcac14b89627cf9dc(Style x44ecfea61c937b8e, StyleIdentifier xcf4b53d4c2f3e75a, StyleIdentifier xe28119327772e23d)
	{
		if (x44ecfea61c937b8e.BuiltIn)
		{
			x2fc747cf1de1e7a7.x52b190e626f65140((int)xcf4b53d4c2f3e75a);
		}
		if (xe28119327772e23d != StyleIdentifier.User)
		{
			if (x2fc747cf1de1e7a7.x263d579af1d0d43f((int)xe28119327772e23d))
			{
				x2fc747cf1de1e7a7.set_xe6d4b1b411ed94b5((int)xe28119327772e23d, (object)x44ecfea61c937b8e);
			}
			else
			{
				x2fc747cf1de1e7a7.xd6b6ed77479ef68c((int)xe28119327772e23d, x44ecfea61c937b8e);
			}
		}
	}

	internal void x30a673601c168f37(Style x44ecfea61c937b8e, int xb3cb051352a9e8f1, int xbffa3aa7ac8f0075)
	{
		x23435b520f97383d.x52b190e626f65140(xb3cb051352a9e8f1);
		if (x23435b520f97383d.x263d579af1d0d43f(xbffa3aa7ac8f0075))
		{
			x23435b520f97383d.set_xe6d4b1b411ed94b5(xbffa3aa7ac8f0075, (object)x44ecfea61c937b8e);
		}
		else
		{
			x23435b520f97383d.xd6b6ed77479ef68c(xbffa3aa7ac8f0075, x44ecfea61c937b8e);
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Style style = (Style)enumerator.Current;
				if (style.xe709b224f455b863 == xb3cb051352a9e8f1)
				{
					style.xe709b224f455b863 = xbffa3aa7ac8f0075;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		x255ed75560e42420(x44ecfea61c937b8e, xb3cb051352a9e8f1, xbffa3aa7ac8f0075);
	}

	internal void x4880cad9f3196627(Style x44ecfea61c937b8e, string[] x4bb79322d6f07955)
	{
		if (x3097e66d61f8bec1.Contains(x44ecfea61c937b8e.Name))
		{
			x44ecfea61c937b8e.x2b8399f052630a13(x816b1ea8b69dca23(x44ecfea61c937b8e.Name));
		}
		if (x44ecfea61c937b8e.BuiltIn && x2fc747cf1de1e7a7.x263d579af1d0d43f((int)x44ecfea61c937b8e.StyleIdentifier))
		{
			x44ecfea61c937b8e.x7ac71dcbd33d6241(StyleIdentifier.User);
		}
		xd6b6ed77479ef68c(x44ecfea61c937b8e);
		if (x4bb79322d6f07955 != null)
		{
			for (int i = 0; i < x4bb79322d6f07955.Length; i++)
			{
				x3097e66d61f8bec1.Add(x816b1ea8b69dca23(x4bb79322d6f07955[i]), x44ecfea61c937b8e);
			}
		}
	}

	internal string x816b1ea8b69dca23(string xc15bd84e01929885)
	{
		string text = xc15bd84e01929885;
		int num = 0;
		while (x3097e66d61f8bec1.Contains(text))
		{
			text = $"{xc15bd84e01929885}_{num}";
			num++;
		}
		return text;
	}

	public Style AddCopy(Style style)
	{
		if (style == null)
		{
			throw new ArgumentException("Style can not be null.");
		}
		Style style2 = style.x8b61531c8ea35b85();
		x8cc2e85cba11a0e8(style, style2);
		if (style.Type != StyleType.Character && style.x1a78664fa10a3755.x71c63f7e57f7ede5 > 0)
		{
			List x3fbc82dc0259cd6d = style.Document.Lists.xceb66bfa0e6b60c7(style.x1a78664fa10a3755.x71c63f7e57f7ede5);
			style2.x1a78664fa10a3755.x71c63f7e57f7ede5 = Document.Lists.x25de37482b6805d5(x3fbc82dc0259cd6d, xc9d49f938b96bdd0: false).ListId;
		}
		if (x3097e66d61f8bec1.Contains(style.Name))
		{
			style2.x2b8399f052630a13(x816b1ea8b69dca23(style.Name));
		}
		else if (style.StyleIdentifier != StyleIdentifier.User)
		{
			style2.x2b8399f052630a13(style.Name + "_0");
		}
		int num = xdc32dcfe6668100d();
		style2.xd01720d5ff2238cc(num);
		if (style.StyleIdentifier != StyleIdentifier.User)
		{
			style2.x7ac71dcbd33d6241(StyleIdentifier.User, x6d60cf0a80bb0eb6: false);
		}
		style2.xe709b224f455b863 = 4095;
		style2.xfb77c9ea054ac31c = num;
		xd6b6ed77479ef68c(style2);
		if (style2.xcb78713836fcc98a && style2.Document is Document)
		{
			((Document)style2.Document).Revisions.xd6b6ed77479ef68c(style2);
		}
		return style2;
	}

	private static void x8cc2e85cba11a0e8(Style x44ecfea61c937b8e, Style x63e78703e64bb044)
	{
		switch (x44ecfea61c937b8e.Type)
		{
		case StyleType.Paragraph:
			x106de6b96e062339(x44ecfea61c937b8e, x63e78703e64bb044);
			break;
		case StyleType.Character:
			x63e78703e64bb044.xeedad81aaed42a76 = x44ecfea61c937b8e.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
			break;
		case StyleType.Table:
			xdec91d6afb72f415((TableStyle)x44ecfea61c937b8e, (TableStyle)x63e78703e64bb044);
			break;
		default:
			throw new ArgumentException("Unknown style type");
		case StyleType.List:
			break;
		}
	}

	private static void x106de6b96e062339(Style x464349d05eb2b57c, Style x63e78703e64bb044)
	{
		x63e78703e64bb044.xeedad81aaed42a76 = x464349d05eb2b57c.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
		x63e78703e64bb044.x1a78664fa10a3755 = x464349d05eb2b57c.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x2be08ba736aa04f0);
	}

	private static void xdec91d6afb72f415(TableStyle xdd4491ef6c61397c, TableStyle x048f0234fd2f3fce)
	{
		x106de6b96e062339(xdd4491ef6c61397c, x048f0234fd2f3fce);
		x048f0234fd2f3fce.x511a581657d77f2b = xdd4491ef6c61397c.xaa572f7df92ef004();
		x048f0234fd2f3fce.xf8cef531dae89ea3 = xdd4491ef6c61397c.x0974156b728aa5fc();
		x048f0234fd2f3fce.xedb0eb766e25e0c9 = xdd4491ef6c61397c.x43aa3065eb22eea2();
	}

	internal StyleCollection x8b61531c8ea35b85(DocumentBase xcdd91c46b8f58479)
	{
		StyleCollection styleCollection = (StyleCollection)MemberwiseClone();
		styleCollection.x232be220f517f721 = xcdd91c46b8f58479;
		styleCollection.x067ea144d8539d30 = (xeedad81aaed42a76)x067ea144d8539d30.x8b61531c8ea35b85();
		styleCollection.x9fb31b512ec52022 = (x1a78664fa10a3755)x9fb31b512ec52022.x8b61531c8ea35b85();
		styleCollection.x23435b520f97383d = new x09ce2c02826e31a6();
		styleCollection.x3097e66d61f8bec1 = new xd345c73dd1b16b74();
		styleCollection.x2fc747cf1de1e7a7 = new x09ce2c02826e31a6();
		for (int i = 0; i < x23435b520f97383d.xd44988f225497f3a; i++)
		{
			Style style = (Style)x23435b520f97383d.x6d3720b962bd3112(i);
			styleCollection.xd6b6ed77479ef68c(style.x8b61531c8ea35b85());
		}
		foreach (DictionaryEntry item in x3097e66d61f8bec1)
		{
			string text = (string)item.Key;
			Style style2 = (Style)item.Value;
			if (text != style2.Name)
			{
				Style value = styleCollection.xe931c242f6b9055f(style2.Name, x988fcf605f8efa7e: false);
				styleCollection.x3097e66d61f8bec1.Add(text, value);
			}
		}
		styleCollection.x5e6674d07ce0c0e7 = x5e6674d07ce0c0e7.x8b61531c8ea35b85();
		return styleCollection;
	}

	internal string x4c0f9b9b517a1ec4(Style x44ecfea61c937b8e, bool xe9f84f829511a789)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (xe9f84f829511a789)
		{
			stringBuilder.Append(x44ecfea61c937b8e.Name);
		}
		for (int i = 0; i < x3097e66d61f8bec1.Count; i++)
		{
			Style style = (Style)x3097e66d61f8bec1.GetByIndex(i);
			string text = (string)x3097e66d61f8bec1.GetKey(i);
			if (x44ecfea61c937b8e == style && x44ecfea61c937b8e.Name != text)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(text);
			}
		}
		return stringBuilder.ToString();
	}

	[JavaThrows(false)]
	internal Style x1976fb6958cf7237(int xddd12ddd8b1e4a90, bool x988fcf605f8efa7e)
	{
		Style style = (Style)x23435b520f97383d.get_xe6d4b1b411ed94b5(xddd12ddd8b1e4a90);
		if (style == null && x988fcf605f8efa7e)
		{
			Style style2 = xc6b4c6fa9a60b0fc.x1976fb6958cf7237(xddd12ddd8b1e4a90, x988fcf605f8efa7e: false);
			if (style2 != null)
			{
				style = x81f78ebaaa78ed06(style2);
			}
		}
		return style;
	}

	[JavaThrows(false)]
	internal Style xe931c242f6b9055f(string xc15bd84e01929885, bool x988fcf605f8efa7e)
	{
		x0d299f323d241756.x0aaaea7864a53f26(xc15bd84e01929885, "name");
		Style style = (Style)x3097e66d61f8bec1[xc15bd84e01929885];
		if (style == null && x988fcf605f8efa7e)
		{
			Style style2 = xc6b4c6fa9a60b0fc.xe931c242f6b9055f(xc15bd84e01929885, x988fcf605f8efa7e: false);
			if (style2 != null)
			{
				style = x81f78ebaaa78ed06(style2);
			}
		}
		return style;
	}

	[JavaThrows(false)]
	internal Style xf21e14e2c9db279a(StyleIdentifier xa3be2ccad541ab25, bool x988fcf605f8efa7e)
	{
		if (xa3be2ccad541ab25 == StyleIdentifier.User)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ogmfjidgdjkgajbhoiihajphjdgiiiniihejeiljcickmhjkfhalechlgholbhfmagmmkgdnfbkngfboefiocfpocfgpefnpieeaeelanpbbnejbleacnehcndocddfdodmdiocehckeldbfpnhfpcpfncggpcngpbehfblhnmbidbjilaajjahjpaojcbfkeamkopclopjlhpambaimklom", 1513118763)));
		}
		Style style = (Style)x2fc747cf1de1e7a7.get_xe6d4b1b411ed94b5((int)xa3be2ccad541ab25);
		if (style == null && x988fcf605f8efa7e)
		{
			Style style2 = xc6b4c6fa9a60b0fc.xf21e14e2c9db279a(xa3be2ccad541ab25, x988fcf605f8efa7e: false);
			if (style2 != null)
			{
				style = x81f78ebaaa78ed06(style2);
			}
		}
		return style;
	}

	private LoadFormat x18445bcef0e65876()
	{
		if (x232be220f517f721.NodeType == NodeType.GlossaryDocument)
		{
			return LoadFormat.Docx;
		}
		return ((Document)x232be220f517f721).OriginalLoadFormat;
	}

	internal bool x263d579af1d0d43f(StyleIdentifier xe98722bc47ad3bb3)
	{
		return x2fc747cf1de1e7a7.xbc5dc59d0d9b620d((int)xe98722bc47ad3bb3);
	}

	internal Style x04084ecd680fb39a(Style x464349d05eb2b57c)
	{
		if (x464349d05eb2b57c.BuiltIn)
		{
			Style style = xf21e14e2c9db279a(x464349d05eb2b57c.StyleIdentifier, x988fcf605f8efa7e: false);
			if (style != null)
			{
				return style;
			}
		}
		return xe931c242f6b9055f(x464349d05eb2b57c.Name, x988fcf605f8efa7e: false);
	}

	internal Style xf194004582627ed5(int xddd12ddd8b1e4a90, int x81d973eeafae2be3)
	{
		bool x988fcf605f8efa7e = xddd12ddd8b1e4a90 <= 14;
		Style style = x1976fb6958cf7237(xddd12ddd8b1e4a90, x988fcf605f8efa7e);
		if (style != null)
		{
			return style;
		}
		style = x1976fb6958cf7237(x81d973eeafae2be3, x988fcf605f8efa7e);
		if (style != null)
		{
			return style;
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jahhecohocfilcmijcdjlckjenakhbikhbpkjbglmanlfmdmdalmplbnpajnnaaopahoppnofpepnklpbadaapjaipabjohbojobpofcaomconddfokdpibefniemnpekngfhmnfoieg", 58881734)));
	}

	internal Style xfee6a7b399450516(string xc15bd84e01929885)
	{
		Style style = this[xc15bd84e01929885];
		if (style == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kajcfcadpchdmcodkcfemcmefncfibkfibbgkbignapggmfhgbnhebeigbligacjmpijelpjilgkjaokllelfamlmkcmaljm", 120203463)), xc15bd84e01929885));
		}
		return style;
	}

	internal Style x590d8ef356786501(StyleIdentifier xa3be2ccad541ab25)
	{
		Style style = this[xa3be2ccad541ab25];
		if (style == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jfjdehaeohhelhoejhfflhmfecdghgkghgbhjgihmfphfbgidfnipaejpfljnfckpfjkpealfehlnpnlbffmaemmiednjdknooaopdioadpoocgpfdnppndapclanccbpcjbpbacfbhcnmncdbfdlamdjadepakecbbfeaifopofopfghpmgbaehklkh", 1693464854)));
		}
		return style;
	}

	[JavaThrows(false)]
	private Style x81f78ebaaa78ed06(Style x464349d05eb2b57c)
	{
		x7f4fa84f489f40ab x0f7b23d1c393aed = new x7f4fa84f489f40ab(x464349d05eb2b57c.Document, Document, ImportFormatMode.UseDestinationStyles);
		return x81f78ebaaa78ed06(x0f7b23d1c393aed, x464349d05eb2b57c);
	}

	[JavaThrows(false)]
	internal Style x81f78ebaaa78ed06(x7f4fa84f489f40ab x0f7b23d1c393aed9, Style x464349d05eb2b57c)
	{
		if (x464349d05eb2b57c == null)
		{
			throw new ArgumentNullException("srcStyle");
		}
		if (x464349d05eb2b57c.Styles == this)
		{
			return x464349d05eb2b57c;
		}
		if (x0f7b23d1c393aed9.x52d3f14665be3dcc.Contains(x464349d05eb2b57c.x8301ab10c226b0c2))
		{
			int xddd12ddd8b1e4a = (int)x0f7b23d1c393aed9.x52d3f14665be3dcc[x464349d05eb2b57c.x8301ab10c226b0c2];
			return x1976fb6958cf7237(xddd12ddd8b1e4a, x988fcf605f8efa7e: false);
		}
		return x0f7b23d1c393aed9.xcea1c437a94c4d02 switch
		{
			ImportFormatMode.UseDestinationStyles => x373f03ca281e40dd(x0f7b23d1c393aed9, x464349d05eb2b57c), 
			ImportFormatMode.KeepSourceFormatting => x2d4b4dc2668bf0ec(x0f7b23d1c393aed9, x464349d05eb2b57c), 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ijdfokkfikbgikiggkpglkghpjnhoeeiejlifjcjfjjjbjakbjhkajokjdflmhmlcidmcikmkhbnlginlhpnecgocgnobgeppglpbgcaegjaagabnbhb", 2140230467))), 
		};
	}

	private Style x2d4b4dc2668bf0ec(x7f4fa84f489f40ab x0f7b23d1c393aed9, Style x464349d05eb2b57c)
	{
		Style style;
		if (x464349d05eb2b57c.StyleIdentifier == StyleIdentifier.DefaultParagraphFont || x464349d05eb2b57c.StyleIdentifier == StyleIdentifier.TableNormal)
		{
			style = xf21e14e2c9db279a(x464349d05eb2b57c.StyleIdentifier, x988fcf605f8efa7e: false);
			if (style != null)
			{
				return style;
			}
		}
		style = x464349d05eb2b57c.x8b61531c8ea35b85();
		if (x04084ecd680fb39a(x464349d05eb2b57c) == null)
		{
			if (x464349d05eb2b57c.x8301ab10c226b0c2 > 14)
			{
				style.xd01720d5ff2238cc(xdc32dcfe6668100d());
			}
		}
		else
		{
			style.x2b8399f052630a13(x816b1ea8b69dca23(x464349d05eb2b57c.Name));
			style.xd01720d5ff2238cc(xdc32dcfe6668100d());
			style.x7ac71dcbd33d6241(StyleIdentifier.User);
		}
		xf9c433b247125cf8(x464349d05eb2b57c, x0f7b23d1c393aed9, style);
		return style;
	}

	private Style x373f03ca281e40dd(x7f4fa84f489f40ab x0f7b23d1c393aed9, Style x464349d05eb2b57c)
	{
		Style style = x04084ecd680fb39a(x464349d05eb2b57c);
		if (style != null)
		{
			return style;
		}
		style = x746554b54190cf7c(x464349d05eb2b57c);
		if (style != null)
		{
			return style;
		}
		style = x464349d05eb2b57c.x8b61531c8ea35b85();
		if (x464349d05eb2b57c.x8301ab10c226b0c2 > 14)
		{
			style.xd01720d5ff2238cc(xdc32dcfe6668100d());
		}
		xf9c433b247125cf8(x464349d05eb2b57c, x0f7b23d1c393aed9, style);
		return style;
	}

	private Style x746554b54190cf7c(Style x464349d05eb2b57c)
	{
		if (x464349d05eb2b57c.BuiltIn)
		{
			Style style = xc6b4c6fa9a60b0fc.xf21e14e2c9db279a(x464349d05eb2b57c.StyleIdentifier, x988fcf605f8efa7e: false);
			if (style != null)
			{
				Style style2 = style.x8b61531c8ea35b85();
				if (style.x8301ab10c226b0c2 > 14)
				{
					style2.xd01720d5ff2238cc(xdc32dcfe6668100d());
				}
				x7f4fa84f489f40ab x0f7b23d1c393aed = new x7f4fa84f489f40ab(style.Document, Document, ImportFormatMode.UseDestinationStyles);
				xf9c433b247125cf8(style, x0f7b23d1c393aed, style2);
				return style2;
			}
		}
		return null;
	}

	private void xf9c433b247125cf8(Style x464349d05eb2b57c, x7f4fa84f489f40ab x0f7b23d1c393aed9, Style x63e78703e64bb044)
	{
		xd6b6ed77479ef68c(x63e78703e64bb044);
		x0f7b23d1c393aed9.x52d3f14665be3dcc.Add(x464349d05eb2b57c.x8301ab10c226b0c2, x63e78703e64bb044.x8301ab10c226b0c2);
		switch (x464349d05eb2b57c.Type)
		{
		case StyleType.Paragraph:
			x57748101fad5a2b0(x0f7b23d1c393aed9, x464349d05eb2b57c, x63e78703e64bb044);
			break;
		case StyleType.List:
			x57748101fad5a2b0(x0f7b23d1c393aed9, x464349d05eb2b57c, x63e78703e64bb044);
			break;
		}
		if (x464349d05eb2b57c.xe709b224f455b863 != 4095)
		{
			x63e78703e64bb044.xe709b224f455b863 = x81f78ebaaa78ed06(x0f7b23d1c393aed9, x464349d05eb2b57c.xea729b8c7bbb5bb0()).x8301ab10c226b0c2;
		}
		if (x464349d05eb2b57c.xfb77c9ea054ac31c != 4095)
		{
			x63e78703e64bb044.xfb77c9ea054ac31c = x81f78ebaaa78ed06(x0f7b23d1c393aed9, x464349d05eb2b57c.x72896b10f838c181()).x8301ab10c226b0c2;
		}
		if (x464349d05eb2b57c.x4cf1854ef833220f != 4095)
		{
			x63e78703e64bb044.x4cf1854ef833220f = x81f78ebaaa78ed06(x0f7b23d1c393aed9, x464349d05eb2b57c.xe617ec963a7004e3()).x8301ab10c226b0c2;
		}
	}

	private static void x57748101fad5a2b0(x7f4fa84f489f40ab x0f7b23d1c393aed9, Style x464349d05eb2b57c, Style x63e78703e64bb044)
	{
		if (x464349d05eb2b57c.x1a78664fa10a3755.x71c63f7e57f7ede5 != 0)
		{
			int x71c63f7e57f7ede = x464349d05eb2b57c.x1a78664fa10a3755.x71c63f7e57f7ede5;
			int x71c63f7e57f7ede2 = x0f7b23d1c393aed9.xfb9dbcd4f0daf938.x26885624294ecfb1(x0f7b23d1c393aed9, x71c63f7e57f7ede);
			x63e78703e64bb044.x1a78664fa10a3755.x71c63f7e57f7ede5 = x71c63f7e57f7ede2;
			if (x63e78703e64bb044.Type == StyleType.List)
			{
				x63e78703e64bb044.List.x178ff6dcbf808c38.xc657ea789af2c1f0 = x63e78703e64bb044.x8301ab10c226b0c2;
			}
		}
	}

	internal void xca86a79e7ad537a5()
	{
		x7b6d33b2b3eb9639(StyleIdentifier.Normal);
		x7b6d33b2b3eb9639(StyleIdentifier.DefaultParagraphFont);
	}

	private void x7b6d33b2b3eb9639(StyleIdentifier xa3be2ccad541ab25)
	{
		int xddd12ddd8b1e4a = xd9263e6f13384bf1.x778a4fac7992bc43(xa3be2ccad541ab25);
		Style style = x1976fb6958cf7237(xddd12ddd8b1e4a, x988fcf605f8efa7e: true);
		if (style.StyleIdentifier != xa3be2ccad541ab25)
		{
			style.xd01720d5ff2238cc(xdc32dcfe6668100d(), x6d60cf0a80bb0eb6: true);
			xf21e14e2c9db279a(xa3be2ccad541ab25, x988fcf605f8efa7e: true);
		}
	}

	internal void x0fdd6762da0945d8()
	{
		ArrayList arrayList = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Style value = (Style)enumerator.Current;
				arrayList.Add(value);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		foreach (Style item in arrayList)
		{
			item.xb5c8f7c15000a29f();
		}
		foreach (Style item2 in arrayList)
		{
			item2.x8b31be6b0ff92506();
		}
	}

	internal void x160c33d5600b9bc8()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Style style = (Style)enumerator.Current;
				xeedad81aaed42a76 xeedad81aaed42a = style.xeedad81aaed42a76;
				xeedad81aaed42a.x52b190e626f65140(380);
				xeedad81aaed42a.x52b190e626f65140(340);
				xeedad81aaed42a.x52b190e626f65140(390);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}
}
