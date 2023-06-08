using System.Drawing;
using System.IO;
using System.Text;
using ns218;
using ns234;
using ns271;

namespace ns237;

internal class Class6530 : Class6527
{
	private readonly Class6541 class6541_0;

	private readonly Class6514 class6514_0;

	private readonly Class6733 class6733_0;

	public Class6530(Class6672 context, FontStyle requestedStyle, Class6730 font, Enum873 fontType, Enum872 fontEmbeddingRule)
		: base(context, requestedStyle, font, fontType)
	{
		class6541_0 = new Class6541(context, this);
		class6514_0 = new Class6514(context);
		base.IsFullEmbedding = Class5957.smethod_4((int)fontEmbeddingRule, 4);
		string_1 = vmethod_3();
		class6733_0 = new Class6733(font, base.IsFullEmbedding, !base.IsFullEmbedding && context.Options.Compliance == Enum883.const_0);
		class6733_0.method_0('A');
	}

	internal bool method_3(string text, Class6678 writer)
	{
		bool result = false;
		foreach (char c in text)
		{
			int num = class6733_0.method_0(c);
			if (num >= 0)
			{
				writer.method_22(num);
			}
			if (num <= 0)
			{
				result = true;
			}
		}
		return result;
	}

	public override void vmethod_2(Stream dstStream)
	{
		class6733_0.method_2(dstStream, isMakeValidTtf: false, base.IsFullEmbedding);
	}

	internal string method_4(int defaultWidth)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		for (int i = 0; i < class6733_0.CharsToNewGlyphIndexes.Count; i++)
		{
			char charCode = (char)class6733_0.CharsToNewGlyphIndexes.method_4(i);
			int val = (int)class6733_0.CharsToNewGlyphIndexes.method_3(i);
			Class6734 @class = class6730_0.Glyphs.method_0(charCode);
			int num = method_1(@class.AdvanceWidth);
			if (num != defaultWidth)
			{
				stringBuilder.Append(Class6159.smethod_24(val));
				stringBuilder.Append("[");
				stringBuilder.Append(Class6159.smethod_24(num));
				stringBuilder.Append("]");
			}
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	public override void vmethod_0(Class6679 writer)
	{
		method_5(writer);
		class6541_0.vmethod_0(writer);
		method_6(writer);
	}

	protected override string vmethod_1()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("F");
		string text = $"{base.Id:D5}";
		for (int i = 0; i < text.Length; i++)
		{
			stringBuilder.Append((char)(text[i] + 17));
		}
		return stringBuilder.ToString();
	}

	private void method_5(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/Font");
		writer.method_8("/Subtype", "/Type0");
		writer.method_8("/Encoding", "/Identity-H");
		writer.method_8("/BaseFont", $"/{string_1}");
		writer.method_8("/DescendantFonts", $"[{class6541_0.IndirectReference}]");
		writer.method_8("/ToUnicode", class6514_0.IndirectReference);
		writer.method_7();
		writer.method_30();
	}

	private void method_6(Class6679 writer)
	{
		class6514_0.method_1("/CIDInit /ProcSet findresource begin");
		class6514_0.method_1("11 dict begin");
		class6514_0.method_1("begincmap");
		class6514_0.method_1("/CIDSystemInfo");
		class6514_0.method_1("<< /Registry (Adobe)");
		class6514_0.method_1("/Ordering (UCS)");
		class6514_0.method_1("/Supplement 0");
		class6514_0.method_1(">> def");
		class6514_0.method_1("/CMapName /Adobe-Identity-UCS def");
		class6514_0.method_1("/CMapType 2 def");
		class6514_0.method_1("1 begincodespacerange");
		class6514_0.method_1("<0000><FFFF>");
		class6514_0.method_1("endcodespacerange");
		method_7();
		class6514_0.method_1("endcmap");
		class6514_0.method_1("CMapName currentdict /CMap defineresource pop");
		class6514_0.method_1("end");
		class6514_0.method_1("end");
		class6514_0.vmethod_0(writer);
	}

	private void method_7()
	{
		Class5967 @class = method_8();
		class6514_0.method_2("{0} beginbfchar", Class6159.smethod_24(@class.Count));
		for (int i = 0; i < @class.Count; i++)
		{
			int val = @class.method_4(i);
			int val2 = (int)@class.method_3(i);
			class6514_0.method_3("<{0}><{1}>", Class6159.smethod_35(val), Class6159.smethod_35(val2));
		}
		class6514_0.method_1("endbfchar");
	}

	private Class5967 method_8()
	{
		Class5967 @class = new Class5967();
		for (int i = 0; i < class6733_0.CharsToNewGlyphIndexes.Count; i++)
		{
			int num = class6733_0.CharsToNewGlyphIndexes.method_4(i);
			int key = (int)class6733_0.CharsToNewGlyphIndexes.method_3(i);
			@class[key] = num;
		}
		return @class;
	}
}
