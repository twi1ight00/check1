using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("CADD381F-75AA-423E-8EF5-A0AD26A0B60B")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class ColorOffset : IColorOffset
{
	internal float float_0 = float.NaN;

	internal float float_1 = float.NaN;

	internal float float_2 = float.NaN;

	public float Value0
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float Value1
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public float Value2
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}
}
