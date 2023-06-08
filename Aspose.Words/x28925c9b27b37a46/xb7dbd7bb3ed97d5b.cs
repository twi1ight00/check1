using System;
using System.Collections;
using System.Drawing;
using System.Text;
using Aspose.Words;
using x13f1efc79617a47b;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x28925c9b27b37a46;

internal class xb7dbd7bb3ed97d5b
{
	private static readonly Hashtable x6f30e378d4d9c8e0;

	private static readonly int x8905819f865ee5e1;

	private xb7dbd7bb3ed97d5b()
	{
	}

	internal static void x9d7a28ea717302c8(CompositeNode x93d8434f027afd5a)
	{
		if (x0b978d47953b45c3(x93d8434f027afd5a))
		{
			x93d8434f027afd5a.AppendChild(new Paragraph(x93d8434f027afd5a.Document));
		}
	}

	private static bool x0b978d47953b45c3(CompositeNode x93d8434f027afd5a)
	{
		Node lastChild = x93d8434f027afd5a.LastChild;
		if (lastChild == null)
		{
			return true;
		}
		switch (lastChild.NodeType)
		{
		case NodeType.Paragraph:
			return false;
		case NodeType.CustomXmlMarkup:
		case NodeType.StructuredDocumentTag:
			return x0b978d47953b45c3((CompositeNode)lastChild);
		default:
			return true;
		}
	}

	internal static x000f21cbda739311 xc0f0857806be03ff(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 >= '\0' && x3c4da2980d043c95 <= '\u007f')
		{
			return x000f21cbda739311.x175297738c8b8d1e;
		}
		if (x3c4da2980d043c95 >= '⺀' && x3c4da2980d043c95 <= '\ud7af')
		{
			return x000f21cbda739311.x7c8c2d13fa5b79fa;
		}
		if (x3c4da2980d043c95 >= '豈' && x3c4da2980d043c95 <= '\ufaff')
		{
			return x000f21cbda739311.x7c8c2d13fa5b79fa;
		}
		if (x3c4da2980d043c95 >= '\uff00' && x3c4da2980d043c95 <= '\uffef')
		{
			return x000f21cbda739311.x7c8c2d13fa5b79fa;
		}
		if (x3c4da2980d043c95 >= '\u0590' && x3c4da2980d043c95 <= '\u0dff')
		{
			return x000f21cbda739311.xd4e922ceeed89b74;
		}
		if (x3c4da2980d043c95 >= 'יִ' && x3c4da2980d043c95 <= 'ﭏ')
		{
			return x000f21cbda739311.xd4e922ceeed89b74;
		}
		if ((x3c4da2980d043c95 >= 'ﭐ' && x3c4da2980d043c95 <= '\ufdff') || (x3c4da2980d043c95 >= 'ﹰ' && x3c4da2980d043c95 <= '\ufeff'))
		{
			return x000f21cbda739311.xd4e922ceeed89b74;
		}
		return x000f21cbda739311.x22a0fbb9469b35e1;
	}

	internal static string x4a59367ba6527b94(x000f21cbda739311 x21a91e2ac6ef5338, string x23baa165bca7b6ef, string x9765a88832769f88, string x4681a4352e687cd7, string xe1755e6a97c55396)
	{
		return x21a91e2ac6ef5338 switch
		{
			x000f21cbda739311.x175297738c8b8d1e => x23baa165bca7b6ef, 
			x000f21cbda739311.xd4e922ceeed89b74 => x9765a88832769f88, 
			x000f21cbda739311.x7c8c2d13fa5b79fa => x4681a4352e687cd7, 
			_ => xe1755e6a97c55396, 
		};
	}

	internal static bool x06768d79f7751c4d(string xe4115acdf4fbfccc)
	{
		if (xe4115acdf4fbfccc.StartsWith("\""))
		{
			return xe4115acdf4fbfccc.EndsWith("\"");
		}
		return false;
	}

	internal static string x8ee3644420992dc6(string xe4115acdf4fbfccc)
	{
		return x8ee3644420992dc6(xe4115acdf4fbfccc, x38919f3daaa51f82: true);
	}

	internal static string x8ee3644420992dc6(string xe4115acdf4fbfccc, bool x38919f3daaa51f82)
	{
		if (x38919f3daaa51f82)
		{
			return xe4115acdf4fbfccc.Trim('"');
		}
		if (xe4115acdf4fbfccc.StartsWith("\""))
		{
			xe4115acdf4fbfccc = xe4115acdf4fbfccc.Substring(1);
		}
		if (xe4115acdf4fbfccc.EndsWith("\""))
		{
			xe4115acdf4fbfccc = xe4115acdf4fbfccc.Substring(0, xe4115acdf4fbfccc.Length - 1);
		}
		return xe4115acdf4fbfccc;
	}

	internal static string xe8f643df16d085d9(string xe4115acdf4fbfccc)
	{
		return $"\"{xe4115acdf4fbfccc}\"";
	}

	internal static string xdf336ac83a5b01a2(string x55f6d57b715d99a8)
	{
		x55f6d57b715d99a8 = x8ee3644420992dc6(x55f6d57b715d99a8);
		x55f6d57b715d99a8 = x55f6d57b715d99a8.Replace("\\\\", "\\");
		return x55f6d57b715d99a8;
	}

	internal static string x0b0647af7a5ab290(string xbda579af315c6893)
	{
		xbda579af315c6893 = xbda579af315c6893.Replace("\\", "\\\\");
		xbda579af315c6893 = xe8f643df16d085d9(xbda579af315c6893);
		return xbda579af315c6893;
	}

	internal static string x6007a6ce1e15de6a(string xb41faee6912a2313)
	{
		StringBuilder stringBuilder = new StringBuilder(xb41faee6912a2313);
		stringBuilder.Replace(ControlChar.CrLf, ControlChar.Cr);
		stringBuilder.Replace(ControlChar.Lf, ControlChar.Cr);
		return stringBuilder.ToString();
	}

	internal static string x0994f10b8582d748(string xe4115acdf4fbfccc)
	{
		if (xe4115acdf4fbfccc == null)
		{
			throw new ArgumentNullException("s");
		}
		StringBuilder stringBuilder = new StringBuilder(xe4115acdf4fbfccc);
		for (int i = 0; i < stringBuilder.Length; i++)
		{
			if (!char.IsWhiteSpace(stringBuilder[i]))
			{
				stringBuilder[i] = char.ToUpper(stringBuilder[i]);
				break;
			}
		}
		return stringBuilder.ToString();
	}

	internal static string x5dbd7011cc4f99b9(string xe4115acdf4fbfccc)
	{
		if (xe4115acdf4fbfccc == null)
		{
			throw new ArgumentNullException("s");
		}
		bool flag = false;
		StringBuilder stringBuilder = new StringBuilder(xe4115acdf4fbfccc);
		for (int i = 0; i < stringBuilder.Length; i++)
		{
			if (char.IsWhiteSpace(stringBuilder[i]))
			{
				flag = false;
			}
			else if (!flag)
			{
				stringBuilder[i] = char.ToUpper(stringBuilder[i]);
				flag = true;
			}
			else
			{
				stringBuilder[i] = char.ToLower(stringBuilder[i]);
			}
		}
		return stringBuilder.ToString();
	}

	internal static string x041cc377735f8501(string xe4115acdf4fbfccc, xbc1709746b087e6c x67e7091832843e9a)
	{
		return x67e7091832843e9a switch
		{
			xbc1709746b087e6c.xad26a7203634de8e => xe4115acdf4fbfccc.ToUpper(), 
			xbc1709746b087e6c.x3f230538ea01aa0e => xe4115acdf4fbfccc.ToLower(), 
			xbc1709746b087e6c.xa6417f0b87702333 => x5dbd7011cc4f99b9(xe4115acdf4fbfccc), 
			xbc1709746b087e6c.x4c95b3a38f1afc3a => x0994f10b8582d748(xe4115acdf4fbfccc), 
			xbc1709746b087e6c.xce79258263c70a58 => xa527852d12649803(xe4115acdf4fbfccc), 
			xbc1709746b087e6c.xb9715d2f06b63cf0 => xe4115acdf4fbfccc, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("baighbpgbbghbbnhpaeiebliiacjhlijhppjjpgkponknpeliklliocmdojmcpanbohnjjonjofodomofndpankpdnbanmianmpagmgbcmnbjiec", 745564076))), 
		};
	}

	private static string xa527852d12649803(string xbcea506a33cf9111)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in xbcea506a33cf9111)
		{
			if (c > ' ' && c < '\u007f')
			{
				stringBuilder.Append((char)(0xFF00u | (uint)(c - 32)));
			}
			else if (c == ' ')
			{
				stringBuilder.Append('\u3000');
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	internal static string x6bf3310acbc2c04f(DateTime x73f821c71fe1e676, string x5786461d089b10a0)
	{
		return x6bf3310acbc2c04f(x73f821c71fe1e676, x5786461d089b10a0, 0);
	}

	internal static string x6bf3310acbc2c04f(DateTime x73f821c71fe1e676, string x5786461d089b10a0, int xb0a546d42545a9ea)
	{
		return x21d82b8f3e4c4642.x6bf3310acbc2c04f(x5786461d089b10a0, x73f821c71fe1e676, xb0a546d42545a9ea);
	}

	internal static StoryType x3bcc8e857eb29ca0(HeaderFooterType x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			HeaderFooterType.FooterEven => StoryType.EvenPagesFooter, 
			HeaderFooterType.FooterFirst => StoryType.FirstPageFooter, 
			HeaderFooterType.FooterPrimary => StoryType.PrimaryFooter, 
			HeaderFooterType.HeaderEven => StoryType.EvenPagesHeader, 
			HeaderFooterType.HeaderFirst => StoryType.FirstPageHeader, 
			HeaderFooterType.HeaderPrimary => StoryType.PrimaryHeader, 
			_ => throw new InvalidOperationException("Unknown header or footer type."), 
		};
	}

	internal static HeaderFooterType x442f5a91105f9e6a(StoryType x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			StoryType.EvenPagesFooter => HeaderFooterType.FooterEven, 
			StoryType.FirstPageFooter => HeaderFooterType.FooterFirst, 
			StoryType.PrimaryFooter => HeaderFooterType.FooterPrimary, 
			StoryType.EvenPagesHeader => HeaderFooterType.HeaderEven, 
			StoryType.FirstPageHeader => HeaderFooterType.HeaderFirst, 
			StoryType.PrimaryHeader => HeaderFooterType.HeaderPrimary, 
			_ => throw new InvalidOperationException("This story is not a header or footer story."), 
		};
	}

	internal static Size x9d0ad238350f058d(PaperSize x9dc84f7137b23608)
	{
		return (Size)x6f30e378d4d9c8e0[x9dc84f7137b23608];
	}

	internal static PaperSize xca878d9befa76e8f(int x9b0739496f8b5475, int x4d5aabc7a55b12ba, bool x34eb37a12a81c6f3)
	{
		foreach (DictionaryEntry item in x6f30e378d4d9c8e0)
		{
			Size size = (Size)item.Value;
			if (x0d299f323d241756.x25e9a0e7dc336c01(new SizeF(size.Width, size.Height), new SizeF(x9b0739496f8b5475, x4d5aabc7a55b12ba), x34eb37a12a81c6f3, x8905819f865ee5e1))
			{
				return (PaperSize)item.Key;
			}
		}
		return PaperSize.Custom;
	}

	internal static void x7feaa17f5d673c47(Document x6beba47238e0ade6)
	{
	}

	internal static void x2a7cd8137a4fa48c(Document x6beba47238e0ade6, string xb87dbcbc7a68861b, string xc1c66f01bc993d0e)
	{
		x6beba47238e0ade6.EnsureMinimum();
		if (x6beba47238e0ade6.FirstChild == x6beba47238e0ade6.LastChild && x6beba47238e0ade6.FirstSection.Body.x74f5d3c8c1c169b6)
		{
			return;
		}
		Run x38453dde2dc1ee = x6beba47238e0ade6.FirstSection.Body.FirstParagraph.x38453dde2dc1ee92;
		if (x38453dde2dc1ee == null || !(x38453dde2dc1ee.Text == xb87dbcbc7a68861b))
		{
			Run run = new Run(x6beba47238e0ade6, xb87dbcbc7a68861b, new xeedad81aaed42a76());
			run.xeedad81aaed42a76.xae20093bed1e48a8(160, x26d9ecb4bdf0456d.x46d2ee2a363fa637);
			run.xeedad81aaed42a76.xae20093bed1e48a8(60, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
			run.xeedad81aaed42a76.xae20093bed1e48a8(190, 24);
			Paragraph paragraph = new Paragraph(x6beba47238e0ade6, new x1a78664fa10a3755(), new xeedad81aaed42a76());
			paragraph.AppendChild(run);
			Paragraph firstParagraph = x6beba47238e0ade6.FirstSection.Body.FirstParagraph;
			if (firstParagraph != null && firstParagraph.ParagraphFormat.PageBreakBefore)
			{
				firstParagraph.ParagraphFormat.PageBreakBefore = false;
			}
			x6beba47238e0ade6.FirstSection.Body.PrependChild(paragraph);
			x12c651b23b05c7de(x6beba47238e0ade6, xc1c66f01bc993d0e);
		}
	}

	private static void x12c651b23b05c7de(Document x6beba47238e0ade6, string xc1c66f01bc993d0e)
	{
		NodeCollection childNodes = x6beba47238e0ade6.GetChildNodes(NodeType.Paragraph, isDeep: true);
		int num = 0;
		int num2 = 0;
		Paragraph paragraph = null;
		foreach (Paragraph item in childNodes)
		{
			if (item.ParentNode.NodeType == NodeType.Body)
			{
				paragraph = item;
				foreach (Node item2 in item)
				{
					switch (item2.NodeType)
					{
					case NodeType.FieldStart:
						num2++;
						break;
					case NodeType.FieldEnd:
						num2--;
						break;
					}
				}
			}
			num++;
			if (num > 200 && paragraph != null && num2 == 0)
			{
				x5699f8523a546a42.x7088fd15062d931f(paragraph.ParentSection.NextSibling, null);
				x5699f8523a546a42.x7088fd15062d931f(paragraph.NextSibling, null);
				Run run = new Run(x6beba47238e0ade6, xc1c66f01bc993d0e, new xeedad81aaed42a76());
				run.xeedad81aaed42a76.xae20093bed1e48a8(160, x26d9ecb4bdf0456d.x46d2ee2a363fa637);
				run.xeedad81aaed42a76.xae20093bed1e48a8(60, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				run.xeedad81aaed42a76.xae20093bed1e48a8(190, 24);
				Paragraph paragraph3 = new Paragraph(x6beba47238e0ade6, new x1a78664fa10a3755(), new xeedad81aaed42a76());
				paragraph3.AppendChild(run);
				x6beba47238e0ade6.LastSection.Body.AppendChild(paragraph3);
				break;
			}
		}
	}

	internal static double x73ef7a6dac3d681b(TextureIndex xc0c4c459c6ccbd00)
	{
		switch (xc0c4c459c6ccbd00)
		{
		case TextureIndex.TextureNone:
		case TextureIndex.TextureNil:
			return 0.0;
		case TextureIndex.Texture2Pt5Percent:
			return 0.025;
		case TextureIndex.Texture5Percent:
			return 0.05;
		case TextureIndex.Texture7Pt5Percent:
			return 0.075;
		case TextureIndex.Texture10Percent:
			return 0.10000000149011612;
		case TextureIndex.Texture12Pt5Percent:
			return 0.125;
		case TextureIndex.Texture15Percent:
			return 0.15;
		case TextureIndex.Texture17Pt5Percent:
			return 0.175;
		case TextureIndex.Texture20Percent:
			return 0.2;
		case TextureIndex.Texture22Pt5Percent:
			return 0.225;
		case TextureIndex.Texture25Percent:
		case TextureIndex.TextureHorizontal:
		case TextureIndex.TextureVertical:
		case TextureIndex.TextureDiagonalDown:
		case TextureIndex.TextureDiagonalUp:
			return 0.25;
		case TextureIndex.Texture27Pt5Percent:
			return 0.275;
		case TextureIndex.Texture30Percent:
		case TextureIndex.TextureDiagonalCross:
			return 0.3;
		case TextureIndex.Texture32Pt5Percent:
			return 0.325;
		case TextureIndex.TextureCross:
		case TextureIndex.Texture35Percent:
			return 0.35;
		case TextureIndex.Texture37Pt5Percent:
			return 0.375;
		case TextureIndex.Texture40Percent:
			return 0.4;
		case TextureIndex.Texture42Pt5Percent:
			return 0.425;
		case TextureIndex.Texture45Percent:
			return 0.45;
		case TextureIndex.Texture47Pt5Percent:
			return 0.475;
		case TextureIndex.Texture50Percent:
		case TextureIndex.TextureDarkHorizontal:
		case TextureIndex.TextureDarkVertical:
		case TextureIndex.TextureDarkDiagonalDown:
		case TextureIndex.TextureDarkDiagonalUp:
		case TextureIndex.TextureDarkCross:
			return 0.5;
		case TextureIndex.Texture52Pt5Percent:
			return 0.525;
		case TextureIndex.Texture55Percent:
			return 0.55;
		case TextureIndex.Texture57Pt5Percent:
			return 0.575;
		case TextureIndex.Texture60Percent:
			return 0.6;
		case TextureIndex.Texture62Pt5Percent:
			return 0.625;
		case TextureIndex.Texture65Percent:
			return 0.65;
		case TextureIndex.Texture67Pt5Percent:
			return 0.675;
		case TextureIndex.Texture70Percent:
		case TextureIndex.TextureDarkDiagonalCross:
			return 0.7;
		case TextureIndex.Texture72Pt5Percent:
			return 0.725;
		case TextureIndex.Texture75Percent:
			return 0.75;
		case TextureIndex.Texture77Pt5Percent:
			return 0.775;
		case TextureIndex.Texture80Percent:
			return 0.8;
		case TextureIndex.Texture82Pt5Percent:
			return 0.825;
		case TextureIndex.Texture85Percent:
			return 0.85;
		case TextureIndex.Texture87Pt5Percent:
			return 0.875;
		case TextureIndex.Texture90Percent:
			return 0.9;
		case TextureIndex.Texture92Pt5Percent:
			return 0.925;
		case TextureIndex.Texture95Percent:
			return 0.95;
		case TextureIndex.Texture97Pt5Percent:
			return 0.975;
		case TextureIndex.TextureSolid:
			return 1.0;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gpjemabfgaifgapfeaggjangnpdhmkkhnpbiloiilppiepgjcpnjmoekmnlkckcl", 73746849)));
		}
	}

	internal static bool x36694757e8d7e52b(TextureIndex xc0c4c459c6ccbd00)
	{
		switch (xc0c4c459c6ccbd00)
		{
		case TextureIndex.TextureDarkHorizontal:
		case TextureIndex.TextureDarkVertical:
		case TextureIndex.TextureDarkDiagonalDown:
		case TextureIndex.TextureDarkDiagonalUp:
		case TextureIndex.TextureDarkCross:
		case TextureIndex.TextureDarkDiagonalCross:
		case TextureIndex.TextureHorizontal:
		case TextureIndex.TextureVertical:
		case TextureIndex.TextureDiagonalDown:
		case TextureIndex.TextureDiagonalUp:
		case TextureIndex.TextureCross:
		case TextureIndex.TextureDiagonalCross:
			return true;
		default:
			return false;
		}
	}

	internal static TextureIndex x1d6525b2be992278(double xbcea506a33cf9111)
	{
		return (int)(40.0 * xbcea506a33cf9111) switch
		{
			0 => TextureIndex.TextureNone, 
			1 => TextureIndex.Texture2Pt5Percent, 
			2 => TextureIndex.Texture5Percent, 
			3 => TextureIndex.Texture7Pt5Percent, 
			4 => TextureIndex.Texture10Percent, 
			5 => TextureIndex.Texture12Pt5Percent, 
			6 => TextureIndex.Texture15Percent, 
			7 => TextureIndex.Texture17Pt5Percent, 
			8 => TextureIndex.Texture20Percent, 
			9 => TextureIndex.Texture22Pt5Percent, 
			10 => TextureIndex.Texture25Percent, 
			11 => TextureIndex.Texture27Pt5Percent, 
			12 => TextureIndex.Texture30Percent, 
			13 => TextureIndex.Texture32Pt5Percent, 
			14 => TextureIndex.Texture35Percent, 
			15 => TextureIndex.Texture37Pt5Percent, 
			16 => TextureIndex.Texture40Percent, 
			17 => TextureIndex.Texture42Pt5Percent, 
			18 => TextureIndex.Texture45Percent, 
			19 => TextureIndex.Texture47Pt5Percent, 
			20 => TextureIndex.Texture50Percent, 
			21 => TextureIndex.Texture52Pt5Percent, 
			22 => TextureIndex.Texture55Percent, 
			23 => TextureIndex.Texture57Pt5Percent, 
			24 => TextureIndex.Texture60Percent, 
			25 => TextureIndex.Texture62Pt5Percent, 
			26 => TextureIndex.Texture65Percent, 
			27 => TextureIndex.Texture67Pt5Percent, 
			28 => TextureIndex.Texture70Percent, 
			29 => TextureIndex.Texture72Pt5Percent, 
			30 => TextureIndex.Texture75Percent, 
			31 => TextureIndex.Texture77Pt5Percent, 
			32 => TextureIndex.Texture80Percent, 
			33 => TextureIndex.Texture82Pt5Percent, 
			34 => TextureIndex.Texture85Percent, 
			35 => TextureIndex.Texture87Pt5Percent, 
			36 => TextureIndex.Texture90Percent, 
			37 => TextureIndex.Texture92Pt5Percent, 
			38 => TextureIndex.Texture95Percent, 
			39 => TextureIndex.Texture97Pt5Percent, 
			_ => TextureIndex.TextureSolid, 
		};
	}

	internal static x26d9ecb4bdf0456d x87e2b03b45effe52(x26d9ecb4bdf0456d x6d9a095d183b6b50, x26d9ecb4bdf0456d x60a2487f840b534c, double x607a3f96d060de40)
	{
		if (x607a3f96d060de40 == 0.0)
		{
			return x60a2487f840b534c;
		}
		if (x607a3f96d060de40 == 1.0)
		{
			return x6d9a095d183b6b50;
		}
		if (x6d9a095d183b6b50.x2bdbc700da15ebe5 && x60a2487f840b534c.x2bdbc700da15ebe5)
		{
			int num = (int)((double)x6d9a095d183b6b50.xc613adc4330033f3 * x607a3f96d060de40 + (double)x60a2487f840b534c.xc613adc4330033f3 * (1.0 - x607a3f96d060de40));
			return new x26d9ecb4bdf0456d(num, num, num);
		}
		return x05445f08a0a17687.x82410676ea092625(x6d9a095d183b6b50, x60a2487f840b534c, x607a3f96d060de40);
	}

	private static Size x7d6de2a14bd3fd11(double x08db3aeabb253cb1, double x1e218ceaee1bb583)
	{
		return new Size(x4574ea26106f0edb.x7d6de2a14bd3fd11(x08db3aeabb253cb1), x4574ea26106f0edb.x7d6de2a14bd3fd11(x1e218ceaee1bb583));
	}

	private static Size x02191c6de86774e5(double x08db3aeabb253cb1, double x1e218ceaee1bb583)
	{
		return new Size(x4574ea26106f0edb.x02191c6de86774e5(x08db3aeabb253cb1), x4574ea26106f0edb.x02191c6de86774e5(x1e218ceaee1bb583));
	}

	static xb7dbd7bb3ed97d5b()
	{
		x8905819f865ee5e1 = x4574ea26106f0edb.x7d6de2a14bd3fd11(2.0);
		x6f30e378d4d9c8e0 = new Hashtable();
		x6f30e378d4d9c8e0.Add(PaperSize.A3, x7d6de2a14bd3fd11(297.0, 420.0));
		x6f30e378d4d9c8e0.Add(PaperSize.A4, x7d6de2a14bd3fd11(210.0, 297.0));
		x6f30e378d4d9c8e0.Add(PaperSize.A5, x7d6de2a14bd3fd11(148.0, 210.0));
		x6f30e378d4d9c8e0.Add(PaperSize.B4, x7d6de2a14bd3fd11(250.0, 353.0));
		x6f30e378d4d9c8e0.Add(PaperSize.B5, x7d6de2a14bd3fd11(176.0, 250.0));
		x6f30e378d4d9c8e0.Add(PaperSize.Executive, x02191c6de86774e5(7.25, 10.5));
		x6f30e378d4d9c8e0.Add(PaperSize.Folio, x02191c6de86774e5(8.0, 13.0));
		x6f30e378d4d9c8e0.Add(PaperSize.Ledger, x02191c6de86774e5(11.0, 17.0));
		x6f30e378d4d9c8e0.Add(PaperSize.Legal, x02191c6de86774e5(8.5, 14.0));
		x6f30e378d4d9c8e0.Add(PaperSize.Letter, x02191c6de86774e5(8.5, 11.0));
		x6f30e378d4d9c8e0.Add(PaperSize.EnvelopeDL, x7d6de2a14bd3fd11(110.0, 220.0));
		x6f30e378d4d9c8e0.Add(PaperSize.Quarto, x02191c6de86774e5(8.0, 10.0));
		x6f30e378d4d9c8e0.Add(PaperSize.Statement, x02191c6de86774e5(5.5, 8.5));
		x6f30e378d4d9c8e0.Add(PaperSize.Tabloid, x02191c6de86774e5(11.0, 17.0));
		x6f30e378d4d9c8e0.Add(PaperSize.Paper10x14, x02191c6de86774e5(10.0, 14.0));
		x6f30e378d4d9c8e0.Add(PaperSize.Paper11x17, x02191c6de86774e5(11.0, 17.0));
	}
}
