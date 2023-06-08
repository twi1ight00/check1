using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using ns171;
using ns189;
using ns190;
using ns205;

namespace ns173;

internal class Class4974 : Class4941, Interface160
{
	private Class4973 class4973_0;

	private RectangleF rectangleF_0;

	private string string_0;

	private string string_1;

	private int int_0 = -1;

	private string string_2;

	private int int_1 = -1;

	private bool bool_0;

	private Class4975 class4975_0;

	private ArrayList arrayList_1 = new ArrayList();

	private Hashtable hashtable_1 = new Hashtable();

	private Hashtable hashtable_2;

	private Hashtable hashtable_3;

	private Hashtable hashtable_4;

	private Hashtable hashtable_5;

	private Hashtable hashtable_6;

	private Hashtable hashtable_7;

	public Class4974()
	{
	}

	public Class4974(Class5171 spm, int pageNumber, string pageStr, bool blank, bool spanAll)
	{
		string_0 = spm.method_55();
		method_6(spm.method_44());
		method_1(spm.method_47());
		bool_0 = blank;
		int num = spm.method_56().imethod_5();
		int num2 = spm.method_57().imethod_5();
		int_0 = pageNumber;
		string_2 = pageStr;
		rectangleF_0 = new RectangleF(0f, 0f, num, num2);
		class4973_0 = new Class4973(spm);
		method_33(spanAll);
	}

	public Class4974(Class5171 spm, int pageNumber, string pageStr, bool blank)
		: this(spm, pageNumber, pageStr, blank, spanAll: false)
	{
	}

	public Class4974(Class4974 original)
	{
		if (original.arrayList_0 != null)
		{
			method_6(original.arrayList_0);
		}
		if (original.hashtable_0 != null)
		{
			method_1(original.hashtable_0);
		}
		int_1 = original.int_1;
		int_0 = original.int_0;
		string_2 = original.string_2;
		class4973_0 = (Class4973)original.class4973_0.method_13();
		rectangleF_0 = original.rectangleF_0;
		string_0 = original.string_0;
		bool_0 = original.bool_0;
	}

	public Class4974(RectangleF viewArea, int pageNumber, string pageStr, string simplePageMasterName, bool blank)
	{
		rectangleF_0 = viewArea;
		int_0 = pageNumber;
		string_2 = pageStr;
		string_0 = simplePageMasterName;
		bool_0 = blank;
	}

	public void method_9(Class4975 seq)
	{
		class4975_0 = seq;
	}

	public Class4975 method_10()
	{
		return class4975_0;
	}

	public RectangleF method_11()
	{
		return rectangleF_0;
	}

	public Class4973 method_12()
	{
		return class4973_0;
	}

	public void method_13(Class4973 page)
	{
		class4973_0 = page;
	}

	public int method_14()
	{
		return int_0;
	}

	public string method_15()
	{
		return string_2;
	}

	public void method_16(int index)
	{
		int_1 = index;
	}

	public int method_17()
	{
		return int_1;
	}

	public void method_18(string key)
	{
		string_1 = key;
	}

	public string method_19()
	{
		if (string_1 == null)
		{
			throw new Exception("No page key set on the PageViewport: " + ToString());
		}
		return string_1;
	}

	public void method_20(string id)
	{
		if (id != null)
		{
			arrayList_1.Add(id);
		}
	}

	public bool method_21(string id)
	{
		return arrayList_1.Contains(id);
	}

	public void method_22(string idref, Interface160 res)
	{
		if (hashtable_1 == null)
		{
			hashtable_1 = new Hashtable();
		}
		ArrayList arrayList = (ArrayList)hashtable_1[idref];
		if (arrayList == null)
		{
			arrayList = new ArrayList();
			hashtable_1.Add(idref, arrayList);
		}
		arrayList.Add(res);
	}

	public bool imethod_2()
	{
		if (hashtable_1 != null)
		{
			return hashtable_1.Count == 0;
		}
		return true;
	}

	public string[] imethod_3()
	{
		if (hashtable_1 == null)
		{
			return null;
		}
		string[] array = new string[hashtable_1.Keys.Count];
		int num = 0;
		foreach (string key in hashtable_1.Keys)
		{
			array[num] = key;
			num++;
		}
		return array;
	}

	public void imethod_4(string id, ArrayList pages)
	{
		if (class4973_0 == null)
		{
			if (hashtable_2 == null)
			{
				hashtable_2 = new Hashtable();
			}
			hashtable_2.Add(id, pages);
		}
		else if (hashtable_1 != null)
		{
			ArrayList arrayList = (ArrayList)hashtable_1[id];
			if (arrayList != null)
			{
				foreach (Interface160 item in arrayList)
				{
					item.imethod_4(id, pages);
				}
			}
		}
		if (hashtable_1 != null && pages != null)
		{
			hashtable_1.Remove(id);
			if (hashtable_1.Count == 0)
			{
				hashtable_1 = null;
			}
		}
	}

	public void method_23(Hashtable marks, bool starting, bool isfirst, bool islast)
	{
		if (marks == null)
		{
			return;
		}
		if (starting)
		{
			if (isfirst)
			{
				if (hashtable_3 == null)
				{
					hashtable_3 = new Hashtable();
				}
				if (hashtable_5 == null)
				{
					hashtable_5 = new Hashtable();
				}
				foreach (string key3 in marks.Keys)
				{
					if (!hashtable_3.ContainsKey(key3))
					{
						hashtable_3.Add(key3, marks[key3]);
					}
					if (!hashtable_5.ContainsKey(key3))
					{
						hashtable_5.Add(key3, marks[key3]);
					}
				}
				if (hashtable_4 == null)
				{
					hashtable_4 = new Hashtable();
				}
				{
					foreach (DictionaryEntry mark in marks)
					{
						hashtable_4.Add(mark.Key, mark.Value);
					}
					return;
				}
			}
			if (hashtable_5 == null)
			{
				hashtable_5 = new Hashtable();
			}
			{
				foreach (string key4 in marks.Keys)
				{
					if (!hashtable_5.ContainsKey(key4))
					{
						hashtable_5.Add(key4, marks[key4]);
					}
				}
				return;
			}
		}
		if (islast)
		{
			if (hashtable_6 == null)
			{
				hashtable_6 = new Hashtable();
			}
			foreach (DictionaryEntry mark2 in marks)
			{
				hashtable_6.Add(mark2.Key, mark2.Value);
			}
		}
		if (hashtable_7 == null)
		{
			hashtable_7 = new Hashtable();
		}
		foreach (DictionaryEntry mark3 in marks)
		{
			hashtable_7.Add(mark3.Key, mark3.Value);
		}
	}

	public Class5108 method_24(string name, int pos)
	{
		Class5108 @class = null;
		string text = null;
		switch ((Enum679)pos)
		{
		case Enum679.const_55:
			if (hashtable_3 != null)
			{
				@class = (Class5108)hashtable_3[name];
				text = "FSWP";
			}
			if (@class == null && hashtable_5 != null)
			{
				@class = (Class5108)hashtable_5[name];
				text = "FirstAny after " + text;
			}
			break;
		case Enum679.const_50:
			if (hashtable_5 != null)
			{
				@class = (Class5108)hashtable_5[name];
				text = "FIC";
			}
			break;
		case Enum679.const_82:
			if (hashtable_4 != null)
			{
				@class = (Class5108)hashtable_4[name];
				text = "LSWP";
			}
			if (@class == null && hashtable_7 != null)
			{
				@class = (Class5108)hashtable_7[name];
				text = "LastAny after " + text;
			}
			break;
		case Enum679.const_75:
			if (hashtable_6 != null)
			{
				@class = (Class5108)hashtable_6[name];
				text = "LEWP";
			}
			if (@class == null && hashtable_7 != null)
			{
				@class = (Class5108)hashtable_7[name];
				text = "LastAny after " + text;
			}
			break;
		}
		return @class;
	}

	public void method_25()
	{
	}

	public void method_26(Stream @out)
	{
		throw new NotImplementedException();
	}

	public void method_27(Stream @in)
	{
		throw new NotImplementedException();
	}

	public object method_28()
	{
		Class4974 @class = (Class4974)base.vmethod_0(new Class4974());
		@class.class4973_0 = (Class4973)class4973_0.method_13();
		@class.rectangleF_0 = rectangleF_0;
		return @class;
	}

	public void method_29()
	{
		class4973_0 = null;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("PageViewport: page=");
		stringBuilder.Append(method_15());
		return stringBuilder.ToString();
	}

	public string method_30()
	{
		return string_0;
	}

	public bool method_31()
	{
		return bool_0;
	}

	public Class4965 method_32()
	{
		return (Class4965)method_12().method_11(58).method_38();
	}

	public Class4967 method_33(bool spanAll)
	{
		return method_32().method_47().method_37(spanAll);
	}

	public Class4967 method_34()
	{
		return method_32().method_47().method_40();
	}

	public Class4961 method_35()
	{
		return method_34().method_42();
	}

	public Class4961 method_36()
	{
		return method_34().method_44();
	}

	public Class4964 method_37(int id)
	{
		return method_12().method_11(id).method_38();
	}

	public void method_38(Interface231 wmtg)
	{
		if (class4973_0 != null)
		{
			class4973_0.method_16(wmtg);
		}
	}
}
