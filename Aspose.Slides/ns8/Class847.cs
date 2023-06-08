using Aspose.Slides;
using ns33;
using ns56;

namespace ns8;

internal class Class847 : Class846
{
	private Class2191 class2191_0;

	private Enum118 enum118_0;

	private Class131 class131_0;

	private static readonly Class1151 class1151_1 = new Class1151("none", "animLvl", "animOne", "bulEnabled", "chMax", "chPref", "dir", "hierBranch", "orgChart", "resizeHandles");

	public Class847(Class2191 elementData, Class131 parent)
		: base(elementData)
	{
		class2191_0 = elementData;
		enum118_0 = (Enum118)class1151_1[class2191_0.Arg];
		class131_0 = parent;
	}

	internal bool method_0(Class836 dataContext, Class837 presentationContext)
	{
		string text = method_1(dataContext, presentationContext);
		int result = 0;
		bool flag;
		if (flag = int.TryParse(text, out var result2))
		{
			int.TryParse(class2191_0.Val, out result);
		}
		bool result3 = false;
		switch (class2191_0.Op)
		{
		case Enum333.const_1:
			result3 = ((!flag) ? string.Equals(text, class2191_0.Val) : (result2 == result));
			break;
		case Enum333.const_2:
			result3 = ((!flag) ? (!string.Equals(text, class2191_0.Val)) : (result2 != result));
			break;
		case Enum333.const_3:
			if (!flag)
			{
				throw new PptxException("operator \"if\" expression is invalid");
			}
			result3 = result2 > result;
			break;
		case Enum333.const_4:
			if (!flag)
			{
				throw new PptxException("operator \"if\" expression is invalid");
			}
			result3 = result2 < result;
			break;
		case Enum333.const_5:
			if (!flag)
			{
				throw new PptxException("operator \"if\" expression is invalid");
			}
			result3 = result2 >= result;
			break;
		case Enum333.const_6:
			if (!flag)
			{
				throw new PptxException("operator \"if\" expression is invalid");
			}
			result3 = result2 <= result;
			break;
		}
		return result3;
	}

	private string method_1(Class836 context, Class837 presOf)
	{
		Class838 @class = context.method_4(this, presOf.Algorithm != null && presOf.Algorithm.HideLastTransition);
		switch (class2191_0.Func)
		{
		default:
			return string.Empty;
		case Enum334.const_1:
			return @class.Count.ToString();
		case Enum334.const_2:
			return context.PositionSameType.ToString();
		case Enum334.const_3:
		{
			int num2 = context.ReversePositionSameType;
			if (context.Type == Enum337.const_6)
			{
				num2--;
			}
			return num2.ToString();
		}
		case Enum334.const_4:
			if (context.PositionSameType % 2 == 0 && @class.Contains(context))
			{
				return "1";
			}
			return "0";
		case Enum334.const_5:
			if (context.PositionSameType % 2 != 0 && @class.Contains(context))
			{
				return "1";
			}
			return "0";
		case Enum334.const_6:
			return class131_0.method_3<Class135>().method_7(enum118_0, presOf);
		case Enum334.const_7:
			return context.Level.ToString();
		case Enum334.const_8:
		{
			int num = 0;
			Class838 class2 = context.method_4(this, skipLastTransition: false);
			foreach (Class836 item in class2)
			{
				if (item.Level > num)
				{
					num = item.Level;
				}
			}
			Class836 class3 = context;
			if (base.Axis.Count > 1)
			{
				Class838 class4 = context.method_5(this, skipLastTransition: false, 0, isRecursive: false);
				if (class4.Count > 0)
				{
					class3 = class4[0];
				}
			}
			return (num - class3.Level).ToString();
		}
		}
	}
}
