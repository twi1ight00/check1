using System;
using ns2;
using ns21;

namespace Aspose.Cells.Drawing;

/// <summary>
///       This class specifies the 3D shape properties for a chart element or shape.
///       </summary>
public class Format3D
{
	private ShapePropertyCollection shapePropertyCollection_0;

	/// <summary>
	///       Gets the <seealso cref="T:Aspose.Cells.Drawing.Bevel" /> object that holds the properties associated with defining a bevel on the top or front face of a shape.
	///       </summary>
	public Bevel TopBevel
	{
		get
		{
			method_0();
			return shapePropertyCollection_0.method_1().TopBevel;
		}
	}

	/// <summary>
	///       Gets and sets the material type which is combined with the lighting properties to give the final look and feel of a shape.
	///       Default value is PresetMaterialType.WarmMatte.
	///       </summary>
	public PresetMaterialType SurfaceMaterialType
	{
		get
		{
			method_0();
			return shapePropertyCollection_0.method_1().method_4();
		}
		set
		{
			method_0();
			shapePropertyCollection_0.method_1().method_5(value);
		}
	}

	/// <summary>
	///       Gets and sets the lighting type which is to be applied to the scene of the shape.
	///       Default value is LightRigType.ThreePoint.
	///       </summary>
	public LightRigType SurfaceLightingType
	{
		get
		{
			method_0();
			return shapePropertyCollection_0.method_3().method_1().method_1();
		}
		set
		{
			method_0();
			shapePropertyCollection_0.method_3().method_1().method_2(value);
		}
	}

	/// <summary>
	///       Gets and sets the lighting angle. Range from 0 to 359.9 degrees.
	///       </summary>
	public double LightingAngle
	{
		get
		{
			method_0();
			return Math.Round((double)shapePropertyCollection_0.method_3().method_1().method_0()
				.int_2 / (double)Class1391.int_0, 1);
		}
		set
		{
			method_0();
			if (value < 0.0 || value > 359.9)
			{
				throw new CellsException(ExceptionType.InvalidData, "LightingAngle must between 0 and 359.9");
			}
			shapePropertyCollection_0.method_3().method_1().method_0()
				.int_2 = (int)(value * (double)Class1391.int_0);
		}
	}

	internal Format3D(ShapePropertyCollection shapePropertyCollection_1)
	{
		shapePropertyCollection_0 = shapePropertyCollection_1;
	}

	private void method_0()
	{
		if (shapePropertyCollection_0.method_2() == null)
		{
			Class1295 @class = shapePropertyCollection_0.method_3();
			@class.method_0().method_1(Enum189.const_46);
			@class.method_1().method_2(LightRigType.ThreePoint);
			@class.method_1().method_4(Enum177.const_5);
		}
	}

	/// <summary>
	///       Indicates if the shape has top bevel data.
	///       </summary>
	/// <returns>
	/// </returns>
	public bool HasTopBevelData()
	{
		if (shapePropertyCollection_0.method_0() != null && shapePropertyCollection_0.method_0().method_3() != null && shapePropertyCollection_0.method_0().method_3().Type != 0)
		{
			return true;
		}
		return false;
	}
}
