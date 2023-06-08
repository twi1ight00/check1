using ns115;
using ns126;
using ns133;
using ns154;

namespace ns117;

internal class Class4473 : Class4469
{
	public Class4473()
	{
	}

	public Class4473(Class4715 subroutines)
		: base(subroutines)
	{
	}

	protected override void vmethod_1(Class4455 reader)
	{
		Class4459 @class = (Class4459)reader;
		switch (@class.method_0())
		{
		case Enum650.const_0:
		{
			string text = @class.method_3();
			if (text == null)
			{
				method_0(text);
			}
			else
			{
				base.CommandProcessor.vmethod_0(text);
			}
			break;
		}
		case Enum650.const_1:
			class4707_0.method_0(@class.method_1());
			break;
		case Enum650.const_2:
			class4707_0.method_0(@class.method_2());
			break;
		}
	}

	protected override Class4455 vmethod_0(Class4552 psProgram)
	{
		return new Class4459(psProgram);
	}
}
