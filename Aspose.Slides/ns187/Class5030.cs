using System.Collections;
using ns171;
using ns195;

namespace ns187;

internal class Class5030 : Class5027
{
	internal class Class5080 : Class5052
	{
		public Class5080(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
		{
			if ("inherit".Equals(value))
			{
				return base.vmethod_8(propertyList, value, fo);
			}
			Class5030 @class = new Class5030();
			if (object.ReferenceEquals(string_0, value) && !string.IsNullOrEmpty(fo.method_2().DefaultFontName))
			{
				@class.vmethod_14(Class5050.smethod_0(fo.method_2().DefaultFontName));
			}
			int num = 0;
			int num2 = value.IndexOf(',');
			bool flag = false;
			while (!flag)
			{
				string text;
				if (num2 == -1)
				{
					text = value.Substring(num).Trim();
					flag = true;
				}
				else
				{
					text = Class5479.smethod_0(value, num, num2).Trim();
					num = num2 + 1;
					num2 = value.IndexOf(',', num);
				}
				int num3 = text.IndexOf('\'');
				int num4 = text.IndexOf('"');
				if (num3 != -1 || num4 != -1)
				{
					char value2 = ((num3 == -1) ? '"' : '\'');
					text = ((text.Length < 3 || text.LastIndexOf(value2) != text.Length - 1) ? string.Empty : Class5479.smethod_0(text, 1, text.Length - 1));
				}
				if (!string.IsNullOrEmpty(text))
				{
					for (int num5 = text.IndexOf("  "); num5 != -1; num5 = text.IndexOf("  "))
					{
						text = Class5479.smethod_0(text, 0, num5) + text.Substring(num5 + 1);
					}
					@class.vmethod_14(Class5050.smethod_0(text));
				}
			}
			return (Class5030)class5749_0.method_0(@class);
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5030)
			{
				return p;
			}
			return new Class5030(p);
		}
	}

	private static Class5749 class5749_0 = new Class5749();

	private int int_0;

	private Class5030(Class5024 prop)
	{
		vmethod_14(prop);
	}

	private Class5030()
	{
	}

	public override void vmethod_14(Class5024 prop)
	{
		if (prop.vmethod_8() != null)
		{
			ArrayList arrayList = prop.vmethod_8();
			{
				foreach (Class5024 item in arrayList)
				{
					arrayList_0.Add(item);
				}
				return;
			}
		}
		base.vmethod_14(prop);
	}

	public override string vmethod_13()
	{
		if (arrayList_0.Count > 0)
		{
			Class5024 @class = (Class5024)arrayList_0[0];
			return @class.vmethod_13();
		}
		return base.vmethod_13();
	}

	public override bool Equals(object o)
	{
		if (this == o)
		{
			return true;
		}
		if (o is Class5030 @class)
		{
			if (arrayList_0 != null)
			{
				return arrayList_0.Equals(@class.arrayList_0);
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (int_0 == 0)
		{
			int num = 17;
			foreach (Class5024 item in arrayList_0)
			{
				num = 37 * num + (item?.GetHashCode() ?? 0);
			}
			int_0 = num;
		}
		return int_0;
	}
}
