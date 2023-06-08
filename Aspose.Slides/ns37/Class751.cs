using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns36;
using ns38;

namespace ns37;

internal class Class751 : Interface14
{
	private Class746 class746_0;

	private string string_0 = "";

	private DisplayUnitType displayUnitType_0;

	private int int_0;

	private Enum157 enum157_0;

	private Enum157 enum157_1;

	private bool bool_0;

	private bool bool_1;

	internal bool IsAutoRotation
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal Class746 ChartFrameInternal => class746_0;

	public Interface10 ChartFrame => class746_0;

	public DisplayUnitType DisplayUnitType
	{
		get
		{
			return displayUnitType_0;
		}
		set
		{
			displayUnitType_0 = value;
		}
	}

	public string Label
	{
		get
		{
			if (string_0 != "")
			{
				return string_0;
			}
			return displayUnitType_0 switch
			{
				DisplayUnitType.None => "None", 
				DisplayUnitType.Hundreds => "Hundrends", 
				DisplayUnitType.Thousands => "Thousands", 
				DisplayUnitType.Millions => "Millions", 
				DisplayUnitType.Billions => "Billions", 
				DisplayUnitType.Trillions => "Trillions", 
				_ => "None", 
			};
		}
		set
		{
			string_0 = value;
		}
	}

	public int Rotation
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			IsAutoRotation = false;
		}
	}

	public Enum157 TextHorizontalAlignment
	{
		get
		{
			return enum157_0;
		}
		set
		{
			enum157_0 = value;
		}
	}

	public Enum157 TextVerticalAlignment
	{
		get
		{
			return enum157_1;
		}
		set
		{
			enum157_1 = value;
		}
	}

	public bool IsShown
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal Class751(Class740 chart, object parent, Enum140 areaParentType)
	{
		class746_0 = new Class746(chart, parent, Enum140.const_13, Enum145.const_15);
		int_0 = 0;
		class746_0.AreaInternal.Formatting = FillType.NoFill;
		enum157_0 = Enum157.const_1;
		enum157_1 = Enum157.const_1;
		bool_1 = true;
	}

	internal void method_0()
	{
		if (DisplayUnitType != 0 && IsShown)
		{
			class746_0.method_17();
			Struct39.smethod_0(class746_0.Chart.Graphics, class746_0.rectangle_0, Label, Rotation, class746_0.TextFont, class746_0.FontColor, TextHorizontalAlignment, TextVerticalAlignment);
		}
	}

	internal Size method_1(SizeF layout)
	{
		Size size = new Size(0, 0);
		if (DisplayUnitType != 0 && IsShown)
		{
			size = Struct39.smethod_3(class746_0.Chart.Graphics, Label, Rotation, class746_0.TextFont, layout, TextHorizontalAlignment, TextVerticalAlignment);
		}
		class746_0.rectangle_1.Size = size;
		return size;
	}
}
