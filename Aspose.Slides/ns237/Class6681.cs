namespace ns237;

internal class Class6681
{
	private readonly Class6672 class6672_0;

	private readonly Class6545 class6545_0;

	private Class6545 class6545_1;

	internal bool IsEmpty => class6545_0.class6545_3 == null;

	internal string IndirectReference => class6545_0.IndirectReference;

	internal Class6681(Class6672 context)
	{
		class6672_0 = context;
		class6545_0 = new Class6545(class6672_0, "Root", -1, null);
		class6545_1 = class6545_0;
	}

	internal void method_0(string title, int level, Class6673 dest)
	{
		Class6545 @class = new Class6545(class6672_0, title, level, dest);
		if (@class.int_1 > class6545_1.int_1)
		{
			class6545_1.method_1(@class);
		}
		else if (@class.int_1 < class6545_1.int_1)
		{
			while (class6545_1.int_1 >= @class.int_1)
			{
				class6545_1 = class6545_1.class6545_0;
			}
			class6545_1.method_1(@class);
		}
		else
		{
			class6545_1.class6545_0.method_1(@class);
		}
		class6545_1 = @class;
	}

	internal void method_1(Class6679 writer)
	{
		writer.method_29(class6545_0);
		writer.method_6();
		writer.method_8("/Type", "/Outlines");
		if (class6545_0.class6545_3 != null)
		{
			writer.method_8("/First", class6545_0.class6545_3.IndirectReference);
		}
		if (class6545_0.class6545_4 != null)
		{
			writer.method_8("/Last", class6545_0.class6545_4.IndirectReference);
		}
		writer.method_7();
		writer.method_30();
		for (Class6545 @class = class6545_0.class6545_3; @class != null; @class = @class.class6545_2)
		{
			@class.vmethod_0(writer);
		}
	}
}
