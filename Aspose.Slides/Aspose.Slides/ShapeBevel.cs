using System;

namespace Aspose.Slides;

public class ShapeBevel : IShapeBevel
{
	internal double double_0 = 6.0;

	internal double double_1 = 6.0;

	internal BevelPresetType bevelPresetType_0 = BevelPresetType.NotDefined;

	private bool bool_0;

	private uint uint_0;

	public double Width
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_1();
		}
	}

	public double Height
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
			method_1();
		}
	}

	public BevelPresetType BevelType
	{
		get
		{
			return bevelPresetType_0;
		}
		set
		{
			bevelPresetType_0 = value;
			method_1();
		}
	}

	internal uint Version => uint_0;

	public ShapeBevel(bool bIsTopBevel)
	{
		bool_0 = bIsTopBevel;
	}

	internal void method_0(ShapeBevel shapeBevel)
	{
		bool_0 = shapeBevel.bool_0;
		double_1 = shapeBevel.double_1;
		bevelPresetType_0 = shapeBevel.bevelPresetType_0;
		double_0 = shapeBevel.double_0;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ShapeBevel shapeBevel))
		{
			return base.Equals(obj);
		}
		if (double_0 == shapeBevel.double_0 && double_1 == shapeBevel.double_1 && bevelPresetType_0 == shapeBevel.bevelPresetType_0)
		{
			return bool_0 == shapeBevel.bool_0;
		}
		return false;
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	private void method_1()
	{
		uint_0++;
	}
}
