using ns10;
using ns16;

namespace ns9;

internal class Class406 : Class316
{
	internal Class406()
	{
		int_0 = 494;
	}

	internal void SetLink(Class1537 class1537_0)
	{
		int num = 32;
		if (class1537_0.string_0 != null)
		{
			num += class1537_0.string_0.Length * 2;
		}
		if (class1537_0.hyperlink_0.TextToDisplay != null)
		{
			num += class1537_0.hyperlink_0.TextToDisplay.Length * 2;
		}
		if (class1537_0.hyperlink_0.ScreenTip != null)
		{
			num += class1537_0.hyperlink_0.ScreenTip.Length * 2;
		}
		if (class1537_0.int_0 == 2)
		{
			num += class1537_0.hyperlink_0.Address.Length * 2;
		}
		byte_0 = new byte[num];
		Class1217.smethod_4(class1537_0.hyperlink_0.Area, byte_0, 0);
		int num2 = 16;
		Class1217.smethod_7(byte_0, ref num2, class1537_0.string_0);
		if (class1537_0.int_0 == 2)
		{
			Class1217.smethod_7(byte_0, ref num2, class1537_0.hyperlink_0.Address);
		}
		else
		{
			num2 += 4;
		}
		Class1217.smethod_7(byte_0, ref num2, class1537_0.hyperlink_0.ScreenTip);
		Class1217.smethod_7(byte_0, ref num2, class1537_0.hyperlink_0.TextToDisplay);
	}
}
