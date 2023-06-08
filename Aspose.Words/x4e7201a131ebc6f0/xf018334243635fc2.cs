using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;
using x9b5b1a17490bd5f3;

namespace x4e7201a131ebc6f0;

internal class xf018334243635fc2
{
	private DocumentBuilder x3b4f374f0aa4599b;

	private readonly LoadOptions xd545ef71ef25db52;

	private bool x91c8fe550136f8dd;

	private string x905793b172319375;

	private int xd53f14c3ae900d2c;

	private int xf63e2e3cd6453e2c;

	private x1db3a108be0bd856 x22b177c2f3dd0b22;

	private xc5f6f2ca0aafd220 x5b31e050531694cd;

	private x8945e5e373eb8aa6 xee9b4ce877ec2cb0;

	private string xe8cd133d029b0775;

	private string xfaf3cb141245c220;

	private int x954646ed317383ac;

	private int x2994ebde70f3ba41;

	private Encoding x03c08dd551c66dae;

	private static readonly Regex x1bd5216920f41794 = new Regex("^(?:multipart/[a-z0-9-]+|(?:text|image)(?:/[^/]*)?)?$", RegexOptions.Compiled);

	private bool x156eafdc8eb80a27 => xee9b4ce877ec2cb0 == x8945e5e373eb8aa6.x36110ac077c974bc;

	internal xf018334243635fc2(LoadOptions loadOptions)
	{
		xd545ef71ef25db52 = loadOptions;
	}

	internal void x06b0e25aa6ad68a9(Stream xcf18e5243f8d5fd3, Document x6beba47238e0ade6)
	{
		x905793b172319375 = new StreamReader(xcf18e5243f8d5fd3, Encoding.GetEncoding(1252)).ReadToEnd();
		x22b177c2f3dd0b22 = new x1db3a108be0bd856();
		x22b177c2f3dd0b22.x1f490eac106aee12(x905793b172319375, ref xd53f14c3ae900d2c, xfc076963a5541b8a: true);
		if (!x1bd5216920f41794.IsMatch(x22b177c2f3dd0b22.x0b93856f95be30d0))
		{
			throw new NotSupportedException($"Specified content type is not supported: {x22b177c2f3dd0b22.x0b93856f95be30d0}.");
		}
		xf63e2e3cd6453e2c = x905793b172319375.Length - xd53f14c3ae900d2c;
		xee9b4ce877ec2cb0 = x8945e5e373eb8aa6.x36110ac077c974bc;
		xe8cd133d029b0775 = x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4;
		x3b4f374f0aa4599b = new DocumentBuilder(x6beba47238e0ade6);
		xafe4c84dad991034();
	}

	private void xafe4c84dad991034()
	{
		if (x22b177c2f3dd0b22.x8945e5e373eb8aa6 != 0)
		{
			xd5f4297b62020f85();
		}
		else if (x22b177c2f3dd0b22.x0b93856f95be30d0 == "text/html")
		{
			xe531712616d6b172();
		}
		else if (xee9b4ce877ec2cb0 == x8945e5e373eb8aa6.x4584065da1a89b7a)
		{
			x25e3e6352376ad1e();
		}
		else if (x156eafdc8eb80a27)
		{
			xf8a40478b82d35ca();
		}
	}

	private void xd5f4297b62020f85()
	{
		if (x22b177c2f3dd0b22.x8945e5e373eb8aa6 == x8945e5e373eb8aa6.x4584065da1a89b7a && x22b177c2f3dd0b22.x0707b0d65a658243.Length != 0 && x22b177c2f3dd0b22.x0707b0d65a658243 != "text/html" && x22b177c2f3dd0b22.x0707b0d65a658243 != "multipart/alternative")
		{
			throw new NotSupportedException($"Unsupported target content type in a multipart/related structure: {x22b177c2f3dd0b22.x0707b0d65a658243}.");
		}
		if (!x156eafdc8eb80a27 && (xee9b4ce877ec2cb0 != x8945e5e373eb8aa6.x4584065da1a89b7a || x22b177c2f3dd0b22.x8945e5e373eb8aa6 != x8945e5e373eb8aa6.xea4d252d87fc677b) && (xee9b4ce877ec2cb0 != x8945e5e373eb8aa6.xea4d252d87fc677b || x22b177c2f3dd0b22.x8945e5e373eb8aa6 != x8945e5e373eb8aa6.x4584065da1a89b7a))
		{
			return;
		}
		bool flag = x156eafdc8eb80a27 && x22b177c2f3dd0b22.x8945e5e373eb8aa6 != x8945e5e373eb8aa6.x36110ac077c974bc;
		if (flag)
		{
			x9a2845ba8f07845d();
		}
		x8945e5e373eb8aa6 x8945e5e373eb8aa7 = xee9b4ce877ec2cb0;
		string text = xe8cd133d029b0775;
		xee9b4ce877ec2cb0 = x22b177c2f3dd0b22.x8945e5e373eb8aa6;
		if (x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4.Length != 0)
		{
			xe8cd133d029b0775 = x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4;
		}
		x22a6d26ddb3dacb9();
		xe8cd133d029b0775 = text;
		xee9b4ce877ec2cb0 = x8945e5e373eb8aa7;
		if (flag)
		{
			if (x2994ebde70f3ba41 == 0)
			{
				throw new InvalidOperationException("Root HTML resource is not found in a multipart structure.");
			}
			xddc8f9d0b6206645();
		}
	}

	private void x22a6d26ddb3dacb9()
	{
		Regex regex = x24d30a19a0947ed1(x22b177c2f3dd0b22.xa1e62debd3c311a5);
		Match match = regex.Match(x905793b172319375, xd53f14c3ae900d2c);
		while (match.Success)
		{
			xd53f14c3ae900d2c = match.Index + match.Length;
			if (match.Groups[1].Success)
			{
				break;
			}
			bool flag = x22b177c2f3dd0b22.x1f490eac106aee12(x905793b172319375, ref xd53f14c3ae900d2c, xfc076963a5541b8a: false);
			xf63e2e3cd6453e2c = x905793b172319375.Length - xd53f14c3ae900d2c;
			match = regex.Match(x905793b172319375, xd53f14c3ae900d2c);
			if (match.Success)
			{
				xf63e2e3cd6453e2c = match.Index - xd53f14c3ae900d2c;
			}
			if (flag)
			{
				xafe4c84dad991034();
			}
		}
	}

	private void xe531712616d6b172()
	{
		string text = xe8cd133d029b0775;
		if (x156eafdc8eb80a27 || x2994ebde70f3ba41 == 0)
		{
			if (x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4.Length != 0)
			{
				xe8cd133d029b0775 = x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4;
			}
			xfaf3cb141245c220 = x22b177c2f3dd0b22.xd6224c0caa44176e;
			x954646ed317383ac = xd53f14c3ae900d2c;
			x2994ebde70f3ba41 = xf63e2e3cd6453e2c;
			x03c08dd551c66dae = x56eb95f766e8a78c.xba7d93913e2c1836(x22b177c2f3dd0b22.x27ef141299301ded);
		}
		if (x156eafdc8eb80a27)
		{
			x5b31e050531694cd = new xc5f6f2ca0aafd220(xd545ef71ef25db52);
			xddc8f9d0b6206645();
			xe8cd133d029b0775 = text;
		}
	}

	private void x25e3e6352376ad1e()
	{
		if (x22b177c2f3dd0b22.xcf1958c8ba1531d5.Length == 0 && x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4.Length == 0 && x22b177c2f3dd0b22.x56c1af88a9bb0378.Length == 0)
		{
			return;
		}
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			x56eb95f766e8a78c.xaf3fe0636f87a61e(memoryStream, x905793b172319375, xd53f14c3ae900d2c, xf63e2e3cd6453e2c, x22b177c2f3dd0b22.xd6224c0caa44176e);
			byte[] array = memoryStream.GetBuffer();
			if (array.Length != memoryStream.Length)
			{
				array = memoryStream.ToArray();
			}
			if (x22b177c2f3dd0b22.xcf1958c8ba1531d5.Length != 0)
			{
				x5b31e050531694cd.x0cd0eeb5ca95cea9.xd1150d5ec6c325df("cid:" + x22b177c2f3dd0b22.xcf1958c8ba1531d5, array);
			}
			if (x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4.Length != 0)
			{
				x5b31e050531694cd.x0cd0eeb5ca95cea9.xd1150d5ec6c325df(x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4, array);
				if (xe8cd133d029b0775.Length != 0 && x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4.StartsWith(xe8cd133d029b0775))
				{
					int i = xe8cd133d029b0775.Length;
					int length;
					for (length = x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4.Length; i < length && x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4[i] == '/'; i++)
					{
					}
					if (i < length)
					{
						string x50a18ad2656e = x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4.Substring(i);
						x5b31e050531694cd.x0cd0eeb5ca95cea9.xd1150d5ec6c325df(x50a18ad2656e, array);
					}
				}
			}
			if (x22b177c2f3dd0b22.x56c1af88a9bb0378.Length != 0 && x22b177c2f3dd0b22.x56c1af88a9bb0378 != x22b177c2f3dd0b22.x1ce10e3dd5f1d7f4)
			{
				x5b31e050531694cd.x0cd0eeb5ca95cea9.xd1150d5ec6c325df(x22b177c2f3dd0b22.x56c1af88a9bb0378, array);
			}
		}
		catch (Exception)
		{
		}
	}

	private void xf8a40478b82d35ca()
	{
		bool flag = x34373120251ba1e5(x22b177c2f3dd0b22.x0b93856f95be30d0, "image");
		if (!flag && x22b177c2f3dd0b22.x0b93856f95be30d0.Length != 0 && !x34373120251ba1e5(x22b177c2f3dd0b22.x0b93856f95be30d0, "text"))
		{
			return;
		}
		using MemoryStream memoryStream = new MemoryStream();
		x56eb95f766e8a78c.xaf3fe0636f87a61e(memoryStream, x905793b172319375, xd53f14c3ae900d2c, xf63e2e3cd6453e2c, x22b177c2f3dd0b22.xd6224c0caa44176e);
		memoryStream.Position = 0L;
		x8b0a7170ed016164();
		if (flag)
		{
			Shape shape = x3b4f374f0aa4599b.InsertImage(memoryStream);
			shape.ParentParagraph.x1a78664fa10a3755.x9ba359ff37a3a63b = ParagraphAlignment.Center;
		}
		else
		{
			Encoding encoding = x56eb95f766e8a78c.xba7d93913e2c1836(x22b177c2f3dd0b22.x27ef141299301ded);
			StreamReader streamReader = ((encoding != null) ? new StreamReader(memoryStream, encoding) : new StreamReader(memoryStream));
			x3b4f374f0aa4599b.Write(streamReader.ReadToEnd());
		}
		x91c8fe550136f8dd = true;
	}

	private void x9a2845ba8f07845d()
	{
		x5b31e050531694cd = new xc5f6f2ca0aafd220(xd545ef71ef25db52);
		xfaf3cb141245c220 = string.Empty;
		x954646ed317383ac = 0;
		x2994ebde70f3ba41 = 0;
		x03c08dd551c66dae = null;
	}

	private void xddc8f9d0b6206645()
	{
		using MemoryStream memoryStream = new MemoryStream();
		x56eb95f766e8a78c.xaf3fe0636f87a61e(memoryStream, x905793b172319375, x954646ed317383ac, x2994ebde70f3ba41, xfaf3cb141245c220);
		memoryStream.Position = 0L;
		if (xe8cd133d029b0775.Length != 0)
		{
			x3b4f374f0aa4599b.Document.xb93d084d48e486dd = (x0d4d45882065c63e.xa141f5cbe7fb508b(xe8cd133d029b0775) ? x0d4d45882065c63e.xad7c54e85c011ae5(xe8cd133d029b0775) : xe8cd133d029b0775);
		}
		x8b0a7170ed016164();
		x5b31e050531694cd.x06b0e25aa6ad68a9(memoryStream, x03c08dd551c66dae, x3b4f374f0aa4599b);
		x91c8fe550136f8dd = true;
	}

	private void x8b0a7170ed016164()
	{
		if (x91c8fe550136f8dd)
		{
			if (x3b4f374f0aa4599b.CurrentParagraph.HasChildNodes)
			{
				x3b4f374f0aa4599b.xb41fed203ad7c94f(BreakType.ParagraphBreak, x291fabf8727e1df6: false);
			}
			Shape node = Shape.xb939ebca8a836c60(x3b4f374f0aa4599b.Document);
			x3b4f374f0aa4599b.InsertNode(node);
			x3b4f374f0aa4599b.ParagraphFormat.ClearFormatting();
		}
	}

	private static Regex x24d30a19a0947ed1(string x362993ef901691f7)
	{
		return new Regex($"^--{Regex.Escape(x362993ef901691f7)}(--)?(?:\r?\n)?", RegexOptions.Multiline);
	}

	private static bool x34373120251ba1e5(string xe1d3286d17e44a37, string xcb4ff4fe7b4fe7e6)
	{
		if (xe1d3286d17e44a37.StartsWith(xcb4ff4fe7b4fe7e6))
		{
			if (xe1d3286d17e44a37.Length != xcb4ff4fe7b4fe7e6.Length)
			{
				return xe1d3286d17e44a37[xcb4ff4fe7b4fe7e6.Length] == '/';
			}
			return true;
		}
		return false;
	}
}
