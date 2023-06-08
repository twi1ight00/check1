using Aspose.Words.Tables;
using x1495530f35d79681;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;

namespace x909757d9fd2dd6ae;

internal class xd701baa8d8c978fa
{
	internal static TableStyleOptions x6acbbe254d0bb830(x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		TableStyleOptions tableStyleOptions = TableStyleOptions.Default;
		string xbcea506a33cf = x97bf2eeabd4abc7b.xbbfc54380705e01e();
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
		{
			tableStyleOptions = x4cf3b47199c96529.xb7e770c54c5f7404(xc1b08afa36bf580c.x5c612ff105e66e13(xbcea506a33cf));
		}
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "firstRow":
				tableStyleOptions = (TableStyleOptions)x26000ce44ebda9ea.x5ef51986c8da8183((int)tableStyleOptions, 32, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			case "firstColumn":
				tableStyleOptions = (TableStyleOptions)x26000ce44ebda9ea.x5ef51986c8da8183((int)tableStyleOptions, 128, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			case "lastColumn":
				tableStyleOptions = (TableStyleOptions)x26000ce44ebda9ea.x5ef51986c8da8183((int)tableStyleOptions, 256, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			case "lastRow":
				tableStyleOptions = (TableStyleOptions)x26000ce44ebda9ea.x5ef51986c8da8183((int)tableStyleOptions, 64, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			case "noHBand":
				tableStyleOptions = (TableStyleOptions)x26000ce44ebda9ea.x5ef51986c8da8183((int)tableStyleOptions, 512, !x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			case "noVBand":
				tableStyleOptions = (TableStyleOptions)x26000ce44ebda9ea.x5ef51986c8da8183((int)tableStyleOptions, 1024, !x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			}
		}
		return tableStyleOptions;
	}
}
