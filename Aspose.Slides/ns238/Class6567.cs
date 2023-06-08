using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ns218;
using ns223;
using ns235;
using ns271;

namespace ns238;

internal class Class6567
{
	private Class6588 class6588_0;

	private Class6566 class6566_0;

	private short short_0 = 300;

	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	private Hashtable hashtable_2 = new Hashtable();

	private Hashtable hashtable_3 = new Hashtable();

	private List<Class6579> list_0 = new List<Class6579>();

	private Class6579 class6579_0;

	private int int_0;

	private Class6589 class6589_0;

	private Class6730 class6730_0;

	public Class6588 Options => class6588_0;

	public Class6566 Writer => class6566_0;

	public IList<Class6579> Pages => list_0;

	public Class6579 CurrentPage => class6579_0;

	public Class6730 ToolTipFont => class6730_0;

	public Hashtable Bookmarks => hashtable_3;

	public Class6589 Outline => class6589_0;

	public Class6567(Stream stream, Class6588 options)
	{
		class6566_0 = new Class6566(stream);
		class6588_0 = options;
		class6589_0 = new Class6589(class6588_0.ExpandedOutlineLevels);
	}

	public void method_0(short pageSpriteId, SizeF pageSize)
	{
		class6579_0 = new Class6579(this, pageSpriteId, pageSize);
	}

	public void method_1(Class6583 pageSprite)
	{
		class6579_0.method_2(pageSprite);
		list_0.Add(class6579_0);
		int_0++;
	}

	public bool method_2(Class6730 font)
	{
		return hashtable_0[font] != null;
	}

	public short method_3(Class6730 font)
	{
		object obj = hashtable_0[font];
		if (obj != null)
		{
			return (short)obj;
		}
		short num = method_10();
		hashtable_0[font] = num;
		return num;
	}

	public Class6586 method_4(Class6730 font)
	{
		short num = method_3(font);
		Class6586 @class = (Class6586)hashtable_1[num];
		if (@class == null)
		{
			@class = new Class6586(font);
			@class.method_0(" ");
			hashtable_1[num] = @class;
		}
		return @class;
	}

	public bool method_5(byte[] imageBytes)
	{
		return hashtable_2[Class5981.smethod_0(imageBytes)] != null;
	}

	public short method_6(byte[] imageBytes)
	{
		Guid guid = Class5981.smethod_0(imageBytes);
		object obj = hashtable_2[guid];
		if (obj != null)
		{
			return (short)obj;
		}
		short num = method_10();
		hashtable_2[guid] = num;
		return num;
	}

	public void method_7(Class6211 bookmark)
	{
		string text = method_12(bookmark.Origin);
		hashtable_3[bookmark.Name] = text;
		int bookmarksOutlineLevel = class6588_0.BookmarksOutlineLevel;
		if (bookmarksOutlineLevel > 0 && !bookmark.IsHiddenFromOutline)
		{
			class6589_0.method_0(bookmarksOutlineLevel, bookmark.Name, text);
		}
	}

	public void method_8(Class6221 item)
	{
		string navigationUrl = method_12(item.Origin);
		int headingsOutlineLevels = class6588_0.HeadingsOutlineLevels;
		if (item.Level < headingsOutlineLevels)
		{
			class6589_0.method_0(item.Level, item.Title, navigationUrl);
		}
	}

	public void method_9()
	{
		class6730_0 = Class6652.Instance.method_0(class6588_0.ToolTipsFontName, FontStyle.Regular, "Arial");
		Class6586 subset = method_4(class6730_0);
		smethod_0(class6588_0.TopPaneToolTips, subset);
		smethod_0(class6588_0.LeftPaneToolTips, subset);
		smethod_0(class6588_0.BottomPaneToolTips, subset);
	}

	public short method_10()
	{
		return ++short_0;
	}

	public void method_11(bool isViewerIncluded)
	{
		if (isViewerIncluded)
		{
			Class6572 @class = new Class6572(this);
			@class.method_0(class6730_0);
			Class6569 class2 = new Class6569(this);
			class2.method_0();
			Writer.method_16(Enum878.const_1, 0);
		}
		for (int i = 0; i < list_0.Count; i++)
		{
			Class6579 class3 = list_0[i];
			class3.Write(i, isViewerIncluded);
		}
	}

	private static void smethod_0(Hashtable tips, Class6586 subset)
	{
		foreach (DictionaryEntry tip in tips)
		{
			subset.method_0((string)tip.Value);
		}
	}

	private string method_12(PointF origin)
	{
		return $"bookmark://internal?page={int_0}&x={Class5955.smethod_29(origin.X)}&y={Class5955.smethod_29(origin.Y)}";
	}
}
