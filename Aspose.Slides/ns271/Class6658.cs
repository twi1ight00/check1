using System.Drawing;
using ns218;
using ns235;

namespace ns271;

internal class Class6658
{
	private const int int_0 = 1024;

	private Class6659 class6659_0;

	private readonly Class6660 class6660_0;

	public Class6660 Points => class6660_0;

	public Class6658(int EMHeight)
	{
		class6660_0 = new Class6660(1024f / (float)EMHeight);
	}

	public Class6217 method_0()
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		class6659_0 = class6660_0[0];
		class6659_0.IsRefPoint = true;
		Class6659 class3 = class6659_0;
		class2.Add(new Class6223(new float[2]
		{
			class6659_0.X,
			-class6659_0.Y
		}));
		for (int i = 1; i <= class6660_0.Count; i++)
		{
			Class6659 class4 = ((i >= class6660_0.Count || class3.IsEndOfContour) ? method_1(class6660_0[i]) : class6660_0[i]);
			if (!class4.IsOnCurve && !class4.IsRefPoint)
			{
				Class6659 class5 = ((i + 1 >= class6660_0.Count || class4.IsEndOfContour) ? method_1(class6660_0[i + 1]) : class6660_0[i + 1]);
				if (class5.IsOnCurve)
				{
					class2.Add(new Class6222(new PointF(class3.X, -class3.Y), new PointF(class4.X, -class4.Y), new PointF(class5.X, -class5.Y)));
					class3 = class4;
					class4 = class5;
					i++;
				}
				else
				{
					int num = Class5964.smethod_29((float)(class5.X - class4.X) / 2f);
					int num2 = Class5964.smethod_29((float)(class5.Y - class4.Y) / 2f);
					Class6659 class6 = new Class6659(num, num2, class4.X + num, class4.Y + num2, isOnCurve: true, isEndOfContour: false);
					class2.Add(new Class6222(new PointF(class3.X, -class3.Y), new PointF(class4.X, -class4.Y), new PointF(class6.X, -class6.Y)));
					class3 = class4;
					class4 = class6;
				}
			}
			else
			{
				class2.Add(new Class6223(new float[2]
				{
					class4.X,
					-class4.Y
				}));
			}
			if (class3.IsEndOfContour)
			{
				class2 = smethod_0(class2, @class);
				if (i < class6660_0.Count)
				{
					class4 = class6660_0[i];
				}
			}
			class3 = class4;
		}
		if (class6659_0 != null)
		{
			class2.Add(new Class6223(new float[2]
			{
				class6659_0.X,
				-class6659_0.Y
			}));
		}
		smethod_0(class2, @class);
		return @class;
	}

	private static Class6218 smethod_0(Class6218 figure, Class6217 path)
	{
		figure.IsClosed = true;
		path.Add(figure);
		return new Class6218();
	}

	private Class6659 method_1(Class6659 nextRefPoint)
	{
		Class6659 result = class6659_0;
		if (nextRefPoint != null)
		{
			class6659_0 = nextRefPoint;
			class6659_0.IsRefPoint = true;
		}
		return result;
	}
}
