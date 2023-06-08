using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns18;

namespace ns19;

internal class Class1037
{
	internal static Class458 smethod_0(GraphicsPath graphicsPath_0, Class1031 class1031_0)
	{
		Class458 @class = new Class458();
		Class459 class2 = new Class459();
		class2.method_5(bool_1: false);
		@class.Add(class2);
		GraphicsPathIterator graphicsPathIterator = new GraphicsPathIterator(graphicsPath_0);
		int startIndex;
		int endIndex;
		bool isClosed;
		while (graphicsPathIterator.NextSubpath(out startIndex, out endIndex, out isClosed) > 0)
		{
			if (class2.method_4())
			{
				class2 = new Class459();
				class2.method_5(bool_1: false);
				@class.Add(class2);
			}
			byte pathType;
			int startIndex2;
			int endIndex2;
			while (graphicsPathIterator.NextPathType(out pathType, out startIndex2, out endIndex2) > 0)
			{
				if (class2.method_1() == null || class2.method_1().Count == 0)
				{
					class2.method_3(new PointF(class1031_0.vmethod_13(graphicsPath_0.PathPoints[startIndex].X), class1031_0.vmethod_13(graphicsPath_0.PathPoints[startIndex].Y)));
				}
				if (pathType == 1)
				{
					float[] array = new float[(endIndex2 - startIndex2 + 1) * 2];
					int num = 0;
					for (int i = startIndex2; i <= endIndex2; i++)
					{
						array[num++] = class1031_0.vmethod_13(graphicsPath_0.PathPoints[i].X);
						array[num++] = class1031_0.vmethod_13(graphicsPath_0.PathPoints[i].Y);
					}
					Class467 class452_ = new Class467(array);
					class2.Add(class452_);
				}
				else
				{
					if (pathType != 3)
					{
						throw new NotImplementedException("PathPointType==" + pathType);
					}
					if ((endIndex2 - startIndex2) % 3 != 0)
					{
						throw new ApplicationException();
					}
					for (int j = startIndex2; j < endIndex2; j += 3)
					{
						Struct89 struct89_ = default(Struct89);
						struct89_.method_1(new PointF(class1031_0.vmethod_13(graphicsPath_0.PathPoints[j].X), class1031_0.vmethod_13(graphicsPath_0.PathPoints[j].Y)));
						struct89_.method_3(new PointF(class1031_0.vmethod_13(graphicsPath_0.PathPoints[j + 1].X), class1031_0.vmethod_13(graphicsPath_0.PathPoints[j + 1].Y)));
						struct89_.method_5(new PointF(class1031_0.vmethod_13(graphicsPath_0.PathPoints[j + 2].X), class1031_0.vmethod_13(graphicsPath_0.PathPoints[j + 2].Y)));
						struct89_.method_7(new PointF(class1031_0.vmethod_13(graphicsPath_0.PathPoints[j + 3].X), class1031_0.vmethod_13(graphicsPath_0.PathPoints[j + 3].Y)));
						Class466 class3 = new Class466();
						class3.method_1(struct89_);
						class2.Add(class3);
					}
				}
				if (isClosed)
				{
					class2.method_5(bool_1: true);
				}
			}
		}
		return @class;
	}
}
