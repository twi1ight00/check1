using Aspose.Cells;

namespace ns8;

internal class Class777
{
	private int int_0;

	private int int_1;

	private Font font_0;

	public Class777()
	{
		int_0 = 0;
		int_1 = 0;
		Style style = new Style();
		font_0 = style.Font;
	}

	public Font method_0()
	{
		return font_0;
	}

	public void method_1(Font font_1)
	{
		font_0 = font_1;
	}

	public int method_2()
	{
		return int_0;
	}

	public void method_3(int int_2)
	{
		int_0 = int_2;
	}

	public int method_4()
	{
		return int_1;
	}

	public void SetLength(int int_2)
	{
		int_1 = int_2;
	}
}
