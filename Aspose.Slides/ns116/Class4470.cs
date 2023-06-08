using ns115;
using ns126;
using ns133;

namespace ns116;

internal class Class4470 : Class4469
{
	protected override void vmethod_1(Class4455 reader)
	{
		Class4457 @class = (Class4457)reader;
		Interface117 @interface = base.CommandProcessor as Interface117;
		int currentPos = @class.CurrentPos;
		if (@interface != null)
		{
			@interface.IsHandled = false;
		}
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
		int currentPos2 = @class.CurrentPos;
		if (@interface != null && !@interface.IsHandled)
		{
			for (int i = currentPos; i < currentPos2; i++)
			{
				@interface.AlterProgramStream.WriteByte(@class.PSProgram[i]);
			}
		}
	}

	protected override Class4455 vmethod_0(Class4552 psProgram)
	{
		return new Class4457(psProgram);
	}
}
