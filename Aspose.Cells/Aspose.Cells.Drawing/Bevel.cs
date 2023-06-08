using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents a bevel of a shape
///       </summary>
public class Bevel
{
	internal int int_0;

	internal int int_1;

	private BevelPresetType bevelPresetType_0;

	/// <summary>
	///       Gets and sets the width of the bevel, or how far into the shape it is applied.
	///       In unit of Points.
	///       </summary>
	public double Width
	{
		get
		{
			return (double)int_0 / Class1391.double_0;
		}
		set
		{
			if (value > 0.0 && bevelPresetType_0 == BevelPresetType.None)
			{
				bevelPresetType_0 = BevelPresetType.Circle;
			}
			int_0 = (int)(value * Class1391.double_0);
		}
	}

	/// <summary>
	///       Gets and sets the height of the bevel, or how far above the shape it is applied.
	///       In unit of Points.
	///       </summary>
	public double Height
	{
		get
		{
			return (double)int_1 / Class1391.double_0;
		}
		set
		{
			if (value > 0.0 && bevelPresetType_0 == BevelPresetType.None)
			{
				bevelPresetType_0 = BevelPresetType.Circle;
			}
			int_1 = (int)(value * Class1391.double_0);
		}
	}

	/// <summary>
	///       Gets and sets the preset bevel type.
	///       </summary>
	public BevelPresetType Type
	{
		get
		{
			return bevelPresetType_0;
		}
		set
		{
			bevelPresetType_0 = value;
		}
	}

	internal Bevel()
	{
		bevelPresetType_0 = BevelPresetType.Circle;
	}

	internal void Copy(Bevel bevel_0)
	{
		bevelPresetType_0 = bevel_0.bevelPresetType_0;
		int_1 = bevel_0.int_1;
		int_0 = bevel_0.int_0;
	}
}
