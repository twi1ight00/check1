using System;
using System.Collections;
using System.Text;

namespace ns82;

internal class Class4395 : Class4394
{
	private class Class4399 : IComparer
	{
		public virtual int Compare(object o1, object o2)
		{
			Class4400 @class = (Class4400)o1;
			Class4400 class2 = (Class4400)o2;
			if (@class.int_1 < class2.int_1)
			{
				return -1;
			}
			if (@class.int_1 > class2.int_1)
			{
				return 1;
			}
			return 0;
		}
	}

	protected internal class Class4400
	{
		protected internal int int_0;

		protected internal int int_1;

		protected internal object object_0;

		protected internal Class4395 class4395_0;

		protected internal Class4400(int index, object text, Class4395 parent)
		{
			int_1 = index;
			object_0 = text;
			class4395_0 = parent;
		}

		public virtual int vmethod_0(StringBuilder buf)
		{
			return int_1;
		}

		public override string ToString()
		{
			string fullName = GetType().FullName;
			int num = fullName.IndexOf('$');
			fullName = fullName.Substring(num + 1, fullName.Length - (num + 1));
			return string.Concat("<", fullName, "@", int_1, ":\"", object_0, "\">");
		}
	}

	protected internal class Class4401 : Class4400
	{
		public Class4401(int index, object text, Class4395 parent)
			: base(index, text, parent)
		{
		}

		public override int vmethod_0(StringBuilder buf)
		{
			buf.Append(object_0);
			buf.Append(class4395_0.imethod_9(int_1).Text);
			return int_1 + 1;
		}
	}

	protected internal class Class4402 : Class4400
	{
		protected internal int int_2;

		public Class4402(int from, int to, object text, Class4395 parent)
			: base(from, text, parent)
		{
			int_2 = to;
		}

		public override int vmethod_0(StringBuilder buf)
		{
			if (object_0 != null)
			{
				buf.Append(object_0);
			}
			return int_2 + 1;
		}

		public override string ToString()
		{
			return string.Concat("<ReplaceOp@", int_1, "..", int_2, ":\"", object_0, "\">");
		}
	}

	protected internal class Class4403 : Class4402
	{
		public Class4403(int from, int to, Class4395 parent)
			: base(from, to, null, parent)
		{
		}

		public override string ToString()
		{
			return "<DeleteOp@" + int_1 + ".." + int_2 + ">";
		}
	}

	public const string string_0 = "default";

	public const int int_3 = 100;

	public const int int_4 = 0;

	protected IDictionary idictionary_1;

	protected IDictionary idictionary_2;

	public Class4395()
	{
		vmethod_12();
	}

	public Class4395(Interface85 tokenSource)
		: base(tokenSource)
	{
		vmethod_12();
	}

	public Class4395(Interface85 tokenSource, int channel)
		: base(tokenSource, channel)
	{
		vmethod_12();
	}

	protected internal virtual void vmethod_12()
	{
		idictionary_1 = new Hashtable();
		idictionary_1["default"] = new ArrayList(100);
		idictionary_2 = new Hashtable();
	}

	public virtual void vmethod_13(int instructionIndex)
	{
		vmethod_14("default", instructionIndex);
	}

	public virtual void vmethod_14(string programName, int instructionIndex)
	{
		IList list = (IList)idictionary_1[programName];
		if (list != null)
		{
			idictionary_1[programName] = ((ArrayList)list).GetRange(0, instructionIndex);
		}
	}

	public virtual void vmethod_15()
	{
		vmethod_16("default");
	}

	public virtual void vmethod_16(string programName)
	{
		vmethod_14(programName, 0);
	}

	public virtual void vmethod_17(Interface86 t, object text)
	{
		vmethod_19("default", t, text);
	}

	public virtual void vmethod_18(int index, object text)
	{
		vmethod_20("default", index, text);
	}

	public virtual void vmethod_19(string programName, Interface86 t, object text)
	{
		vmethod_20(programName, t.TokenIndex, text);
	}

	public virtual void vmethod_20(string programName, int index, object text)
	{
		vmethod_24(programName, index + 1, text);
	}

	public virtual void vmethod_21(Interface86 t, object text)
	{
		vmethod_23("default", t, text);
	}

	public virtual void vmethod_22(int index, object text)
	{
		vmethod_24("default", index, text);
	}

	public virtual void vmethod_23(string programName, Interface86 t, object text)
	{
		vmethod_24(programName, t.TokenIndex, text);
	}

	public virtual void vmethod_24(string programName, int index, object text)
	{
		Class4400 value = new Class4401(index, text, this);
		IList list = vmethod_40(programName);
		list.Add(value);
	}

	public virtual void vmethod_25(int index, object text)
	{
		vmethod_29("default", index, index, text);
	}

	public virtual void vmethod_26(int from, int to, object text)
	{
		vmethod_29("default", from, to, text);
	}

	public virtual void vmethod_27(Interface86 indexT, object text)
	{
		vmethod_30("default", indexT, indexT, text);
	}

	public virtual void vmethod_28(Interface86 from, Interface86 to, object text)
	{
		vmethod_30("default", from, to, text);
	}

	public virtual void vmethod_29(string programName, int from, int to, object text)
	{
		if (from > to || from < 0 || to < 0 || to >= ilist_0.Count)
		{
			throw new ArgumentOutOfRangeException("replace: range invalid: " + from + ".." + to + "(size=" + ilist_0.Count + ")");
		}
		Class4400 @class = new Class4402(from, to, text, this);
		IList list = vmethod_40(programName);
		@class.int_0 = list.Count;
		list.Add(@class);
	}

	public virtual void vmethod_30(string programName, Interface86 from, Interface86 to, object text)
	{
		vmethod_29(programName, from.TokenIndex, to.TokenIndex, text);
	}

	public virtual void vmethod_31(int index)
	{
		vmethod_35("default", index, index);
	}

	public virtual void vmethod_32(int from, int to)
	{
		vmethod_35("default", from, to);
	}

	public virtual void vmethod_33(Interface86 indexT)
	{
		vmethod_36("default", indexT, indexT);
	}

	public virtual void vmethod_34(Interface86 from, Interface86 to)
	{
		vmethod_36("default", from, to);
	}

	public virtual void vmethod_35(string programName, int from, int to)
	{
		vmethod_29(programName, from, to, null);
	}

	public virtual void vmethod_36(string programName, Interface86 from, Interface86 to)
	{
		vmethod_30(programName, from, to, null);
	}

	public virtual int vmethod_37()
	{
		return vmethod_38("default");
	}

	protected virtual int vmethod_38(string programName)
	{
		object obj = idictionary_2[programName];
		if (obj == null)
		{
			return -1;
		}
		return (int)obj;
	}

	protected virtual void vmethod_39(string programName, int i)
	{
		idictionary_2[programName] = i;
	}

	protected virtual IList vmethod_40(string name)
	{
		IList list = (IList)idictionary_1[name];
		if (list == null)
		{
			list = method_0(name);
		}
		return list;
	}

	private IList method_0(string name)
	{
		IList list = new ArrayList(100);
		idictionary_1[name] = list;
		return list;
	}

	public virtual string vmethod_41()
	{
		return vmethod_42(0, imethod_7() - 1);
	}

	public virtual string vmethod_42(int start, int end)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = start; i >= 0 && i <= end && i < ilist_0.Count; i++)
		{
			stringBuilder.Append(imethod_9(i).Text);
		}
		return stringBuilder.ToString();
	}

	public override string ToString()
	{
		return ToString(0, imethod_7() - 1);
	}

	public virtual string ToString(string programName)
	{
		return ToString(programName, 0, imethod_7() - 1);
	}

	public override string ToString(int start, int end)
	{
		return ToString("default", start, end);
	}

	public virtual string ToString(string programName, int start, int end)
	{
		IList list = (IList)idictionary_1[programName];
		if (end > ilist_0.Count - 1)
		{
			end = ilist_0.Count - 1;
		}
		if (start < 0)
		{
			start = 0;
		}
		if (list != null && list.Count != 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			IDictionary dictionary = method_1(list);
			int num = start;
			while (num <= end && num < ilist_0.Count)
			{
				Class4400 @class = (Class4400)dictionary[num];
				dictionary.Remove(num);
				Interface86 @interface = (Interface86)ilist_0[num];
				if (@class == null)
				{
					stringBuilder.Append(@interface.Text);
					num++;
				}
				else
				{
					num = @class.vmethod_0(stringBuilder);
				}
			}
			if (end == ilist_0.Count - 1)
			{
				IEnumerator enumerator = dictionary.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Class4401 class2 = (Class4401)enumerator.Current;
					if (class2.int_1 >= ilist_0.Count - 1)
					{
						stringBuilder.Append(class2.object_0);
					}
				}
			}
			return stringBuilder.ToString();
		}
		return vmethod_42(start, end);
	}

	protected IDictionary method_1(IList rewrites)
	{
		for (int i = 0; i < rewrites.Count; i++)
		{
			Class4400 @class = (Class4400)rewrites[i];
			if (@class == null || !(@class is Class4402))
			{
				continue;
			}
			Class4402 class2 = (Class4402)rewrites[i];
			IList list = smethod_1(rewrites, typeof(Class4401), i);
			for (int j = 0; j < list.Count; j++)
			{
				Class4401 class3 = (Class4401)list[j];
				if (class3.int_1 >= class2.int_1 && class3.int_1 <= class2.int_2)
				{
					rewrites[class3.int_0] = null;
				}
			}
			IList list2 = smethod_1(rewrites, typeof(Class4402), i);
			for (int k = 0; k < list2.Count; k++)
			{
				Class4402 class4 = (Class4402)list2[k];
				if (class4.int_1 >= class2.int_1 && class4.int_2 <= class2.int_2)
				{
					rewrites[class4.int_0] = null;
					continue;
				}
				bool flag = class4.int_2 < class2.int_1 || class4.int_1 > class2.int_2;
				bool flag2 = class4.int_1 == class2.int_1 && class4.int_2 == class2.int_2;
				if (!flag && !flag2)
				{
					throw new ArgumentOutOfRangeException(string.Concat("replace op boundaries of ", class2, " overlap with previous ", class4));
				}
			}
		}
		for (int l = 0; l < rewrites.Count; l++)
		{
			Class4400 class5 = (Class4400)rewrites[l];
			if (class5 == null || !(class5 is Class4401))
			{
				continue;
			}
			Class4401 class6 = (Class4401)rewrites[l];
			IList list3 = smethod_1(rewrites, typeof(Class4401), l);
			for (int m = 0; m < list3.Count; m++)
			{
				Class4401 class7 = (Class4401)list3[m];
				if (class7.int_1 == class6.int_1)
				{
					class6.object_0 = smethod_0(class6.object_0, class7.object_0);
					rewrites[class7.int_0] = null;
				}
			}
			IList list4 = smethod_1(rewrites, typeof(Class4402), l);
			for (int n = 0; n < list4.Count; n++)
			{
				Class4402 class8 = (Class4402)list4[n];
				if (class6.int_1 == class8.int_1)
				{
					class8.object_0 = smethod_0(class6.object_0, class8.object_0);
					rewrites[l] = null;
				}
				else if (class6.int_1 >= class8.int_1 && class6.int_1 <= class8.int_2)
				{
					throw new ArgumentOutOfRangeException(string.Concat("insert op ", class6, " within boundaries of previous ", class8));
				}
			}
		}
		IDictionary dictionary = new Hashtable();
		for (int num = 0; num < rewrites.Count; num++)
		{
			Class4400 class9 = (Class4400)rewrites[num];
			if (class9 != null)
			{
				if (dictionary[class9.int_1] != null)
				{
					throw new Exception("should only be one op per index");
				}
				dictionary[class9.int_1] = class9;
			}
		}
		return dictionary;
	}

	protected static string smethod_0(object a, object b)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		if (a != null)
		{
			text = a.ToString();
		}
		if (b != null)
		{
			text2 = b.ToString();
		}
		return text + text2;
	}

	protected IList method_2(IList rewrites, Type kind)
	{
		return smethod_1(rewrites, kind, rewrites.Count);
	}

	protected static IList smethod_1(IList rewrites, Type kind, int before)
	{
		IList list = new ArrayList();
		for (int i = 0; i < before && i < rewrites.Count; i++)
		{
			Class4400 @class = (Class4400)rewrites[i];
			if (@class != null && @class.GetType() == kind)
			{
				list.Add(@class);
			}
		}
		return list;
	}

	public virtual string vmethod_43()
	{
		return vmethod_44(0, imethod_7() - 1);
	}

	public virtual string vmethod_44(int start, int end)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = start; i >= 0 && i <= end && i < ilist_0.Count; i++)
		{
			stringBuilder.Append(imethod_9(i));
		}
		return stringBuilder.ToString();
	}
}
