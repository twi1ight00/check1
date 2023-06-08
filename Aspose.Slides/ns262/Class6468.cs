using System.Drawing;
using ns253;

namespace ns262;

internal class Class6468 : Interface312
{
	private readonly Interface304 interface304_0;

	private RectangleF rectangleF_0 = default(RectangleF);

	private Class6456[] class6456_0;

	private int int_0;

	public double MaximumColumnHeight
	{
		get
		{
			double num = 0.0;
			Class6456[] array = class6456_0;
			foreach (Class6456 @class in array)
			{
				if (num < @class.ActualHeight)
				{
					num = @class.ActualHeight;
				}
			}
			return num;
		}
	}

	public double ColumnWidth => class6456_0[0].Width;

	public double ColumnHeight => class6456_0[0].Height;

	public Class6456[] Columns => class6456_0;

	private Class6456 CurrentColumn
	{
		get
		{
			if (int_0 >= class6456_0.Length)
			{
				return null;
			}
			return class6456_0[int_0];
		}
	}

	public Class6468(Interface304 serviceLocator)
	{
		interface304_0 = serviceLocator;
	}

	public void Initialize(Class6448 textBodyProperties, RectangleF bounds)
	{
		rectangleF_0 = textBodyProperties.Insets.method_0(bounds);
		int num = textBodyProperties.ColumnNumber;
		if (num == 0)
		{
			num = 1;
		}
		double num2 = textBodyProperties.SpaceBetweenColumns;
		double num3 = ((double)rectangleF_0.Width - num2 * (double)(num - 1)) / (double)num;
		class6456_0 = new Class6456[num];
		for (int i = 0; i < num; i++)
		{
			Class6456 @class = new Class6456();
			@class.Height = rectangleF_0.Height;
			@class.Width = num3;
			@class.X = (double)rectangleF_0.X + (num3 + num2) * (double)i;
			@class.Y = rectangleF_0.Y;
			class6456_0[i] = @class;
		}
	}

	public void imethod_0(Interface307 line, Interface299 lineSpacing)
	{
		if (CurrentColumn != null)
		{
			CurrentColumn.imethod_0(line, lineSpacing);
			if (line.IsOverflowed && int_0 < class6456_0.Length - 1)
			{
				CurrentColumn.imethod_3(line);
				int_0++;
				imethod_0(line, lineSpacing);
			}
		}
	}

	public void imethod_1(double spaceBefore)
	{
		if (CurrentColumn != null)
		{
			CurrentColumn.imethod_1(spaceBefore);
		}
	}

	public void imethod_2(double spaceAfter)
	{
		if (CurrentColumn != null)
		{
			CurrentColumn.imethod_2(spaceAfter);
		}
	}
}
