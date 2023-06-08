using ns101;
using ns138;

namespace ns99;

internal class Class4495
{
	private struct Struct171
	{
		public static Struct171 struct171_0 = new Struct171(-1, -1);

		public int int_0;

		public int int_1;

		public int int_2;

		public bool IsEmpty
		{
			get
			{
				if (int_0 == struct171_0.int_0)
				{
					return int_2 == struct171_0.int_2;
				}
				return false;
			}
		}

		public Struct171(int xFrom, int y)
		{
			int_0 = xFrom;
			int_1 = int_0;
			int_2 = y;
		}
	}

	private Class4480 class4480_0;

	private double double_0;

	public Class4495(Class4480 glyph, double scale)
	{
		class4480_0 = glyph;
		double_0 = scale;
	}

	public void method_0(Class4491.Class4640 charDef)
	{
		Struct171 setInfo = Struct171.struct171_0;
		for (int i = 0; i < charDef.Height; i++)
		{
			for (int j = 0; j < charDef.Width; j++)
			{
				int num = i * charDef.Width + j;
				int num2 = (int)((double)num / 8.0);
				int num3 = num - num2 * 8;
				if ((charDef.Data[num2] & (1 << 7 - num3)) != 0)
				{
					if (setInfo.IsEmpty)
					{
						setInfo = new Struct171(j, i);
					}
					else
					{
						setInfo.int_1++;
					}
				}
				else if (!setInfo.IsEmpty)
				{
					method_1(charDef, setInfo);
					setInfo = Struct171.struct171_0;
				}
			}
			if (!setInfo.IsEmpty)
			{
				method_1(charDef, setInfo);
				setInfo = Struct171.struct171_0;
			}
		}
	}

	private void method_1(Class4491.Class4640 charDef, Struct171 setInfo)
	{
		double x = (double)(setInfo.int_0 + charDef.LeftOffset) * double_0;
		double num = (double)(setInfo.int_1 + charDef.LeftOffset) * double_0;
		double num2 = (double)(charDef.Height - setInfo.int_2 - (charDef.Height - charDef.TopOffset)) * double_0;
		class4480_0.Path.Segments.Add(new Class4614(x, num2));
		class4480_0.Path.Segments.Add(new Class4613(x, num2 + 1.0 * double_0));
		class4480_0.Path.Segments.Add(new Class4613(num + 1.0 * double_0, num2 + 1.0 * double_0));
		class4480_0.Path.Segments.Add(new Class4613(num + 1.0 * double_0, num2));
		class4480_0.Path.Segments.Add(new Class4611(x, num2));
	}
}
