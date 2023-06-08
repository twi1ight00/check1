using System.Collections;
using System.IO;
using ns218;
using ns272;

namespace ns271;

internal class Class6733
{
	private readonly Class5967 class5967_0 = new Class5967();

	private readonly Class5967 class5967_1 = new Class5967();

	private readonly Class6730 class6730_0;

	private bool bool_0;

	public Class5967 CharsToNewGlyphIndexes => class5967_0;

	public Class6730 TTFont => class6730_0;

	public Class6733(Class6730 font, bool isFullEmbedding, bool embedCffFileOnly)
	{
		class6730_0 = font;
		bool_0 = embedCffFileOnly;
		if (!font.IsCff && !isFullEmbedding)
		{
			method_0('\uffff');
		}
		else
		{
			method_4();
		}
	}

	public Class6733(Class6730 font, bool isFullEmbedding)
		: this(font, isFullEmbedding, embedCffFileOnly: false)
	{
	}

	public int method_0(char c)
	{
		object obj = class5967_0[c];
		int num;
		if (obj != null)
		{
			num = (int)obj;
		}
		else
		{
			Class6734 @class = class6730_0.Glyphs.method_0(c);
			if (@class.AdvanceWidth == 0 && (c < '\u0300' || c > '\u036f'))
			{
				return -1;
			}
			obj = class5967_1[@class.OldGlyphIndex];
			if (obj != null)
			{
				num = (int)obj;
				class5967_0.Add(c, num);
			}
			else
			{
				num = class5967_1.Count;
				class5967_1.Add(@class.OldGlyphIndex, num);
				class5967_0.Add(c, num);
			}
		}
		return num;
	}

	public void method_1(Stream dstStream, bool isMakeValidTtf)
	{
		method_2(dstStream, isMakeValidTtf, isFullEmbedding: false);
	}

	public void method_2(Stream dstStream, bool isMakeValidTtf, bool isFullEmbedding)
	{
		Class6732 @class = new Class6732();
		if (class6730_0.IsCff && bool_0)
		{
			@class.method_30(class6730_0, dstStream);
		}
		else
		{
			@class.method_2(class6730_0, class5967_0, class5967_1, dstStream, isMakeValidTtf, isFullEmbedding);
		}
	}

	public Hashtable method_3()
	{
		Class6732 @class = new Class6732();
		return @class.method_3(class6730_0, class5967_1, class6730_0.EmHeight);
	}

	private void method_4()
	{
		if (class6730_0.Cmap.method_4() is Class6648 @class)
		{
			int segCount = @class.SegCount;
			for (int i = 0; i < segCount; i++)
			{
				int num = @class.StartCode[i];
				int num2 = @class.EndCode[i];
				for (int j = num; j <= num2; j++)
				{
					char c = (char)j;
					Class6734 class2 = class6730_0.Glyphs.method_0(c);
					class5967_0.Add(c, class2.OldGlyphIndex);
				}
			}
		}
		else if (class6730_0.Cmap.method_4() is Class6647 class3)
		{
			for (char c2 = '\0'; c2 < '\uffff'; c2 = (char)(c2 + 1))
			{
				int num3 = class3.vmethod_3(c2);
				class5967_0.Add(c2, num3);
			}
		}
	}
}
