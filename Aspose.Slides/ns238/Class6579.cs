using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ns218;
using ns224;
using ns233;
using ns235;
using ns271;

namespace ns238;

internal class Class6579 : Class6568
{
	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	private Hashtable hashtable_2 = new Hashtable();

	private List<Class6730> list_0 = new List<Class6730>();

	private Hashtable hashtable_3 = new Hashtable();

	private Hashtable hashtable_4 = new Hashtable();

	private short short_0;

	private int int_0;

	private int int_1;

	public short PageId => short_0;

	public int PageWidth => int_0;

	public int PageHeight => int_1;

	public Hashtable Hyperlinks => hashtable_4;

	public Class6579(Class6567 context, short pageSpriteId, SizeF pageSize)
		: base(context)
	{
		short_0 = pageSpriteId;
		int_0 = Class5955.smethod_29(pageSize.Width);
		int_1 = Class5955.smethod_29(pageSize.Height);
	}

	public void Write(int pageIndex, bool isViewerIncluded)
	{
		Class6572 @class = new Class6572(base.Context);
		foreach (Class6730 item in list_0)
		{
			@class.method_0(item);
		}
		Class6576 class2 = new Class6576(base.Context);
		foreach (DictionaryEntry item2 in hashtable_3)
		{
			class2.method_0((byte[])item2.Value, (short)item2.Key);
		}
		Class6585 class3 = new Class6585(base.Context);
		foreach (DictionaryEntry item3 in hashtable_0)
		{
			class3.method_0((Class6219)item3.Value, (short)item3.Key);
		}
		Class6582 class4 = new Class6582(base.Context);
		foreach (DictionaryEntry item4 in hashtable_1)
		{
			class4.method_0((Class6217)item4.Value, (short)item4.Key);
		}
		foreach (DictionaryEntry item5 in hashtable_2)
		{
			Class6583 class5 = (Class6583)item5.Value;
			class5.Write();
		}
		string text = $"page{pageIndex:D9}";
		if (isViewerIncluded)
		{
			method_4(text, short_0);
		}
		else
		{
			Class6591 placeObject = new Class6591(short_0, null, (short)pageIndex, text);
			Class6580 class6 = new Class6580(base.Context);
			class6.method_1(placeObject);
		}
		base.Writer.method_16(Enum878.const_1, 0);
	}

	public short AddText(Class6219 glyphs)
	{
		Class6730 trueTypeFont = glyphs.Font.TrueTypeFont;
		if (!base.Context.method_2(trueTypeFont))
		{
			list_0.Add(trueTypeFont);
		}
		Class6586 @class = base.Context.method_4(trueTypeFont);
		@class.method_0(glyphs.Text);
		short num = base.Context.method_10();
		hashtable_0.Add(num, glyphs);
		return num;
	}

	public short method_0(Class6217 path)
	{
		short num = base.Context.method_10();
		hashtable_1.Add(num, path);
		if (path.Brush != null)
		{
			method_1(path.Brush);
		}
		if (path.Pen != null && path.Pen.Brush != null)
		{
			method_1(path.Pen.Brush);
		}
		return num;
	}

	private void method_1(Class5990 brush)
	{
		switch (brush.BrushType)
		{
		case Enum746.const_1:
			AddImage(Class6141.smethod_0((Class5996)brush));
			break;
		case Enum746.const_2:
			AddImage(((Class5995)brush).ImageBytes);
			break;
		}
	}

	public void AddImage(byte[] imageBytes)
	{
		if (!base.Context.method_5(imageBytes))
		{
			short num = base.Context.method_6(imageBytes);
			imageBytes = Class6587.smethod_0(imageBytes, base.Context.Options.JpegQuality);
			hashtable_3[num] = imageBytes;
		}
	}

	public void method_2(Class6583 spriteWriter)
	{
		hashtable_2.Add(spriteWriter.CharacterId, spriteWriter);
	}

	public void method_3(short characterId, Class6270 hyperlink)
	{
		hashtable_4[characterId] = hyperlink;
	}

	private void method_4(string spriteName, short spriteId)
	{
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_2(1);
		base.Writer.method_9(spriteName);
		string text = Convert.ToBase64String(Class6592.PageAbcData);
		string text2 = Convert.ToBase64String(Encoding.UTF8.GetBytes("TemplatePages"));
		string text3 = Convert.ToBase64String(Encoding.UTF8.GetBytes(spriteName));
		text = text.Replace(text2.Substring(0, text2.Length - 2), text3.Substring(0, text3.Length - 2));
		base.Writer.method_0(Convert.FromBase64String(text));
		@class.method_1(Enum878.const_55);
		@class.method_0();
		base.Writer.method_1(1);
		base.Writer.method_1(spriteId);
		base.Writer.method_9(spriteName);
		@class.method_1(Enum878.const_52);
	}
}
