using ns253;

namespace ns262;

internal class Class6465 : Interface309
{
	private double double_0;

	private bool bool_0 = true;

	private double double_1;

	public double FirstLineWidth => double_0;

	public double RegularLineWidth => double_1;

	public Class6465(Class6435 paragraphProperties, double columnWidth)
	{
		double_1 = columnWidth - (double)paragraphProperties.LeftMargin - (double)paragraphProperties.RightMargin;
		if (paragraphProperties.TextIdentation > 0)
		{
			double_0 = double_1 - (double)paragraphProperties.TextIdentation;
		}
		else
		{
			double_0 = double_1 + (double)paragraphProperties.LeftMargin;
		}
	}

	public double imethod_0()
	{
		if (bool_0)
		{
			bool_0 = false;
			return FirstLineWidth;
		}
		return RegularLineWidth;
	}
}
