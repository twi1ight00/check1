using ns161;
using ns164;
using ns167;

namespace ns163;

internal class Class4750
{
	internal Class4779 class4779_0;

	private float float_0;

	private Class4760 class4760_0;

	private Class4755 class4755_0;

	private float float_1;

	internal bool bool_0;

	internal Enum676 enum676_0;

	private float float_2;

	internal Class4755 LastElement
	{
		get
		{
			Class4763 lastSection = LastSection;
			return lastSection[lastSection.Count - 1];
		}
	}

	internal Class4763 LastSection => (Class4763)class4760_0[class4760_0.Count - 1];

	internal Class4755 CurrentElement
	{
		get
		{
			return class4755_0;
		}
		set
		{
			class4755_0 = value;
		}
	}

	internal Class4760 Document => class4760_0;

	internal float BottomOfLastElement
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

	internal float VerticalExpansion
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

	public float LeftMargin
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

	internal Class4750(Class4760 doc)
	{
		class4760_0 = doc;
	}
}
