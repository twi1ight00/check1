using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class950 : Class938
{
	private RectangleF rectangleF_0;

	private bool bool_0;

	private string string_1;

	private Class1441 class1441_0;

	internal Class1441 Destination
	{
		get
		{
			return class1441_0;
		}
		set
		{
			class1441_0 = value;
		}
	}

	internal Class950(Class1440 class1440_1, RectangleF rectangleF_1, string string_2, bool bool_1)
		: base(class1440_1)
	{
		rectangleF_0 = rectangleF_1;
		int int_ = 0;
		float x = 0f;
		float y = 0f;
		if (bool_1)
		{
			string[] array = string_2.Split('_');
			try
			{
				int_ = int.Parse(array[0]);
				x = float.Parse(array[1]);
				y = float.Parse(array[2]);
			}
			catch
			{
			}
			class1441_0 = new Class1441(int_, new PointF(x, y));
		}
		string_1 = string_2;
		bool_0 = bool_1;
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		if (class1440_0.method_7() != null)
		{
			class1440_0.method_7().method_10(this);
			class1447_0.method_22(class1440_0.method_7());
		}
		class1447_0.Write("/Type/Annot");
		class1447_0.Write("/Subtype/Link");
		class1447_0.method_14("/Rect", rectangleF_0);
		if (!class1440_0.method_1().method_7())
		{
			class1447_0.method_11("/BS", "<</Type/Border/S/S/W 0>>");
		}
		if (bool_0)
		{
			if (class1441_0 != null)
			{
				class1447_0.Write("/Dest");
				class1441_0.method_0(class1447_0);
			}
		}
		else
		{
			class1447_0.Write("/A");
			class1447_0.method_9();
			class1447_0.Write("/Type/Action");
			class1447_0.Write("/S/URI");
			class1447_0.method_12("/URI", string_1);
			class1447_0.method_10();
		}
		class1447_0.method_10();
		class1447_0.method_25();
	}

	[SpecialName]
	internal string method_4()
	{
		return string_1;
	}

	[SpecialName]
	internal void method_5(string string_2)
	{
		string_1 = string_2;
	}

	[SpecialName]
	internal bool method_6()
	{
		return bool_0;
	}
}
