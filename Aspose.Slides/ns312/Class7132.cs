using System;
using System.Collections;
using System.Drawing.Drawing2D;
using ns315;

namespace ns312;

internal class Class7132
{
	public Class7132 class7132_0;

	public int int_0;

	public Hashtable hashtable_0 = new Hashtable();

	public Hashtable hashtable_1 = new Hashtable();

	public Hashtable hashtable_2 = new Hashtable();

	internal Hashtable hashtable_3 = new Hashtable();

	public Hashtable hashtable_4 = new Hashtable();

	public string string_0 = string.Empty;

	public string string_1 = string.Empty;

	internal ArrayList arrayList_0 = new ArrayList();

	internal ArrayList arrayList_1 = new ArrayList();

	internal ArrayList arrayList_2 = new ArrayList();

	internal ArrayList arrayList_3 = new ArrayList();

	internal ArrayList arrayList_4 = new ArrayList();

	internal ArrayList arrayList_5 = new ArrayList();

	private Enum976 enum976_0;

	private GraphicsPath graphicsPath_0;

	public int int_1 = -1;

	internal ArrayList arrayList_6 = new ArrayList();

	internal ArrayList arrayList_7 = new ArrayList();

	internal ArrayList arrayList_8 = new ArrayList();

	internal ArrayList arrayList_9 = new ArrayList();

	internal ArrayList arrayList_10 = new ArrayList();

	internal ArrayList arrayList_11 = new ArrayList();

	internal Hashtable hashtable_5 = new Hashtable();

	public virtual Class7132 Parent => class7132_0;

	public virtual Enum976 ClipRule => enum976_0;

	public virtual GraphicsPath Path => graphicsPath_0;

	public Class7132(string nodeName, Hashtable properties, Class7132 svgParent)
	{
		string_0 = nodeName;
		class7132_0 = svgParent;
		hashtable_0 = properties;
		method_0();
	}

	public Class7132(string nodeName, Hashtable properties, Class7132 svgParent, int seqNumber)
	{
		string_0 = nodeName;
		class7132_0 = svgParent;
		hashtable_0 = properties;
		int_0 = seqNumber;
		method_0();
	}

	public Class7132()
	{
		method_0();
	}

	private void method_0()
	{
		hashtable_1.Add("stroke-width", "-1");
	}

	public void method_1()
	{
		bool flag = false;
		Hashtable hashtable = smethod_0(this);
		if ((hashtable_0.ContainsKey("stroke") || hashtable.ContainsKey("stroke")) && !hashtable_0.ContainsKey("stroke-width") && !hashtable.ContainsKey("stroke-width"))
		{
			hashtable_0.Add("stroke-width", "1");
		}
		foreach (DictionaryEntry item in hashtable_1)
		{
			flag = false;
			if (hashtable_0.ContainsKey(item.Key))
			{
				flag = true;
			}
			else if (hashtable_0.ContainsKey("style") && hashtable.ContainsKey(item.Key))
			{
				flag = true;
			}
			if (!flag)
			{
				hashtable_0.Add(item.Key, item.Value);
			}
		}
	}

	private static Hashtable smethod_0(Class7132 node)
	{
		Hashtable hashtable = new Hashtable();
		if (!node.hashtable_0.ContainsKey("style"))
		{
			return hashtable;
		}
		string[] array = node.hashtable_0["style"].ToString().Split(new string[1] { ";" }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string text in array2)
		{
			string[] array3 = text.Split(new string[1] { ":" }, StringSplitOptions.RemoveEmptyEntries);
			if (array3.Length >= 2)
			{
				hashtable.Add(array3[0].Trim(), array3[1].Trim());
			}
		}
		return hashtable;
	}

	public virtual bool vmethod_0()
	{
		return hashtable_4.Count > 0;
	}

	public virtual object Clone()
	{
		Class7132 @class = new Class7132();
		foreach (DictionaryEntry item in hashtable_0)
		{
			if (!@class.hashtable_0.ContainsKey(item.Key))
			{
				@class.hashtable_0.Add(item.Key, item.Value);
			}
		}
		foreach (DictionaryEntry item2 in hashtable_1)
		{
			if (!@class.hashtable_1.ContainsKey(item2.Key))
			{
				@class.hashtable_1.Add(item2.Key, item2.Value);
			}
		}
		foreach (DictionaryEntry item3 in hashtable_2)
		{
			if (!@class.hashtable_2.ContainsKey(item3.Key))
			{
				@class.hashtable_2.Add(item3.Key, item3.Value);
			}
		}
		foreach (DictionaryEntry item4 in hashtable_3)
		{
			if (!@class.hashtable_3.ContainsKey(item4.Key))
			{
				@class.hashtable_3.Add(item4.Key, item4.Value);
			}
		}
		@class.string_0 = string_0;
		@class.string_1 = string_1;
		@class.class7132_0 = class7132_0;
		@class.int_0 = int_0;
		foreach (DictionaryEntry item5 in hashtable_4)
		{
			@class.hashtable_4.Add(@class.hashtable_4.Count, ((Class7132)item5.Value).Clone());
		}
		return @class;
	}
}
