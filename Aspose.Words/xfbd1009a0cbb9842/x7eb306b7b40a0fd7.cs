using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fields;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x7eb306b7b40a0fd7 : Field, x6ed66b5cf8da2955
{
	internal string xa39af5a82860a9a3 => base.xb452e2ee706d7a67.x642e37025c67edab(0);

	internal string x0e99a2a20bc3c647 => base.xb452e2ee706d7a67.x642e37025c67edab(1);

	internal bool x72276a1e9d3609b7 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\!");

	internal string x6083d35d6209dac5 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\c");

	internal string xe3f198ba0942c956 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\n");

	internal string x78bc7334f6586888 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\t");

	internal string x8d815cb9b264fc20 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\x");

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		Uri uri = x0d299f323d241756.xece38db10adcf774(xa39af5a82860a9a3);
		string text = ((null != uri) ? uri.LocalPath : xa39af5a82860a9a3);
		if (!File.Exists(text))
		{
			return new xd5801a931e010963(this, "Error! Not a valid filename.");
		}
		if (FileFormatUtil.DetectFileFormat(text).LoadFormat == LoadFormat.Unknown)
		{
			return new xd5801a931e010963(this, string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ebnfpcegjdlggdchedjhgdaipngifcoihcfjjbmjpbdkfckkbbblpailhmoliagmabnmbaenablnfacokpioaaapdahpmknpipeamoladkcbepjbfoacdohckoocejfdfomdhodelnkenmbffiifdmpfdnggmhngnmehollhilciahjiklajjlhjelojjkfkpkmkcldljgkl", 1617648849)));
		}
		base.x6edce55dcd2d335b.xdd53735657fe1b6b();
		try
		{
			Document document = new Document(text);
			x7e263f21a73a027a x5f36ad26e64b91c;
			if (!x0d299f323d241756.x5959bccb67bbf051(x0e99a2a20bc3c647))
			{
				x5f36ad26e64b91c = new x7e263f21a73a027a(document.FirstSection.Body.FirstChild, document.LastSection.Body.LastChild);
			}
			else
			{
				Bookmark bookmark = document.Range.Bookmarks[x0e99a2a20bc3c647];
				if (bookmark == null)
				{
					return new xd5801a931e010963(this, "Error! Bookmark not defined.");
				}
				x5f36ad26e64b91c = bookmark.x451c3f5e0b9f8822();
			}
			xa645a74f32ce7b5e xcbf24c118ac8aa0b = new xa645a74f32ce7b5e(document, x357c90b33d6bb8e6());
			x0a28863c804404d7.x775521112ede5e6f(x5f36ad26e64b91c, base.End, xcbf24c118ac8aa0b);
			base.x6edce55dcd2d335b.xac51c2571643df46();
			x2c3ae36fc00d97a7();
			if (x72276a1e9d3609b7)
			{
				xe281e37eccb3c698();
			}
		}
		catch
		{
			return new xd5801a931e010963(this, "Error! Not a valid filename.");
		}
		return new xbd727e2aafbfe2ad(this);
	}

	private void xe281e37eccb3c698()
	{
		foreach (Node item in xabae4fa6681a6afd(x7d5e2f34b6651bf4.xf8d31d196ccd74c4))
		{
			if (item.NodeType == NodeType.FieldStart)
			{
				((FieldStart)item).IsLocked = true;
			}
		}
	}

	private void x2c3ae36fc00d97a7()
	{
		Paragraph parentParagraph = base.Separator.ParentParagraph;
		if (parentParagraph.NextSibling is Paragraph paragraph)
		{
			Node firstChild = paragraph.FirstChild;
			Node node = parentParagraph.FirstChild;
			while (node != null)
			{
				Node nextSibling = node.NextSibling;
				paragraph.InsertBefore(node, firstChild);
				node = nextSibling;
			}
			parentParagraph.Remove();
		}
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\!":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\c":
		case "\\n":
		case "\\t":
		case "\\x":
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
}
