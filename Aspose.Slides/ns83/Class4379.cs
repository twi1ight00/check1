using ns82;

namespace ns83;

internal class Class4379
{
	protected Class4378 class4378_0;

	protected int int_0;

	protected Class4380 class4380_0;

	protected Interface106 interface106_0;

	public Class4379(Class4378 tokenizer, Class4380 wizard, Interface106 adaptor)
	{
		class4378_0 = tokenizer;
		class4380_0 = wizard;
		interface106_0 = adaptor;
		int_0 = tokenizer.method_0();
	}

	public object method_0()
	{
		if (int_0 == 1)
		{
			return method_1();
		}
		if (int_0 == 3)
		{
			object result = method_2();
			if (int_0 == -1)
			{
				return result;
			}
			return null;
		}
		return null;
	}

	public object method_1()
	{
		if (int_0 != 1)
		{
			return null;
		}
		int_0 = class4378_0.method_0();
		object obj = method_2();
		if (obj == null)
		{
			return null;
		}
		while (true)
		{
			if (int_0 == 1 || int_0 == 3 || int_0 == 5 || int_0 == 7)
			{
				if (int_0 == 1)
				{
					object child = method_1();
					interface106_0.imethod_6(obj, child);
					continue;
				}
				object obj2 = method_2();
				if (obj2 == null)
				{
					break;
				}
				interface106_0.imethod_6(obj, obj2);
				continue;
			}
			if (int_0 != 2)
			{
				return null;
			}
			int_0 = class4378_0.method_0();
			return obj;
		}
		return null;
	}

	public object method_2()
	{
		string text = null;
		if (int_0 == 5)
		{
			int_0 = class4378_0.method_0();
			if (int_0 != 3)
			{
				return null;
			}
			text = class4378_0.stringBuilder_0.ToString();
			int_0 = class4378_0.method_0();
			if (int_0 != 6)
			{
				return null;
			}
			int_0 = class4378_0.method_0();
		}
		if (int_0 == 7)
		{
			int_0 = class4378_0.method_0();
			Interface86 payload = new Class4093(0, ".");
			Class4380.Class4365 @class = new Class4380.Class4366(payload);
			if (text != null)
			{
				@class.string_0 = text;
			}
			return @class;
		}
		if (int_0 != 3)
		{
			return null;
		}
		string text2 = class4378_0.stringBuilder_0.ToString();
		int_0 = class4378_0.method_0();
		if (text2.Equals("nil"))
		{
			return interface106_0.imethod_3();
		}
		string text3 = text2;
		string text4 = null;
		if (int_0 == 4)
		{
			text4 = class4378_0.stringBuilder_0.ToString();
			text3 = text4;
			int_0 = class4378_0.method_0();
		}
		int num = class4380_0.method_0(text2);
		if (num == 0)
		{
			return null;
		}
		object obj = interface106_0.imethod_13(num, text3);
		if (text != null && obj.GetType() == typeof(Class4380.Class4365))
		{
			((Class4380.Class4365)obj).string_0 = text;
		}
		if (text4 != null && obj.GetType() == typeof(Class4380.Class4365))
		{
			((Class4380.Class4365)obj).bool_0 = true;
		}
		return obj;
	}
}
