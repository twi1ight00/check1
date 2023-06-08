namespace ns237;

internal class Class6545 : Class6511
{
	internal string string_1;

	internal int int_1;

	internal Class6673 class6673_0;

	internal Class6545 class6545_0;

	internal Class6545 class6545_1;

	internal Class6545 class6545_2;

	internal Class6545 class6545_3;

	internal Class6545 class6545_4;

	internal Class6545(Class6672 context, string title, int level, Class6673 destination)
		: base(context)
	{
		string_1 = title;
		int_1 = level;
		class6673_0 = destination;
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_28(method_0());
		writer.method_29(this);
		writer.method_6();
		writer.method_13("/Title", string_1);
		writer.method_8("/Parent", class6545_0.IndirectReference);
		if (class6545_1 != null)
		{
			writer.method_8("/Prev", class6545_1.IndirectReference);
		}
		if (class6545_2 != null)
		{
			writer.method_8("/Next", class6545_2.IndirectReference);
		}
		if (class6545_3 != null)
		{
			writer.method_8("/First", class6545_3.IndirectReference);
		}
		if (class6545_4 != null)
		{
			writer.method_8("/Last", class6545_4.IndirectReference);
		}
		if (class6545_3 != null)
		{
			int num = method_2();
			if (int_1 >= class6672_0.Options.ExpandedOutlineLevels)
			{
				num = -num;
			}
			writer.method_18("/Count", num);
		}
		writer.Write("/Dest");
		class6673_0.method_0(writer);
		writer.method_7();
		writer.method_30();
		for (Class6545 @class = class6545_3; @class != null; @class = @class.class6545_2)
		{
			@class.vmethod_0(writer);
		}
	}

	internal void method_1(Class6545 child)
	{
		if (class6545_3 == null)
		{
			class6545_3 = child;
		}
		else
		{
			class6545_4.class6545_2 = child;
			child.class6545_1 = class6545_4;
		}
		class6545_4 = child;
		child.class6545_0 = this;
	}

	private int method_2()
	{
		int num = 0;
		for (Class6545 @class = class6545_3; @class != null; @class = @class.class6545_2)
		{
			num++;
		}
		return num;
	}
}
