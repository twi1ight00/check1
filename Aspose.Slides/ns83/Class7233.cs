using ns82;

namespace ns83;

internal class Class7233
{
	protected Class7232 class7232_0;

	protected int int_0;

	protected Class7321 class7321_0;

	protected Interface387 interface387_0;

	public Class7233(Class7232 tokenizer, Class7321 wizard, Interface387 adaptor)
	{
		class7232_0 = tokenizer;
		class7321_0 = wizard;
		interface387_0 = adaptor;
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
		int_0 = class7232_0.method_0();
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
					interface387_0.imethod_6(obj, child);
					continue;
				}
				object obj2 = method_2();
				if (obj2 == null)
				{
					break;
				}
				interface387_0.imethod_6(obj, obj2);
				continue;
			}
			if (int_0 != 2)
			{
				return null;
			}
			int_0 = class7232_0.method_0();
			return obj;
		}
		return null;
	}

	public object method_2()
	{
		string text = null;
		if (int_0 == 5)
		{
			int_0 = class7232_0.method_0();
			if (int_0 != 3)
			{
				return null;
			}
			text = class7232_0.stringBuilder_0.ToString();
			int_0 = class7232_0.method_0();
			if (int_0 != 6)
			{
				return null;
			}
			int_0 = class7232_0.method_0();
		}
		if (int_0 == 7)
		{
			int_0 = class7232_0.method_0();
			Interface392 payload = new Class7335(0, ".");
			Class7321.Class7213 @class = new Class7321.Class7214(payload);
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
		string text2 = class7232_0.stringBuilder_0.ToString();
		int_0 = class7232_0.method_0();
		if (text2.Equals("nil"))
		{
			return interface387_0.imethod_3();
		}
		string text3 = text2;
		string text4 = null;
		if (int_0 == 4)
		{
			text4 = class7232_0.stringBuilder_0.ToString();
			text3 = text4;
			int_0 = class7232_0.method_0();
		}
		int num = class7321_0.method_0(text2);
		if (num == 0)
		{
			return null;
		}
		object obj = interface387_0.imethod_13(num, text3);
		if (text != null && obj.GetType() == typeof(Class7321.Class7213))
		{
			((Class7321.Class7213)obj).string_0 = text;
		}
		if (text4 != null && obj.GetType() == typeof(Class7321.Class7213))
		{
			((Class7321.Class7213)obj).bool_0 = true;
		}
		return obj;
	}
}
