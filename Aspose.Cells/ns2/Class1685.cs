using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace ns2;

internal class Class1685 : CollectionBase
{
	public Class1684 this[int int_0] => (Class1684)base.InnerList[int_0];

	public Class1684 this[Enum235 enum235_0]
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					if (this[num].enum235_0 == enum235_0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return this[num];
		}
	}

	public void Add(Class1685 class1685_0)
	{
		base.InnerList.AddRange(class1685_0.InnerList);
	}

	public int Add(Class1684 class1684_0)
	{
		base.InnerList.Add(class1684_0);
		return base.Count - 1;
	}

	public int Add(Enum235 enum235_0, object object_0)
	{
		Class1684 @class = new Class1684();
		@class.enum235_0 = enum235_0;
		@class.object_0 = object_0;
		base.InnerList.Add(@class);
		return base.Count - 1;
	}

	internal bool method_0(WorksheetCollection worksheetCollection_0, InternalColor internalColor_0)
	{
		return internalColor_0.ColorType switch
		{
			ColorType.RGB => !worksheetCollection_0.method_24().IsColorInPalette(internalColor_0.method_6(worksheetCollection_0.Workbook)), 
			ColorType.Theme => false, 
			_ => false, 
		};
	}

	internal void method_1(Style style_0)
	{
		WorksheetCollection worksheetCollection_ = style_0.method_5();
		if (style_0.IsModified(StyleModifyFlag.Indent) && style_0.IndentLevel > 15)
		{
			Add(Enum235.const_15, style_0.IndentLevel);
		}
		if (style_0.IsModified(StyleModifyFlag.FontColor) && method_0(worksheetCollection_, style_0.Font.InternalColor))
		{
			Add(Enum235.const_13, style_0.Font.InternalColor);
		}
		if (style_0.IsGradient)
		{
			GradientFill gradientFill = new GradientFill(null, null);
			gradientFill.method_5(GradientColorType.TwoColors, style_0.ForeInternalColor, 0.0, style_0.BackgroundInternalColor, style_0.method_51(), style_0.method_53());
			Add(Enum235.const_6, gradientFill);
		}
		else if (style_0.IsModified(StyleModifyFlag.CellShading))
		{
			if (style_0.IsModified(StyleModifyFlag.ForegroundColor) && method_0(worksheetCollection_, style_0.ForeInternalColor))
			{
				Add(Enum235.const_4, style_0.ForeInternalColor);
			}
			if (style_0.IsModified(StyleModifyFlag.BackgroundColor) && method_0(worksheetCollection_, style_0.BackgroundInternalColor))
			{
				Add(Enum235.const_5, style_0.BackgroundInternalColor);
			}
		}
		if (style_0.IsModified(StyleModifyFlag.Borders))
		{
			if (style_0.IsModified(StyleModifyFlag.LeftBorder) && method_0(worksheetCollection_, style_0.Borders[BorderType.LeftBorder].InternalColor))
			{
				Add(Enum235.const_9, style_0.Borders[BorderType.LeftBorder].InternalColor);
			}
			if (style_0.IsModified(StyleModifyFlag.RightBorder) && method_0(worksheetCollection_, style_0.Borders[BorderType.RightBorder].InternalColor))
			{
				Add(Enum235.const_10, style_0.Borders[BorderType.RightBorder].InternalColor);
			}
			if (style_0.IsModified(StyleModifyFlag.TopBorder) && method_0(worksheetCollection_, style_0.Borders[BorderType.TopBorder].InternalColor))
			{
				Add(Enum235.const_7, style_0.Borders[BorderType.TopBorder].InternalColor);
			}
			if (style_0.IsModified(StyleModifyFlag.BottomBorder) && method_0(worksheetCollection_, style_0.Borders[BorderType.BottomBorder].InternalColor))
			{
				Add(Enum235.const_8, style_0.Borders[BorderType.BottomBorder].InternalColor);
			}
			if (style_0.IsModified(StyleModifyFlag.Diagonal) && method_0(worksheetCollection_, style_0.Borders.method_7()))
			{
				Add(Enum235.const_11, style_0.Borders.method_7());
			}
		}
	}

	internal bool method_2(Style style_0)
	{
		bool result = false;
		for (int i = 0; i < base.Count; i++)
		{
			Class1684 @class = this[i];
			switch (@class.enum235_0)
			{
			case Enum235.const_4:
				style_0.ForeInternalColor = (InternalColor)@class.object_0;
				break;
			case Enum235.const_5:
				style_0.BackgroundInternalColor = (InternalColor)@class.object_0;
				break;
			case Enum235.const_6:
			{
				GradientFill gradientFill = (GradientFill)@class.object_0;
				gradientFill.SetStyle(style_0, style_0.method_5().Workbook);
				break;
			}
			case Enum235.const_7:
				style_0.Borders[BorderType.TopBorder].InternalColor = (InternalColor)@class.object_0;
				break;
			case Enum235.const_8:
				style_0.Borders[BorderType.BottomBorder].InternalColor = (InternalColor)@class.object_0;
				break;
			case Enum235.const_9:
				style_0.Borders[BorderType.LeftBorder].InternalColor = (InternalColor)@class.object_0;
				break;
			case Enum235.const_10:
				style_0.Borders[BorderType.RightBorder].InternalColor = (InternalColor)@class.object_0;
				break;
			case Enum235.const_11:
				style_0.Borders[BorderType.DiagonalDown].InternalColor = (InternalColor)@class.object_0;
				style_0.Borders[BorderType.DiagonalUp].InternalColor = (InternalColor)@class.object_0;
				break;
			case Enum235.const_13:
				result = true;
				style_0.Font.InternalColor = (InternalColor)@class.object_0;
				break;
			case Enum235.const_14:
				result = true;
				switch ((int)@class.object_0)
				{
				case 1:
					style_0.Font.method_24(Enum193.const_1);
					break;
				case 2:
					style_0.Font.method_24(Enum193.const_2);
					break;
				}
				break;
			case Enum235.const_15:
				style_0.IndentLevel = (short)@class.object_0;
				break;
			}
		}
		return result;
	}
}
