using System.Collections;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns12;

internal class Class1127 : CollectionBase
{
	public Class1661 this[int int_0] => (Class1661)base.InnerList[int_0];

	internal bool method_0(StringBuilder stringBuilder_0)
	{
		if (stringBuilder_0.Length != 0)
		{
			method_4(stringBuilder_0);
		}
		else if (base.Count == 0)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula.");
		}
		Class1661 @class = (Class1661)base.InnerList[base.Count - 1];
		if (@class.Type == Enum180.const_2)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula.");
		}
		base.InnerList.RemoveAt(base.Count - 1);
		Class1661 class2 = new Class1661();
		class2.Type = Enum180.const_6;
		class2.method_4("%");
		class2.method_10(Class1128.byte_2);
		class2.method_1(@class);
		base.InnerList.Add(class2);
		return true;
	}

	internal void method_1(StringBuilder stringBuilder_0, string string_0, bool bool_0)
	{
		Class1661 @class = new Class1661();
		@class.Type = Enum180.const_2;
		@class.method_4(string_0);
		@class.int_0 = 3;
		if (stringBuilder_0.Length != 0)
		{
			method_4(stringBuilder_0);
		}
		else if (base.Count == 0)
		{
			@class.Type = Enum180.const_6;
			if (bool_0)
			{
				@class.method_10(Class1128.byte_0);
			}
			else
			{
				@class.method_10(Class1128.byte_1);
			}
		}
		else
		{
			Class1661 class2 = (Class1661)base.InnerList[base.Count - 1];
			switch (class2.Type)
			{
			default:
				if (bool_0)
				{
					@class.method_10(Class1128.byte_5);
				}
				else
				{
					@class.method_10(Class1128.byte_6);
				}
				break;
			case Enum180.const_6:
				if (class2.int_0 == 3)
				{
					@class.Type = Enum180.const_6;
					if (bool_0)
					{
						@class.method_10(Class1128.byte_0);
					}
					else
					{
						@class.method_10(Class1128.byte_1);
					}
				}
				else if (bool_0)
				{
					@class.method_10(Class1128.byte_5);
				}
				else
				{
					@class.method_10(Class1128.byte_6);
				}
				break;
			case Enum180.const_2:
				@class.Type = Enum180.const_6;
				if (bool_0)
				{
					@class.method_10(Class1128.byte_0);
				}
				else
				{
					@class.method_10(Class1128.byte_1);
				}
				break;
			}
		}
		base.InnerList.Add(@class);
	}

	internal bool method_2(StringBuilder stringBuilder_0, string string_0, int int_0, byte[] byte_0)
	{
		if (stringBuilder_0.Length != 0)
		{
			method_4(stringBuilder_0);
		}
		else if (base.Count == 0)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula.");
		}
		Class1661 @class = (Class1661)base.InnerList[base.Count - 1];
		switch (@class.Type)
		{
		case Enum180.const_6:
			if (@class.int_0 == 3)
			{
				throw new CellsException(ExceptionType.Formula, "Invalid formula.");
			}
			break;
		case Enum180.const_2:
			throw new CellsException(ExceptionType.Formula, "Invalid formula.");
		}
		Class1661 class2 = new Class1661();
		class2.method_4(string_0);
		class2.method_10(byte_0);
		class2.Type = Enum180.const_2;
		class2.int_0 = int_0;
		base.InnerList.Add(class2);
		return true;
	}

	internal void method_3(Class1661 class1661_0)
	{
		if (base.Count != 0)
		{
			for (int num = base.Count - 1; num >= 0; num--)
			{
				Class1661 @class = (Class1661)base.InnerList[num];
				if (@class.Type != Enum180.const_6 || @class.int_0 != 3)
				{
					break;
				}
				@class.method_1(class1661_0);
				class1661_0 = @class;
				@class.int_0 = 0;
				RemoveAt(num);
			}
		}
		base.InnerList.Add(class1661_0);
	}

	internal void method_4(StringBuilder stringBuilder_0)
	{
		Class1661 @class = new Class1661();
		@class.method_4(stringBuilder_0.ToString());
		stringBuilder_0.Remove(0, stringBuilder_0.Length);
		@class.Type = Enum180.const_1;
		if (base.Count != 0)
		{
			bool flag = true;
			for (int num = base.Count - 1; num >= 0; num--)
			{
				Class1661 class2 = (Class1661)base.InnerList[num];
				if (class2.Type != Enum180.const_6 || class2.int_0 != 3)
				{
					break;
				}
				if (flag)
				{
					if (class2.method_3() == "-" && Class1677.smethod_18(@class.method_3()))
					{
						class2.Type = Enum180.const_1;
						class2.method_4("-" + @class.method_3());
						class2.method_10(null);
					}
					else
					{
						class2.method_1(@class);
					}
					flag = false;
				}
				else
				{
					class2.method_1(@class);
				}
				class2.int_0 = 0;
				@class = class2;
				RemoveAt(num);
			}
		}
		base.InnerList.Add(@class);
	}
}
