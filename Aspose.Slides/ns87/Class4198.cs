using System.Text;
using ns73;

namespace ns87;

internal class Class4198 : Class4154
{
	public class Class4336
	{
		private string string_0;

		private int int_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		public bool IsIntValue => bool_3;

		public bool IsStringValue => bool_2;

		public bool IsEnd => bool_1;

		public bool IsStart => bool_0;

		public int IntValue => int_0;

		public string StringValue => string_0;

		private Class4336()
		{
		}

		internal Class4336(string value)
		{
			string_0 = value;
			bool_2 = true;
		}

		internal Class4336(int value)
		{
			int_0 = value;
			bool_3 = true;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsIntValue)
			{
				stringBuilder.Append(IntValue);
			}
			else if (IsStringValue)
			{
				stringBuilder.Append(StringValue);
			}
			else if (IsStart)
			{
				stringBuilder.Append("start");
			}
			else
			{
				stringBuilder.Append("end");
			}
			return stringBuilder.ToString();
		}

		internal static Class4336 smethod_0()
		{
			Class4336 @class = new Class4336();
			@class.bool_0 = true;
			return @class;
		}

		internal static Class4336 smethod_1()
		{
			Class4336 @class = new Class4336();
			@class.bool_1 = true;
			return @class;
		}
	}

	private Class4336 class4336_0;

	private Class4336 class4336_1;

	private bool bool_0;

	public bool IsAuto => bool_0;

	public Class4336 StartLine => class4336_0;

	public Class4336 EndLine => class4336_1;

	internal Class4198(Class3679 cssValue)
		: base(cssValue)
	{
		if (!base.IsListValue)
		{
			if (Class3700.Class3702.class3689_3 == cssValue)
			{
				bool_0 = true;
			}
			else
			{
				class4336_0 = method_3((Class3680)cssValue);
			}
		}
		else
		{
			Class3691 @class = cssValue as Class3691;
			class4336_0 = method_3((Class3680)@class[0]);
			class4336_1 = method_3((Class3680)@class[1]);
		}
	}

	internal Class4336 method_3(Class3680 value)
	{
		if (base.IsStringValue)
		{
			return new Class4336(method_0());
		}
		return new Class4336((int)method_1().vmethod_1(1));
	}
}
