using Aspose.Cells.Charts;

namespace ns27;

internal class Class670 : Class538
{
	internal Class670()
	{
		method_2(2155);
	}

	internal void method_4(DataLabels dataLabels_0)
	{
		switch (dataLabels_0.Separator)
		{
		case DataLablesSeparatorType.Auto:
			method_0(16);
			break;
		case DataLablesSeparatorType.Comma:
		case DataLablesSeparatorType.Semicolon:
		case DataLablesSeparatorType.Period:
			method_0(21);
			break;
		case DataLablesSeparatorType.Space:
		case DataLablesSeparatorType.NewLine:
			method_0(19);
			break;
		}
		byte_0 = new byte[base.Length];
		byte_0[0] = 107;
		byte_0[1] = 8;
		byte_0[12] = 0;
		if (dataLabels_0.ShowSeriesName)
		{
			byte_0[12] |= 1;
		}
		if (dataLabels_0.ShowCategoryName)
		{
			byte_0[12] |= 2;
		}
		if (dataLabels_0.ShowValue)
		{
			byte_0[12] |= 4;
		}
		if (dataLabels_0.ShowPercentage)
		{
			byte_0[12] |= 8;
		}
		if (dataLabels_0.ShowBubbleSize)
		{
			byte_0[12] |= 16;
		}
		if (dataLabels_0.Separator != 0)
		{
			byte_0[16] = 1;
			switch (dataLabels_0.Separator)
			{
			case DataLablesSeparatorType.Space:
				byte_0[14] = 1;
				byte_0[17] = 32;
				break;
			case DataLablesSeparatorType.Auto:
				break;
			case DataLablesSeparatorType.Comma:
				byte_0[14] = 2;
				byte_0[17] = 44;
				byte_0[19] = 32;
				break;
			case DataLablesSeparatorType.Semicolon:
				byte_0[14] = 2;
				byte_0[17] = 59;
				byte_0[19] = 32;
				break;
			case DataLablesSeparatorType.Period:
				byte_0[14] = 2;
				byte_0[17] = 46;
				byte_0[19] = 32;
				break;
			case DataLablesSeparatorType.NewLine:
				byte_0[14] = 1;
				byte_0[17] = 10;
				break;
			}
		}
	}
}
