using Aspose.Cells;

namespace ns16;

internal class Class1571
{
	internal int int_0;

	internal bool bool_0;

	internal Class1525 class1525_0;

	internal Class1563 class1563_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal int int_6;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal bool bool_5;

	internal bool bool_6;

	internal bool bool_7;

	internal Style style_0;

	internal Class1529 class1529_0;

	internal Class1571()
	{
		int_0 = -1;
		bool_0 = false;
		class1525_0 = null;
		class1563_0 = null;
		int_1 = 0;
		int_2 = 0;
		int_3 = 0;
		int_4 = 0;
		int_5 = 0;
		int_6 = -1;
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
	}

	internal bool method_0(Class1571 class1571_0)
	{
		if (int_1 == class1571_0.int_1 && int_2 == class1571_0.int_2 && int_3 == class1571_0.int_3 && int_4 == class1571_0.int_4 && int_5 == class1571_0.int_5)
		{
			if (class1525_0 == null)
			{
				if (class1571_0.class1525_0 != null)
				{
					return false;
				}
			}
			else
			{
				if (class1571_0.class1525_0 == null)
				{
					return false;
				}
				if (!class1571_0.class1525_0.method_0(class1571_0.class1525_0))
				{
					return false;
				}
			}
			if (class1563_0 == null)
			{
				if (class1571_0.class1563_0 != null)
				{
					return false;
				}
			}
			else
			{
				if (class1571_0.class1563_0 == null)
				{
					return false;
				}
				if (!class1563_0.method_0(class1571_0.class1563_0))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}
}
