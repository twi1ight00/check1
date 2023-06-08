using System;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;

namespace ns14;

internal abstract class Class496 : Class495
{
	private string string_0;

	private string string_1;

	internal Class496(Class509 class509_1, string string_2, string string_3)
		: base(class509_1, "")
	{
		string_0 = string_2;
		string_1 = string_3;
	}

	protected abstract void vmethod_5(Class515 class515_0, DateTime dateTime_0, double double_0, StringBuilder stringBuilder_0);

	internal override Class518 Format(Class515 class515_0, DateTime dateTime_0, double double_0, bool bool_0)
	{
		Class518 @class = base.Format(class515_0, dateTime_0, double_0, bool_0: false);
		if (@class.method_5() != Enum136.const_7)
		{
			return @class;
		}
		StringBuilder stringBuilder = new StringBuilder();
		Format(class515_0, dateTime_0, double_0, stringBuilder);
		@class.method_0(Enum136.const_3, stringBuilder.ToString());
		return @class;
	}

	protected override void vmethod_0(char[] char_0, int int_0, int int_1)
	{
	}

	[SpecialName]
	internal void method_8(string string_2)
	{
		string_0 = string_2;
	}

	[SpecialName]
	internal void method_9(string string_2)
	{
		string_1 = string_2;
	}

	public void Format(Class515 class515_0, DateTime dateTime_0, double double_0, StringBuilder stringBuilder_0)
	{
		if (string_0 != null)
		{
			stringBuilder_0.Append(string_0);
		}
		vmethod_5(class515_0, dateTime_0, double_0, stringBuilder_0);
		if (string_1 != null)
		{
			stringBuilder_0.Append(string_1);
		}
	}
}
