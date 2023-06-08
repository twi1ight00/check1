using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Words.Fields;
using Aspose.Words.Reporting;
using x13f1efc79617a47b;
using x2a6f63b6650e76c4;
using x6c95d9cf46ff5f25;
using xb1090543d168d647;
using xe86f37adaccef1c3;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x561fa53c007d3597 : Field, x6ed66b5cf8da2955
{
	private const string xf71b9b3aca3c68bc = "tablestart";

	private const string x1102f70873b89cc9 = "tableend";

	private const string xc83fe3c477732d21 = "image";

	private const int x50b701cb8d66897e = 2;

	private const int x1963f3ecd6826a7e = 6;

	private const int xe25d309e676a481a = 4;

	private const int x5ddda6db6217b3a4 = 1;

	private const int xa358cd42003a65c5 = 2;

	private const int x19b08ed527ef5f03 = 3;

	private const int xf8ce88f0b43f2703 = 4;

	private string x363b3d27894c5a9f;

	private string xcd243a5d7178f0b0;

	private string xe6b1194a5c81b5f1;

	private string xef352825cdb55c36;

	private MergeFieldImageDimension x42e5c99daad7b47e;

	private MergeFieldImageDimension xc870c20d40920a8c;

	private static readonly Regex x7cd6bd4cdb5dbebb = new Regex("\\A((tablestart|tableend|image(\\s*\\((.*?)\\)\\s*)??)(:|_))?(.+)\\z", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	private static readonly Regex x2768612081fbe2f8 = new Regex("\\A\\s*(.+?)\\s*(pt|%|)\\s*;\\s*(.+?)\\s*(pt|%|)\\s*\\z", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	internal bool x6f452516cc92f528 => x27cd5f9641d9eb15.xa62d1d5c5f21cd20(x363b3d27894c5a9f, "tablestart");

	internal bool x5aafe4417767ef58 => x27cd5f9641d9eb15.xa62d1d5c5f21cd20(x363b3d27894c5a9f, "tableend");

	internal bool x3b0e6072839c4cc0 => x27cd5f9641d9eb15.x9c01925b84cc0a1b(x363b3d27894c5a9f, "image");

	internal string xd8a1c7c41bfbcde0 => x363b3d27894c5a9f;

	internal string xae9d2e3eea32978f => xcd243a5d7178f0b0;

	internal string xc0cc6aa8c5758ee8
	{
		get
		{
			if (xe6b1194a5c81b5f1 == null)
			{
				return string.Empty;
			}
			return xe6b1194a5c81b5f1;
		}
	}

	internal string x97586616c5ed2194
	{
		get
		{
			if (xef352825cdb55c36 == null)
			{
				return string.Empty;
			}
			return xef352825cdb55c36;
		}
	}

	internal static x561fa53c007d3597 x19b147e6909d4320(x5da40b5371fb63c5 xd467cf11a28aa761)
	{
		x561fa53c007d3597 x561fa53c007d3598 = new x561fa53c007d3597();
		x561fa53c007d3598.x20aee281977480cf(xd467cf11a28aa761.xa6531501d8d65c28(), xd467cf11a28aa761.x58c315215a8914d6(), xd467cf11a28aa761.x0743967e197899e8());
		x561fa53c007d3598.xcd243a5d7178f0b0 = xd467cf11a28aa761.x1cc850cdad47f539();
		return x561fa53c007d3598;
	}

	internal override void x20aee281977480cf(FieldStart x10aaa7cdfa38f254, FieldSeparator x3de314ab70bbd9bf, FieldEnd xca09b6c2b5b18485)
	{
		base.x20aee281977480cf(x10aaa7cdfa38f254, x3de314ab70bbd9bf, xca09b6c2b5b18485);
		xc8f5f9bd30e5d3f3();
	}

	internal override void xc8f5f9bd30e5d3f3()
	{
		base.xc8f5f9bd30e5d3f3();
		if (base.Type == FieldType.FieldMergeField)
		{
			xc8f5f9bd30e5d3f3(base.xb452e2ee706d7a67);
		}
	}

	internal void xc8f5f9bd30e5d3f3(string x0e59413709b18038)
	{
		xc8f5f9bd30e5d3f3(new x985dd08fd338eeea(x0e59413709b18038, this));
	}

	private void xc8f5f9bd30e5d3f3(x985dd08fd338eeea x0e59413709b18038)
	{
		x86b92c0f50f4a4d2(x0e59413709b18038.x642e37025c67edab(0));
		xe6b1194a5c81b5f1 = x0e59413709b18038.x6eba61762c5e83d7("\\b");
		xef352825cdb55c36 = x0e59413709b18038.x6eba61762c5e83d7("\\f");
	}

	private void x86b92c0f50f4a4d2(string x2af9f82dc0751a81)
	{
		if (x2af9f82dc0751a81 == null)
		{
			return;
		}
		x42e5c99daad7b47e = null;
		xc870c20d40920a8c = null;
		string xb37daae42e1995c = xed747ca236d86aa0.xe8201cb97474aaaf();
		xed747ca236d86aa0.xf4dc0c63b869aa1f();
		try
		{
			Match match = x7cd6bd4cdb5dbebb.Match(x2af9f82dc0751a81);
			x363b3d27894c5a9f = match.Groups[2].Value;
			xcd243a5d7178f0b0 = match.Groups[6].Value;
			if (!x3b0e6072839c4cc0)
			{
				return;
			}
			string value = match.Groups[4].Value;
			if (!x0d299f323d241756.x5959bccb67bbf051(value))
			{
				return;
			}
			match = x2768612081fbe2f8.Match(value);
			if (!match.Success)
			{
				return;
			}
			MergeFieldImageDimension mergeFieldImageDimension = MergeFieldImageDimension.x19890931227f0f56(match.Groups[1].Value, match.Groups[2].Value);
			if (mergeFieldImageDimension != null)
			{
				MergeFieldImageDimension mergeFieldImageDimension2 = MergeFieldImageDimension.x19890931227f0f56(match.Groups[3].Value, match.Groups[4].Value);
				if (mergeFieldImageDimension2 != null)
				{
					x42e5c99daad7b47e = mergeFieldImageDimension;
					xc870c20d40920a8c = mergeFieldImageDimension2;
				}
			}
		}
		finally
		{
			xed747ca236d86aa0.xcb651329dbd67ff0(xb37daae42e1995c);
		}
	}

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		xc5c3f438428cb03b xc5c3f438428cb03b = xc0702eba5bbdc74b();
		if (xc5c3f438428cb03b != null)
		{
			if (x3b0e6072839c4cc0)
			{
				return xdd44da4fbab52b81(xc5c3f438428cb03b);
			}
			return x67bf65e8693cdf2e(xc5c3f438428cb03b);
		}
		string result = $"{xc0cc6aa8c5758ee8}«{base.xb452e2ee706d7a67.x642e37025c67edab(0)}»{x97586616c5ed2194}";
		return new xca592a476766b11a(this, result, null, formatResult: false);
	}

	private xc5c3f438428cb03b xc0702eba5bbdc74b()
	{
		return (xc5c3f438428cb03b)base.x6edce55dcd2d335b.xc1acbb49fa87a8a3();
	}

	private x5dc2b4bc740c9563 x67bf65e8693cdf2e(xc5c3f438428cb03b xa4d52e34b62b5495)
	{
		FieldMergingArgs xfbf34718e704c6bc;
		bool flag = xa4d52e34b62b5495.xb7e46440d2a34d6d(this, out xfbf34718e704c6bc);
		object fieldValue = xfbf34718e704c6bc.FieldValue;
		if (base.x201282ef5b887ec3)
		{
			return null;
		}
		MailMerge mailMerge = x357c90b33d6bb8e6().MailMerge;
		string x7d95d971d8923f4c;
		if (xfbf34718e704c6bc.Text != null)
		{
			x7d95d971d8923f4c = xfbf34718e704c6bc.Text;
		}
		else
		{
			if (!flag)
			{
				if (mailMerge.x19a7586a42d9e390)
				{
					return new x713c10fc75949ae6(this, mailMerge.xe28d255488c46bd6, mailMerge.x6f8b96bfa12bb473);
				}
				return null;
			}
			if (fieldValue != null && !Convert.IsDBNull(fieldValue))
			{
				x82e26649b09596bd xbcea506a33cf = xb70755075b5f45f5(fieldValue);
				base.xa890d2fd18bed2bc.xd4f20c6c3f6afa2f(xbcea506a33cf, out x7d95d971d8923f4c);
				if (x0d299f323d241756.x5959bccb67bbf051(x7d95d971d8923f4c))
				{
					x7d95d971d8923f4c = $"{xc0cc6aa8c5758ee8}{x7d95d971d8923f4c}{x97586616c5ed2194}";
				}
			}
			else
			{
				x7d95d971d8923f4c = string.Empty;
			}
		}
		x15d8a03b1db63b1e cleanupAction = new x15d8a03b1db63b1e(mailMerge.xe28d255488c46bd6, mailMerge.x6f8b96bfa12bb473);
		return new xca592a476766b11a(this, x7d95d971d8923f4c, cleanupAction, formatResult: false);
	}

	private static x82e26649b09596bd xb70755075b5f45f5(object x807d8ebaad5996b9)
	{
		if (x807d8ebaad5996b9 is byte)
		{
			return new x918e475ee39e3253((int)(byte)x807d8ebaad5996b9);
		}
		if (x807d8ebaad5996b9 is short)
		{
			return new x918e475ee39e3253((short)x807d8ebaad5996b9);
		}
		if (x807d8ebaad5996b9 is int)
		{
			return new x918e475ee39e3253((int)x807d8ebaad5996b9);
		}
		if (x807d8ebaad5996b9 is long)
		{
			return new x918e475ee39e3253((long)x807d8ebaad5996b9);
		}
		if (x807d8ebaad5996b9 is float)
		{
			return new x918e475ee39e3253((float)x807d8ebaad5996b9);
		}
		if (x807d8ebaad5996b9 is double)
		{
			return new x918e475ee39e3253((double)x807d8ebaad5996b9);
		}
		if (x807d8ebaad5996b9 is DateTime)
		{
			return new x91fe491cf90c262f((DateTime)x807d8ebaad5996b9);
		}
		return new xdfbdf8708b1e8b71(x807d8ebaad5996b9.ToString());
	}

	private x5dc2b4bc740c9563 xdd44da4fbab52b81(xc5c3f438428cb03b xa4d52e34b62b5495)
	{
		ImageFieldMergingArgs xfbf34718e704c6bc;
		bool flag = xa4d52e34b62b5495.xbab965d1b5a8be25(this, out xfbf34718e704c6bc);
		object fieldValue = xfbf34718e704c6bc.FieldValue;
		if (base.x201282ef5b887ec3)
		{
			return null;
		}
		MailMerge mailMerge = x357c90b33d6bb8e6().MailMerge;
		Stream stream = null;
		if (x0d299f323d241756.x5959bccb67bbf051(xfbf34718e704c6bc.ImageFileName))
		{
			stream = xed747ca236d86aa0.xb93ba02d7ec640e0(xfbf34718e704c6bc.ImageFileName);
		}
		else if (xfbf34718e704c6bc.ImageStream != null)
		{
			stream = xfbf34718e704c6bc.ImageStream;
		}
		else if (xfbf34718e704c6bc.Image != null)
		{
			stream = new MemoryStream();
			x3cd5d648729cd9b6.x367bb145e7fa9226(xfbf34718e704c6bc.Image, stream);
		}
		else
		{
			if (!flag)
			{
				if (mailMerge.x19a7586a42d9e390)
				{
					return new x713c10fc75949ae6(this, mailMerge.xe28d255488c46bd6);
				}
				return null;
			}
			if (fieldValue != null && !Convert.IsDBNull(fieldValue))
			{
				try
				{
					if (fieldValue is byte[])
					{
						stream = new MemoryStream((byte[])fieldValue);
					}
					else
					{
						if (!(fieldValue is string))
						{
							throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mjcmnkjmhkanpfhnakonkjfokkmoejdpafkpdjbadjiamipaajgbfinbodecgjlciecdcjjdcdaeihhephoejcfflgmflhdgahkgcgbhnfihlgphjfgiffnioaejpfljhfckfajkeealeehlmpnlldfmpemmhednfdknicbohciohoooddgpddnpondaoclamccbhcjblbacnbhcdbocfnedgmldfadefbkebbbfklhfaapfiaggblmgfaehmokhlpbifkiinppialgjjpnjhkek", 1204142664)), xfbf34718e704c6bc.DocumentFieldName, fieldValue.GetType()));
						}
						stream = xed747ca236d86aa0.xb93ba02d7ec640e0(fieldValue.ToString());
					}
				}
				catch (Exception ex)
				{
					throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dnbiooiiippifpgjdpnjfpekojlkhoclhojlgnamgnhmpiomfnfngnmnhmdokmkofmbpnhipamppjmgadmnaoleboglbblccbljckkadokhddkodmffeagmebldfdgkfnkbgefigifpgheghihnhjieidilildcjohjjohakhhhklhokahfljcmljgdmchkmogbnbhinlfpnaggocgnoegepoalppecajejajfabdehbppnbfefchemcgpcdiekdodbeaeiepdpehdgfednfadegadlgpcchnbjhjbaicngifboilbfjlbmjdbdkeakkebbllmhlklolcbgmfmmmoaen", 1643020688)), xfbf34718e704c6bc.DocumentFieldName, ex.Message));
				}
			}
		}
		x15d8a03b1db63b1e cleanupAction = new x15d8a03b1db63b1e(mailMerge.xe28d255488c46bd6, mailMerge.x6f8b96bfa12bb473);
		return new x94fd89996b5d6f25(this, stream, xfbf34718e704c6bc.ImageWidth, xfbf34718e704c6bc.ImageHeight, cleanupAction);
	}

	internal override xea515a7e0d19a986 xadf6796b90c1934e()
	{
		xea515a7e0d19a986 xea515a7e0d19a = base.xadf6796b90c1934e();
		xc5c3f438428cb03b xc5c3f438428cb03b = xc0702eba5bbdc74b();
		if (xc5c3f438428cb03b == null)
		{
			return xea515a7e0d19a;
		}
		foreach (xcfa6f73a76d96956 item in base.xb452e2ee706d7a67.x7261c103565fa212)
		{
			if (x5c29822913be33c1.x5580509afa07e28e(item.x759aa16c2016a289))
			{
				return xea515a7e0d19a;
			}
		}
		return new x5c9a4dc7d7dc8e67(xc5c3f438428cb03b, xea515a7e0d19a);
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\m":
		case "\\v":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\b":
		case "\\f":
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}

	internal MergeFieldImageDimension x9e7ae1da8539c294()
	{
		return xd0a26bb4af7ba32a(x42e5c99daad7b47e);
	}

	internal MergeFieldImageDimension x1bb8c0117ad009d3()
	{
		return xd0a26bb4af7ba32a(xc870c20d40920a8c);
	}

	private MergeFieldImageDimension xd0a26bb4af7ba32a(MergeFieldImageDimension x337e217cb3ba0627)
	{
		if (x337e217cb3ba0627 != null)
		{
			return x337e217cb3ba0627.x8b61531c8ea35b85();
		}
		return new MergeFieldImageDimension();
	}
}
