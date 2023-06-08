using System.Collections;
using ns171;
using ns186;

namespace ns187;

internal class Class5056 : Class5027.Class5054
{
	public Class5056(int propId)
		: base(propId)
	{
	}

	public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
	{
		Class5027 @class = (Class5027)base.vmethod_11(p, propertyList, fo);
		ArrayList arrayList = @class.vmethod_8();
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		int num = -1;
		int num2 = arrayList.Count;
		while (--num2 >= 0)
		{
			Class5024 class2 = (Class5024)arrayList[num2];
			if (class2 is Class5047)
			{
				class2 = (Class5024)(arrayList[num2] = vmethod_10(class2.vmethod_13()));
			}
			if (class2 != null)
			{
				num = class2.imethod_0();
			}
			switch ((Enum679)num)
			{
			case Enum679.const_18:
			case Enum679.const_78:
			case Enum679.const_173:
			case Enum679.const_177:
			case Enum679.const_178:
			case Enum679.const_179:
			case Enum679.const_190:
			case Enum679.const_240:
				if (!flag)
				{
					switch ((Enum679)num)
					{
					case Enum679.const_18:
					case Enum679.const_173:
						if (!flag5)
						{
							flag5 = true;
						}
						break;
					case Enum679.const_78:
					case Enum679.const_177:
						if (!flag4)
						{
							flag4 = true;
						}
						break;
					case Enum679.const_178:
					case Enum679.const_190:
						if (!flag3)
						{
							flag3 = true;
						}
						break;
					case Enum679.const_179:
					case Enum679.const_240:
						if (!flag2)
						{
							flag2 = true;
						}
						break;
					default:
						throw new Exception55("Invalid combination of values");
					}
					break;
				}
				throw new Exception55("'none' specified, no additional values allowed");
			case Enum679.const_182:
				if (!(flag2 || flag3 || flag4 || flag5))
				{
					flag = true;
					break;
				}
				throw new Exception55("Invalid combination of values");
			default:
				throw new Exception55("Invalid value specified: " + p);
			}
		}
		return @class;
	}
}
