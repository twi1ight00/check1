using System;
using System.Runtime.CompilerServices;
using ns2;
using ns21;
using ns7;

namespace Aspose.Cells.Drawing;

/// <summary>
///       This class specifies a glow effect, in which a color blurred outline 
///       is added outside the edges of the object.
///       </summary>
public class GlowEffect
{
	private Class1288 class1288_0;

	internal CellsColor cellsColor_0;

	private Class923 class923_0;

	internal int int_0;

	/// <summary>
	///       Gets and sets the color of the glow effect.
	///       </summary>
	public CellsColor CellsColor
	{
		get
		{
			if (cellsColor_0 == null)
			{
				cellsColor_0 = new CellsColor(class1288_0.Workbook);
			}
			return cellsColor_0;
		}
		set
		{
			if (value != null)
			{
				cellsColor_0 = value;
			}
		}
	}

	/// <summary>
	///       Gets and sets the degree of transparency of the glow effect. Range from 0.0 (opaque) to 1.0 (clear).
	///       </summary>
	public double Transparency
	{
		get
		{
			return Math.Round(1.0 - (double)method_1() / 100000.0, 2);
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new CellsException(ExceptionType.InvalidData, "Transparency must between 0.0 (opaque) and 1.0 (clear)");
			}
			method_2((int)((1.0 - value) * 100000.0));
		}
	}

	/// <summary>
	///       Gets and sets the radius of the glow, in unit of points.
	///       </summary>
	public double Radius
	{
		get
		{
			return (double)int_0 / Class1391.double_0;
		}
		set
		{
			int_0 = (int)(value * Class1391.double_0);
		}
	}

	internal Class923 Properties
	{
		get
		{
			if (class923_0 == null)
			{
				class923_0 = new Class923();
			}
			return class923_0;
		}
	}

	internal GlowEffect(Class1288 class1288_1)
	{
		class1288_0 = class1288_1;
	}

	internal bool method_0()
	{
		if (int_0 == 0 && cellsColor_0 == null)
		{
			return false;
		}
		return true;
	}

	internal CellsColor GetColor()
	{
		return cellsColor_0;
	}

	internal void SetColor(CellsColor cellsColor_1)
	{
		cellsColor_0 = cellsColor_1;
	}

	[SpecialName]
	internal int method_1()
	{
		object obj = Properties.method_1(Enum230.const_10);
		if (obj != null)
		{
			return (int)obj;
		}
		return 100;
	}

	[SpecialName]
	internal void method_2(int int_1)
	{
		Class1691 @class = Properties.method_2(Enum230.const_10);
		if (@class == null)
		{
			Properties.method_0(Enum230.const_10, int_1);
		}
		else
		{
			@class.object_0 = int_1;
		}
	}

	internal void Copy(GlowEffect glowEffect_0)
	{
		if (glowEffect_0.cellsColor_0 != null)
		{
			cellsColor_0 = new CellsColor(class1288_0.Workbook);
			cellsColor_0.internalColor_0 = glowEffect_0.cellsColor_0.internalColor_0;
		}
		int_0 = glowEffect_0.int_0;
		if (glowEffect_0.class923_0 != null)
		{
			class923_0 = new Class923();
			class923_0.Copy(glowEffect_0.class923_0);
		}
		else
		{
			class923_0 = null;
		}
	}
}
