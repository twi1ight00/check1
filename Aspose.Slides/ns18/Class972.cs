using ns24;
using ns56;

namespace ns18;

internal class Class972
{
	internal static void smethod_0(Class516 path, Class1896 pathLstElementData, Class541[] geometryGuides, Class341[] adjValues)
	{
		Class1894 @class = pathLstElementData.delegate1549_0();
		int num = 0;
		Enum115[] commands = path.Commands;
		foreach (Enum115 @enum in commands)
		{
			Class2605 class2 = @class.delegate2773_0(Class516.class1151_0[(int)@enum]);
			switch (@enum)
			{
			case Enum115.const_1:
			{
				Class1897 class7 = (Class1897)class2.Object;
				smethod_1(class7.Pt, path.Data[num], path.Data[num + 1], geometryGuides, adjValues);
				num += 2;
				break;
			}
			case Enum115.const_2:
			{
				Class1895 class6 = (Class1895)class2.Object;
				smethod_1(class6.Pt, path.Data[num], path.Data[num + 1], geometryGuides, adjValues);
				num += 2;
				break;
			}
			case Enum115.const_3:
			{
				Class1891 class5 = (Class1891)class2.Object;
				class5.WR = Class954.smethod_11(path.Data[num++], geometryGuides, adjValues);
				class5.HR = Class954.smethod_11(path.Data[num++], geometryGuides, adjValues);
				class5.StAng = Class954.smethod_11(path.Data[num++], geometryGuides, adjValues);
				class5.SwAng = Class954.smethod_11(path.Data[num++], geometryGuides, adjValues);
				break;
			}
			case Enum115.const_4:
			{
				Class1898 class4 = (Class1898)class2.Object;
				smethod_1(class4.Pt1, path.Data[num], path.Data[num + 1], geometryGuides, adjValues);
				num += 2;
				smethod_1(class4.Pt2, path.Data[num], path.Data[num + 1], geometryGuides, adjValues);
				num += 2;
				break;
			}
			case Enum115.const_5:
			{
				Class1893 class3 = (Class1893)class2.Object;
				smethod_1(class3.Pt1, path.Data[num], path.Data[num + 1], geometryGuides, adjValues);
				num += 2;
				smethod_1(class3.Pt2, path.Data[num], path.Data[num + 1], geometryGuides, adjValues);
				num += 2;
				smethod_1(class3.Pt3, path.Data[num], path.Data[num + 1], geometryGuides, adjValues);
				num += 2;
				break;
			}
			}
		}
		@class.W = (double)path.Width / 12700.0;
		@class.H = (double)path.Height / 12700.0;
		@class.Fill = path.FillMode;
		@class.Stroke = path.Stroke;
		@class.ExtrusionOk = path.ExtrusionOk;
	}

	private static void smethod_1(Class1782 ptElementData, long x, long y, Class541[] geometryGuides, Class341[] adjValues)
	{
		ptElementData.X = Class954.smethod_11(x, geometryGuides, adjValues);
		ptElementData.Y = Class954.smethod_11(y, geometryGuides, adjValues);
	}
}
