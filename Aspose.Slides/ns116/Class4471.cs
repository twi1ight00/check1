using ns115;
using ns126;
using ns133;
using ns154;

namespace ns116;

internal class Class4471 : Class4469
{
	private int int_0;

	public Class4471(int charStringType)
	{
		int_0 = charStringType;
	}

	public Class4471(Class4715 subroutines, int charStringType)
		: base(subroutines)
	{
		int_0 = charStringType;
	}

	protected override void vmethod_1(Class4455 reader)
	{
		Class4456 @class = (Class4456)reader;
		switch (@class.method_0())
		{
		case Enum650.const_0:
		{
			string text = @class.method_4();
			if (text == null)
			{
				method_0(text);
				break;
			}
			base.CommandProcessor.vmethod_0(text);
			if ((!(text == "hintmask") && !(text == "cntrmask")) || class4707_0.Count <= 0)
			{
				break;
			}
			long num = (long)base.OperandStack.method_3();
			if (num != 0L)
			{
				for (int i = 0; i < num; i++)
				{
					@class.Read();
					class4707_0.method_0(@class.method_1());
				}
			}
			base.CommandProcessor.vmethod_0("pickupyourfreakingmask");
			break;
		}
		case Enum650.const_1:
			class4707_0.method_0(@class.method_2());
			break;
		case Enum650.const_2:
			class4707_0.method_0(@class.method_3());
			break;
		}
	}

	protected override Class4455 vmethod_0(Class4552 psProgram)
	{
		return new Class4456(psProgram, int_0);
	}
}
