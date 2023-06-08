using System.Drawing;
using System.IO;
using System.Text;
using ns271;

namespace ns237;

internal class Class6529 : Class6528
{
	private readonly Class6733 class6733_0;

	internal Class6529(Class6672 context, FontStyle requestedStyle, Class6730 font, Enum873 fontType)
		: base(context, requestedStyle, font, fontType)
	{
		base.FontDescriptor = new Class6543(context, this);
		base.FirstChar = (char)Class6528.int_1;
		base.UsedChars = new bool[Class6528.int_1 + 1];
		if (method_5())
		{
			class6733_0 = new Class6733(font, isFullEmbedding: false, embedCffFileOnly: false);
		}
	}

	internal override string vmethod_6()
	{
		return "/TrueType";
	}

	public override void vmethod_2(Stream dstStream)
	{
		if (method_5())
		{
			class6733_0.method_2(dstStream, isMakeValidTtf: true, isFullEmbedding: false);
		}
		base.vmethod_2(dstStream);
	}

	private bool method_5()
	{
		return class6672_0.PdfaCompliant;
	}

	internal override void vmethod_4(string text)
	{
		if (method_5())
		{
			foreach (char c in text)
			{
				class6733_0.method_0(c);
			}
		}
		base.vmethod_4(text);
	}

	protected override string vmethod_3()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(method_2());
		if (base.IsSimulateBold && base.IsSimulateItalic)
		{
			stringBuilder.Append(",BoldItalic");
		}
		else if (base.IsSimulateBold)
		{
			stringBuilder.Append(",Bold");
		}
		else if (base.IsSimulateItalic)
		{
			stringBuilder.Append(",Italic");
		}
		return stringBuilder.Replace(" ", string.Empty).ToString();
	}
}
