using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace ns16;

internal class Class1528
{
	internal double double_0;

	internal double double_1;

	internal double double_2;

	internal double double_3;

	internal string string_0;

	internal int int_0;

	internal double[] double_4;

	internal InternalColor[] internalColor_0;

	internal static bool smethod_0(Class1528 class1528_0, Class1528 class1528_1)
	{
		if (class1528_0 == null && class1528_1 == null)
		{
			return true;
		}
		if (class1528_0 != null && class1528_1 != null)
		{
			if (class1528_0.double_0 != class1528_1.double_0)
			{
				return false;
			}
			if (class1528_0.double_1 != class1528_1.double_1)
			{
				return false;
			}
			if (class1528_0.double_2 != class1528_1.double_2)
			{
				return false;
			}
			if (class1528_0.double_3 != class1528_1.double_3)
			{
				return false;
			}
			if (class1528_0.string_0 != class1528_1.string_0)
			{
				return false;
			}
			if (class1528_0.int_0 != class1528_1.int_0)
			{
				return false;
			}
			if (class1528_0.double_0 != class1528_1.double_0)
			{
				return false;
			}
			if (class1528_0.double_4 != null || class1528_1.double_4 != null)
			{
				if (class1528_0.double_4 == null || class1528_1.double_4 == null)
				{
					return false;
				}
				if (class1528_0.double_4.Length != class1528_1.double_4.Length)
				{
					return false;
				}
				int num = class1528_0.double_4.Length;
				for (int i = 0; i < num; i++)
				{
					if (class1528_0.double_4[i] != class1528_1.double_4[i])
					{
						return false;
					}
				}
			}
			if (class1528_0.internalColor_0 != null || class1528_1.internalColor_0 != null)
			{
				if (class1528_0.internalColor_0 == null || class1528_1.internalColor_0 == null)
				{
					return false;
				}
				if (class1528_0.internalColor_0.Length != class1528_1.internalColor_0.Length)
				{
					return false;
				}
				int num2 = class1528_0.internalColor_0.Length;
				for (int j = 0; j < num2; j++)
				{
					if (!class1528_0.internalColor_0[j].Equals(class1528_1.double_4[j]))
					{
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	internal static void smethod_1(Class1528 class1528_0, Style style_0)
	{
		GradientStyleType gradientStyleType_ = GradientStyleType.Horizontal;
		int num = 0;
		if (class1528_0.internalColor_0.Length == 0)
		{
			return;
		}
		InternalColor internalColor = class1528_0.internalColor_0[0];
		InternalColor internalColor_ = class1528_0.internalColor_0[1];
		if (class1528_0.string_0 != null && class1528_0.string_0 == "path")
		{
			if (class1528_0.double_2 == 0.5)
			{
				gradientStyleType_ = GradientStyleType.FromCenter;
			}
			else
			{
				gradientStyleType_ = GradientStyleType.FromCorner;
				if (class1528_0.double_2 == 1.0)
				{
					num = ((class1528_0.double_0 != 1.0) ? 3 : 4);
				}
				else if (class1528_0.double_2 == 0.0)
				{
					num = ((class1528_0.double_0 == 0.0) ? 1 : 2);
				}
			}
		}
		else
		{
			switch (class1528_0.int_0)
			{
			case 45:
				gradientStyleType_ = GradientStyleType.DiagonalUp;
				num = ((class1528_0.internalColor_0.Length != 3) ? 1 : 3);
				break;
			case 0:
				gradientStyleType_ = GradientStyleType.Vertical;
				num = ((class1528_0.internalColor_0.Length != 3) ? 1 : 3);
				break;
			case 135:
				gradientStyleType_ = GradientStyleType.DiagonalDown;
				num = ((class1528_0.internalColor_0.Length != 3) ? 1 : 3);
				break;
			case 90:
				gradientStyleType_ = GradientStyleType.Horizontal;
				num = ((class1528_0.internalColor_0.Length != 3) ? 1 : 3);
				break;
			case 225:
				gradientStyleType_ = GradientStyleType.DiagonalUp;
				num = 2;
				break;
			case 180:
				gradientStyleType_ = GradientStyleType.Vertical;
				num = 2;
				break;
			case 315:
				gradientStyleType_ = GradientStyleType.DiagonalDown;
				num = 2;
				break;
			case 270:
				gradientStyleType_ = GradientStyleType.Horizontal;
				num = 2;
				break;
			}
		}
		style_0.SetTwoColorGradient(internalColor, internalColor_, gradientStyleType_, num);
		style_0.IsGradient = true;
	}

	internal static Class1528 smethod_2(Style style_0)
	{
		if (!style_0.IsGradient)
		{
			return null;
		}
		InternalColor foreInternalColor = style_0.ForeInternalColor;
		InternalColor backgroundInternalColor = style_0.BackgroundInternalColor;
		GradientStyleType gradientStyleType = style_0.method_51();
		int num = style_0.method_53();
		Class1528 @class = new Class1528();
		switch (gradientStyleType)
		{
		case GradientStyleType.FromCenter:
		case GradientStyleType.FromCorner:
			@class.string_0 = "path";
			@class.double_4 = new double[2] { 0.0, 1.0 };
			@class.internalColor_0 = new InternalColor[2] { foreInternalColor, backgroundInternalColor };
			break;
		case GradientStyleType.DiagonalDown:
		case GradientStyleType.DiagonalUp:
		case GradientStyleType.Horizontal:
		case GradientStyleType.Vertical:
			switch (num)
			{
			case 1:
			case 2:
				@class.double_4 = new double[2] { 0.0, 1.0 };
				@class.internalColor_0 = new InternalColor[2] { foreInternalColor, backgroundInternalColor };
				break;
			case 3:
				@class.double_4 = new double[3] { 0.0, 0.5, 1.0 };
				@class.internalColor_0 = new InternalColor[3] { foreInternalColor, backgroundInternalColor, foreInternalColor };
				break;
			}
			break;
		}
		switch (gradientStyleType)
		{
		case GradientStyleType.DiagonalDown:
			switch (num)
			{
			case 1:
				@class.int_0 = 135;
				break;
			case 2:
				@class.int_0 = 315;
				break;
			case 3:
				@class.int_0 = 135;
				break;
			}
			break;
		case GradientStyleType.DiagonalUp:
			switch (num)
			{
			case 1:
				@class.int_0 = 45;
				break;
			case 2:
				@class.int_0 = 225;
				break;
			case 3:
				@class.int_0 = 45;
				break;
			}
			break;
		case GradientStyleType.FromCenter:
			@class.double_2 = (@class.double_1 = (@class.double_0 = (@class.double_3 = 0.5)));
			break;
		case GradientStyleType.FromCorner:
			switch (num)
			{
			case 2:
				@class.double_0 = 1.0;
				@class.double_1 = 1.0;
				break;
			case 3:
				@class.double_2 = 1.0;
				@class.double_3 = 1.0;
				break;
			case 4:
				@class.double_2 = (@class.double_1 = (@class.double_0 = (@class.double_3 = 1.0)));
				break;
			}
			break;
		case GradientStyleType.Horizontal:
			switch (num)
			{
			case 1:
				@class.int_0 = 90;
				break;
			case 2:
				@class.int_0 = 270;
				break;
			case 3:
				@class.int_0 = 90;
				break;
			}
			break;
		case GradientStyleType.Vertical:
			switch (num)
			{
			case 1:
				@class.int_0 = 0;
				break;
			case 2:
				@class.int_0 = 180;
				break;
			case 3:
				@class.int_0 = 0;
				break;
			}
			break;
		}
		return @class;
	}
}
