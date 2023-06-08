using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Properties;
using x0ba9768691592c95;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xf9a9481c3f63a419;

namespace xa604c4d210ae0581;

internal class xe6d08044467dd57c
{
	private const int x3eba0e3819c0dbc1 = 1200;

	private const int x61375df7dd944836 = 16777216;

	private const string x0e64d1e784425ed5 = "_PID_LINKBASE";

	private BuiltInDocumentProperties x10a82e724559a04c;

	private CustomDocumentProperties x41790cc63fab4cbb;

	private x77d7a46711f04d5d x7879fdf00fe45397;

	private x77d7a46711f04d5d xe492aecd71fb69dd;

	private x77d7a46711f04d5d xa9666ccdb8c16c55;

	private int x63255d49a8fe74a6;

	private static readonly DateTime x602d3a6c146ee2b4;

	private IWarningCallback xa056586c1f99e199;

	private static readonly Hashtable x61060b8501c15939;

	private static readonly Hashtable xdead9b6bd527cecc;

	private static readonly Hashtable x06f5677326dd4629;

	private static readonly Hashtable x7f98d89aa4dd820b;

	internal x721d5a5fac797586 xd6e655e60efa6bed => xa9666ccdb8c16c55.x4e35c79189b28e26;

	internal void x06b0e25aa6ad68a9(xe7be411416cfcd54 x630baaeb4d769680, BuiltInDocumentProperties xf401ea1a049007f6, CustomDocumentProperties xe92ee63fc139f521)
	{
		x06b0e25aa6ad68a9(x630baaeb4d769680, xf401ea1a049007f6, xe92ee63fc139f521, null);
	}

	internal void x06b0e25aa6ad68a9(xe7be411416cfcd54 x630baaeb4d769680, BuiltInDocumentProperties xf401ea1a049007f6, CustomDocumentProperties xe92ee63fc139f521, IWarningCallback x57fef5933b41d0c2)
	{
		xa056586c1f99e199 = x57fef5933b41d0c2;
		x10a82e724559a04c = xf401ea1a049007f6;
		x41790cc63fab4cbb = xe92ee63fc139f521;
		x322764889cbf1e8c(x630baaeb4d769680);
		x92f8b40321651a8b(x630baaeb4d769680);
	}

	private void x322764889cbf1e8c(xe7be411416cfcd54 x630baaeb4d769680)
	{
		Stream stream = x630baaeb4d769680.x3e19bf48aeaa5779("\u0005SummaryInformation");
		if (stream == null)
		{
			return;
		}
		x5704d66afcf29611 x5704d66afcf = new x5704d66afcf29611(stream);
		if (x5704d66afcf.x31ded3025bcd2eb4.Count == 0)
		{
			return;
		}
		x77d7a46711f04d5d x77d7a46711f04d5d = (x77d7a46711f04d5d)x5704d66afcf.x31ded3025bcd2eb4[0];
		x721d5a5fac797586 x4e35c79189b28e = x77d7a46711f04d5d.x4e35c79189b28e26;
		for (int i = 0; i < x4e35c79189b28e.xd44988f225497f3a; i++)
		{
			x879a106b0501b9dc x879a106b0501b9dc = x4e35c79189b28e.get_xe6d4b1b411ed94b5(i);
			switch (x879a106b0501b9dc.xea1e81378298fa81)
			{
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 18:
				x79bb66e917aad3af(x7bdf5af95ec15f2a(x879a106b0501b9dc.xea1e81378298fa81), x879a106b0501b9dc.xd2f68ee6f47e9dfb, PropertyType.String);
				break;
			case 11:
			case 12:
			case 13:
				x79bb66e917aad3af(x7bdf5af95ec15f2a(x879a106b0501b9dc.xea1e81378298fa81), x879a106b0501b9dc.xd2f68ee6f47e9dfb, PropertyType.DateTime);
				break;
			case 14:
			case 15:
			case 16:
			case 19:
				x79bb66e917aad3af(x7bdf5af95ec15f2a(x879a106b0501b9dc.xea1e81378298fa81), x879a106b0501b9dc.xd2f68ee6f47e9dfb, PropertyType.Number);
				break;
			case 9:
				if (x879a106b0501b9dc.xd2f68ee6f47e9dfb is string)
				{
					int num = xca004f56614e2431.x912616ee70b2d94d((string)x879a106b0501b9dc.xd2f68ee6f47e9dfb);
					if (num != int.MinValue)
					{
						x79bb66e917aad3af("RevisionNumber", num, PropertyType.Number);
					}
					else
					{
						x3dc950453374051a("Invalid revision number.");
					}
				}
				break;
			case 10:
				if (x879a106b0501b9dc.xd2f68ee6f47e9dfb is DateTime)
				{
					x79bb66e917aad3af("TotalEditingTime", xc1365694bafe1d1a((DateTime)x879a106b0501b9dc.xd2f68ee6f47e9dfb), PropertyType.Number);
				}
				else
				{
					x3dc950453374051a("Invalid DateTime property, ignored.");
				}
				break;
			case 17:
				x3dc950453374051a("Unsupported document property 0x{0:x4}, ignored.", x879a106b0501b9dc.xea1e81378298fa81);
				break;
			default:
				x3dc950453374051a("Unsupported document property 0x{0:x4}, ignored.", x879a106b0501b9dc.xea1e81378298fa81);
				break;
			case 1:
				break;
			}
		}
	}

	private void x92f8b40321651a8b(xe7be411416cfcd54 x630baaeb4d769680)
	{
		Stream stream = x630baaeb4d769680.x3e19bf48aeaa5779("\u0005DocumentSummaryInformation");
		if (stream == null)
		{
			return;
		}
		x5704d66afcf29611 x5704d66afcf = new x5704d66afcf29611(stream);
		foreach (x77d7a46711f04d5d item in x5704d66afcf.x31ded3025bcd2eb4)
		{
			if (item.x11f221c54c2b65e6.Equals(x77d7a46711f04d5d.x3cf382f9d0ce3e4b))
			{
				x539e792dd9444baa(item.x4e35c79189b28e26);
			}
			else
			{
				x55570b18c1f08a68(item.x4e35c79189b28e26);
			}
		}
	}

	private void x539e792dd9444baa(x721d5a5fac797586 xceba1887cd3dc9cc)
	{
		for (int i = 0; i < xceba1887cd3dc9cc.xd44988f225497f3a; i++)
		{
			x879a106b0501b9dc x879a106b0501b9dc = xceba1887cd3dc9cc.get_xe6d4b1b411ed94b5(i);
			switch (x879a106b0501b9dc.xea1e81378298fa81)
			{
			case 2:
			case 14:
			case 15:
			case 26:
			case 27:
				x79bb66e917aad3af(x5d3cd08a31ce3a5a(x879a106b0501b9dc.xea1e81378298fa81), x879a106b0501b9dc.xd2f68ee6f47e9dfb, PropertyType.String);
				break;
			case 4:
			case 5:
			case 6:
			case 17:
			case 23:
				x79bb66e917aad3af(x5d3cd08a31ce3a5a(x879a106b0501b9dc.xea1e81378298fa81), x879a106b0501b9dc.xd2f68ee6f47e9dfb, PropertyType.Number);
				break;
			case 3:
			case 7:
			case 8:
			case 9:
			case 11:
				x3dc950453374051a("Unsupported PowerPoint property 0x{0:x4}, ignored.", x879a106b0501b9dc.xea1e81378298fa81);
				break;
			case 12:
				x79bb66e917aad3af("HeadingPairs", x879a106b0501b9dc.xd2f68ee6f47e9dfb, PropertyType.ObjectArray);
				break;
			case 13:
				x79bb66e917aad3af("TitlesOfParts", x879a106b0501b9dc.xd2f68ee6f47e9dfb, PropertyType.StringArray);
				break;
			case 16:
				x79bb66e917aad3af("LinksUpToDate", x879a106b0501b9dc.xd2f68ee6f47e9dfb, PropertyType.Boolean);
				break;
			case 19:
				x3dc950453374051a("Unsupported document property 0x{0:x4}, ignored.", x879a106b0501b9dc.xea1e81378298fa81);
				break;
			case 21:
			case 22:
				x3dc950453374051a("Unsupported document property 0x{0:x4}, ignored.", x879a106b0501b9dc.xea1e81378298fa81);
				break;
			default:
				x3dc950453374051a("Unsupported document property 0x{0:x4}, ignored.", x879a106b0501b9dc.xea1e81378298fa81);
				break;
			case 1:
			case 20:
				break;
			}
		}
	}

	private void x79bb66e917aad3af(string xc15bd84e01929885, object xbcea506a33cf9111, PropertyType x1f8ba6f334d9c5af)
	{
		if (DocumentProperty.x83502f7a85629080(xbcea506a33cf9111) == x1f8ba6f334d9c5af)
		{
			x10a82e724559a04c.xd6b6ed77479ef68c(xc15bd84e01929885, xbcea506a33cf9111);
		}
	}

	private void x55570b18c1f08a68(x721d5a5fac797586 xceba1887cd3dc9cc)
	{
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		for (int i = 0; i < xceba1887cd3dc9cc.xd44988f225497f3a; i++)
		{
			x879a106b0501b9dc x879a106b0501b9dc = xceba1887cd3dc9cc.get_xe6d4b1b411ed94b5(i);
			if (x879a106b0501b9dc.x759aa16c2016a289 == "_PID_LINKBASE")
			{
				if (x879a106b0501b9dc.xd2f68ee6f47e9dfb is byte[])
				{
					byte[] array = (byte[])x879a106b0501b9dc.xd2f68ee6f47e9dfb;
					x10a82e724559a04c.HyperlinkBase = Encoding.Unicode.GetString(array, 0, array.Length - 2);
				}
				else if (x879a106b0501b9dc.xd2f68ee6f47e9dfb is string)
				{
					x10a82e724559a04c.HyperlinkBase = (string)x879a106b0501b9dc.xd2f68ee6f47e9dfb;
				}
			}
			else if (((uint)x879a106b0501b9dc.xea1e81378298fa81 & 0x1000000u) != 0)
			{
				int num = x879a106b0501b9dc.xea1e81378298fa81 & -16777217;
				hashtable2[num] = x879a106b0501b9dc.xd2f68ee6f47e9dfb;
			}
			else if (x0d299f323d241756.x5959bccb67bbf051(x879a106b0501b9dc.x759aa16c2016a289))
			{
				if (x879a106b0501b9dc.x759aa16c2016a289 != "_PID_HLINKS")
				{
					DocumentProperty value = x41790cc63fab4cbb.xd6b6ed77479ef68c(x879a106b0501b9dc.x759aa16c2016a289, x879a106b0501b9dc.xd2f68ee6f47e9dfb);
					hashtable[x879a106b0501b9dc.xea1e81378298fa81] = value;
				}
			}
			else
			{
				x3dc950453374051a("Document property without name found, ignored.");
			}
		}
		foreach (DictionaryEntry item in hashtable2)
		{
			int num2 = (int)item.Key;
			DocumentProperty documentProperty = (DocumentProperty)hashtable[num2];
			if (documentProperty != null)
			{
				documentProperty.x1321c7b28b151682 = (string)item.Value;
			}
		}
	}

	internal void x6210059f049f0d48(BuiltInDocumentProperties xf401ea1a049007f6, CustomDocumentProperties xe92ee63fc139f521, xe7be411416cfcd54 x630baaeb4d769680)
	{
		x10a82e724559a04c = xf401ea1a049007f6;
		x41790cc63fab4cbb = xe92ee63fc139f521;
		x5704d66afcf29611 x5704d66afcf = new x5704d66afcf29611();
		x7879fdf00fe45397 = new x77d7a46711f04d5d(x77d7a46711f04d5d.x81b8eab21d0ad59b, 1200);
		x5704d66afcf.x31ded3025bcd2eb4.Add(x7879fdf00fe45397);
		x5704d66afcf29611 x5704d66afcf2 = new x5704d66afcf29611();
		xe492aecd71fb69dd = new x77d7a46711f04d5d(x77d7a46711f04d5d.x3cf382f9d0ce3e4b, 1200);
		x5704d66afcf2.x31ded3025bcd2eb4.Add(xe492aecd71fb69dd);
		xa9666ccdb8c16c55 = new x77d7a46711f04d5d(x77d7a46711f04d5d.x4a71b6aa10d36864, 1200);
		x5704d66afcf2.x31ded3025bcd2eb4.Add(xa9666ccdb8c16c55);
		x63255d49a8fe74a6 = 2;
		xd3c64bb0fbe98334();
		xd2f3222333394dea();
		if (xa9666ccdb8c16c55.x4e35c79189b28e26.xd44988f225497f3a == 0)
		{
			x5704d66afcf2.x31ded3025bcd2eb4.Remove(xa9666ccdb8c16c55);
		}
		MemoryStream memoryStream = new MemoryStream();
		x5704d66afcf.x0acd3c2012ea2ee8(memoryStream);
		x630baaeb4d769680["\u0005SummaryInformation"] = memoryStream;
		MemoryStream memoryStream2 = new MemoryStream();
		x5704d66afcf2.x0acd3c2012ea2ee8(memoryStream2);
		x630baaeb4d769680["\u0005DocumentSummaryInformation"] = memoryStream2;
	}

	private void xd3c64bb0fbe98334()
	{
		foreach (DocumentProperty item in x10a82e724559a04c)
		{
			switch (item.Name)
			{
			case "Title":
			case "Subject":
			case "Author":
			case "Keywords":
			case "Comments":
			case "Template":
			case "LastSavedBy":
			case "LastPrinted":
			case "CreateTime":
			case "LastSavedTime":
			case "Pages":
			case "Words":
			case "Characters":
			case "Security":
			case "NameOfApplication":
				xeae28d942cc1d73f(x396587bfd0095a31(item.Name), item.x240f22d025b60fe7);
				break;
			case "RevisionNumber":
				xeae28d942cc1d73f(9, item.x240f22d025b60fe7.ToString());
				break;
			case "TotalEditingTime":
				xeae28d942cc1d73f(10, xaa1f937f64e65733((int)item.x240f22d025b60fe7));
				break;
			case "Category":
			case "Bytes":
			case "Lines":
			case "Paragraphs":
			case "HeadingPairs":
			case "TitlesOfParts":
			case "Manager":
			case "Company":
			case "LinksUpToDate":
			case "CharactersWithSpaces":
			case "Version":
			case "ContentStatus":
			case "ContentType":
				x2d26bf63dcddf72d(xdcef0b55ace39497(item.Name), item.x240f22d025b60fe7);
				break;
			case "HyperlinkBase":
			{
				string text = item.x240f22d025b60fe7.ToString();
				if (x0d299f323d241756.x5959bccb67bbf051(text))
				{
					int num = text.Length * 2 + 2;
					byte[] array = new byte[num];
					Encoding.Unicode.GetBytes(text, 0, text.Length, array, 0);
					x359b066bbed8b833("_PID_LINKBASE", array);
				}
				break;
			}
			default:
				throw new InvalidOperationException("Unknown built-in property encountered.");
			}
		}
	}

	private static string x7bdf5af95ec15f2a(int x6de7844ec9827511)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x06f5677326dd4629, x6de7844ec9827511);
	}

	private static string x5d3cd08a31ce3a5a(int x6de7844ec9827511)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x61060b8501c15939, x6de7844ec9827511);
	}

	private static int x396587bfd0095a31(string xc15bd84e01929885)
	{
		return (int)x682712679dbc585a.xce92de628aa023cf(x7f98d89aa4dd820b, xc15bd84e01929885);
	}

	private static int xdcef0b55ace39497(string xc15bd84e01929885)
	{
		return (int)x682712679dbc585a.xce92de628aa023cf(xdead9b6bd527cecc, xc15bd84e01929885);
	}

	private void xeae28d942cc1d73f(int xeaf1b27180c0557b, object xbcea506a33cf9111)
	{
		x7879fdf00fe45397.x4e35c79189b28e26.xd6b6ed77479ef68c(new x879a106b0501b9dc(xeaf1b27180c0557b, null, xbcea506a33cf9111));
	}

	private void x2d26bf63dcddf72d(int xeaf1b27180c0557b, object xbcea506a33cf9111)
	{
		xe492aecd71fb69dd.x4e35c79189b28e26.xd6b6ed77479ef68c(new x879a106b0501b9dc(xeaf1b27180c0557b, null, xbcea506a33cf9111));
	}

	private int x359b066bbed8b833(string xc15bd84e01929885, object xbcea506a33cf9111)
	{
		int num = x63255d49a8fe74a6++;
		xa9666ccdb8c16c55.x4e35c79189b28e26.xd6b6ed77479ef68c(new x879a106b0501b9dc(num, xc15bd84e01929885, xbcea506a33cf9111));
		return num;
	}

	private void xd2f3222333394dea()
	{
		foreach (DocumentProperty item in x41790cc63fab4cbb)
		{
			int num = x359b066bbed8b833(item.Name, item.x240f22d025b60fe7);
			if (x0d299f323d241756.x5959bccb67bbf051(item.x1321c7b28b151682))
			{
				xa9666ccdb8c16c55.x4e35c79189b28e26.xd6b6ed77479ef68c(new x879a106b0501b9dc(0x1000000 | num, null, item.x1321c7b28b151682));
			}
		}
	}

	private static int xc1365694bafe1d1a(DateTime x35e790da04c0f27f)
	{
		if (x35e790da04c0f27f == DateTime.MinValue)
		{
			return 0;
		}
		double totalMinutes = (x35e790da04c0f27f - x602d3a6c146ee2b4).TotalMinutes;
		if (!(totalMinutes > 0.0) || !(totalMinutes < 2147483647.0))
		{
			return 0;
		}
		return (int)totalMinutes;
	}

	private static DateTime xaa1f937f64e65733(int xd1f6c6f4f40b65fc)
	{
		if (xd1f6c6f4f40b65fc == 0)
		{
			return DateTime.MinValue;
		}
		TimeSpan timeSpan = TimeSpan.FromMinutes(xd1f6c6f4f40b65fc);
		return x602d3a6c146ee2b4 + timeSpan;
	}

	private void x3dc950453374051a(string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		x98b0e09ccece0a5a.x3dc950453374051a(xa056586c1f99e199, WarningSource.Doc, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}

	static xe6d08044467dd57c()
	{
		x602d3a6c146ee2b4 = new DateTime(1601, 1, 1);
		x61060b8501c15939 = new Hashtable();
		xdead9b6bd527cecc = new Hashtable();
		x06f5677326dd4629 = new Hashtable();
		x7f98d89aa4dd820b = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[26]
		{
			23, "Version", 17, "CharactersWithSpaces", 2, "Category", 4, "Bytes", 5, "Lines",
			6, "Paragraphs", 12, "HeadingPairs", 13, "TitlesOfParts", 14, "Manager", 15, "Company",
			16, "LinksUpToDate", 27, "ContentStatus", 26, "ContentType"
		}, x61060b8501c15939, xdead9b6bd527cecc);
		x682712679dbc585a.x70fa1602ceccddee(new object[30]
		{
			2, "Title", 3, "Subject", 4, "Author", 5, "Keywords", 6, "Comments",
			7, "Template", 8, "LastSavedBy", 11, "LastPrinted", 12, "CreateTime", 13, "LastSavedTime",
			14, "Pages", 15, "Words", 16, "Characters", 19, "Security", 18, "NameOfApplication"
		}, x06f5677326dd4629, x7f98d89aa4dd820b);
	}
}
