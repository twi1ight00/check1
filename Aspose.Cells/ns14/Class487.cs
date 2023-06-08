using System;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;
using ns22;

namespace ns14;

internal abstract class Class487 : Interface3
{
	protected Class509 class509_0;

	protected Class518 class518_0 = new Class518();

	internal Class487(Class509 class509_1, string string_0)
	{
		class509_0 = class509_1;
		if (string_0 == null)
		{
			string_0 = class509_1.Pattern;
		}
		char[] array = string_0.ToCharArray();
		vmethod_0(array, 0, array.Length);
	}

	[SpecialName]
	public abstract Enum136 imethod_0();

	protected abstract void vmethod_0(char[] char_0, int int_0, int int_1);

	public virtual Class518 Format(Class515 class515_0, object object_0)
	{
		return Format(class515_0, Type.GetTypeCode(object_0.GetType()), object_0);
	}

	public virtual Class518 Format(Class515 class515_0, TypeCode typeCode_0, object object_0)
	{
		class518_0.Reset();
		if (typeCode_0 == TypeCode.String && Class428.smethod_0((string)object_0))
		{
			class518_0.method_0(Enum136.const_1, object_0.ToString());
			return class518_0;
		}
		if (!Class1178.smethod_0(class509_0.Color))
		{
			class518_0.SetColor(class509_0.Color);
		}
		return class518_0;
	}

	protected void method_0(object object_0, TypeCode typeCode_0, Class518 class518_1)
	{
		if (typeCode_0 == TypeCode.Boolean)
		{
			class518_1.method_0(Enum136.const_1, ((bool)object_0) ? "TRUE" : "FALSE");
		}
		else
		{
			class518_1.method_0(Enum136.const_1, object_0.ToString());
		}
	}

	protected DateTime ToDateTime(double double_0)
	{
		return Class428.GetDateTimeFromDouble(double_0, class509_0.method_0().Date1904);
	}

	protected double ToDouble(DateTime dateTime_0)
	{
		return Class428.GetDoubleFromDateTime(dateTime_0, class509_0.method_0().Date1904);
	}

	protected void method_1(Class518 class518_1, Class518 class518_2, int int_0)
	{
		int num = class518_2.method_9();
		if (num > 0)
		{
			int num2 = class518_1.method_9();
			int[] array = new int[num2 + num];
			if (num2 > 0)
			{
				Array.Copy(class518_1.method_8(), array, num2);
			}
			class518_1.method_7(array);
			Array.Copy(class518_2.method_8(), 0, array, num2, num);
			for (int i = 0; i < num; i++)
			{
				class518_1.method_12(num2 + i, int_0 + class518_2.method_11(i));
			}
		}
	}

	protected virtual int vmethod_1(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		switch (char_0[int_0])
		{
		default:
			Class1180.smethod_5(stringBuilder_0, char_0[int_0]);
			int_0++;
			break;
		case '[':
			int_0 = class509_0.method_3(char_0, int_0, int_1, stringBuilder_0, bool_0: true);
			break;
		case '\\':
			int_0++;
			if (int_0 < int_1)
			{
				Class1180.smethod_5(stringBuilder_0, char_0[int_0]);
				int_0++;
			}
			break;
		case '"':
		{
			int_0++;
			int int_2 = int_0;
			while (int_0 < int_1)
			{
				if (char_0[int_0] != '"')
				{
					int_0++;
					continue;
				}
				Class1180.smethod_6(stringBuilder_0, char_0, int_2, int_0);
				return int_0 + 1;
			}
			Class1180.smethod_6(stringBuilder_0, char_0, int_2, int_0);
			break;
		}
		}
		return int_0;
	}

	protected virtual int vmethod_2(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		return smethod_0(char_0, int_0, int_1, stringBuilder_0);
	}

	internal static int smethod_0(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		switch (char_0[int_0])
		{
		case '[':
			stringBuilder_0.Append('[');
			int_0++;
			while (int_0 < int_1)
			{
				stringBuilder_0.Append(char_0[int_0]);
				if (char_0[int_0] != ']')
				{
					int_0++;
					continue;
				}
				int_0++;
				break;
			}
			break;
		case '\\':
			stringBuilder_0.Append('\\');
			int_0++;
			if (int_0 < int_1)
			{
				stringBuilder_0.Append(char_0[int_0]);
				int_0++;
			}
			break;
		default:
			stringBuilder_0.Append(char_0[int_0]);
			int_0++;
			break;
		case '*':
		case '_':
			stringBuilder_0.Append(char_0[int_0]);
			int_0++;
			if (int_0 < int_1)
			{
				stringBuilder_0.Append(char_0[int_0]);
				int_0++;
			}
			break;
		case '"':
			stringBuilder_0.Append('"');
			int_0++;
			while (int_0 < int_1)
			{
				stringBuilder_0.Append(char_0[int_0]);
				if (char_0[int_0] != '"')
				{
					int_0++;
					continue;
				}
				int_0++;
				break;
			}
			break;
		}
		return int_0;
	}

	internal static int smethod_1(char[] char_0, int int_0, int int_1)
	{
		switch (char_0[int_0])
		{
		case '[':
			do
			{
				int_0++;
			}
			while (int_0 < int_1 && char_0[int_0] != ']');
			int_0++;
			break;
		default:
			int_0++;
			break;
		case '*':
		case '\\':
		case '_':
			int_0++;
			if (int_0 < int_1)
			{
				int_0++;
			}
			break;
		case '"':
			do
			{
				int_0++;
			}
			while (int_0 < int_1 && char_0[int_0] != '"');
			int_0++;
			break;
		}
		return int_0;
	}

	internal static bool smethod_2(char[] char_0, int int_0, int int_1, char char_1, char char_2)
	{
		bool result = false;
		while (int_0 < int_1)
		{
			switch (char_0[int_0])
			{
			case '"':
				do
				{
					int_0++;
				}
				while (int_0 < int_1 && char_0[int_0] != '"');
				int_0++;
				continue;
			case '*':
			case '\\':
			case '_':
				int_0++;
				if (int_0 < int_1)
				{
					int_0++;
				}
				continue;
			}
			if (char_0[int_0] == char_1)
			{
				result = true;
				char_0[int_0] = char_2;
			}
			int_0++;
		}
		return result;
	}
}
